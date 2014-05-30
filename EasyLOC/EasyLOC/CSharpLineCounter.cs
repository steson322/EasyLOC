using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyLOC
{
    /// <summary>
    /// Line Counter for CSharp
    /// </summary>
    public class CSharpLineCounter : LineCounter
    {
        protected override string RemoveCommentsAndWhiteSpace(string line)
        {
            int fcIndex = line.IndexOf(@"//");
            if (fcIndex > 0)
                line = line.Remove(fcIndex);
            line = line.Replace("{", "");
            line = line.Replace("}", "");
            line = line.Replace("(", "");
            line = line.Replace(")", "");
            line = line.Trim();
            return line;
        }
    }
}
