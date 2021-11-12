using Prueb_GitHub.Entity;
using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Prueb_GitHub.Views
{
    /// <summary>
    /// Lógica de interacción para afegirTasca.xaml
    /// </summary>
    public partial class afegirTasca : Window
    {
        public afegirTasca()
        {
            InitializeComponent();
        }
        //quan l'usuari clica sobre el button afegir
        private void btn_agregar_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                //afageix un nou item al listview
                lvTasca.Items.Add(new Tasca()
                {
                    
                    Id = int.Parse(txt_id.Text),
                    Nom = txt_nomTasca.Text,
                    Descripcio = txt_descripcio.Text,
                    DInici = (DateTime)datepicker_data_inici.SelectedDate,
                    DFinal = (DateTime)datepicker_data_final.SelectedDate,
                    Prioritat_id = (cmb_prioritat.SelectedItem as ComboBoxItem).Content.ToString(), //transforma el valor del item seleccionat
                    Responsable_id = (cmb_responsable.SelectedItem as ComboBoxItem).Content.ToString(), //transforma el valor del item seleccionat
                    Estat_id = (cmb_estat.SelectedItem as ComboBoxItem).Content.ToString() //transforma el valor del item seleccionat
                });
<<<<<<< Updated upstream

                netejaCamps();
=======
                
>>>>>>> Stashed changes
            }
            catch (Exception)
            {
                MessageBox.Show("Has d'omplir tots els camps");
            }
        }

        private void btn_modificar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //creem un nou item al listview
                Tasca tasca_mod = new Tasca(

                    int.Parse(txt_id.Text),
                    txt_nomTasca.Text,txt_descripcio.Text,
                    (DateTime)datepicker_data_inici.SelectedDate,
                    (DateTime)datepicker_data_final.SelectedDate,
                    (cmb_prioritat.SelectedItem as ComboBoxItem).Content.ToString(), //transforma el valor del item seleccionat
                    (cmb_responsable.SelectedItem as ComboBoxItem).Content.ToString(), //transforma el valor del item seleccionat
                    (cmb_estat.SelectedItem as ComboBoxItem).Content.ToString() //transforma el valor del item seleccionat
                );
                //intercanvia l'item seleccionat per el que acabem de crear
                lvTasca.Items.Insert(lvTasca.SelectedIndex, tasca_mod);

                netejaCamps();
            }
            catch (Exception)
            {
                MessageBox.Show("Has de seleccionar una tasca i omplir tots els camps", "Informacio", MessageBoxButton.OK, MessageBoxImage.Information);
                
            }
        }

        // quan l'usuari clica sobre el button eliminar
        private void btn_eliminar_Click(object sender, RoutedEventArgs e)
        {
            try //faig un trycatch per asegurarme que l'usuari ha seleccionat un item previament
            {
                //elimina el item seleccionat
                lvTasca.Items.RemoveAt(lvTasca.SelectedIndex);
                netejaCamps();

            }
            catch (Exception)
            {
                MessageBox.Show("Has de seleccionar una tasca", "Informacio", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        //metode per netejar els camps
        public void netejaCamps()
        {
            txt_id.Text = "";
            txt_nomTasca.Text = "";
            txt_descripcio.Text = "";
            datepicker_data_inici.SelectedDate = null;
            datepicker_data_inici.SelectedDate = null;
            cmb_prioritat.SelectedItem = null;
            cmb_responsable.SelectedItem = null;
            cmb_estat.SelectedItem = null;

        }

        //Aques event s'aplica sobre el textbox id  
        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            //si la tecla es un nuemero
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
                //permet introduir valors
                e.Handled = false;
            else
                //si no no permet introduir valors
                e.Handled = true;
        }

        private void lvTasca_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Console.WriteLine(lvTasca.SelectedItem.ToString());
            lvTasca.GetValue();
        }
    }
}
