using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.ServiceModel;

namespace WcfServer
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single, InstanceContextMode = InstanceContextMode.Single)]
    public partial class Server : Form,IServer
    {
        /// ServiceHost to klasa umozliwiajaca uruchomienie hosta swiadczacego wczesniej zdefiniowana usługi.
        ServiceHost host;
        /// lista istniejacych sesji i odpowiadajacych im nazw uzytkownikow
        private Dictionary<string, IServerCallback> clients = new Dictionary<string, IServerCallback>();
        /// lista zbanowanych uzytkownikow i data kiedy ban się kończy
        private Dictionary<string, DateTime> ban = new Dictionary<string, DateTime>();
        private Wiadomosc admin_wiad = new Wiadomosc("Administrator", null, null, 0);
        /// zmienna wskazujaca czy host jest otwarty
        private bool connected = false;
        ///lista uzytkownikow polaczonych, używana do wygenrowania alfabetycznej listy użytkowników chatu w ListBoxie lsUser
        ArrayList rozmawiajacy = new ArrayList();
        
        public Server()
        {
            InitializeComponent();

        }

        /// <summary>
        /// Klikniecie na przycisk start powoduje uruchomienie hosta. Adres pod jakim znajduje sie host ustawiany jest na podstawie wprowadzonych w formularzu danych.
        /// Pole tcp oznacza adres usługi tcp - służacej do wymiany wiadomości, http - oznacza adres usługi pozwalającej wyświetlić informacje o działających usługach w przegladarce www, moze tez zostac wykorzystany w celach serwisowych sprawdzic czy usluga działa itp.
        /// Usług są skonfigurowane w pliku App.config
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
         
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (connected == false)
            {   string port_http = (int.Parse(txtPort.Text.ToString())+1).ToString();
                Uri tcp  = new Uri("net.tcp://" +txtMachine.Text+":"+txtPort.Text+"/WCFChat/");
                Uri http = new Uri("http://"    +txtMachine.Text+":"+port_http+"/WCFChat/");
                Uri[] baseadress = {tcp,http};

                host = null;
                try { host = new ServiceHost(this, baseadress); }
                catch (Exception ex) { txtLog.AppendText(ex.Message.ToString()); }
                /// obsługa zdarzeń otwarcia, zamkniecia lub błedu hosta
                host.Opened  += new EventHandler(HandleHost);
                host.Closed  += new EventHandler(HandleHost);
                host.Faulted += new EventHandler(HandleHost);

                try { host.Open(); }
                catch (Exception ex) { txtLog.AppendText(ex.Message.ToString()); }
                
            }

            else

            {   ///jesli connected == false zakoncz sesje i powiadom o koncu sesji
                admin_wiad.Tresc = "Koniec Sesji !!! Do zobaczenia.";
                admin_wiad.Set_opcje = 9;
                WysliDoWszystkich(admin_wiad);
                /*foreach (IServerCallback cb in clients.Values)
                {
                    cb.SayToClient(admin_wiad);
                }*/
                try { host.Close(); }
                catch (Exception ex) { txtLog.AppendText(ex.Message.ToString()); }
                
            }
        }
        /// <summary>
        /// Obsługa zdarzeń związanych z otwarciem, błędem i zamknięciem hosta.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HandleHost(object sender, EventArgs e)
        {
            switch (host.State)
            {
                case CommunicationState.Closed:
                    txtLog.AppendText("Close " + DateTime.Now + "\n");
                    Stop();
                    break;
                case CommunicationState.Faulted:
                    txtLog.AppendText("Faulted " + DateTime.Now + "\n");
                    host.Abort();
                    Stop();
                    break;
                case CommunicationState.Opened:
                    txtLog.AppendText("Opened " + DateTime.Now + "\n");
                    Start();
                    break;
            }
        }
        /// <summary>
        /// ustala wartosci i dostępność danych pól formy gdy host jest zamknięty
        /// ustala wartość connected = false
        /// </summary>
        void Stop()
        {
            connected = false;
            btnSend.Enabled = false;
            btnStart.Text = "START";
            txtPort.Enabled = true;
            txtMachine.Enabled = true;
            txtMsg.Enabled = false;
            //czyszczenie listy uzytkownikow
            lsUsers.Items.Clear();
            rozmawiajacy.Clear();
            clients.Clear();
            
        }

        /// <summary>
        /// ustala dostępność i wartości danych pól formy gdy host jest otwarty
        /// </summary>
        void Start()
        {
            connected = true;
            btnSend.Enabled = true;
            btnStart.Text = "STOP";
            txtMsg.Enabled = true;
            txtPort.Enabled = false;
            txtMachine.Enabled = false;
        }

        /// <summary>
        /// Wysyłanie wiadomości od administratora do wszystkich użytkowników.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSlij_Click(object sender, EventArgs e)
        {
            SlijWiadomosc();
        }

        private void SlijWiadomosc()
        {
            if (txtMsg.Text.Trim() != string.Empty )
            {
                admin_wiad.Do_kogo = null;
                admin_wiad.Set_opcje = 0;
                admin_wiad.Tresc = txtMsg.Text + "\n";
                WysliDoWszystkich(admin_wiad);
                txtLog.AppendText("Administrator : " + txtMsg.Text.ToString() + "\n");
                txtMsg.Text = "";
            }
        }

        /// <summary>
        /// Własność zwaracająca callbacchanell danego użytkownika przez ten kanał prowadzona jest komunikacja z użytkownikiem.
        /// </summary>
        private IServerCallback CurrentCallback
        {
            get
            {
                return OperationContext.Current.GetCallbackChannel<IServerCallback>();
            }
        }
        
        /// <summary>
        /// Metoda do której odwołuje się klient łacząc się z serwerem.
        /// </summary>
        /// <param name="name"></param>
        public void Connect(string name)
        {
            /// Sprawdzanie czy nazwa podana przez klienta jest akceptowana (nie jest pusta ani nie jest nazwą zastrzeżoną administratora).
            if (name.Trim() == string.Empty || name.ToUpper() == "ADMINISTRATOR")
            {
                admin_wiad.Tresc = "Niedozwolona nazwa uzytkownika \n";
                admin_wiad.Set_opcje = 9;
                CurrentCallback.SayToClient(admin_wiad);
                
            }
            else
                /// sprawdzanie czy użytkownik nie został zbanowany
                if (ban.ContainsKey(name))
                {
                    DateTime data;
                    ban.TryGetValue(name, out data);
                    /// Powiadom uzytkownika o banie albo jeśli mineło odpowiednio dużo czasu usuń ban.
                    if (DateTime.Now < data)
                    {
                        admin_wiad.Tresc = "Zostales zbanowany !!!!";
                        CurrentCallback.SayToClient(admin_wiad);
                    }
                    else
                    {
                        ban.Remove(name);
                        Connect_true(name);
                    }
                }
                else
                    /// sprawdz czy nazwa nie jest zajeta przez innego użytkownika
            if (!clients.ContainsKey(name))
            {
                Connect_true(name);
            }
            else
            {
                admin_wiad.Tresc = "Nazwa zajeta!!!\n";
                CurrentCallback.SayToClient(admin_wiad);
                admin_wiad.Set_opcje = 9;
            }
        }

        /// <summary>
        /// właściwe połączenie, poinformuj innych użytkowników o tym, że dołączył nowy
        /// </summary>
        /// <param name="name"></param>
        public void Connect_true(string name)
        {
            admin_wiad.Tresc = "Uzytkownik " + name + " dołączył do chatu";
            admin_wiad.Do_kogo = name;
            admin_wiad.Set_opcje = 1;

            WysliDoWszystkich(admin_wiad);
            ///wyslij nowemu użytkownikowi listę kontaktów
            admin_wiad.Tresc = null;
            foreach (string nick in clients.Keys)
            {
                admin_wiad.Do_kogo = nick;
                CurrentCallback.SayToClient(admin_wiad);
            }
            ///dodaj nowego użytkownika do Dictionary clients wraz z odpowiadającym mu callbac canal
            clients.Add(name, CurrentCallback);
            lsUsers.Items.Add(name);
            ///wyswietl informacje na ekranie administratora
            txtLog.AppendText(name + " dołączył do chatu \n");
            UpdateLsUsers(name, 1);
        }
        /// <summary>
        /// metoda do której odwołuje się klient, służy do zakończenia połaczenia.
        /// </summary>
        /// <param name="name"></param>
        public void Disconnect(string name)
        {
            ///wyslij informacje o tym ze uzytkownik opuścił chat
            admin_wiad.Tresc = name + "opuścił chat" + "\n";
            admin_wiad.Do_kogo = name;
            /// opcja -1 mówi o usunięciu uzytkownika o nazwie zawartej w polu Do_kogo wiadomości z listy kontaktów.
            admin_wiad.Set_opcje = -1;
            if (clients.ContainsKey(name))
            {
                    clients.Remove(name);
                    UpdateLsUsers(name, -1);
                    WysliDoWszystkich(admin_wiad);

            }
            /// wyświetl informacje w oknie administratora.
            txtLog.AppendText(name + " disconnected.." + "\n");


        }
        /// <summary>
        /// Metoda do której odwołuje się klient służy do wysłania wiadomości do serwera.
        /// </summary>
        /// <param name="nowa_wiad"></param>
        public void SayToServer(Wiadomosc nowa_wiad)
        {

            IServerCallback cb;
            ///jesli nazwa klienta ktory wysyła nową wiadomość jest w Dictionary clients przejdz dalej
            if (clients.ContainsKey(nowa_wiad.Name))
            {
                /// jesli pole Do_kogo jest puste przekaż wiadomość wszystkim  uzytkownikom znajdujacym sie w canals
                if (nowa_wiad.Do_kogo == null)
                {
                    ///wyswietl wiadomosc w oknie administratora
                    txtLog.AppendText(nowa_wiad.Name + " : " + nowa_wiad.Tresc + "\n");


                    foreach (IServerCallback canal in clients.Values)
                    {
                        canal.SayToClient(nowa_wiad);
                    }

                }
                else
                {   ///Jesli pole wiadomości Do_kogo zawiera nazwę użytkownika która też znajduje się w Dictionary clients przekaż tę wiadomość tylko temu użytkownikowi.
                    if (clients.ContainsKey(nowa_wiad.Do_kogo))
                    {

                        clients.TryGetValue(nowa_wiad.Do_kogo, out cb);
                        cb.SayToClient(nowa_wiad);
                    }
                    /// jeśli użytkownik o takiej nazwie nie istnieje powiadom użytkownika wysyłającego wiadomość o błędzie i karz mu usunąć błednego użytkownika z listy kontaktów
                    else
                    {
                        admin_wiad.Tresc = "Blad !! Uzytkownik " + nowa_wiad.Do_kogo + " nie zostal znaleziony";
                        admin_wiad.Set_opcje = -1;
                        admin_wiad.Do_kogo = nowa_wiad.Do_kogo;
                        clients.TryGetValue(nowa_wiad.Name, out cb);
                        cb.SayToClient(admin_wiad);
                    }

                }
            }
        }
        /// <summary>
        /// Metoda wysyłająca wiadomość do wszystkich
        /// </summary>
        /// <param name="wiadomosc"></param>
        public void WysliDoWszystkich(Wiadomosc wiadomosc)
        {
            foreach (IServerCallback canal in clients.Values)
            {
                try { canal.SayToClient(wiadomosc); }
                    ///jesli wyslanie wiadomosci nie powiedzie sie danny uzytkownik zostanie rozlaczony
                catch (Exception ex) 
                { 
                    txtLog.AppendText(ex.Message.ToString() + "\n");
                    string name = ReturnKey(canal);
                    txtLog.AppendText(name);
                    Disconnect(name);
                } 
            }

        }

        /// <summary>
        /// metoda która zwraca klucz odpowiedniej wartości z Dictionary, używana w metodzie WysliDoWszystkich
        /// </summary>
        /// <param name="canal"></param>
        /// <returns></returns>
        private string ReturnKey(IServerCallback canal)
        {
            foreach (string key in clients.Keys)
            {
                if (clients[key] == canal)
                {
                    return key;
                }
            }
            return null;
        }


        /// <summary>
        /// Metoda uaktualniająca ArrayList rozmawiajacy o nowego uzytkownika, elementy ArrayList są sortowane i dodawane ListBoxa lsUsers
        /// </summary>
        /// <param name="uzytkownik"></param>
        /// <param name="opt"></param>
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

            rozmawiajacy.Sort();

            for (int k = 0; k < rozmawiajacy.Count; k++)
            {
                lsUsers.Items.Add((k + 1) + ". " + rozmawiajacy[k]);
            }
        }
        /// <summary>
        /// Metoda służąca do zapisu logów do pliku tekstowego zawsze na początku pliku zapisywany jest nagłówek.
        /// </summary>
        /// <param name="nazwa"></param>
        /// <param name="tekst"></param>
        /// <param name="naglowek"></param>
        public static void ZapisLogu(string nazwa, string[] tekst, string naglowek)
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
        /// Metoda czyści textBox txtLog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void wyczyśćLogiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            txtLog.Clear();
        }

        /// <summary>
        /// Metoda wyświetla formę z informacją o programie.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void informacjeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InfoBox InfoProg = new InfoBox();
            InfoProg.Show();
        }

        /// <summary>
        /// Metoda zapisuje log do pliku tekstowego, wykorzystuje saveFileDialog
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
                try { ZapisLogu(nazwa, txtLog.Lines, naglowek); }
                catch (Exception ex) { txtLog.AppendText(ex.Message.ToString()); }
            }
        }
        /// <summary>
        /// metoda obsługująca zdarzenie wciśnięcia klawisza enter, powoduje wysłanie wiadomości z pola txtMsg jęsli zaznaczone jest pole chechBox1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtMsg_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (checkBox1.Checked == true)
                {
                    ///obsługa zdarzenia eleminuje dźwięk towrzyszący wciśnięciu enter
                    e.Handled = true;
                    SlijWiadomosc();
                }
            }
        }
        /// <summary>
        /// obsługa zdarzenia kliknięcia przycisku kick wyrzucającego użytkownika z chata.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnKick_Click(object sender, EventArgs e)
        {
            kick();
        }
        /// <summary>
        /// Metoda służąca do wyrzucenia użytkownika zaznczonego w polu lsUser
        /// </summary>
        private void kick()
        {
            IServerCallback cb;
            string kto_kick;
            ///opcja 9 mówi klientowi by się rozłączył
            admin_wiad.Set_opcje = 9;
            admin_wiad.Tresc = "Zostałeś wyrzucony z chatu";
            if (lsUsers.SelectedItem != null)
            {
                kto_kick = lsUsers.SelectedItem.ToString().Remove(0, 2).Trim();
                clients.TryGetValue(kto_kick, out cb);
                cb.SayToClient(admin_wiad);
                //gdyby ktos napisal wlasnego klienta i nie chcial opuscic dobrowolnie
                //if (clients.ContainsKey(kto_kick)) { Disconnect(kto_kick); }
            }        
        }
        /// <summary>
        /// Obsługa zdarzenia kliknięcie przycisku btnBan, powodującego danie bana uzytkownikowi zaznaczonego na ListBoxie lsUser 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBan_Click(object sender, EventArgs e)
        {
            DateTime data;
            TimeSpan do_kiedy;
            if (lsUsers.SelectedItem != null)
            {
                    ///odcina z nazwy uzytkownika cyfre porzadkowa
                    string name = lsUsers.SelectedItem.ToString().Remove(0, 2).Trim();
                    ///czas trwania banu ustawia administrator za pomoca przycisków numerycznych 
                    do_kiedy = new TimeSpan(0, (int)numH.Value, (int)numM.Value, (int)numS.Value);
                    data = DateTime.Now.Add(do_kiedy);
                    txtLog.AppendText("Czas aktualny : " + DateTime.Now.ToString()+"\n");
                    txtLog.AppendText(name+" zbanowany do : " + data.ToString()+"\n");
                    ///dodanie do Dictionary ban nazwy uzytkownika i czasu do kiedy ban działa
                    ban.Add(name, data);
                    ///dodanie nazwy uzytkownika do listy zbanowanych
                    comboBanList.Items.Add(name);
                    ///wyrzucenie uzytkownika z chatu
                    kick();
                
            }
        }
        /// <summary>
        /// obsluga zdarzenia klikniecia na przycisk unban, powoduje usuniecie nicku z listy zbanowanych przed wygaśnięciem banu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUnBan_Click(object sender, EventArgs e)
        {
            if (comboBanList.SelectedItem != null)
            {
                ban.Remove(comboBanList.SelectedItem.ToString());
                comboBanList.Items.Remove(comboBanList.SelectedItem);
            }
        }
        /// <summary>
        /// Obsługa zdarzenia zamknięcia formy powoduje poinformowanie wszystkich użytkowników o końcu sesji i zamkniecie hosta
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Server_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (connected == true)
            {
                admin_wiad.Tresc = "Koniec Sesji !!! Do zobaczenia.";
                /// opcja dziewięc mowi klientowi by się rozłaczył
                admin_wiad.Set_opcje = 9;
                
                WysliDoWszystkich(admin_wiad);
                try { host.Close(); }
                catch (Exception ex) { txtLog.AppendText(ex.Message.ToString()); }
            
            }
        }



    }
}

/*
 * HOST MOZNA ZDEFINIOWAC W PLIKU App.config
         <host>
            <baseAddresses>
                <add baseAddress="net.tcp://localhost:4477/WCFChat/" />
                <add baseAddress="http://localhost:4478/WCFChat/" />
            </baseAddresses>
        </host>
 */
