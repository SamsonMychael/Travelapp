using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Travelapp.Model;

namespace Travelapp.Logic
{
   public class VenueLogic
    {
        public async static Task<List<Venue>> GetVenues(double latitude , double longitude)
        {
            List<Venue> gets = new List<Venue>();

            var url = Venue.GetUrl( latitude, longitude );

            using (HttpClient client = new HttpClient())
            {
                var responce = await client.GetAsync(url);
                var json = responce.Content.ReadAsStringAsync();

            }


                return gets;
            
        }
    }
}
