using System.Collections.Generic;

namespace ExternalDataClients.SeattleParksData
{
    public class Metadata
    {
        public string rdfSubject { get; set; }
        public string rdfClass { get; set; }
        //public CustomFields custom_fields { get; set; }
        public string rowIdentifier { get; set; }
        public string rowLabel { get; set; }
        public List<string> availableDisplayTypes { get; set; }
        public RenderTypeConfig renderTypeConfig { get; set; }
    }
}