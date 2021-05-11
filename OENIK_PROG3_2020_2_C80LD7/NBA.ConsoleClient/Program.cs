// <copyright file="Program.cs" company="C80LD7">
// Copyright (c) C80LD7. All rights reserved.
// </copyright>

namespace NBA.ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Text.Json;

    /// <summary>
    /// Program class.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main method.
        /// </summary>
        internal static void Main()
        {
            string url = "https://localhost:44354/PlayersApi/";
            Console.WriteLine("WAITING...");
            Console.ReadLine();

            JsonSerializerOptions jsonOptions = new JsonSerializerOptions(JsonSerializerDefaults.Web);

            using (HttpClient client = new HttpClient())
            {
                string json = client.GetStringAsync(url + "all").Result;
                var list = JsonSerializer.Deserialize<List<Player>>(json, jsonOptions);
                foreach (var item in list)
                {
                    Console.WriteLine(item);
                }

                Console.ReadLine();

                Dictionary<string, string> postData;
                string response;

                postData = new Dictionary<string, string>();
                postData.Add(nameof(Player.Name), "Csoor Peter");
                postData.Add(nameof(Player.Birth), new DateTime(2000, 09, 01).ToString());
                postData.Add(nameof(Player.Height), "192");
                postData.Add(nameof(Player.Weight), "85");
                postData.Add(nameof(Player.TeamName), "Houston Rockets");
                postData.Add(nameof(Player.Salary), "2387916");
                postData.Add(nameof(Player.Post), PositionType.PointGuard.ToString());
                postData.Add(nameof(Player.Number), "5");

                response = client.PostAsync(url + "add", new FormUrlEncodedContent(postData)).Result.Content.ReadAsStringAsync().Result;
                json = client.GetStringAsync(url + "all").Result;
                Console.WriteLine("ADD: " + response);
                Console.WriteLine("ALL: " + json);
                Console.ReadLine();

                int playerId = JsonSerializer.Deserialize<List<Player>>(json, jsonOptions).First(x => x.Name == "Csoor Peter").PlayerID;
                postData = new Dictionary<string, string>();
                postData.Add(nameof(Player.PlayerID), playerId.ToString());
                postData.Add(nameof(Player.Name), "Csoor Peter MVP");
                postData.Add(nameof(Player.Birth), new DateTime(2000, 09, 01).ToString());
                postData.Add(nameof(Player.Height), "188");
                postData.Add(nameof(Player.Weight), "85");
                postData.Add(nameof(Player.TeamName), "Portland Trail Blazers");
                postData.Add(nameof(Player.Salary), "9999999");
                postData.Add(nameof(Player.Post), PositionType.PointGuard.ToString());
                postData.Add(nameof(Player.Number), "1");

                response = client.PostAsync(url + "mod", new FormUrlEncodedContent(postData)).Result.Content.ReadAsStringAsync().Result;
                json = client.GetStringAsync(url + "all").Result;
                Console.WriteLine("MOD: " + response);
                Console.WriteLine("ALL: " + json);
                Console.ReadLine();

                Console.WriteLine("DEL: " + client.GetStringAsync(url + "del/" + playerId).Result);
                json = client.GetStringAsync(url + "all").Result;
                Console.WriteLine("ALL: " + json);
                Console.ReadLine();
            }
        }
    }
}
