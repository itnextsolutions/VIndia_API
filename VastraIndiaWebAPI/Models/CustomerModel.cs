using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace VastraIndiaWebAPI.Models
{
    public class CustomerModel
    {

        public int Customer_Review_Id { get; set; }
 

        public string Client_Name { get; set; }
 
        public string Profession { get; set; }
  
        public string Review { get; set; }
      
    
        public string Client_Photo { get; set; }

        public DateTime ReviewDate { get; set; }

        public string Rating { get; set; }
        public IFormFile formFile { get; set; }
    }
}
