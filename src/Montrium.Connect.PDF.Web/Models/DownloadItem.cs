using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Table;

namespace Montrium.Connect.PDF.Web.Models
{
    public class DownloadItem : TableEntity
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }
    
}
