using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bank
{
    public class Spaarrekening : Rekening
    {
        #region Fields
        // --Fields--
        private decimal rentePercentage;
        private string rekeningNrSparen;
        private decimal bankSaldo;
        #endregion

        #region Properties
        // -- PROPERTIES --
        public override decimal BankSaldo
        {
            get { return bankSaldo; }
        }

        // Afschrijven van een bedrag
        public override decimal Afschrijven
        {
            set { bankSaldo -= value; }
        }

        // Bijschrijven van een bedrag
        public override decimal Bijschrijven
        {
            set { bankSaldo += value; }
        }

        // De rente berekenen
        public decimal HuidigeRenteBerekenen
        {
            
            get { return Convert.ToDecimal(HuidigOpgebouwdeRente()); }
        }

        // Jaarrente bijschrijven
        public decimal JaarRenteBijschrijven
        {
            set { bankSaldo += value; }
        }

        public override string RekeningNr
        {
            get { return rekeningNrSparen; }
        }

        #endregion

        #region Constructor
        // --Constructor--

        // Spaarrekening aanmaken met behulp van de parameters, rente, rekeningNrSparen, bankSaldo die worden meegegeven tijdens het aanmaken
        public Spaarrekening(decimal rente, string rekeningNrSparen, decimal bankSaldo) : base(rekeningNrSparen, bankSaldo)
        {
            this.rentePercentage = rente;
            this.rekeningNrSparen = rekeningNrSparen;
            this.bankSaldo = bankSaldo;
        }
        #endregion

        #region Methods
        // -- METHODS --

        // de opgebouwde rente berekenen door HuidigeRenteBerekenen() aan te roepen
        public string HuidigOpgebouwdeRente()
        {

            decimal huidigeRente = ((bankSaldo / 100) * rentePercentage);
            string s = string.Format("{0:0.00}", huidigeRente);
            s.Replace(".", ",");
            return s;
        }

        // Converten van het rentepercentage naar een string
        public override string ToString()
        {
            return Convert.ToString(rentePercentage);
        }
        #endregion
    }
}