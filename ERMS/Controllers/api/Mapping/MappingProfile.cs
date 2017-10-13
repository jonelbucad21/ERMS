using AutoMapper;
using ERMS.Controllers.api.DTOs;
using ERMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERMS.Controllers.api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Letter, LetterDto>();
            CreateMap<Sender, SenderDto>();
            CreateMap<LetterType, LetterTypeDto>();
        }
    }
}
