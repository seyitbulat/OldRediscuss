using AutoMapper;
using Rediscuss.Model.Dtos.Subredis;
using Rediscuss.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rediscuss.Business.Profiles
{
	public class SubredisProfile : Profile
	{
        public SubredisProfile()
        {
            CreateMap<Subredis, SubredisGetDto>()
                .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.User.UserId));
            CreateMap<SubredisPostDto, Subredis>();
        }
    }
}
