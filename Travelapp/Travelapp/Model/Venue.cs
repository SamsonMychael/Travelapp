using System;
using System.Collections.Generic;
using System.Text;
using Travelapp.Helpers;

namespace Travelapp.Model
{
   public class Venue
    {
        public static string GetUrl(double latitude , double longitude)
        {
            return string.Format(Constants.VENUE_SEARCH, longitude, latitude, Constants.CLIENT_ID, Constants.CLIENT_SECRET, DateTime.Now.ToString("yyyyMMdd"));
        }
    }
}
