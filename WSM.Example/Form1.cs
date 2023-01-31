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
    public partial class Form1 : WForm
    {
        private readonly EmployeeService serivce;

        public Form1(EmployeeService serivce)
        {
            InitializeComponent();
            this.serivce = serivce;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            serivce.AddEmployee(textBox1.Text);
        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            WShowDialog<Form2>();
        }
    }
}
