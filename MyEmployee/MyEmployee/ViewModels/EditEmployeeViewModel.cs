using System.Collections.Generic;
using MyEmployee.Helper;
using MyEmployee.Model;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace MyEmployee.ViewModels
{
    public class EditEmployeeViewModel : BindableBase
 {
        private readonly INavigationService _navigationService;
        private List<Employee> _employees = new List<Employee>();
        private string _name;
        private string _email;
        private int _employeeID;
        public EditEmployeeViewModel(INavigationService navigationService)
        {
            EditCommand = new DelegateCommand<Employee>(EditCommandHandler);
            ShowAllEmployeeCommand = new Command(ShowAllEmployeeCommandHandler);
            _navigationService = navigationService;
        }
        public HelperDB HelperDB = new HelperDB();

        public ObservableRangeCollection<Employee> Employees { get; } = new ObservableRangeCollection<Employee>();

        //public List<Employee> Employees
        //{
        //    get => _employees;
        //    set => SetProperty(ref _employees, value);
        //}
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                SetProperty(ref _name, value);

            }
        }

        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                SetProperty(ref _email, value);

            }
        }


        public int EmployeeID
        {
            get
            {
                return _employeeID;
            }
            set
            {
                SetProperty(ref _employeeID, value);

            }
        }


        public DelegateCommand<Employee> EditCommand { get; set; }
        public Command ShowAllEmployeeCommand { get; set; }

        public async void ShowAllEmployeeCommandHandler()
        {
           
            var employee = await HelperDB.GetEmployees();
            Employees.ReplaceRange(employee);
        }
        public async void EditCommandHandler(Employee employee)
        {
           
            var Data = new NavigationParameters();
            
            Data.Add("TappedData", employee);
            await _navigationService.NavigateAsync("EditEmployeeList", Data);
        }

    }
    
    
}
