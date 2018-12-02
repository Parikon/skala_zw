using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace skala_zw
{
    /// <summary>
    /// Logika interakcji dla klasy UserControl1_skala.xaml
    /// </summary>
    public partial class UserControl1_skala : UserControl
    {
        string[] skala_zdefiniowana = { "1", "2", "5", "10", "20", "25", "50", "75", "100", "200", "250", "500", "1000" };

        public UserControl1_skala()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                //ikona okna
                string sciezka = PiZwTools.path + "\\pi_icon32x32.ico";
                Uri iconUri = new Uri(sciezka, UriKind.RelativeOrAbsolute);
                if (File.Exists(sciezka) == true) Window.GetWindow(this).Icon = BitmapFrame.Create(iconUri);
                //dodanie ikonki do przycisku OK
                Bitmap bm = Resource1.pi_icon_png;
                image_ok.Source = PiZwTools.Konwersja_bitmap_bitmapimage_png(bm);
                //dodaje obrazek do kontrolki image w zakładce info
                bm = Resource1._286090478539097a3198af;
                image_WaGaCAD.Source = PiZwTools.Konwersja_bitmap_bitmapimage_png(bm);

                //ustawienie radiobutton grupy styl
                Ustawienia_Styl_wejscie(Settings1.Default.Styl);

                //dodanie bloków i stylu wymiarowania
                PiZwTools.Wymiary_bloki();
                PiZwTools.Dodaj_styl_PI_STANDARD();

                //ustawienie wartości w textboxskala oraz model jednostki
                combobox_skala.ItemsSource = skala_zdefiniowana;

                if (PiZwTools.INSUNITS() == 4)
                {
                    textbox_skala.Text = (PiZwTools.DIMSCALA()).ToString();
                    radio_model_milimetry.IsChecked = true;
                    if (PiZwTools.DIMLFAC() == 1.0)
                    {
                        radio_wymiar_milimetry.IsChecked = true;
                    }
                    else
                    {
                        if (PiZwTools.DIMLFAC() == 0.1)
                        { radio_wymiar_centymetry.IsChecked = true; }
                        else
                        {
                            if (PiZwTools.DIMLFAC() == 0.001)
                            {
                                radio_wymiar_metry.IsChecked = true;
                            }
                            else
                            {
                                radio_wymiar_milimetry.IsChecked = true;
                            }
                        }

                    }
                }
                else
                {
                    if (PiZwTools.INSUNITS() == 5)
                    {
                        textbox_skala.Text = (PiZwTools.DIMSCALA() * 10).ToString();
                        radio_model_centymetry.IsChecked = true;
                        if (PiZwTools.DIMLFAC() == 10)
                        {
                            radio_wymiar_milimetry.IsChecked = true;
                        }
                        else
                        {
                            if (PiZwTools.DIMLFAC() == 1.0)
                            {
                                radio_wymiar_centymetry.IsChecked = true;
                            }
                            else
                            {
                                if (PiZwTools.DIMLFAC() == 0.01)
                                {
                                    radio_wymiar_metry.IsChecked = true;
                                }
                                else
                                {
                                    radio_wymiar_milimetry.IsChecked = true;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (PiZwTools.INSUNITS() == 6)
                        {
                            textbox_skala.Text = (PiZwTools.DIMSCALA() * 1000).ToString();
                            radio_model_metry.IsChecked = true;
                            if (PiZwTools.DIMLFAC() == 1000)
                            {
                                radio_wymiar_milimetry.IsChecked = true;
                            }
                            else
                            {
                                if (PiZwTools.DIMLFAC() == 100)
                                {
                                    radio_wymiar_centymetry.IsChecked = true;
                                }
                                else
                                {
                                    if (PiZwTools.DIMLFAC() == 1)
                                    {
                                        radio_wymiar_metry.IsChecked = true;
                                    }
                                    else
                                    {
                                        radio_wymiar_milimetry.IsChecked = true;
                                    }
                                }
                            }
                        }
                        else
                        {
                            radio_model_milimetry.IsChecked = true;
                            radio_wymiar_milimetry.IsChecked = true;
                        }
                    }
                }

                //ustawienia miejs po przecinku

                if (PiZwTools.DIMDEC() == 0)
                {
                    radio_miejsc_zero.IsChecked = true;
                    //fokus textxtbox
                    textbox_skala.Focus(); //ustawia kursor
                    textbox_skala.SelectionStart = 0;
                    textbox_skala.SelectionLength = textbox_skala.Text.Length;
                }
                else
                {
                    if (PiZwTools.DIMDEC() == 1)
                    {
                        radio_miejsc_jedno.IsChecked = true;
                        //fokus textxtbox
                        textbox_skala.Focus(); //ustawia kursor
                        textbox_skala.SelectionStart = 0;
                        textbox_skala.SelectionLength = textbox_skala.Text.Length;
                    }
                    else
                    {
                        if (PiZwTools.DIMDEC() == 2)
                        {
                            radio_miejsc_dwa.IsChecked = true;
                            //fokus textxtbox
                            textbox_skala.Focus(); //ustawia kursor
                            textbox_skala.SelectionStart = 0;
                            textbox_skala.SelectionLength = textbox_skala.Text.Length;
                        }
                        else
                        {
                            if (PiZwTools.DIMDEC() == 3)
                            {
                                radio_miejsc_trzy.IsChecked = true;
                                //fokus textxtbox
                                textbox_skala.Focus(); //ustawia kursor
                                textbox_skala.SelectionStart = 0;
                                textbox_skala.SelectionLength = textbox_skala.Text.Length;
                            }
                            else
                            {
                                radio_miejsc_zero.IsChecked = true;
                                //fokus textxtbox
                                textbox_skala.Focus(); //ustawia kursor
                                textbox_skala.SelectionStart = 0;
                                textbox_skala.SelectionLength = textbox_skala.Text.Length;
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "PI-INFO");
                Window.GetWindow(this).Close();
            }

        }

        public void Ustawienia_Styl_wejscie(string nazwa)
        {
            if (nazwa == radio_styl_architektura.Content.ToString()) radio_styl_architektura.IsChecked = true;
            if (nazwa == radio_styl_stal.Content.ToString()) radio_styl_stal.IsChecked = true;
            if (nazwa == radio_styl_beton.Content.ToString()) radio_styl_beton.IsChecked = true;
            if (nazwa == radio_styl_zbrojenie.Content.ToString()) radio_styl_zbrojenie.IsChecked = true;
        }

        public string Ustawienia_Styl_wyjscie()
        {
            string nazwa = null;
            if (radio_styl_architektura.IsChecked == true) nazwa = radio_styl_architektura.Content.ToString();
            if (radio_styl_stal.IsChecked == true) nazwa = radio_styl_stal.Content.ToString();
            if (radio_styl_beton.IsChecked == true) nazwa = radio_styl_beton.Content.ToString();
            if (radio_styl_zbrojenie.IsChecked == true) nazwa = radio_styl_zbrojenie.Content.ToString();
            return nazwa;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double liczba;
            bool results = double.TryParse(textbox_skala.Text.Replace(".", ","), out liczba);

            if (results == false)
            {

                MessageBox.Show("Nieprawidłowy format danych", "PI-INFO");
                //fokus textxtbox
                textbox_skala.Focus(); //ustawia kursor
                textbox_skala.SelectionStart = 0;
                textbox_skala.SelectionLength = textbox_skala.Text.Length;

            }
            else if (liczba <= 0)
            {
                MessageBox.Show("Skala nie może być zerem lub liczbą ujemną", "PI-INFO");
                //fokus textxtbox
                textbox_skala.Focus(); //ustawia kursor
                textbox_skala.SelectionStart = 0;
                textbox_skala.SelectionLength = textbox_skala.Text.Length;
            }
            else
            {
                // ustawiamy styl
                if (radio_styl_architektura.IsChecked == true) PiZwTools.Ustawstyl("PI_grotplany");
                if (radio_styl_beton.IsChecked == true) PiZwTools.Ustawstyl("PI_grotbeton");
                if (radio_styl_stal.IsChecked == true) PiZwTools.Ustawstyl("PI_grotstal");
                if (radio_styl_zbrojenie.IsChecked == true) PiZwTools.Ustawstyl("PI_grotzbrojenie");
                //zapisujemy styl
                Settings1.Default.Styl = Ustawienia_Styl_wyjscie();

                //ustawiamy insunist
                if (radio_model_milimetry.IsChecked == true) PiZwTools.UstawINSUNITS(4);
                if (radio_model_centymetry.IsChecked == true) PiZwTools.UstawINSUNITS(5);
                if (radio_model_metry.IsChecked == true) PiZwTools.UstawINSUNITS(6);
                //ustawiamy dimdec czyli miejsca po przecinku
                if (radio_miejsc_zero.IsChecked == true) PiZwTools.UstawDIMDEC(0);
                if (radio_miejsc_jedno.IsChecked == true) PiZwTools.UstawDIMDEC(1);
                if (radio_miejsc_dwa.IsChecked == true) PiZwTools.UstawDIMDEC(2);
                if (radio_miejsc_trzy.IsChecked == true) PiZwTools.UstawDIMDEC(3);

                //ustawienie zmiennej DIMLFAC
                //wymiar metry - model metry
                if (radio_wymiar_metry.IsChecked == true & radio_model_metry.IsChecked == true) PiZwTools.Ustawdokladnosc(1.0);
                //wymiar metry - model centymetry
                if (radio_wymiar_metry.IsChecked == true & radio_model_centymetry.IsChecked == true) PiZwTools.Ustawdokladnosc(0.01);
                //wymiar metry - model milimetry
                if (radio_wymiar_metry.IsChecked == true & radio_model_milimetry.IsChecked == true) PiZwTools.Ustawdokladnosc(0.001);
                //wymiar centymetry - model metry
                if (radio_wymiar_centymetry.IsChecked == true & radio_model_metry.IsChecked == true) PiZwTools.Ustawdokladnosc(100.0);
                //wymiar centymetry - model centymetry
                if (radio_wymiar_centymetry.IsChecked == true & radio_model_centymetry.IsChecked == true) PiZwTools.Ustawdokladnosc(1.0);
                //wymiar centymetry - model milimetry
                if (radio_wymiar_centymetry.IsChecked == true & radio_model_milimetry.IsChecked == true) PiZwTools.Ustawdokladnosc(0.1);
                //wymiar milimetry - model metry
                if (radio_wymiar_milimetry.IsChecked == true & radio_model_metry.IsChecked == true) PiZwTools.Ustawdokladnosc(1000.0);
                //wymiar milimetry - model centymetry
                if (radio_wymiar_milimetry.IsChecked == true & radio_model_centymetry.IsChecked == true) PiZwTools.Ustawdokladnosc(10.0);
                //wymiar milimetry - model milimetrymetry
                if (radio_wymiar_milimetry.IsChecked == true & radio_model_milimetry.IsChecked == true) PiZwTools.Ustawdokladnosc(1.0);

                //ustawienie zmiennej dimscale
                if (radio_model_metry.IsChecked == true) PiZwTools.Ustawdimscale(Convert.ToDouble(liczba));
                if (radio_model_centymetry.IsChecked == true) PiZwTools.Ustawdimscale(Convert.ToDouble(liczba) * 100);
                if (radio_model_milimetry.IsChecked == true) PiZwTools.Ustawdimscale(Convert.ToDouble(liczba) * 1000);

                //Zamykamy okno
                Window.GetWindow(this).Close();
            }
        }

        private void combobox_skala_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (combobox_skala.SelectedIndex != -1)
            {
                textbox_skala.Text = combobox_skala.SelectedValue.ToString();
                textbox_skala.Focus(); //ustawia kursor
                textbox_skala.SelectionStart = 0;
                textbox_skala.SelectionLength = textbox_skala.Text.Length;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Process.Start("www.przybornik.parikon.pl");
        }
    }
}
