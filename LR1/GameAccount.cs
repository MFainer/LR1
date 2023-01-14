using System;
using System.Collections.Generic;
using System.Text;


namespace LR1
{
        class Game
        {
            private static int gameIDSEED = 1;
            public int GameID;
            public int Rating;
            public GameAccount P1;
            public GameAccount P2;

            public Game(int rating, GameAccount p1, GameAccount p2)
            {
            if(rating < 0){
                throw new ArgumentOutOfRangeException("rating<0");
            }
                Rating = rating;
                P1 = p1;
                P2 = p2;
                GameID = gameIDSEED++;
            }
        }

        class GameAccount
        {
            public string UserName { get; set; }
            public int CurrentRating
            {
                get
                {
                    int rating = 1;
                    foreach (var item in allGames)
                    {
                        rating = ChangeRating(item, rating);
                    }

                    if (rating < 1)
                    {
                        rating = 1;
                    }
                    return rating;
                }
                
            }
            public int GamesCount
            {
                get
                {
                    int count = 0;
                    foreach (var item in allGames)
                    {
                        count++;
                    }
                    return count;
                }
            }
            public List<Game> allGames = new List<Game>();

            public GameAccount(string userName)
            {
                UserName = userName;
            }

            private int ChangeRating(Game game, int rating)
            {
                if (game.P1 == this)
                {
                    rating += game.Rating;
                }
                else
                {
                    rating -= game.Rating;
                }
                return rating;
            }

            public void WinGame(GameAccount opponent, int rating)
            {
                Game game = new Game(rating, this, opponent);
                allGames.Add(game);
                opponent.allGames.Add(game);
            }

            public void LostGame(GameAccount opponent, int rating)
            {
                Game game = new Game(rating, opponent, this);
                allGames.Add(game);
                opponent.allGames.Add(game);
            }
            public string GetStats()
            {
                var build = new StringBuilder();

                int rating = 0;
                build.AppendLine($"{"GameID",10}{"Opponent",10}{"Rating",10}{"Result",10}");
                foreach (var item in allGames)
                {
                    rating = ChangeRating(item, rating);
                    var opponent = item.P1 == this ? item.P2 : item.P1;
                    string getResult = item.P1 == this ? "Won" : "Lose";
                    build.AppendLine($"{item.GameID,10}{opponent.UserName,10}{item.Rating,10}{getResult,10}");
                }
                return build.ToString();
            }
        }


}
