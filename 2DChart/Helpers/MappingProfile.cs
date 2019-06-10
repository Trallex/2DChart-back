using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using _2DChart.Data.Models;
using _2DChart.Domain.Charts;
using _2DChart.Domain.Function;
using _2DChart.Domain.Repository;
using _2DChart.Domain.Users.Commands;

namespace _2DChart.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>()
                .ForMember(dto => dto.Guid, opt => opt.MapFrom(src => src.UserId));
            CreateMap<Repository, RepositoryDto>()
                .ForMember(dto => dto.Guid, opt => opt.MapFrom(src => src.RepositoryId));
            CreateMap<Chart, ChartDto>()
                .ForMember(dto => dto.Guid, opt => opt.MapFrom(src => src.ChartId))
                .ForMember(dto => dto.Name, opt => opt.MapFrom(src => src.Logo));
            CreateMap<Chart, RepositoryDto.ChartListDto>()
                .ForMember(dto => dto.Guid, opt => opt.MapFrom(src => src.ChartId))
                .ForMember(dto => dto.Name, opt => opt.MapFrom(src => src.Logo));
            CreateMap<Function, ChartDto.FunctionListDto>()
                .ForMember(dto => dto.Guid, opt => opt.MapFrom(src => src.FunctionId));;
            CreateMap<Function,FunctionDto>()
                .ForMember(dto => dto.Guid, opt => opt.MapFrom(src => src.FunctionId));
        }
    }
}
