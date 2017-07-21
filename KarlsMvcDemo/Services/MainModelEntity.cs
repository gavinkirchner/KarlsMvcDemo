using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure.Storage.Table;
using KarlsMvcDemo.Models;

namespace KarlsMvcDemo.Services
{
    public class MainModelEntity : TableEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public static string DefaultPartitionKey = "12345";

        public MainModelEntity() { }

        public MainModelEntity(MainModel model)
        {
            this.PartitionKey = DefaultPartitionKey;
            this.RowKey = model.Id.ToString();
            this.Name = model.Name;
            this.Description = model.Description;
        }

        public MainModel ConvertToMainModel()
        {
            return new MainModel()
            {
                Id = Int32.Parse(RowKey),
                Name = this.Name,
                Description = this.Description
            };
        }
    }
}