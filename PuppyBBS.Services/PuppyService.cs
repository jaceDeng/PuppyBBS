using NPoco;
using NPoco.Expressions;
using NPoco.Linq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace PuppyBBS.Services
{
    /// <summary>
    /// 服务基类
    /// </summary>
    public class PuppyService<T>
    {
        private String _connectString;
        public PuppyService(string connectString)
        {
            _connectString = connectString;
        }

        public string ConnectString
        {
            get
            {
                return _connectString;
            }
        }



        protected virtual NPoco.Database GetDatabase()
        {
            return new NPoco.Database(_connectString, DatabaseType.SQLite, System.Data.SQLite.SQLiteFactory.Instance);

        }



        public virtual List<T> Fetch()
        {
            using (var db = GetDatabase())
            {
                return db.Fetch<T>();
            }
        }

        public virtual List<T> Fetch(string sql, params object[] args)
        {
            using (var db = GetDatabase())
            {
                return db.Fetch<T>(sql, args);
            }
        }

        public virtual List<T> Fetch(string where)
        {
            using (var db = GetDatabase())
            {
                return db.Fetch<T>(where);
            }
        }

        public virtual List<T> Fetch(Expression<Func<T, bool>> whereExpression)
        {
            using (var db = GetDatabase())
            {
                return db.Query<T>().Where(whereExpression).ToList();
            }
        }

        public virtual Page<T> PageQuery(long page, long itemsPerPage, string sql, params object[] args)
        {
            using (var db = GetDatabase())
            {
                return db.Page<T>(page, itemsPerPage, sql, args);
            }
        }

        public virtual Page<T> PageQuery(int page, int itemsPerPage, Expression<Func<T, bool>> whereExpression)
        {
            using (var db = GetDatabase())
            {
                return db.Query<T>().Where(whereExpression).ToPage(page, itemsPerPage);
            }
        }

        public virtual T SingleOrDefaultById(object primaryKey)
        {
            using (var db = GetDatabase())
            {
                return db.SingleOrDefaultById<T>(primaryKey);
            }
        }

        public virtual T SingleOrDefault(Expression<Func<T, bool>> whereExpression)
        {
            using (var db = GetDatabase())
            {
                SqlExpression<T> express = new DefaultSqlExpression<T>(db);
                express = express.Where(whereExpression);
                string where = express.Context.ToWhereStatement();
                var poco = db.FirstOrDefault<T>(where, express.Context.Params);
                return poco;
            }
        }

        public virtual int Count(Expression<Func<T, bool>> whereExpression)
        {
            using (var db = GetDatabase())
            {
                return db.Query<T>().Where(whereExpression).Count();
            }
        }

        public virtual bool Exist(Expression<Func<T, bool>> whereExpression)
        {
            using (var db = GetDatabase())
            {
                return db.Query<T>().Where(whereExpression).Count() > 0;
            }
        }


        public virtual object Insert(T poco)
        {
            using (var db = GetDatabase())
            {
                return db.Insert<T>(poco);
            }
        }

        public virtual void Save(T poco)
        {
            using (var db = GetDatabase())
            {
                db.Save<T>(poco);
            }
        }


        public virtual int Update(object primaryKey, Expression<Func<T, object>> fields)
        {
            using (var db = GetDatabase())
            {
                var poco = db.SingleOrDefaultById<T>(primaryKey);
                return db.Update<T>(poco, fields);
            }
        }

        public virtual int Update(Expression<Func<T, bool>> whereExpression, Func<T, T> funcUpdate)
        {
            using (var db = GetDatabase())
            {
                SqlExpression<T> express = new DefaultSqlExpression<T>(db);
                express = express.Where(whereExpression);
                string where = express.Context.ToWhereStatement();
                var poco = db.SingleOrDefault<T>(where, express.Context.Params);
                if (poco == null)
                {
                    return 0;
                }

                var snapshot = db.StartSnapshot(poco);
                poco = funcUpdate(poco);
                //return db.Update(poco, columns: snapshot.UpdatedColumns().ToArray());

                var columns = snapshot.UpdatedColumns().ToArray();
                var result = db.Update(poco, columns: columns);
                if (result == 0 && columns.Length == 0)
                {
                    return 1; // 缓存中的数据和要更新的数据对应的字段值相等
                }
                return result;
            }
        }

        public virtual int Update(object poco, IEnumerable<string> columns)
        {
            using (var db = GetDatabase())
            {
                return db.Update(poco, columns);
            }
        }

        public virtual int Delete(Expression<Func<T, bool>> whereExpression)
        {

            using (var db = GetDatabase())
            {
                /**
                    *生成对应的where sql 
                    */
                SqlExpression<T> express = new DefaultSqlExpression<T>(db);
                express = express.Where(whereExpression);
                string where = express.Context.ToWhereStatement();
                if (where.StartsWith("WHERE"))
                {
                    where = where.Remove(0, 5);
                }
                return db.DeleteWhere<T>(where, express.Context.Params);
            }
        }
    }
}
