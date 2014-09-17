using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Cfg;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Tool.hbm2ddl;

namespace PictureManager
{
    class DataConfig
    {
        private static ISessionFactory _sessionFactory;
        private static bool _startupComplete = false;
        private static readonly object _locker = new object();

        public static ISession GetSession()
        {
            ISession session = _sessionFactory.OpenSession();
            session.BeginTransaction();
            return session;
        }

        public static void EnsureStartup()
        {
            if (!_startupComplete)
            {
                lock (_locker)
                {
                    if (!_startupComplete)
                    {
                        DataConfig.PerformStartup();
                        _startupComplete = true;
                    }
                }
            }
        }

        private static void PerformStartup()
        {
            InitializeLog4Net();
            InitializeSessionFactory();
            InitializeRepositories();
        }

        private static void InitializeSessionFactory()
        {
            Configuration configuration = BuildConfiguration();
            _sessionFactory = configuration.BuildSessionFactory();
        }

        public static Configuration BuildConfiguration()
        {
            return Fluently.Configure(new Configuration().Configure())
            .Mappings(cfg =>
                cfg.FluentMappings
            .AddFromAssembly(typeof(PictureMap).Assembly))
            .BuildConfiguration();
        }

        private static void InitializeLog4Net()
        {
            string configPath = Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory,
            "log4Net.config");
            var fileInfo = new FileInfo(configPath);
            XmlConfigurator.ConfigureAndWatch(fileInfo);
        }

        private static void InitializeRepositories()
        {
            Func<IPictureRepository> builder = () => new PictureRepository();
            PictureRepositoryFactory.RepositoryBuilder = builder;
        }
    }
}
