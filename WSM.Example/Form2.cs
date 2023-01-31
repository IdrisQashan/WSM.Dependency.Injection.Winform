using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WSM.Example.Services.Employee;
using WSMDependencyInjection.Components.Main;

namespace WSM.Example
{
    public partial class Form2 : WForm
    {
        private readonly EmployeeService service;

        public Form2(EmployeeService service)
        {
            InitializeComponent();
            this.service = service;
            RefreshData();
        }
        private void RefreshData()
        {
            listBox1.Items.Clear();
            listBox1.Items.AddRange(service.GetEmployees().ToArray());
        }
    }
}
