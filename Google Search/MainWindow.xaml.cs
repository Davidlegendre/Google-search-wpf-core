using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Google_Search
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SolidColorBrush borderPadreBorderBrushNormal = new SolidColorBrush(Color.FromArgb(50, 106, 90, 205));
        SolidColorBrush borderPadreBorderBrushActive = new SolidColorBrush(Color.FromArgb(100, 106, 90, 205));
        SolidColorBrush buttonSearchBackgroundNormal = new SolidColorBrush(Color.FromRgb(21,21,21));
        SolidColorBrush buttonSearchBackgroundActive = new SolidColorBrush(Color.FromRgb(82, 77, 77));
        double puntitoWidthNormal = 7, puntitoWidthActive = 10, puntitoHeightNormal = 7, puntitoHeightActive = 10;
        Thickness puntitoMarginNormal = new Thickness(20, 0, 0, 0);
        Thickness puntitoMarginActive = new Thickness(18, 0, 0, 0);
        string urlApiGoogle = "https://www.google.com/search?q=";
        bool isActiveText = false;
        //60,57,57

        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            borderPadre.BorderBrush = borderPadreBorderBrushNormal;
            btnSearch.Background = buttonSearchBackgroundNormal;
            txtSearch.Focus();
        }

        private void borderPadre_MouseEnter(object sender, MouseEventArgs e)
        {
            if(!isActiveText)
                borderPadre.BorderBrush = borderPadreBorderBrushActive;
        }

        private void borderPadre_MouseLeave(object sender, MouseEventArgs e)
        {
            if(!isActiveText)
                borderPadre.BorderBrush = borderPadreBorderBrushNormal;
        }

        private void btnSearch_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            buscar();
        }

        private void txtSearch_GotFocus(object sender, RoutedEventArgs e)
        {
            borderPadre.BorderBrush = borderPadreBorderBrushActive;

            isActiveText = true;
        }

        private void txtSearch_LostFocus(object sender, RoutedEventArgs e)
        {
            isActiveText = false;
        }

        private void btnSearch_MouseEnter(object sender, MouseEventArgs e)
        {
            btnSearch.Background = buttonSearchBackgroundActive;
        }

        private void btnSearch_MouseLeave(object sender, MouseEventArgs e)
        {
            btnSearch.Background = buttonSearchBackgroundNormal;
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
                buscar();

            if (e.Key == Key.Escape)
                txtSearch.Clear();

        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtSearch.Text.Length > 0)
            {
                texthint.Visibility = Visibility.Collapsed;
                puntito.Width = puntitoWidthActive;
                puntito.Height = puntitoHeightActive;
                puntito.Opacity = 1;
                puntito.Margin = puntitoMarginActive;
            }
            else {
                texthint.Visibility = Visibility.Visible;
                puntito.Width = puntitoWidthNormal;
                puntito.Height = puntitoHeightNormal;
                puntito.Opacity = 0.5; puntito.Margin = puntitoMarginNormal;
            }

            

        }

        void gotoSite(string url) {
            Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
        }


        void buscar() {
            if (!string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                gotoSite(urlApiGoogle + txtSearch.Text);
                txtSearch.Clear();
            }
        }

    }
}
