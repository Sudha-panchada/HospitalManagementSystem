using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinancialDataServices.Model
{
    [Table("financialdata1")]
    public class Financialdata
    {
        [Key]
        public int id { get; set; }

        public string? name { get; set; }

        public string? instrument {  get; set; }

        public DateTime purchaseDate {  get; set; }
        public decimal purchaseprice {  get; set; }

        public decimal price {  get; set; }

        public string? timelineprice {  get; set; }

        public int quntity { get; set; }

    }
}
