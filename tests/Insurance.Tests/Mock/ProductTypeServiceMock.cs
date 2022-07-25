using Insurance.Domain;
using Insurance.Service;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Insurance.Tests
{
    public class ProductTypeServiceMock : IProductTypeService
    {
        private List<ProductTypeResponseDto> _productTypes;
        
        public ProductTypeServiceMock()
        {
            InitializeProductTypes();
        }

        private void InitializeProductTypes()
        {
            _productTypes = new List<ProductTypeResponseDto>()
            {
                new ProductTypeResponseDto(){ CanBeInsured = true, Id = 21, Name = "Laptops"},
                new ProductTypeResponseDto(){ CanBeInsured = true, Id = 33, Name = "Digital cameras"},
                new ProductTypeResponseDto(){ CanBeInsured = true, Id = 32, Name = "Smartphones"},
                new ProductTypeResponseDto(){ CanBeInsured = false, Id = 841, Name = "Laptops"},
                new ProductTypeResponseDto(){ CanBeInsured = false, Id = 35, Name = "Laptops"},
                new ProductTypeResponseDto(){ CanBeInsured = true, Id = 124, Name = "Washing machines"},
                new ProductTypeResponseDto(){ CanBeInsured = true, Id = 2, Name = "Test"},
            };
        }

        public Task<ProductTypeResponseDto> GetProductTypeAsync(int productTypeId)
        {
            return Task.Run(() => { return _productTypes.FirstOrDefault(p => p.Id == productTypeId); });
        }

        public Task<bool> IsProductTypeIdExistsAsync(int productTypeId)
        {
            return Task.Run(() => { return GetProductTypeAsync(productTypeId) != null; });
        }
    }
}
