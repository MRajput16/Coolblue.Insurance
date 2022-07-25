using Insurance.Domain;
using Insurance.Service;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Insurance.Tests
{
    public class ProductServiceMock : IProductService
    {
        private List<ProductResponseDto> _products;

        public ProductServiceMock()
        {
            InitializeProducts();
        }

        private void InitializeProducts()
        {
            _products = new List<ProductResponseDto>()
            {
                new ProductResponseDto(){ ProductTypeId  = 33, SalesPrice = 600, Id = 1},
                new ProductResponseDto(){ ProductTypeId = 32, SalesPrice = 400, Id = 2},
                new ProductResponseDto(){ ProductTypeId = 21, SalesPrice = 700, Id = 3},
                new ProductResponseDto(){ ProductTypeId = 33, SalesPrice = 400, Id = 4},
                new ProductResponseDto(){ ProductTypeId = 33, SalesPrice = 2000, Id = 5},
                new ProductResponseDto(){ ProductTypeId = 32, SalesPrice = 2000, Id = 6},

                new ProductResponseDto(){ ProductTypeId = 32, SalesPrice = 200, Id = 7},
                new ProductResponseDto(){ ProductTypeId = 21, SalesPrice = 450, Id = 8},
                new ProductResponseDto(){ ProductTypeId = 32, SalesPrice = 150, Id = 9},
                new ProductResponseDto(){ ProductTypeId = 21, SalesPrice = 299.8f, Id = 10},

                new ProductResponseDto(){ ProductTypeId = 32, SalesPrice = 500, Id = 11},
                new ProductResponseDto(){ ProductTypeId = 21, SalesPrice = 1800, Id = 12},
                new ProductResponseDto(){ ProductTypeId = 21, SalesPrice = 1999.6f, Id = 13},

                new ProductResponseDto(){ ProductTypeId = 32, SalesPrice = 2000, Id = 14},
                new ProductResponseDto(){ ProductTypeId = 21, SalesPrice = 4000, Id = 15},

                new ProductResponseDto(){ ProductTypeId = 32, SalesPrice = 2000, Id = 16},
                new ProductResponseDto(){ ProductTypeId = 33, SalesPrice = 4000, Id = 17},

                new ProductResponseDto(){ ProductTypeId = 841, SalesPrice = 4000, Id = 18},

                new ProductResponseDto(){ ProductTypeId = 841, SalesPrice = 4000, Id = 19},

                new ProductResponseDto(){ ProductTypeId = 124, SalesPrice = 3000, Id = 20}

            };
        }

        public Task<ProductResponseDto> GetProductAsync(int productId)
        {
            return Task.Run(() => { return _products.FirstOrDefault(p => p.Id == productId); });
        }
    }
}
