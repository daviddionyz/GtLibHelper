using System;

namespace GtLibHelper.Persistence
{
    public class DataAccessException : Exception
    {
        public DataAccessException(string msg) : base(msg)
        {

        }
    }
}
