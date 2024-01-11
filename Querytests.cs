using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task20_consumewebapioftask11_.Controllers;
using Task20_consumewebapioftask11_.Models;

namespace xunit_tas11_
{

    public class Querytests
    {
        private ProductDbContext GetContextData()
        {
            var options = new DbContextOptionsBuilder<ProductDbContext>()
                      .UseInMemoryDatabase(Guid.NewGuid().ToString())
                      .Options;
            var context = new ProductDbContext(options);
            var Producttest = new Product { Id = 1, ProductName = "tv", Quantity = 1 };
            new Product { Id = 2, ProductName = "ac", Quantity = 5 };
            new Product { Id = 3, ProductName = "iphone", Quantity = 2 };

            var Gendertest = new Gender { Id = 1, GenderName = "Male" };
            new Gender { Id = 2, GenderName = "Female" };
            context.Product.Add(Producttest);
            context.Gender.Add(Gendertest);

             context.Customer.Add(new Customer{ Id = 5,Name = "shelsi", Email="shels@outlook.com",Phone="7995158450",Address="hyd",Product= Producttest ,Gender=Gendertest});
             context.Customer.Add(new Customer { Id = 6, Name = "shelsi", Email = "shels@outlook.com", Phone = "7995158450", Address = "hyd", Product = Producttest, Gender = Gendertest });
             context.Customer.Add(new Customer { Id = 7, Name = "shelsi", Email = "shels@outlook.com", Phone = "7995158450", Address = "hyd", Product = Producttest, Gender = Gendertest });
             context.SaveChanges();
            return context;

        }
        [Fact]
        public async void GetCustomerList()
        {
            using (var context = GetContextData())
            {
                CustomerController customerController = new CustomerController(context);
                var result = customerController.CustomerLists();

                //Assert
                Assert.NotNull(result);
                
            }
        }
        [Fact]
        public async Task CreateCustomerList()
        {
            using (var context = GetContextData())
            {
                CustomerController customerController=new CustomerController(context);
                //var customerDto = new CustomerDto();
                //var result = customerController.Create(customerDto);
                //var model = result.CustomerDto as FrontPageModel;

                CustomerDto customer = new CustomerDto() { Name = "shelsi", Email = "shels@outlook.com", Phone = "7995158450", Address = "hyd", ProductId=1,GenderId=1  };
                
                var result = await customerController.Create(customer);
                //Assert
                var okresult = Assert.IsType<OkObjectResult>(result);
                var createdCustomer = Assert.IsType<Customer>(okresult.Value);
                Assert.Equal("shelsi", createdCustomer.Name);
                Assert.Equal("shels@outlook.com", createdCustomer.Email);
                Assert.Equal(8, createdCustomer.Id);
                Assert.NotNull(okresult);
                //Assert.Equal(4, Pro.Id);
                //Assert.Equal("car", Pro.Name);
                //Assert.Equal(1000000, Pro.Price);
                //Assert.Equal(1, Pro.Quantity);
            }
        }
        [Fact]
        public async Task UpdateCustomerList()
        {
            using (var context = GetContextData())
            {
                CustomerController customerController = new CustomerController(context);
                var Id = 5;
                var updatedProduct = new CustomerDto { Id=5, Name = "divya", Email = "divya@outlook.com", Phone = "7995158450", Address = "vizag", ProductId = 1, GenderId = 1 };


                // Act
                var result = await customerController.Edit(Id, updatedProduct);
                var okresult = Assert.IsType<OkObjectResult>(result);
                Assert.Equal(200, okresult.StatusCode);
                Assert.NotNull(okresult);
                Assert.Equal(5, updatedProduct.Id);
                
            }
        }
        [Fact]
        public async Task DeleteCustomerList()
        {
            using (var context = GetContextData())
            {
                CustomerController customerController=new CustomerController(context);
                var Id = 5;
                var result=await customerController.Delete(Id);
                var okresult = Assert.IsType<NoContentResult>(result);
                Assert.Equal(204, okresult.StatusCode);
                Assert.Equal(5, Id);
                
            }
        }
       

    }

}
