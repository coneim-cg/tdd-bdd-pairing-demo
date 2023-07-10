using Xunit;
using BankDemo;
using System;

namespace BankDemo.Unit.Tests
{
    public class BankCustomerAddressesRepositoryTests
    {
        [Fact]
        public void Test_Add_ValidAddress_Success()
        {
            var repository = new BankCustomerAddressesRepository();
            var address = new AddressInfo { Id = 1, Country = "Country1", City = "City1", ZipCode = "11111" };

            repository.Add(1, address);

            Assert.Equal(address, repository.GetCustomerAddressInfo(1));
        }

        [Fact]
        public void Test_Add_ExistingAddress_ThrowsException()
        {
            var repository = new BankCustomerAddressesRepository();
            var address = new AddressInfo { Id = 1, Country = "Country1", City = "City1", ZipCode = "11111" };
            repository.Add(1, address);

            Assert.Throws<Exception>(() => repository.Add(1, address));
        }

        [Fact]
        public void Test_Update_ValidAddress_Success()
        {
            var repository = new BankCustomerAddressesRepository();
            var address = new AddressInfo { Id = 1, Country = "Country1", City = "City1", ZipCode = "11111" };
            repository.Add(1, address);

            var updatedAddress = new AddressInfo { Id = 1, Country = "Country2", City = "City2", ZipCode = "22222" };
            repository.UpdateAddress(updatedAddress);

            var currentAddress = repository.GetCustomerAddressInfo(1);
            Assert.NotNull(currentAddress);
            Assert.Equal(updatedAddress.Country, currentAddress.Country);
            Assert.Equal(updatedAddress.City, currentAddress.City);
            Assert.Equal(updatedAddress.ZipCode, currentAddress.ZipCode);
        }

        [Fact]
        public void Test_Update_NonExistentAddress_ThrowsException()
        {
            var repository = new BankCustomerAddressesRepository();
            var address = new AddressInfo { Id = 1, Country = "Country1", City = "City1", ZipCode = "11111" };

            Assert.Throws<Exception>(() => repository.UpdateAddress(address));
        }

        [Fact]
        public void Test_Delete_ExistentAddress_Success()
        {
            var repository = new BankCustomerAddressesRepository();
            var address = new AddressInfo { Id = 1, Country = "Country1", City = "City1", ZipCode = "11111" };
            repository.Add(1, address);

            repository.DeleteAddress(1);

            Assert.Null(repository.GetCustomerAddressInfo(1));
        }

        [Fact]
        public void Test_Delete_NonExistentAddress_ThrowsException()
        {
            var repository = new BankCustomerAddressesRepository();

            Assert.Throws<Exception>(() => repository.DeleteAddress(1));
        }

        [Fact]
        public void Test_Add_InvalidAddress_Null_ThrowsException()
        {
            var repository = new BankCustomerAddressesRepository();
            Assert.Throws<ArgumentNullException>(() => repository.Add(1, null!));
        }

        [Fact]
        public void Test_Add_InvalidAddress_NoCountry_ThrowsException()
        {
            var repository = new BankCustomerAddressesRepository();
            var address = new AddressInfo { Id = 1, Country = "", City = "City1", ZipCode = "11111" };
            Assert.Throws<ArgumentException>(() => repository.Add(1, address));
        }
    }
}
