﻿using Discord.Commands;
using Discord.WebSocket;
using System.Threading.Tasks;

namespace Gideon.Handlers
{
    [RequireContext(ContextType.Guild)]
    public class CoinsCommands : ModuleBase<SocketCommandContext>
    {
        // Pickpocket a user
        [Command("pickpocket")]
        public async Task PickPocketCoins(SocketGuildUser user = null) => await CoinsHandler.PickPocket(Context, user);

        // Start a Coins Lottery
        [Command("coins lottery start")]
        public async Task StartCoinsLottery(int amount, int cost) => await CoinsHandler.StartCoinsLottery(Context, amount, cost);

        // Join the Coins Lottery
        [Command("coins lottery join")]
        public async Task JoinCoinsLottery() => await CoinsHandler.JoinCoinsLottery(Context);

        // Draw the Coins Lottery
        [Command("coins lottery draw")]
        public async Task DrawCoinsLottery() => await CoinsHandler.DrawLottery(Context);

        // Reset Coins Lottery
        [Command("coins lottery reset")]
        public async Task ResetCoinsLottery() => await CoinsHandler.ResetCoinsLottery(Context, true);

        // Spawn Coins for a user
        [Command("coins spawn")]
        public async Task SpawnCoins(SocketGuildUser user, [Remainder]int amount)
        {
            if (!await Utilities.CheckForSuperadmin(Context, Context.User)) return;
            await CoinsHandler.SpawnCoins(Context, user, amount);
        }

        // Remove Coins for a user
        [Command("coins remove")]
        public async Task RemoveCoins(SocketGuildUser user, [Remainder]int amount)
        {
            if (!await Utilities.CheckForSuperadmin(Context, Context.User)) return;
            await CoinsHandler.RemoveCoins(Context, user, amount);
        }

        // See how many Coins another user has
        [Command("coins")]
        public async Task SeeCoins(SocketGuildUser user = null) => await CoinsHandler.DisplayCoins(Context, user ?? (SocketGuildUser)Context.User, Context.Channel);

        // Give Coins to another user (not spawning them)
        [Command("coins give")]
        public async Task GiveCoins(SocketGuildUser user, [Remainder]int amount) => await CoinsHandler.GiveCoins(Context, (SocketGuildUser)Context.User, user, amount);

        // Coins Store
        [Command("coins store")]
        public async Task CoinsStore() => await CoinsHandler.DisplayCoinsStore(Context, (SocketGuildUser)Context.User, Context.Channel);
    }
}