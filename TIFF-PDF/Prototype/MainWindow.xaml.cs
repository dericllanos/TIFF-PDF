using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MySql.Data.MySqlClient;
using System.Data;
using System.IO;
using iTextSharp.text.pdf;
using System.Windows.Documents;
using Image = System.Windows.Controls.Image;
using System.Windows.Media.Imaging;
using System.Collections.Generic;
using System.Collections;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf;
using System.Drawing;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq;
using System.Collections.ObjectModel;

namespace Prototype2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string id;
        public static string cname;
        public static string ckey;
        public static string ctype;
        public static string desc;
        public static string scandate;
        public static string doctype;
        public static string file_path;

        int i = 0;

        string con = "Server=localhost; Port=3306; Database=prototypedb; Uid=root; Pwd=h2d.8ByPUDgzZN3; pooling = false; convert zero datetime=True";
        string select = "select id AS ID, CONCAT (client_fname,' ', client_lname) AS 'Client Name', client_desc AS 'Description', client_type AS 'Client Type', scan_date AS 'Scan Date', doc_type AS 'Document Type', archive AS 'Archive', client_key 'Key', pdf_file AS 'File Path', export_status AS 'Status' from client_tb ";

        public bool c { get; set; }

        public MainWindow()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NTc1OTc5QDMxMzkyZTM0MmUzMGUrRDYvUCsycGpoSlVjYVlhdmhHWmJrQTBQRzFYTTN2d1FSQkUrVStCQjA9;NTc1OTgwQDMxMzkyZTM0MmUzMGxZejU1Ri9GRjEvaTRKRE5Pa2d0RDVYdkFZRFV3R2V0Y09pdDlsQU9xSE09;NTc1OTgxQDMxMzkyZTM0MmUzMGVpNWJqL3VoNjFTRFJZeXBMRUdNSi9JM0MyUFc2Yitmd1JYb1pmZ1dINjQ9;NTc1OTgyQDMxMzkyZTM0MmUzMGdFT2lHQWdnQ1Byem9jVlJYQmxzWXNJS0pxNXh1bnVqMG5FamNja2FQU3c9;NTc1OTgzQDMxMzkyZTM0MmUzMFFUbXdFVE9JV0EwU1VQNjQwTHhMTG85MldhVTdyRWFqeUxHeXNmT09yTzQ9;NTc1OTg0QDMxMzkyZTM0MmUzMEFrcXhMbVVvdWowZnVoUS80R2ZWMk5PRDQyV2xoY2N6THkxSmJ5S1BSU0E9;NTc1OTg1QDMxMzkyZTM0MmUzMEVvc0Rtc1RKRi96bEpLbmJsdmo5ODdWd0ZDaXBqbTB2R2FsM0liVVJwVzg9;NTc1OTg2QDMxMzkyZTM0MmUzMElyMUtzc0tLWDNocnc1T2d5ekdrMFFnaVpseWpSU1pGK1V0akFsOWY0cWs9;NTc1OTg3QDMxMzkyZTM0MmUzMFB1bk1LalQ0eXBYQVBsWWRkSmV4Tm50QUNrRitCZnI3dklrVmhjNlBNQVk9;NTc1OTg4QDMxMzkyZTM0MmUzMFZjc0FPbXV1N0hDZm1zSkVUNzhSZy9aMStzK3RxV0dIcEFreFl0VDFuY2s9;NTc1OTg5QDMxMzkyZTM0MmUzMFhqQTdFanFROTV1SjVHYUJDSFFEMGZkcUIzcURKbG1lOXV1eHgxdm1WbVE9");
            InitializeComponent();

            datagridview();
            combo();

            browser.Navigate(new Uri("about:blank"));
            browser.Visibility = Visibility.Hidden;

            btn_edit.IsEnabled = false;
            dataGrid2.Visibility = Visibility.Visible;
            dataGrid1.Visibility = Visibility.Hidden;
            btn_export.IsEnabled = false;
        }

        #region ScaleValue Depdency Property
        public static readonly DependencyProperty ScaleValueProperty = DependencyProperty.Register("ScaleValue", typeof(double), typeof(MainWindow), new UIPropertyMetadata(1.0, new PropertyChangedCallback(OnScaleValueChanged), new CoerceValueCallback(OnCoerceScaleValue)));


        private static object OnCoerceScaleValue(DependencyObject o, object value)
        {
            MainWindow mainWindow = o as MainWindow;
            if (mainWindow != null)
                return mainWindow.OnCoerceScaleValue((double)value);
            else return value;
        }

        private static void OnScaleValueChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            MainWindow mainWindow = o as MainWindow;
            if (mainWindow != null)
                mainWindow.OnScaleValueChanged((double)e.OldValue, (double)e.NewValue);
        }

        protected virtual double OnCoerceScaleValue(double value)
        {
            if (double.IsNaN(value))
                return 1.0f;

            value = Math.Max(0.1, value);
            return value;
        }

        protected virtual void OnScaleValueChanged(double oldValue, double newValue) { }

        public double ScaleValue
        {
            get => (double)GetValue(ScaleValueProperty);
            set => SetValue(ScaleValueProperty, value);
        }
#endregion

        private void MainGrid_SizeChanged(object sender, EventArgs e) => CalculateScale();

        private void CalculateScale()
        {
            double yScale = ActualHeight / 540f;
            double xScale = ActualWidth / 978f;
            double value = Math.Min(xScale, yScale);

            ScaleValue = (double)OnCoerceScaleValue(window1, value);
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();

            dataGrid2.Visibility = Visibility.Visible;
            dataGrid1.Visibility = Visibility.Hidden;
        }

        public void combo()
        {           
            try
            {
                MySqlConnection conn = new MySqlConnection(con);
                MySqlCommand cmd = new MySqlCommand("select * from client_tb", conn);
                MySqlDataAdapter adapt = new MySqlDataAdapter(cmd);
                conn.Open();

                DataSet ds = new DataSet();
                adapt.Fill(ds, "client_tb");
                DataTable dt = ds.Tables[0];

                for (int intCount = 0; intCount < ds.Tables[0].Rows.Count; intCount++)
                {
                    var fname = ds.Tables[0].Rows[intCount][1].ToString();
                    var lname = ds.Tables[0].Rows[intCount][2].ToString();
                    var desc = ds.Tables[0].Rows[intCount][3].ToString();
                    var ctype = ds.Tables[0].Rows[intCount][4].ToString();
                    var scandate = ds.Tables[0].Rows[intCount][5].ToString();
                    var doctype = ds.Tables[0].Rows[intCount][6].ToString();
                    var archive = ds.Tables[0].Rows[intCount][7].ToString();
                    var ckey = ds.Tables[0].Rows[intCount][8].ToString();

                    var fullname = fname + " " + lname;
                    string status;

                    if (doctype == ".pdf")
                    {
                        status = "exported";
                    }
                    else
                    {
                        status = "null";
                    }

                    //check if it already exists
                    if (!combo_cname.Items.Contains(fullname))
                    {
                        combo_cname.Items.Add(fullname);
                    }

                    if (!combo_desc.Items.Contains(desc))
                    {
                        combo_desc.Items.Add(desc);
                    }

                    if (!combo_ctype.Items.Contains(ctype))
                    {
                        combo_ctype.Items.Add(ctype);
                    }

                    if (!combo_doctype.Items.Contains(status))
                    {
                        combo_doctype.Items.Add(status);
                    }

                    if (!combo_archive.Items.Contains(archive))
                    {
                        combo_archive.Items.Add(archive);
                    }

                    if (!combo_ckey.Items.Contains(ckey))
                    {
                        combo_ckey.Items.Add(ckey);
                    }
                }

                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void datagridview()
        {
            dataGrid1.Visibility = Visibility.Visible;
            dataGrid2.Visibility = Visibility.Hidden;
            btn_export.IsEnabled = false;

            try
            {
                if (Login.usertype == 1)
                {
                    MySqlConnection conn = new MySqlConnection(con);
                    MySqlCommand cmd = new MySqlCommand(select, conn);
                    conn.Open();

                    DataTable dt = new DataTable();
                    MySqlDataAdapter adapt = new MySqlDataAdapter(cmd);
                    dt.Load(cmd.ExecuteReader());
                    adapt.Fill(dt);
                    dataGrid1.ItemsSource = dt.DefaultView;

                    conn.Close();
                }
                else if (Login.usertype == 2)
                {
                    MySqlConnection conn = new MySqlConnection(con);
                    MySqlCommand cmd = new MySqlCommand(select , conn);
                    conn.Open();

                    DataTable dt = new DataTable();
                    MySqlDataAdapter adapt = new MySqlDataAdapter(cmd);
                    dt.Load(cmd.ExecuteReader());
                    adapt.Fill(dt);
                    dataGrid1.ItemsSource = dt.DefaultView;

                    conn.Close();
                } 
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            i++;
            c = true;          

            CheckBox select_row = (CheckBox)sender;
            DataRowView selected = select_row.DataContext as DataRowView;

            txt_path.Text = selected[8].ToString();

            id = selected[0].ToString();
            cname = selected[1].ToString();
            desc = selected[2].ToString();
            ctype = selected[3].ToString();
            scandate = selected[4].ToString();
            doctype = selected[5].ToString();
            ckey = selected[7].ToString();
            file_path = selected[8].ToString();

            if (Login.usertype == 1)
            {
                if (selected != null)
                {
                    MySqlConnection conn = new MySqlConnection(con);
                    MySqlCommand cmd = new MySqlCommand("select path from tif_tb where client_key = @ck AND page_num = '1' ", conn);
                    cmd.Parameters.AddWithValue("@ck", ckey);
                    MySqlDataAdapter adapt = new MySqlDataAdapter(cmd);
                    conn.Open();

                    DataSet ds = new DataSet();
                    adapt.Fill(ds, "tif_tb");

                    if (doctype == ".pdf")
                    {
                        try
                        {
                            doc_viewer.Visibility = Visibility.Hidden;
                            browser.Visibility = Visibility.Visible;
                            string PDFPath = txt_path.Text;
                            browser.Navigate(PDFPath);
                            btn_export.IsEnabled = false;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }

                    else
                    {
                        for (int intCount = 0; intCount < ds.Tables[0].Rows.Count; intCount++)
                        {
                            string doctype2 = selected[5].ToString();
                            var path = ds.Tables[0].Rows[intCount][0].ToString();

                            try
                            {
                                //add tif viewer
                                doc_viewer.Visibility = Visibility.Visible;
                                browser.Visibility = Visibility.Hidden;

                                BlockUIContainer container = (BlockUIContainer)doc_viewer.Document.FindName("ImageContainer");
                                Image image = (Image)container.Child;
                                image.Visibility = Visibility.Visible;
                                image.Stretch = System.Windows.Media.Stretch.UniformToFill;
                                image.StretchDirection = StretchDirection.Both;
                                image.Source = new BitmapImage(new Uri(path, UriKind.RelativeOrAbsolute));
                                //MessageBox.Show(path);

                                btn_export.IsEnabled = true;
                            }

                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                    }
                }
            }
            else
            {
                if (selected != null)
                {
                    MySqlConnection conn = new MySqlConnection(con);
                    MySqlCommand cmd = new MySqlCommand("select path from tif_tb where client_key = @ck AND page_num = '1' ", conn);
                    cmd.Parameters.AddWithValue("@ck", ckey);
                    MySqlDataAdapter adapt = new MySqlDataAdapter(cmd);
                    conn.Open();

                    DataSet ds = new DataSet();
                    adapt.Fill(ds, "tif_tb");

                    if (doctype == ".pdf")
                    {
                        try
                        {
                            doc_viewer.Visibility = Visibility.Hidden;
                            browser.Visibility = Visibility.Visible;
                            string PDFPath = txt_path.Text;
                            browser.Navigate(PDFPath);
                            btn_export.IsEnabled = false;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }

                    else
                    {
                        for (int intCount = 0; intCount < ds.Tables[0].Rows.Count; intCount++)
                        {
                            string doctype2 = selected[5].ToString();
                            var path = ds.Tables[0].Rows[intCount][0].ToString();

                            try
                            {
                                //add tif viewer
                                doc_viewer.Visibility = Visibility.Visible;
                                browser.Visibility = Visibility.Hidden;

                                BlockUIContainer container = (BlockUIContainer)doc_viewer.Document.FindName("ImageContainer");
                                Image image = (Image)container.Child;
                                image.Visibility = Visibility.Visible;
                                image.Stretch = System.Windows.Media.Stretch.UniformToFill;
                                image.StretchDirection = StretchDirection.Both;
                                image.Source = new BitmapImage(new Uri(path, UriKind.RelativeOrAbsolute));
                                //MessageBox.Show(path);

                                btn_export.IsEnabled = false;
                            }

                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                    }
                }
            }
        }

        public IEnumerable<System.Windows.Controls.DataGridRow> GetDataGridRows(System.Windows.Controls.DataGrid grid)
        {
            var itemsSource = grid.ItemsSource as IEnumerable;
            if (null == itemsSource) yield return null;
            foreach (var item in itemsSource)
            {
                var row = grid.ItemContainerGenerator.ContainerFromItem(item) as System.Windows.Controls.DataGridRow;
                if (null != row) yield return row;
            }
        }

        private void btn_edit_Click(object sender, RoutedEventArgs e)
        {           
            if (i > 1)
            {
                var rows = GetDataGridRows(dataGrid1);

                foreach (DataGridRow row in rows)
                {
                    DataRowView rowView = (DataRowView)row.Item;

                    foreach (DataGridColumn column in dataGrid1.Columns)
                    {
                        id = rowView.Row.ItemArray[0].ToString();
                        ckey = rowView.Row.ItemArray[7].ToString();
                        doctype = rowView.Row.ItemArray[5].ToString();
                        file_path = rowView.Row.ItemArray[8].ToString();
                        string gen_path = "C:/Users/Predator/Desktop/Test/" + rowView.Row.ItemArray[1].ToString() + "/" + rowView.Row.ItemArray[7].ToString() + ".pdf";
                      
                        MySqlConnection conn = new MySqlConnection(con);
                        MySqlCommand cmd = new MySqlCommand("select doc_type from client_tb where client_key = @ck ", conn);
                        cmd.Parameters.AddWithValue("@ck", ckey);
                        MySqlDataAdapter adapt = new MySqlDataAdapter(cmd);
                        conn.Open();

                        bool isSelected = Convert.ToBoolean(rowView.Row[0]);
                        string path = file_path;

                        if (isSelected && doctype == ".tif")
                        {
                            //Create a new PDF document
                            Syncfusion.Pdf.PdfDocument document = new Syncfusion.Pdf.PdfDocument();
                            //Get the directory information
                            DirectoryInfo directory = new DirectoryInfo(path);
                            FileInfo[] fileInfo = directory.GetFiles("*.tif*");
                            foreach (FileInfo file in fileInfo)
                            {
                                //Load the image
                                PdfBitmap image = new PdfBitmap(file.FullName);
                                //Add a page to the document
                                Syncfusion.Pdf.PdfPage page = document.Pages.Add();
                                //Draw the image
                                page.Graphics.DrawImage(image, new PointF(0, 0), new SizeF(page.GetClientSize().Width, page.GetClientSize().Height));
                            }
                            //Save the document
                            document.Save(gen_path);
                            //Close the document
                            //document.Close(true);

                            MySqlCommand cmd2 = new MySqlCommand("update client_tb set pdf_file = @fl, doc_type = @pdf, export_status = @ex where id = @id", conn);

                            cmd2.Parameters.AddWithValue("@fl", gen_path);
                            cmd2.Parameters.AddWithValue("@pdf", ".pdf");
                            cmd2.Parameters.AddWithValue("@ex", "exported");
                            cmd2.Parameters.AddWithValue("@id", id);
                            cmd2.ExecuteNonQuery();

                            conn.Close();
                            MessageBox.Show("Successfully generated PDF at " + gen_path);
                            btn_export.IsEnabled = false;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }                  
                }
            }

            if (i <= 1)
            {
                Editing edit = new Editing();
                edit.Show();
                btn_export.IsEnabled = false;
                //this.Hide();
            }
        }

        private void combo_cname_DropDownClosed(object sender, EventArgs e)
        {
            dataGrid1.Visibility = Visibility.Visible;
            dataGrid2.Visibility = Visibility.Hidden;

            try
            {
                MySqlConnection conn = new MySqlConnection(con);
                MySqlCommand cmd = new MySqlCommand(select + "where client_fname LIKE @cn OR client_lname LIKE @cn OR CONCAT (client_fname,' ', client_lname) LIKE @cn ", conn);
                cmd.Parameters.AddWithValue("@cn", combo_cname.Text);
                conn.Open();

                DataTable dt = new DataTable();
                MySqlDataAdapter adapt = new MySqlDataAdapter(cmd);
                dt.Load(cmd.ExecuteReader());  
                adapt.Fill(dt);
                dataGrid1.ItemsSource = dt.DefaultView;

                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void combo_cname_KeyUp(object sender, KeyEventArgs e)
        {
            dataGrid1.Visibility = Visibility.Visible;
            dataGrid2.Visibility = Visibility.Hidden;

            try
            {
                if (e.Key == System.Windows.Input.Key.Back)
                {
                    datagridview();
                }
                else
                {
                    try
                    {
                        MySqlConnection conn = new MySqlConnection(con);
                        MySqlCommand cmd = new MySqlCommand(select + "where client_fname LIKE @cn OR client_lname LIKE @cn OR CONCAT (client_fname,' ', client_lname) REGEXP @cn ", conn);
                        cmd.Parameters.AddWithValue("@cn", combo_cname.Text);
                        conn.Open();

                        DataTable dt = new DataTable();
                        MySqlDataAdapter adapt = new MySqlDataAdapter(cmd);
                        dt.Load(cmd.ExecuteReader());
                        adapt.Fill(dt);
                        dataGrid1.ItemsSource = dt.DefaultView;

                        conn.Close();
                    }
                    catch (Exception)
                    {
                        datagridview();
                    }
                }
                
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void combo_ckey_DropDownClosed(object sender, EventArgs e)
        {
            dataGrid1.Visibility = Visibility.Visible;
            dataGrid2.Visibility = Visibility.Hidden;

            try
            {
                MySqlConnection conn = new MySqlConnection(con);
                MySqlCommand cmd = new MySqlCommand(select + "where client_key = @ck ", conn);
                cmd.Parameters.AddWithValue("@ck", combo_ckey.Text);
                conn.Open();

                DataTable dt = new DataTable();
                MySqlDataAdapter adapt = new MySqlDataAdapter(cmd);
                dt.Load(cmd.ExecuteReader());
                adapt.Fill(dt);
                dataGrid1.ItemsSource = dt.DefaultView;

                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void combo_ckey_KeyUp(object sender, KeyEventArgs e)
        {
            dataGrid1.Visibility = Visibility.Visible;
            dataGrid2.Visibility = Visibility.Hidden;

            try
            {

                if (e.Key == System.Windows.Input.Key.Back)
                {
                    datagridview();
                }
                else
                {
                    try
                    {
                        MySqlConnection conn = new MySqlConnection(con);
                        MySqlCommand cmd = new MySqlCommand(select + "where client_key REGEXP @ck ", conn);
                        cmd.Parameters.AddWithValue("@ck", combo_ckey.Text);
                        conn.Open();

                        DataTable dt = new DataTable();
                        MySqlDataAdapter adapt = new MySqlDataAdapter(cmd);
                        dt.Load(cmd.ExecuteReader());
                        adapt.Fill(dt);
                        dataGrid1.ItemsSource = dt.DefaultView;

                        conn.Close();
                    }
                    catch (Exception)
                    {
                        datagridview();
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void combo_ctype_KeyUp(object sender, KeyEventArgs e)
        {
            dataGrid1.Visibility = Visibility.Visible;
            dataGrid2.Visibility = Visibility.Hidden;

            try
            {
                if (e.Key == System.Windows.Input.Key.Back)
                {
                    datagridview();
                }
                else
                {
                    try
                    {
                        MySqlConnection conn = new MySqlConnection(con);
                        MySqlCommand cmd = new MySqlCommand(select + "where client_type REGEXP @ct ", conn);
                        cmd.Parameters.AddWithValue("@ct", combo_ctype.Text);
                        conn.Open();

                        DataTable dt = new DataTable();
                        MySqlDataAdapter adapt = new MySqlDataAdapter(cmd);
                        dt.Load(cmd.ExecuteReader());
                        adapt.Fill(dt);
                        dataGrid1.ItemsSource = dt.DefaultView;

                        conn.Close();
                    }
                    catch (Exception)
                    {
                        datagridview();
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void combo_ctype_DropDownClosed(object sender, EventArgs e)
        {
            dataGrid1.Visibility = Visibility.Visible;
            dataGrid2.Visibility = Visibility.Hidden;

            try
            {
                MySqlConnection conn = new MySqlConnection(con);
                MySqlCommand cmd = new MySqlCommand(select + "where client_type = @ct ", conn);
                cmd.Parameters.AddWithValue("@ct", combo_ctype.Text);
                conn.Open();

                DataTable dt = new DataTable();
                MySqlDataAdapter adapt = new MySqlDataAdapter(cmd);
                dt.Load(cmd.ExecuteReader());
                adapt.Fill(dt);
                dataGrid1.ItemsSource = dt.DefaultView;

                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void combo_desc_DropDownClosed(object sender, EventArgs e)
        {
            dataGrid1.Visibility = Visibility.Visible;
            dataGrid2.Visibility = Visibility.Hidden;

            try
            {
                MySqlConnection conn = new MySqlConnection(con);
                MySqlCommand cmd = new MySqlCommand(select + "where client_desc = @cd ", conn);
                cmd.Parameters.AddWithValue("@cd", combo_desc.Text);
                conn.Open();

                DataTable dt = new DataTable();
                MySqlDataAdapter adapt = new MySqlDataAdapter(cmd);
                dt.Load(cmd.ExecuteReader());
                adapt.Fill(dt);
                dataGrid1.ItemsSource = dt.DefaultView;

                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void combo_desc_KeyUp(object sender, KeyEventArgs e)
        {
            dataGrid1.Visibility = Visibility.Visible;
            dataGrid2.Visibility = Visibility.Hidden;

            try
            {
                if (e.Key == System.Windows.Input.Key.Back)
                {
                    datagridview();
                }
                else
                {
                    if (combo_desc.Text != null)
                    {
                        try
                        {
                            MySqlConnection conn = new MySqlConnection(con);
                            MySqlCommand cmd = new MySqlCommand(select + "where client_desc REGEXP @cd ", conn);
                            cmd.Parameters.AddWithValue("@cd", combo_desc.Text);
                            conn.Open();

                            DataTable dt = new DataTable();
                            MySqlDataAdapter adapt = new MySqlDataAdapter(cmd);
                            dt.Load(cmd.ExecuteReader());
                            adapt.Fill(dt);
                            dataGrid1.ItemsSource = dt.DefaultView;

                            conn.Close();
                        }
                        catch (Exception)
                        {
                            datagridview();
                        }
                    }
                    else
                    {
                        MessageBox.Show("No text");
                    }    
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void combo_doctype_KeyUp(object sender, KeyEventArgs e)
        {
            dataGrid1.Visibility = Visibility.Visible;
            dataGrid2.Visibility = Visibility.Hidden;        

            try
            {
                if (e.Key == System.Windows.Input.Key.Back)
                {
                    datagridview();
                }
                else
                {
                    try
                    {
                        string doctype2;

                        if (combo_doctype.Text == "exported")
                        {
                            doctype2 = ".pdf";
                        }
                        else
                        {
                            doctype2 = ".tif";
                        }

                        MySqlConnection conn = new MySqlConnection(con);
                        MySqlCommand cmd = new MySqlCommand(select + "where doc_type REGEXP @dt ", conn);
                        cmd.Parameters.AddWithValue("@dt", doctype2);
                        conn.Open();

                        DataTable dt = new DataTable();
                        MySqlDataAdapter adapt = new MySqlDataAdapter(cmd);
                        dt.Load(cmd.ExecuteReader());
                        adapt.Fill(dt);
                        dataGrid1.ItemsSource = dt.DefaultView;

                        conn.Close();
                    }
                    catch (Exception)
                    {
                        datagridview();
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void combo_doctype_DropDownClosed(object sender, EventArgs e)
        {
            dataGrid1.Visibility = Visibility.Visible;
            dataGrid2.Visibility = Visibility.Hidden;

            try
            {
                string doctype2;

                if (combo_doctype.Text == "exported")
                {
                    doctype2 = ".pdf";
                }
                else
                {
                    doctype2 = ".tif";
                }

                MySqlConnection conn = new MySqlConnection(con);
                MySqlCommand cmd = new MySqlCommand(select + "where doc_type = @dt ", conn);
                cmd.Parameters.AddWithValue("@dt", doctype2);
                conn.Open();

                DataTable dt = new DataTable();
                MySqlDataAdapter adapt = new MySqlDataAdapter(cmd);
                dt.Load(cmd.ExecuteReader());
                adapt.Fill(dt);
                dataGrid1.ItemsSource = dt.DefaultView;

                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void combo_archive_DropDownClosed(object sender, EventArgs e)
        {
            dataGrid1.Visibility = Visibility.Visible;
            dataGrid2.Visibility = Visibility.Hidden;

            try
            {
                MySqlConnection conn = new MySqlConnection(con);
                MySqlCommand cmd = new MySqlCommand(select + "where archive = @a ", conn);
                cmd.Parameters.AddWithValue("@a", combo_archive.Text);
                conn.Open();

                DataTable dt = new DataTable();
                MySqlDataAdapter adapt = new MySqlDataAdapter(cmd);
                dt.Load(cmd.ExecuteReader());
                adapt.Fill(dt);
                dataGrid1.ItemsSource = dt.DefaultView;

                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void combo_archive_KeyUp(object sender, KeyEventArgs e)
        {
            dataGrid1.Visibility = Visibility.Visible;
            dataGrid2.Visibility = Visibility.Hidden;

            try
            {
                if (e.Key == System.Windows.Input.Key.Back)
                {
                    datagridview();
                }
                else
                {
                    try
                    {
                        MySqlConnection conn = new MySqlConnection(con);
                        MySqlCommand cmd = new MySqlCommand(select + "where archive REGEXP @a ", conn);
                        cmd.Parameters.AddWithValue("@a", combo_archive.Text);
                        conn.Open();

                        DataTable dt = new DataTable();
                        MySqlDataAdapter adapt = new MySqlDataAdapter(cmd);
                        dt.Load(cmd.ExecuteReader());
                        adapt.Fill(dt);
                        dataGrid1.ItemsSource = dt.DefaultView;

                        conn.Close();
                    }
                    catch (Exception)
                    {
                        datagridview();
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void checkbox1_Unchecked(object sender, RoutedEventArgs e)
        {
            btn_edit.IsEnabled = false;

        }
        private void checkbox1_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void dataGrid1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            i = 1;
            DataGrid dg = (DataGrid)sender;
            DataRowView selected = dg.SelectedItem as DataRowView;

            if (selected != null)
            {
                txt_path.Text = selected[8].ToString();

                id = selected[0].ToString();
                cname = selected[1].ToString();
                desc = selected[2].ToString();
                ctype = selected[3].ToString();
                scandate = selected[4].ToString();
                doctype = selected[5].ToString();
                ckey = selected[7].ToString();
                file_path = selected[8].ToString();

                if (Login.usertype == 1)
                {
                    if (selected != null)
                    {
                        MySqlConnection conn = new MySqlConnection(con);
                        MySqlCommand cmd = new MySqlCommand("select path from tif_tb where client_key = @ck AND page_num = '1' ", conn);
                        cmd.Parameters.AddWithValue("@ck", ckey);
                        MySqlDataAdapter adapt = new MySqlDataAdapter(cmd);
                        conn.Open();

                        DataSet ds = new DataSet();
                        adapt.Fill(ds, "tif_tb");

                        if (doctype == ".pdf")
                        {
                            try
                            {
                                doc_viewer.Visibility = Visibility.Hidden;
                                browser.Visibility = Visibility.Visible;
                                string PDFPath = txt_path.Text;
                                browser.Navigate(PDFPath);
                                btn_export.IsEnabled = false;
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }

                        else
                        {
                            for (int intCount = 0; intCount < ds.Tables[0].Rows.Count; intCount++)
                            {
                                string doctype2 = selected[5].ToString();
                                var path = ds.Tables[0].Rows[intCount][0].ToString();

                                try
                                {
                                    //add tif viewer
                                    doc_viewer.Visibility = Visibility.Visible;
                                    browser.Visibility = Visibility.Hidden;

                                    BlockUIContainer container = (BlockUIContainer)doc_viewer.Document.FindName("ImageContainer");
                                    Image image = (Image)container.Child;
                                    image.Visibility = Visibility.Visible;
                                    image.Stretch = System.Windows.Media.Stretch.UniformToFill;
                                    image.StretchDirection = StretchDirection.Both;
                                    image.Source = new BitmapImage(new Uri(path, UriKind.RelativeOrAbsolute));
                                    //MessageBox.Show(path);

                                    btn_export.IsEnabled = true;
                                }

                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                            }
                        }
                    }
                }
                else
                {
                    btn_export.IsEnabled = false;

                    if (selected != null)
                    {
                        MySqlConnection conn = new MySqlConnection(con);
                        MySqlCommand cmd = new MySqlCommand("select path from tif_tb where client_key = @ck AND page_num = '1' ", conn);
                        cmd.Parameters.AddWithValue("@ck", ckey);
                        MySqlDataAdapter adapt = new MySqlDataAdapter(cmd);
                        conn.Open();

                        DataSet ds = new DataSet();
                        adapt.Fill(ds, "tif_tb");

                        if (doctype == ".pdf")
                        {
                            doc_viewer.Visibility = Visibility.Hidden;
                            browser.Visibility = Visibility.Visible;
                            string PDFPath = txt_path.Text;
                            browser.Navigate(PDFPath);
                        }

                        else
                        {
                            for (int intCount = 0; intCount < ds.Tables[0].Rows.Count; intCount++)
                            {
                                string doctype2 = selected[5].ToString();
                                var path = ds.Tables[0].Rows[intCount][0].ToString();

                                try
                                {
                                    //add tif viewer
                                    doc_viewer.Visibility = Visibility.Visible;
                                    browser.Visibility = Visibility.Hidden;

                                    BlockUIContainer container = (BlockUIContainer)doc_viewer.Document.FindName("ImageContainer");
                                    Image image = (Image)container.Child;
                                    image.Visibility = Visibility.Visible;
                                    image.Stretch = System.Windows.Media.Stretch.UniformToFill;
                                    image.StretchDirection = StretchDirection.Both;
                                    image.Source = new BitmapImage(new Uri(path, UriKind.RelativeOrAbsolute));
                                }

                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                            }
                        }
                    }
                }
            }
        }

        private void btn_reset_Click(object sender, RoutedEventArgs e)
        {
            datagridview();
        }

        private void date_scandate_CalendarClosed(object sender, RoutedEventArgs e)
        {
            dataGrid1.Visibility = Visibility.Visible;
            dataGrid2.Visibility = Visibility.Hidden;

            try
            {
                MySqlConnection conn = new MySqlConnection(con);
                MySqlCommand cmd = new MySqlCommand(select + "where scan_date = @scd", conn);
                cmd.Parameters.AddWithValue("@scd", date_scandate.SelectedDate);
                conn.Open();

                DataTable dt = new DataTable();
                MySqlDataAdapter adapt = new MySqlDataAdapter(cmd);
                dt.Load(cmd.ExecuteReader());
                adapt.Fill(dt);
                dataGrid1.ItemsSource = dt.DefaultView;

                conn.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void date_enddate_CalendarClosed(object sender, RoutedEventArgs e)
        {
            dataGrid1.Visibility = Visibility.Visible;
            dataGrid2.Visibility = Visibility.Hidden;

            try
            {
                if (date_startdate.Text == "")
                {
                    MySqlConnection conn = new MySqlConnection(con);
                    MySqlCommand cmd = new MySqlCommand(select + "where scan_date <= @ed", conn);
                    cmd.Parameters.AddWithValue("@ed", date_enddate.SelectedDate);
                    conn.Open();

                    DataTable dt = new DataTable();
                    MySqlDataAdapter adapt = new MySqlDataAdapter(cmd);
                    dt.Load(cmd.ExecuteReader());
                    adapt.Fill(dt);
                    dataGrid1.ItemsSource = dt.DefaultView;

                    conn.Close();
                }
                else
                {
                    MySqlConnection conn = new MySqlConnection(con);
                    MySqlCommand cmd = new MySqlCommand(select + "where scan_date BETWEEN @sd AND @ed", conn);
                    cmd.Parameters.AddWithValue("@sd", date_startdate.SelectedDate);
                    cmd.Parameters.AddWithValue("@ed", date_enddate.SelectedDate);
                    conn.Open();

                    DataTable dt = new DataTable();
                    MySqlDataAdapter adapt = new MySqlDataAdapter(cmd);
                    dt.Load(cmd.ExecuteReader());
                    adapt.Fill(dt);
                    dataGrid1.ItemsSource = dt.DefaultView;

                    conn.Close();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void date_startdate_CalendarClosed(object sender, RoutedEventArgs e)
        {
            dataGrid1.Visibility = Visibility.Visible;
            dataGrid2.Visibility = Visibility.Hidden;

            try
            {
                if (date_enddate.Text == "")
                {
                    MySqlConnection conn = new MySqlConnection(con);
                    MySqlCommand cmd = new MySqlCommand(select + "where scan_date >= @sd", conn);
                    cmd.Parameters.AddWithValue("@sd", date_startdate.SelectedDate);
                    conn.Open();

                    DataTable dt = new DataTable();
                    MySqlDataAdapter adapt = new MySqlDataAdapter(cmd);
                    dt.Load(cmd.ExecuteReader());
                    adapt.Fill(dt);
                    dataGrid1.ItemsSource = dt.DefaultView;

                    conn.Close();
                }
                else
                {
                    MySqlConnection conn = new MySqlConnection(con);
                    MySqlCommand cmd = new MySqlCommand(select + "where scan_date BETWEEN @sd AND @ed", conn);
                    cmd.Parameters.AddWithValue("@sd", date_startdate.SelectedDate);
                    cmd.Parameters.AddWithValue("@ed", date_enddate.SelectedDate);
                    conn.Open();

                    DataTable dt = new DataTable();
                    MySqlDataAdapter adapt = new MySqlDataAdapter(cmd);
                    dt.Load(cmd.ExecuteReader());
                    adapt.Fill(dt);
                    dataGrid1.ItemsSource = dt.DefaultView;

                    conn.Close();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void date_scandate_KeyUp(object sender, KeyEventArgs e)
        {
            dataGrid1.Visibility = Visibility.Visible;
            dataGrid2.Visibility = Visibility.Hidden;

            try
            {
                if (e.Key == System.Windows.Input.Key.Back)
                {
                    datagridview();
                }
                else
                {
                    MySqlConnection conn = new MySqlConnection(con);
                    MySqlCommand cmd = new MySqlCommand(select + "where scan_date = @scd", conn);
                    cmd.Parameters.AddWithValue("@scd", date_scandate.SelectedDate);
                    conn.Open();

                    DataTable dt = new DataTable();
                    MySqlDataAdapter adapt = new MySqlDataAdapter(cmd);
                    dt.Load(cmd.ExecuteReader());
                    adapt.Fill(dt);
                    dataGrid1.ItemsSource = dt.DefaultView;

                    conn.Close();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void date_startdate_KeyUp(object sender, KeyEventArgs e)
        {
            dataGrid1.Visibility = Visibility.Visible;
            dataGrid2.Visibility = Visibility.Hidden;

            try
            {
                if (e.Key == System.Windows.Input.Key.Back)
                {
                    datagridview();
                }
                else
                {
                    if (date_enddate.Text == "")
                    {
                        MySqlConnection conn = new MySqlConnection(con);
                        MySqlCommand cmd = new MySqlCommand(select + "where scan_date >= @sd", conn);
                        cmd.Parameters.AddWithValue("@sd", date_startdate.SelectedDate);
                        conn.Open();

                        DataTable dt = new DataTable();
                        MySqlDataAdapter adapt = new MySqlDataAdapter(cmd);
                        dt.Load(cmd.ExecuteReader());
                        adapt.Fill(dt);
                        dataGrid1.ItemsSource = dt.DefaultView;

                        conn.Close();
                    }
                    else
                    {
                        MySqlConnection conn = new MySqlConnection(con);
                        MySqlCommand cmd = new MySqlCommand(select + "where scan_date BETWEEN @sd AND @ed", conn);
                        cmd.Parameters.AddWithValue("@sd", date_startdate.SelectedDate);
                        cmd.Parameters.AddWithValue("@ed", date_enddate.SelectedDate);
                        conn.Open();

                        DataTable dt = new DataTable();
                        MySqlDataAdapter adapt = new MySqlDataAdapter(cmd);
                        dt.Load(cmd.ExecuteReader());
                        adapt.Fill(dt);
                        dataGrid1.ItemsSource = dt.DefaultView;

                        conn.Close();
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void date_enddate_KeyUp(object sender, KeyEventArgs e)
        {
            dataGrid1.Visibility = Visibility.Visible;
            dataGrid2.Visibility = Visibility.Hidden;

            try
            {
                if (e.Key == System.Windows.Input.Key.Back)
                {
                    datagridview();
                }
                else
                {
                    if (date_startdate.Text == "")
                    {
                        MySqlConnection conn = new MySqlConnection(con);
                        MySqlCommand cmd = new MySqlCommand(select + "where scan_date <= @ed", conn);
                        cmd.Parameters.AddWithValue("@ed", date_enddate.SelectedDate);
                        conn.Open();

                        DataTable dt = new DataTable();
                        MySqlDataAdapter adapt = new MySqlDataAdapter(cmd);
                        dt.Load(cmd.ExecuteReader());
                        adapt.Fill(dt);
                        dataGrid1.ItemsSource = dt.DefaultView;

                        conn.Close();
                    }
                    else
                    {
                        MySqlConnection conn = new MySqlConnection(con);
                        MySqlCommand cmd = new MySqlCommand(select + "where scan_date BETWEEN @sd AND @ed", conn);
                        cmd.Parameters.AddWithValue("@sd", date_startdate.SelectedDate);
                        cmd.Parameters.AddWithValue("@ed", date_enddate.SelectedDate);
                        conn.Open();

                        DataTable dt = new DataTable();
                        MySqlDataAdapter adapt = new MySqlDataAdapter(cmd);
                        dt.Load(cmd.ExecuteReader());
                        adapt.Fill(dt);
                        dataGrid1.ItemsSource = dt.DefaultView;

                        conn.Close();
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            /*IEnumerable<Checked> selectedItems = dataGrid1.Items.OfType<Checked>().Where(usr => usr.c == true).ToList();
            foreach (Checked selectedUser in selectedItems)
            {
                n++;
            }
            MessageBox.Show(n + " checked");*/

            Add add = new Add();
            add.Show();
        }

        private void btn_refresh_Click(object sender, RoutedEventArgs e)
        {
            datagridview();
            combo();
        }

        private void select_row_Unchecked(object sender, RoutedEventArgs e)
        {
            i--;
            c = false;
        }
    }
}
