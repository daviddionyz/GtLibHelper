using System;
using System.Collections.Generic;
using System.Text;

namespace GtLibHelper.Persistence
{
    public class DataAccessException : Exception
    {
        public DataAccessException(string msg) : base(msg)
        {

        }
    }
}
