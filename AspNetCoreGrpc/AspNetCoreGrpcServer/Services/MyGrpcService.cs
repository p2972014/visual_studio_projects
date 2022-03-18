using AspNetCoreGrpc;
using Google.Protobuf;
using Grpc.Core;
using System.Text;

namespace AspNetCoreGrpc.Services
{
    public class GrpcMyService : AspNetCoreGrpc.GrpcMy.GrpcMyBase
    {
        private readonly ILogger<GrpcMyService> _logger;
        public GrpcMyService(ILogger<GrpcMyService> logger)
        {
            _logger = logger;
        }

        public override Task<GrpcMyReply> GrpcMyFunc(GrpcMyRequest request, ServerCallContext context)
        {
            var tmp_sended_obj =
                new GrpcMyReply
                {
                    MField1String = $"GrpcMySayHello. {DateTime.Now}. request.MField1Name:" + request.MField1String,
                    MField2Bytesstring = ByteString.CopyFrom(Encoding.UTF8.GetBytes("456"))
                };
            tmp_sended_obj.MField3Array.AddRange(request.MField3Array.Select(it => new GrpcModelField3() { MField1Int = it.MField1Int, MField2Long = it.MField2Long + 1 }));

            return Task.FromResult(tmp_sended_obj);
        }
    }
}