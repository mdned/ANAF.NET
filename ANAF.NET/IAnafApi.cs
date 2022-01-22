using RestEase;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ANAF.API
{
    [AllowAnyStatusCode]
    public interface IAnafApi
    {
        [Post]
        public Task<Response<GetFiscalDataResponseDto>> GetFiscalData([Body] IEnumerable<GetFiscalDataRequestDto> request);
    }
}