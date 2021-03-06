﻿using Orleans.Configuration;
using Phenix.Core;
using Phenix.Core.Data;

namespace Phenix.Services.Host
{
    public static class OrleansConfig
    {
        private static string _clusterId;

        /// <summary>
        /// 集群的唯一ID
        /// 默认：Database.Default.DataSourceKey
        /// </summary>
        public static string ClusterId
        {
            get { return AppSettings.GetProperty(ref _clusterId, Database.Default.DataSourceKey); }
            set { AppSettings.SetProperty(ref _clusterId, value); }
        }

        private static string _serviceId;

        /// <summary>
        /// 服务的唯一ID
        /// 默认：Database.Default.DataSourceKey
        /// </summary>
        public static string ServiceId
        {
            get { return AppSettings.GetProperty(ref _serviceId, Database.Default.DataSourceKey); }
            set { AppSettings.SetProperty(ref _serviceId, value); }
        }

        private static int? _defaultSiloPort; //注意: 需将字段定义为Nullable<T>类型，以便AppSettings区分是否曾被自己初始化

        /// <summary>
        /// Silo端口
        /// 默认：EndpointOptions.DEFAULT_SILO_PORT
        /// </summary>
        public static int DefaultSiloPort
        {
            get { return AppSettings.GetProperty(ref _defaultSiloPort, EndpointOptions.DEFAULT_SILO_PORT); }
            set { AppSettings.SetProperty(ref _defaultSiloPort, value); }
        }

        private static int? _defaultGatewayPort; //注意: 需将字段定义为Nullable<T>类型，以便AppSettings区分是否曾被自己初始化

        /// <summary>
        /// Gateway端口
        /// 默认：EndpointOptions.DEFAULT_GATEWAY_PORT
        /// </summary>
        public static int DefaultGatewayPort
        {
            get { return AppSettings.GetProperty(ref _defaultGatewayPort, EndpointOptions.DEFAULT_GATEWAY_PORT); }
            set { AppSettings.SetProperty(ref _defaultGatewayPort, value); }
        }

        private static string _dashboardUsername;

        /// <summary>
        /// Dashboard登录用户名
        /// 默认：null
        /// </summary>
        public static string DashboardUsername
        {
            get { return AppSettings.GetProperty(ref _dashboardUsername, (string) null); }
            set { AppSettings.SetProperty(ref _dashboardUsername, value); }
        }

        private static string _dashboardPassword;

        /// <summary>
        /// Dashboard登录用户口令
        /// 默认：null
        /// </summary>
        public static string DashboardPassword
        {
            get { return AppSettings.GetProperty(ref _dashboardPassword, (string) null, true); }
            set { AppSettings.SetProperty(ref _dashboardPassword, value, true); }
        }

        private static string _dashboardHost;

        /// <summary>
        /// Dashboard绑定http主机名
        /// 默认：*
        /// </summary>
        public static string DashboardHost
        {
            get { return AppSettings.GetProperty(ref _dashboardHost, "*"); }
            set { AppSettings.SetProperty(ref _dashboardHost, value); }
        }

        private static int? _dashboardPort; //注意: 需将字段定义为Nullable<T>类型，以便AppSettings区分是否曾被自己初始化

        /// <summary>
        /// Dashboard绑定http访问的端口
        /// 默认：8080
        /// </summary>
        public static int DashboardPort
        {
            get { return AppSettings.GetProperty(ref _dashboardPort, 8080); }
            set { AppSettings.SetProperty(ref _dashboardPort, value); }
        }

        private static bool? _dashboardHostSelf; //注意: 需将字段定义为Nullable<T>类型，以便AppSettings区分是否曾被自己初始化

        /// <summary>
        /// Dashboard托管自己的http服务器
        /// 默认：true
        /// </summary>
        public static bool DashboardHostSelf
        {
            get { return AppSettings.GetProperty(ref _dashboardHostSelf, true); }
            set { AppSettings.SetProperty(ref _dashboardHostSelf, value); }
        }

        private static int? _dashboardCounterUpdateIntervalMs; //注意: 需将字段定义为Nullable<T>类型，以便AppSettings区分是否曾被自己初始化

        /// <summary>
        /// Dashboard采样更新间隔(毫秒)
        /// 默认：10000
        /// </summary>
        public static int DashboardCounterUpdateIntervalMs
        {
            get { return AppSettings.GetProperty(ref _dashboardCounterUpdateIntervalMs, 10000); }
            set { AppSettings.SetProperty(ref _dashboardCounterUpdateIntervalMs, value); }
        }
    }
}
