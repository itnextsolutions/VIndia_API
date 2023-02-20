using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace VastraIndiaWebAPI.Models
{
    public class BlogModel
    {

        public int Blog_Id { get; set; }

        public string Blog_Title { get; set; }

        public string Blog_Content { get; set; }


        public string Blog_Topic { get; set; }


        public string Image_Name { get; set; }
        public int IsActive { get; set; }

        public DateTime Created_Date { get; set; }

        public DateTime Updated_Date { get; set; }
    }
}
