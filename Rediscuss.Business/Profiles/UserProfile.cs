using AutoMapper;
using Rediscuss.Model.Dtos.User;
using Rediscuss.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rediscuss.Business.Profiles
{
	public class UserProfile : Profile
	{
        public UserProfile()
        {
			CreateMap<User, UserGetDto>()
				.ForMember(dest => dest.UserImage, opt => opt.MapFrom(src => src.Base64Picture))
				.ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate.Value.ToString("yyyy-MM-dd")));
				
			CreateMap<UserPostDto, User>();
			//.ForMember(dest => dest.UserImage, opt => opt.MapFrom(src => Convert.FromBase64String(src.Base64Picture)));
			CreateMap<UserSignupDto, User>();
			CreateMap<UserPutDto, User>();
			//.ForMember(dest => dest.UserImage, opt => opt.MapFrom(src => Convert.FromBase64String(src.Base64Picture)));

			CreateMap<UserSetUpDto, User>();
		}
    }
}
