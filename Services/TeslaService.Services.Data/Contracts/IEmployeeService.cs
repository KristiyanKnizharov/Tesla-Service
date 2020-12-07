﻿namespace TeslaService.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using TeslaService.Web.ViewModels.Employee;

    public interface IEmployeeService
    {
        Task HiredEmployeeAsync(EmployeeModel newEmployee);

        Task FiredEmployeeAsync(int employeeId);

        bool IsTheEmpoyeeExist(string fullName);

        IEnumerable<EmployeeModel> GetAllEmployee();

        int CountEmployee();
    }
}
