using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using FlippingTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FlippingTracker.Fetcher
{
    public class GetRS3ItemsController : Controller
    {
        string Baseurl = "http://services.runescape.com/m=itemdb_rs/";

        public async Task<ActionResult> Index()
        {
            List<Item> EmpInfo = new List<Item>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage Res = await client.GetAsync("api/catalogue/items.json?category=21&alpha=a&page=1");
 
                if (Res.IsSuccessStatusCode)
                {  
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    var tmp = JsonConvert.DeserializeObject<RootObject>(EmpResponse);
                    EmpInfo = tmp.items;
                }

                return View(EmpInfo);
            }
        }
    }
}