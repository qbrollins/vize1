﻿using AutoMapper;
using Internet_1.Models;
using Internet_1.ViewModels;

namespace Internet_1.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Surway, SurwayModel>().ReverseMap();
            CreateMap<SurwayQuestions, SurwayQuestionsModel>().ReverseMap();
            CreateMap<AppUser, UserModel>().ReverseMap();
            CreateMap<AppUser, RegisterModel>().ReverseMap();
            CreateMap<Todo, TodoModel>().ReverseMap();
        }
    }
}
