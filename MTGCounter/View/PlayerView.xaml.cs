using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Reactive.Subjects;
using System.Diagnostics;

namespace MTGCounter.View
{
    public partial class PlayerView : ContentView
    {
        private ISubject<PlayerModel> PlayerChange;
        public PlayerModel PlayerModel;

        PlayerView()
        {
            InitializeComponent();
        }

        ~PlayerView()
        {
            PlayerChange.OnCompleted();
        }

        public PlayerView(PlayerModel playerModel)
        {
            InitializeComponent();

            PlayerChange = new Subject<PlayerModel>();
            PlayerChange.Subscribe(PlayerChanged);

            PlayerModel = playerModel;
            PlayerChange.OnNext(PlayerModel);
        }

        void PlayerChanged(PlayerModel player) 
        {
            hpLabel.Text = player.HitPoints.ToString();   
        }

        void OnDecreaseHP(object sender, System.EventArgs e)
        {
            IncreaseBy1HP();
        }

        void OnIncreaseHP(object sender, System.EventArgs e)
        {
            DecreaseBy1HP();
        }

        private void IncreaseBy1HP()
        {
            ++PlayerModel.HitPoints;
            PlayerChange.OnNext(PlayerModel);
        }

        private void DecreaseBy1HP()
        {
            --PlayerModel.HitPoints;
            PlayerChange.OnNext(PlayerModel);
        }


    }
}
