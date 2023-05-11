﻿using AuthenticationService.Models;
using AutoMapper;
namespace AuthenticationService

{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<User,UserViewModel>()
                .ConstructUsing(u =>new UserViewModel(u));

        }
    }
}
