using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TCP.Models;


namespace TCP.Managers
{
    public class FootBallPlayerManager
    {
        private static int _nextID = 1;

        private static List<FootBallPlayer> Players = new List<FootBallPlayer>()
        {
            new FootBallPlayer {ID = _nextID++, Name = "Jack", Price = 1200, ShirtNumber = 5},
            new FootBallPlayer {ID = _nextID++, Name = "Daniel", Price = 2, ShirtNumber = 75}

        };

        public List<FootBallPlayer> GetAllPlayers()
        {
            return new List<FootBallPlayer>(Players);
        }

        public FootBallPlayer GetPlayerByID(int ID)
        {
            return Players.Find(item => item.ID == ID);
        }

        public FootBallPlayer AddPlayer(FootBallPlayer player)
        {
            player.ID = _nextID++;
            Players.Add(player);
            return player;
        }

        public FootBallPlayer DeletePlayer(int ID)
        {
            FootBallPlayer player = Players.Find(item => item.ID == ID);

            Players.Remove(player);
            return player;
        }

        public FootBallPlayer UpdateItem(int ID, FootBallPlayer newPlayer)
        {
            FootBallPlayer player = Players.Find(item => item.ID == ID);

            player.Name = newPlayer.Name;
            player.Price = newPlayer.Price;
            player.ShirtNumber = newPlayer.ShirtNumber;
            return player;
        }
    }
}
