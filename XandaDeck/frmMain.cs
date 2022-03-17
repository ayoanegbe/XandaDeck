using System;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;

namespace XandaDeck
{
    public partial class MainForm : Form
    {
        //private SQLiteConnection conn = null;
        //private DataSet dsAllTables = null;
        //private Dictionary<string, SQLiteDataAdapter> adapters = new System.Collections.Generic.Dictionary<string, SQLiteDataAdapter>();
        //private Dictionary<string, DataSet> datasets = new System.Collections.Generic.Dictionary<string, DataSet>();
        

        public MainForm()
        {
            InitializeComponent();

            imageList1 = new ImageList();

            // The default image size is 16 x 16, which sets up a larger
            // image size. 
            imageList1.ImageSize = new Size(255, 255);
            imageList1.TransparentColor = Color.White;

            // Assigns the graphics object to use in the draw options.
            myGraphics = Graphics.FromHwnd(panel1.Handle);

        }
        
        // Display the image.
        private void button1_Click(object sender, System.EventArgs e)
        {
            if (imageList1.Images.Empty != true)
            {
                if (imageList1.Images.Count - 1 > currentImage)
                {
                    currentImage++;
                }
                else
                {
                    currentImage = 0;
                }
                panel1.Refresh();

                // Draw the image in the panel.
                imageList1.Draw(myGraphics, 10, 10, currentImage);

                // Show the image in the PictureBox.
                pictureBox1.Image = imageList1.Images[currentImage];
                label3.Text = "Current image is " + currentImage;
                listBox1.SelectedIndex = currentImage;
                label5.Text = "Image is " + listBox1.Text;
            }
        }

        // Remove the image.
        private void button2_Click(object sender, System.EventArgs e)
        {
            imageList1.Images.RemoveAt(listBox1.SelectedIndex);
            listBox1.Items.Remove(listBox1.SelectedItem);
        }

        // Clear all images.
        private void button3_Click(object sender, System.EventArgs e)
        {
            imageList1.Images.Clear();
            listBox1.Items.Clear();
        }

        // Find an image.
        private void button4_Click(object sender, System.EventArgs e)
        {
            openFileDialog1.Multiselect = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog1.FileNames != null)
                {
                    for (int i = 0; i < openFileDialog1.FileNames.Length; i++)
                    {
                        addImage(openFileDialog1.FileNames[i]);
                    }
                }
                else
                {
                    addImage(openFileDialog1.FileName);
                }
            }
        }

        private void addImage(string imageToLoad)
        {
            if (imageToLoad != "")
            {
                imageList1.Images.Add(Image.FromFile(imageToLoad));
                listBox1.BeginUpdate();
                listBox1.Items.Add(imageToLoad);
                listBox1.EndUpdate();
            }
        }

        static SQLiteConnection CreateConnection()
        {

            SQLiteConnection sqlite_conn;
            // Create a new database connection:
            sqlite_conn = new SQLiteConnection("Data Source=database.db; Version = 3; New = True; Compress = True; ");
         // Open the connection:
         try
            {
                sqlite_conn.Open();
            }
            catch (Exception /* ex */)
            {

            }
            return sqlite_conn;
        }

    }
}
