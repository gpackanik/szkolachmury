using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wwwPostgresSQL.Models
{
    public class SearchResult
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        [JsonProperty("snippet")]
        public string Desc { get; set; }
    }
}
