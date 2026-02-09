using System;

namespace LicenseDTO
{
    public class LicenseDTO
    {

        public enum enIssueReason { FirstTime = 1, Renew = 2, ReplacementforDamaged = 3, ReplacementforLost = 4 };
        public int LicenseID { get; set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public int LicenseClassID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Notes { get; set; }
        public decimal PaidFees { get; set; }
        public bool IsActive { get; set; }
        public enIssueReason IssueReason { get; set; }
        public int CreatedByUserID { get; set; }
    }
}
