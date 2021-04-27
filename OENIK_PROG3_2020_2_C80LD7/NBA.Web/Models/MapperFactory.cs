// <copyright file="MapperFactory.cs" company="C80LD7">
// Copyright (c) C80LD7. All rights reserved.
// </copyright>

namespace NBA.Web.Models
{
    using AutoMapper;

    /// <summary>
    /// Mapper factory class.
    /// </summary>
    public class MapperFactory
    {
        /// <summary>
        /// Creating mapper.
        /// </summary>
        /// <returns>IMapper.</returns>
        public static IMapper CreateMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Data.Model.Player, NBA.Web.Models.Player>()
                    .ForMember(dest => dest.PlayerID, map => map.MapFrom(src => src.PlayerID))
                    .ForMember(dest => dest.Name, map => map.MapFrom(src => src.Name))
                    .ForMember(dest => dest.Height, map => map.MapFrom(src => src.Height))
                    .ForMember(dest => dest.Weight, map => map.MapFrom(src => src.Weight))
                    .ForMember(dest => dest.Salary, map => map.MapFrom(src => src.Salary))
                    .ForMember(dest => dest.Post, map => map.MapFrom(src => src.Post))
                    .ForMember(dest => dest.TeamID, map => map.MapFrom(src => src.TeamID))
                    .ForMember(dest => dest.TeamName, map => map.MapFrom(src => src.Team == null ? string.Empty : src.Team.Name))
                    .ForMember(dest => dest.Birth, map => map.MapFrom(src => src.Birth))
                    .ForMember(dest => dest.Number, map => map.MapFrom(src => src.Number));
            });

            return config.CreateMapper();
        }
    }
}
