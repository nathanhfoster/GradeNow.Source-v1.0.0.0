//---------------------------------------------------------------------------
//
// <copyright file="CoursesListPage.xaml.cs" company="Microsoft">
//    Copyright (C) 2015 by Microsoft Corporation.  All rights reserved.
// </copyright>
//
// <createdOn>8/5/2016 7:05:38 PM</createdOn>
//
//---------------------------------------------------------------------------

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml;
using AppStudio.DataProviders.DynamicStorage;
using GradeNow.Sections;
using GradeNow.ViewModels;
using AppStudio.Uwp;

namespace GradeNow.Pages
{
    public sealed partial class CoursesListPage : Page
    {
	    public ListViewModel ViewModel { get; set; }
        public CoursesListPage()
        {
			ViewModel = ViewModelFactory.NewList(new CoursesSection());

            this.InitializeComponent();
			commandBar.DataContext = ViewModel;
			NavigationCacheMode = NavigationCacheMode.Enabled;
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
			ShellPage.Current.ShellControl.SelectItem("fa176aa3-2435-4a62-b9da-8dd9d0e5eb4d");
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
