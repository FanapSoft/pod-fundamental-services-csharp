using System;

namespace POD_VirtualAccount.Model.ServiceOutput
{
    public class ContactSrv
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string CellphoneNumber { get; set; }
        public string UniqueId { get; set; }
        public RelatedUserSrv LinkedUser { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastModifyDate { get; set; }
        public string ContactType { get; set; }
    }
}
