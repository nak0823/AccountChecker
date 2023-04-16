using AccountChecker.Globals;
using DiscordRPC;

namespace AccountChecker.RPC
{
    internal class Handler
    {
        private static readonly DiscordRpcClient client = new DiscordRpcClient("1234567890ABCDEFG"); // Discord Bot Id goes here.

        public static void Initialize(string state, string description = null)
        {
            client.Initialize();

            var presence = new RichPresence
            {
                State = state,
                Details = description,
                Assets = new Assets
                {
                    LargeImageKey = "imageNameHere",
                    LargeImageText = $"{Tool.Toolname} by {Tool.Author}"
                },
                Buttons = new Button[]
                {
                   new Button
                    {
                        Label = "Header 1",
                        Url = "https://www.website.com/"
                    },
                    new Button
                    {
                        Label = "Header 2",
                        Url = "https://www.website.com/"
                    },
                }
            };

            client.SetPresence(presence);
        }

        public static void UpdatePresence(string newState, string newDetails)
        {
            var newPresence = new RichPresence
            {
                State = newState,
                Details = newDetails,
                Assets = new Assets
                {
                    LargeImageKey = "imageNameHere",
                    LargeImageText = $"{Tool.Toolname} by {Tool.Author}"
                },
                Buttons = new Button[]
                {
                    new Button
                    {
                        Label = "Header 1",
                        Url = "https://www.website.com/"
                    },
                    new Button
                    {
                        Label = "Header 2",
                        Url = "https://www.website.com/"
                    },
                }
            };

            client.SetPresence(newPresence);
        }
    }
}