using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSM.Example.Services.Employee
{
    public class EmployeeService
    {
        private List<string> m_employees = new List<string>();
        public void AddEmployee(string Name)
        {
            m_employees.Add(Name);
        }

        public void DeleteEmployee(string Name)
        {
            m_employees.Remove(Name);
        }

        public List<string> GetEmployees()
        {
            return m_employees;
        }
    }
}
