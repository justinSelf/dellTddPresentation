Feature: LinkedSavingsAccount
	In order to avoid overdrawing my account
	When I add a transaction that overdraws my checking account
	I want the overdrawn amount o be transferred from the linked savings account

@mytag
Scenario: Overdrawing the checking account with a linked account 
	Given I am a customer 
	And I have a checking account with a balance of 25
	And I have a savings account with a balance of 100
	When I withdraw 30 dollars from my checking account
	Then my savings account balance should be 94
	And my checking account balance should be 1