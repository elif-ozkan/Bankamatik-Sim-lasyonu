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

namespace Bankamatik_Simülasyonu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection baglantı = new SqlConnection(@"Data Source=LAPTOP-9MADQ7Q9\SQLEXPRESS01;Initial Catalog=Bankamatik Simülasyonu;Integrated Security=True");


        private void Form1_Load(object sender, EventArgs e)
        {
            




        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            SqlCommand komut = new SqlCommand("Select*From TBLKISILER where HESAPNO=@p1 and SIFRE=@p2", baglantı);
            komut.Parameters.AddWithValue("@p1", MskHesapNo.Text);
            komut.Parameters.AddWithValue("@p2", TxtSifre.Text);
            SqlDataReader dr = komut.ExecuteReader(); //Hesap sorgusunun yapılmasını sağlar
            if (dr.Read())
            {
                Form2 fr = new Form2();
                fr.hesap=MskHesapNo.Text;
                fr.Show();
            }
            else
            {
                MessageBox.Show("Hatalı giriş");
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form3 frm = new Form3();
            frm.Show();

        }
    }
}

