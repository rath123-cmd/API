using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Commander.Data;
using Commander.Models;

namespace Commander.Profiles
{
    public class CommandProfiles : Profile
    {
        public CommandProfiles()
        {
            CreateMap<Command, CommandModel>();
            CreateMap<CommandWriteModel, Command>();
            CreateMap<CommandWriteModel, CommandModel>();
            CreateMap<CommandUpdaterModel, Command>();
            CreateMap<Command, CommandUpdaterModel>();
        }
    }
}
