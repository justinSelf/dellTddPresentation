using System;
using DellTddBanking2.Bus;
using DellTddBanking2.Commands;
using DellTddBanking2.Domain;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Banking.Tests
{
    [Binding]
    public class LinkedSavingsAccountSteps
    {
        private Customer customer;
        private Bus bus;

        [Given(@"I am a customer")]
        public void GivenIAmACustomer()
        {
            customer = new Customer();
            bus = new Bus();
        }

        [Given(@"I have a checking account with a balance of (.*)")]
        public void GivenIHaveACheckingAccountWithABalanceOf(int amount)
        {
            customer.CheckingAccount = new CheckingAccount();
            customer.CheckingAccount.AddTransaction(new Transaction(amount));
        }

        [Given(@"I have a savings account with a balance of (.*)")]
        public void GivenIHaveASavingsAccountWithABalanceOf(int amount)
        {
            customer.SavingsAccount = new SavingsAccount();
            customer.SavingsAccount.AddTransaction(new Transaction(amount));
        }

        [When(@"I withdraw (.*) dollars from my checking account")]
        public void WhenIWithdrawDollarsFromMyCheckingAccount(int amount)
        {
            bus.Send(new AddTransaction
            {
                Account = customer.CheckingAccount,
                Customer = customer,
                Transaction = new Transaction(amount * -1)
            });
        }
        [Then(@"my savings account balance should be (.*)")]
        public void ThenMySavingsAccountBalanceShouldBe(int amount)
        {
            Assert.AreEqual(amount, customer.SavingsAccount.CalculateBalance());
        }

        [Then(@"my checking account balance should be (.*)")]
        public void ThenMyCheckingAccountBalanceShouldBe(int amount)
        {
            Assert.AreEqual(amount, customer.CheckingAccount.CalculateBalance());
        }

    }
}
