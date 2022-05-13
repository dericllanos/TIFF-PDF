using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using MySql.Data.MySqlClient;
using System.Data;
using System.IO;
using Microsoft.Win32;
using System.Text.RegularExpressions;

namespace Prototype2
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Add : Window
    {
        string con = "Server=localhost; Port=3306; Database=prototypedb; Uid=root; Pwd=h2d.8ByPUDgzZN3;";

        public Add()
        {
            InitializeComponent();
            datagridview();

            btn_update.IsEnabled = false;
        }


        private void btn_done_Click(object sender, RoutedEventArgs e)
        {
            //MainWindow mainwindow = new MainWindow();
            //mainwindow.Show();
            this.Hide();
        }

        public void datagridview()
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(con);
                MySqlCommand cmd = new MySqlCommand("select id, CONCAT (client_fname,' ', client_lname) AS client_name, client_desc, client_type, scan_date, doc_type, archive, client_key, pdf_file from client_tb", conn);
                conn.Open();

                DataTable dt = new DataTable();
                MySqlDataAdapter adapt = new MySqlDataAdapter(cmd);
                dt.Load(cmd.ExecuteReader());
                adapt.Fill(dt);
                dataGrid2.ItemsSource = dt.DefaultView;

                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void clear()
        {
            txt_id.Text = "";
            txt_cname.Text = "";
            txt_ctype.Text = "";
            txt_ckey.Text = "";
            txt_desc.Text = "";
            txt_doctype.Text = "";
            txt_archive.Text = "";
            txt_scandate.Text = "";
            txt_filelocation.Text = "";    
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {           
            if (txt_cname.Text == "" || txt_desc.Text == "" || txt_ctype.Text == "" || txt_scandate.Text == "" || txt_doctype.Text == "" ||
                txt_archive.Text == "" || txt_ckey.Text == "" || txt_filelocation.Text == "")
            {
                MessageBox.Show("Field required.");

                if (txt_cname.Text == "")
                {
                    txt_cname.BorderThickness = new Thickness(1.5);
                    txt_cname.BorderBrush = new SolidColorBrush(Colors.Red);
                }

                else if (txt_ckey.Text == "")
                {
                    txt_ckey.BorderThickness = new Thickness(1.5);
                    txt_ckey.BorderBrush = new SolidColorBrush(Colors.Red);
                }

                else if (txt_ctype.Text == "")
                {
                    txt_ctype.BorderThickness = new Thickness(1.5);
                    txt_ctype.BorderBrush = new SolidColorBrush(Colors.Red);
                }

                else if (txt_desc.Text == "")
                {
                    txt_desc.BorderThickness = new Thickness(1.5);
                    txt_desc.BorderBrush = new SolidColorBrush(Colors.Red);
                }

                else if (txt_doctype.Text == "")
                {
                    txt_doctype.BorderThickness = new Thickness(1.5);
                    txt_doctype.BorderBrush = new SolidColorBrush(Colors.Red);
                }

                else if (txt_archive.Text == "")
                {
                    txt_archive.BorderThickness = new Thickness(1.5);
                    txt_archive.BorderBrush = new SolidColorBrush(Colors.Red);
                }

                else if (txt_scandate.Text == "")
                {
                    txt_scandate.BorderThickness = new Thickness(1.5);
                    txt_scandate.BorderBrush = new SolidColorBrush(Colors.Red);
                }

                else if (txt_filelocation.Text == "")
                {
                    txt_filelocation.BorderThickness = new Thickness(1.5);
                    txt_filelocation.BorderBrush = new SolidColorBrush(Colors.Red);
                }
            }

            else 
            {
                try
                {
                    MySqlConnection conn = new MySqlConnection(con);
                    conn.Open();

                    MySqlCommand cmd1 = conn.CreateCommand();
                    cmd1.CommandText = "select * from client_tb where client_key = @ck ";
                    cmd1.Parameters.AddWithValue("@ck", txt_ckey.Text);

                    MySqlDataReader dr = cmd1.ExecuteReader();
                    conn.Close();

                    if (dr.HasRows)
                    {
                        MessageBox.Show("Key already exists.");
                        txt_ckey.BorderThickness = new Thickness(1.5);
                        txt_ckey.BorderBrush = new SolidColorBrush(Colors.Red);
                    }

                    else
                    {
                        conn.Open();

                        MySqlCommand cmd2 = conn.CreateCommand();
                        cmd2.CommandText = "insert into client_tb (client_fname, client_lname, client_desc, client_type, scan_date, doc_type, archive, client_key, pdf_file) values (@cfn, @cln, @cd, @ct, @sd, @dt, @a, @ck, @fl) ";
                        cmd2.Parameters.AddWithValue("@cfn", Regex.Replace(txt_cname.Text.Split()[0], @"[^0-9a-zA-Z\ ]+", ""));
                        cmd2.Parameters.AddWithValue("@cln", Regex.Replace(txt_cname.Text.Split()[1], @"[^0-9a-zA-Z\ ]+", ""));
                        cmd2.Parameters.AddWithValue("@cd", txt_desc.Text);
                        cmd2.Parameters.AddWithValue("@ct", txt_ctype.Text);
                        cmd2.Parameters.AddWithValue("@sd", txt_scandate.SelectedDate);
                        cmd2.Parameters.AddWithValue("@dt", txt_doctype.Text);
                        cmd2.Parameters.AddWithValue("@a", txt_archive.Text);
                        cmd2.Parameters.AddWithValue("@ck", txt_ckey.Text);
                        cmd2.Parameters.AddWithValue("@fl", txt_filelocation.Text);
                        cmd2.ExecuteNonQuery();
                        conn.Close();

                        MessageBox.Show("Record saved successfully.");
                        clear();
                        datagridview();

                        txt_cname.BorderThickness = new Thickness(1.0);
                        txt_cname.BorderBrush = new SolidColorBrush(Colors.Gray);
                        txt_ctype.BorderThickness = new Thickness(1.0);
                        txt_ctype.BorderBrush = new SolidColorBrush(Colors.Gray);
                        txt_ckey.BorderThickness = new Thickness(1.0);
                        txt_ckey.BorderBrush = new SolidColorBrush(Colors.Gray);
                        txt_desc.BorderThickness = new Thickness(1.0);
                        txt_desc.BorderBrush = new SolidColorBrush(Colors.Gray);
                        txt_doctype.BorderThickness = new Thickness(1.0);
                        txt_doctype.BorderBrush = new SolidColorBrush(Colors.Gray);
                        txt_archive.BorderThickness = new Thickness(1.0);
                        txt_archive.BorderBrush = new SolidColorBrush(Colors.Gray);
                        txt_scandate.BorderThickness = new Thickness(1.0);
                        txt_scandate.BorderBrush = new SolidColorBrush(Colors.Gray);
                        txt_filelocation.BorderThickness = new Thickness(1.0);
                        txt_filelocation.BorderBrush = new SolidColorBrush(Colors.Gray);
                    }   
                }

                catch (Exception ex)
                {
                    txt_cname.BorderThickness = new Thickness(1.5);
                    txt_cname.BorderBrush = new SolidColorBrush(Colors.Red);
                    MessageBox.Show(ex.Message + " \n               *Please include a lastname.*");
                }
            }
        }
        private void dataGrid2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            /*btn_update.IsEnabled = true;
            btn_save.IsEnabled = false;
            DataGrid dg = (DataGrid)sender;
            DataRowView selected = dg.SelectedItem as DataRowView;

            if (selected != null)
            {
                txt_id.Text = selected[0].ToString();
                txt_cname.Text = selected[1].ToString();
                txt_desc.Text = selected[2].ToString();
                txt_ctype.Text = selected[3].ToString();
                txt_scandate.Text = selected[4].ToString();
                txt_doctype.Text = selected[5].ToString();
                txt_startdate.Text = selected[6].ToString();
                txt_enddate.Text = selected[7].ToString();
                txt_archive.Text = selected[8].ToString();
                txt_ckey.Text = selected[9].ToString();
                txt_filelocation.Text = selected[10].ToString();
            }*/
        }

        private void btn_update_Click(object sender, RoutedEventArgs e)
        {
            if (txt_id.Text != "")
            {
                try
                {
                    MySqlConnection conn = new MySqlConnection(con);
                    conn.Open();

                    MySqlCommand cmd = new MySqlCommand("update client_tb set client_fname = @cfn, client_lname = @cln, client_desc = @cd, client_type = @ct, scan_date = @sd, doc_type = @dt, archive = @a, client_key = @ck, pdf_file = @fl where id = @id", conn);

                    cmd.Parameters.AddWithValue("@cfn", Regex.Replace(txt_cname.Text.Split()[0], @"[^0-9a-zA-Z\ ]+", ""));
                    cmd.Parameters.AddWithValue("@cln", Regex.Replace(txt_cname.Text.Split()[1], @"[^0-9a-zA-Z\ ]+", ""));
                    cmd.Parameters.AddWithValue("@cd", txt_desc.Text);
                    cmd.Parameters.AddWithValue("@ct", txt_ctype.Text);
                    cmd.Parameters.AddWithValue("@sd", txt_scandate.SelectedDate);
                    cmd.Parameters.AddWithValue("@dt", txt_doctype.Text);
                    cmd.Parameters.AddWithValue("@a", txt_archive.Text);
                    cmd.Parameters.AddWithValue("@ck", txt_ckey.Text);
                    cmd.Parameters.AddWithValue("@fl", txt_filelocation.Text);
                    cmd.Parameters.AddWithValue("@id", txt_id.Text);
                    cmd.ExecuteNonQuery();

                    conn.Close();
                    MessageBox.Show("Record updated successfully.");
                    clear();
                    datagridview();
                    btn_save.IsEnabled = true;
                    btn_update.IsEnabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            else
            {
                MessageBox.Show("No Rows selected.");   
            }
        }

        private void btn_undo_Click(object sender, RoutedEventArgs e)
        {

        }

        private void dataGrid2_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            btn_update.IsEnabled = true;
            btn_save.IsEnabled = false;
            DataGrid dg = (DataGrid)sender;
            DataRowView selected = dg.SelectedItem as DataRowView;

            if (selected != null)
            {
                txt_id.Text = selected[0].ToString();
                txt_cname.Text = selected[1].ToString();
                txt_desc.Text = selected[2].ToString();
                txt_ctype.Text = selected[3].ToString();
                txt_scandate.Text = selected[4].ToString();
                txt_doctype.Text = selected[5].ToString();
                txt_archive.Text = selected[6].ToString();
                txt_ckey.Text = selected[7].ToString();
                txt_filelocation.Text = selected[8].ToString();
            }
        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            btn_save.IsEnabled = true;
            btn_update.IsEnabled = false;
            clear();
            datagridview();
        }

        private void btn_browse_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "All Files (*.*)|*.*";
            op.FilterIndex = 1;
            op.Multiselect = true;

            if (op.ShowDialog() == true)
            {
                string path = op.FileName;
                string replacement = path.Replace(@"\", "/");
                string source = Path.GetExtension(op.FileName);

                txt_filelocation.Text = replacement;
                txt_doctype.Text = source;
            }
        }

        private void btn_delete_Click(object sender, RoutedEventArgs e)
        {
            if (txt_id.Text != "")
            { 
                Confirm conf = new Confirm();
                conf.txt_id.Text = txt_id.Text;
                conf.Show();        
            }

            else
            {
                MessageBox.Show("No row selected.");
            }
        }
    }
}
