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
            CreateMap<Comment, CommentGetDto>();
            CreateMap<CommentPostDto, Comment>();
        }
    }
}
