﻿using MineApp.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MineApp.Shared.Pages
{
    public class RootPage : MasterDetailPage
	{

        OptionItem previousItem;
		public RootPage ()
        {
            
            var optionsPage = new MenuPage { Icon = "settings.png", Title = "menu" };
            
            optionsPage.Menu.ItemSelected += (sender, e) => NavigateTo(e.SelectedItem as OptionItem);

            Master = optionsPage;

            NavigateTo(optionsPage.Menu.ItemsSource.Cast<OptionItem>().First());

            //ShowLoginDialog();    
        }

        async void ShowLoginDialog()
        {
            var page = new LoginPage();

            await Navigation.PushModalAsync(page);
        }

        void NavigateTo(OptionItem option)
        {
            if (previousItem != null)
                previousItem.Selected = false;

            option.Selected = true;
            previousItem = option;

            var displayPage = PageForOption(option);
                     
            Detail = new NavigationPage(displayPage)
            {
              Tint = Helpers.Color.Blue.ToFormsColor(),
            };


            IsPresented = false;
        }

        Page PageForOption (OptionItem option)
        {
            if (option.Title == "Contacts")
                return new MasterPage<Contact>(option);
            if (option.Title == "Leads")
                return new MasterPage<Lead>(option);
            if (option.Title == "Accounts") {
                var page = new MasterPage<Account>(option);
                var cell = page.List.Cell;
                cell.SetBinding(TextCell.TextProperty, "Company");
                return page;
            }
            if (option.Title == "Opportunities") {
                var page = new MasterPage<Opportunity>(option);
                var cell = page.List.Cell;
                cell.SetBinding(TextCell.DetailProperty, "EstimatedAmount");
                return page;
            }
            throw new NotImplementedException("Unknown menu option: " + option.Title);
        }
	}
}

