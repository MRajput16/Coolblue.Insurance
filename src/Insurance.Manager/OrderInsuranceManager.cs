using Insurance.Common;
using Insurance.Domain;
using Insurance.Operations;
using Newtonsoft.Json;
using System;

namespace Insurance.Manager
{
    /// <summary>
    /// concrete implementation of IOrderInsuranceManager
    /// </summary>
    public class OrderInsuranceManager: IOrderInsuranceManager
    {
        private readonly IOrderBasicOperation _orderBasicOperation;
        private readonly ICameraOrderInsuranceOperation _cameraOrderInsuranceOperation;
        private readonly ILogger _logger;

        public OrderInsuranceManager(ICameraOrderInsuranceOperation cameraInsuranceOperation, IOrderBasicOperation orderBasicOperation, ILogger logger)
        {
            _cameraOrderInsuranceOperation = cameraInsuranceOperation;
            _orderBasicOperation = orderBasicOperation;
            _logger = logger;
        }

        /// <summary>
        /// Calculates total order's insurance value based on its product type's insurance and if it contains more than one camera
        /// </summary>
        /// <param name="order"></param>
        /// <returns>total order's insurance value</returns>
        public float CalculateInsurance(Order order)
        {
            var basicOrderInsuranceValue = _orderBasicOperation.Calculate(order);

            var camerasInsuranceValue = _cameraOrderInsuranceOperation.Calculate(order);
            
            var serializedObject = JsonConvert.SerializeObject(order);

            _logger.LogInformation($"Order initial insurance value [{basicOrderInsuranceValue}]. " +
                $"Order cameras insurance value {camerasInsuranceValue}{Environment.NewLine}" 
                + $" order json object: [{serializedObject}]");

            return basicOrderInsuranceValue + camerasInsuranceValue;
        }
    }
}
