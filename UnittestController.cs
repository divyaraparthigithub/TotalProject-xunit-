//using Moq;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Task20_consumewebapioftask11_.ServiceLayer;
//using Task20_consumewebapioftask11_.Controllers;
//using Task20_consumewebapioftask11_.Models;
//using Task20_consumewebapioftask11_.ServiceLayer;
//using Castle.Core.Configuration;
//using System.Reflection.Metadata.Ecma335;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using System.Linq.Expressions;
//using NPOI.SS.Formula.Functions;
//using System.Reflection;
//using Microsoft.VisualStudio.TestPlatform.ObjectModel;
//using Microsoft.AspNetCore.Http.HttpResults;
//using EntityFrameworkCoreMock;

//namespace xunit_tas11_
//{
//    public  class UnittestController
//    {
//        private readonly Mock<ICustomerService> customerService;
//        private readonly Mock<ProductDbContext> productdb;
//        private readonly Mock<CustomerController> customerController;
//       // private readonly Mock<IConfiguration> configuration;
//        public UnittestController()
//        {
//            customerService=new Mock<ICustomerService>();
//            productdb=new Mock<ProductDbContext>();
//            customerController=new Mock<CustomerController>();
//        }
//        //[Fact]
//        //public void GetProductListTest()
//        //{
//        //    var customercontroller = new CustomerController(customerService.Object, productdb.Object);
//        //    //act
//        //    var productResult = customercontroller.ProductList();
//        //    //assert
//        //Assert.NotNull(productResult);
//        //var customerServiceMock = new Mock<ICustomerService>();
//        //var productDbContextMock = new Mock<ProductDbContext>();
//        //var controller = new CustomerController(customerServiceMock.Object, productDbContextMock.Object);
//        //arrange
//        //var productList = GetProductData();
//        //customerService.Setup(x => x.ProductList()).Returns(productList);
//        //var result = customerService.Object;
//        //var productresult=
//        //var customercontroller = new CustomerController(customerService.Object, productdb.Object);
//        ////act
//        ////var productresult=customercontroller.GetProductList();
//        //////assert
//        ////Assert.NotNull(productresult);
//        ////Assert.Equal(GetProductData().Count().productresult.Count());
//        //var products = new List<Product> { new Product { Id = 1, ProductName = "Product1" } };
//        //customerService.Setup(service => service.ProductList()).Returns(products);

//        //// Act
//        //var result = customercontroller.ProductList();

//        //// Assert
//        //var okResult = Assert.IsType<OkObjectResult>(result);



//        //}
//        //[Fact]
//        //public void GetProductListTest()
//        //{
//        //    // Arrange
//        //    var customerServiceMock = new Mock<ICustomerService>();
//        //    var productDbContextMock = new Mock<ProductDbContext>();
//        //    var controller = new CustomerController(customerServiceMock.Object, productDbContextMock.Object);

//        //    // Act
//        //    var result = controller.GetProductList();

//        //    // Assert
//        //    var okResult = Assert.IsType<OkObjectResult>(result);
//        //    var model = Assert.IsAssignableFrom<IEnumerable<Product>>(okResult.Value);

//        //}
//        //private DbContextMock<ProductDbContext> getDbContext(Product[] initialEntities)
//        //{
//        //    var dbContextOptions = new DbContextOptionsBuilder<ProductDbContext>()
//        //        .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
//        //        .Options;

//        //    DbContextMock<ProductDbContext> dbContextMock = new DbContextMock<ProductDbContext>(dbContextOptions);
//        //    dbContextMock.CreateDbSetMock(x => x.Set<Product>(), initialEntities);
//        //    return dbContextMock;
//        //}
//        private DbContextMock<ProductDbContext> getDbContext(Product[] initialEntities)
//        {
//            var dbContextOptions = new DbContextOptionsBuilder<ProductDbContext>()
//                .UseInMemoryDatabase(databaseName: "Customerdatabase")
//                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
//                .Options;
//            DbContextMock<ProductDbContext> dbContextMocks = new DbContextMock<ProductDbContext>(dbContextOptions);
//            dbContextMocks.CreateDbSetMock(x => x.Set<Product>(), initialEntities);
//            return dbContextMocks;
//        }
       

//        private CustomerController CustomerControllerInit(Mock<ICustomerService> customerService,DbContextMock<ProductDbContext> dbContextMock)
//        {
//            return new CustomerController(customerService.Object, dbContextMock.Object);
//        }
//        //private Customer[] getInitialDbEntities()
//        //{
//        //    return new Customer[]
//        //    {
//        //        new Customer {Id=1,Name="divya", Phone="1234567890",Email="divya@gmail.com",ProductId=1,GenderId=1,Address="vizag" },
//        //        new Customer {Id=2,Name="uday", Phone="1234567890",Email="divya@gmail.com",ProductId=1,GenderId=1,Address="vizag" },
//        //        new Customer {Id=3,Name="divya", Phone="1234567890",Email="divya@gmail.com",ProductId=1,GenderId=1,Address="vizag" }

//        //    };
//        //}

//        private Product[] getInitialDbEntities()
//        {
//            return new Product[]
//             {
//                new Product {Id = 1, ProductName="tv", Quantity=2},
//                new Product {Id = 2, ProductName = "ac", Quantity=2},
//                new Product {Id = 3, ProductName = "iphone", Quantity=7},
//            };
//        }

//        [Fact]
//        public void GetProductDetailTest()
//        {
//            // var customerservice=new Mock<ICustomerService>();
//            //customerService.Setup(x => x.ProductList());
//            //var mockedDbContext = Create.MockedDbContextFor<ProductDbContext>();
//            DbContextMock<ProductDbContext> dbContextMock = getDbContext(getInitialDbEntities());
//            CustomerController custController = CustomerControllerInit(customerService,dbContextMock);
//            //var customercontroller =  new CustomerController(customerService.Object, dbContextMock.Object);

//            var result = custController.ProductList();
//            var resultType = result as OkObjectResult;
//            Assert.NotNull(result);
           
//        }
//        [Fact]
//        public async Task Creatcustomer()
//        {
//            DbContextMock<ProductDbContext> dbContextMock = getDbContext(getInitialDbEntities());
//            CustomerController custController = CustomerControllerInit(customerService, dbContextMock);
//            var customerDto = new CustomerDto()
//            {
//                Name = "lalitha",
//                Address = "anakapalli",
//                Phone = "1234567890",
//                Email = "lalli@gmail.com",
//                ProductId=1,
//                GenderId=2

//            };
//            var response = custController.Create(customerDto);
//            var result = response.Result as CreatedAtActionResult;

//            Assert.NotNull(result);
//            Assert.Equal(201, result.StatusCode);
//           // Assert.IsType<CreatedAtActionResult>(result);


//           // Customer

//        }
//        //[Fact]
//        //public void UpdateCustomerTests()
//        //{
//        //    DbContextMock<ProductDbContext> dbContextMock = getDbContext(getInitialDbEntities());
//        //    CustomerController custController = CustomerControllerInit(customerService, dbContextMock);
//        //    CustomerDto updates = getInitialDbEntities()[1];
//        //    updates.Name = "hellodivya";
//        //    int id = 3;
//        //    //act
//        //    var result = custController.Edit(id, updates);
//        //    Customer updateditem = dbContextMock.Object.Customer.Find(id);

//        //    Assert.True(updateditem !=null);


//        //}
//        [Fact]
//        public void DeleteCustomer()
//        {
//            //arrange
//            DbContextMock<ProductDbContext> dbContextMock = getDbContext(getInitialDbEntities());
//            CustomerController custController = CustomerControllerInit(customerService, dbContextMock);
//            int id = 2;

//            //act
//            var result = custController.Delete(id).Result;

//            //assert
//            Assert.IsType<NoContentResult>(result);
//            Assert.Null(dbContextMock.Object.Customer.Find(id));
//        }
//        //public List<Product> GetProductData()
//        //{
//        //    List<Product> products = new List<Product>
//        //    {
//        //        new Product
//        //        {
//        //            Id=1,
//        //            ProductName="tv"



//        //        },
//        //    };
//        //    return products;



//        //}

//    }

    
//}
