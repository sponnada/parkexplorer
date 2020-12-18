using System.Collections.Generic;

namespace ExternalDataClients.SeattleParksData
{
    public class View
    {
        public string id { get; set; }
        public string name { get; set; }
        public string attribution { get; set; }
        public string attributionLink { get; set; }
        public int averageRating { get; set; }
        public string category { get; set; }
        public int createdAt { get; set; }
        public string description { get; set; }
        public string displayType { get; set; }
        public int downloadCount { get; set; }
        public bool hideFromCatalog { get; set; }
        public bool hideFromDataJson { get; set; }
        public int indexUpdatedAt { get; set; }
        public bool newBackend { get; set; }
        public int numberOfComments { get; set; }
        public int oid { get; set; }
        public string provenance { get; set; }
        public bool publicationAppendEnabled { get; set; }
        public int publicationDate { get; set; }
        public int publicationGroup { get; set; }
        public string publicationStage { get; set; }
        public string rowClass { get; set; }
        public int rowsUpdatedAt { get; set; }
        public string rowsUpdatedBy { get; set; }
        public int tableId { get; set; }
        public int totalTimesRated { get; set; }
        public int viewCount { get; set; }
        public int viewLastModified { get; set; }
        public string viewType { get; set; }
        public List<Column> columns { get; set; }
        public List<Grant> grants { get; set; }
        public Metadata metadata { get; set; }
        public Owner owner { get; set; }
        public Query query { get; set; }
        public List<string> rights { get; set; }
        public TableAuthor tableAuthor { get; set; }
        public List<string> tags { get; set; }
        public List<string> flags { get; set; }
    }
}