using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;
using System.IO.Ports;
using System.Text;

namespace Netduino_Zigbee_Essai
{
    public class Program
    {
        private static CPortSerie port = new CPortSerie();
        private static SerialPort sp;
        private static String portCOM = "COM1"; //port COM à changer
        private static byte[] msg = Encoding.UTF8.GetBytes("SNIR\r\n"); // conserve dans une variable byte[] la chaîne de caractère "SNIR" après transformation en byte

        public static void Main()
        {
            sp = port.PortSerie(portCOM);
            sp.Open(); // ouverture du port série

            while (true)
            {
                sp.Write(msg, 0, msg.Length); // envoie le message yop 
                Thread.Sleep(1000);

                sp.Flush();
            }
        }
    }
}
