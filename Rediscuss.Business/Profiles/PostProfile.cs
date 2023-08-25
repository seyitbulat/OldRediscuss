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
				.ForMember(dest => dest.PostedBy, opt => opt.MapFrom(src => src.User.Username))
				.ForMember(dest => dest.PostedByImage, opt => opt.MapFrom(src => src.User.Base64Picture))
				.ForMember(dest => dest.PostedByContentType, opt => opt.MapFrom(src => "image/"+Path.GetExtension(src.User.ImageRoute)));
			CreateMap<PostPostDto, Post>();
		}
    }
}
