using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace IGym.Application.Core
{
    public static class AssemblyLocator
    {
        public static IList<string> AssemblyFinder(string dllDir)
        {
            IList<string> ass = new List<string>();
            var items = Directory.GetFiles(dllDir, "*.dll");
            if (items.Length == 0) return ass;

            ass = new List<string>(items);

            return ass;
        }
    }
}
