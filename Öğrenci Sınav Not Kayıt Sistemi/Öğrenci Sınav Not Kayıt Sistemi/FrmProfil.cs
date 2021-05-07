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
    public partial class FrmProfil : Form
    {
        public FrmProfil()
        {
            InitializeComponent();
        }
        SqlConnection bgl = new SqlConnection("Data Source=DESKTOP-PKO8JLN\\SQLEXPRESS;Initial Catalog=DBOgrenciNot;Integrated Security=True");
        public string numara;
        public string ad;
        public string soyad;
        public string adres;
        public string no;
        private void FrmProfil_Load(object sender, EventArgs e)
        {
            label9.Text = numara.ToString();

            bgl.Open();
            SqlCommand k = new SqlCommand("Select OgrAd,OgrSoyad,Dosya from TblDers where OgrNo=" + numara, bgl);
            SqlDataReader dr = k.ExecuteReader();
            while (dr.Read())
            {
                label7.Text = dr[0].ToString();
                label8.Text = dr[1].ToString();
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox1.ImageLocation = dr[2].ToString();


            }
            bgl.Close();

            SqlDataAdapter adapter = new SqlDataAdapter("Select S1 as ' Sınav 1 ' ,S2 as ' Sınav 2 ' ,S3 as ' Sınav 3 ' ,Ortalama,Durum from TblDers where OgrNo=" + numara,bgl);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }
    
    }
}
