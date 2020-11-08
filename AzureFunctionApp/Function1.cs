using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Autofac;
using Microsoft.Azure.Documents;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using AzureFunctions.Autofac;

namespace AzureFunctionApp
{
    [DependencyInjectionConfig(typeof(DIConfig))]
    public class Function1
    {
       // IApplication _application;
        public Function1()

        {
            // _application = application;
            //var container = Startup.GetContainer();
            //using (var scope = container.BeginLifetimeScope())
            //{
            //    _application = scope.Resolve<IApplication>();
            //}
        }
        [FunctionName("Function1")]
        public static string Run([CosmosDBTrigger(
            databaseName: "MyDB",
            collectionName: "MyCollection",
            ConnectionStringSetting = "CosmosDBConnectionString",
            LeaseCollectionName = "leases",CreateLeaseCollectionIfNotExists =true)]IReadOnlyList<Document> documents,ILogger log, [Inject] IApplication app)
        {
            var j = app.ProcessData();
            log.LogInformation(j);
            return j;
           
                //var container = Startup.GetContainer();
                //using (var scope = container.BeginLifetimeScope())
                //{
                //    var _application = scope.Resolve<IApplication>();
                //    _application.ProcessData();
                //}
                
                //if (documents != null && documents.Count > 0)
                //{
                //    log.LogInformation("Documents modified " + documents.Count);
                //    log.LogInformation("First document Id " + documents[0].Id);
                //}
               // Task<int> longRunningTask = LongRunningOperationAsync();
               // int result = await longRunningTask;          
            //use the result 
           // Console.WriteLine(result);
        }
        //public  static async Task<int> LongRunningOperationAsync() // assume we return an int from this long running operation 
        //{
        //    await Task.Delay(1000); // 1 second delay
        //    return 1;
        //}
    }
}
