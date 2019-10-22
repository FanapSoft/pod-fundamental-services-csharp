using POD_Base_Service.Model.ServiceOutput;

namespace POD_Billing.Model.ServiceOutput.Settlement
{
    public class CustomerProfileSrv
    {
        public int Version { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Email_Unverified { get; set; }
        public string PhoneNumber { get; set; }
        public string NationalCode { get; set; }
        public string NationalCode_verified { get; set; }
        public string Gender { get; set; }
        public AddressSrv AddressSrv { get; set; }
        public string NickName { get; set; }
        public long BirthDate { get; set; }
        public long Score { get; set; }
        public long FollowingCount { get; set; }
        public ImageInfoSrv ImageInfo { get; set; }
        public string ProfileImage { get; set; }
        public long JoinDate { get; set; }
        public string CellphoneNumber { get; set; }
        public string CellphoneNumber_Unverified { get; set; }
        public long UserId { get; set; }
        public string Sheba { get; set; }
        public bool Guest { get; set; }
        public bool ChatSendEnable { get; set; }
        public bool ChatReceiveEnable { get; set; }
        public string Username { get; set; }
        public string SsoId { get; set; }
        public int SsoIssuerCode { get; set; }
        public string Client_Metadata { get; set; }
        public string ReadOnlyFields { get; set; }
        public bool Follower { get; set; }
        public CustomerLegalInfo LegalInfo { get; set; }
        public FinancialLevelSrv FinancialLevelSrv { get; set; }
    }
}
