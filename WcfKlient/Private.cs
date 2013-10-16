using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
//using System.ServiceModel;
//using System.ServiceModel.Description;

namespace WcfKlient
{
    public delegate void SendHandler(object o, SendEventArgs e);

    public delegate void OknoHandler(object o, OknoEventArgs e);

    

    partial class Private : Form
    {
        public event SendHandler EventSend;
        public event OknoHandler EventOkno;
        ///krycie - pole odpowiedzialne za to czy zamknac okno czy tylko ukryc
        private bool krycie = true;
        private string kto;
        ///Własność pozwalająca na zmianę pola krycie
        public bool Krycie
        {
            get { return krycie;}
            set { krycie = value; }
        }

        public Private(string User)
        {
            kto = User;
            InitializeComponent();
        }

        public Private()
        {
            InitializeComponent();
        }
        
        private void btnPrvSend_Click(object sender, EventArgs e)
        {
            SlijWiadomosc();
        }
        /// <summary>
        /// Metoda obsługująca wysyłanie wiadomości prywatnej
        /// </summary>
        private void SlijWiadomosc()
        {
            if (txtPrvMsg.Text.Trim() != string.Empty)
            {
                txtPrvLog.AppendText("<ja> : "+txtPrvMsg.Text + "\n");
                WcfServer.Wiadomosc nowa = new WcfServer.Wiadomosc();
                nowa.Do_kogo = kto;
                nowa.Tresc = txtPrvMsg.Text;
                nowa.Name = null;

                SendEventArgs e1 = new SendEventArgs(nowa);
                if (EventSend != null) EventSend(new object(), e1);

                txtPrvMsg.Text = "";
            }
        }
        /// <summary>
        /// Metoda obsługująca odbieranie nadchodzącej wiadomości. 
        /// </summary>
        /// <param name="msg"></param>
        public void Wiadomosc(WcfServer.Wiadomosc msg)
        {
            ///przyjście normalnej wiadomości
            if (msg.Opcje == 0)
            {
                txtPrvLog.AppendText("<" + msg.Name + "> : " + msg.Tresc + "\n");
            }
            ///przyjście wiadomości, że użytkownik opuścił chat.
            if (msg.Opcje == -1)
            {
                txtPrvLog.AppendText("<Administrator> : " + msg.Tresc + "\n");
                krycie = false;
            }
        }
        
        /// <summary>
        /// Metoda obsługująca zdarzenie zamknięcia formy
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Private_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = krycie;
            //e.Cancel = true;
            OknoEventArgs e2 = new OknoEventArgs(kto);
            if (EventOkno != null) EventOkno(new object(), e2);

        }
        /// <summary>
        /// Poniższe metody są torzsame z metodami z formy KlientForm.cs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void txtPrvMsg_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (chEnter.Checked == true)
            {

                if (e.KeyChar == (char)13)
                {
                    e.Handled = true;
                    SlijWiadomosc();
                }
            }
        }
        private void wyczyśćLogiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtPrvLog.Clear();
        }

        public static void ZapisLogu(string nazwa, string[] tekst,string naglowek)
        {
            using (StreamWriter sw = new StreamWriter(nazwa))
            {
                sw.WriteLine(naglowek);
                sw.WriteLine();
                foreach (string wiersz in tekst)
                    sw.WriteLine(wiersz);
                 
            }

        }

        private void zapiszLogiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string nazwa;
            string naglowek = "Rozmowa prywatna z " + kto + ", " + DateTime.Now.ToString();
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                nazwa = saveFile.FileName;
                ZapisLogu(nazwa, txtPrvLog.Lines, naglowek);
            }
        }


    }
}
