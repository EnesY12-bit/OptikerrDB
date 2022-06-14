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
            
            MessageBox.Show("Gesendet");

            kundenDG.Items.Refresh();
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

        private void UpdateKunde_Click(object sender, RoutedEventArgs e)
        {

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

        private void UpdateBrillen_Click(object sender, RoutedEventArgs e)
        {

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

        private void UpdateMitarbeiter_Click(object sender, RoutedEventArgs e)
        {

        }

        // Lieferer
        private void AddLiefer_Click(object sender, RoutedEventArgs e)
        {

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
                MessageBox.Show("Error");
            }
        }

        private void UpdateLiefer_Click(object sender, RoutedEventArgs e)
        {

        }

        // Geschäft
        private void AddGeschäft_Click(object sender, RoutedEventArgs e)
        {

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

        private void UpdateGeschäft_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}