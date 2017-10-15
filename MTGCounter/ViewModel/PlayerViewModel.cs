using System;
namespace MTGCounter
{
    public class PlayerViewModel
    {
        public PlayerViewModel() 
        {
            Name = "PLayer";
            HitPoints = 20;
        }

		public string Name { get; set; }
        public int HitPoints { get; set; }
    }

}
