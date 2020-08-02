using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {

      
      
        static void Main(string[] args)
        {
            ProcessBusinessLogic processBusinessLogic = new ProcessBusinessLogic();
            processBusinessLogic.ProcessCompleted += Bl_ProcessCompleted; // register with an event
            processBusinessLogic.ProcessCompleted += B2_ProcessCompleted; // register with an event

            while (true)
            {
                processBusinessLogic.StartProcess();
                System.Threading.Thread.Sleep(1000);
            }
           
        }

        public static void Bl_ProcessCompleted(object sender, EventArgs e)
        {
            Console.WriteLine("Process Completed!1");
        }
        public static void B2_ProcessCompleted(object sender, EventArgs e)
        {
            Console.WriteLine("Process Completed!2");
        }
    }

    public class ProcessBusinessLogic
    {
        // declaring an event using built-in EventHandler
        public event EventHandler ProcessCompleted;

        public void StartProcess()
        {
            OnProcessCompleted(EventArgs.Empty); //No event data
        }

        protected virtual void OnProcessCompleted(EventArgs e)
        {
            ProcessCompleted?.Invoke(this, e);
        }
    }
}
