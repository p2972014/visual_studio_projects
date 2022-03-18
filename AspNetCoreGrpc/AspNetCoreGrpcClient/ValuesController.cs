﻿using AspNetCoreGrpc;
using AutoMapper;
using Google.Protobuf;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using static AspNetCoreGrpc.GrpcMy;

namespace AspNetCoreGrpcClient
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IHostEnvironment _env;

        //private readonly IMapper _mapper;

        public ValuesController(
            IConfiguration configuration,
            IHostEnvironment env
            //, IMapper mapper
            )
        {
            _configuration = configuration;
            _env = env;
            //_mapper = mapper;
        }
        // GET: api/<ValuesController1>
        [HttpGet]
        public async Task<IEnumerable<string>> GetAsync()
        {
            var tmp3 = _env.IsDevelopment();
            var tmp_url = _configuration["GrpcServerUrl"];
            using var channel = GrpcChannel.ForAddress(tmp_url);
            var client = new GrpcMyClient(channel);
            var tmp_sended_obj =
                new GrpcMyRequest()
                {
                    MField1String = $"ValuesController. Get. {DateTime.Now}",
                    MField2Bytesstring = ByteString.CopyFrom(Encoding.UTF8.GetBytes("123"))
                };
            tmp_sended_obj.MField3Array.AddRange((new object[3]).Select((it, ind) => new GrpcModelField3() { MField1Int = ind, MField2Long = ind }));
            var tmp = await client.GrpcMySayHelloAsync(tmp_sended_obj);
            return new string[] { "value1", "value2", tmp.MField1String };
        }
    }
}