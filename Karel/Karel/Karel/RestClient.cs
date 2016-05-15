using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Karel
{
    public class RestClient : IRestService
    {
        public RestClient() { }

        public async Task<RootObject.Course[]> GetCoursesAsync()
        {
            var client = new HttpClient();

            client.BaseAddress
        }
    }
}
