﻿using System.Threading.Tasks;
using Demo.InspectionStation.Plugin.Actor;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Phenix.Actor;

namespace Demo.InspectionStation.Plugin.Api.OperationPoint
{
    /// <summary>
    /// 磅秤Controller
    /// </summary>
    [EnableCors]
    [Route(ApiConfig.ApiOperationPointWeighbridgePath)]
    [ApiController]
    public sealed class WeighbridgeController : Phenix.Core.Net.Api.ControllerBase
    {
        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="operationPointName">作业点名称</param>
        /// <returns>称重重量</returns>
        [Authorize]
        [HttpGet]
        public async Task<int> Get(string operationPointName)
        {
            return await ClusterClient.Default.GetGrain<IOperationPointGrain>(operationPointName).GetWeighbridge();
        }

        /// <summary>
        /// 设置
        /// </summary>
        /// <param name="operationPointName">作业点名称</param>
        [Authorize]
        [HttpPut]
        public async Task Set(string operationPointName)
        {
            await ClusterClient.Default.GetGrain<IOperationPointGrain>(operationPointName).SetWeighbridge(await Request.ReadBodyAsync<int>());
        }

        /// <summary>
        /// 心跳(每10秒至少2次)
        /// </summary>
        /// <param name="operationPointName">作业点名称</param>
        [Authorize]
        [HttpPost]
        public async Task Alive(string operationPointName)
        {
            await ClusterClient.Default.GetGrain<IOperationPointGrain>(operationPointName).WeighbridgeAlive();
        }
    }
}
