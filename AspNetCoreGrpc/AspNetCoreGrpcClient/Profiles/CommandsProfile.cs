using AspNetCoreGrpc;
using AspNetCoreGrpcClient.DataObjects;
using AutoMapper;
using System.Text;

namespace AspNetCoreGrpcClient.Profiles
{
    public class DtoValuesItemProfile : Profile
    {
        public DtoValuesItemProfile()
        {
            // Source -> Target
            CreateMap<GrpcMyReply, DtoValuesItem>()
                .ForMember(dest => dest.MField2Bytesstring, opt => opt.MapFrom(src => Encoding.UTF8.GetString(src.MField2Bytesstring.ToArray())))
                .ForMember(dest => dest.MField3Array, opt => opt.MapFrom(src => src.MField3Array.ToArray()))
                //.ForMember(dest => dest.Value, opt => opt.Ignore())
                ;
        }
    }
}