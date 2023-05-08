using System;
using System.IO;

namespace AuthenticationService
{
    public class Logger:ILogger
    {
        public async void WriteEvent(string eventMessage)
        {
            Console.WriteLine(eventMessage);
            var sw = new StreamWriter(Startup.txtEventsPath, true);
            
            using (sw)
            {
                await sw.WriteLineAsync(eventMessage);
            }
            sw.Close();
        }


        public async void WriteError(string errorMessage)
        {
            Console.WriteLine(errorMessage);
            var sw = new StreamWriter(Startup.txtErrorsPath, true);
            using (sw)
            {
                await sw.WriteLineAsync(errorMessage);
            }
            sw.Close();
        }

  
        
    }
}
