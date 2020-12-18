using System.Collections.Generic;

namespace ExternalDataClients.SeattleParksData
{
    public class SeattleParksCachedData
    {
        public Meta meta { get; set; }
        public List<List<object>> data { get; set; }
    }
}