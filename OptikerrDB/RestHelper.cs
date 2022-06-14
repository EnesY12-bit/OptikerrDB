using System;
using System.Net;
using System.Text;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using OptikerDBLibary;
using OptikerService.Models;

namespace OptikerrDB
{

    static class RestHelper
    {
        static JsonSerializerOptions options = new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = true,
        };

        static Uri baseUri = new Uri("https://localhost:7170");
        static HttpClient client = new HttpClient();
        static string baseUrl = $"{baseUri.AbsoluteUri}";

        //GET Kunden
        public static async Task<List<kunden>?> Getallkunden()
        {
            HttpResponseMessage response = await client.GetAsync(baseUri + "api/kundens/");
            if (!response.IsSuccessStatusCode)
            {
                //throw new InvalidOperationException();
                return null;
            }
            
            string content = await response.Content.ReadAsStringAsync();
            Console.Write(content);
            List<kunden> kundenL = JsonSerializer.Deserialize<List<kunden>>(content, options);
            return kundenL;
        }

        //GET Brillen
        public static async Task<List<brillen>?> Getallbrillen()
        {
            HttpResponseMessage response = await client.GetAsync(baseUri + "api/brillens/");
            if (!response.IsSuccessStatusCode)
            {
                //throw new InvalidOperationException();
                return null;
            }
            string content = await response.Content.ReadAsStringAsync();
            List<brillen> brillenL = JsonSerializer.Deserialize<List<brillen>>(content, options);
            return brillenL;
        }

        //GET Mitarbeiter

        public static async Task<List<mitarbeiter>?> Getallmitarbeiter()
        {
            HttpResponseMessage response = await client.GetAsync(baseUri + "api/mitarbeiters/");
            if (!response.IsSuccessStatusCode)
            {
                //throw new InvalidOperationException();
                return null;
            }
            string content = await response.Content.ReadAsStringAsync();
            List<mitarbeiter> mitarbeiterL = JsonSerializer.Deserialize<List<mitarbeiter>>(content, options);
            return mitarbeiterL;
        }

        //Get Lieferer
        public static async Task<List<lieferer>?> Getalllieferer()
        {
            HttpResponseMessage response = await client.GetAsync(baseUri + "api/lieferers/");
            if (!response.IsSuccessStatusCode)
            {
                //throw new InvalidOperationException();
                return null;
            }
            string content = await response.Content.ReadAsStringAsync();
            List<lieferer> liefererL = JsonSerializer.Deserialize<List<lieferer>>(content, options);
            return liefererL;
        }

        //Get Geschäft
        public static async Task<List<geschaeft>?> Getallgeschaeft()
        {
            HttpResponseMessage response = await client.GetAsync(baseUri + "api/geschaefts/");
            if (!response.IsSuccessStatusCode)
            {
                //throw new InvalidOperationException();
                return null;
            }
            string content = await response.Content.ReadAsStringAsync();
            List<geschaeft> geschaeftL = JsonSerializer.Deserialize<List<geschaeft>>(content, options);
            return geschaeftL;
        }


        //Post Kunden
        public static async Task<kunden> PostKunden(int KID , kunden kunden)
        {
            string json = JsonSerializer.Serialize(kunden);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            var request = await client.PostAsync($"{baseUri}/api/kundens/{KID}/kundens", content);
            if (!request.IsSuccessStatusCode)
            {
                //thow new InvalidOperationExceptions();
                return null;
            }

            return JsonSerializer.Deserialize<kunden>(await request.Content.ReadAsStringAsync(), options);
        }

        //Post Brillen
        public static async Task<brillen> PostBrillen(int MID, brillen brillen)
        {
            string json = JsonSerializer.Serialize(brillen);
            StringContent content = new StringContent(json, Encoding.UTF8 , "application/json");

            var reqeust = await client.PostAsync($"{baseUri}/api/brillens/{MID}/brillens", content);
            if (!reqeust.IsSuccessStatusCode)
            {
                //thow new InvaildOpertaionExceptions();
                return null;
            }
            return JsonSerializer.Deserialize<brillen>(await reqeust.Content.ReadAsStringAsync(), options);
        }


    }
}
