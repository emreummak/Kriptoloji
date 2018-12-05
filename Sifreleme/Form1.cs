using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sifreleme
{
    public partial class Form1 : Form
    {
        public string ceasar(string metin,int say) {
            string alfabe = "abcçdefgğhıijklmnoöprsştuüvyz";
            string sifreli = "";
            for (int i=0; i<metin.Length; i++) {
                for (int j=0; j<alfabe.Length; j++) {
                    if (metin[i]==alfabe[j]) {
                        int gecici = (j + say > 28) ? (j + say) - 29 : j + say;
                        sifreli = sifreli + alfabe[gecici];
                    }
                }
            }
            return sifreli;
        }
        public string polybius(string metin) {
            int [,]dizi = new int[5,5];
            string sifreli = "";
            string alfabe = "abcdefgğhıjklmnoprsştuvyz";
            int say = 0;
            for (int i=0;i<5;i++) {
                for (int j=0;j<5;j++) {
                    dizi[i,j] = alfabe[say];
                    say++;
                }
            }
            for (int i=0;i<metin.Length;i++) {
                for (int j = 0; j < 5; j++)
                {
                    for (int k = 0; k < 5; k++)
                    {
                        if (metin[i]==dizi[j,k]) {
                            sifreli = sifreli + (j+1) + (k+1);
                        }                        
                    }
                }
            }
            return sifreli;
        }
        public string cit(string metin) {
            string tek = "";
            string cift = "";
            for (int i=0;i<metin.Length;i++) {
                if (i % 2 == 0)
                {
                    tek = tek + metin[i];
                }
                else
                {
                    cift = cift + metin[i];
                }
            }
            return metin.Length%2!=0?(tek.Length>cift.Length?tek+cift:cift+tek):tek+cift;
        }
        public string sutun(string metin, int stn) {
            Random rnd = new Random();
            string alfabe = "abcçdefgğhıijklmnoöprsştuüvyz";
            metin = metin.Trim();
            int mBoy = 0;
            int rndsayisi = 0;
            if (metin.Length % stn != 0)
            {
                mBoy = ((metin.Length / stn) + 1)*stn;
            }
            if (metin.Length<mBoy) {
                rndsayisi = mBoy - metin.Length;
                for (int i=0;i<rndsayisi;i++) {
                    metin += alfabe[rnd.Next(0,28)];
                }
            }
            char[,] dizi = new char[metin.Length/stn, stn];
            int sayac = 0;
            string sifreli = "";
            for (int i=0;i<metin.Length/stn;i++) {
                for (int j=0;j<stn;j++) {
                    dizi[i, j] = metin[sayac];
                    sayac++;
                }
            }
            for (int i = 0; i < stn; i++)
            {
                for (int j = 0; j < metin.Length/stn; j++)
                {
                    sifreli += dizi[j, i];
                }
            }
            return sifreli;
        }
        public string matris(string metin) {
            int[,] det1 = new int[3,3] { { 3, 2, 2 }, { 0, 1,0 }, { 1,0,1 } };
            string alfabe = " abcçdefgğhıijklmnoöprsştuüvyz";
            int mBoy = 0;
            int ssay = 0;
            mBoy = ((metin.Length / 3) + 1) * 3;
            ssay = mBoy - metin.Length;
            if (metin.Length % 3 != 0)
            {
                for (int i = 0; i < ssay; i++)
                {
                    metin += "0";
                }
            }
            int sutun = mBoy / 3;
            int[,] dizi = new int[3, sutun];
            string sifreli="";
            int[] sifreliDizi = new int[mBoy];
            int sayac = 0;
            for (int i=0;i<metin.Length;i++) {
                for (int j=0;j<alfabe.Length;j++) {
                    if (metin[i]==alfabe[j]) {
                        sifreliDizi[sayac]=j;
                        sayac++;
                    }
                }
            }
            sayac = 0;
            for (int i=0;i<3;i++) {
                for (int j=0;j<sutun;j++) {
                    dizi[i, j] = sifreliDizi[sayac];
                    sayac++;
                }
            }
            int[,] carpim = new int[3, sutun];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        carpim[i, j] += det1[i, k] * dizi[k, j];
                    }
                }
            }

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < sutun; j++)
                {
                    sifreli += carpim[i, j];
                }
            }
            return sifreli;
        } 
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string sMetin = textBox1.Text;
            string aMetin = textBox3.Text; if (aMetin=="") { aMetin ="1"; }
            if (comboBox1.Text == "Ceasar Algoritması") {
                textBox2.Text = ceasar(sMetin, Int32.Parse(aMetin));
            }
            else if (comboBox1.Text == "Polybius Algoritması") {
                textBox2.Text = polybius(sMetin);
            }
            else if (comboBox1.Text == "Çit Algoritması")
            {
                textBox2.Text = cit(sMetin);
            }
            else if (comboBox1.Text == "Sütun Algoritması")
            {
                textBox2.Text = sutun(sMetin,Int32.Parse(aMetin));
            }
            else if (comboBox1.Text == "T. Olmayan Matris Algoritması")
            {
                textBox2.Text = matris(sMetin);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Ceasar Algoritması" || comboBox1.Text == "Sütun Algoritması")
            {
                label4.Visible = true;
                button1.Visible = true;
                textBox3.Visible = true;
            }
            else {
                label4.Visible = false;
                button1.Visible = true;
                textBox3.Visible = false;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
               && !char.IsSeparator(e.KeyChar);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text.ToLower();
            textBox1.SelectionStart = textBox1.Text.Length;
        }
    }
}