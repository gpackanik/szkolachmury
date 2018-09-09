using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using wwwPostgresSQL.Models;

namespace wwwPostgresSQL.Controllers
{
    public class BingController : Controller
    {
        private readonly IConfiguration _config;

        public BingController(IConfiguration config)
        {
            _config = config;
        }
        public async Task<IActionResult> Search(string searchPhase)
        {
            var results = new List<SearchResult>();

            if (!string.IsNullOrWhiteSpace(searchPhase))
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", _config["Bing:Key"]);
                client.DefaultRequestHeaders.Add("BingAPIs-Market", "pl-PL");
                client.BaseAddress = new Uri(_config["Bing:Url"]);

                var response = client.GetAsync($"search?q={searchPhase}");
                JObject bingResponse = JObject.Parse(await response.Result.Content.ReadAsStringAsync());
                IList<JToken> bingResults = bingResponse["webPages"]["value"].Children().ToList();

                foreach (var item in bingResults)
                {
                    results.Add(item.ToObject<SearchResult>());
                }
            }

            return View(results);
        }
    }
}