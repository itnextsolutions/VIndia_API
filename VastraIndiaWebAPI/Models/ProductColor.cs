using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace VastraIndiaWebAPI.Models
{
    public class ProductColor
    {
        public int Product_Color_Id { get; set; }
   
        public int Product_Id { get; set; }
     
        public int Color_Code { get; set; }
        public int IsActive { get; set; }
    
        public DateTime? Created_Date { get; set; }
    
        public DateTime? Updated_Date { get; set; }
     
    }
 
}
