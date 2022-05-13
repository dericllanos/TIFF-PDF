using System;
using System.Windows;
using MySql.Data.MySqlClient;
using System.Data;

namespace Prototype2
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public static int usertype;
        string con = "Server=localhost; Port=3306; Database=prototypedb; Uid=root; Pwd=h2d.8ByPUDgzZN3;";
        MainWindow mw = new MainWindow();

        public Login()
        {
            InitializeComponent();
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            // Shutdown the application.
            Application.Current.Shutdown();
            // OR You can Also go for below logic
            // Environment.Exit(0);
        }

        private void btn_login_Click(object sender, RoutedEventArgs e)
        { 
            try
            {
                if (txt_user.Text == "" || txt_pass.Password == "")
                {
                    MessageBox.Show("Authentication is required.");
                }

                else
                {
                    MySqlConnection conn = new MySqlConnection(con);
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("select * from admin_tb where user = @u and pass = @p ", conn);
                    cmd.Parameters.AddWithValue("@u", txt_user.Text);
                    cmd.Parameters.AddWithValue("@p", txt_pass.Password);
                    MySqlDataAdapter adapt = new MySqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    adapt.Fill(ds);
                    
                    MySqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();
                    var u_type = dr.GetValue(3).ToString();
                    dr.Read();

                    int count = ds.Tables[0].Rows.Count;

                    if (count == 1 && u_type == "admin")
                    {
                        usertype = 1;
                        MessageBox.Show("Welcome Admin.");

                        mw.Show();
                        //mw.checkbox1.IsChecked = true;
                        //mw.btn_edit.IsEnabled = true;
                        this.Hide();
                    }
                    else if (count == 1 && u_type == "read")
                    {
                        usertype = 2;
                        MessageBox.Show("Welcome User.");

                        mw.Show();
                        //mw.checkbox1.IsChecked = true;
                        //mw.btn_edit.IsEnabled = true;
                        this.Hide();
                        //mw.btn_export.Visibility = Visibility.Hidden;
                        mw.btn_export.IsEnabled = false;
                        mw.btn_add2.Visibility = Visibility.Hidden;
                    }

                    else
                    {
                        MessageBox.Show("Invalid credentials.");
                    }
                    conn.Close();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " \n                              *Invalid credentials.*");
            }          
        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
