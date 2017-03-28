using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Bank;
using System.Text.RegularExpressions;

namespace Bankieren
{
    /// <summary>
    /// Interaction logic for BetaalRekening.xaml
    /// </summary>
    public partial class Betaalrekening : Window
    {
        #region Fields
        // -- FIELDS --

        bool fillonce = true;
        Bankrekeninghouder bankrekeninghouder;
        #endregion

        #region Constructor
        // -- CONSTRUCTOR --

        // Betaalrekening aanmaken met een Bankrekeninghouder class
        public Betaalrekening(Bankrekeninghouder bankrekeninghouder)
        {
            InitializeComponent();
            this.bankrekeninghouder = bankrekeninghouder;
            cbxClients.Items.Insert(0, "<- Maak een keuze ->");
            cbxClients.SelectedIndex = 0;
        }
        #endregion

        #region Methods
        // -- METHODS --
        public void HuidigeSaldoEnKredietBijwerken()
        {
            foreach (Bankrekeninghouder bankrekeninghouder in Bankrekeninghouder.Bankrekeninghouderslijst)
            {
                if (bankrekeninghouder.Betaalrekening.RekeningNr == this.bankrekeninghouder.Betaalrekening.RekeningNr)
                {
                    string s = string.Format("{0:0.00}", bankrekeninghouder.Betaalrekening.BankSaldo);
                    s.Replace(".", ",");
                    lblHuidigeSaldo.Content = s;
                    s = string.Format("{0:0.00}", -bankrekeninghouder.Betaalrekening.MaximaalKrediet);
                    s.Replace(".", ",");
                    lblKrediet.Content = s;
                }
            }
        }
        #endregion

        #region RoutedEventArgs Methods
        // -- EVENTARGS METHODS --

        #region Grid_Loaded Events
        // -- GRID_LOADED EVENTARGS --

        // Als het window is geladen word er gekeken met welke bankrekeninghouder je werkt op dit moment
        // daarvan word dan het banksaldo opgehaald en weergeven in een label
        public void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            HuidigeSaldoEnKredietBijwerken();
        }
        #endregion

        #region cbxClients_GotFocus Events
        // -- CBXCLIENTS_GOTFOCUS EVENTARGS --

        // Als er op de combobox wordt geklikt, worden de items gevuld met de bijbehorende rekeningnummer waarnaar je het kan overmaken. (Exclusief de huidige betaalrekeningnummer)
        private void cbxClients_GotFocus(object sender, RoutedEventArgs e)
        {
            if (fillonce == true)
            {
                int index = 1;
                foreach (Bankrekeninghouder bankrekeninghouder in Bankrekeninghouder.Bankrekeninghouderslijst)
                {
                    if (this.bankrekeninghouder.Betaalrekening.RekeningNr != bankrekeninghouder.Betaalrekening.RekeningNr)
                    {
                        cbxClients.Items.Insert(index, bankrekeninghouder.Betaalrekening.RekeningNr);
                        index++;
                    }
                }
                fillonce = false;
            }
        }
        #endregion

        #region Radiobuttons_Checked Events
        // -- RADIOBUTTONS_CHECKED EVENTARGS --

        // De volgende methode wordt uitgevoerd als de radiobutton met de naam rbnMijnSpaarrekening wordt aangeklikt.
        private void rbnMijnSpaarrekening_Checked(object sender, RoutedEventArgs e)
        {
            cbxClients.SelectedIndex = 0;
            cbxClients.IsEnabled = false;
        }

        // De volgende methode wordt uitgevoerd als de radiobutton met de naam rbnAndereBetaalrekening wordt aangeklikt.
        private void rbnAndereBetaalrekening_Checked(object sender, RoutedEventArgs e)
        {
            cbxClients.SelectedIndex = 0;
            cbxClients.IsEnabled = true;
        }
        #endregion

        #region btnVerzenden ClickEvents
        // -- BTNVERZENDEN CLICK-EVENTARGS --

        private void btnVerzenden_Click(object sender, RoutedEventArgs e) // Methode wordt uitgevoerd als er op btnVerzenden wordt geklikt
        {
            try
            {
                if (tbxBedrag.Text != string.Empty) // Checkt of de ingevoerde waarde niet leeg is
                {
                    // Laat een messagebox zien die vervolgens als result yes moet zijn om de onderliggende code te kunnen uitvoeren
                    if (MessageBox.Show("Weet u zeker of u het bedrag wilt overmaken?", "Overmaken", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        if (rbnMijnSpaarrekening.IsChecked == true) // Als de radiobutton MijnSpaarrekening is aangevinkt dan wordt de onderliggende code uitgevoerd.
                        {
                            foreach (Bankrekeninghouder bankrekeninghouder in Bankrekeninghouder.Bankrekeninghouderslijst) // Eerst worden alle bankrekeninghouders uit de lijst opgehaald
                            {
                                if (bankrekeninghouder.Betaalrekening.RekeningNr == this.bankrekeninghouder.Betaalrekening.RekeningNr) // Checkt voor elke bankrekninghouder uit de lijst of de betaalrekeningnr gelijk is aan de huidige rekeningnr
                                {
                                    bankrekeninghouder.OverboekenSpaarrekening(Convert.ToDecimal(tbxBedrag.Text));
                                    HuidigeSaldoEnKredietBijwerken();
                                    tbxBedrag.Text = "";
                                }
                            }
                            MessageBox.Show("Het bedrag is overgemaakt.", "Overmaken", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else if (rbnAndereBetaalrekening.IsChecked == true) // Als de radiobutton AndereBetaalrekening is aangevinkt dan wordt de onderliggende code uitgevoerd.
                        {
                            if (cbxClients.SelectedIndex != 0) // Als de Aangegeven index niet gelijk is aan 0 dan wordt de onderliggende code uitgevoerd.
                            {
                                foreach (Bankrekeninghouder bankrekeninghouder in Bankrekeninghouder.Bankrekeninghouderslijst) // Eerst worden alle bankrekeninghouders uit de lijst opgehaald
                                {
                                    if (bankrekeninghouder.Betaalrekening.RekeningNr == this.bankrekeninghouder.Betaalrekening.RekeningNr) // Checkt voor elke bankrekninghouder uit de lijst of de betaalrekeningnr gelijk is aan de huidige rekeningnr
                                    {
                                        bankrekeninghouder.Betalingverichten(cbxClients.SelectedItem.ToString(), Convert.ToDecimal(tbxBedrag.Text));
                                        HuidigeSaldoEnKredietBijwerken();
                                        tbxBedrag.Text = "";
                                    }
                                }
                                MessageBox.Show("Het bedrag is overgemaakt.", "Overmaken", MessageBoxButton.OK, MessageBoxImage.Information);
                            }
                            else
                            {
                                MessageBox.Show("Geef eerst aan naar wie je het aangegeven bedrag wilt overmaken", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Voer eerst een geldig geldbedrag in!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        #endregion

        #region btnClose ClickEvents
        // -- BTNCLOSE CLICK-EVENTARGS --
        private void btnClose_Click(object sender, RoutedEventArgs e) // Methode wordt uitgevoerd als er op de knop btnClose wordt geklikt.
        {
            this.Hide();
        }
        #endregion

        #region Window_Closing Events
        // -- WINDOW_CLOSING EVENTARGS --
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) // Methode wordt uitgevoerd als het venster wordt gesloten met het kruisje rechtsbovenin
        {
            this.Hide();
            e.Cancel = true;
        }
        #endregion
        #endregion

        #region PreviewTextInputs
        // -- PREVIEW TEXT INPUTS --
        private void DoublePreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9,-]+$"); //Accepteert alleen de toetsen 0 t/m 9, - en ,
            e.Handled = regex.IsMatch(e.Text);
            if (Regex.IsMatch(tbxBedrag.Text, @"\,\d\d")) //Mag maximaal 2 decimalen achter de komma hebben
            {
                e.Handled = true;
            }
        }
        #endregion
    }
}
