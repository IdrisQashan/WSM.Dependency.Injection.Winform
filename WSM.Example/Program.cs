using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WSM.Dependency.Injection;
using WSM.Example.Services.Employee;

namespace WSM.Example
{
    internal static class Program
    {
        static void Main()
        {
            AppBuilder app = new AppBuilder();
            app.AddSingleton<EmployeeService>();
            app.Run(typeof(Form1));
        }
    }
}
