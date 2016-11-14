using System;
using ANT_Managed_Library;
using AntPlus.Profiles.HeartRate;
using AntPlus.Types;

namespace HelloAnt
{
    class Program
    {
        static void Main(string[] args)
        {
            byte USER_RADIOFREQ = 57;           // RF Frequency + 2400 MHz
            //Do not distrubute this key
            byte[] USER_NETWORK_KEY = { 0xB9, 0xA5, 0x21, 0xFB, 0xBD, 0x72, 0xC3, 0x45 }; 
            byte USER_NETWORK_NUM = 0;

            ANT_Device USB_Dongle;
            USB_Dongle = new ANT_Device();
            USB_Dongle.ResetSystem();
            USB_Dongle.setNetworkKey(USER_NETWORK_NUM, USER_NETWORK_KEY);
            ANT_Channel Channel0 = USB_Dongle.getChannel(0);
            Network AntPlusNetwork = new Network(USER_NETWORK_NUM, USER_NETWORK_KEY, USER_RADIOFREQ);
            HeartRateDisplay HeartRate = new HeartRateDisplay(Channel0, AntPlusNetwork);
            HeartRate.TurnOn();
            while (Console.KeyAvailable == false)
            {
                Console.WriteLine("Heart Rate=" + HeartRate.HeartRate);
                System.Threading.Thread.Sleep(500);
            }
        }
    }
}


