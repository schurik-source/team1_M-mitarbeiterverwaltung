using klassen_Bibliothek;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace mitarbeiterverwaltung
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Mitarbeiter> Mitarbeiterliste = new List<Mitarbeiter>();
        public MainWindow()
        {
            InitializeComponent();
            MySqlConnection conect = new MySqlConnection("Server=localhost;Database=Team1;Uid=root");
            conect.Open();
            MySqlCommand comman = new MySqlCommand("select * from t_mitarbeiter", conect);
            
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(comman);
            da.Fill(dt);
            Dg_Mitarbeiter.ItemsSource = dt.DefaultView;
           
            

            //List<Mitarbeiter> daten = new List<Mitarbeiter>();

            //while (myreader.Read())

            //{

            //    var stroka = $"{myreader[0]}: {myreader[1]}: {myreader[2]} : {myreader[3]} : {myreader[4]}";

            //    daten.Add(stroka);

            //}
            //Dg_Mitarbeiter.ItemsSource = daten;
            //foreach (var item in daten)
            //{
            //    ListMA.Items.Add(item);

            //}
            
            conect.Close();

            //Dg_Mitarbeiter.ItemsSource = daten.ToList().DefaultIfEmpty();

            //testdatenLaden();
            //Dg_Mitarbeiter.ItemsSource = Mitarbeiterliste;
        }
        void testdatenLaden()
        {
            Mitarbeiterliste.Add(new Mitarbeiter("Hans", "Wurst", new DateTime(1980,12,12) ,1, Position.Geschäftsführer, Abteilung.Personal, new DateTime(2020, 02, 13), 2000, new Bankverbindung(789456123, 456456, "Spardabank"), new KontaktDaten(new Adresse("Beispielstr.", "66a", "90402", "Nürnberg"), "hans@wurst.bsp", "0911-6548945")));
            Mitarbeiterliste.Add(new Mitarbeiter("Peter", "Hubert", new DateTime(1981, 11, 05), 2, Position.Geschäftsführer, Abteilung.Personal, new DateTime(2020, 02, 13), 2000, new Bankverbindung(789456123, 456456, "Spardabank"), new KontaktDaten(new Adresse("Beispielstr.", "66a", "90402", "Nürnberg"), "hans@wurst.bsp", "0911-6548945")));


            //Kundenliste[0].Termine.Add(new termin(new DateTime(2020, 02, 13, 11, 00, 00), new DateTime(2020, 02, 13, 13, 00, 00), "Guter Kunde", Grund.Service));
            //Kundenliste[0].Termine.Add(new termin(new DateTime(2020, 02, 14, 13, 00, 00), new DateTime(2020, 02, 15, 13, 00, 00), "Guter Kunde", Grund.Service));
            //Kundenliste[1].Termine.Add(new termin(new DateTime(2020, 02, 14, 11, 00, 00), new DateTime(2020, 02, 13, 13, 00, 00), "Schlechter Kunde", Grund.Service));

        }

        private void Mitarbeiter_anlegen(object sender, RoutedEventArgs e)
        {
            Mitarbeiter_Anlegen_Andern maaf = new Mitarbeiter_Anlegen_Andern(Mitarbeiterliste, -1);
            maaf.ShowDialog();

            //Dg_Mitarbeiter.ItemsSource = null;
            //Dg_Mitarbeiter.ItemsSource = Mitarbeiterliste;
        }

        private void Button_berarbeiten(object sender, RoutedEventArgs e)
        {
            Mitarbeiter_Anlegen_Andern maaf = new Mitarbeiter_Anlegen_Andern(Mitarbeiterliste, Dg_Mitarbeiter.SelectedIndex);
            
            maaf.ShowDialog();
            //Dg_Mitarbeiter.ItemsSource = null;
            //Dg_Mitarbeiter.ItemsSource = dt.DefaultView;
        }
    }
}
