using BankDemo;
using System;
using TechTalk.SpecFlow;

namespace BankAccount.BDD.Tests.StepDefinitions
{
    [Binding]
    public class BankCustomerAddressesRepositorySteps
    {
        private BankCustomerAddressesRepository? _repository;
        private AddressInfo? _address;

        [Given(@"I have a BankCustomerAddressesRepository")]
        public void GivenIHaveABankCustomerAddressesRepository()
        {
            _repository = new BankCustomerAddressesRepository();
        }

        [Given(@"I have a valid address")]
        public void GivenIHaveAValidAddress()
        {
            _address = new AddressInfo { Id = 1, Country = "Country1", City = "City1", ZipCode = "11111" };
        }

        [Given(@"I have an invalid address")]
        public void GivenIHaveAnInvalidAddress()
        {
            _address = new AddressInfo { Id = 1, Country = "", City = "", ZipCode = "" };
        }

        [Given(@"I have added a valid address to the repository")]
        public void GivenIHaveAddedAValidAddressToTheRepository()
        {
            _repository?.Add(1, _address!);
        }

        [When(@"I add the address to the repository")]
        public void WhenIAddTheAddressToTheRepository()
        {
            _repository?.Add(1, _address!);
        }

        [When(@"I try to add the address to the repository")]
        public void WhenITryToAddTheAddressToTheRepository()
        {
            try
            {
                _repository?.Add(1, _address!);
            }
            catch
            {
                // Swallow exception for now. We will check this in Then step.
            }
        }

        [When(@"I update the address in the repository")]
        public void WhenIUpdateTheAddressInTheRepository()
        {
            _address!.City = "UpdatedCity";
            _repository!.UpdateAddress(_address);
        }

        [When(@"I delete the address from the repository")]
        public void WhenIDeleteTheAddressFromTheRepository()
        {
            _repository!.DeleteAddress(1);
        }

        [Then(@"the address should be in the repository")]
        public void ThenTheAddressShouldBeInTheRepository()
        {
            Assert.Equal(_address, _repository?.GetCustomerAddressInfo(1));
        }

        [Then(@"an exception should be thrown")]
        public void ThenAnExceptionShouldBeThrown()
        {
            Assert.Throws<ArgumentException>(() => _repository?.Add(1, _address!));
        }

        [Then(@"the updated address should be in the repository")]
        public void ThenTheUpdatedAddressShouldBeInTheRepository()
        {
            Assert.Equal(_address!.City, _repository?.GetCustomerAddressInfo(1)?.City);
        }

        [Then(@"the address should not be in the repository")]
        public void ThenTheAddressShouldNotBeInTheRepository()
        {
            Assert.Null(_repository?.GetCustomerAddressInfo(1));
        }
    }
}
