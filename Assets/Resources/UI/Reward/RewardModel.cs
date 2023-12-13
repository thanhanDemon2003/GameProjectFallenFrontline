
using UnityEngine;
namespace RewardModel
{
    public class Reward
    {
        public bool success;
        public string nofitication;
        public Data data;
        public PlayerModel.Data player;
        Reward(bool success, string nofitication, Data data)
        {
            this.success = success;
            this.nofitication = nofitication;
            this.data = data;
        }
    }
    public class Data
    {
        public string _id;
        public string id_Player;
        public string namePlayer;
        public string playingTime;
        public int gameMode;
        public int dotcoin;
        public string Date;
        Data(string _id, string id_Player, string namePlayer, string playingTime, int gameMode, int dotcoin, string Date)
        {
            this._id = _id;
            this.id_Player = id_Player;
            this.namePlayer = namePlayer;
            this.playingTime = playingTime;
            this.gameMode = gameMode;
            this.dotcoin = dotcoin;
            this.Date = Date;
        }
    }
}