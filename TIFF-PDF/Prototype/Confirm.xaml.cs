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
using MySql.Data.MySqlClient;
using System.Data;

namespace Prototype2
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Confirm : Window
    {
        string con = "Server=localhost; Port=3306; Database=prototypedb; Uid=root; Pwd=h2d.8ByPUDgzZN3;";
        Add add = new Add();

        public Confirm()
        {
            InitializeComponent();
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            Hide();
        }

        private void btn_yes_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(con);
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("DELETE from client_tb where id = @id", conn);

                cmd.Parameters.AddWithValue("@id", txt_id.Text);
                cmd.ExecuteNonQuery();

                conn.Close();
                MessageBox.Show("Record deleted.");
                add.clear();
                add.datagridview();
                add.btn_save.IsEnabled = true;
                add.btn_update.IsEnabled = false;
                Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_no_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Operation cancelled.");
            Hide();
        }
    }
}
