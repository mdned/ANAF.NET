using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ANAF.NET
{
    public class AnafService : IAnafService
    {
        private readonly IAnafApi _anafApi;

        public AnafService(IAnafApi anafApi)
        {
            _anafApi = anafApi;
        }

        public async Task<SearchCompanyResponseDto> SearchCompany(string cui)
        {
            var request = new List<GetFiscalDataRequestDto> { new GetFiscalDataRequestDto(cui) };
            var anafResponse = await _anafApi.GetFiscalData(request);

            if (!anafResponse.ResponseMessage.IsSuccessStatusCode)
                throw new AnafException();

            var anafData = anafResponse.GetContent().Found.FirstOrDefault();

            if (anafData.Cui != cui)
                throw new AnafException();

            var anafAddress = anafData.Adresa;

            var addressContent = ParseAnafAddress(anafAddress);
            if (addressContent.Any())
            {
                var county =
                    addressContent.FirstOrDefault(x => x.Field == "judet").Value ??
                    addressContent.FirstOrDefault(x => x.Field == "sector").Value ??
                    addressContent.FirstOrDefault(x => x.Field == "municipiu").Value ??
                    "";
                var city =
                    addressContent.FirstOrDefault(x => x.Field == "sat").Value ??
                    addressContent.FirstOrDefault(x => x.Field == "comuna").Value ??
                    addressContent.FirstOrDefault(x => x.Field == "municipiu").Value ??
                    "";
                var street = addressContent.FirstOrDefault(x => x.Field == "strada").Value ?? "";
                var number = addressContent.FirstOrDefault(x => x.Field == "numar").Value ?? "";
                var building = addressContent.FirstOrDefault(x => x.Field == "bloc").Value ?? "";
                var entry = addressContent.FirstOrDefault(x => x.Field == "scara").Value ?? "";
                var floor = addressContent.FirstOrDefault(x => x.Field == "etaj").Value ?? "";
                var appartment = addressContent.FirstOrDefault(x => x.Field == "apartament").Value ?? "";

                return new SearchCompanyResponseDto(anafData.Denumire, anafData.Telefon, anafData.Cui, county, city, street, number, building, entry, floor, appartment);
            }
            return new SearchCompanyResponseDto();
        }

        private List<(string Field, string Value)> ParseAnafAddress(string address)
        {
            var patterns = new List<(string, string, bool)>
            {
                ("judet", "JUD.", false),
                ("municipiu", "MUN.", false),
                ("municipiu", "MUNICIPIUL", false),
                ("sat", "SAT ", false),
                ("sector", "SECTOR ", true),
                ("comuna", "COM.", false),
                ("strada", "STR.", false),
                ("numar", "NR.", false),
                ("bloc", "BL.", false),
                ("bloc", "CLĂDIREA ", true),
                ("scara", "SC.", false),
                ("etaj", "ET.", false),
                ("apartament", "AP.", false)
            };

            var values = new List<(string, string)>();
            var addressContents = address.Split(',');
            foreach (var (field, pattern, includePatternInResult) in patterns)
            {
                var matchedContent = addressContents.FirstOrDefault(x => x.Contains(pattern));
                if (string.IsNullOrWhiteSpace(matchedContent))
                    continue;
                if (includePatternInResult)
                {
                    values.Add((field, matchedContent.Trim()));
                    continue;
                }

                var startIndex = includePatternInResult ? 0 : pattern.Length + 1;
                var valueLength = matchedContent.Length - startIndex;
                var value = matchedContent.Substring(startIndex, valueLength);
                values.Add((field, value.Trim()));
            }

            return values;
        }
    }
}