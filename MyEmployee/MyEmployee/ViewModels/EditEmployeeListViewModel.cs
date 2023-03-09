using MyEmployee.Helper;
using MyEmployee.Model;
using MyEmployee.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Xml.Linq;
using Xamarin.Essentials;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;
using static SQLite.SQLite3;

namespace MyEmployee.ViewModels
{
    public class EditEmployeeListViewModel : ViewModelBase
    {
       // private List<Employee> _content;
        private Employee _seperateDetails;
        private string _name;
        private string _email;
        private int _employeeID;
        private readonly INavigationService _navigationService;
        private readonly IPageDialogService _pageDialogService;
        public EditEmployeeListViewModel(INavigationService navigationService, IPageDialogService pageDialogService) : base(navigationService)
        {
            UpdateCommand = new Command(UpdateCommandHandler);
            _navigationService = navigationService;
            _pageDialogService = pageDialogService;
        }
        public HelperDB HelperDB = new HelperDB();
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
        //public List<Employee> Content
        //{
        //    get
        //    {
        //        return _content;
        //    }
        //    set
        //    {
        //        SetProperty(ref _content, value);
        //    }
        //}
        public Employee SeperateDetails
        {
            get
            {
                return _seperateDetails;
            }
            set
            {
                SetProperty(ref _seperateDetails, value);
            }
        }
        public Command UpdateCommand { get; set; }

        public async void UpdateCommandHandler()
        {
            //await HelperDB.EditEmployees(SeperateDetails);
            // SeperateDetails.Clear();
            //var employee = new Employee { Email = Email, EmployeeID = EmployeeID, Name = Name };
            //SeperateDetails.Add(employee);
            //HelperDB.EditEmployees(employee);
            await HelperDB.EditEmployees(SeperateDetails);
            await _pageDialogService.DisplayAlertAsync("Employee", "Updated Successfully", "Ok");
            await _navigationService.GoBackAsync();

        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            if(parameters.TryGetValue<Employee>("TappedData", out var employee))
            {
                SeperateDetails = employee;
               
            }
        }
    }
}
