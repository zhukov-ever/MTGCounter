using Xamarin.Forms;
using System.Collections.ObjectModel;
using MTGCounter.View;
using System;
using System.Diagnostics;

namespace MTGCounter
{
    public partial class MTGCounterPage : ContentPage
    {

        ObservableCollection<PlayerModel> Players { get; set; }

        public MTGCounterPage()
        {
            InitializeComponent();

            Players = new ObservableCollection<PlayerModel>
            {
                new PlayerModel()
            };



            AddViewToGrid(new PlayerView(new PlayerModel()), playersGrid.Children.Count);
            AddViewToGrid(new PlayerView(new PlayerModel()), playersGrid.Children.Count);

            NavigationPage.SetHasNavigationBar(this, true);

            SetupForPreparingGame();
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            for (int i = 0; i < playersGrid.Children.Count; i++)
            {
                AddViewToGrid(playersGrid.Children[i], i);
            }
        }

        protected void AddViewToGrid(Xamarin.Forms.View view, int position)
        {
            int lineItemCount = 0;
            if (this.Width > this.Height)
            {
                switch (playersGrid.Children.Count)
                {
                    case 1:
                    case 2:
                    case 3:
                        lineItemCount = 3;
                        break;
                    case 4:
                        lineItemCount = 2;
                        break;
                    case 5:
                    case 6:
                        lineItemCount = 3;
                        break;
                    case 7:
                    case 8:
                    default:
                        lineItemCount = 4;
                        break;

                }
            }
            else
            {
                switch (playersGrid.Children.Count)
                {
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                        lineItemCount = 1;
                        break;
                    case 6:
                    case 7:
                    case 8:
                    default:
                        lineItemCount = 2;
                        break;

                }
            }

            playersGrid.Children.Add(view, position - (position / lineItemCount) * lineItemCount, position / lineItemCount);
        }

        void OnAddHandler()
        {
            if (playersGrid.Children.Count < 8)
            {
                AddViewToGrid(new PlayerView(new PlayerModel()), playersGrid.Children.Count);   
            } else {
                DisplayAlert("WOW", "Too much player. cant", "Okay");
            }
        }

        void OnRmHandler()
        {
            if (playersGrid.Children.Count > 0)
            {
                playersGrid.Children.RemoveAt(playersGrid.Children.Count - 1);
            }
            else
            {
                DisplayAlert("Err", "No players - no deletions", "Okay");
            }
        }

        void OnFightHandler()
        {
            SetupForActiveGame();
        }

        async void OnFinishHandler()
        {
            var action = await DisplayAlert("Warn!", "Rly finish fight???", "Yes", "NOOOO!!!");
            if (action) {
                SetupForPreparingGame();    
            }
        }

        void OnRollDiceHandler()
        {
            DisplayAlert((new Random().Next() % 6 + 1).ToString(), null, "Done");
        }


        private void SetupForPreparingGame() 
        {
            this.ToolbarItems.Clear();
            this.ToolbarItems.Add(new ToolbarItem("[ add ]", null, OnAddHandler, ToolbarItemOrder.Primary, 0));
            this.ToolbarItems.Add(new ToolbarItem("[ rm ]", null, OnRmHandler, ToolbarItemOrder.Primary, 1));
            this.ToolbarItems.Add(new ToolbarItem("[ FIGHT! ]", null, OnFightHandler, ToolbarItemOrder.Primary, 2));
        }

        private void SetupForActiveGame() 
        {
            this.ToolbarItems.Clear();
            this.ToolbarItems.Add(new ToolbarItem("[ Roll 6-dice ]", null, OnRollDiceHandler, ToolbarItemOrder.Primary, 0));
            this.ToolbarItems.Add(new ToolbarItem("[ Finish ]", null, OnFinishHandler, ToolbarItemOrder.Primary, 1));
        }


    }

}