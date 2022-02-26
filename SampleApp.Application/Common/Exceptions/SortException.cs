using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApp.Application.Common.Exceptions;

public class SortException : Exception
{
    public SortException()
        : base()
    {
    }

    public SortException(string message)
        : base(message)
    {
    }

    public SortException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    public SortException(string parameterName, object key)
        : base($"Parameter \"{parameterName}\" ({key}) was not found.")
    {
    }
}

