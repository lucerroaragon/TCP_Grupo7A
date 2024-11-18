using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace Dominio
{
    public class ApiClient
    {
        public static readonly HttpClient client = new HttpClient();

        public static async Task<string> GetAsync(string url)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                return responseBody;

            }
            catch (Exception e)
            {

                throw new Exception("Error al consumir la API: " + e.Message);



            }


        }



    }
}
