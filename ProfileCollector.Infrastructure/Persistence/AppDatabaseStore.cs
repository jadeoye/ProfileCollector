using Raven.Client.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfileCollector.Infrastructure.Persistence
{
    public class AppDatabaseStore
    {
        public IDocumentStore Store { get; }
        public AppDatabaseStore(string url, string name)
        {
            Store = new DocumentStore
            {
                Urls = new[] { url },
                Database = name
            };

            Store.Initialize();
        }
    }
}
