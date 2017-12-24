namespace ETHComboBot
{
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Logger;
    using Newtonsoft.Json;

    /// <summary>
    ///     The main program
    /// </summary>
    public class Program
    {
        /// <summary>
        ///     The configuration file name
        /// </summary>
        private const string ConfigFile = "config.json";

        /// <summary>
        ///     A default configuration file with default values
        /// </summary>
        private readonly Config _defaultConfig = new Config()
        {
            ChestUrl =
                "http://ethcombo.com/chestcount.php?id=YOURIDHERE&uhash=YOURHASHHERE&uhash2=YOURHASHHERE&chest=",
            SpinUrl = "http://ethcombo.com/numbers.php?id=YOURIDHERE&uhash=YOURHASHHERE&uhash2=YOURHASHHERE",
            SpinDurationMs = 3000
        };

        /// <summary>
        ///     The main entry point of the program
        /// </summary>
        public static void Main() => new Program().MainAsync().GetAwaiter().GetResult();

        /// <summary>
        ///     The asynchronous entry point of the program
        /// </summary>
        /// <returns>A completed task</returns>
        public async Task MainAsync()
        {
            Config config;

            // Create config if not existing
            try
            {
                config = await ReadConfig();
                if (config == null)
                {
                    Log.Warn("No config was found, a default config was created for you.");
                    Log.Warn("Please edit the config and restart the program.");
                    return;
                }
            }
            catch (JsonReaderException)
            {
                Log.Error($"Failed to read {ConfigFile}.");
                Console.ReadLine();
                return;
            }

            Log.Info("Configuration Loaded");

            var user = new User(config);
            await user.AutoPlay(uint.MaxValue);

            await Task.Delay(-1);
        }

        /// <summary>
        ///     Reads and parses the user configuration
        /// </summary>
        /// <returns>An instance of <see cref="Config"/>; otherwise null</returns>
        public async Task<Config> ReadConfig()
        {
            if (!File.Exists(ConfigFile))
            {
                var obj = JsonConvert.SerializeObject(_defaultConfig, Formatting.Indented);

                File.WriteAllText(ConfigFile, obj);
                return null;
            }

            Log.Info("Reading config...");
            return await Task.Run(() => JsonConvert.DeserializeObject<Config>(File.ReadAllText(ConfigFile)));
        }
    }
}
