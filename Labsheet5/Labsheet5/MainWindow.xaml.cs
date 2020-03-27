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

namespace Labsheet5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Model1Container db = new Model1Container();


        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var query = from b in db.Bands
                        select b;

            lbxBands.ItemsSource = query.ToList();
        }

        private void LbxBands_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Band selectedband = lbxBands.SelectedItem as Band;

            if(selectedband != null)
            {
                //Display Band Info
                string bandtext = $"{selectedband.YearFormed}\nMembers: {selectedband.Members}";
                tblkBandinfo.Text = bandtext;


                //display Band Image
                imgBand.Source = new BitmapImage(new Uri($"/Images/{selectedband.BandImage}",UriKind.Relative));
                //Display albums


                lbxAlbums.ItemsSource = selectedband.Albums;
            }

        }
    }
}
