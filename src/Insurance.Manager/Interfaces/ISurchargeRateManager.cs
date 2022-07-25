using Insurance.Domain;
using System.Threading.Tasks;

namespace Insurance.Manager
{
    public interface ISurchargeRateManager
    {
        Task<ProductTypeSurchargeRate> CreateSurchargeRateAsync(ProductTypeSurchargeRate productTypeSurchargeRate);
    }
}
