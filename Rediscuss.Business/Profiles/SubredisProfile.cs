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
            CreateMap<Subredis, SubredisGetDto>();
            CreateMap<SubredisPostDto, Subredis>();
        }
    }
}
