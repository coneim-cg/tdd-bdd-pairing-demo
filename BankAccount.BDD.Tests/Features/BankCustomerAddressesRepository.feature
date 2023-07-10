Feature: BankCustomerAddressesRepository
	In order to manage customer addresses in a bank
	As a developer
	I want to ensure the Address repository works correctly
	
Scenario: Adding a valid address
	Given I have a BankCustomerAddressesRepository
	And I have a valid address
	When I add the address to the repository
	Then the address should be in the repository
	
Scenario: Adding an invalid address
	Given I have a BankCustomerAddressesRepository
	And I have an invalid address
	When I try to add the address to the repository
	Then an exception should be thrown
	
Scenario: Updating a valid address
	Given I have a BankCustomerAddressesRepository
	And I have a valid address
	And I have added a valid address to the repository
	When I update the address in the repository
	Then the updated address should be in the repository
	
Scenario: Deleting an address
	Given I have a BankCustomerAddressesRepository
	And I have a valid address
	And I have added a valid address to the repository
	When I delete the address from the repository
	Then the address should not be in the repository