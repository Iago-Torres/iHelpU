using iHelpU.MODEL.Interface_Services;
using iHelpU.MODEL.Interfaces;
using iHelpU.MODEL.Models;
using iHelpU.MODEL.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace iHelpU.MODEL.Services
{
    public class GoogleMaps_Service : IGoogleMaps_Service
    {
        private readonly BancoTccContext _context;
        private readonly HttpClient _httpClient;
        private readonly string _googleApiKey;

        public GoogleMaps_Service(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _googleApiKey = configuration["GoogleMaps:ApiKey"];
        }
        public async Task<List<string>> ObterPaisesAsync()
        {
            var url = $"https://maps.googleapis.com/maps/api/place/autocomplete/json?input=a&types=(regions)&key={_googleApiKey}";

            var response = await _httpClient.GetAsync(url);
            if (!response.IsSuccessStatusCode) return new List<string>();

            var json = await response.Content.ReadAsStringAsync();
            var jsonData = JsonSerializer.Deserialize<GooglePlacesResponse>(json);

            var paises = new HashSet<string>();

            if (jsonData?.Predictions != null)
            {
                foreach (var prediction in jsonData.Predictions)
                {
                    paises.Add(prediction.Description);
                }
            }

            return new List<string>(paises);
        }
    }

    // Classe para mapear a resposta JSON
    public class GooglePlacesResponse
    {
        public List<Prediction> Predictions { get; set; }
    }

    public class Prediction
    {
        public string Description { get; set; }
    }
} 

