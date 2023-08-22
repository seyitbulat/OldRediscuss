using AutoMapper;
using Rediscuss.Model.Dtos.Join;
using Rediscuss.Model.Entities;

namespace Rediscuss.Business.Profiles
{
	public class JoinProfile : Profile
	{
        public JoinProfile()
        {
            CreateMap<Join, JoinGetDto>()
                .ForMember(dest => dest.SubredisName, opt => opt.MapFrom(src => src.Subredis.SubredisName));         
            CreateMap<JoinPostDto, Join>();
            CreateMap<JoinPutDto, Join>();
		}
    }
}
