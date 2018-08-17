using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using Montrium.Connect.PDF.Web.Models;

namespace Montrium.Connect.PDF.Web.Controllers
{
    public class DownloadsController : Controller
    {
        private readonly CloudTableClient _tableClient;

        public DownloadsController(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("StorageConnectionString");
            var account = CloudStorageAccount.Parse(connectionString);
            _tableClient = account.CreateCloudTableClient();
        }

        public async Task<IActionResult> Index()
        {
            var table = _tableClient.GetTableReference("downloads");
            var query = new TableQuery<DownloadItem>();

            var entities = await table.ExecuteQuerySegmentedAsync(query, null);
            return View(entities);
        }
    }
}
