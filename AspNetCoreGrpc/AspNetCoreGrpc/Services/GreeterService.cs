using AspNetCoreGrpc;
using Grpc.Core;

namespace AspNetCoreGrpc.Services
{
    public class MyGrpcService1 : AspNetCoreGrpc.MyGrpcService1.MyGrpcService1Base
    {
        private readonly ILogger<MyGrpcService1> _logger;
        public MyGrpcService1(ILogger<MyGrpcService1> logger)
        {
            _logger = logger;
        }

        public override Task<MyGrpcHelloReply> MyGrpcSayHello(MyGrpcHelloRequest request, ServerCallContext context)
        {
            return Task.FromResult(new MyGrpcHelloReply
            {
                MField1Message = $"MyGrpcSayHello. {DateTime.Now}. request.MField1Name:" + request.MField1Name
            });
        }
    }
}