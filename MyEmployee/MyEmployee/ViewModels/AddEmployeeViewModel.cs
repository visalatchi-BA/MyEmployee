using System;
using System.Collections.Generic;
using System.Linq;
using MyEmployee.Helper;
using MyEmployee.Model;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Xamarin.Forms;

namespace MyEmployee.ViewModels
{
 public class AddEmployeeViewModel : BindableBase
 {
  private readonly INavigationService _navigationService;
  private string _name;
  private string _email;
  private int _employeeID;
  public AddEmployeeViewModel(INavigationService navigationService)
  {
   _navigationService = navigationService;
   SaveCommand = new Command(SaveCommandHandler);
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
  public Command SaveCommand { get; set; }

  public async void SaveCommandHandler()
  {
   var employee = new Employee { Email = Email, EmployeeID = EmployeeID, Name = Name, };
   await HelperDB.AddEmployee(employee);
   await _navigationService.GoBackAsync(); 
  }
 }
}
