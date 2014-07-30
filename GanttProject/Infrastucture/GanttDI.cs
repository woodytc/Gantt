using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using System.Web.Mvc;
//using Spring.Context.Support;
using System.Diagnostics;

using NHibernate;
using FluentNHibernate.Cfg;
using NHibernate.ByteCode.Castle;
using FluentNHibernate.Cfg.Db;

using GanttRepository.Repository;
using GanttRepository.RepositoryImpl;
using GanttRepository.Mapping;
using GanttProject.Properties;



namespace GanttProject.Infrastucture
{
    public static class GanttDI
    {
        public static void Initialize()
        {
           // HibernatingRhinos.Profiler.Appender.NHibernate.NHibernateProfiler.Initialize();
            //log4net.Config.XmlConfigurator.Configure();
            IKernel kernel = new StandardKernel();
            
            var a = CreateSessionFactory();
            kernel.Bind<ISessionFactory>().ToConstant(CreateSessionFactory()).InSingletonScope();

            kernel.Bind<ITasksRepository>()
                .To<TasksRepository>()
                .WithPropertyValue("SessionFactory", kernel.Get<ISessionFactory>());

            kernel.Bind<ILinksRepository>()
                .To<LinksRepository>()
                .WithPropertyValue("SessionFactory", kernel.Get<ISessionFactory>());
            
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }

        public static ISessionFactory CreateSessionFactory()
        {
            //Appist: 192.168.30.3
            return Fluently.Configure()
                .ProxyFactoryFactory<ProxyFactoryFactory>()
                .Database(MsSqlConfiguration.MsSql2008
                .ConnectionString(c => c
                .Server(Settings.Default.ServerDatabase) //dbuat01, 192.168.30.3, 192.168.10.11
                .Username(Settings.Default.UsernameDatabase)
                .Password(Settings.Default.PasswordDatabase)
                .Database(Settings.Default.Database)))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<TasksMap>())
                .ExposeConfiguration(c => c.SetProperty("current_session_context_class", "thread_static"))
                .BuildSessionFactory();
            //return Fluently.Configure()
            //    .ProxyFactoryFactory<ProxyFactoryFactory>()
            //    .Database(MsSqlConfiguration.MsSql2008
            //    .ConnectionString(c => c
            //    .Server("221.23.0.25") //dbuat01, 192.168.30.3, 192.168.10.11
            //    .Username("sa")
            //    .Password("ktblitadmin")
            //    .Database("BatchTB")))
            //    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<TasksMap>())
            //    .ExposeConfiguration(c => c.SetProperty("current_session_context_class", "thread_static"))
            //    .BuildSessionFactory();
        }

    }
}