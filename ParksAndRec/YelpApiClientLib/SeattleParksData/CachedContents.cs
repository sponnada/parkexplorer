using System.Collections.Generic;

namespace ExternalDataClients.SeattleParksData
{
    public class CachedContents
    {
        public int non_null { get; set; }
        public string average { get; set; }
        public object largest { get; set; }
        public int @null { get; set; }
        public List<Top> top { get; set; }
        public object smallest { get; set; }
        public string sum { get; set; }
    }
}