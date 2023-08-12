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
			CreateMap<User, UserGetDto>();
			CreateMap<UserPostDto, User>();
		}
    }
}
