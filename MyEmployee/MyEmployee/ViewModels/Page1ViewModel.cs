using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Xml.Linq;
using MyEmployee.Helper;
using MyEmployee.Model;
using MyEmployee.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MyEmployee.ViewModels
{
 public class Page1ViewModel : BindableBase
 {
  private readonly INavigationService _navigationService;
  

  public Page1ViewModel(INavigationService navigationService)
  {
   _navigationService = navigationService;
   AddCommand = new Command(AddCommandHandler);
   GetCommand = new Command(GetCommandHandler);
   EditCommand = new Command(EditCommandHandler);
   DeleteCommand = new Command(DeleteCommandHandler);

  }
  public HelperDB HelperDB= new HelperDB();

  
  
 
  public Command AddCommand { get; set; }
  public Command GetCommand { get; set; }
  public Command DeleteCommand { get; set; }
  public Command EditCommand { get; set; }
  

  public async void AddCommandHandler()
  {
   await _navigationService.NavigateAsync(nameof(AddEmployee));
  }
  public  async void GetCommandHandler()
  { 
    
   await _navigationService.NavigateAsync(nameof(GetEmployee));
  }
  public async void DeleteCommandHandler()
  {
   await _navigationService.NavigateAsync(nameof(DeleteEmployee));
  }
  public async void EditCommandHandler()
  {
   await _navigationService.NavigateAsync(nameof(EditEmployee));
  }

 }
}
