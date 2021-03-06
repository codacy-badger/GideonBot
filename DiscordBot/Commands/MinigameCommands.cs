﻿using Discord.Commands;
using Discord.WebSocket;
using System.Threading.Tasks;

namespace Gideon.Handlers
{
    [RequireContext(ContextType.Guild)]
    public class MinigameCommands : ModuleBase<SocketCommandContext>
    {
        // Display a list of MiniGames
        [Command("games")]
        public async Task DisplayGames() => await MinigameHandler.DisplayGames(Context);

        // Reset a game
        [Command("reset")]
        public async Task ResetAGame([Remainder]string game = "") => await MinigameHandler.ResetGame(Context, game);

        // Start a "Who Said It?" game
        [Command("wsi")]
        public async Task PlayWSI() => await MinigameHandler.WSI.TryToStartGame(Context);

        // Start Rock, Paper, Scissors
        [Command("rps")]
        public async Task StartRPS() => await MinigameHandler.RPS.StartRPS(Context);

        // Trivia menu & modes
        [Command("trivia")]
        public async Task TryToStartTrivia(string input = null) => await MinigameHandler.Trivia.TryToStartTrivia((SocketGuildUser)Context.User, Context, input ?? "trivia");

        #region Tic-Tac-Toe Commands
        // Tic-Tac-Toe Menu/Start Game
        [Command("ttt")]
        public async Task TTTMenu() => await MinigameHandler.TTT.StartGame(Context);

        // Join Tic-Tac-Toe
        [Command("ttt join")]
        public async Task JoinTTT() => await MinigameHandler.TTT.JoinGame(Context);
        #endregion

        #region Russian Roulette Commands
        // RR menu or try to start a game of RR
        [Command("rr")]
        public async Task RRTryToStart(string input = null) => await MinigameHandler.RR.TryToStartGame(Context, input ?? "");

        // Join RR
        [Command("join rr")]
        public async Task RRJoin() => await MinigameHandler.RR.TryToJoin(Context);

        // Pull the trigger in RR
        [Command("pt")]
        public async Task RRPullTrigger() => await MinigameHandler.RR.PullTrigger(Context);
        #endregion

        #region Number Guess Game Commands
        // Play NG (Solo)
        [Command("play ng")]
        public async Task PlayNG() => await PlayNG(0);

        // Play NG (2+ players)
        [Command("play ng")]
        public async Task PlayNG(int input) => await MinigameHandler.NG.TryToStartGame(Utilities.GetRandomNumber(1, 100), (SocketGuildUser)Context.User, Context, input);

        // Join NG
        [Command("join ng")]
        public async Task JoinNG() => await MinigameHandler.NG.JoinGame((SocketGuildUser)Context.User, Context);

        // Guess the number in NG
        [Command("g")]
        public async Task GuessNG(int input) => await MinigameHandler.NG.TryToGuess((SocketGuildUser)Context.User, Context, input);
        #endregion

        #region 8-Ball Commands
        // Display 8-Ball instructions
        [Command("8ball")]
        public async Task Play8Ball() => await Minigames._8ball.Greet8Ball(Context);

        // Print 8-ball menu or play 8-Ball
        [Command("8ball")]
        public async Task Play8Ball([Remainder]string question) => await Minigames._8ball.Play8Ball(Context);
        #endregion

    }
}