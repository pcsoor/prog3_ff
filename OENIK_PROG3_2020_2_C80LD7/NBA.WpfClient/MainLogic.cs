// <copyright file="MainLogic.cs" company="C80LD7">
// Copyright (c) C80LD7. All rights reserved.
// </copyright>

namespace NBA.WpfClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Text;
    using System.Text.Json;
    using System.Threading.Tasks;
    using GalaSoft.MvvmLight.Messaging;

    /// <summary>
    /// Logic class.
    /// </summary>
    public class MainLogic
    {
        private string url = "https://localhost:44354/PlayersApi/";
        private HttpClient client = new HttpClient();
        private JsonSerializerOptions jsonOptions = new JsonSerializerOptions(JsonSerializerDefaults.Web);

        /// <summary>
        /// Sends result message.
        /// </summary>
        /// <param name="success">result.</param>
        public void SendMessage(bool success)
        {
            string msg = success ? "Operation completed successfully" : "Operation failed";
            Messenger.Default.Send(msg, "PlayerResult");
        }

        /// <summary>
        /// Get all players through api controller.
        /// </summary>
        /// <returns>list of players.</returns>
        public List<PlayerVM> ApiGetPlayers()
        {
            string json = this.client.GetStringAsync(this.url + "all").Result;
            var list = JsonSerializer.Deserialize<List<PlayerVM>>(json, this.jsonOptions);
            return list;
        }

        /// <summary>
        /// Delete one player through api controller.
        /// </summary>
        /// <param name="player">player to delete.</param>
        public void ApiDelPlayer(PlayerVM player)
        {
            bool success = false;
            if (player != null)
            {
                string json = this.client.GetStringAsync(this.url + "del/" + player.PlayerID.ToString()).Result;
                JsonDocument doc = JsonDocument.Parse(json);

                success = doc.RootElement.EnumerateObject().First().Value.GetRawText() == "true";
            }

            this.SendMessage(success);
        }

        /// <summary>
        /// Edit one player through api controller.
        /// </summary>
        /// <param name="player">player to edit.</param>
        /// <param name="isEditing">editing or not.</param>
        /// <returns>bool.</returns>
        public bool ApiEditPlayer(PlayerVM player, bool isEditing)
        {
            if (player == null)
            {
                return false;
            }

            string myUrl = isEditing ? this.url + "mod" : this.url + "add";

            Dictionary<string, string> postData = new Dictionary<string, string>();
            if (isEditing)
            {
                postData.Add("playerID", player.PlayerID.ToString());
            }

            postData.Add("name", player.Name);
            postData.Add("birth", player.Birth.ToString());
            postData.Add("height", player.Height.ToString());
            postData.Add("weight", player.Weight.ToString());
            postData.Add("teamName", player.TeamName);
            postData.Add("salary", player.Salary.ToString());
            postData.Add("post", player.Post.ToString());
            postData.Add("number", player.Number.ToString());
            string json = this.client.PostAsync(myUrl, new FormUrlEncodedContent(postData)).
                Result.Content.ReadAsStringAsync().Result;

            JsonDocument doc = JsonDocument.Parse(json);
            return doc.RootElement.EnumerateObject().First().Value.GetRawText() == "true";
        }

        /// <summary>
        /// Edit one player.
        /// </summary>
        /// <param name="player">Player to edit.</param>
        /// <param name="editor">Editor function.</param>
        public void EditPlayer(PlayerVM player, Func<PlayerVM, bool> editor)
        {
            PlayerVM clone = new PlayerVM();

            if (player != null)
            {
                clone.CopyFrom(player);
            }

            bool? success = editor?.Invoke(clone);

            if (success == true)
            {
                if (player != null)
                {
                    success = this.ApiEditPlayer(clone, true);
                }
                else
                {
                    success = this.ApiEditPlayer(clone, false);
                }
            }

            this.SendMessage(success == true);
        }
    }
}
