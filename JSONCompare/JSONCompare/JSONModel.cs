using System;
using System.Collections.Generic;
using System.Text;

namespace JSONCompare
{
    public class JSONModel
    {

        public class Rootobject
        {
            public Localizedstring[] LocalizedStrings { get; set; }
            public Localizedcollection[] LocalizedCollections { get; set; }
        }

        public class Localizedstring
        {
            public string ElementType { get; set; }
            public string ElementId { get; set; }
            public string StringId { get; set; }
            public bool Override { get; set; }
            public string Value { get; set; }
        }

        public class Localizedcollection
        {
            public string ElementType { get; set; }
            public string ElementId { get; set; }
            public string TargetCollection { get; set; }
            public bool Override { get; set; }
            public Item[] Items { get; set; }
        }

        public class Item
        {
            public string Name { get; set; }
            public string Value { get; set; }
        }

    }
}
