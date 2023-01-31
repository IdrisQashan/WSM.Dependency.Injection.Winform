using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WSM.Dependency.Injection;

namespace WSMDependencyInjection.Components.Main
{
    public class WForm : Form
    {
        internal AppBuilder appBuilder;
        public void WShow<T>()
            where T : WForm
        {
            var obj = (WForm)appBuilder.Inject(typeof(T));
            obj.appBuilder = appBuilder;
            obj.Show();
        }
        public void WShowDialog<T>()
            where T : WForm
        {
            var obj = (WForm)appBuilder.Inject(typeof(T));
            obj.appBuilder = appBuilder;
            obj.ShowDialog();
        }
    }
}
