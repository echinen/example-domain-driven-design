[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(ExampleDDDArchitecture.MVC.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(ExampleDDDArchitecture.MVC.App_Start.NinjectWebCommon), "Stop")]

namespace ExampleDDDArchitecture.MVC.App_Start
{
    using System;
    using System.Web;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Common;
    using ExampleDDDArchitecture.Application.Interface;
    using ExampleDDDArchitecture.Application;
    using ExampleDDDArchitecture.Domain.Interfaces.Services;
    using ExampleDDDArchitecture.Domain.Services;
    using ExampleDDDArchitecture.Domain.Interfaces.Repositories;
    using ExampleDDDArchitecture.Infra.Data.Repositories;

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
            kernel.Bind(typeof(IAppServiceBase<>)).To(typeof(AppServiceBase<>));
            kernel.Bind<ICotacaoAppService>().To<CotacaoAppService>();
            kernel.Bind<IProdutoAppService>().To<ProdutoAppService>();
            kernel.Bind<IPlanoAppService>().To<PlanoAppService>();

            kernel.Bind(typeof(IServiceBase<>)).To(typeof(ServiceBase<>));
            kernel.Bind<ICotacaoService>().To<CotacaoService>();
            kernel.Bind<IProdutoService>().To<ProdutoService>();
            kernel.Bind<IPlanoService>().To<PlanoService>();

            kernel.Bind(typeof(IRepositoryBase<>)).To(typeof(RepositoryBase<>));
            kernel.Bind<ICotacaoRepository>().To<CotacaoRepository>();
            kernel.Bind<IProdutoRepository>().To<ProdutoRepository>();
            kernel.Bind<IPlanoRepository>().To<PlanoRepository>();
        }        
    }
}
