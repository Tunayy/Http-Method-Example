using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Paycore_patika_hw2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {


        public class Employee
        {

            public int Id { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
            public string PhoneNumber { get; set; }
            public string DateofBirth { get; set; }
            public string Email { get; set; }
            public int Salary { get; set; }

            internal static object Where(Func<object, bool> value)
            {
                throw new NotImplementedException();
            }
        }

        private static List<Employee> EmployeeList = new List<Employee>()
       {
           new Employee
           {
               Id = 1,
               Name = "Yagmur",
               Surname = "Senturk",
               DateofBirth = "06.04.2005",
               Email = "yagmursenturk@gmail.com",
               PhoneNumber = "5435029414",
               Salary = 9000,
           },
           new Employee
           {
               Id = 2,
               Name = "Tunay",
               Surname = "Turer",
               DateofBirth = "21.06.1999",
               Email = "tunayturer@gmail.com",
               PhoneNumber = "5435029414",
               Salary = 8999,
           },
          


       };



       [HttpGet]
       public List<Employee> GetEmployees()
        {
            var employeeList = EmployeeList.OrderBy(x => x.Id).ToList<Employee>();
            return employeeList;
        }


        [HttpGet("GetById {id}")]
        public Employee GetEmployeesById(int id)
        {
            var employee = EmployeeList.Where(employee => employee.Id == id).SingleOrDefault();
            return employee;
        }

        [HttpPost("PostMethod")] 
        public IActionResult AddEmployee([FromBody] Employee New_Employee)
        {

            var employee = EmployeeList.SingleOrDefault(x => x.Name == New_Employee.Name);

            if (employee is not null)
                return BadRequest();

            EmployeeList.Add(New_Employee);
            return Ok();


        }

        [HttpDelete("DeleteForId {id}")]  
        public IActionResult DeleteEmployee(int id)
        {

            var employee = EmployeeList.SingleOrDefault(x => x.Id == id);
            if (employee is null)
                return BadRequest();

            EmployeeList.Remove(employee);
            return Ok();

        }

        [HttpPut("PutMethod {id}")] 
        public IActionResult UpdateEmployee(int id, [FromBody] Employee Updated_Employee)
        {
            var employee = EmployeeList.SingleOrDefault(x => x.Id == id);

            if (employee is not null)
                return BadRequest();

            employee.Name = Updated_Employee.Name;
            employee.Surname = Updated_Employee.Surname;
            employee.DateofBirth = Updated_Employee.DateofBirth;
            employee.Email = Updated_Employee.Email;
            employee.PhoneNumber = Updated_Employee.PhoneNumber;
            employee.Salary = Updated_Employee.Salary;

            return Ok();


        }

    }
}
