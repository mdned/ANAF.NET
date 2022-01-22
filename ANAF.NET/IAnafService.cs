using System.Threading.Tasks;

namespace ANAF.NET
{
    public interface IAnafService
    {
        Task<SearchCompanyResponseDto> SearchCompany(string cui);
    }
}