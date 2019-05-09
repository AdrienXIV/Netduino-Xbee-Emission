using System;
using Microsoft.SPOT;
using System.IO.Ports;

namespace Netduino_Zigbee_Essai
{
    class CPortSerie
    {
        public SerialPort PortSerie(String portCOM)
        {
            return new SerialPort(portCOM, 9600, Parity.None, 8, StopBits.One);
        }
    }
}
