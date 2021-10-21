using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace accessbaglanti
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Erkek");
            comboBox1.Items.Add("Kadın");


            string dosya = @"Provider=Microsoft.ACE.OleDb.12.0;data source=data.accdb";
            OleDbConnection baglanti = new OleDbConnection(dosya);
            baglanti.Open();
            string sql = "select * from tablo_personel";
            OleDbCommand cmd = new OleDbCommand(sql, baglanti);
            OleDbDataReader veri = cmd.ExecuteReader();
            veri.Close();
            cmd.CommandType = CommandType.Text;
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            DataTable data = new DataTable();
            da.Fill(data);
            dataGridView1.DataSource = data;
            cmd.Dispose();
            baglanti.Close();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string dosya = @"Provider=Microsoft.ACE.OleDb.12.0;data source=data.accdb";
            OleDbConnection baglanti = new OleDbConnection(dosya);
            baglanti.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = baglanti;
            cmd.CommandText = "insert into tablo_personel(perno, ad, soyad, cinsiyet, maas) values(@perno, @ad, @soyad, @cinsiyet, @maas)";
            cmd.Parameters.AddWithValue("@perno", textBox2.Text);
            cmd.Parameters.AddWithValue("@ad", textBox3.Text);
            cmd.Parameters.AddWithValue("@soyad", textBox4.Text);
            cmd.Parameters.AddWithValue("@cinsiyet", comboBox1.Text);
            cmd.Parameters.AddWithValue("@maas", int.Parse(textBox6.Text));
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            baglanti.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string dosya = @"Provider=Microsoft.ACE.OleDb.12.0;data source=data.accdb";
            OleDbConnection baglanti = new OleDbConnection(dosya);
            baglanti.Open();
            string sql = "delete from personel_tablo where perno ='" + textBox2.Text + "'";
            OleDbCommand cmd = new OleDbCommand(sql, baglanti);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            baglanti.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string dosya = @"Provider=Microsoft.ACE.OleDb.12.0;data source=data.accdb";
            OleDbConnection baglanti = new OleDbConnection(dosya);
            baglanti.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = baglanti;
            cmd.CommandText = "update personel_tablo set ad='" + textBox3.Text + 
                "', soyad ='" + textBox4.Text +
                "',maas=" + int.Parse(textBox6.Text) + " where perno'" + textBox2.Text + "'";
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            baglanti.Close();
                
            
        }
    }
}
