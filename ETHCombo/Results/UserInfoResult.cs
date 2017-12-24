namespace ETHComboBot.Results
{
    using System;

    /// <summary>
    ///     The <see cref="UserInfoResult"/> contains statistics about
    ///     the current user.
    /// </summary>
    public class UserInfoResult : IResult
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="UserInfoResult"/> class.
        /// </summary>
        /// <param name="webResponse">A response with the result of the chest game.</param>
        public UserInfoResult(string webResponse)
        {
            var arr = webResponse.Split(':');

            EthBalance = double.Parse(arr[1]);
            UsdBalance = double.Parse(arr[2]);
            PayoutPercentage = arr[4];
        }

        /// <inheritdoc />
        public string PayoutPercentage { get; set; }

        /// <inheritdoc />
        public double AmountWon
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        /// <inheritdoc />
        public double EthBalance { get; set; }

        /// <inheritdoc />
        public double UsdBalance { get; set; }

        /// <inheritdoc />
        public bool IsWinner
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }
    }
}
