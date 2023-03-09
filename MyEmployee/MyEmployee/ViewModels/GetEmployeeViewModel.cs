using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Xml.Linq;
using MyEmployee.Helper;
using MyEmployee.Model;
using Prism.Commands;
using Prism.Mvvm;
using Xamarin.Forms;

namespace MyEmployee.ViewModels
{
    public class GetEmployeeViewModel : BindableBase
    {

        private List<Employee> _employees = new List<Employee>();

        public GetEmployeeViewModel()
        {
            GetCommand = new Command(GetCommandHandler);
        }
        public HelperDB HelperDB = new HelperDB();
        public List<Employee> Employees
        {
            get => _employees;
            set => SetProperty(ref _employees, value);
        }

        public Command GetCommand { get; set; }

        public async void GetCommandHandler()
        {

            //var employee = await HelperDB.GetEmployees();
            List<Employee> employees = new List<Employee>();
            //Employee employee;
            Employees = await HelperDB.GetEmployees();
            //Employees = employee;


        }
    }
}
