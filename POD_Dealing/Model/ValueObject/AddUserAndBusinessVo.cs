using POD_Base_Service.Exception;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using POD_Base_Service.Base;
using POD_Base_Service.Model.ValueObject;

namespace POD_Dealing.Model.ValueObject
{
    public class AddUserAndBusinessVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public string Username { get; }
        public string BusinessName { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Sheba { get; }
        public string NationalCode { get; }
        public string EconomicCode { get; }
        public string RegistrationNumber { get; }
        public string Email { get; }
        public string[] GuildCode { get; }
        public string Cellphone { get; }
        public string Phone { get; }
        public string Fax { get; }
        public string PostalCode { get; }
        public string Country { get; }
        public string State { get; }
        public string City { get; }
        public string Address { get; }
        public string Description { get; }
        public bool? NewsReader { get; }
        public string LogoImage { get; }
        public string CoverImage { get; }
        public string Tags { get; }
        public string TagTrees { get; }
        public string TagTreeCategoryName { get; }
        public string Link { get; }
        public double? Lat { get; }
        public double? Lng { get; }
        public string AgentFirstName { get; }
        public string AgentLastName { get; }
        public string AgentCellphoneNumber { get; }
        public string AgentNationalCode { get; }
        public InternalServiceCallVo ServiceCallParameters { get; }

        public AddUserAndBusinessVo(Builder builder)
        {
            Username = builder.GetUsername();
            BusinessName = builder.GetBusinessName();
            FirstName = builder.GetFirstName();
            LastName = builder.GetLastName();
            Sheba = builder.GetSheba();
            NationalCode = builder.GetNationalCode();
            EconomicCode = builder.GetEconomicCode();
            RegistrationNumber = builder.GetRegistrationNumber();
            Email = builder.GetEmail();
            GuildCode = builder.GetGuildCode();
            Cellphone = builder.GetCellphone();
            Phone = builder.GetPhone();
            Fax = builder.GetFax();
            PostalCode = builder.GetPostalCode();
            Country = builder.GetCountry();
            State = builder.GetState();
            City = builder.GetCity();
            Address = builder.GetAddress();
            Description = builder.GetDescription();
            NewsReader = builder.GetNewsReader();
            LogoImage = builder.GetLogoImage();
            CoverImage = builder.GetCoverImage();
            Tags = builder.GetTags();
            TagTrees = builder.GetTagTrees();
            TagTreeCategoryName = builder.GetTagTreeCategoryName();
            Link = builder.GetLink();
            Lat = builder.GetLat();
            Lng = builder.GetLng();
            AgentFirstName = builder.GetAgentFirstName();
            AgentLastName = builder.GetAgentLastName();
            AgentCellphoneNumber = builder.GetAgentCellphoneNumber();
            AgentNationalCode = builder.GetAgentNationalCode();
            ServiceCallParameters = builder.GetServiceCallParameters();
        }

        public class Builder
        {
            [Required] private string username;

            [Required] private string businessName;
            private string firstName;
            private string lastName;

            [RegularExpression(RegexFormat.Sheba)]
            private string sheba;

            [RegularExpression(RegexFormat.NationalCode)]
            private string nationalCode;
            private string economicCode;
            private string registrationNumber;

            [EmailAddress] [Required] private string email;

            [Required] private string[] guildCode; //guildCode[]

            [RegularExpression(RegexFormat.MobileNumber)]
            private string cellphone;

            private string phone;
            private string fax;

            [RegularExpression(RegexFormat.PostalCode)]
            private string postalCode;

            [Required] private string country;

            [Required] private string state;

            [Required] private string city;

            [Required] private string address;

            [Required] private string description;
            private bool? newsReader;

            [Url] private string logoImage;

            [Url] private string coverImage;
            private string tags;
            private string tagTrees;
            private string tagTreeCategoryName;

            [Url] private string link;
            private double? lat;
            private double? lng;

            [Required] private string agentFirstName;

            [Required] private string agentLastName;
            private string agentCellphoneNumber;

            [RegularExpression(RegexFormat.NationalCode)]
            private string agentNationalCode;

            [Required] private InternalServiceCallVo serviceCallParameters;

            public string GetUsername()
            {
                return username;
            }

            /// <param name="username">
            ///نام کاربری کسب و کار جدید
            ///منحصر به فرد باشد، حتما با حروف انگلیسی ثبت گردد
            /// </param>
            public Builder SetUsername(string username)
            {
                this.username = Regex.Replace(username, RegexFormat.WhiteSpace, "");
                return this;
            }

            public string GetBusinessName()
            {
                return businessName;
            }


            /// <param name="businessName">نام کسب و کار</param>
            public Builder SetBusinessName(string businessName)
            {
                this.businessName = businessName.Trim();
                return this;
            }

            public string GetFirstName()
            {
                return firstName;
            }

            /// <param name="firstName">نام شخص نماینده کسب و کار</param>
            public Builder SetFirstName(string firstName)
            {
                this.firstName = firstName.Trim();
                return this;
            }

            public string GetLastName()
            {
                return lastName;
            }

            /// <param name="lastName">نام خانوادگی شخص نماینده کسب و کار</param>
            public Builder SetLastName(string lastName)
            {
                this.lastName = lastName.Trim();
                return this;
            }

            public string GetSheba()
            {
                return sheba;
            }

            /// <param name="sheba">شبا که به صورت عددی وارد می شود (IR بدون)</param>
            public Builder SetSheba(string sheba)
            {
                this.sheba = sheba.Trim();
                return this;
            }

            public string GetNationalCode()
            {
                return nationalCode;
            }

            /// <param name="nationalCode">شناسه ملی کسب و کار- 10 رقمی</param>
            public Builder SetNationalCode(string nationalCode)
            {
                this.nationalCode = nationalCode.Trim();
                return this;
            }

            public string GetEconomicCode()
            {
                return economicCode;
            }

            /// <param name="economicCode">کد اقتصادی کسب و کار</param>
            public Builder SetEconomicCode(string economicCode)
            {
                this.economicCode = economicCode.Trim();
                return this;
            }

            public string GetRegistrationNumber()
            {
                return registrationNumber;
            }

            /// <param name="registrationNumber">شماره ثبت کسب و کار</param>
            public Builder SetRegistrationNumber(string registrationNumber)
            {
                this.registrationNumber = registrationNumber.Trim();
                return this;
            }

            public string GetEmail()
            {
                return email;
            }

            public Builder SetEmail(string email)
            {
                this.email = email.Trim();
                return this;
            }

            public string[] GetGuildCode()
            {
                return guildCode;
            }

            /// <param name="guildCode">لیست کد اصناف</param>
            public Builder SetGuildCode(string[] guildCode)
            {
                this.guildCode = guildCode;
                return this;
            }

            public string GetCellphone()
            {
                return cellphone;
            }

            /// <param name="cellphone">شماره موبایل نماینده کسب و کار</param>
            public Builder SetCellphone(string cellphone)
            {
                this.cellphone = cellphone.Trim();
                return this;
            }

            public string GetPhone()
            {
                return phone;
            }

            public Builder SetPhone(string phone)
            {
                this.phone = phone.Trim();
                return this;
            }

            public string GetFax()
            {
                return fax;
            }

            public Builder SetFax(string fax)
            {
                this.fax = fax.Trim();
                return this;
            }

            public string GetPostalCode()
            {
                return postalCode;
            }

            public Builder SetPostalCode(string postalCode)
            {
                this.postalCode = postalCode.Trim();
                return this;
            }

            public string GetCountry()
            {
                return country;
            }

            /// <param name="country">کشور محل کسب و کار</param>
            public Builder SetCountry(string country)
            {
                this.country = country.Trim();
                return this;
            }

            public string GetState()
            {
                return state;
            }

            /// <param name="state">استان محل کسب و کار</param>
            public Builder SetState(string state)
            {
                this.state = state.Trim();
                return this;
            }

            public string GetCity()
            {
                return city;
            }

            public Builder SetCity(string city)
            {
                this.city = city.Trim();
                return this;
            }

            public string GetAddress()
            {
                return address;
            }

            public Builder SetAddress(string address)
            {
                this.address = address.Trim();
                return this;
            }

            public string GetDescription()
            {
                return description;
            }

            public Builder SetDescription(string description)
            {
                this.description = description.Trim();
                return this;
            }

            public bool? GetNewsReader()
            {
                return newsReader;
            }

            /// <param name="newsReader">دسترسی خواندن اخبار کسب و کارهای دیگر</param>
            public Builder SetNewsReader(bool newsReader)
            {
                this.newsReader = newsReader;
                return this;
            }

            public string GetLogoImage()
            {
                return logoImage;
            }

            /// <param name="logoImage">url تصویر لوگو کسب و کار</param>
            public Builder SetLogoImage(string logoImage)
            {
                this.logoImage = logoImage.Trim();
                return this;
            }

            public string GetCoverImage()
            {
                return coverImage;
            }

            /// <param name="coverImage">url تصویر کاور کسب و کار</param>
            public Builder SetCoverImage(string coverImage)
            {
                this.coverImage = coverImage.Trim();
                return this;
            }

            public string GetTags()
            {
                return tags;
            }

            public Builder SetTags(string[] tags)
            {
                this.tags = string.Join(",", tags);
                return this;
            }

            public string GetTagTrees()
            {
                return tagTrees;
            }

            public Builder SetTagTrees(string[] tagTrees)
            {
                this.tagTrees = string.Join(",", tagTrees);
                return this;
            }

            public string GetTagTreeCategoryName()
            {
                return tagTreeCategoryName;
            }

            public Builder SetTagTreeCategoryName(string tagTreeCategoryName)
            {
                this.tagTreeCategoryName = tagTreeCategoryName.Trim();
                return this;
            }

            public string GetLink()
            {
                return link;
            }

            /// <param name="link">SSO لینک دسترسی به کسب و کار از طریق</param>
            public Builder SetLink(string link)
            {
                this.link = link.Trim();
                return this;
            }

            public double? GetLat()
            {
                return lat;
            }

            /// <param name="lat">عرض جغرافیایی</param>
            public Builder SetLat(double lat)
            {
                this.lat = lat;
                return this;
            }

            public double? GetLng()
            {
                return lng;
            }

            /// <param name="lng">طول جغرافیایی</param>
            public Builder SetLng(double lng)
            {
                this.lng = lng;
                return this;
            }

            public string GetAgentFirstName()
            {
                return agentFirstName;
            }

            public Builder SetAgentFirstName(string agentFirstName)
            {
                this.agentFirstName = agentFirstName.Trim();
                return this;
            }

            public string GetAgentLastName()
            {
                return agentLastName;
            }

            public Builder SetAgentLastName(string agentLastName)
            {
                this.agentLastName = agentLastName.Trim();
                return this;
            }

            public string GetAgentCellphoneNumber()
            {
                return agentCellphoneNumber;
            }

            public Builder SetAgentCellphoneNumber(string agentCellphoneNumber)
            {
                this.agentCellphoneNumber = agentCellphoneNumber.Trim();
                return this;
            }

            public string GetAgentNationalCode()
            {
                return agentNationalCode;
            }

            /// <param name="agentNationalCode">کد ملی نماینده</param>
            public Builder SetAgentNationalCode(string agentNationalCode)
            {
                this.agentNationalCode = agentNationalCode.Trim();
                return this;
            }

            public InternalServiceCallVo GetServiceCallParameters()
            {
                return serviceCallParameters;
            }

            public Builder SetServiceCallParameters(InternalServiceCallVo serviceCallParameters)
            {
                this.serviceCallParameters = serviceCallParameters;
                return this;
            }

            public AddUserAndBusinessVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new AddUserAndBusinessVo(this);
            }
        }
    }
}
