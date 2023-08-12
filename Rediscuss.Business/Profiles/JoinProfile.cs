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
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.User.UserId))
                .ForMember(dest => dest.SubredisId, opt => opt.MapFrom(src => src.Subredis.SubredisId));

            CreateMap<JoinPostDto, Join>();
            CreateMap<JoinPutDto, Join>();
		}
    }
}
