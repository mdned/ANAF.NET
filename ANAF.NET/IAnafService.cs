using System.Threading.Tasks;

namespace ANAF.API
{
    public interface IAnafService
    {
        Task<SearchCompanyResponseDto> SearchCompany(string cui);
    }
}