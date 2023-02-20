using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace VastraIndiaWebAPI.Models
{
    public class ProductSize
    {
      
        public int ProductSizeId { get; set; }
                    
        public int Product_Id { get; set; }

        public string Size { get; set; }
        public int IsActive { get; set; }
  
        public DateTime Created_Date { get; set; }
 
        public DateTime Updated_Date { get; set; }
    }
}
