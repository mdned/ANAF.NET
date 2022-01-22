using System;
using System.Text.Json.Serialization;

namespace ANAF.API
{
    public class GetFiscalDataRequestDto
    {
        [JsonPropertyName("cui")]
        public string Cui { get; set; }
        [JsonPropertyName("data")]
        public string Data 
        {
            get 
            {
                return DateTime.Today.ToString("yyyy-MM-dd");
            }
        }

        public GetFiscalDataRequestDto(string cui)
        {
            Cui = cui;
        }
    }
}