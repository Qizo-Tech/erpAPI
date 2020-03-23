using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace qizoErpWebApiApp.Model.Masters
{
    public class Musers
    {
        [Key]
        public int Id { get; set; }
        public int? UserGroupId { get; set; }
        public string UserUserName { get; set; }
        public string UserPassword { get; set; }
        public string UserName { get; set; }
        public string UserAddress1 { get; set; }
        public string UserAddress2 { get; set; }
        public string UserAddress3 { get; set; }
        public string UserPinCode { get; set; }
        public string UserMobileNo { get; set; }
        public string UserContactNos { get; set; }
        public string UserEmail { get; set; }
        public string UserImage { get; set; }
        public int UserCreatedUserId { get; set; }
        public int? UserBranchId { get; set; }

        public virtual MuserGroups UserGroup { get; set; }
    }
}
