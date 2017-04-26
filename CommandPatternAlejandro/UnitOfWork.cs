using System.Data;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Event;
using NHibernate.Tool.hbm2ddl;

namespace CommandPatternAlejandro
{
    public class UnitOfWork : IUnitOfWork
    {
        private static readonly ISessionFactory _sessionFactory;
        private ITransaction _transaction;

        public ISession Session { get; private set; }

        static UnitOfWork()
        {
            // Initialise singleton instance of ISessionFactory, static constructors are only executed once during the
            // application lifetime - the first time the UnitOfWork class is used
            _sessionFactory = Fluently.Configure()
                .Database(MySQLConfiguration.Standard.ConnectionString(x => x.FromConnectionStringWithKey("Default")))
                .Mappings(m=>m.FluentMappings.AddFromAssemblyOf<Program>())
                .ExposeConfiguration(config => new SchemaUpdate(config).Execute(false, true))
                .ExposeConfiguration(x =>
                {
                    x.EventListeners.PostCommitUpdateEventListeners =
                        new IPostUpdateEventListener[] { new EventListener() };
                    x.EventListeners.PostCommitInsertEventListeners =
                        new IPostInsertEventListener[] { new EventListener() };
                    x.EventListeners.PostCommitDeleteEventListeners =
                        new IPostDeleteEventListener[] { new EventListener() };
                    x.EventListeners.PostCollectionUpdateEventListeners =
                        new IPostCollectionUpdateEventListener[] { new EventListener() };
                })
                .BuildSessionFactory();
        }

        public UnitOfWork()
        {
            //Session = _sessionFactory.OpenSession();
        }

        public void BeginTransaction()
        {
            Session = _sessionFactory.OpenSession();
            _transaction = Session.BeginTransaction(IsolationLevel.ReadCommitted);
        }

        public void Commit()
        {
            try
            {
                _transaction.Commit();
            }
            catch
            {
                _transaction.Rollback();
                throw;
            }
            finally
            {
                Session.Close();
            }
        }
    }
}