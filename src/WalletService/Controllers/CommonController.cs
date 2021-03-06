﻿using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WalletServiceApi.JsonRpc;
using WalletServiceApi.Models;
using SubmitTxReq = WalletServiceApi.Models.SubmitTxReq;

namespace WalletServiceApi.Controllers
{
    /// <summary>
    /// 其他接口
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class CommonController : JsonRpcService.BaseService
    {
        public CommonController(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {

        }

        /// <summary>
        /// 提交已签名交易
        /// </summary>
        /// <param name="data">交易数据</param>
        /// <returns>处理结果</returns>
        [HttpPost("SubmitTx")]
        public async Task<BaseRsp<dynamic>> SubmitTx(SubmitTxReq data)
        {
            return await CallRpc<dynamic>(data.Node, new BaseRpc() { method = RpcMethod.GetBlockCount.ToString().ToLower() });
        }

        /// <summary>
        /// 获取指定节点上的区块高度
        /// </summary>
        /// <param name="node">节点信息</param>
        /// <returns></returns>
        [HttpPost("GetBlockCount")]
        public async Task<BaseRsp<dynamic>> GetBlockCount(NodeInfo node)
        {
            return await CallRpc<dynamic>(node, new BaseRpc() { method = RpcMethod.GetBlockCount.ToString().ToLower() });
        }
    }
}