using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.IO;
namespace WcfKlient
{
 
    public partial class KlientForm : Form, IServerCallback
    {
        ///Kod klienta ServerForm.cs i plik konfiguracyjny App.config zostały wygenerowane za pomocą narzędzia SvcUtil.exe
        ///Klasa klienta ServerClient
        ServerClient proxy;
        ///pole oznaczające nazwę użytkownika
        private string name = string.Empty;
        ///zmienna mówiąca czy istnieje połączenie z serwerem
        private bool connected = false;
        ///lista uzytkownikow polaczonych
        ArrayList rozmawiajacy = new ArrayList();
        ///tablica otwartych okien wiadomosci prywatnych
        private Dictionary<string, Private> okna = new Dictionary<string, Private>();
        
        public KlientForm()
        {
            InitializeComponent();
            txtWiad.Enabled = false;
            btnSend.Enabled = false;

         }
        /// <summary>
        /// Metoda wykorzystywana do obsługi zdarzenia wysłania wiadomości z okna wiadomości prywatnych
        /// </summary>
        /// <param name="o"></param>
        /// <param name="e"></param>
        public void onSend(object o, SendEventArgs e)
        {
            WcfServer.Wiadomosc wiad = e.Message;
            wiad.Name = txtNick.Text;
            try{proxy.SayToServer(wiad);}
            catch (TimeoutException ex) { txtLog.AppendText(ex.Message.ToString()); proxy.Abort(); Disconnect(); }
            catch (Exception ex){txtLog.AppendText(ex.Message.ToString());}
         }
        /// <summary>
        /// Metoda do której odwołuje się serwer wysyłając wiadomość do klienta
        /// </summary>
        /// <param name="msg">Wiadomość wysyłana do klienta chatu</param>
        public void SayToClient(WcfServer.Wiadomosc msg)
        {
            switch(msg.Opcje)
            {   
                ///opcja zero -> zwykla wiadomosc
                case 0:
                    Private prv;
                    ///sprawdza czy pole Do_kogo wiadomości odpowiada naszemu nickowi
                    if (msg.Do_kogo == txtNick.Text)
                    { ///jesli istnieje juz okno wiadomości prywatnych od użytkownika msg.Name, przekaż wiadomość do tego okna
                        if (okna.Keys.Contains(msg.Name) == true)
                        {
                            okna.TryGetValue(msg.Name, out prv);
                            prv.Show();
                            prv.Wiadomosc(msg);
                            
                        }
                        ///jesli nie istnieje okno wiadomości prywatnych od tego użytkownika stwórz je i przekaż do niego wiadomość
                        else
                        {
                            NoweOkno(msg.Name);
                            okna.TryGetValue(msg.Name, out prv);
                            prv.Wiadomosc(msg);
                        }

                        
                    }
                    else if (msg.Do_kogo == null)
                    ///jesli pole Do_kogo jest puste wyświetla wiadomość w txtLog
                    txtLog.AppendText("<" + msg.Name + "> : " + msg.Tresc + "\n");
                break;
                
                //opcja 1 -> dodaj uzytkownika do listy za pomocą meto LsUser
                case 1:
                    if (msg.Tresc != null) txtLog.AppendText("<" + msg.Name + "> : " + msg.Tresc + "\n");
                    UpdateLsUsers(msg.Do_kogo, 1);
                break;
                
                ///opcja -1 -> usun uzytkownika z listy, nick użytkownika do usunięcia znajduje się w polu Do_kogo
                case -1:
                    if (msg.Tresc != null) txtLog.AppendText("<" + msg.Name + "> : " + msg.Tresc + "\n");
                    UpdateLsUsers(msg.Do_kogo, -1);
                    ///jesli istnieje okno wiadomosci prywatnych od usuwanego uzytkownika
                    if (okna.Keys.Contains(msg.Do_kogo))
                    {
                        
                        okna.TryGetValue(msg.Do_kogo, out prv);
                        ///jeśli jest ono nie widoczne zostaje ono zamknięte
                        if (prv.Visible != true)
                        {
                            prv.Krycie = false;
                            prv.Close();
                        }   
                        ///jeśli okno jest widoczne jest w nim wyświetlona informacja, że użytkownik opuścił chat
                        else
                        {
                            prv.Wiadomosc(msg);
                        }
                    }

                break;
                ///opcja ta powoduje rozłaczenie się 
                case 9:
                    if (msg.Tresc != null) txtLog.AppendText("<" + msg.Name + "> : " + msg.Tresc + "\n");
                    try { proxy.Disconnect(name); }
                    catch (Exception ex) { txtLog.AppendText(ex.Message.ToString()); proxy.Abort(); Disconnect(); }
                break;
            }
        }
        /// <summary>
        /// obsługa zdarzenia wysyłanie wiadomości
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSend_Click(object sender, EventArgs e)
        {
            SlijWiadomosc();
        }
        /// <summary>
        /// Metoda wysyłająca wiadomość z textBoxu txtWiad do serwera, wiadomość zostanie przekazana do wszystkich użytkowników
        /// </summary>
        private void SlijWiadomosc()
        {
            WcfServer.Wiadomosc nowa = new WcfServer.Wiadomosc();
            nowa.Do_kogo = null;
            nowa.Tresc = txtWiad.Text;
            nowa.Name = txtNick.Text;
            try { proxy.SayToServer(nowa); }
            catch (TimeoutException ex) { txtLog.AppendText(ex.Message.ToString()); proxy.Abort(); Disconnect(); }
            catch (Exception ex) { txtLog.AppendText(ex.Message.ToString()); }
            txtWiad.Text = "";
        }
        /// <summary>
        /// obsługa zdarzenia kliknięcia przycisku połącz/rozłącz
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCon_Click(object sender, EventArgs e)
        { ///jeśli wartość connected = false połącz się
            if (connected == false)
            {
                proxy = null;
                
                InstanceContext context = new InstanceContext(this);
                EndpointAddress adress = new EndpointAddress("net.tcp://" + txtMachine.Text + ":" + txtPort.Text + "/WCFChat/tcp");     
                proxy = new ServerClient(context, "NetTcpBinding_IServer",adress);
                
                proxy.InnerDuplexChannel.Opened  +=  new EventHandler(HandleProxy);
                proxy.InnerDuplexChannel.Closed  +=  new EventHandler(HandleProxy);
                proxy.InnerDuplexChannel.Faulted +=  new EventHandler(HandleProxy);
                
                name = txtNick.Text.ToString().Trim();
                try { proxy.Connect(name); }
                catch (Exception ex) { txtLog.AppendText(ex.Message.ToString()); }
               
            }
                ///w innym przypadku rozłącz się
            else
            {
                try { proxy.Disconnect(name); }
                catch (Exception ex) { txtLog.AppendText(ex.Message.ToString()); proxy.Abort(); Disconnect(); }
                
            }
        }
        /// <summary>
        /// Metoda ustawiając dostępi i wartości pól formy po rozłączeniu się
        /// </summary>
        private void Disconnect()
        {
            connected = false;
            Private prv;
            btnSend.Enabled = false;
            btnCon.Text = "Polacz";
            txtNick.Enabled = true;
            txtPort.Enabled = true;
            txtMachine.Enabled = true;
            txtWiad.Enabled = false;
            ///czyszczenie listy uzytkownikow
            lsUsers.Items.Clear();
            rozmawiajacy.Clear();
            ///zamykanie wszystkich otwartych okien 
            for (int i = 0; i < okna.Count(); i++)
            {
                prv = okna.Values.ElementAt(i);
                prv.Krycie = false;
                prv.Close();
            }
            okna.Clear();
        }

        /// <summary>
        /// Metoda ustawiająca wartości pól formy po połączeniu
        /// </summary>
        private void Connect()
        {
            connected = true;
            btnSend.Enabled = true;
            btnCon.Text = "Rozlacz";
            txtWiad.Enabled = true;
            txtNick.Enabled = false;
            txtPort.Enabled = false;
            txtMachine.Enabled = false;
            rozmawiajacy.Add(name);
            lsUsers.Items.Add("1."+name);
        }
        /// <summary>
        /// Metoda obsługująca zdarzenia zamknięcia połączenia, otwarcia i błedu połączenia
        /// </summary>
        void HandleProxy(object sender, EventArgs e)
        {
            switch (proxy.State)
            {
                case CommunicationState.Closed:
                    //txtLog.AppendText("Disconnected\n");
                    lstatus.ForeColor = Color.Red;
                    lstatus.Text = "niepołączony";
                    Disconnect();

                    break;
                case CommunicationState.Faulted:
                    //txtLog.AppendText("Faulted\n");
                    lstatus.ForeColor = Color.Red;
                    //lstatus.Text = "niepołączony";
                    lstatus.Text = "fault";
                    //proxy.Abort();
                    Disconnect();

                    break;
                case CommunicationState.Opened:
                    lstatus.ForeColor = Color.Blue;
                    lstatus.Text = "połączony";
                    Connect();

                    break;
            }
        }

        /// <summary>
        /// Obsługa zdarzenia zaznaczenia nick na liście lsUser
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lsUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Prv_kto;
            Private prv;
            if (lsUsers.SelectedItem != null && lsUsers.SelectedItem.ToString().Remove(0, 2).Trim() != name)
            {
                Prv_kto = lsUsers.SelectedItem.ToString().Remove(0, 2).Trim();
                ///jeśli nie ma okna prywatnych wiadomości od tego użytkownika zostaje ono stworzone
                if (okna.Keys.Contains(Prv_kto) == false) NoweOkno(Prv_kto);
                else
                {   
                    okna.TryGetValue(Prv_kto, out prv);
                    ///jeśli istnieje i nie jest widoczne zostaje pokazane
                    if (prv.Visible == false)
                    {
                        prv.Show();
                    }
                    ///jeśli okno nie jest ukryte staje się oknem aktywnym
                    else
                    {
                        prv.Activate();
                    }
                }
            }
        }
        /// <summary>
        /// metoda tworząca okno wiadomości prywatnych
        /// </summary>
        /// <param name="do_kogo"></param>
        public void NoweOkno(string do_kogo)
        {
            //if (do_kogo != null && okna.Keys.Contains(do_kogo) == false)           
                Private Prv = new Private(do_kogo);
                Prv.Text = "Rozmowa prywatna z " + do_kogo;
                okna.Add(do_kogo, Prv);
                ///uchwyty do obsługi zdarzenia zamknięcia okna i wysłania wiadomości z okna
                Prv.EventOkno += new OknoHandler(onOknoClose);
                Prv.EventSend += new SendHandler(onSend);
                Prv.Show();
          }
        
        /// <summary>
        /// Metoda obsługująca zdarzenie zamknięcia formy okna wiadomości prywatnych (Prv)
        /// </summary>
        /// <param name="o"></param>
        /// <param name="e"></param>
        public void onOknoClose(object o, OknoEventArgs e)
        {
            string do_kogo = e.Do_kogo;
            Private moje_okno;
            ///jeśli osoba do której wysyłane są wiadomości z okna wiadomości prywatnych jest na liscie rozmawiajacy, nie zamykaj formy tylko ją ukryj
            if (rozmawiajacy.Contains(do_kogo))
            {
                okna.TryGetValue(do_kogo, out moje_okno);
                moje_okno.Hide();
            }
            ///w innym przypadku okno zostaje usunięte
            else
            {
                okna.Remove(do_kogo);
            }
        }

        
        /// <summary>
        /// Metoda uaktualniająca Array List rozmawiajacy i uaktualniająca ListBox lsUser 
        /// </summary>
        /// <param name="uzytkownik">Nazwa uzytkownika do do dania lub usunięcia</param>
        /// <param name="opt">oopcja 1 dodaje użytkownika, opcja -1 usuwa użytkownika</param>
        public void UpdateLsUsers(string uzytkownik, int opt)
        {
            lsUsers.Items.Clear();
            if (opt == 1)
            {
                rozmawiajacy.Add(uzytkownik);               
            }

            else
            {
                rozmawiajacy.Remove(uzytkownik);
            }
            ///Sortowanie użytkowników alfabetycznie
            rozmawiajacy.Sort();
            ///wypełnianie LsUser
            for (int k = 0; k < rozmawiajacy.Count; k++)
            {
                lsUsers.Items.Add((k + 1) + ". " + rozmawiajacy[k]);
            }
        }
        /// <summary>
        /// Metoda obsługująca zdarzenie kliknięcia na pole Wyczyśc Logi w menu, czyscli TextBox txtLog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void wyczyśćLogiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtLog.Clear();
        }
        /// <summary>
        /// Metoda zapisująca Log do pliku
        /// </summary>
        /// <param name="nazwa">Nazwa pliku</param>
        /// <param name="tekst">Treść Logu</param>
        /// <param name="naglowek">Nagłówek pliku</param>
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
        /// <summary>
        /// Metoda obsługująca zdarzenie kliknięcia menu zapisz Logi
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void zapiszLogiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string nazwa;
            string naglowek = "Zapis chatu z dnia " + DateTime.Now.ToString();
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                nazwa = saveFileDialog1.FileName;
                ZapisLogu(nazwa, txtLog.Lines, naglowek);
            }
        }
        /// <summary>
        /// Meto obsługująca zdarzenie kliknięcia pola Informacje w menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void informacjeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InfoBox InfoProg = new InfoBox();
            InfoProg.Show();
        }

        /// <summary>
        /// Metoda obsługująca zdarzenie wciśnięcia klawisza enter przy kursorze ustawionym w TextBoxie txtWiad. Wciśnięcie enter przy zaznaczonym checboxie chEnter powoduje wysłanie wiadomości
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtWiad_KeyPress(object sender, KeyPressEventArgs e)
        { 
            if (e.KeyChar == (char)13)
            {
                if (chEnter.Checked == true)
                {
                    e.Handled = true;
                    SlijWiadomosc();
                }
             }
        }

        /// <summary>
        /// Metoda obsługująca zdarzenie zamknięcia formy
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KlientForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (connected == true)
            {
                try { proxy.Disconnect(name); }
                catch (Exception ex) { txtLog.AppendText(ex.Message.ToString()); proxy.Abort(); }
            }
        }


    }
}