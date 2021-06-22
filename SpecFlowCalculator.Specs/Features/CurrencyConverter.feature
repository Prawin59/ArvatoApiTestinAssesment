Feature: CurrencyConverter
	

@ConvertFromEURToNINR
Scenario: Convertfrom EUR to INR
	Given the amount is 50	
	Given Convert from currency is EUR
	Given to Currency is INR
	When the amount is convertd
	Then the result in INR is 4419.684

@ConvertFromNOKToINR
Scenario: Convertfrom EUR to NOK
	Given the amount is 100	
	Given Convert from currency is EUR
	Given to Currency is NOK
	When the amount is convertd
	Then the result in INR is 1023.302