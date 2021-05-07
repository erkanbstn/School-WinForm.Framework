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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection bgl = new SqlConnection("Data Source=DESKTOP-PKO8JLN\\SQLEXPRESS;Initial Catalog=DBOgrenciNot;Integrated Security=True");
        private void Form1_Load(object sender, EventArgs e)
        {
            listele();
        }
        public void listele()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("Select ID,OgrNo as ' Numarası ',OgrAd as ' Adı ' ,OgrSoyad as ' Soyadı ',Dosya as ' Resmi '   from TblDers", bgl);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bgl.Open();
            SqlCommand k = new SqlCommand("insert into TblDers (OgrNo,OgrAd,OgrSoyad,Dosya) values (@p1,@p2,@p3,@p4)",bgl);
            k.Parameters.AddWithValue("@p1",textBox2.Text);
            k.Parameters.AddWithValue("@p2",textBox3.Text);
            k.Parameters.AddWithValue("@p3",textBox4.Text);
            k.Parameters.AddWithValue("@p4",textBox5.Text);
            k.ExecuteNonQuery();
            bgl.Close();
            listele();
            MessageBox.Show("Öğrenci Eklendi", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bgl.Open();
            SqlCommand k = new SqlCommand("delete from TblDers where ID=@p1", bgl);
            k.Parameters.AddWithValue("@p1", textBox1.Text);
            k.ExecuteNonQuery();
            bgl.Close();
            listele();
            MessageBox.Show("Öğrenci Silindi", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bgl.Open();
            SqlCommand d = new SqlCommand("update TblDers set OgrNo=@p1,OgrAd=@p2,OgrSoyad=@p3,Dosya=@p8 where ID=@p4", bgl);
            d.Parameters.AddWithValue("@p1", textBox2.Text);
            d.Parameters.AddWithValue("@p2",textBox3.Text);
            d.Parameters.AddWithValue("@p3", textBox4.Text);
            d.Parameters.AddWithValue("@p4", textBox1.Text);    
            d.Parameters.AddWithValue("@p8", textBox5.Text);    
            d.ExecuteNonQuery();
            bgl.Close();
            listele();
            MessageBox.Show("Öğrenci Güncellendi", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            FrmNot fr = new FrmNot();
            fr.Show();
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {            
            openFileDialog1.ShowDialog();       
            textBox5.Text = openFileDialog1.FileName;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
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

        private void button6_Click(object sender, EventArgs e)
        {
            FrmResim fr = new FrmResim();
            fr.Show();
        }
    }
}
