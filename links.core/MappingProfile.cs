﻿using AutoMapper;
using links.core.DTOs;
using links.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace links.core
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
                
        CreateMap<Category,CategoryDto>().ReverseMap();
        CreateMap<User, UserDto>().ReverseMap();
        CreateMap<Web, WebDto>().ReverseMap();
        CreateMap<Recommend, RecommendDto>().ReverseMap();
        }

    }
}
