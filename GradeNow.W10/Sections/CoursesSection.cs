using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using AppStudio.DataProviders;
using AppStudio.DataProviders.Core;
using AppStudio.DataProviders.DynamicStorage;
using AppStudio.Uwp;
using AppStudio.Uwp.Actions;
using AppStudio.Uwp.Commands;
using Windows.ApplicationModel.Appointments;
using System.Linq;
using Windows.Storage;

using GradeNow.Navigation;
using GradeNow.ViewModels;

namespace GradeNow.Sections
{
    public class CoursesSection : Section<Courses1Schema>
    {
		private DynamicStorageDataProvider<Courses1Schema> _dataProvider;		

		public CoursesSection()
		{
			_dataProvider = new DynamicStorageDataProvider<Courses1Schema>();
		}

		public override async Task<IEnumerable<Courses1Schema>> GetDataAsync(SchemaBase connectedItem = null)
        {
            var config = new DynamicStorageDataConfig
            {
                Url = new Uri("http://ds.winappstudio.com/api/data/collection?dataRowListId=f9a4799f-6af1-4328-9ebb-b6a7dfc13b53&appId=34c4b26c-c67c-445e-95e2-812c7558ab0a"),
                AppId = "34c4b26c-c67c-445e-95e2-812c7558ab0a",
                StoreId = ApplicationData.Current.LocalSettings.Values[LocalSettingNames.StoreId] as string,
                DeviceType = ApplicationData.Current.LocalSettings.Values[LocalSettingNames.DeviceType] as string,
            };
            return await _dataProvider.LoadDataAsync(config, MaxRecords);
        }

        public override async Task<IEnumerable<Courses1Schema>> GetNextPageAsync()
        {
            return await _dataProvider.LoadMoreDataAsync();
        }

        public override bool HasMorePages
        {
            get
            {
                return _dataProvider.HasMoreItems;
            }
        }

        public override ListPageConfig<Courses1Schema> ListPage
        {
            get 
            {
                return new ListPageConfig<Courses1Schema>
                {
                    Title = "Courses",

                    Page = typeof(Pages.CoursesListPage),

                    LayoutBindings = (viewModel, item) =>
                    {
                        viewModel.Title = item.Title.ToSafeString();
                        viewModel.SubTitle = item.Category.ToSafeString();
                    },
                    DetailNavigation = (item) =>
                    {
						return NavInfo.FromPage<Pages.CoursesDetailPage>(true);
                    }
                };
            }
        }

        public override DetailPageConfig<Courses1Schema> DetailPage
        {
            get
            {
                var bindings = new List<Action<ItemViewModel, Courses1Schema>>();
                bindings.Add((viewModel, item) =>
                {
                    viewModel.PageTitle = item.Category.ToSafeString();
                    viewModel.Title = item.Title.ToSafeString();
                    viewModel.Description = "";
                    viewModel.ImageUrl = ItemViewModel.LoadSafeUrl("");
                    viewModel.Content = null;
                });

                var actions = new List<ActionConfig<Courses1Schema>>
                {
                };

                return new DetailPageConfig<Courses1Schema>
                {
                    Title = "Courses",
                    LayoutBindings = bindings,
                    Actions = actions
                };
            }
        }
    }
}
