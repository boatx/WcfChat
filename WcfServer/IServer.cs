using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServer
{
    /// <summary>
    /// Definicja interfejsu IServer - service contract. Okreslone sa tu metody ktore klient moze wezwac.
    /// Nasza usługa ma byc typu duplex (Duplex Service) (czyli usluga moze zwracac wiadomosc do klienta w ppunkcie koncowym (endpoint client) w sposob analogiczny do obslugi wyjatkow
    /// Dla Duplex Service potrzebujemy dwa interfejsy : service contract interface który zawiera metody do ktorych moze sie odwolywac klient i Callback contract interface zawierajace te metody ktore usluga moze wywolywac na kliencie.
    /// <para>CallbackContract wskazuje ktory interfejs ma byc wykorzystany jako Callbac contract interface, Session mode = Required mowi ze klient laczac sie musi ustanawiac sesje. WYslanie wiadomosci po koncu sesji przez klienta konczy sie wyrzuceniem wyjatku.
    /// Protection Level mowi o tym jak wiadomosc jest chroniona, dla uproszczenia i przy zalozeniu ze przez chat nie beda wymieniane wazne dane o chrona jest wylaczona </para> 
    /// <para> IServer - service contract interfec zawiera metody do ktorych odwoluje się klient</para>
    /// <para>Connect - metoda potrzebna do połaczenia sie z hostem (Serwerem Chatu), IsInitiating = true oznacza ze metoda ta rozpoczyna sesje, IsOneWy = true oznacza ze operacja ta nie wymaga odpowiedzi </para>
    /// <para>SayToServer - metoda ta sluzy do wysylania wiadomosci do Serwera Chatu</para>
    /// <para>Disconnect - metoda sluzaca do zakonczenia polaczenia, IsTerminating = true oznacza, ze kończy ona sesję </para>
    /// </summary>
    [ServiceContract(CallbackContract = typeof(IServerCallback), SessionMode = SessionMode.Required,ProtectionLevel = System.Net.Security.ProtectionLevel.None)]

   
    public interface IServer
    {
        [OperationContract(IsInitiating = true, IsOneWay = true)]
        void Connect(string name);

        [OperationContract(IsOneWay = true)]
         void SayToServer(Wiadomosc msg);     


        [OperationContract(IsTerminating = true, IsOneWay = true)]
        void Disconnect(string name);
    }

    /// <summary>
    /// IServerCallbac - callback contract 
    /// <para>SayToClient metoda, którą Serwer Chatu będzie wykorzystywał do przesyłania wiadomości do klienta.</para>
    /// </summary>
    public interface IServerCallback
    {
        [OperationContract(IsOneWay = true)]
         void SayToClient(Wiadomosc msg);
    }
}
