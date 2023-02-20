using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace VastraIndiaWebAPI.Models
{
    public class ProductModel
    {
        public int Product_Id { get; set; }

        public int Category_Id { get; set; }
        public int SubCategory_Id { get; set; }
        public int[] SizeId { get; set; }

        public int[] ColorId { get; set; }
        public string Product_Title { get; set; }

        public string Product_Description { get; set; }

        public string Image_Name { get; set; }
        //public int IsActive { get; set; }

        //public DateTime Created_Date { get; set; }

        //public DateTime Updated_Date { get; set; }

    }

}
