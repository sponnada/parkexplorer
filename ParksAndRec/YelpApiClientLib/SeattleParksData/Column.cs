using System.Collections.Generic;

namespace ExternalDataClients.SeattleParksData
{
    public class Column
    {
        public int id { get; set; }
        public string name { get; set; }
        public string dataTypeName { get; set; }
        public string fieldName { get; set; }
        public int position { get; set; }
        public string renderTypeName { get; set; }
        public Format format { get; set; }
        public List<string> flags { get; set; }
        public int? tableColumnId { get; set; }
        public int? width { get; set; }
        public CachedContents cachedContents { get; set; }
        public List<string> subColumnTypes { get; set; }
    }
}