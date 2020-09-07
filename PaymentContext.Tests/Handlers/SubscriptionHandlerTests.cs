using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Handlers;
using PaymentContext.Domain.ValueObjects;
using PaymentContext.Tests.Mocks;

namespace PaymentContext.Tests
{
    [TestClass]
    public class SubscriptionHandlerTests
    {
        [TestMethod]
        public void ShouldNotReturnErrorWhenDocumentExists()
        {
            var handler = new SubscriptionHandler(new FakeStudentRepository(), new FakeEmailService());
            var command = new CreateBoletoSubscriptionCommand();

            command.BarCode = "12345678";
            command.FirstName = "Leonardo";
            command.LastName = "Martins";
            command.Document = "99999999999";
            command.Email = "hello@balta.io2";
            command.BarCode = "12345678";
            command.BoletoNumber = "12331";
            command.PaymentNumber = "123141";
            command.PaidDate = DateTime.Now;
            command.ExpireDate = DateTime.Now.AddMonths(1);
            command.Total = 60;
            command.TotalPaid = 60;
            command.Payer = "Leonardo";
            command.PayerDocument = "1234567891011";
            command.PayerDocumentType = EDocumentType.CPF;
            command.PayerEmail = "hello@balta.io2";
            command.Street = "Rua teste";
            command.Number = "123";
            command.Neighborhood = "abc";
            command.City = "Americana";
            command.State = "Sao Paulo";
            command.Country = "Brasil";
            command.ZipCode = "1247658";

            handler.Handle(command);
            Assert.AreEqual(false, handler.Valid);
        }
    }

}