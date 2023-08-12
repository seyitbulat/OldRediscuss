using AutoMapper;
using Rediscuss.Model.Dtos.Post;
using Rediscuss.Model.Entities;

namespace Rediscuss.Business.Profiles
{
	public class PostProfile : Profile
	{
        public PostProfile()
        {
			CreateMap<Post, PostGetDto>();
			CreateMap<PostPostDto, Post>();
		}
    }
}
