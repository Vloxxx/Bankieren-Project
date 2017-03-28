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
    public class BankrekeninghouderTests
    {
        private static List<Bankrekeninghouder> bankrekeninghouderslijst = Bankrekeninghouder.Bankrekeninghouderslijst;
        private decimal bedrag = 150;
        private decimal bedragVoorMethode = 0;
        

        [TestMethod()]
        public void OverboekenSpaarrekeningTest()
        {
            foreach (Bankrekeninghouder bankrekeninghouder in bankrekeninghouderslijst)
            {
                if (bankrekeninghouder.Betaalrekening.RekeningNr == "NL01 STUB 0000 0000 00")
                {
                    bedragVoorMethode = bankrekeninghouder.Spaarrekening.BankSaldo;
                    bankrekeninghouder.OverboekenSpaarrekening(bedrag);                   
                    Assert.AreEqual(bedragVoorMethode + bedrag, bankrekeninghouder.Spaarrekening.BankSaldo);
                }
            }
        }
        [TestMethod()]
        public void BestaandeBetalingverichtenTest()
        {
            foreach (Bankrekeninghouder bankrekeninghouder in bankrekeninghouderslijst)
            {
                if (bankrekeninghouder.Betaalrekening.RekeningNr == "NL01 STUB 0000 0000 00")
                {
                    bedragVoorMethode = bankrekeninghouder.Betaalrekening.BankSaldo;
                    bankrekeninghouder.Betalingverichten("NL03 STUB 0000 0000 00", bedrag);
                    Assert.AreEqual(bedragVoorMethode - bedrag , bankrekeninghouder.Betaalrekening.BankSaldo); 
                }
            }
        }

        [TestMethod()]
        public void NietBestaandeBetalingverichtenTest()
        {
            foreach (Bankrekeninghouder bankrekeninghouder in bankrekeninghouderslijst)
            {
                if (bankrekeninghouder.Betaalrekening.RekeningNr == "NL01 STUB 0000 0000 00")
                {
                    bankrekeninghouder.Betalingverichten("NL04 STUB 0000 0000 00", bedrag);
                }
            }
        }

        [TestMethod()]
        public void OverboekenBetaalrekeningTest()
        {
            foreach (Bankrekeninghouder bankrekeninghouder in bankrekeninghouderslijst)
            {
                if (bankrekeninghouder.Betaalrekening.RekeningNr == "NL01 STUB 0000 0000 00")
                {
                    bedragVoorMethode = bankrekeninghouder.Betaalrekening.BankSaldo;
                    bankrekeninghouder.OverboekenBetaalrekening(bedrag);
                    Assert.AreEqual(bedragVoorMethode + bedrag , bankrekeninghouder.Betaalrekening.BankSaldo);
                }
            }
        }    

    }
}