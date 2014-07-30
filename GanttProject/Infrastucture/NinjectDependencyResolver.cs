// -----------------------------------------------------------------------
// <copyright file="NinjectDependencyResolver.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace GanttProject.Infrastucture
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Ninject;
    using Ninject.Syntax;
    using System.Web.Mvc;
    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private readonly IResolutionRoot _resolutionRoot;
        public NinjectDependencyResolver(IResolutionRoot kernel)
        {           
            _resolutionRoot = kernel;
        }

        public object GetService(Type serviceType)
        {
            return _resolutionRoot.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _resolutionRoot.GetAll(serviceType);

        }
    }
}
