# Coolblue Assignment 
The work you will do as a part of this assignment is to implement the user stories specified below. It should give you a good understanding of what it is like to work with Coolblue, and it should give us a better understanding of your skills. So, good for you, and good for us! 

You have one whole week (including the weekend) to hand your solution back in but please plan your days to give yourself enough time for the assignment. It’s not a requirement to finish all stories at all costs but whatever you do manage to complete should be done to the standards we expect.

# Our technical values at Coolblue:
1. We value team communication so we document our design/architecture choices
2. We have a strong culture of Test Driven Development, before we write production code we prefer to write tests first
3. We like to know what our applications and services are doing in production without necessarily having to debug code or without needing the customer to tell us something is wrong so we proactively monitor them and invest in logging.
4. We value SOLID principles and are pragmatic around applying them to the systems we build
5. We ensure our applications and systems are self-healing and resilient in face of failures

# What we expect in your solution:
- Behavioural tests
  - [Different unit tests](https://github.com/marwa-ahmad/CoolBlue.Insurance/tree/master/tests/Insurance.Tests) for [Order Insurance](https://github.com/marwa-ahmad/CoolBlue.Insurance/blob/master/tests/Insurance.Tests/Controllers/OrderInsuranceControllerUnitTest.cs), [Product Insurance](https://github.com/marwa-ahmad/CoolBlue.Insurance/blob/master/tests/Insurance.Tests/Controllers/ProductInsuranceControllerUnitTest.cs) and [Product Type SurchargeRates](https://github.com/marwa-ahmad/CoolBlue.Insurance/blob/master/tests/Insurance.Tests/Controllers/SurchargeRateControllerUnitTest.cs)
  - Having DI in while doing unit testing via [ClassFixture](https://github.com/marwa-ahmad/CoolBlue.Insurance/blob/master/tests/Insurance.Tests/Setup/SetupTestFixture.cs)
  - Injecting TestData via [Theory and MemberData](https://github.com/marwa-ahmad/CoolBlue.Insurance/tree/master/tests/Insurance.Tests/TestData)
  - [Mocking behaviours of external endpoints while doing the unit tests](https://github.com/marwa-ahmad/CoolBlue.Insurance/tree/master/tests/Insurance.Tests/Mock); which the DI and interface segregation helped here.
  
- Appropriate separation of concerns
  - [Separation of Concerns by having layers as shown in code and in diagrams down below](https://github.com/marwa-ahmad/CoolBlue.Insurance/tree/master/src)

- A solution with an architecture that you can defend and would feel comfortable putting in production.
  -  Please find diagrams down below
  
- Readable code with meaningful names for variables/classes/interfaces etc.
  -  Please find diagrams down below
  
- Appropriate exception handling and fault tolerance
  - [Global Exception Handling via ExceptionFilter handles both custom thrown exceptions and general exceptions](https://github.com/marwa-ahmad/CoolBlue.Insurance/blob/master/src/Insurance.Api/Filters/ApiExceptionFilter.cs)
  - [Logger component using serilog](https://github.com/marwa-ahmad/CoolBlue.Insurance/tree/master/src/Insurance.Common/Logs)

- Should be runnable on our machines so keep that in mind while picking third party tools and apps etc.
  - [Usage section on running the Unit and Project](https://github.com/marwa-ahmad/CoolBlue.Insurance#usage)
  
- Documentation of your design decisions and technical choices for the tasks. A simple markdown or text file (included in your submission) showing the following will be enough: 
   - **Assumption/Decision Made**
   - **Reason**

  - For separation of concerns and applying SOLID, a Domain layer is created which contains the Models and DTO (Data Transfer Objects).
Plus The below components show in the diagram.
  ![alt General Layout](https://i.ibb.co/PMK9QK1/General-Layout.png)
   
# Your colleagues
We are, of course, not going to let you deal with the assignment on your own. You will have two software developers available via email if you have any questions and their contact details are below. We will respond within 4 working hours, at the most. Please make sure you send us your questions before/after the weekend, as we don’t work on the weekends.

Ashish Vegaraju; a.vegaraju@coolblue.nl

Huibert-Jan Nieuwkamer; h.nieuwkamer@coolblue.nl

# User Story:
At Coolblue, we want to be able to insure the products that we sell to a customer, so that we get money back in case the product gets lost or damaged before reaching the customers. For that, we need a REST API that is going to be used by Coolblue webshop. You're going to get access to our Product Information API:

1. Unzip it onto your machine
2. Navigate to the unzipped folder in a terminal
3. On the terminal, type dotnet ProductData.Api.dll and hit Enter.


The Products API is Swagger enabled, and you can access it by navigating to http://localhost:5002/ in your browser. In the example the port is 5002.

## Functionality already implemented here:
There is an existing endpoint that, given the information about the product, calculates the total cost of insurance according to the rules below:
  - If the product sales price is less than € 500, no insurance required
  - If the product sales price=> € 500 but < € 2000, insurance cost is € 1000
  - If the product sales price=> € 2000, insurance cost is €2000
  - If the type of the product is a smartphone or a laptop, add € 500 more to the insurance cost.
* Download the current code, so you can continue with the further tasks.

## Task 1 [BUGFIX]:
The financial manager reported that when customers buy a laptop that costs less than € 500, insurance is not calculated, while it should be € 500.
[Bug fix in code](https://github.com/marwa-ahmad/CoolBlue.Insurance/blob/master/src/Insurance.Operations/Product/ExtraInsuranceOperation.cs)
[Test case](https://github.com/marwa-ahmad/CoolBlue.Insurance/blob/30bcd5455e4089a8d737b3f55d3265a3e558b2c8/tests/Insurance.Tests/Controllers/ProductInsuranceControllerUnitTest.cs#L37)


## Task 2 [REFACTORING]:
It looks like the already implemented functionality has some quality issues. Refactor that code, but be sure to maintain the same behavior. 

* Please make sure to include in the documentation about the approach that you chose for the refactoring.

![alt ServiceLayer](https://i.ibb.co/Dptst3f/Service-Layer.png)

![alt ManagerLayer](https://i.ibb.co/1mjMGzw/Manager-Layer.png)

![al OpearationLayer](https://i.ibb.co/MB7PJzG/Operation-Layer.png)


## Task 3 [FEATURE 1]:
Now we want to calculate the insurance cost for an order and for this, we are going to provide all the products that are in a shopping cart.

* While developing this feature, please document your assumptions and feel free to reach the stakeholders for doubts via email.

[Diagrams are shown above here](https://github.com/marwa-ahmad/CoolBlue.Insurance#task-2-refactoring)

## Task 4 [FEATURE 2]:
We want to change the logic around the insurance calculation. We received a report from our business analysts that digital cameras are getting lost more than usual. Therefore, if an order has one or more digital cameras, add € 500 to the insured value of the order.

* While developing this feature, please document your assumptions and feel free to reach the stakeholders for doubts via email.

![alt OrderAPI](https://i.ibb.co/TYxLxvD/OrderAPI.png)

## Task 5 [FEATURE 3]:
As a part of this story we need to provide the administrators/back office staff with a new endpoint that will allow them to upload surcharge rates per product type. This surcharge will then  need to be added to the overall insurance value for the product type.

Please be aware that this endpoint is going to be used simultaneously by multiple users
* While developing this feature, please document your assumptions and feel free to reach out to the stakeholders for doubts via email.

  - All APIs are asynchrouns and a [concurrent data structure was used for storing the product types and their surcharge rates](https://github.com/marwa-ahmad/CoolBlue.Insurance/blob/master/src/Insurance.Repository/SurchargeRateRepository.cs)
  - [Surchare Rate API in code](https://github.com/marwa-ahmad/CoolBlue.Insurance/blob/master/src/Insurance.Api/Controllers/SurchargeRateController.cs)
  

# Solution
## Usage

1. Clone the solution locally.
2. Run the all unit tests inside the Insurance.Tests project; it should run successfully.
P.S: You will see that a logs folder is created inside the test project
![alt](https://i.ibb.co/jbRGbjn/logs-Tests.png)

3. Run the Insurance.API project; you will see a Swagger UI which lists 3 endpoints
![alt Swagger](https://i.ibb.co/wdx3mQS/Swagger-Integration.png)

4. Logs folder exists inside the src folder.
![alt Logs](https://i.ibb.co/d6nmwbP/logs-folder.png)

5. Make API call through Postman for Product Insurance API similar to:
![alt ProductInsuranceAPI](https://i.ibb.co/8zwBvZy/Product-API.png)

6. Make API call through Postman for Order Insurance API similar to:
![alt OrderAPI](https://i.ibb.co/TYxLxvD/OrderAPI.png)

7. Make API call through Postman for Assigning Surcharge rates to a product type, API similar to:

Assumptions:
- Surcharge rate is a percentage from the sales price of the product and it's added on the total insurance value
- If a product is not insured then no surcharge rate will be applied; since the surcharge rate should be added to the insurance value

![alt SurchargeRateAPI](https://i.ibb.co/Yprjr6C/Surcharge-Rate.png)

8. Make API call to Order insurance or Product isnurance to see the the applied surchage rate to your product type
