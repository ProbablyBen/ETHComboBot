namespace ETHComboBot
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Logger;
    using Results;

    /// <summary>
    ///     The <see cref="User"/> class contains various methods
    ///     to interact with ETHCombo.
    /// </summary>
    public class User
    {
        /// <summary>
        ///     The default multiplier used to determine
        ///     how much time should be waited until another spin
        /// </summary>
        private const int DefaultMultiplier = 2;

        /// <summary>
        ///     The total amount of chests in the chest minigame
        /// </summary>
        private const int TotalChests = 3;

        /// <summary>
        ///     The <see cref="HttpClient"/> used to send and receive web requests
        ///     to the ETHCombo servers
        /// </summary>
        private readonly HttpClient _client = new HttpClient();

        /// <summary>
        ///     The configuration created by the user
        /// </summary>
        private readonly Config _config;

        /// <summary>
        ///     The total amount of spins done
        /// </summary>
        private double _totalSpins;

        /// <summary>
        ///     The total amount of times won
        /// </summary>
        private double _timesWon;

        /// <summary>
        ///     The total amount of Ethereum won
        /// </summary>
        private double _amountWon;

        /// <summary>
        ///     The multiplier used to determine
        ///     how much time should be waited until another spin
        /// </summary>
        private int _multiplier = DefaultMultiplier;

        /// <summary>
        ///     Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        /// <param name="config">The user configuration</param>
        public User(Config config)
        {
            _config = config;
        }

        /// <summary>
        ///     Automatically spins and opens chests
        /// </summary>
        /// <param name="totalTimes">The amount of times to automatically spin</param>
        /// <returns>A completed Task</returns>
        public async Task AutoPlay(uint totalTimes)
        {
            for (uint i = 0; i < totalTimes; i++)
            {
                var spin = await Spin();

                if (spin.SpinsLeft == 0)
                {
                    Console.WriteLine();
                    int ms = _config.SpinDurationMs * _multiplier;
                    _multiplier *= 2;

                    Log.Warn($"You have zero spins left. Waiting {ms / 1000} seconds to get more spins");
                    Console.WriteLine();
                    await Task.Delay(ms);
                }
                else
                {
                    _multiplier = DefaultMultiplier;
                }

                _totalSpins++;

                Console.Title =
                    $"ETHComboBot - Spun {_totalSpins} times. Win Percentage: {Math.Round(_timesWon / _totalSpins, 2) * 100}% // Earned this session: {_amountWon} ETH";

                await Task.Delay(_config.SpinDurationMs);
            }
        }

        /// <summary>
        ///     Performs a spin and logs the spin result
        /// </summary>
        /// <returns>The spin result</returns>
        public async Task<SpinResult> Spin()
        {
            Console.WriteLine();
            Log.Info("Spinning");

            var response = await _client.GetStringAsync(_config.SpinUrl);
            var spin = new SpinResult(response);

            if (spin.Code != "aaa")
            {
                Console.WriteLine($"\tSpin Code: {spin.Code}");
                Console.WriteLine($"\tSpins Left: {spin.SpinsLeft}");
                Console.WriteLine($"\tAmount Won: {spin.AmountWon}");
                Console.WriteLine($"\tETH Balance: {spin.EthBalance}");
                Console.WriteLine($"\tUSD Balance: {spin.UsdBalance:C2}");
                Console.WriteLine($"\tWinner? {spin.IsWinner}");
                Console.WriteLine($"\tPayout Percentage: {spin.PayoutPercentage}");
                Console.WriteLine($"\tPlay Minigame? {spin.Minigame}");
                _amountWon += spin.AmountWon;
            }
            else
            {
                Log.Info("Lost");
                Log.Info($"Spins Left: {spin.SpinsLeft}");
                Log.Info($"ETH Balance: {spin.EthBalance}");
                Log.Info($"USD Balance: {spin.UsdBalance:C2}");
            }

            if (spin.IsWinner)
            {
                _timesWon++;
            }

            if (spin.Minigame)
            {
                await ChestGame();
            }

            Console.WriteLine();

            Console.WriteLine("--------------------------------");

            return spin;
        }

        /// <summary>
        ///     Plays the chest game
        /// </summary>
        /// <returns>A completed Task</returns>
        public async Task ChestGame()
        {
            Log.Info("Playing the chest game");

            // Select a random chest
            int choice = new Random().Next(TotalChests) + 1;
            Log.Info($"Selecting chest {choice}");

            string url = _config.ChestUrl + choice;
            var resp = await _client.GetStringAsync(url);
            var chest = new ChestResult(resp);

            Log.Info($"Winning chest was chest {chest.WinnerChest}");
            string result = chest.WinnerChest == choice ? "Won" : "Lost";
            Log.Info($"Result: {result}");
        }

        /// <summary>
        ///     Gets the user's information
        /// </summary>
        /// <returns>The user's information</returns>
        public async Task<UserInfoResult> GetUserInfo()
        {
            string url = _config.ChestUrl + 1;
            var resp = await _client.GetStringAsync(url);
            return new UserInfoResult(resp);
        }
    }
}
