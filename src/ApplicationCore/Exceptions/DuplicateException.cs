using System;

namespace Microsoft.BookStore.ApplicationCore.Exceptions;

public class DuplicateException : Exception
{
    public DuplicateException(string message) : base(message)
    {

    }

}
