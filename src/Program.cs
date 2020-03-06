﻿using System;
using System.Threading.Tasks;
using tgtgBot.Api;
using tgtgBot.Helpers;
using tgtgBot.Models;

namespace tgtgBot
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("---- tgtgBot ----");
            Console.WriteLine("");

            User tgtgUser = new User()
            {
                email = BotEnvironment.GetConfigVariable("email"),
                password = BotEnvironment.GetConfigVariable("password")
            };

            string tgtgApiAccessToken = await Auth.GetAccessToken(tgtgUser);

            if (!string.IsNullOrEmpty(tgtgApiAccessToken)){
                string latitude = BotEnvironment.GetConfigVariable("latitude");
                string longitude = BotEnvironment.GetConfigVariable("longitude");
                string radius = BotEnvironment.GetConfigVariable("radius");

                string itemsJson = await Auth.GetItems(tgtgUser, latitude, longitude, radius);
                Console.WriteLine(itemsJson);
            }
            else
            {
                Console.WriteLine("Could not get API token");
            }
        }
    }
}
