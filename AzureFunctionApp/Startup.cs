using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using AzureFunctions.Autofac.Configuration;
using AzureFunctions.Autofac.Shared.Extensions;
using Microsoft.Extensions.Logging;

namespace AzureFunctionApp
{
    public class DIConfig
    {
       // public static IContainer Container { get; set; }
        /// <summary>
        /// Method to configure dependencies for all the functions
        /// </summary>
        
            public DIConfig(string functionName, ILoggerFactory factory)
            {
                DependencyInjection.Initialize(builder =>
                {
                    //Implicity registration
                    builder.RegisterInstance(factory).As<ILoggerFactory>().SingleInstance();
                    builder.RegisterGeneric(typeof(AppLogger<>)).As(typeof(ILogger<>)).SingleInstance();
                    builder.RegisterType<Application>().As<IApplication>();

                    builder.RegisterLoggerFactory(factory);
                }, functionName);
            }
            //ContainerBuilder builder = new ContainerBuilder();
            //builder.RegisterType<Application>().As<IApplication>().SingleInstance();
            //Container = builder.Build();

            //return Container;
        

        }
    }
