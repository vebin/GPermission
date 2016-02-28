using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPermission.Common
{
    public class ConfigSettings
    {
        public static TimeSpan ReservationAutoExpiration = TimeSpan.FromMinutes(15);
        /// <summary>主库ENode连接字符串
        /// </summary>
        public static string ENodeConnectionString { get; set; }
        /// <summary>主库连接字符串
        /// </summary>
        public static string GPermissionConnectionString { get; set; }


    


  

        public static int BrokerProducerPort { get; set; }
        public static int BrokerConsumerPort { get; set; }
        public static int BrokerAdminPort { get; set; }

        public static void Initialize()
        {
            if (ConfigurationManager.ConnectionStrings["Enode"] != null)
            {
                ENodeConnectionString = ConfigurationManager.ConnectionStrings["Enode"].ConnectionString;
            }

            if (ConfigurationManager.ConnectionStrings["GPermission"] != null)
            {
                GPermissionConnectionString = ConfigurationManager.ConnectionStrings["GPermission"].ConnectionString;
            }




            BrokerProducerPort = 10000;
            BrokerConsumerPort = 10001;
            BrokerAdminPort = 10002;
        }
    }
}
