using AutoMapper;
using Rediscuss.Model.Dtos.PostImageDto;
using Rediscuss.Model.Entities;

namespace Rediscuss.Business.Profiles
{
    public class PostImageProfile : Profile
    {
        public PostImageProfile()
        {
            CreateMap<PostImage, PostImageGetDto>()
                .ForMember(dest => dest.PostPicture, opt => opt.MapFrom(src => src.Base64Picture));

            CreateMap<PostImagePostDto, PostImage>()
                .ForMember(dest => dest.PostPicture, opt => opt.MapFrom(src => Convert.FromBase64String(src.Base64Picture)));
        }
    }
}
