using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;
using POD_Base_Service.Model.ValueObject;

namespace POD_Dealing.Model.ValueObject
{
    public class ListUserCreatedBusinessVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public long[] BizId { get; }
        public string[] GuildCode { get; }
        public int? Offset { get; }
        public int? Size { get; }
        public string Query { get; }
        public string[] Tags { get; }
        public string[] TagTrees { get; }
        public bool? Active { get; }
        public string Country { get; }
        public string State { get; }
        public string City { get; }
        public long? SsoId { get; }
        public string Username { get; }
        public string BusinessName { get; }
        public string Sheba { get; }
        public string NationalCode { get; }
        public string EconomicCode { get; }
        public string Email { get; }
        public string Cellphone { get; }
        public InternalServiceCallVo ServiceCallParameters { get; }

        public ListUserCreatedBusinessVo(Builder builder)
        {
            BizId = builder.GetBizId();
            GuildCode = builder.GetGuildCode();
            Offset = builder.GetOffset();
            Size = builder.GetSize();
            Query = builder.GetQuery();
            Tags = builder.GetTags();
            TagTrees = builder.GetTagTrees();
            Active = builder.GetActive();
            Country = builder.GetCountry();
            State = builder.GetState();
            City = builder.GetCity();
            SsoId = builder.GetSsoId();
            Username = builder.GetUsername();
            BusinessName = builder.GetBusinessName();
            Sheba = builder.GetSheba();
            NationalCode = builder.GetNationalCode();
            EconomicCode = builder.GetEconomicCode();
            Email = builder.GetEmail();
            Cellphone = builder.GetCellphone();
            ServiceCallParameters = builder.GetServiceCallParameters();
        }

        public class Builder
        {
            private long[] bizId;
            private string[] guildCode;
            private int? offset;
            private int? size;
            private string query;
            private string[] tags;
            private string[] tagTrees;
            private bool? active;
            private string country;
            private string state;
            private string city;
            private long? ssoId;
            private string username;
            private string businessName;

            [RegularExpression(RegexFormat.Sheba)]
            private string sheba;

            [RegularExpression(RegexFormat.NationalCode)]
            private string nationalCode;
            private string economicCode;

            [EmailAddress] private string email;

            [RegularExpression(RegexFormat.MobileNumber)]
            private string cellphone;

            [Required]
            private InternalServiceCallVo serviceCallParameters;

            public long[] GetBizId()
            {
                return bizId;
            }

            public Builder SetBizId(long[] bizId)
            {
                this.bizId = bizId;
                return this;
            }

            public string[] GetGuildCode()
            {
                return guildCode;
            }

            /// <param name="guildCode">لیست کد صنف کسب و کار</param>
            public Builder SetGuildCode(string[] guildCode)
            {
                this.guildCode = guildCode;
                return this;
            }

            public int? GetOffset()
            {
                return offset;
            }

            public Builder SetOffset(int offset)
            {
                this.offset = offset;
                return this;
            }

            public int? GetSize()
            {
                return size;
            }

            public Builder SetSize(int size)
            {
                this.size = size;
                return this;
            }

            public string GetQuery()
            {
                return query;
            }

            /// <param name="query">مورد جستجو روی کسب و کارهای موجود</param>
            public Builder SetQuery(string query)
            {
                this.query = query.Trim();
                return this;
            }

            public string[] GetTags()
            {
                return tags;
            }

            public Builder SetTags(string[] tags)
            {
                this.tags = tags;
                return this;
            }

            public string[] GetTagTrees()
            {
                return tagTrees;
            }

            public Builder SetTagTrees(string[] tagTrees)
            {
                this.tagTrees = tagTrees;
                return this;
            }

            public bool? GetActive()
            {
                return active;
            }

            public Builder SetActive(bool active)
            {
                this.active = active;
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

            public long? GetSsoId()
            {
                return ssoId;
            }

            /// <param name="ssoId"> کاربر SSO شناسه</param>
            public Builder SetSsoId(long ssoId)
            {
                this.ssoId = ssoId;
                return this;
            }

            public string GetUsername()
            {
                return username;
            }

            /// <param name="username">نام کاربری</param>
            public Builder SetUsername(string username)
            {
                this.username = username.Trim();
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

            public string GetEmail()
            {
                return email;
            }

            public Builder SetEmail(string email)
            {
                this.email = email.Trim();
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
            public InternalServiceCallVo GetServiceCallParameters()
            {
                return serviceCallParameters;
            }

            public Builder SetServiceCallParameters(InternalServiceCallVo serviceCallParameters)
            {
                this.serviceCallParameters = serviceCallParameters;
                return this;
            }

            public ListUserCreatedBusinessVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new ListUserCreatedBusinessVo(this);
            }
        }
    }
}
