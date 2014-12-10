using DellTddBanking;
using NUnit.Framework;

namespace Banking.Tests.UnitTests
{
    [TestFixture]
    public class CheckingAccountTest
    {
        [Test]
        public void NewAccountShouldHaveABalanceOfZero()
        {
            //Arrange
            var account = new CheckingAccount();

            //Act
            var balance = account.CalculateBalance();

            //Assert
            Assert.That(balance == 0m);
        }

        [Test]
        public void AddingATransactionShouldAlterTheBalanceByTheAmount()
        {
            //Arrange
            var account = new CheckingAccount();

            //Act
            account.AddTransaction(new Transaction(100));
            var balance = account.CalculateBalance();

            //Assert
            Assert.That(balance == 100m);
        }

        [Test]
        public void ShouldBeAbleToDisplayAllTransactions()
        {
            //Arrange
            var account = new CheckingAccount();

            //Act
            account.AddTransaction(new Transaction(100));
            account.AddTransaction(new Transaction(100));

            var transCount = account.GetTransactions().Count;
            //Assert
            Assert.That(transCount == 2);
        }
    }
}