using System;
using System.Collections.Generic;
using System.Text;

namespace JSONCompare
{
    class JsonObj
    {
        public List<Dictionary<string, object>> LocalizedStrings { get; set; }
        public List<Dictionary<string, object>> LocalizedCollections { get; set; }
    }
}
