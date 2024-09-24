using Raven.Client.Documents;
using Raven.Client.ServerWide.Operations;
using Raven.Client.ServerWide;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

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

            _createDatabaseIfNotExists(name);
        }

        private void _createDatabaseIfNotExists(string name)
        {
            var databaseRecord = Store.Maintenance.Server.Send(new GetDatabaseRecordOperation(name));

            if (databaseRecord == null)
            {
                var createDatabaseOperation = new CreateDatabaseOperation(new DatabaseRecord(name));
                Store.Maintenance.Server.Send(createDatabaseOperation);
            }
        }
    }
}
