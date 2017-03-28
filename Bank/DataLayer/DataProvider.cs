using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bank
{
    public static class DataProvider
    {
        // Methode aanmaken voor alle bankrekeninghouders
        public static List<Bankrekeninghouder> AlleRekeningHouders()
        {
            // Nieuwe Lijst aanmaken om bankrekeninghouders in te plaatsen
            List<Bankrekeninghouder> bankrekeninghouderslijst = new List<Bankrekeninghouder>();

            //Bankrekening aanmaken voor Stijn
            bankrekeninghouderslijst.Add(new Bankrekeninghouder (
                voornaam: "Stijn",
                achternaam: "Mulder",
                bsn: 250577161,
                gebruikersnaam: "stijn7621",
                wachtwoord: "Test12345",
                rekeningNrBetalen: "NL01 STUB 0000 0000 00",
                betalenSaldo: 1500,
                rentePercentage: 1.6m,
                rekeningNrSparen: "NL01 STUB 0000 0000 01",
                sparenSaldo: 2500,
                maximaalKrediet: 2000
                ));

            //Bankrekening aanmaken voor Lars
            bankrekeninghouderslijst.Add(new Bankrekeninghouder(
                voornaam: "Lars",
                achternaam: "Oude Luttikhuis",
                bsn: 229557648,
                gebruikersnaam: "Lars123",
                wachtwoord: "Test12345",
                rekeningNrBetalen: "NL58 STUB 0001 2439 71",
                betalenSaldo: 250,
                rentePercentage: 1.6m,
                rekeningNrSparen: "NL59 STUB 0001 2439 71",
                sparenSaldo: 8750,
                maximaalKrediet: 1000
                ));

            //Bankrekening aanmaken voor Naaman
            bankrekeninghouderslijst.Add(new Bankrekeninghouder(
                voornaam: "Naaman",
                achternaam: "Numansen",
                bsn: 225999262,
                gebruikersnaam: "Naaman",
                wachtwoord: "0644501155",
                rekeningNrBetalen: "NL03 STUB 0000 0000 00",
                betalenSaldo: 2150,
                rentePercentage: 2.1m,
                rekeningNrSparen: "NL03 STUB 0000 0000 01",
                sparenSaldo: 328365,
                maximaalKrediet: 2000
                ));

            return bankrekeninghouderslijst;
        }
        // Methode voor inloggegevens te checken 
        public static Bankrekeninghouder Inloggen(string gebruikersnaam, string wachtwoord)
        {
            // Bankrekeninghouderslijst wordt opgehaald
            List<Bankrekeninghouder> bankrekeninghouderslijst = AlleRekeningHouders();

            // Doorlopen van de collectie uit de bankrekeninghouders, 
            // als de gebruikersnaam en wachtwoord overeen word hij terug gestuurd
            // zo niet dan word er een foutmelding weergeven
            foreach (Bankrekeninghouder objectBankrekeninghouder in bankrekeninghouderslijst) 
            {
                if (objectBankrekeninghouder.Persoon.Gebruikersnaam == gebruikersnaam && objectBankrekeninghouder.Persoon.Wachtwoord == wachtwoord)
                {

                    return objectBankrekeninghouder;

                }
            }
            throw new Exception("Controleer uw gebruikersnaam en wachtwoord");
        }

        // Elf Proef uitvoeren
        public static bool ValidateElfProef(string value)
        {

            if (value.Length == 9)
            {
                int a = 0;
                int b = 9;
                int c = 0;


                for (int i = 0; i <= 8; i++)
                {
                    c = int.Parse(value[i].ToString());

                    if (i == 8)
                    {
                        b = -1;
                    }
                    a += c * b;
                    b--;
                }

                if (a % 11 == 0)
                {
                    return true;

                }
                else
                {
                    // Klopt het nummer niet? dan word er een error aangegeven
                    throw new Exception("Het nummer is niet correct");

                }

            }
            else
            { 
                // Klopt het nummer niet? dan word er een error aangegeven
                throw new Exception("Het nummer is niet correct");

            }
        }

    }
}