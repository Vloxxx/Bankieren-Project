using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bank
{
    public class Betaalrekening : Rekening
    {
        #region Fields
        // -- Fields --

        private decimal maximaalKrediet;
        private string rekeningNrBetalen;
        private decimal bankSaldo;
        #endregion

        #region Properties
        // -- Properties --

        public override decimal BankSaldo
        {
            get { return bankSaldo; }
        }
        // Checken of het ingevoerde bedrag niet hoger is dan je banksaldo of hoger gaat dan het max kredit
        public override decimal Afschrijven
        {
            set { if (bankSaldo - value >= maximaalKrediet)
                {
                    bankSaldo -= value;
                }
                else
                {
                    throw new Exception("Het saldo mag niet lager zijn dan het huidige krediet");
                }
            }
        }

        public override decimal Bijschrijven
        {
            set { bankSaldo += value; }
        }

        public decimal MaximaalKrediet
        {
            get { return maximaalKrediet; }
        }

        public override string RekeningNr
        {
            get { return rekeningNrBetalen; }
        }
        #endregion

        #region Constructor
        // -- Constructor --

        // Een nieuwe betaalrekening maken met je ingevoerde parameters
        public Betaalrekening(decimal maximaalKrediet, string rekeningNrBetalen, decimal bankSaldo) : base(rekeningNrBetalen, bankSaldo)
        {
            this.maximaalKrediet = -maximaalKrediet;
            this.rekeningNrBetalen = rekeningNrBetalen;
            this.bankSaldo = bankSaldo;
        }
        #endregion

        #region Methods
        // -- Methods --

        // Methode voor het converten van het maximaal kredit 
        public override string ToString()
        {
            return Convert.ToString(maximaalKrediet);
        }
        #endregion
    }
}