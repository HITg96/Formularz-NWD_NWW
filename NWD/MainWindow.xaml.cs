using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace NWD
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

        private void NWD_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(liczba1.Text, out int a) && int.TryParse(liczba2.Text, out int b))
            {
                int wynik = nwd(a, b);
                wyniki.Text = "Największy wspólny dzielnik " + a + " i " + b + " wynosi: " + wynik;
            }
        }

        private int nwd(int a, int b)
        {
            while (b != 0)
            {
                int reszta = a % b;
                a = b;
                b = reszta;
            }
            return a;
        }

        private void NWW_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(liczba1.Text, out int a) && int.TryParse(liczba2.Text, out int b))
            {
                int wynik1 = nww(a, b);
                wyniki.Text = "Największa wspólna wielokrotność liczby " + a + " i " + b + " wynosi: " + wynik1;
            }

        }

        private int nww(int a, int b)
        {
            if (a != 0 && b != 0) {
                int dzialanie = (a * b) / nwd(a, b);
                return dzialanie;
            }
            else
            {
                int dzialanie = 0;
                return dzialanie;
            }
        }

        private void Click_Nowy(object sender, RoutedEventArgs e)
        {
            liczba1.Clear();
            liczba2.Clear();
            wyniki.Text = "";
        }

        private void Click_Zapisz(object sender, RoutedEventArgs e)
        {
            SaveFileDialog oknoZapisu = new SaveFileDialog();
            oknoZapisu.Filter = "PlainText | *.txt";
            oknoZapisu.Title = "Zapisywanie";
            if (oknoZapisu.ShowDialog() == true)
                File.WriteAllText(oknoZapisu.FileName, wyniki.Text);
            File.AppendAllText(oknoZapisu.FileName, "\nLiczba 1:  " + liczba1.Text);
            File.AppendAllText(oknoZapisu.FileName, "\nLiczba 2:  " + liczba2.Text);
        }


        private void Click_Oblicz(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(liczba1.Text, out int a) && int.TryParse(liczba2.Text, out int b))
            {
                wyniki.Text = "NWD wynosi: " + nwd(a, b).ToString() + "\nNWW wynosi " + (a * b / nwd(a, b)).ToString();
            }
        }

        private void Click_Zielony(object sender, RoutedEventArgs e)
        {
            Background = System.Windows.Media.Brushes.Green;
        }
        private void Click_Niebieski(object sender, RoutedEventArgs e)
        {
            Background = System.Windows.Media.Brushes.Blue;
        }
        private void Click_Mala(object sender, RoutedEventArgs e)
        {
            FontSize = 14;
        }
        private void Click_Duza(object sender, RoutedEventArgs e)
        {
            FontSize = 20;
        }
        private void OProgramieClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Autor: Michał Tomaszewski", "Wersja: 0.0.8", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
        private void InstrukcjaClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("NWW to Najmniejsza wspólna wielokrotność: (a*b) / NWD(a, b), a NWD to Największy wspólny dzielnik (można obliczyć poprzez rozkład na czynniki)", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}