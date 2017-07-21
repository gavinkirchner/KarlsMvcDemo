using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using KarlsMvcDemo.Models;

namespace KarlsMvcDemo.Services
{
    public class MainModelService
    {
        private const string _connectionString = "XXXXX";

        private const string TABLE_NAME = "Main";
        private CloudTable _mainTable;

        public MainModelService()
        {
            var storageAccount = CloudStorageAccount.Parse(_connectionString);
            var tableClient = storageAccount.CreateCloudTableClient();
            _mainTable = tableClient.GetTableReference(TABLE_NAME);
            _mainTable.CreateIfNotExists();
        }

        public MainModel Get(int id)
        {
            var operation = TableOperation.Retrieve<MainModelEntity>(MainModelEntity.DefaultPartitionKey,id.ToString());
            var result = _mainTable.Execute(operation);

            if (result.HttpStatusCode != 200)
            {
                return null;
            }

            return ((MainModelEntity) result.Result).ConvertToMainModel();
        }

        public void Save(MainModel model)
        {
            var operation = TableOperation.InsertOrReplace(new MainModelEntity(model));
            _mainTable.Execute(operation);
        }
    }
}