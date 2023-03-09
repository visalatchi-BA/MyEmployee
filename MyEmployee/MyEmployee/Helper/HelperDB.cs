using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using MyEmployee.Model;
using SQLite;

namespace MyEmployee.Helper
{
    public class HelperDB
    {
        private readonly SQLiteAsyncConnection _SQLiteConnection;

        public HelperDB()
        {
            var fileName = "UserDatabase.db3";
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, fileName);
            var connection = new SQLiteAsyncConnection(path);
            _SQLiteConnection = connection;
            _SQLiteConnection.CreateTableAsync<Employee>();
        }

        public async Task AddEmployee(Employee employee)
        {
            var data = _SQLiteConnection.Table<Employee>();
            await _SQLiteConnection.InsertAsync(employee);
        }

        public async Task<List<Employee>> GetEmployees()
        {
            var employeeDetails = await _SQLiteConnection.Table<Employee>().OrderBy(x => x.EmployeeID).ToListAsync();
            return employeeDetails;

        }
        
        public async Task EditEmployees(Employee employee)
        {
            await _SQLiteConnection.UpdateAsync(employee);
        }

      

        public async Task DeleteEmployees(Employee employee)
        {
            await _SQLiteConnection.DeleteAsync(employee);
        }
    }
}
