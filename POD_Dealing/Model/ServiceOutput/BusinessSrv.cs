using System.Collections.Generic;
using POD_Base_Service.Model.ServiceOutput;

namespace POD_Dealing.Model.ServiceOutput
{
    public class BusinessSrv
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<GuildSrv> Guilds { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string CoverImage { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Postalcode { get; set; }
        public string Phone { get; set; }
        public string Cellphone { get; set; }
        public string FaxNumber { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int SubscriptionCount { get; set; }
        public bool Subscribed { get; set; }
        public int numOfComments { get; set; }
        public RateSrv Rate { get; set; }
        public long UserId { get; set; }
        public string SsoId { get; set; }
        public int NumOfProducts { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalCode { get; set; }
        public string EconomicCode { get; set; }
        public string RegistrationNumber { get; set; }
        public string Sheba { get; set; }
        public string Email { get; set; }
        public string FullAddress { get; set; }
        public List<string> Tags { get; set; }
        public List<string> TagTrees { get; set; }
        public string Link { get; set; }
        public bool Active { get; set; }
        public string ApiToken { get; set; }
        public BusinessAgentSrv Agent { get; set; }
        public long NumOfLike { get; set; }
        public long NumOfDislike { get; set; }
        public BusinessLegalInfoSrv LegalInfo { get; set; }
        public string Username { get; set; }
    }
}
