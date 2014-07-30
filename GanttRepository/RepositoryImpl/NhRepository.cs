using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.AdoNet.Util;
using NHibernate.Criterion;

namespace GanttRepository.Repository
{
    public class NhRepository
    {
        public NhRepository()
        {
            
        }
        private ISessionFactory _sessionFactory = null;
        public static string NHibernateGeneratedSQL { get; set; }
        public static int QueryCounter { get; set; }
        public static string FormatSQL()
        {
            BasicFormatter formatter = new BasicFormatter();
            return formatter.Format(NHibernateGeneratedSQL.ToUpper());
        }

        public ISessionFactory SessionFactory
        {
            protected get { return _sessionFactory; }
            set { _sessionFactory = value; }
        }

        public IList<T> ExecuteICriteria<T>()
        {
            //using (ITransaction transaction = Session.BeginTransaction())
            using (var Session = SessionFactory.OpenStatelessSession())
            {
                try
                {
                    IList<T> result = Session.CreateCriteria(typeof(T)).List<T>();
                    return result;
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }

        public void Update<T>(T enity)
        {
            using (var Session = SessionFactory.OpenStatelessSession())
            using (var tran = Session.BeginTransaction())
            {
                try
                {
                    Session.Update(enity);
                    tran.Commit();
                }
                catch (Exception executeICriteria)
                {
                    tran.Rollback();
                    throw executeICriteria;

                }
            }
        }

        public void Insert<T>(T entity)
        {
            using (var Session = SessionFactory.OpenStatelessSession())
            using (var tran = Session.BeginTransaction())
            {
                try
                {
                    Session.Insert(entity);
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw;
                }
            }
        }

        public void SaveOrUpdate<T>(T entity)
        {
            using (var Session = SessionFactory.OpenSession())
            using (var tran = Session.BeginTransaction())
            {
                try
                {
                    Session.SaveOrUpdate(entity);
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw;
                }

            }

        }

        public void Delete<T>(T entity)
        {
            using (var Session = SessionFactory.OpenSession())
            using (var ts = Session.BeginTransaction())
            {
                try
                {
                    Session.Delete(entity);
                    ts.Commit();
                }
                catch (Exception ex)
                {
                    ts.Rollback();
                    throw;
                }
            }
        }
        
        /// <summary>
        ///  Get by id use in case one PK
        ///  Function can't use in case multi PK
        /// </summary>
        /// <typeparam name="T">Generic Class</typeparam>
        /// <param name="list">Array is value pk</param>
        /// <returns>Entity of result </returns>
        public T GetByID<T>(Array list)
        {
            using (var session = SessionFactory.OpenStatelessSession())
            {
                var result = session.Get<T>(list.GetValue(0));
                return result;
            }
        }

        public IList<T> ExecuteICriteriaOrderBy<T>(T entity, string orderBy)
        {
            using (var Session = SessionFactory.OpenStatelessSession())
            using (ITransaction transaction = Session.BeginTransaction())
            {
                try
                {
                    IList<T> result = Session.CreateCriteria(typeof(T))
                    .AddOrder(Order.Asc(orderBy))
                    .List<T>();
                    transaction.Commit();
                    return result;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}
