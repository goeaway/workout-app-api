using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using WorkoutApp.API.Application.Models.Workout;
using WorkoutApp.API.Persistence.Entities;

namespace WorkoutApp.API.Application.Mapping
{
    public class WorkoutProfile : Profile
    {
        public WorkoutProfile()
        {
            CreateMap<WorkoutEntity, WorkoutDTO>();
        }
    }
}
