using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ThesisPrototype.DataModels
{
    /// <summary>
    /// A DTO that contains the shipId and the date for a given import.
    /// This DTO gets persisted to EF when an import has been processed.
    /// </summary>
    public class DataImportMeta
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DataImportMetaId { get; set; }
        public long ShipId { get; set; }
        public DateTime ImportDate { get; set; }

        public DataImportMeta(long shipId, DateTime importDate)
        {
            this.ShipId = shipId;
            this.ImportDate = importDate;
        }
    }
}
