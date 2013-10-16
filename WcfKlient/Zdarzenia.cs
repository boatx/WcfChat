using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WcfKlient
{
    public class SendEventArgs : EventArgs
    {
        public readonly WcfServer.Wiadomosc Message;


        public SendEventArgs(WcfServer.Wiadomosc wiad)
        {
            Message = wiad;
        }
    }

    public class OknoEventArgs : EventArgs
    {
        public readonly string Do_kogo;


        public OknoEventArgs(string do_kogo)
        {
            Do_kogo = do_kogo;
        }
    }
}
