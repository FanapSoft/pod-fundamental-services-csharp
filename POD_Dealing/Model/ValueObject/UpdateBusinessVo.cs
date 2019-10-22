using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;
using POD_Base_Service.Model.ValueObject;

namespace POD_Dealing.Model.ValueObject
{
    public class UpdateBusinessVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public long? BizId { get; }
        public string BusinessName { get; }
        public string CompanyName { get; }
        public string ShopName { get; }
        public string ShopNameEn { get; }
        public string Website { get; }
        public string DateEstablishing { get; }
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
        public bool? ChangeLogo { get; }
        public bool? ChangeCover { get; }
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
        public bool? ChangeAgent { get; }
        public InternalServiceCallVo ServiceCallParameters { get; }

        public UpdateBusinessVo(Builder builder)
        {
            BizId = builder.GetBizId();
            BusinessName = builder.GetBusinessName();
            CompanyName = builder.GetCompanyName();
            ShopName = builder.GetShopName();
            ShopNameEn = builder.GetShopNameEn();
            Website = builder.GetWebsite();
            DateEstablishing = builder.GetDateEstablishing();
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
            ChangeLogo = builder.GetChangeLogo();
            ChangeCover = builder.GetChangeCover();
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
            ChangeAgent = builder.GetChangeAgent();
            ServiceCallParameters = builder.GetServiceCallParameters();
        }

        public class Builder
        {
            [Required]
            private long? bizId;

            [Required]
            private string businessName;
            private string companyName;
            private string shopName;
            private string shopNameEn;
            private string website;

            [RegularExpression(RegexFormat.ShamsiDate)]
            private string dateEstablishing;
            private string firstName;
            private string lastName;
            [RegularExpression(RegexFormat.Sheba)]
            private string sheba;

            [StringLength(11, MinimumLength = 11)]
            private string nationalCode;
            private string economicCode;
            private string registrationNumber;

            [EmailAddress]
            private string email;

            [Required]
            private string[] guildCode;

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
            private bool? changeLogo;
            private bool? changeCover;

            [Url] private string logoImage;

            [Url] private string coverImage;
            private string tags;
            private string tagTrees;
            private string tagTreeCategoryName;

            [Url] private string link;
            private double? lat;
            private double? lng;

            private string agentFirstName;
            private string agentLastName;
            private string agentCellphoneNumber;

            [RegularExpression(RegexFormat.NationalCode)]
            private string agentNationalCode;
            private bool? changeAgent;

            [Required]
            private InternalServiceCallVo serviceCallParameters;

            public long? GetBizId()
            {
                return bizId;
            }

            /// <param name="bizId">شناسه کسب و کار</param>
            public Builder SetBizId(long bizId)
            {
                this.bizId = bizId;
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
            public string GetCompanyName()
            {
                return companyName;
            }

            /// <param name="companyName">نام شرکت</param>
            public Builder SetCompanyName(string companyName)
            {
                this.companyName = companyName.Trim();
                return this;
            }
            public string GetShopName()
            {
                return shopName;
            }

            /// <param name="shopName">نام فروشگاه</param>
            public Builder SetShopName(string shopName)
            {
                this.shopName = shopName.Trim();
                return this;
            }
            public string GetShopNameEn()
            {
                return shopNameEn;
            }

            /// <param name="shopNameEn">نام انگلیسی فروشگاه</param>
            public Builder SetShopNameEn(string shopNameEn)
            {
                this.shopNameEn = shopNameEn.Trim();
                return this;
            }
            public string GetWebsite()
            {
                return website;
            }
            public Builder SetWebsite(string website)
            {
                this.website = website.Trim();
                return this;
            }
            public string GetDateEstablishing()
            {
                return dateEstablishing;
            }

            /// <param name="dateEstablishing">تاریخ شمسی تاسیس</param>
            public Builder SetDateEstablishing(string dateEstablishing)
            {
                this.dateEstablishing = dateEstablishing.Trim();
                return this;
            }

            /// <param name="dateEstablishing">تاریخ میلادی تاسیس</param>
            public Builder SetDateEstablishing(DateTime dateEstablishing)
            {
                this.dateEstablishing = dateEstablishing.ToShamsiDate();
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

            /// <param name="nationalCode">شناسه ملی کسب و کار- 11 رقمی</param>
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
            public bool? GetChangeLogo()
            {
                return changeLogo;
            }


            /// <param name="changeLogo">وارد نمایید true در صورتیکه بخواهید تصویر لوگو را تغییر دهید</param>
            public Builder SetChangeLogo(bool changeLogo)
            {
                this.changeLogo = changeLogo;
                return this;
            }
            public bool? GetChangeCover()
            {
                return changeCover;
            }

            /// <param name="changeCover">وارد نمایید true در صورتیکه بخواهید تصویر کاور را تغییر دهید</param>
            public Builder SetChangeCover(bool changeCover)
            {
                this.changeCover = changeCover;
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

            /// <param name="agentFirstName">نام نماینده</param>
            public Builder SetAgentFirstName(string agentFirstName)
            {
                this.agentFirstName = agentFirstName.Trim();
                return this;
            }

            public string GetAgentLastName()
            {
                return agentLastName;
            }

            /// <param name="agentLastName">نام خانوادگی نماینده</param>
            public Builder SetAgentLastName(string agentLastName)
            {
                this.agentLastName = agentLastName.Trim();
                return this;
            }

            public string GetAgentCellphoneNumber()
            {
                return agentCellphoneNumber;
            }

            /// <param name="agentCellphoneNumber">شماره تلفن نماینده</param>
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
            public bool? GetChangeAgent()
            {
                return changeAgent;
            }

            /// <param name="changeAgent">وارد نمایید true در صورتیکه بخواهید نماینده را تغییر دهید</param>
            public Builder SetChangeAgent(bool changeAgent)
            {
                this.changeAgent = changeAgent;
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

            public UpdateBusinessVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new UpdateBusinessVo(this);
            }
        }
    }
}
