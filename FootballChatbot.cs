using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FootballBot
{
    class Chatbot
    {
        private UserProfile userProfile;
        private string currentContext;
        private ResponseGenerator responseGenerator;

        private Dictionary<string, List<string>> botResponses = BotResponse.responses;
        private String response = null;
        public Chatbot()
        {
            userProfile = new UserProfile();
            responseGenerator = new ResponseGenerator();            
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
                    response = "Bot: You can ask me about: ";
                    
                    foreach (String topic in botResponses.Keys)
                    {
                        response += $"\n> {topic.ToString().ToUpper()}";
                    }
                                        
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
}