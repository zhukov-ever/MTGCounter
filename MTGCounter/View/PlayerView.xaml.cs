using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace MTGCounter.View
{
    public partial class PlayerView : ContentView
    {
        public PlayerViewModel PlayerModel;


        public PlayerView(PlayerViewModel playerModel)
        {
            InitializeComponent();
            PlayerModel = playerModel;
            SetupStartHP();
        }

        void OnDecreaseHP(object sender, System.EventArgs e)
        {
            IncreaseBy1HP();
        }

        void OnIncreaseHP(object sender, System.EventArgs e)
        {
            DecreaseBy1HP();
        }

        private void ShowHP(int hpValue)
        {
            PlayerModel.HitPoints = hpValue;
            hpLabel.Text = PlayerModel.HitPoints.ToString();
        }

        private void SetupStartHP() 
        {
            ShowHP(PlayerModel.HitPoints);
        }

        private void IncreaseBy1HP()
        {
            ShowHP(++PlayerModel.HitPoints);
        }

        private void DecreaseBy1HP()
        {
            ShowHP(--PlayerModel.HitPoints);
        }


    }
}
