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
    class Chatbot
    {
        private UserProfile userProfile;
        private string currentContext;
        private ResponseGenerator responseGenerator;

        private String response = null;
        public Chatbot()
        {
            userProfile = new UserProfile();
            responseGenerator = new ResponseGenerator();

            response = "Welcome to the Football Chatbot!\r\nBot: Ask me anything about football, type 'help' for assistance, or 'exit' to quit.\r\n";
        }

        public string GetResponse(String userInput = null)
        {
            if (userInput == null)
            {
                response = "Welcome to the Football Chatbot!\r\nAsk me anything about football, type 'help' for assistance, or 'exit' to quit.\r\n";
            }
            else
            {
                userInput = userInput.Trim().ToLower();
                if (userInput == "exit")
                {
                    response = "Bot: Goodbye!";
                }
                else if (userInput == "help")
                {
                    response = "Bot: You can ask about football teams, players, rules, leagues, the World Cup, stadiums, or history.";
                    response += "\nYou can also tell me your favorite player by saying 'My favorite player is [player name]' or your favorite team by saying 'My favorite team is [team name]'.";
                    response += "\nType 'exit' to quit.";
                }
                else
                {
                    string botResponse = responseGenerator.GenerateResponse(userInput, ref currentContext, userProfile);
                    response = $"Bot: {botResponse}";
                }
            }

            return response;
        }
    }

    class UserProfile
    {
        public string FavoritePlayer { get; set; }
        public string FavoriteTeam { get; set; }
    }

    class ResponseGenerator
    {
        private Dictionary<string, List<string>> responses = new Dictionary<string, List<string>>
    {
        { "teams", new List<string>
            {
                "Barcelona, Real Madrid, Manchester United, and Bayern Munich are some popular football teams.",
                "There are many football teams to explore. Which is your favourite football team?"
            }
        },
        { "players", new List<string>
            {
                "Messi, Ronaldo and Neymar are some famous football players right now.",
                "Who's your favorite football player?"
            }
        },
        { "rules", new List<string>
            {
                "Football is played with two teams, each consisting of 11 players. The goal is to score by getting the ball into the opposing team's net.",
                "Do you want to know more about specific rules?"
            }
        },
        { "leagues", new List<string>
            {
                "Major football leagues include the Premier League, La Liga, Serie A, Bundesliga, and MLS.",
                "Which league would you like to know more about?"
            }
        },
        { "world cup", new List<string>
            {
                "The FIFA World Cup is a prestigious international tournament held every four years. Argentina is the current champion.",
                "Do you want to know about past World Cup winners or future tournaments?"
            }
        },
        { "stadiums", new List<string>
            {
                "Iconic stadiums include Camp Nou, Santiago Bernabeu, Old Trafford, and Allianz Arena.",
                "Have you ever visited a famous football stadium?"
            }
        },
        { "history", new List<string>
            {
                "Football has a rich history dating back centuries. It was officially codified in England in the 19th century.",
                "Is there a specific historical aspect of football you'd like to explore?"
            }
        },
        { "joke", new List<string>
            {
                "Why did the football player bring string to the game? Because he wanted to tie the score!",
                "Did you hear about the football team that drinks tea before a match? They've got great 'penal-tea'!"
            }
        },
        { "goals", new List<string>
            {
                "Scoring goals is the ultimate aim in football, and each goal is a moment of celebration.",
                "Some legendary goal-scorers in history include Gerd Müller, Thierry Henry, and Ferenc Puskás.",
                "The most goals scored in a single calendar year is a record held by Lionel Messi."
            }
        },
        { "defenders", new List<string>
            {
                "Defenders are crucial to a team's success by preventing the opposition from scoring.",
                "Sergio Ramos is known for his defensive skills and scoring important goals for his team.",
                "Great defenders often have excellent positioning and tackling abilities."
            }
        },
        { "midfielders", new List<string>
            {
                "Midfielders control the flow of the game, linking defense to attack.",
                "Andrés Iniesta, Xavi Hernandez, and Zinedine Zidane are midfield maestros known for their passing ability.",
                "A skilled midfielder can change the course of a match with a single pass."
            }
        },
        { "forwards", new List<string>
            {
                "Forwards are responsible for scoring goals and are often the star players of a team.",
                "Thierry Henry, Cristiano Ronaldo, and Robert Lewandowski are prolific goal-scoring forwards.",
                "Their agility, speed, and finishing ability make them lethal in front of the net."
            }
        },
        { "red cards", new List<string>
            {
                "A red card is given to a player for a serious foul or misconduct, resulting in expulsion from the match.",
                "Two yellow cards in a single match also result in a red card (a 'sending off').",
                "Teams playing with fewer players due to red cards often face a tough challenge."
            }
        },
        { "offside", new List<string>
            {
                "The offside rule prevents 'goal-hanging' by attackers who position ahead of the last defender when the ball is passed to them.",
                "A player is offside if they are nearer to the opponent's goal than both the ball and the second-to-last defender when the ball is played to them.",
                "Understanding and timing runs to avoid offside situations is crucial for attackers."
            }
        },
        { "penalties", new List<string>
            {
                "Penalty kicks are awarded for fouls committed in the penalty area, providing a clear goal-scoring opportunity.",
                "The penalty spot is 12 yards (11 meters) from the goal, and only the goalkeeper can defend the shot.",
                "Taking a penalty requires composure and accuracy, as it's a one-on-one situation with the goalkeeper."
            }
        },
            { "matches", new List<string>
        {
            "Football matches can be thrilling and intense with plenty of goals or tactical battles with few goals.",
            "Derby matches, where local rivals face off, often have passionate atmospheres.",
            "International matches like the FIFA World Cup final capture the attention of millions."
        }
        },
        { "coaches", new List<string>
            {
                "Football coaches play a crucial role in developing team strategies and tactics.",
                "Pep Guardiola is known for his innovative tactics, while Jurgen Klopp's teams are famous for high-intensity pressing.",
                "Legendary coaches like Sir Alex Ferguson have had long and successful careers."
            }
        },
        { "transfers", new List<string>
            {
                "Transfer windows are periods when clubs can buy and sell players.",
                "Record-breaking transfers, like Neymar's move to Paris Saint-Germain, make headlines.",
                "Transfers often involve negotiation and can impact a team's performance."
            }
        },
        { "rivalries", new List<string>
            {
                "Football has intense rivalries, such as El Clásico between Barcelona and Real Madrid.",
                "The North West Derby between Liverpool and Manchester United is one of the most historic rivalries in England.",
                "These matches are highly anticipated and can define a team's season."
            }
        },
        { "tournaments", new List<string>
            {
                "Apart from the World Cup and Champions League, other tournaments like the Copa America and Europa League are significant.",
                "The African Cup of Nations showcases talent from the African continent.",
                "Tournaments provide opportunities for players to represent their countries or compete at the club level."
            }
        },
        { "fans", new List<string>
            {
                "Football fans are known for their dedication and loyalty to their teams.",
                "Ultras are passionate fan groups that create electric atmospheres in stadiums.",
                "Famous fan chants and songs add to the excitement of matches."
            }
        },
        { "VAR", new List<string>
            {
                "VAR (Video Assistant Referee) is used to review key decisions during matches.",
                "VAR has helped ensure fair play but can also be a topic of debate.",
                "It's now a crucial part of modern football officiating."
            }
        },
    };

        public string GenerateResponse(string userInput, ref string currentContext, UserProfile userProfile)
        {
            if (currentContext != null && userInput.Contains("no"))
                return ClearContext(ref currentContext, "Okay, let's talk about something else. What would you like to know?");

            if (currentContext != null)
                return AskMoreAbout(currentContext);

            if (userInput.Contains("favorite"))
            {
                if (userInput.Contains("player"))
                    return HandleFavorite(userInput, "player", "favorite_player", userProfile);
                else if (userInput.Contains("team"))
                    return HandleFavorite(userInput, "team", "favorite_team", userProfile);
            }

            var keywordResponses = responses.Keys.Where(key => userInput.Contains(key)).ToList();

            if (!keywordResponses.Any()) return "I'm not sure how to answer that. Ask me about football-related topics or type 'help' for assistance.";

            currentContext = keywordResponses.First();
            var responseList = responses[currentContext];
            return responseList[new Random().Next(responseList.Count)];
        }

        private string ClearContext(ref string currentContext, string message)
        {
            currentContext = null;
            return message;
        }

        private string AskMoreAbout(string context)
        {
            return $"Tell me more about {context}.";
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