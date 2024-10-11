using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleLogger
{
    public interface ISimpleLoggerModule
    {
        ISimpleLoggerManager GetManager();
    }
}
