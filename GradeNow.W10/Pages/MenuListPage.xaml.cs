//---------------------------------------------------------------------------
//
// <copyright file="MenuListPage.xaml.cs" company="Microsoft">
//    Copyright (C) 2015 by Microsoft Corporation.  All rights reserved.
// </copyright>
//
// <createdOn>8/5/2016 7:05:38 PM</createdOn>
//
//---------------------------------------------------------------------------

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml;
using AppStudio.DataProviders.LocalStorage;
using AppStudio.DataProviders.Menu;
using GradeNow.Sections;
using GradeNow.ViewModels;
using AppStudio.Uwp;

namespace GradeNow.Pages
{
    public sealed partial class MenuListPage : Page
    {
	    public ListViewModel ViewModel { get; set; }
        public MenuListPage()
        {
			ViewModel = ViewModelFactory.NewList(new MenuSection());

            this.InitializeComponent();
			commandBar.DataContext = ViewModel;
			NavigationCacheMode = NavigationCacheMode.Enabled;
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
			ShellPage.Current.ShellControl.SelectItem("2b614c80-4133-427c-8437-28a7b69c2b11");
			ShellPage.Current.ShellControl.SetCommandBar(commandBar);
			if (e.NavigationMode == NavigationMode.New)
            {			
				await this.ViewModel.LoadDataAsync();
                this.ScrollToTop();
			}			
            base.OnNavigatedTo(e);
        }

    }
}
