using System;
using System.ServiceModel;
using org.tsu.famc.ds.calc.client.proxy;


namespace org.tsu.famc.ds.calc.client
{
    class CalcClnt
    {
        static void Main(string[] args)
        {
            CalcClient client = new CalcClient();

            try
            {
                Console.WriteLine(client.Addition(1, 1));
                Console.WriteLine(client.Subtraction(1, 1));
                Console.WriteLine(client.Multiplication(1, 1));
                Console.WriteLine(client.Division(1, 0));
            }
            catch (FaultException<CalcFault> e)
            {
                Console.WriteLine(e.Detail.Message);
            }
        }
    }
}
