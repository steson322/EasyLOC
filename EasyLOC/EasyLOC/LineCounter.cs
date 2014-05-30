using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace EasyLOC
{
    /// <summary>
    /// An abstract class for line counter
    /// </summary>
    public abstract class LineCounter
    {
        /// <summary>
        /// Source code in each file
        /// </summary>
        protected Dictionary<string, string> SourceCode;

        /// <summary>
        /// Initialize a line counter with file list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="files">file directories</param>
        /// <returns></returns>
        public void LoadFile(List<string> files)
        {
            SourceCode = new Dictionary<string, string>();
            foreach (var file in files)
                if (File.Exists(file))
                    SourceCode[file] = File.ReadAllText(file);
        }

        /// <summary>
        /// Remove comments from an line
        /// </summary>
        /// <returns></returns>
        protected abstract string RemoveCommentsAndWhiteSpace(string line);

        /// <summary>
        /// Count of lines
        /// </summary>
        /// <returns></returns>
        public long Count()
        { 
            long count = 0;
            foreach(var sc in SourceCode.Values)
            {
                List<string> lines = sc.Split('\n').ToList();
                foreach(var line in lines.ToArray())
                    if (String.IsNullOrWhiteSpace(RemoveCommentsAndWhiteSpace(line).Trim()))
                        lines.Remove(line);
                count += lines.Count;
            }
            return count;
        }
    }
}
