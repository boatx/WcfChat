using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace WcfServer
    
{   ///<summary>
    ///Klasa wiadomości przesyłanych pomiędzy Serwerem Chatu a Klientem Chatu. Pole DataContract zapewnia serializacje danych, klasa jest przesylana w postaci dokumentu xml
    ///</summary>
    [DataContract]
    public class Wiadomosc
    {
        ///klasa wiadomosci
        ///nazwa wysylajacego wiad
        private string name;
        ///tresc wiadomosci
        private string tresc;
        ///do kogo ma byc wyslana, null -> do wszystkich
        private string do_kogo;
        ///opcje serweru
        private int opcje;

        ///wlasnosci
        [DataMember]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        [DataMember]
        public string Tresc
        {
            get { return tresc; }
            set { tresc = value; }
        }
        [DataMember]
        public string Do_kogo
        {
            get { return do_kogo; }
            set { do_kogo = value; }
        }

        [DataMember]
        public int Opcje
        {
            get { return opcje; }
            set { }
        }
        ///opcje tylko moze ustawiac server
        internal int Set_opcje
        {
            set { opcje = value; }
        }

        /// Konstruktor bezparametrowy klasy
        public  Wiadomosc()
        {
            name = null;
            tresc = null;
            do_kogo = null;
            opcje = 0;

        }

        /// konstruktor ustawiajacy wszystkie parametry dostepny dla serwera
        internal  Wiadomosc(string Name,string Tresc,string Do_kogo, int Opt)
        {
            name = Name;
            tresc = Tresc;
            do_kogo = Do_kogo;
            opcje = Opt;

        }
    }
}
