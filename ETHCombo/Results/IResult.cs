namespace ETHComboBot.Results
{
    /// <summary>
    ///     The <see cref="IResult"/> interface holds information about
    ///     a game result on ETHCombo
    /// </summary>
    public interface IResult
    {
        /// <summary>
        ///     Gets or sets the current percentage until a user can cash out
        /// </summary>
        string PayoutPercentage { get; set; }

        /// <summary>
        ///     Gets or sets the total amount of Ethereum won
        /// </summary>
        double AmountWon { get; set; }

        /// <summary>
        ///     Gets or sets the current user's Ethereum balance
        /// </summary>
        double EthBalance { get; set; }

        /// <summary>
        ///     Gets or sets the current user's Ethereum balance in USD
        /// </summary>
        double UsdBalance { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether the user won
        /// </summary>
        bool IsWinner { get; set; }
    }
}
