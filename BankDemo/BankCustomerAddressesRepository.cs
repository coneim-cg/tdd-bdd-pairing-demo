using System;
using System.Collections.Generic;
using System.Linq;

namespace BankDemo
{
    public class BankCustomerAddressesRepository
    {
        private readonly Dictionary<int, AddressInfo> _map;

        public BankCustomerAddressesRepository()
        {
            _map = new Dictionary<int, AddressInfo>();
        }

        public AddressInfo? GetCustomerAddressInfo(int customerId)
        {
            return _map.TryGetValue(customerId, out AddressInfo? result)
                ? result
                : null;
        }

        public IEnumerator<AddressInfo> GetAddresses()
        {
            return _map.Values.GetEnumerator();
        }

        public void Add(int customerId, AddressInfo address)
        {
            ValidateAddress(address);

            if (GetCustomerAddressInfo(customerId) != null)
                throw new Exception($"Address already exists for the customer {customerId}");

            _map.Add(customerId, address);
        }

        public void UpdateAddress(AddressInfo address)
        {
            ValidateAddress(address);

            var currentAddress = GetCustomerAddressInfo(address.Id);
            if (currentAddress == null)
                throw new Exception($"Address is not found with id={address.Id}");

            currentAddress.City = address.City;
            currentAddress.Country = address.Country;
            currentAddress.StreetName = address.StreetName;
            currentAddress.StreetNumber = address.StreetNumber;
            currentAddress.ZipCode = address.ZipCode;
        }

        public void DeleteAddress(int addressId)
        {
            var currentAddress = GetCustomerAddressInfo(addressId);
            if (currentAddress == null)
                throw new Exception($"Address is not found with id={addressId}");

            foreach (var (customerId, addressInfo) in _map)
            {
                if (addressInfo.Id == addressId)
                {
                    _map.Remove(customerId);
                    return;
                }
            }
        }

        private void ValidateAddress(AddressInfo addressInfo)
        {
            if (addressInfo == null)
                throw new ArgumentNullException(nameof(addressInfo));

            if (string.IsNullOrWhiteSpace(addressInfo.Country))
                throw new ArgumentException("Country can not be empty");
            if (string.IsNullOrWhiteSpace(addressInfo.City))
                throw new ArgumentException("City can not be empty");
            if (string.IsNullOrWhiteSpace(addressInfo.ZipCode))
                throw new ArgumentException("ZipCode can not be empty");
        }
    }
}
