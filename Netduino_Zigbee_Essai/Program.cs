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
        static SerialPort sp; 
        public static void Main()
        {
            // write your code here
            sp = new SerialPort("COM1",9600,Parity.None,8,StopBits.One); // création du port série
            sp.Open(); // ouverture du port série

            Thread th = new Thread(th2);
            th.Start();
            while (true)
            {
                byte[] msg = Encoding.UTF8.GetBytes("yop\r\n"); // conserve dans une variable byte[] la chaîne de caractère "yop" après transformation en byte
                
                for (int i = 0; i <= 5; i++)
                {
                    sp.Write(msg, 0, msg.Length); // envoie le message yop 
                    Thread.Sleep(1000);
                }
                sp.Flush();
                th.Join();
            }

        }

        // lire la réception de message
        static public void th2()
        {
            String msg = "";
            while (true)
            {
                if (sp.BytesToRead > 0) // si il a quelque chose en mémoire
                {
                    char letter = (char)sp.ReadByte();
                    msg += letter.ToString();
                    if(letter == '\r')
                    {
                        Debug.Print(msg);
                        msg = "";
                    }
                }
                Thread.Sleep(100);
            }
        }

    }
}
