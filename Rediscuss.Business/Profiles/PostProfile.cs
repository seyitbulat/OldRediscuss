using AutoMapper;
using Rediscuss.Model.Dtos.Post;
using Rediscuss.Model.Entities;

namespace Rediscuss.Business.Profiles
{
	public class PostProfile : Profile
	{
        public PostProfile()
        {
			CreateMap<Post, PostGetDto>()
				.ForMember(dest => dest.SubredisName, opt => opt.MapFrom(src => src.Subredis.SubredisName))
				.ForMember(dest => dest.PostedBy, opt => opt.MapFrom(src => src.User.Username));
			CreateMap<PostPostDto, Post>();
		}
    }
}
