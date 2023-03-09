using System.Collections.Generic;
using MyEmployee.Helper;
using MyEmployee.Model;
using Prism.Mvvm;
using Xamarin.Forms;

namespace MyEmployee.ViewModels
{

    public class DeleteEmployeeViewModel : BindableBase
    {
        private string _name;
        private string _email;
        private int _employeeID;
        private List<Employee> _employees;
        public DeleteEmployeeViewModel()
        {
            DeleteEmployeeCommand = new Command(DeleteEmployeeCommandHandler);
            DeleteCommand = new Command<Employee>(DeleteCommandHandler);
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
        public List<Employee>Employees
        {
            get { return _employees; }
            set { SetProperty(ref _employees, value); }
        }
        public Command DeleteEmployeeCommand { get; set; }
        public Command <Employee>DeleteCommand { get; set; }

        public async void DeleteEmployeeCommandHandler()
        {

            var employee = await HelperDB.GetEmployees();
            Employees = employee;



        }
        public async void DeleteCommandHandler(Employee employee)
        { 
            await HelperDB.DeleteEmployees(employee);
        }
         
    }
}
