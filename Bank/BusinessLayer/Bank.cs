using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bank
{
    public class Bank
    {
        #region Fields
        // --Fields--

        private string bankNaam;
        private string gebruikersnaam;
        private string wachtwoord;
        private List<Bankrekeninghouder> bankrekeninghouderslijst;

        #endregion

        #region Properties
        // --Properties--

        public string BankNaam
        {
            get { return bankNaam; }
            set { bankNaam = value; }
        }

        public string Gebruikersnaam
        {
            get { return gebruikersnaam; }
            set { gebruikersnaam = value; }
        }

        public string Wachtwoord
        {
            get { return wachtwoord; }
            set { wachtwoord = value; }
        }
        public List<Bankrekeninghouder> Bankrekeninghouderslijst
        {
            get { return bankrekeninghouderslijst; }
            set { bankrekeninghouderslijst = value; }
        }

        #endregion


        #region Constructor
        // --Constructor--

        public Bank()
        {

        }
        #endregion

        #region Methods
        // --Methods--

        // methode voor het toevoegen van bankrekeninghouders met classes als parameters 
        public void ToevoegenBankrekeninghouder(Persoon rekeninghouder, Betaalrekening betaalrekening, Spaarrekening spaarrekening)
        {
            throw new NotImplementedException();
        }
        
        public bool BankRekeninghouderOpheffen(long bsn)
        {
            throw new NotImplementedException();

        }
        public bool Rentebijschrijven()
        {
            throw new NotImplementedException();

        }
        #endregion
    }
}