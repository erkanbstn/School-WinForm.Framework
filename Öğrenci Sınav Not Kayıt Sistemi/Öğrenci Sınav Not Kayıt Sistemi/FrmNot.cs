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
    public partial class FrmNot : Form
    {
        public FrmNot()
        {
            InitializeComponent();
        }
        int s1, s2, s3, ort;
        SqlConnection bgl = new SqlConnection("Data Source=DESKTOP-PKO8JLN\\SQLEXPRESS;Initial Catalog=DBOgrenciNot;Integrated Security=True");
        private void FrmNot_Load(object sender, EventArgs e)
        {
            

            listele2();
        }
        public void listele2()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("Select OgrNo as ' Numara ',OgrAd as ' İsim ',S1 as ' Sınav 1 ' ,S2 as ' Sınav 2 ' ,S3 as ' Sınav 3 ',Ortalama,Durum from TblDers", bgl);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bgl.Open();
            SqlCommand d = new SqlCommand("update TblDers set S1=@p1,S2=@p2,S3=@p3,Ortalama=@p4,Durum=@p5 where OgrNo=@p6", bgl);
            d.Parameters.AddWithValue("@p1", textBox1.Text);
            d.Parameters.AddWithValue("@p2", textBox2.Text);
            d.Parameters.AddWithValue("@p3", textBox3.Text);
            d.Parameters.AddWithValue("@p4", textBox4.Text);
            d.Parameters.AddWithValue("@p6", textBox6.Text);
            d.Parameters.AddWithValue("@p5", textBox5.Text);
            d.ExecuteNonQuery();
            bgl.Close();
            listele2();
            MessageBox.Show("Öğrenci Güncellendi", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                s1 = Convert.ToInt32(textBox1.Text);
                s2 = Convert.ToInt32(textBox2.Text);
                s3 = Convert.ToInt32(textBox3.Text);
                ort = (s1 + s2 + s3) / 3;
                textBox4.Text = ort.ToString();
                if (ort >= 50)
                {
                    textBox5.Text = "Geçti";
                }
                else
                {
                    textBox5.Text = "Kaldı";
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Girilmeyen Bilgiler Mevcut!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
      
        }

        private void FrmNot_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Çıkmak istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                Application.Exit();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
  
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            bgl.Open();
            SqlCommand l = new SqlCommand("Select OgrAd,OgrSoyad from TblDers where OgrNo=@p1 ", bgl);
            l.Parameters.AddWithValue("@p1", textBox6.Text);         
            SqlDataReader r = l.ExecuteReader();
            if (r.Read())
            {
                FrmProfil fr = new FrmProfil();
                fr.numara = textBox6.Text;
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
