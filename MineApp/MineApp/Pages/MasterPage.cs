using Xamarin.Forms;
using System.Collections.ObjectModel;
using MobileCRM.Shared.Pages;
using MobileCRM.Shared.ViewModels;
using Xamarin.Forms;
using MobileCRM.Models;

namespace MineApp.Shared.Pages
{
    public class MasterPage<T> : TabbedPage where T: class, new()
    {
        public MapPage<T> Map { get; private set; }
        public ListPage<T> List { get; private set; }

        public MasterPage(OptionItem menuItem)
        {
            var viewModel = new MapViewModel<T>();
            BindingContext = viewModel;

            this.SetValue(Page.TitleProperty, menuItem.Title);
            this.SetValue(Page.IconProperty, menuItem.Icon);

            Map = new MapPage<T>(viewModel);
            List = new ListPage<T>(viewModel) { Icon = "list.png" };

            this.Children.Add(Map);
            this.Children.Add(List);
        }
    }
}
