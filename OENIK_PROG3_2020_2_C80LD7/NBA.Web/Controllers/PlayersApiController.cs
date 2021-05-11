// <copyright file="PlayersApiController.cs" company="C80LD7">
// Copyright (c) C80LD7. All rights reserved.
// </copyright>

namespace NBA.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;
    using NBA.Logic;

    /// <summary>
    /// Api controller class.
    /// </summary>
    [CLSCompliant(false)]
    public class PlayersApiController : Controller
    {
        private IMapper mapper;
        private IPlayerLogic playerLogic;

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayersApiController"/> class.
        /// </summary>
        /// <param name="mapper">mapper reference.</param>
        /// <param name="playerLogic">reference to players's logic.</param>
        public PlayersApiController(IMapper mapper, IPlayerLogic playerLogic)
        {
            this.mapper = mapper;
            this.playerLogic = playerLogic;
        }

        /// <summary>
        /// Get all players.
        /// </summary>
        /// <returns>list of players.</returns>
        [HttpGet]
        [ActionName("all")]
        public IEnumerable<Models.Player> GetAll()
        {
            var players = this.playerLogic.GetAllPlayers();
            return this.mapper.Map<IList<Data.Model.Player>, List<Models.Player>>(players);
        }

        /// <summary>
        /// Delete one player method.
        /// </summary>
        /// <param name="id">Player's id.</param>
        /// <returns>ApiResult.</returns>
        [HttpGet]
        [ActionName("del")]
        public ApiResult DelOnePlayer(int id)
        {
            return new ApiResult() { OperationResult = this.playerLogic.DeletePlayer(id) };
        }

        /// <summary>
        /// Add one player method.
        /// </summary>
        /// <param name="player">player to add.</param>
        /// <returns>ApiResult.</returns>
        [HttpPost]
        [ActionName("add")]
        public ApiResult AddOnePlayer(Models.Player player)
        {
            bool success = true;
            try
            {
                this.playerLogic.AddNewPlayer(this.ConvertToDataEntity(player));
            }
            catch (ArgumentException ex)
            {
                success = false;
                Console.WriteLine(ex.Message);
            }

            return new ApiResult() { OperationResult = success };
        }

        /// <summary>
        /// Mod one player method.
        /// </summary>
        /// <param name="player">player to modify.</param>
        /// <returns>ApiResult.</returns>
        [HttpPost]
        [ActionName("mod")]
        public ApiResult ModOnePlayer(Models.Player player)
        {
            return new ApiResult() { OperationResult = this.playerLogic.ChangePlayer(this.ConvertToDataEntity(player)) };
        }

        private Data.Model.Player ConvertToDataEntity(Models.Player webType)
        {
            Data.Model.Player player = new Data.Model.Player();
            if (webType != null)
            {
                player.PlayerID = webType.PlayerID;
                player.Name = webType.Name;
                player.Salary = webType.Salary;
                player.Number = webType.Number;
                player.Team = this.playerLogic.FindTeamByName(webType.TeamName);
                player.Post = (Data.Model.Player.PositionType)webType.Post;
                player.Height = webType.Height;
                player.Weight = webType.Weight;
                player.Birth = webType.Birth;
            }

            return player;
        }
    }
}
