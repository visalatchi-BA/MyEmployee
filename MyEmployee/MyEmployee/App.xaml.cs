using MyEmployee.ViewModels;
using MyEmployee.Views;
using Prism;
using Prism.Ioc;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;

namespace MyEmployee
{
 public partial class App
 {
  public App(IPlatformInitializer initializer)
      : base(initializer)
  {
  }

  protected override async void OnInitialized()
  {
   InitializeComponent();

   await NavigationService.NavigateAsync("NavigationPage/Page1");
  }

  protected override void RegisterTypes(IContainerRegistry containerRegistry)
  {
   containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

   containerRegistry.RegisterForNavigation<NavigationPage>();
   containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<Page1, Page1ViewModel>();
   containerRegistry.RegisterForNavigation<AddEmployee, AddEmployeeViewModel>();
   containerRegistry.RegisterForNavigation<GetEmployee, GetEmployeeViewModel>();
   containerRegistry.RegisterForNavigation<DeleteEmployee, DeleteEmployeeViewModel>();
   containerRegistry.RegisterForNavigation<EditEmployee, EditEmployeeViewModel>();
            containerRegistry.RegisterForNavigation<EditEmployeeList, EditEmployeeListViewModel>();
        }
 }
}
