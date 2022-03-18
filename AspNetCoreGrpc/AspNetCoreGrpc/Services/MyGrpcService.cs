using AspNetCoreGrpc;
using Grpc.Core;

namespace AspNetCoreGrpc.Services
{
    public class GrpcMyService : AspNetCoreGrpc.GrpcMy.GrpcMyBase
    {
        private readonly ILogger<GrpcMyService> _logger;
        public GrpcMyService(ILogger<GrpcMyService> logger)
        {
            _logger = logger;
        }

        public override Task<GrpcMyHelloReply> GrpcMySayHello(GrpcMyHelloRequest request, ServerCallContext context)
        {
            return Task.FromResult(new GrpcMyHelloReply
            {
                MField1Message = $"GrpcMySayHello. {DateTime.Now}. request.MField1Name:" + request.MField1Name
            });
        }
    }
}