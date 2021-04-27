// <copyright file="PlayersController.cs" company="C80LD7">
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
    using NBA.Data.Model;
    using NBA.Logic;
    using NBA.Repository;
    using NBA.Web.Models;

    /// <summary>
    /// Player controller class.
    /// </summary>
    public class PlayersController : Controller
    {
        private readonly IMapper mapper;
        private readonly PlayerListViewModel vm;
        private readonly ITeamsRepository teamRepo;
        private readonly IPlayerRepository playerRepo;
        private readonly IPlayerLogic playerLogic;
        private readonly Team teamWeb;

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayersController"/> class.
        /// </summary>
        /// <param name="mapper">mapper reference.</param>
        /// <param name="playerLogic">player logic reference.</param>
        /// <param name="playerRepo">player repository reference.</param>
        /// <param name="teamRepo">team repository reference.</param>
        /// <param name="teamWeb">web type team reference.</param>
        public PlayersController(IMapper mapper, IPlayerLogic playerLogic, IPlayerRepository playerRepo, ITeamsRepository teamRepo, Team teamWeb)
        {
            this.mapper = mapper;
            this.vm = new PlayerListViewModel();
            this.vm.EditedPlayer = new Models.Player();
            this.playerLogic = playerLogic;
            this.playerRepo = playerRepo;
            this.teamRepo = teamRepo;
            this.teamWeb = teamWeb;

            var players = playerLogic.GetAllPlayers();
            this.vm.ListOfPlayers = mapper.Map<IList<Data.Model.Player>, List<Models.Player>>(players);
        }

        /// <summary>
        /// Index controller.
        /// </summary>
        /// <returns>IActionResult.</returns>
        public IActionResult Index()
        {
            this.ViewData["editAction"] = "AddNew";
            return this.View("PlayersIndex", this.vm);
        }

        /// <summary>
        /// Details controller.
        /// </summary>
        /// <param name="id">Player's id.</param>
        /// <returns>IActionResult.</returns>
        public IActionResult Details(int id)
        {
            return this.View("PlayersDetails", this.GetPlayerModel(id));
        }

        /// <summary>
        /// Remove Controller.
        /// </summary>
        /// <param name="id">Player's id.</param>
        /// <returns>IActionResult.</returns>
        public IActionResult Remove(int id)
        {
            this.TempData["editResult"] = "Delete FAILS";
            if (this.playerLogic.DeletePlayer(id))
            {
                this.TempData["editResult"] = "Delete OK";
            }

            return this.RedirectToAction(nameof(this.Index));
        }

        /// <summary>
        /// Edit Controller.
        /// </summary>
        /// <param name="id">Player's id.</param>
        /// <returns>IActionResult.</returns>
        public IActionResult Edit(int id)
        {
            this.ViewData["editAction"] = "Edit";
            this.vm.EditedPlayer = this.GetPlayerModel(id);
            return this.View("PlayersIndex", this.vm);
        }

        /// <summary>
        /// Edit controller.
        /// </summary>
        /// <param name="player">Player.</param>
        /// <param name="editAction">edit action.</param>
        /// <returns>IActionResult.</returns>
        [HttpPost]
        public IActionResult Edit(Models.Player player, string editAction)
        {
            if (this.ModelState.IsValid && player != null)
            {
                this.TempData["editResult"] = "Edit OK";
                if (editAction == "AddNew")
                {
                    try
                    {
                        var team = this.teamRepo.GetAll().SingleOrDefault(x => x.Name == player.TeamName);
                        this.playerLogic.AddNewPlayer(this.ConvertToDataEntity(player));
                    }
                    catch (ArgumentException ex)
                    {
                        this.TempData["editResult"] = "AddPlayer FAIL: " + ex.Message;
                    }
                }
                else
                {
                    if (!this.playerLogic.UpdatePlayer(this.playerLogic.GetOnePlayerById(player.PlayerID).PlayerID))
                    {
                        this.TempData["editResult"] = "Edit FAIL";
                    }
                }

                return this.RedirectToAction(nameof(this.Index));
            }
            else
            {
                this.ViewData["editAction"] = "Edit";
                this.vm.EditedPlayer = player;
                return this.View("PlayersIndex", this.vm);
            }
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

        private Models.Player GetPlayerModel(int id)
        {
            Data.Model.Player onePlayer = this.playerLogic.GetOnePlayerById(id);
            return this.mapper.Map<Data.Model.Player, Models.Player>(onePlayer);
        }

        /// <summary>
        /// Converts PlayerUI entity to Player db entity.
        /// </summary>
        /// <param name="webType">Team ui entity.</param>
        /// <returns>Player db entity.</returns>
        private Teams ConvertToTeamEntity(Team webType)
        {
            Teams team = new Teams();
            if (webType != null)
            {
                team.TeamID = webType.TeamID;
                team.Name = webType.TeamName;
                team.Coach = webType.Coach;
                team.Region = webType.Region;
            }

            return team;
        }
    }
}
