using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using WSMDependencyInjection.Components.Main;

namespace WSM.Dependency.Injection
{
    public class AppBuilder
    {
        public AppBuilder()
        {
        }
        private List<Type> m_types = new List<Type>();
        private List<Type> m_singletonTypes = new List<Type>();
        private List<object> m_singletonObjects = new List<object>();
        public void Run(Type type)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var form = (WForm)Inject(type);
            form.appBuilder = this;
            Application.Run(form);
        }
        public void AddTransit<T>()
        {
            m_types.Add(typeof(T));
        }
        public void AddSingleton<T>()
        {
            m_singletonTypes.Add(typeof(T));
        }
        internal object Inject(Type type)
        {
            var contructer = type.GetConstructors().FirstOrDefault();
            if (contructer == null)
            {
                try
                {
                    return Activator.CreateInstance(type);
                }
                catch (Exception)
                {
                    return null;
                }
            }
            var paramters = contructer.GetParameters();
            var constructorParms = new List<object>();
            if (paramters.Length != -1)
            {
                foreach (var paramter in paramters)
                {
                    if (m_types.Any(e => e.FullName == paramter.ParameterType.FullName))
                    {
                        constructorParms.Add(Inject(m_types.First(e => e.FullName == paramter.ParameterType.FullName)));
                    }
                    else if (m_singletonTypes.Any(e => e.FullName == paramter.ParameterType.FullName))
                    {
                        if (m_singletonObjects.Any(e => e.GetType().FullName == paramter.ParameterType.FullName))
                        {
                            constructorParms.Add(m_singletonObjects.First(e => e.GetType().FullName == paramter.ParameterType.FullName));
                        }
                        else
                        {
                            var obj = Inject(m_singletonTypes.First(e => e.FullName == paramter.ParameterType.FullName));
                            m_singletonObjects.Add(obj);
                            constructorParms.Add(obj);
                        }
                    }
                    else
                    {
                        constructorParms.Add(null);
                    }
                }
                return Activator.CreateInstance(type, constructorParms.ToArray());
            }
            else
            {
                return Activator.CreateInstance(type);
            }
        }
    }
}