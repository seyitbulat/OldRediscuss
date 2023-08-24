using AutoMapper;
using Rediscuss.Model.Dtos.Comment;
using Rediscuss.Model.Dtos.User;
using Rediscuss.Model.Entities;

namespace Rediscuss.Business.Profiles
{
	public class CommentProfile : Profile
	{
        public CommentProfile()
        {
            CreateMap<Comment, CommentGetDto>()
                .ForMember(dest => dest.CreatedByName, opt => opt.MapFrom(src => src.User.Username))
                .ForMember(dest => dest.UserImage, opt => opt.MapFrom(src => src.User.Base64Picture))
                .ForMember(dest => dest.ImageRoute, opt => opt.MapFrom(src => src.User.ImageRoute))
                ;
            CreateMap<CommentPostDto, Comment>();
        }
    }
}
