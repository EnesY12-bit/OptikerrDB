#nullable disable
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using OptikerService.Models;


namespace OptikerrDB
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //OberserableCollections for Data
        ObservableCollection<kunden> OBkunden = new ObservableCollection<kunden>();
        ObservableCollection<brillen> OBbrillen = new ObservableCollection<brillen>();
        ObservableCollection<mitarbeiter> OBmitarbeiter = new ObservableCollection<mitarbeiter>();
        ObservableCollection<lieferer> OBlieferer = new ObservableCollection<lieferer>();   
        ObservableCollection<geschaeft> OBgeschaeft = new ObservableCollection<geschaeft>();

        public MainWindow()
        {
            InitializeComponent();

        }
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            kundenDG.ItemsSource = OBkunden;
            brillenDG.ItemsSource = OBbrillen;
            mitarbeiterDG.ItemsSource = OBmitarbeiter;
            liefererDG.ItemsSource = OBlieferer;
            geschaeftDG.ItemsSource = OBgeschaeft;
            
            

            await LoadData();

        }


        async Task LoadData()
        {

            //Loading the Data
            var obkunden = await RestHelper.GetallkundenAsync();
            foreach (var k in obkunden)
            {
                OBkunden.Add(k);
            }
            //kundenDG.ItemsSource = await RestHelper.Getallkunden();
            kundenDG.SelectedIndex = 0;

            var obbrillen = await RestHelper.GetallbrillenAsync();
            foreach (var b in obbrillen)
            {
                OBbrillen.Add(b);
            }
            //brillenDG.ItemsSource = await RestHelper.Getallbrillen();
            brillenDG.SelectedIndex = 0;

            var obmitarbeiter = await RestHelper.GetallmitarbeiterAsync();
            foreach (var m in obmitarbeiter)
            {
                OBmitarbeiter.Add(m);
            }    
            //mitarbeiterDG.ItemsSource = await RestHelper.Getallmitarbeiter();
            mitarbeiterDG.SelectedIndex = 0;

            var oblieferer = await RestHelper.GetallliefererAsync();
            foreach (var l in oblieferer)
            {
                OBlieferer.Add(l);
            }
            //liefererDG.ItemsSource = await RestHelper.Getalllieferer();
            liefererDG.SelectedIndex = 0;

            var obgeschaeft = await RestHelper.GetallgeschaeftAsync();
            foreach (var g in obgeschaeft)
            {
                OBgeschaeft.Add(g);
            }
            //geschaeftDG.ItemsSource = await RestHelper.Getallgeschaeft();
            geschaeftDG.SelectedIndex = 0;
        }

        //Kunden
        private async void AddKunden_Click(object sender, RoutedEventArgs e)
        {
            //KundenTB, AnredeTB, NameTB, EmailTB, TelefonnummerTB, AnredeTB, KostenTB, BestellungTB, DatumTB 
            var kundeAdd = new kunden(Convert.ToInt32(KIDTB.Text), AnredeTB.Text, NameTB.Text, EmailTB.Text, Convert.ToDecimal(TelTB.Text), AdressTB.Text, Convert.ToDecimal(KostenTB.Text), Convert.ToDecimal(BestellungTB.Text), KundeDP.DisplayDate);

            var newKunde = await RestHelper.PostKundenAsync(kundeAdd.kundenid, kundeAdd);

            if (newKunde != null)
            {
                OBkunden.Add(newKunde);
                kundenDG.Items.Refresh();
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private async void DeleteKunde_Click(object sender, RoutedEventArgs e)
        {
            kunden selectedKunde = kundenDG.SelectedItem as kunden;
            if (selectedKunde == null)
                return;

            var deleteKunde = await RestHelper.DeleteKundenAsync(selectedKunde.kundenid);
            if (deleteKunde)
            {
                OBkunden.Remove(selectedKunde);
                kundenDG.Items.Refresh();
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private async void UpdateKunde_Click(object sender, RoutedEventArgs e)
        {
            kunden selectedKundeU = kundenDG.SelectedItem as kunden;
            if (selectedKundeU == null)
            {
                return;
            }
            kunden editkunde = new kunden(selectedKundeU.kundenid, selectedKundeU.anrede, selectedKundeU.name, selectedKundeU.email, selectedKundeU.telefonnummer, selectedKundeU.adresse, selectedKundeU.kosten, selectedKundeU.bestellungsnummer, selectedKundeU.datum);

           /* selectedKundeU.kundenid = editkunde.kundenid;
            selectedKundeU.anrede = editkunde.anrede;
            selectedKundeU.name = editkunde.name;
            selectedKundeU.email = editkunde.email;
            selectedKundeU.telefonnummer = editkunde.telefonnummer;
            selectedKundeU.adresse = editkunde.adresse;
            selectedKundeU.kosten = editkunde.kosten;
            selectedKundeU.bestellungsnummer = editkunde.bestellungsnummer;
            selectedKundeU.datum = editkunde.datum;
            */

            var patchkunde = await RestHelper.PatchKundenAsync(selectedKundeU.kundenid, editkunde);
            if (patchkunde)
            {
                kundenDG.Items.Refresh();
            }
            else
            {
                MessageBox.Show("Error");
            }


        }

        //Brillen

        private async void AddBrillen_Click(object sender, RoutedEventArgs e)
        {
            brillen brillenAdd = new brillen(Convert.ToInt32(MIDTB.Text), BNTB.Text,
             BATB.Text, Convert.ToDecimal(BPTB.Text),
             BGTB.Text, Convert.ToDecimal(BSTB.Text),
             Convert.ToDecimal(BSTUTB.Text));


            var newBrille = await RestHelper.PostBrillensAsync(brillenAdd.modellid, brillenAdd);

            if (newBrille != null)
            {
                OBbrillen.Add(newBrille);
                brillenDG.Items.Refresh();
            }
            else
            {
                MessageBox.Show("Error");
            }

        }

        private async void DeleteBrillen_Click(object sender, RoutedEventArgs e)
        {
            brillen selectedBrille = brillenDG.SelectedItem as brillen;
            if (selectedBrille == null)
                return;

            var deleteBrille = await RestHelper.DeleteBrillenAsync(selectedBrille.modellid);
            if (deleteBrille)
            {
                OBbrillen.Remove(selectedBrille);
                brillenDG.Items.Refresh();
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private async void UpdateBrillen_Click(object sender, RoutedEventArgs e)
        {
            brillen selectedBrillenU = brillenDG.SelectedItem as brillen;
            
            /*
            MIDTB.Text = Convert.ToString(selectedBrillenU.modellid);
            BNTB.Text = selectedBrillenU.name;
            BATB.Text = selectedBrillenU.art;
            BPTB.Text = Convert.ToString(selectedBrillenU.preis);
            BGTB.Text = selectedBrillenU.glasart;
            BSTB.Text = Convert.ToString(selectedBrillenU.staerke);
            BSTUTB.Text = Convert.ToString(selectedBrillenU.stueck);
            */
            

            if (selectedBrillenU == null)
            {
                return;
            }
           // brillen editbrillen = new brillen(selectedBrillenU.modellid, selectedBrillenU.name, selectedBrillenU.art, selectedBrillenU.preis, selectedBrillenU.glasart, selectedBrillenU.staerke, selectedBrillenU.stueck);


            brillen editbrillen = new()
            {
                modellid = selectedBrillenU.modellid,
                name = selectedBrillenU.name,
                art = selectedBrillenU.art,
                preis = selectedBrillenU.preis,
                glasart = selectedBrillenU.glasart,
                staerke = selectedBrillenU.staerke,
                stueck = selectedBrillenU.stueck
            };

           /* selectedBrillenU.modellid = editbrillen.modellid;
            selectedBrillenU.name = editbrillen.name;
            selectedBrillenU.art = editbrillen.art;
            selectedBrillenU.preis = editbrillen.preis;
            selectedBrillenU.glasart = editbrillen.glasart;
            selectedBrillenU.staerke = editbrillen.staerke;
            selectedBrillenU.stueck = editbrillen.stueck;
           */

            var patchbrillen = await RestHelper.PatchBrillenAsync(selectedBrillenU.modellid, editbrillen);
            if (patchbrillen)
            {
                brillenDG.Items.Refresh();
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        //Mitarbeiter

        private async void AddMitarbeiter_Click(object sender, RoutedEventArgs e)
        {
            mitarbeiter mitarbeiterAdd = new mitarbeiter(Convert.ToInt32(MPIDTB.Text),MATB.Text,MNTB.Text,
            MAdresseTB.Text,Convert.ToDecimal(MSTB.Text),Convert.ToDecimal(MGTB.Text),MTTB.Text,
            Convert.ToInt32(MGIDTB.Text), Convert.ToInt32(MKIDTB.Text));


            var newmitarbeiter = await RestHelper.PostMitarbeiterAsync(mitarbeiterAdd.personalid, mitarbeiterAdd);

            if (newmitarbeiter != null)
            {
                OBmitarbeiter.Add(newmitarbeiter);
                mitarbeiterDG.Items.Refresh();
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private async void DeleteMitarbeiter_Click(object sender, RoutedEventArgs e)
        {
            mitarbeiter selectedMitarbeiter = mitarbeiterDG.SelectedItem as mitarbeiter;
            if (selectedMitarbeiter == null)
                return;

            var deleteMitarbeiter = await RestHelper.DeleteMitarbeiterAsync(selectedMitarbeiter.personalid);

            if (deleteMitarbeiter)
            {
                OBmitarbeiter.Remove(selectedMitarbeiter);
                mitarbeiterDG.Items.Refresh();
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private async void UpdateMitarbeiter_Click(object sender, RoutedEventArgs e)
        {
            mitarbeiter selectedMitarbeiterU = mitarbeiterDG.SelectedItem as mitarbeiter; 
            if (selectedMitarbeiterU == null)
            {
                return;
            }
            mitarbeiter editmitarbeiter = new mitarbeiter(selectedMitarbeiterU.personalid, selectedMitarbeiterU.anrede, selectedMitarbeiterU.name, selectedMitarbeiterU.adress, selectedMitarbeiterU.sozialversicherung, selectedMitarbeiterU.gehalt, selectedMitarbeiterU.taetigkeit, selectedMitarbeiterU.geschaeftsid, selectedMitarbeiterU.kundenid);

            var patchmitarbeiter = await RestHelper.PatchMitarbeiterAsync(selectedMitarbeiterU.personalid, editmitarbeiter);
            if (patchmitarbeiter)
            {
                mitarbeiterDG.Items.Refresh();
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        // Lieferer
        private async void AddLiefer_Click(object sender, RoutedEventArgs e)
        {
            lieferer liefererAdd = new lieferer(Convert.ToInt32(LIDTB.Text), LNTB.Text, LATB.Text, LETB.Text, Convert.ToDecimal(LTTB.Text));


            var newlieferer = await RestHelper.PostLiefererAsync(liefererAdd.lieferid, liefererAdd);

            if (newlieferer != null)
            {
                OBlieferer.Add(newlieferer);
                liefererDG.Items.Refresh();
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private async void DeleteLiefer_Click(object sender, RoutedEventArgs e)
        {
            lieferer selectedLieferer = liefererDG.SelectedItem as lieferer;
            if (selectedLieferer == null)
                return;

            var deleteLieferer = await RestHelper.DeleteLiefererAsync(selectedLieferer.lieferid);
            if (deleteLieferer)
            {
                OBlieferer.Remove(selectedLieferer);
                liefererDG.Items.Refresh();
            }
            else
            {
                MessageBox.Show("Error deleting lieferer");
            }
        }

        private async void UpdateLiefer_Click(object sender, RoutedEventArgs e)
        {
            lieferer selectedLiefererU = liefererDG.SelectedItem as lieferer;
            if (selectedLiefererU == null)
            {
                return;
            }
            lieferer editlieferer = new lieferer(selectedLiefererU.lieferid, selectedLiefererU.name, selectedLiefererU.adresse, selectedLiefererU.email, selectedLiefererU.telefonnummer);

            var patchlieferer = await RestHelper.PatchLiefererAsync(selectedLiefererU.lieferid, editlieferer);
            if (patchlieferer)
            {
                liefererDG.Items.Refresh();
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        // Geschäft
        private async void AddGeschäft_Click(object sender, RoutedEventArgs e)
        {
            geschaeft geschaeftAdd = new geschaeft(Convert.ToInt32(GIDTB.Text), GATB.Text, GNTB.Text, Convert.ToInt32(GPTB.Text));

            var newgeschaeft = await RestHelper.PostGeschaeftAsync(geschaeftAdd.geschaeftsid, geschaeftAdd); 

            if (newgeschaeft != null)
            {
                OBgeschaeft.Add(newgeschaeft);
                geschaeftDG.Items.Refresh();
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private async void DeleteGeschäft_Click(object sender, RoutedEventArgs e)
        {
            geschaeft selectedGeschaeft = geschaeftDG.SelectedItem as geschaeft;
            if (selectedGeschaeft == null)
                return;

            var deleteGescheaft = await RestHelper.DeleteGeschaeftAsync(selectedGeschaeft.geschaeftsid);
            if (deleteGescheaft)
            {
                OBgeschaeft.Remove(selectedGeschaeft);
                geschaeftDG.Items.Refresh();
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private async void UpdateGeschäft_Click(object sender, RoutedEventArgs e)
        {
            geschaeft selectedGeschaeftU = geschaeftDG.SelectedItem as geschaeft;
            if (selectedGeschaeftU == null)
            {
                return;
            }
            geschaeft editgeschaeft = new geschaeft(selectedGeschaeftU.geschaeftsid, selectedGeschaeftU.adresse, selectedGeschaeftU.name, selectedGeschaeftU.personalid);

            var patchgeschaeft = await RestHelper.PatchGeschaeftAsync(selectedGeschaeftU.geschaeftsid, editgeschaeft);
            if (patchgeschaeft)
            {
                geschaeftDG.Items.Refresh();
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        //Filtering through the DataGrids
        private void SearchKundenTB_KeyUp(object sender, KeyEventArgs e)
        {
            string searchtermK = SearchKundenTB.Text.Trim().ToLower();
            kundenDG.ItemsSource = OBkunden.Where(w => w.name.ToLower().Contains(searchtermK));
        }

        private void SearchBrillenTB_KeyUp(object sender, KeyEventArgs e)
        {
            string searchtermB = SearchBrillenTB.Text.Trim().ToLower();
            brillenDG.ItemsSource = OBbrillen.Where(w => w.name.ToLower().Contains(searchtermB));
        }

        private void SearchMitarebiterTB_KeyUp(object sender, KeyEventArgs e)
        {
            string searchtermM = SearchMitarebiterTB.Text.Trim().ToLower();
            mitarbeiterDG.ItemsSource = OBmitarbeiter.Where(w => w.name.ToLower().Contains(searchtermM));
        }

        private void SearchLieferTB_KeyUp(object sender, KeyEventArgs e)
        {
            string searchtermL = SearchLieferTB.Text.Trim().ToLower();
            liefererDG.ItemsSource = OBlieferer.Where(w => w.name.ToLower().Contains(searchtermL));
        }

        private void SearchGeschäftTB_KeyUp(object sender, KeyEventArgs e)
        {
            string searchtermG = SearchGeschäftTB.Text.Trim().ToLower();
            geschaeftDG.ItemsSource = OBgeschaeft.Where(w => w.name.ToLower().Contains(searchtermG));
        }

        //Test
        /* private void TabBrille_GotFocus(object sender, RoutedEventArgs e)
         {
             var window = new LoginWindow();
             window.Owner = this;
             if (window.ShowDialog() == true)
             {
                 TabBrille.Focus();
             }
             else
             {
                 TabKunde.Focus();
             }
         }

        */
    }
}