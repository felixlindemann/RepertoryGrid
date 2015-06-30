using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LimeTree.Extensions
{
    /// <summary>
    /// An interface for tasks that should be executed on startup.
    /// </summary>
    public interface IStartupTask
    {
        void Execute();
    }
}
