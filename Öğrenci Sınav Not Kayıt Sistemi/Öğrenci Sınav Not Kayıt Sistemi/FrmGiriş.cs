using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Öğrenci_Sınav_Not_Kayıt_Sistemi
{
    public partial class FrmGiriş : Form
    {
        public FrmGiriş()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
                  
          
        }

        private void label1_Click(object sender, EventArgs e)
        {
           
            Form1 fr = new Form1();
            fr.Show();
        }
        SqlConnection bgl = new SqlConnection("Data Source=DESKTOP-PKO8JLN\\SQLEXPRESS;Initial Catalog=DBOgrenciNot;Integrated Security=True");
        private void FrmGiriş_Load(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            FrmProfil t = new FrmProfil();
            t.no = textBox1.Text;

        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               

                bgl.Open();
                SqlCommand l = new SqlCommand("Select OgrNo from TblDers where OgrNo=@p1 ", bgl);
                l.Parameters.AddWithValue("@p1", textBox1.Text);
                SqlDataReader r = l.ExecuteReader();
                if (r.Read())
                {
                    FrmProfil fr = new FrmProfil();
                    fr.numara = textBox1.Text;
                    fr.Show();

                }
                else
                {
                    MessageBox.Show("Hatalı Numara Girdiniz", "Failure", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                bgl.Close();
            }
          

        }
    }
}
