using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bank
{
    public class Persoon
    {
        #region Fields
        // --Fields--
        private string voornaam;
        private string achternaam;
        private long bsn;
        private string gebruikersnaam;
        private string wachtwoord;

        #endregion

        #region Properties
        // --Properties--
        public string Voornaam
        {
            get { return voornaam; }
            set { voornaam = value; }
        }

        public long Bsn
        {
            get { return bsn; }
            set { bsn = value; }
        }

        public string Achternaam
        {
            get { return achternaam; }
            set { achternaam = value; }
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
        #endregion

        #region Constructor
        // --Constructors--

        // Een persoon aanmaken met de parameters voornaam,achernaam, Bsn, gebruikersnaam en wachtwoord 

        public Persoon(string voornaam, string achternaam, long bsn, string gebruikersnaam, string wachtwoord)
        { 
            this.voornaam = voornaam;
            this.achternaam = achternaam;
            this.bsn = bsn;
            this.gebruikersnaam = gebruikersnaam;
            this.wachtwoord = wachtwoord;
        }
        #endregion

        #region Methods
        // --Methods--

        // De voornaam en achternaam converten naar een zin zodat de output de voornaam spatie achternaam bevat
        public override string ToString()
        {
            return voornaam +" "+ achternaam;
        }
        #endregion
    }
}