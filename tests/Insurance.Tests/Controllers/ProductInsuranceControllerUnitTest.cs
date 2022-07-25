using System;
using System.Threading.Tasks;
using Insurance.Api.Controllers;
using Insurance.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Insurance.Tests
{
    public class ProductInsuranceControllerUnitTest: IClassFixture<SetupTestFixture>
    {
        private readonly IServiceProvider _serviceProvider;
        private ProductInsuranceController _productInsuranceController;

        public ProductInsuranceControllerUnitTest(SetupTestFixture setuptestFixture)
        {
            _serviceProvider = setuptestFixture.ServiceProvider;

            _productInsuranceController = _serviceProvider.GetService<ProductInsuranceController>();
        }

        [Theory]
        [MemberData(nameof(InsuranceTestData.InsuranceWith1000), MemberType = typeof(InsuranceTestData))]
        public async Task GetProductInsurance_SalesPriceIn500And2000_ExpectedInsurance1000Euros(int productId, float expectedInsuranceValue)
        {
            var result = await _productInsuranceController.GetProductInsuranceAsync(productId);
            Assert.IsType<OkObjectResult>(result);
            Assert.Equal(
                expected: expectedInsuranceValue,
                actual: ((InsuranceResponseDto)((OkObjectResult)result).Value).InsuranceValue
            );
        }

        [Theory]
        [MemberData(nameof(InsuranceTestData.InsuranceWith500), MemberType = typeof(InsuranceTestData))]
        public async Task GetProductInsurance_SalesPriceLess500_ExpectedInsurance500Euros(int productId, float expectedInsuranceValue)
        {
            var result = await _productInsuranceController.GetProductInsuranceAsync(productId);
            Assert.IsType<OkObjectResult>(result);

            Assert.Equal(
                expected: expectedInsuranceValue,
                actual: ((InsuranceResponseDto)((OkObjectResult)result).Value).InsuranceValue
            );
        }

        [Theory]
        [MemberData(nameof(InsuranceTestData.InsuranceWith0), MemberType = typeof(InsuranceTestData))]
        public async Task GetProductInsurance_SalesPriceLess500_ExpectedInsurance0Euros(int productId, float expectedInsuranceValue)
        {
            var result = await _productInsuranceController.GetProductInsuranceAsync(productId);
            Assert.IsType<OkObjectResult>(result);

            Assert.Equal(
                expected: expectedInsuranceValue,
                actual: ((InsuranceResponseDto)((OkObjectResult)result).Value).InsuranceValue
            );
        }

        [Theory]
        [MemberData(nameof(InsuranceTestData.InsuranceWith2000), MemberType = typeof(InsuranceTestData))]
        public async Task GetProductInsurance_SalesPriceAbove2000_ExpectedInsurance2000Euros(int productId, float expectedInsuranceValue)
        {
            var result = await _productInsuranceController.GetProductInsuranceAsync(productId);
            Assert.IsType<OkObjectResult>(result);

            Assert.Equal(
                expected: expectedInsuranceValue,
                actual: ((InsuranceResponseDto)((OkObjectResult)result).Value).InsuranceValue
            );
        }

        [Theory]
        [MemberData(nameof(InsuranceTestData.InsuranceWith2500), MemberType = typeof(InsuranceTestData))]
        public async Task GetProductInsurance_SalesPriceAbove2000_ExpectedInsurance2500Euros(int productId, float expectedInsuranceValue)
        {
            var result = await _productInsuranceController.GetProductInsuranceAsync(productId);
            Assert.IsType<OkObjectResult>(result);

            Assert.Equal(
                expected: expectedInsuranceValue,
                actual: ((InsuranceResponseDto)((OkObjectResult)result).Value).InsuranceValue
            );
        }
    }
}