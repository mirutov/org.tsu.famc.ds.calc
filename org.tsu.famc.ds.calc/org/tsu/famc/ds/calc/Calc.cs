using System;
using System.ServiceModel;


namespace org.tsu.famc.ds.calc
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Calc : ICalc
    {
        long count;

        public Calc()
        {
            count = 0;
        }

        private void Log(string msg)
        {
            Console.WriteLine(count + ": " + msg);
        }

        public double Addition(double a, double b)
        {
            count++;
            Log(a + " + " + b);
            return a + b;
        }

        public double Subtraction(double a, double b)
        {
            count++;
            Log(a + " - " + b);
            return a - b;
        }

        public double Multiplication(double a, double b)
        {
            count++;
            Log(a + " * " + b);
            return a * b;
        }

        [FaultContract(typeof(CalcFault))]
        public double Division(double a, double b)
        {
            count++;
            Log(a + " / " + b);
            if (b == 0)
            {
                throw new FaultException<CalcFault>(new CalcFault("Divide by zero"));
            }
            return a / b;
        }
    }
}
