using UnityEngine;
using ExtraPerry.Shadow.WeatherApp.API.Model;
using System.Collections.Generic;

namespace ExtraPerry.Shadow.WeatherApp.API.SO
{
    [CreateAssetMenu(menuName = "Shadow Weather App/API SO/Search Autocomplete Info")]
    public class SearchAutocompleteInfo : Info
    {
        public List<SearchAutocomplete> data = new List<SearchAutocomplete>();

        public void hasBeenRead()
        {
            isCompletedOnce = false;
        }
    }
}
