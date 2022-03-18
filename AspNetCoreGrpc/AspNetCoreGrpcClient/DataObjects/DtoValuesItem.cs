using Google.Protobuf;

namespace AspNetCoreGrpcClient.DataObjects
{
    public class DtoValuesItem
    {
        public string? Value { get; set; }
        public string? MField1String { get; set; }
        public string? MField2Bytesstring { get; set; }
        public AspNetCoreGrpc.GrpcModelField3[]? MField3Array { get; set; }
    }
}
