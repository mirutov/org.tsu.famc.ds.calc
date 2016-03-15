using System.ServiceModel;
using System.Runtime.Serialization;

namespace org.tsu.famc.ds.calc
{
    [ServiceContract]
    public interface ICalc
    {
        [OperationContract]
        double Addition(double a, double b);
        [OperationContract]
        double Subtraction(double a, double b);
        [OperationContract]
        double Multiplication(double a, double b);
        [OperationContract]
        [FaultContract(typeof(CalcFault))]
        double Division(double a, double b);
    }

    [DataContract]
    public class CalcFault
    {
        private string _message;

        public CalcFault(string message)
        {
            _message = message;
        }

        [DataMember]
        public string Message { get { return _message; } set { _message = value; } }
    }
}
