using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Exceptions;
public class EmailDuplicateException : Exception
{
    public EmailDuplicateException(string message)
        :base(message)
    {
        
    }
}
