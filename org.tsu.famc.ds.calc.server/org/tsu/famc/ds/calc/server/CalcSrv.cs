using System;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace org.tsu.famc.ds.calc.server
{
    class CalcSrv
    {
        static void Main(string[] args)
        {
            // Опрелеяем URI сервиса
            Uri baseAddress = new Uri("http://localhost:8000/Calc/");

            // Создаем сервис
            ServiceHost selfHost = new ServiceHost(typeof(Calc), baseAddress);

            try
            {
                // Связываем сервис с endpoint'ом
                selfHost.AddServiceEndpoint(typeof(ICalc), new WSHttpBinding(), "Calc");

                // Разрешаем считывать метаданные сервиса
                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                selfHost.Description.Behaviors.Add(smb);

                // Стартуем сервис
                selfHost.Open();
                Console.WriteLine("The service is ready.");
                Console.WriteLine("Press <ENTER> to terminate service.");
                Console.WriteLine();
                Console.ReadLine();

                // Останавливаем сервис
                selfHost.Close();
            }
            catch (CommunicationException ce)
            {
                Console.WriteLine("An exception occurred: {0}", ce.Message);
                selfHost.Abort();
            }

        }
    }
}
