using Microsoft.VisualBasic;
using Newtonsoft.Json;
using PxLookUp.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PxLookUp
{
    public class RestService
    {
        HttpClient client;
        List<Course> Items = new List<Course>();

        public RestService()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
        }

        public async Task<List<Course>> GetCoursesAsync()
        {
            var uri = new Uri("http://datatank.pxl.be/core/public/pxl-it/roosters/1516.json");

            var result = await client.GetAsync(uri).ConfigureAwait(continueOnCapturedContext: false);

            if (result.IsSuccessStatusCode)
            {
                var content = await result.Content.ReadAsStringAsync();
                Items = JsonConvert.DeserializeObject<List<Course>>(content);
            }

            return Items; 
        }

        public async Task<List<Menu>> GetMenusAsync()
        {
            var uri = new Uri("http://datatank.pxl.be/core/public/pxl/catering.json");

            var result = await client.GetAsync(uri).ConfigureAwait(continueOnCapturedContext: false);

            List<Menu> Items = new List<Menu>();

            if (result.IsSuccessStatusCode)
            {
                var content = await result.Content.ReadAsStringAsync();
                Items = JsonConvert.DeserializeObject<List<Menu>>(content);
            }

            return Items;
        }
    }
}
