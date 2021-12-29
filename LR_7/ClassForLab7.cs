using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR_7
{
    class IsNotRightModel : ArgumentException
    {
        string Value { get; set; }
        public IsNotRightModel(string message, string value) : base(message)
        {
            Value = value;
        }
    }

    class IsNotRightPrice : Exception
    {
        int Value { get; set; }
        public IsNotRightPrice(string message, int value) : base(message)
        {
            Value = value;
        }
    }

    class WrongWorkingLifeValue : Exception
    {
        int Value { get; set; }
        public WrongWorkingLifeValue(string message, int value) : base(message)
        {
            Value = value;
        }
    }

    class IsNotScreenDiagonal : Exception
    {
        double Value { get; set; }
        public IsNotScreenDiagonal(string message, double value) : base(message)
        {
            Value = value;
        }
    }
}
