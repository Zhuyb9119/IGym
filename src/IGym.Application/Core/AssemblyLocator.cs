using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace IGym.Application.Core
{
    public static class AssemblyLocator
    {
        public static IList<string> AssemblyFinder(string dllDir, string match = "")
        {
            List<string> ass = new List<string>();

            var items = Directory.GetFiles(dllDir, "*.dll");
            if (items.Length == 0) return ass;

            ass = new List<string>(items);

            if (!string.IsNullOrEmpty(match))
            {
                return ass.Where(x => x == match || x.Contains(match)).ToList();
            }

            return ass;
        }
    }
}
