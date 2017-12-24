namespace ETHComboBot.Results
{
    using System;

    /// <inheritdoc />
    public class ChestResult : IResult
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ChestResult"/> class.
        /// </summary>
        /// <param name="webResponse">The response with a result of the chest game.</param>
        public ChestResult(string webResponse)
        {
            var arr = webResponse.Split(':');

            AmountWon = double.Parse(arr[0]);
            EthBalance = double.Parse(arr[1]);
            UsdBalance = double.Parse(arr[2]);
            IsWinner = Convert.ToBoolean(int.Parse(arr[3]));
            PayoutPercentage = arr[4];
            WinnerChest = int.Parse(arr[5]);
        }

        /// <summary>
        ///     Gets the winning chest number
        /// </summary>
        public int WinnerChest { get; }

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
