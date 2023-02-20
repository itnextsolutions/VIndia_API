using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VastraIndiaWebAPI.Models
{
    [Table("tbl_Login")]
    public partial class TblLogin
    {
        [Key]
        [Column("Login_Id")]
        public int LoginId { get; set; }
        [StringLength(50)]
        public string UserName { get; set; }
        public string Password { get; set; }
        public string EncodePassword { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        public int? IsLogedIn { get; set; }
    }
}
