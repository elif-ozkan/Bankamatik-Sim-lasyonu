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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
        //Data Source=LAPTOP-9MADQ7Q9\SQLEXPRESS01
        //Bağlantı adresi=Data Source=LAPTOP-9MADQ7Q9\SQLEXPRESS01;Initial Catalog="Film Arşivim";Integrated Security=True
        SqlConnection baglantı = new SqlConnection(@"Data Source=LAPTOP-9MADQ7Q9\SQLEXPRESS01;Initial Catalog=Bankamatik Simülasyonu;Integrated Security=True");
        private void Form3_Load(object sender, EventArgs e)
        {
            



            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Random rastgele=new Random();
            int sayı=rastgele.Next(100000, 1000000);
            MskHesapNo.Text = sayı.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            SqlCommand komut=new SqlCommand("insert into TBLKISILER (AD,SOYAD,TC,TELEFON,HESAPNO,SIFRE) values (@p1,@p2,@p3,@p4,@p5,@p6)",baglantı);
            komut.Parameters.AddWithValue("@p1", TxtAd.Text);
            komut.Parameters.AddWithValue("@p2",TxtSoyad.Text);
            komut.Parameters.AddWithValue("@p3",MskTc.Text);
            komut.Parameters.AddWithValue("@p4", MskTelefon.Text);
            komut.Parameters.AddWithValue("@p5", MskHesapNo.Text);
            komut.Parameters.AddWithValue("@p6", TxtSıfre.Text);
            komut.ExecuteNonQuery();
            baglantı.Close();
            MessageBox.Show("Müşteri bilgileri sisteme kaydedilmiştir.");
        }
    }
}
