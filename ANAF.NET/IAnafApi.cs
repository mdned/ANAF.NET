using RestEase;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ANAF.NET
{
    [AllowAnyStatusCode]
    public interface IAnafApi
    {
        [Post]
        public Task<Response<GetFiscalDataResponseDto>> GetFiscalData([Body] IEnumerable<GetFiscalDataRequestDto> request);
    }
}