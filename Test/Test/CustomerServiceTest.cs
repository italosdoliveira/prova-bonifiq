using Castle.Core.Resource;
using Moq;
using ProvaPub.Models;
using ProvaPub.Repository.Interfaces;
using ProvaPub.Services;

namespace Test
{
    public class CustomerServiceTest
    {
        [Fact]
        public void CustomerExists_ShouldBeTrueIfCustomerExists()
        {
            var customerRepositoryMock = new Mock<ICustomerRepository>();
            var orderRepositoryMock = new Mock<IOrderRepository>();

            customerRepositoryMock
                .Setup(s => s.Find(1))
                .ReturnsAsync(() => new Customer
                {
                    Id = 1
                });

            var service = new CustomerService(customerRepositoryMock.Object, orderRepositoryMock.Object);

            var result = service.CustomerExists(1);

            Assert.True(result);
        }

        [Fact]
        public void CustomerExists_ShouldBeFalseIfCustomerDoesNotExists()
        {
            var customerRepositoryMock = new Mock<ICustomerRepository>();
            var orderRepositoryMock = new Mock<IOrderRepository>();

            customerRepositoryMock
                .Setup(s => s.Find(2))
                .ReturnsAsync(() => null);

            var service = new CustomerService(customerRepositoryMock.Object, orderRepositoryMock.Object);

            Assert.Throws<InvalidOperationException>(() => service.CustomerExists(2));
        }

        [Fact]
        public void HasOneOrMoreOrders_ShouldBeTrueIfCountGreaterThanZero()
        {
            var customerRepositoryMock = new Mock<ICustomerRepository>();
            var orderRepositoryMock = new Mock<IOrderRepository>();

            orderRepositoryMock
                .Setup(s => s.Count(1, new DateTime()))
                .ReturnsAsync(() => 1);

            var service = new CustomerService(customerRepositoryMock.Object, orderRepositoryMock.Object);

            var result = service.HasOneOrMoreOrders(1);

            Assert.True(result);
        }

        [Fact]
        public void HasOneOrMoreOrders_ShouldBeFalseIfCountEqualZero()
        {
            var customerRepositoryMock = new Mock<ICustomerRepository>();
            var orderRepositoryMock = new Mock<IOrderRepository>();

            orderRepositoryMock
                .Setup(s => s.Count(1, new DateTime()))
                .ReturnsAsync(() => 0);

            var service = new CustomerService(customerRepositoryMock.Object, orderRepositoryMock.Object);

            var result = service.HasOneOrMoreOrders(1);

            Assert.False(result);
        }

        [Fact]
        public void PurchaseValuesIsGreaterThanHundred_ShouldBeTrueIfHaveBoughtBeforeEqualZero()
        {
            var customerRepositoryMock = new Mock<ICustomerRepository>();
            var orderRepositoryMock = new Mock<IOrderRepository>();

            orderRepositoryMock
                .Setup(s => s.Count(1, new DateTime()))
                .ReturnsAsync(() => 0);

            var service = new CustomerService(customerRepositoryMock.Object, orderRepositoryMock.Object);

            var result = service.PurchaseValuesIsGreaterThanHundred(1, 101);

            Assert.True(result);
        }

        [Fact]
        public void PurchaseValuesIsGreaterThanHundred_ShouldBeTrueIfHaveBoughtBeforeGreaterThanZero()
        {
            var customerRepositoryMock = new Mock<ICustomerRepository>();
            var orderRepositoryMock = new Mock<IOrderRepository>();

            orderRepositoryMock
                .Setup(s => s.Count(1, new DateTime()))
                .ReturnsAsync(() => 1);

            var service = new CustomerService(customerRepositoryMock.Object, orderRepositoryMock.Object);

            var result = service.PurchaseValuesIsGreaterThanHundred(1, 100);

            Assert.True(result);
        }
    }
}