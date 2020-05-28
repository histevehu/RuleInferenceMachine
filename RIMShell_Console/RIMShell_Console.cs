using RIM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RuleInferenceMachine.RIMShell_Console
{
    static class Test
    {
        static void Main()
        {
            RIMEngine rimEngine = new RIMEngine();
            rimEngine.CreatKB();
            rimEngine.InputDB();
            rimEngine.Think();
            rimEngine.Explain();
            Console.Read();
         }
    }
}
