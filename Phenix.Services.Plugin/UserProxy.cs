﻿using System;
using System.Threading.Tasks;
using Phenix.Actor;
using Phenix.Core.Reflection;
using Phenix.Core.Security;

namespace Phenix.Services.Plugin
{
    /// <summary>
    /// 用户资料
    /// </summary>
    [Serializable]
    public class UserProxy : EntityGrainProxyBase<UserProxy, User, IUserGrain>, IUserProxy
    {
        #region 属性

        long IUserProxy.Id
        {
            get { return GetKernelPropertyAsync<long>(p => p.Id).Result; }
        }

        Teams IUserProxy.RootTeams
        {
            get { return GetKernelPropertyAsync<Teams>(p => p.RootTeams).Result; }
        }

        bool IUserProxy.IsAuthenticated
        {
            get { return GetKernelPropertyAsync<bool>(p => p.IsAuthenticated).Result; }
        }

        #endregion

        #region 方法

        Task<User> IUserProxy.FetchUser()
        {
            return Grain.FetchKernel();
        }

        Task<string> IUserProxy.CheckIn(string name, string phone, string eMail, string regAlias, string requestAddress)
        {
            return Grain.CheckIn(name, phone, eMail, regAlias, requestAddress);
        }

        Task<bool> IUserProxy.IsValidLogon(string timestamp, string signature, string requestAddress, bool throwIfNotConform)
        {
            return Grain.IsValidLogon(timestamp, signature, requestAddress, throwIfNotConform);
        }

        Task<bool> IUserProxy.IsValid(string timestamp, string signature, string requestAddress, bool throwIfNotConform)
        {
            return Grain.IsValid(timestamp, signature, requestAddress, throwIfNotConform);
        }

        Task IUserProxy.Logon(string tag)
        {
            return Grain.Logon(tag);
        }

        Task<bool> IUserProxy.IsInRole(string role)
        {
            return Grain.IsInRole(role);
        }

        Task<string> IUserProxy.Encrypt(object data)
        {
            return Grain.Encrypt(data is string ds ? ds : Utilities.JsonSerialize(data));
        }

        Task<string> IUserProxy.Decrypt(string cipherText)
        {
            return Grain.Decrypt(cipherText);
        }

        Task<bool> IUserProxy.ChangePassword(string newPassword, bool throwIfNotConform)
        {
            return Grain.ChangePassword(newPassword, throwIfNotConform);
        }

        #endregion
    }
}