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
        public MainWindow()
        {
            InitializeComponent();

        }
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await LoadData();

        }


        async Task LoadData()
        {
            //Loading the Data
            kundenDG.ItemsSource = await RestHelper.Getallkunden();
            kundenDG.SelectedIndex = 0;

            brillenDG.ItemsSource = await RestHelper.Getallbrillen();
            brillenDG.SelectedIndex = 0;

            mitarbeiterDG.ItemsSource = await RestHelper.Getallmitarbeiter();
            mitarbeiterDG.SelectedIndex = 0;

            liefererDG.ItemsSource = await RestHelper.Getalllieferer();
            liefererDG.SelectedIndex = 0;

            geschaeftDG.ItemsSource = await RestHelper.Getallgeschaeft();
            geschaeftDG.SelectedIndex = 0;
        }

    }
}
