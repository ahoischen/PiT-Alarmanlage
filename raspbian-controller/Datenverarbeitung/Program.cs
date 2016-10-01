using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Datenverarbeitung
{
    class Program
    {
        
        static void Main(string[] args)
            
        {  //1. Verbindung herstellen
            slackIntegration
            



            //2. Alarm ausgelöst?
 
            if(alarmAusloesen() && !istBesitzerZuhause() )
            {

                Console.WriteLine("auslösen");

            }

        }

        private static bool istBesitzerZuhause ()
        {
            string[] dirs = Directory.GetFiles(@"c:\Users\doslabor\Desktop\", "marker.txt");
            Console.WriteLine("The number of files starting with c is {0}.", dirs.Length);
            if (dirs.Length >= 1)
            {
                Console.WriteLine("Alles gut kein Alarm starten.");
                return true;
            }
            return false;
        }
        private static bool alarmAusloesen ()
        {
           
                bool Lichtschranke = false;
                int Erschuetterungssensor = 0;

                bool alarm_ausloesen = false;
                 // alarm_ausloesen einlesen

                if (Lichtschranke == true || Erschuetterungssensor >= 20)
                {
                    alarm_ausloesen = true;
                    return true;
                }

                return false;
            
        }
    }
}


    

