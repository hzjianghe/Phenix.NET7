﻿using System.Threading.Tasks;
using Demo.InspectionStation.Plugin.Actor;
using Demo.InspectionStation.Plugin.Business;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Phenix.Actor;

namespace Demo.InspectionStation.Plugin.Api.OperationPoint
{
    /// <summary>
    /// 道闸Controller
    /// </summary>
    [EnableCors]
    [Route(ApiConfig.ApiOperationPointGatePath)]
    [ApiController]
    public sealed class GateController : Phenix.Core.Net.Api.ControllerBase
    {
        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="operationPointName">作业点名称</param>
        /// <returns>开闭(null=不确定)</returns>
        [Authorize]
        [HttpGet]
        public async Task<bool?> GetStatus(string operationPointName)
        {
            OperationPointStatus status = await ClusterClient.Default.GetGrain<IOperationPointGrain>(operationPointName).GetStatus();
            switch (status)
            {
                case OperationPointStatus.Shutdown:
                    return null;
                case OperationPointStatus.PermitThrough:
                    return false;
                default:
                    return true;
            }
        }

        /// <summary>
        /// 放行
        /// </summary>
        /// <param name="operationPointName">作业点名称</param>
        [Authorize]
        [HttpPut]
        public async Task PermitThrough(string operationPointName)
        {
            await ClusterClient.Default.GetGrain<IOperationPointGrain>(operationPointName).PermitThrough();
        }
    }
}

