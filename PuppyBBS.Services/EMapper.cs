using EmitMapper.MappingConfiguration;
using System;
using System.Collections.Generic;
using System.Text;

namespace PuppyBBS.Services
{
    public class EMapper
    {

        public static TOUT Mapper<TIN, TOUT>(TIN model)
        {
            var config = new DefaultMapConfig()
            {

            };
            config.MatchMembers((s1, s2) => s1.Equals(s2, StringComparison.InvariantCultureIgnoreCase));
            var outout = global::EmitMapper.ObjectMapperManager
                .DefaultInstance.GetMapper<TIN, TOUT>(config)
               .Map(model);

            return outout;
        }

        public static void Mapper<TIN, TOUT>(TIN modelIN, TOUT modelOUT)
        {
            var config = new DefaultMapConfig();
            config.MatchMembers((s1, s2) => s1.Equals(s2, StringComparison.InvariantCultureIgnoreCase));
            var outout = global::EmitMapper.ObjectMapperManager
                .DefaultInstance.GetMapper<TIN, TOUT>(config);
            outout.Map(modelIN, modelOUT);
        }

        public static List<TOUT> Mapper<TIN, TOUT>(List<TIN> model, Action<TOUT> action)
        {
            var config = new DefaultMapConfig()
            {

            };
            List<TOUT> outout = new List<TOUT>(model.Count);
            foreach (var item in model)
            {
                config.MatchMembers((s1, s2) => s1.Equals(s2, StringComparison.InvariantCultureIgnoreCase));
                var ou = global::EmitMapper.ObjectMapperManager
                    .DefaultInstance.GetMapper<TIN, TOUT>(config)
                   .Map(item);
                if (action != null)
                {
                    action.Invoke(ou);
                }
                outout.Add(ou);
            }


            return outout;
        }
    }
}
