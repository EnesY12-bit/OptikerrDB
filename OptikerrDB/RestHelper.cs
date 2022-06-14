#nullable disable
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
        public static async Task<List<kunden>?> GetallkundenAsync()
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
        public static async Task<List<brillen>?> GetallbrillenAsync()
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

        public static async Task<List<mitarbeiter>?> GetallmitarbeiterAsync()
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
        public static async Task<List<lieferer>?> GetallliefererAsync()
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
        public static async Task<List<geschaeft>?> GetallgeschaeftAsync()
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
        public static async Task<kunden> PostKundenAsync(int KID, kunden kunden)
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
        public static async Task<brillen> PostBrillensAsync(int MID, brillen brillen)
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

        //Post Mitarbeiter
        public static async Task<mitarbeiter> PostMitarbeiterAsync(int PID, mitarbeiter mitarbeiter)
        {
            string json = JsonSerializer.Serialize(mitarbeiter);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            var request = await client.PostAsync($"{baseUri}/api/mitarbeiters/{PID}/mitarbeiters", content);
            if (!request.IsSuccessStatusCode)
            {
                //thow new InvaildOperationExceptions();
                return null;
            }
            return JsonSerializer.Deserialize<mitarbeiter>(await request.Content.ReadAsStringAsync(), options);
        }

        //Post Lieferer
        public static async Task<lieferer> PostLiefererAsync(int LID, lieferer lieferer)
        {
            string json = JsonSerializer.Serialize(lieferer);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            var request = await client.PostAsync($"{baseUri}/api/lieferers/{LID}/lieferers", content);
            if (!request.IsSuccessStatusCode)
            {
                //thow new InvaildOperationExceptions();
                return null;
            }
            return JsonSerializer.Deserialize<lieferer>(await request.Content.ReadAsStringAsync(), options);
        }

        //Post Geschäft
        public static async Task<geschaeft> PostGeschaeftAsync(int GID, geschaeft geschaeft)
        {
            string json = JsonSerializer.Serialize(geschaeft);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            var request = await client.PostAsync($"{baseUri}/api/geschaefts/{GID}/geschaefts", content);
            if (!request.IsSuccessStatusCode)
            {
                //thow new InvaildOperationExceptions();
                return null;
            }
            return JsonSerializer.Deserialize<geschaeft>(await request.Content.ReadAsStringAsync(), options);
        }


        //Delete Kunden
        public static async Task<bool> DeleteKundenAsync(int dKID)
        {
            var request = await client.DeleteAsync($"{baseUri}/api/kundens/{dKID}");

            if (!request.IsSuccessStatusCode)
            {
                return false;
            }
            return true;
        }
        //Delete Brillen
        public static async Task<bool> DeleteBrillenAsync(int dMID)
        {
            var request = await client.DeleteAsync($"{baseUri}/api/brillen/{dMID}");

            if (!request.IsSuccessStatusCode)
            {
                return false;
            }
            return true;
        }
        //Delete Mitarbeiter
        public static async Task<bool> DeleteMitarbeiterAsync(int dPID)
        {
            var request = await client.DeleteAsync($"{baseUri}/api/mitarbeiters/{dPID}");

            if (!request.IsSuccessStatusCode)
            {
                return false;
            }
            return true;
        }
        //Delete Lieferer
        public static async Task<bool> DeleteLiefererAsync(int dLID)
        {
            var request = await client.DeleteAsync($"{baseUri}/api/lieferers/{dLID}");

            if (!request.IsSuccessStatusCode)
            {
                return false;
            }
            return true;
        }
        //Delete Geschäft
        public static async Task<bool> DeleteGeschaeftAsync(int dGID)
        {
            var request = await client.DeleteAsync($"{baseUri}/api/geschaefts/{dGID}");

            if (!request.IsSuccessStatusCode)
            {
                return false;
            }
            return true;
        }

        //Patch Kunden

        //Patch Brillen

        //Patch Mitarbeiter

        //Patch Lieferer

        //Patch Geschäft

    }
}
