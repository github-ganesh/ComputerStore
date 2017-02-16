using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTest.ComputerStore.Exceptions
{
    public class OfferNotValidException : Exception
    {
        public OfferNotValidException(string message)
            : base(message)
        { }
    }
}
