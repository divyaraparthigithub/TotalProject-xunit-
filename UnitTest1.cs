//using Castle.Core.Configuration;
//using Microsoft.AspNetCore.Mvc;
//using Moq;
//using NPOI.SS.Formula.Functions;
//using Task20_consumewebapioftask11_.Controllers;
//using Task20_consumewebapioftask11_.Models;
//using Task20_consumewebapioftask11_.ServiceLayer;

//namespace xunit_tas11_
//{
//    public class UnitTest1
//    {
//        private readonly Mock<ICustomerService> _customerServiceMock;
//        private readonly Mock<ProductDbContext> _productdb;
//        private readonly Mock<IConfiguration> configuration;

//        //private readonly Mock<CustomerController> customercontroller;
//        //private readonly CustomerController _controller;
//        private object? productResult;

//        public UnitTest1()
//        {
//            _customerServiceMock=new Mock<ICustomerService>();
//            _productdb=new Mock<ProductDbContext>();
//            configuration = new Mock<IConfiguration>();
//            //customercontroller =new Mock<CustomerController>();

//        }
//        [Fact]
//        public void Test1()
//        {
           
//            //arrange
//            var customerlist = CustomerData();
//            _customerServiceMock.Setup(x=>x.GetProductList());
//            var custcontroller = new CustomerController(_customerServiceMock,  _productdb, configuration);
//            //act
//            var customerresult = custcontroller.ProductList();
            
//            //assert
//            Assert.NotNull(customerresult);
//            Assert.Equal(CustomerData().Count(), customerresult.Count());
//            Assert.True(customerlist.Equals(productResult));


//        }

//        private List<Customer> CustomerData()
//        {
//            List<Customer> productsData = new List<Customer>
//        {
//            new Customer
//            {
//                Id = 1,
//                Name = "divya",
//                Address ="vizag",
//                Phone= "1234567890"
               
//            },
            
//        };
//            return productsData;
//        }
//    }
//}