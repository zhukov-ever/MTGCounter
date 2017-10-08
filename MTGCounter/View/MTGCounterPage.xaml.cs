using Xamarin.Forms;
using System.Collections.ObjectModel;
using MTGCounter.View;

namespace MTGCounter
{
    public partial class MTGCounterPage : ContentPage
    {

        public ObservableCollection<PlayerViewModel> players { get; set; }

        public MTGCounterPage()
        {
            InitializeComponent();

            players = new ObservableCollection<PlayerViewModel>();
            players.Add(new PlayerViewModel { Name = "Zopen'" });

			addViewToGrid(new PlayerView(), 0);
			addViewToGrid(new PlayerView(), 1);
			addViewToGrid(new PlayerView(), 2);
			addViewToGrid(new PlayerView(), 3);
			addViewToGrid(new PlayerView(), 4);
			addViewToGrid(new PlayerView(), 5);

            NavigationPage.SetHasNavigationBar(this, false);
        }

        protected override void LayoutChildren(double x, double y, double width, double height)
        {
            base.LayoutChildren(x, y, width, height);


            //listView.RowHeight = (int)(listView.Height / players.Count);
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            for (int i = 0; i < playersGrid.Children.Count; i++)
            {
                addViewToGrid(playersGrid.Children[i], i);
            }
        }

        private void addViewToGrid(Xamarin.Forms.View view, int position)
        {
            if (this.Width > this.Height)
            {
                playersGrid.Children.Add(view, position, 0);
            }
            else
            {
                playersGrid.Children.Add(view, 0, position);
            }
        }

    }

}