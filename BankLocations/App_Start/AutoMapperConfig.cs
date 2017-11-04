using AutoMapper;
using BankLocations.Dto;
using BankLocations.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BankLocations.App_Start
{
    public class AutoMapperConfig
    {
        public static void RegisterMapper()
        {
            Mapper.Initialize(cfg =>
            {
                //cfg.CreateMap<Zone, ZoneDto>();                
                //cfg.CreateMap<Bank, BankDto>();
                //cfg.CreateMap<Location, LocationDto>();
            });
        }
    }
}