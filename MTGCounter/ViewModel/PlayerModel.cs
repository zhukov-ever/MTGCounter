using System;
namespace MTGCounter
{
    public class PlayerModel
    {
        public PlayerModel() 
        {
            Name = "PLayer";
            HitPoints = 20;
        }

		public string Name { get; set; }
        public int HitPoints { get; set; }
    }

}
