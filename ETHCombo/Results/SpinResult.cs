namespace ETHComboBot.Results
{
    using System;

    /// <inheritdoc />
    public class SpinResult : IResult
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="SpinResult"/> class.
        /// </summary>
        /// <param name="webResponse">The response with a result of the spin.</param>
        public SpinResult(string webResponse)
        {
            var arr = webResponse.Split(':');

            Code = arr[0];
            SpinsLeft = int.Parse(arr[1]);
            AmountWon = double.Parse(arr[2]);
            EthBalance = double.Parse(arr[3]);
            UsdBalance = double.Parse(arr[4]);
            IsWinner = Convert.ToBoolean(int.Parse(arr[5]));
            PayoutPercentage = arr[6];
            Minigame = Convert.ToBoolean(int.Parse(arr[7]));
            MinigameWinnings = arr[8];
        }

        /// <summary>
        ///     Gets the spin code
        /// </summary>
        public string Code { get; }

        /// <summary>
        ///     Gets the amount of spins the user has left
        /// </summary>
        public int SpinsLeft { get; }

        /// <summary>
        ///     Gets a value indicating whether the user should play the chest minigame
        /// </summary>
        public bool Minigame { get; }

        /// <summary>
        ///     Gets the minigame winnings from the chest game
        /// </summary>
        public string MinigameWinnings { get; }

        /// <inheritdoc />
        public string PayoutPercentage { get; set; }

        /// <inheritdoc />
        public double AmountWon { get; set; }

        /// <inheritdoc />
        public double EthBalance { get; set; }

        /// <inheritdoc />
        public double UsdBalance { get; set; }

        /// <inheritdoc />
        public bool IsWinner { get; set; }
    }
}
