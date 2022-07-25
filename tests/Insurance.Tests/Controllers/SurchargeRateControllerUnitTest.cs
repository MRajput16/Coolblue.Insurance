using Xunit;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Insurance.Domain;
using Insurance.Api.Controllers;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System;

namespace Insurance.Tests.Controllers
{
    /// <summary>
    /// Two approaches to assign surcharge rate to a product type:
    /// 1. simple choice in three stpes:(preferred; because of the separation of concern, high maintainability, decoupled solution)
    /// 1.a. create endpoint for creating surcharge rates; Name, Value --> returns the Id of the surcharge rate created or the whole object created
    /// 1.b. create endpoint to list all surcharge rates; Id, Name, Value
    /// 1.c. create endpoint to assign product type to its surcharge rates; productTypeId, surchargeRatesIds
    /// 
    /// 2. one single step
    /// 2.a CreateSurchareRateProductType; send productId with list of floats which are surchargeRates (as it's required only one endpoint)
    /// Cons of 2nd choice is: 
    ///     could add add multiple surcharge rates with the same value
    ///     not extendable functionality; not easy to maintain
    /// 
    /// </summary>
    public class SurchargeRateControllerUnitTest : IClassFixture<SetupTestFixture>
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ProductInsuranceController _productInsuranceController;
        private SurchargeRateController _surchargeRateController;

        public SurchargeRateControllerUnitTest(SetupTestFixture setuptestFixture)
        {
            _serviceProvider = setuptestFixture.ServiceProvider;

            _surchargeRateController = _serviceProvider.GetService<SurchargeRateController>();
            _productInsuranceController = _serviceProvider.GetService<ProductInsuranceController>(); ;
        }

        [Theory]
        [MemberData(nameof(SurchargeRateTestData.ValidSurchargeRates), MemberType = typeof(SurchargeRateTestData))]
        public async Task AddProductTypeSurchargeRates_ExpectedCreated(SurchargeRateCreateRequestDto surchargeRateCreateRequestDto)
        {
            //we need async data structure for storing the product type and its surcharge rate
            var result = await _surchargeRateController.CreateSurchargeRateAsync(surchargeRateCreateRequestDto);
            Assert.IsType<OkObjectResult>(result);

            Assert.Equal(
                expected: surchargeRateCreateRequestDto.ProductTypeId,
                actual: ((SurchargeRateCreateResponseDto)((OkObjectResult)result).Value).ProductTypeId
            );

            Assert.Equal(
                expected: surchargeRateCreateRequestDto.SurchareRates,
                actual: ((SurchargeRateCreateResponseDto)((OkObjectResult)result).Value).SurchareRates
            );
        }

        [Theory]
        [MemberData(nameof(SurchargeRateTestData.InsuranceWithSurchargeRate), MemberType = typeof(SurchargeRateTestData))]
        public async Task GetProductInsurance_SalesPriceAbove2000_WithSurchargeRate_ExpectedInsurance2500Euros(int productId, float expectedInsuranceValue, SurchargeRateCreateRequestDto surchargeRateCreateRequestDto)
        {
            var createSurchargeRateResponse = await _surchargeRateController.CreateSurchargeRateAsync(surchargeRateCreateRequestDto);
            Assert.IsType<OkObjectResult>(createSurchargeRateResponse);

            var result = await _productInsuranceController.GetProductInsuranceAsync(productId);
            Assert.IsType<OkObjectResult>(result);

            Assert.Equal(
                expected: expectedInsuranceValue,
                actual: ((InsuranceResponseDto)((OkObjectResult)result).Value).InsuranceValue
            );
        }


        [Theory]
        [MemberData(nameof(SurchargeRateTestData.ValidSurchargeRates_ConcurrentUsers), MemberType = typeof(SurchargeRateTestData))]
        public async Task AddProductTypeSurchargeRates_ConcurrentUsers_ExpectedCreated(List<SurchargeRateCreateRequestDto> requests)
        {
            var tasks = new List<Task<IActionResult>>();
            foreach (var request in requests)
            {
                tasks.Add(_surchargeRateController.CreateSurchargeRateAsync(request));
            }
            var result = await Task.WhenAll(tasks);

            var resultOkObject = new ArrayList(result.Select(r => ((OkObjectResult)r).Value).ToArray());
            var createSurchargeRateResponse = resultOkObject.Cast<SurchargeRateCreateResponseDto>().ToList();
            Assert.Equal(
                expected: requests.Select(r => r.ProductTypeId).ToList(),
                actual: createSurchargeRateResponse.Select(s => s.ProductTypeId).ToList()
            );

            Assert.Equal(
                expected: requests.Select(r => r.SurchareRates).ToList(),
                actual: createSurchargeRateResponse.Select(s => s.SurchareRates).ToList()
            );
        }
    }
}
