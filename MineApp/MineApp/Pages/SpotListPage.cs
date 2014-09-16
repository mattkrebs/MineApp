using MineApp.Shared.ViewModels;
using System;
using Xamarin.Forms;

namespace MineApp
{
    public class ListPageBase<T> : ContentPage where T : class, new()
    {
        public ListPageBase(BaseViewModel<T> viewModel)
        {
            BindingContext = viewModel;
        }
    }


	public class SpotListPage : ContentPage
	{

        public ListView spotListView { get; set; }
		public SpotListPage ()
		{
            Title = "Spots";
			Label header = new Label
			{
				Text = "Welcome Matt!",
				Font = Font.BoldSystemFontOfSize(30),
				HorizontalOptions = LayoutOptions.Center
			};


            spotListView = new ListView()
            {
				ItemsSource = MineAppServices.Current.NearSpots
			};
            var cell = new DataTemplate(typeof(TextCell));
            cell.SetBinding(TextCell.TextProperty, "Name");
            cell.SetBinding(TextCell.DetailProperty, "Description");


            Content = new StackLayout() 
            { 
                Children ={ header, spotListView}
            };
		}
	}
}

