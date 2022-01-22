using System.Collections.Generic;

namespace ANAF.API
{
    public class GetFiscalDataResponseDto
    {
        public int Cod { get; set; }
        public string Message { get; set; }
        public IEnumerable<FiscalDataDto> Found { get; set; }
    }
}