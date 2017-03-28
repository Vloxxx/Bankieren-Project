using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bank;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Tests
{
    [TestClass()]
    public class DataProviderTests
    {
        [TestMethod()]
        public void InloggenTest()
        {
            string gebruikersnaam = "stijn7621";
            string wachtwoord = "Test12345";
            DataProvider.Inloggen(gebruikersnaam, wachtwoord);
        }

        [TestMethod()]
        public void ValidateElfProefTest()
        {

            string bsn = "229557648";
            DataProvider.ValidateElfProef(bsn);
        }
    }
}