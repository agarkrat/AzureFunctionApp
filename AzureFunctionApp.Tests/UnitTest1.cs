using System;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AzureFunctionApp.Tests
{
    [TestClass]
    public class UnitTest1
    {
       
        private ILogger<Application> loggerMock;
        private static readonly string endpointUrl = "https://localhost:8081";
        private static readonly string authorizationKey = "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";
        private static readonly string databaseId = "MyDB";
        private static readonly string collectionId = "MyCollection";
        private static DocumentClient client;

        [TestMethod]
        public async Task Function1Test()
        {
            
            var logMock = new Mock<ILogger<Application>>();
            loggerMock = logMock.Object;
            var loggingMock = new Mock<ILogger>();
            client = new DocumentClient(new Uri(endpointUrl), authorizationKey);
            var uri = UriFactory.CreateDocumentCollectionUri(databaseId, collectionId);

            var doc = new Document();
            doc.SetPropertyValue("name", "jay");
            List<Document> documents = new List<Document>();
            doc = await client.CreateDocumentAsync(
                "/dbs/MyDB/colls/MyCollection", doc, null);
            documents.Add(doc);
            Console.WriteLine("insert success");

            var result = Function1.Run(documents, loggingMock.Object, new Application(loggerMock));
            Assert.AreEqual("krati",result);
        }
    }
}
