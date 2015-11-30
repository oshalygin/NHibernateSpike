using System.Reflection;
using Entities;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;

namespace NHibernateSpike
{
    class Program
    {
        static void Main(string[] args)
        {
            var configuration = new Configuration();
            configuration.DataBaseIntegration(x =>
            {
                x.ConnectionString = "Server=localhost;Database=NHibernateSpike;Integerated Security=SSPI;";
                x.Driver<SqlClientDriver>();
                x.Dialect<MsSql2012Dialect>();
                x.LogSqlInConsole = true;
            });

            configuration.AddAssembly(Assembly.GetExecutingAssembly());

            var sessionFactory = configuration.BuildSessionFactory();

            using (var session = sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var customers = session.QueryOver<Customer>().Where(x => x.FirstName == "Oleg");
                    transaction.Commit();
                    
                }

            }

        }
    }
}
