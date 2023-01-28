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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
        
        SqlConnection baglantı=new SqlConnection(@"Data Source=LAPTOP-9MADQ7Q9\SQLEXPRESS01;Initial Catalog=Bankamatik Simülasyonu;Integrated Security=True");
        public string hesap;
        private void Form2_Load(object sender, EventArgs e)
        {
            baglantı.Open();    
            LblHesapNo.Text = hesap;
            SqlCommand komut = new SqlCommand("Select*From TBLKISILER where HESAPNO=@p1", baglantı);
            komut.Parameters.AddWithValue("@p1", hesap);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                LblAdSoyad.Text = dr[1] + "" + dr[2]; //Bir satırda string ifade varsa dönüşüm gerekmez
                LblTcKimlik.Text = dr[3].ToString();
                LblTelefon.Text = dr[4].ToString();

            }
            baglantı.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Gönderilrn hesabın para artışı
            baglantı.Open();
            SqlCommand komut = new SqlCommand("update TBLHESAP set Bakıye=Bakıye+@p1 where HesapNo=@p2", baglantı);
            komut.Parameters.AddWithValue("@p1",decimal.Parse(TxtTutar.Text));
            komut.Parameters.AddWithValue("@p2",maskedTextBox1.Text);
            komut.ExecuteNonQuery();
            baglantı.Close();
            MessageBox.Show("İşlem Gerçekleşti");


        }

        private void TxtTutar_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
