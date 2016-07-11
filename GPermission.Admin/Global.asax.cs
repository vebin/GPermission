using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using ECommon.Autofac;
using ECommon.Components;
using ECommon.Configurations;
using ECommon.Logging;
using ENode.Commanding;
using ENode.Configurations;
using ENode.EQueue;
using GPermission.Admin.Extensions;
using GPermission.Common;
using GPermission.IQueryServices;
using GPermission.QueryServices;

namespace GPermission.Admin
{
	public class WebApiApplication : System.Web.HttpApplication
	{
		private ILogger _logger;
		private Configuration _ecommonConfiguration;
		private ENodeConfiguration _enodeConfiguration;

		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();
			GlobalConfiguration.Configure(WebApiConfig.Register);
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);

			InitializeECommon();
			InitializeENode();
		}

		private void InitializeECommon()
		{
			_ecommonConfiguration = Configuration
				.Create()
				.UseAutofac()
				.RegisterCommonComponents()
				.UseLog4Net()
				.UseJsonNet()
				.RegisterUnhandledExceptionHandler();

			_logger = ObjectContainer.Resolve<ILoggerFactory>().Create(GetType().FullName);
			_logger.Info("ECommon initialized.");
		}
		private void InitializeENode()
		{
			ConfigSettings.Initialize();

			var assemblies = new[]
			{
				Assembly.Load("GPermission.Commands"),
				Assembly.Load("GPermission.CommandHandlers"),
				Assembly.Load("GPermission.IQueryServices"),
				Assembly.Load("GPermission.QueryServices"),
				Assembly.GetExecutingAssembly()
			};

			_enodeConfiguration = _ecommonConfiguration
				.CreateENode()
				.RegisterENodeComponents()
				.RegisterBusinessComponents(assemblies)
				.UseEQueue()
				.InitializeBusinessAssemblies(assemblies)
				.StartEQueue();

		     RegisterControllers();
			_logger.Info("ENode initialized.");
		}
		private void RegisterControllers()
		{
			var container = (ObjectContainer.Current as AutofacObjectContainer).Container;
			var builder = new ContainerBuilder();
			builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
				.Where(
					t => !t.IsAbstract && (typeof (IHttpController).IsAssignableFrom(t) || typeof (IController).IsAssignableFrom(t)))
				.InstancePerLifetimeScope();
			GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);//ApiController　WebApi注入 
			DependencyResolver.SetResolver(new AutofacDependencyResolver(container));//普通的MVC Controller 注入 
		}
	}
}
