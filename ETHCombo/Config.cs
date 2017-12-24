namespace ETHComboBot
{
    /// <summary>
    ///     The <see cref="Config"/> class holds information used to interact with ETHCombo.
    /// </summary>
    public class Config
    {
        /// <summary>
        ///     Gets or sets the url used to make spins
        /// </summary>
        public string SpinUrl { get; set; }

        /// <summary>
        ///     Gets or sets the url used to play the chest game
        /// </summary>
        public string ChestUrl { get; set; }

        /// <summary>
        ///     Gets or sets the duration that a spin will occur
        /// </summary>
        public int SpinDurationMs { get; set; }
    }
}
