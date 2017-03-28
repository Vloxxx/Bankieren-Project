using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bank
{
    public class Bankrekeninghouder
    {
        #region Fields
        // --Fields--

        private Persoon persoon;
        private Betaalrekening betaalrekening;
        private Spaarrekening spaarrekening;
        private static List<Bankrekeninghouder> bankrekeninghouderslijst = DataProvider.AlleRekeningHouders();
        #endregion

        #region Properties
        // --Properties--
        public static List<Bankrekeninghouder> Bankrekeninghouderslijst
        {
            get { return bankrekeninghouderslijst; }
            set { bankrekeninghouderslijst = value; }
        }
        public Persoon Persoon
        {
            get { return persoon; }
            set { persoon = value; }
        }

        public Betaalrekening Betaalrekening
        {
            get { return betaalrekening; }
            set { betaalrekening = value; }
        }

        public Spaarrekening Spaarrekening
        {
            get { return spaarrekening; }
            set { spaarrekening = value; }
        }
        #endregion

        #region Constructor
        // --Constructors--

        // Constructors voor het maken van een bankrekeninghouder met parameters om de classes aan te maken
        public Bankrekeninghouder(string voornaam, string achternaam, long bsn, string gebruikersnaam, string wachtwoord, string rekeningNrSparen, decimal sparenSaldo, decimal rentePercentage, string rekeningNrBetalen, decimal betalenSaldo, decimal maximaalKrediet)
        {
            persoon = new Persoon(voornaam, achternaam, bsn, gebruikersnaam, wachtwoord);
            betaalrekening = new Betaalrekening(maximaalKrediet, rekeningNrBetalen, betalenSaldo);
            spaarrekening = new Spaarrekening(rentePercentage, rekeningNrSparen, sparenSaldo);
        }
        
        public Bankrekeninghouder(Persoon rekeninghouder, Betaalrekening betaalrekening, Spaarrekening spaarrekening)
        {
            this.persoon = rekeninghouder;
            this.betaalrekening = betaalrekening;
            this.spaarrekening = spaarrekening;
        }
        #endregion

        #region Methods
        // --Methods--

        //een methode voor het inzien van het spaarrekening
        public string SpaarrekeningInzien()
        {
            return Convert.ToString(Spaarrekening.BankSaldo);
        }

        // methode voor het inzien van het betaalrekening
        public string BetaalrekeningInzien()
        {
            return Convert.ToString(Betaalrekening.BankSaldo);
        }


        // Het uitvoeren van een betaling
        public bool Betalingverichten(string rekeningNr, decimal bedrag)
        {
            // Haalt alle bankrekeninghouders op uit de bankrekeninghouderslijst
            foreach (Bankrekeninghouder objectbankrekeninghouder in bankrekeninghouderslijst) 
            {
                // Kijken of de Object bankrekeningNR gelijk is aan de rekeningNR
                if (objectbankrekeninghouder.Betaalrekening.RekeningNr == rekeningNr)
                {
                    // Kijken of het banksaldo zonder het ingevoerde bedrag hoger is dan het maximaal krediet

                    if (betaalrekening.BankSaldo - bedrag >= betaalrekening.MaximaalKrediet)
                    {
                        betaalrekening.Afschrijven = bedrag;
                        objectbankrekeninghouder.Betaalrekening.Bijschrijven = bedrag;
                        return true;
                    }
                    // Zo niet dan komt er eem error melding
                    else
                    {
                        throw new Exception("Het saldo mag niet lager zijn dan het huidige krediet!");
                    }
                }
            }
            // Zo niet dan komt er een error melding
            throw new Exception("Het opgegeven rekening bestaat niet!");
        }

        // Overboeken naar een spaarrekening
        public bool OverboekenSpaarrekening(decimal bedrag)
        {
            // Is het banksaldo min het ingevoerde bedrag hoger dan het maximaal kredit? dan word het bedrag overgemaakt
            if (betaalrekening.BankSaldo - bedrag >= betaalrekening.MaximaalKrediet)
            {
                spaarrekening.Bijschrijven = bedrag;
                betaalrekening.Afschrijven = bedrag;
                return true;
            }
            // Zo niet dan word er een error melding gegeven
            throw new Exception("Het saldo mag niet lager zijn dan het huidige krediet!");
        }

        // Overboeken vanuit een betaalrekening naar een andere betaalrekening
        public bool OverboekenBetaalrekening(decimal bedrag)
        {
            // Is het banksaldo min het bedrag groter of gelijk is aan nul? dan word het bedrag overgemaakt
            if (spaarrekening.BankSaldo - bedrag >= 0)
            {
                spaarrekening.Afschrijven = bedrag;
                betaalrekening.Bijschrijven = bedrag;
                return true;
            }
            // Zo niet dan word er een error melding weergeven
            throw new Exception("Het saldo mag niet lager zijn dan het bedrag dat je op jouw spaarrekening hebt staan!");
        }
        #endregion
    }
}