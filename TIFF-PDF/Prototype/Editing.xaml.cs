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
using MySql.Data.MySqlClient;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using System.Drawing;
using System.Data;
using System.IO;
using Microsoft.Win32;
using System.Diagnostics;

namespace Prototype2
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Editing : Window
    {
        MainWindow mw = new MainWindow();
        string con = "Server=localhost; Port=3306; Database=prototypedb; Uid=root; Pwd=h2d.8ByPUDgzZN3;";

        public Editing()
        {
            InitializeComponent();  
        }


        private void btn_done_Click(object sender, RoutedEventArgs e)
        { 
            //mw.Show();
            this.Hide();
        }

        private void clear()
        {
            txt_docid.Text = "";
            txt_desc.Text = MainWindow.desc;
        }

        private void btn_generate_Click(object sender, RoutedEventArgs e)
        {
            string path = MainWindow.file_path;
            string completepath = txt_filepath.Text;

            if (txt_cname.Text == "" || txt_docid.Text == "")
            {
                MessageBox.Show("Field required.");

                if (txt_cname.Text == "")
                {
                    txt_cname.BorderThickness = new Thickness(1.5);
                    txt_cname.BorderBrush = new SolidColorBrush(Colors.Red);
                }

                else if (txt_docid.Text == "")
                {
                    txt_docid.BorderThickness = new Thickness(1.5);
                    txt_docid.BorderBrush = new SolidColorBrush(Colors.Red);
                }
            }

            else 
            {
                try
                {
                    if (txt_id.Text != "")
                    {
                        try
                        {
                            //Create a new PDF document
                            PdfDocument document = new PdfDocument();
                            //Get the directory information
                            DirectoryInfo directory = new DirectoryInfo(path);
                            FileInfo[] fileInfo = directory.GetFiles("*.tif*");
                            foreach (FileInfo file in fileInfo)
                            {
                                //Load the image
                                PdfBitmap image = new PdfBitmap(file.FullName);
                                //Add a page to the document
                                PdfPage page = document.Pages.Add();
                                //Draw the image
                                page.Graphics.DrawImage(image, new PointF(0, 0), new SizeF(page.GetClientSize().Width, page.GetClientSize().Height));
                            }
                            //Save the document
                            document.Save(txt_filepath.Text);
                            //Close the document
                            //document.Close(true);

                            MySqlConnection conn = new MySqlConnection(con);
                            conn.Open();

                            MySqlCommand cmd = new MySqlCommand("update client_tb set pdf_file = @fl, client_desc = @cd, doc_type = @pdf, export_status = @ex where id = @id", conn);

                            cmd.Parameters.AddWithValue("@fl", txt_filepath.Text);
                            cmd.Parameters.AddWithValue("@cd", txt_desc.Text);
                            cmd.Parameters.AddWithValue("@pdf", ".pdf");
                            cmd.Parameters.AddWithValue("@ex", "exported");
                            cmd.Parameters.AddWithValue("@id", txt_id.Text);
                            cmd.ExecuteNonQuery();

                            conn.Close();
                            MessageBox.Show("PDF generated successfully at " + txt_filepath.Text);
                            txt_docid.IsEnabled = false;
                            txt_desc.IsEnabled = false;
                            btn_generate.IsEnabled = false;
                            btn_cancel.IsEnabled = false;
                            //clear();                     
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }

                    else
                    {
                        MessageBox.Show("Error.");
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btn_undo_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            clear();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txt_ckey.Text = MainWindow.ckey;
            txt_cname.Text = MainWindow.cname;
            txt_ctype.Text = MainWindow.ctype;
            txt_desc.Text = MainWindow.desc;
            txt_doctype.Text = MainWindow.doctype;
            txt_id.Text = MainWindow.id;
            txt_scandate.Text = MainWindow.scandate;
            txt_filepath.Text = "C:/Users/Predator/Desktop/Test/" + txt_cname.Text + "/";
        }


        private void txt_docid_KeyUp(object sender, KeyEventArgs e)
        {
            txt_filepath.Text = "C:/Users/Predator/Desktop/Test/" + txt_cname.Text + "/" + txt_docid.Text + ".pdf";
        }

        /*private void btn_browse_Click(object sender, RoutedEventArgs e)
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
        }*/
    }
}
