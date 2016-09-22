using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baseball
{
    class Game
    {
        Team _Team1 { get; }
        Team _Team2 { get; }

        int Team1Score { get; set; }
        int Team2Score { get; set; }

        Team AtBat  { get; set; }

        Field Field { get; set; }

        Player Batter { get; set;}
        Player AtFirstBase { get; set; }
        Player AtSecondBase { get; set; }
        Player AtThirdBase { get; set; }

        private int _innings;
        int Innings
        {
            get
            {
                return _innings;
            }

            set
            {
                if (value > 9 || value < 1)
                {
                    throw new ArgumentException();
                }
                _innings = value;
            }
        }

        public Game(Team team1, Team team2)
        {
            _Team1 = team1;
            _Team2 = team2;
            _innings = 1;
            Team1Score = 0;
            Team2Score = 0;
        }
    }

    class Field //This is here in additon to the Player.position because there can be multiple pitchers that get rotated out
    {
        List<Player> Outfielders { get; set; }
        List<Player> Infielders { get; set; }
        Player Pitcher { get; set; }
        Player Catcher { get; set; }
        Player Shortstop { get; set; }
        //etc.. theres a lot of positions in baseball

    }

    class Team
    {
        List<Player> Players { get; set; }
        string Name { get; set; }
    }

    class Player
    {
        string Name { get; set; }
        string Position { get; set; }
        int Number { get; set; }

    }
}

