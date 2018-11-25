
[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(TaskManager.UI.Web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(TaskManager.UI.Web.App_Start.NinjectWebCommon), "Stop")]

namespace TaskManager.UI.Web.App_Start
{
    using System;
    using System.Web;
    using Delloite.TaskManager.Data.Contracts.Respositories;
    using Delloite.TaskManager.Data.Repositories;
    using Delloite.TaskManager.Services;
    using Delloite.TaskManager.Services.Contracts;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
  
    //using NetCoders.CodeFirst.FluentApi.Repository;
    //using NetCoders.CodeFirst.FluentApi.Repository.Contracts;

    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                // Here where we're going to go
                // The good work with the IOC, imagine that the orignal class struck, or some bigger shit we have to use
                // a DUBLE (CLASS MOCKED) a class that simulates the same behavior as the original.
                //kernel.Bind<CLIENTREP>().For<DESCRIPTION>(); // To give the new.

                kernel.Bind<ITaskService>().To<TaskService>();
                kernel.Bind<IUserService>().To<UserService>();
                kernel.Bind<ITaskRepository>().To<TaskRepository>();
                kernel.Bind<IUserRepository>().To<UserRepository>();;

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
        }
    }
}
