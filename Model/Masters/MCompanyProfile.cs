using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace qizoErpWebApiApp.Model.Masters
{
    public class MCompanyProfile
    {
        [Key]
        public int CompanyProfileId { get; set; }
        public string CompanyProfileName { get; set; }
        public string CompanyProfileShortName { get; set; }
        public string CompanyProfileMailingName { get; set; }
        public string CompanyProfileAddress1 { get; set; }
        public string CompanyProfileAddress2 { get; set; }
        public string CompanyProfileAddress3 { get; set; }
        public string CompanyProfileGstNo { get; set; }
        public string CompanyProfilePan { get; set; }
        public string CompanyProfileMobile { get; set; }
        public string CompanyProfileContact { get; set; }
        public string CompanyProfileEmail { get; set; }
        public string CompanyProfileWeb { get; set; }
        public string CompanyProfileBankName { get; set; }
        public string CompanyProfileAccountNo { get; set; }
        public string CompanyProfileBranch { get; set; }
        public string CompanyProfileIfsc { get; set; }
        public string CompanyProfileImagePath { get; set; }
        public int? CompanyProfileIsPrintHead { get; set; }
        public int? CompanyProfileStateId { get; set; }

    }
}
