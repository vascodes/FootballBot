using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballBot
{
    public static class BotResponse
    {
        public static Dictionary<string, List<string>> responses = new Dictionary<string, List<string>>
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
                    "To score the ball must go into your opponent’s goal. The whole ball needs to be over the line for it to be a legitimate goal. ",
                    "A goal can be scored with any part of the body apart from the hand or arm up to the shoulder. The goal itself consists of a frame measuring 8 feet high and 8 yards wide.",
                    "A match consists of two 45 minutes halves with a 15 minute rest period in between.",
                    "The ball must have a circumference of 58-61cm and be of a circular shape."

                }
            },
            { "leagues", new List<string>
                {
                    "Major football leagues include the Premier League, La Liga, Serie A, Bundesliga etc.",
                    "English Premier Leagues is the top-level division in England. Founded in 1992 (previously English Football League).",
                    "Spanish La Liga is the football league in Spain. Founded in 1929."
                }
            },
            { "world cup", new List<string>
                {
                    "The FIFA World Cup is a prestigious international tournament held every four years. Argentina is the current champion.",
                    "The first World Cup took place back in 1930. The tournament consisted of thirteen invited teams and took place in Uruguay, who also won the tournament.",
                    "Brazil has won the World Cup five times. Italy and Germany are close behind with four each.",
                    "The most prestigious tournament in the world! \r\nTaking place quadrennially, the FIFA Men's World Cup sees nations compete against each other for the prize."

                }
            },
            { "stadiums", new List<string>
                {
                    "Iconic stadiums include Camp Nou, Santiago Bernabeu, Old Trafford, and Allianz Arena.",
                    "One of the FIFA World Cup 2022 Football Stadiums in Qatar (‘Stadium 974’) will be the first ever temporary football stadium ever used in a World Cup and has been constructed with the use of shipping containers.",
                    "Camp Nou football stadium has the highest capacity in Europe with 99,354 seats. Before standing places were removed, the stadium’s capacity reached over 122,000 fans."
                }
            },
            { "history", new List<string>
                {
                    "Football has a rich history dating back centuries. It was officially codified in England in the 19th century.",
                    "Modern football originated in Britain in the 19th century."
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
            { "var", new List<string>
                {
                    "VAR (Video Assistant Referee) is used to review key decisions during matches.",
                    "VAR has helped ensure fair play but can also be a topic of debate.",
                    "It's now a crucial part of modern football officiating."
                }
            },
        };                
    }
}
