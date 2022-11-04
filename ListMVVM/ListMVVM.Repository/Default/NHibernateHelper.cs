using NHibernate;
using NHibernate.Cfg;
using System.Reflection;

namespace ListMVVM.Repository.Default
{
    public sealed class NHibernateHelper
    {
        private static ISessionFactory SessionFactory;

        public static void OpenSession()
        {
            Configuration configuration = new Configuration();
            configuration.AddAssembly(Assembly.GetCallingAssembly());
            configuration.SetProperty(Environment.ConnectionString, @"localhost\\sqlexpress;");//just an example 
            SessionFactory = configuration.BuildSessionFactory();
        }

        public static ISession GetCurrentSession()
        {
            if (SessionFactory == null)
                OpenSession();

            return SessionFactory.OpenSession();
        }

        public static void CloseSessionFactory()
        {
            if (SessionFactory != null)
                SessionFactory.Close();
        }
    }
}
