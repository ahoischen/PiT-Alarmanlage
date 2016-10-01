using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MQTT_Leser;
using System.Diagnostics;

namespace Datenverarbeitung
{
    class Program
    {

        static MqttReader x;
        static void Main(string[] args)
            
        {  //1. Verbindung herstellen


            x = new MqttReader("192.168.1.103", "taster", "Erschutterungssensor");
            x.onNewDataEvent += X_onNewDataEvent;



            //2. Alarm ausgelöst?

           
        

        }


        private static void X_onNewDataEvent(MqttReader.NewDataEventArgs args)
        {

            if (alarmAusloesen(args.Topic, args.Message) && !istBesitzerZuhause())
            {
                var Messenger = new SlackIntegration.SlackMessenger();
                Messenger.PostMessageWithPic("Alarm !");
                x.beepForSeconds(6);
            }

        }



        private static bool istBesitzerZuhause ()
        {
            Process process = Process.Start("python", "Netzwerk.py");
            process.WaitForExit();

            if (File.Exists("marker"))
            {
                Console.WriteLine("Alles gut kein Alarm starten.");
                return true;
            }
            return false;
        }
        private static bool alarmAusloesen (string topic, string text)
        {
           if(topic.Equals ("taster") && text.Equals ("PRESSED BUTTON"))
            {
                return true;
            }
           if(topic.Equals("mikrofon") )
            {
                int zahl = Convert.ToInt32(text);
                if(zahl > 500)
                {
                    return true;
                }
            }
            return false;


        }
    }
}


    

