using System.Collections.Generic;

namespace ExternalDataClients.SeattleParksData
{
    public class Grant
    {
        public bool inherited { get; set; }
        public string type { get; set; }
        public List<string> flags { get; set; }
    }
}