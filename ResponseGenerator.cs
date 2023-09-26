using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace FootballBot
{
    public class ResponseGenerator
    {
        private Dictionary<string, List<string>> botResponses = BotResponse.responses;
        public string GenerateResponse(string userInput, ref string currentContext, UserProfile userProfile)
        {
            if (currentContext != null && userInput.Contains("no"))
                return ClearContext(ref currentContext, "Okay, let's talk about something else. What would you like to know?");

            if (userInput.Contains("favorite"))
            {
                if (userInput.Contains("player"))
                    return HandleFavorite(userInput, "player", "favorite_player", userProfile);
                else if (userInput.Contains("team"))
                    return HandleFavorite(userInput, "team", "favorite_team", userProfile);
            }

            var keywordResponses = botResponses.Keys.Where(key => userInput.Contains(key)).ToList();

            if (!keywordResponses.Any()) return "I'm not sure how to answer that. Ask me about football-related topics or type 'help' for assistance.";

            currentContext = keywordResponses.First();
            var responseList = botResponses[currentContext];
            return responseList[new Random().Next(responseList.Count)];
        }

        private string ClearContext(ref string currentContext, string message)
        {
            currentContext = null;
            return message;
        }

        private string HandleFavorite(string userInput, string item, string profileKey, UserProfile userProfile)
        {
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;

            if (userProfile == null) return null;

            if (profileKey == "favorite_player" && userProfile.FavoritePlayer != null)
            {
                return $"You've already told me your favorite {item}. Is there anything else you'd like to know?";
            }
            else if (profileKey == "favorite_team" && userProfile.FavoriteTeam != null)
            {
                return $"You've already told me your favorite {item}. Is there anything else you'd like to know?";
            }

            var match = Regex.Match(userInput, $"favorite {item} is (\\w+)");
            String matchedItemInTitleCase = textInfo.ToTitleCase(match.Groups[1].Value);

            if (!match.Success)
                return $"I didn't catch the name of your favorite {item}. Please specify the {item}'s name.";

            if (profileKey == "favorite_player")
            {
                userProfile.FavoritePlayer = match.Groups[1].Value;
            }
            else if (profileKey == "favorite_team")
            {
                userProfile.FavoriteTeam = match.Groups[1].Value;
            }

            return $"Great choice! {matchedItemInTitleCase} is an excellent {item}. Is there anything else you'd like to discuss?";
        }
    }
}
