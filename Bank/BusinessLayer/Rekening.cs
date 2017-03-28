using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bank
{
    public abstract class Rekening
    {
        #region Fields
        // --Fields--
        private string rekeningNr;
        private decimal bankSaldo;

        #endregion
        
        #region Properties
        // --Properties--

        public abstract string RekeningNr
        {
            get;
        }
        public abstract decimal Bijschrijven
        {
            set;
        }

        public abstract decimal Afschrijven
        {
            set;
        }

        public abstract decimal BankSaldo
        {
            get;
        }
        #endregion

        #region Constructor
        // --Constructor--
        // Een rekening aamken met de parameters rekeningNr en bankSaldo
        public Rekening(string rekeningNr,decimal bankSaldo)
        {
            this.rekeningNr = rekeningNr;
            this.bankSaldo = bankSaldo;
        }
        #endregion

        #region Methods
        // --Methods--

        // Een methode aanmaken voor het converten naar een string
        public abstract override string ToString();
        #endregion  
    }
}