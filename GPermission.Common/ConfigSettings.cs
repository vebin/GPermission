﻿using System;
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
        /// <summary>应用系统表
        /// </summary>
        public static string AppSystemTable { get; set; }
        /// <summary>应用系统代码索引表
        /// </summary>
        public static string AppSystemCodeIndexTable { get; set; }
        /// <summary>角色表
        /// </summary>
        public static string RoleTable { get; set; }
        /// <summary>角色代码索引表
        /// </summary>
        public static string RoleCodeIndexTable { get; set; }

        /// <summary>用户表
        /// </summary>
        public static string UserTable { get; set; }
        /// <summary>用户代码索引表
        /// </summary>
        public static string UserCodeIndexTable { get; set; }
        /// <summary>用户角色表
        /// </summary>
        public static string UserRoleTable { get; set; }

        /// <summary>模块表
        /// </summary>
        public static string ModuleTable { get; set; }
        /// <summary>角色模块权限
        /// </summary>
        public static string RoleModulePermission { get; set; }
        /// <summary>权限表
        /// </summary>
        public static string PermissionTable { get; set; }
        /// <summary>模块权限表
        /// </summary>
        public static string ModulePermissionTable { get; set; }

        /// <summary>账号表
        /// </summary>
        public static string AccountTable { get; set; }
        /// <summary>账号,应用系统关联表
        /// </summary>
        public static string AccountAppSystemTable { get; set; }

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

            AppSystemTable = "AppSystem";
            AppSystemCodeIndexTable = "AppSystemCodeIndex";
            RoleTable = "Role";
            RoleCodeIndexTable = "RoleCodeIndex";
            UserTable = "User";
            UserCodeIndexTable = "UserCodeIndex";
            UserRoleTable = "UserRole";

            ModuleTable = "Module";
            PermissionTable = "Permission";
            ModulePermissionTable = "ModulePermission";
            AccountTable = "Account";
            AccountAppSystemTable = "AccountAppSystem";

            BrokerProducerPort = 10000;
            BrokerConsumerPort = 10001;
            BrokerAdminPort = 10002;
        }
    }
}
