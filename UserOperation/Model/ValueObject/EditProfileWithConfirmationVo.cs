using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;
using POD_Base_Service.Model.ValueObject;
using POD_UserOperation.Base.Enum;

namespace POD_UserOperation.Model.ValueObject
{
    public class EditProfileWithConfirmationVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public string FirstName { get; }
        public string LastName { get; }
        public string NickName { get; }
        public string Email { get; }
        public string PhoneNumber { get; }
        public string CellphoneNumber { get; }
        public string NationalCode { get; }
        public GenderType? Gender { get; }
        public string Address { get; }
        public string BirthDate { get; }
        public string Country { get; }
        public string State { get; }
        public string City { get; }
        public string PostalCode { get; }
        public string Sheba { get; }
        public string ProfileImage { get; }
        public string ClientId { get; }
        public string ClientSecret { get; }
        public string ClientMetadata { get; }
        public string BirthState { get; }
        public string IdentificationNumber { get; }
        public string FatherName { get; }
        public InternalServiceCallVo ServiceCallParameters { get; }

        public EditProfileWithConfirmationVo(Builder builder)
        {
            FirstName = builder.GetFirstName();
            LastName = builder.GetLastName();
            NickName = builder.GetNickName();
            Email = builder.GetEmail();
            PhoneNumber = builder.GetPhoneNumber();
            CellphoneNumber = builder.GetClientId();
            NationalCode = builder.GetNationalCode();
            Gender = builder.GetGender();
            Address = builder.GetAddress();
            BirthDate = builder.GetClientId();
            Country = builder.GetCountry();
            State = builder.GetState();
            City = builder.GetCity();
            PostalCode = builder.GetPostalCode();
            Sheba = builder.GetSheba();
            ProfileImage = builder.GetProfileImage();
            ClientId = builder.GetClientId();
            ClientSecret = builder.GetClientSecret();
            ClientMetadata = builder.GetClientMetadata();
            BirthState = builder.GetBirthState();
            IdentificationNumber = builder.GetIdentificationNumber();
            FatherName = builder.GetFatherName();
            ServiceCallParameters = builder.GetServiceCallParameters();
        }

        public class Builder
        {
            private string firstName;
            private string lastName;

            [Required]
            private string nickName;

            [EmailAddress]
            private string email;

            [RegularExpression(RegexFormat.MobileNumber)]
            private string phoneNumber;
            private string cellphoneNumber;

            [RegularExpression(RegexFormat.NationalCode)]
            private string nationalCode;
            private GenderType? gender;
            private string address;

            [RegularExpression(RegexFormat.ShamsiDate)]
            private string birthDate;
            private string country;
            private string state;
            private string city;

            [RegularExpression(RegexFormat.PostalCode)]
            private string postalCode;

            [RegularExpression(RegexFormat.Sheba)]
            private string sheba;

            [Url]
            private string profileImage;
            private string clientId;
            private string clientSecret;
            private string clientMetadata;
            private string birthState;
            private string identificationNumber;
            private string fatherName;

            [Required]
            private InternalServiceCallVo serviceCallParameters;

            public string GetFirstName()
            {
                return firstName;
            }

            /// <summary>
            /// scope: profile
            /// </summary>
            public Builder SetFirstName(string firstName)
            {
                this.firstName = firstName;
                return this;
            }
            public string GetLastName()
            {
                return lastName;
            }

            /// <summary>
            /// scope: profile
            /// </summary>
            public Builder SetLastName(string lastName)
            {
                this.lastName = lastName;
                return this;
            }
            public string GetNickName()
            {
                return nickName;
            }

            /// <summary>
            /// scope: profile
            /// </summary>
            /// <param name="nickName">نام مستعار که باید یکتا باشد</param>
            public Builder SetNickName(string nickName)
            {
                this.nickName = nickName;
                return this;
            }
            public string GetEmail()
            {
                return email;
            }

            /// <summary>
            /// scope: email
            /// </summary>           
            public Builder SetEmail(string email)
            {
                this.email = email;
                return this;
            }
            public string GetPhoneNumber()
            {
                return phoneNumber;
            }

            /// <summary>
            /// scope: address
            /// </summary>
            public Builder SetPhoneNumber(string phoneNumber)
            {
                this.phoneNumber = phoneNumber;
                return this;
            }
            public string GetCellphoneNumber()
            {
                return cellphoneNumber;
            }

            /// <summary>
            /// scope: phone
            /// </summary>           
            public Builder SetCellphoneNumber(string cellphoneNumber)
            {
                this.cellphoneNumber = cellphoneNumber;
                return this;
            }
            public string GetNationalCode()
            {
                return nationalCode;
            }

            /// <summary>
            /// scope: legal
            /// </summary>            
            public Builder SetNationalCode(string nationalCode)
            {
                this.nationalCode = nationalCode;
                return this;
            }
            public GenderType? GetGender()
            {
                return gender;
            }

            /// <summary>
            /// scope: profile
            /// </summary>
            public Builder SetGender(GenderType gender)
            {
                this.gender = gender;
                return this;
            }
            public string GetAddress()
            {
                return address;
            }

            /// <summary>
            /// scope: address
            /// </summary>
            public Builder SetAddress(string address)
            {
                this.address = address;
                return this;
            }


            public string GetBirthDate()
            {
                return birthDate;
            }
            /// <summary>
            /// scope: legal
            /// </summary>
            /// <param name="birthDate">تاریخ شمسی تولد yyyy/mm/dd</param>
            public Builder SetBirthDate(string birthDate)
            {                
                this.birthDate = birthDate;
                return this;
            }

            /// <summary>
            /// scope: legal
            /// </summary>
            /// <param name="date">تاریخ میلادی تولد</param>
            public Builder SetBirthDate(DateTime date)
            {
                this.birthDate = date.ToShamsiDate();
                return this;
            }
            public string GetCountry()
            {
                return country;
            }

            /// <summary>
            /// scope: address
            /// </summary>
            public Builder SetCountry(string country)
            {
                this.country = country;
                return this;
            }
            public string GetState()
            {
                return state;
            }

            /// <summary>
            /// scope: address
            /// </summary>
            public Builder SetState(string state)
            {
                this.state = state;
                return this;
            }       
            public string GetCity()
            {
                return city;
            }

            /// <summary>
            /// scope: address
            /// </summary>
            public Builder SetCity(string city)
            {
                this.city = city;
                return this;
            }
            public string GetPostalCode()
            {
                return postalCode;
            }

            /// <summary>
            /// scope: address
            /// </summary>
            public Builder SetPostalCode(string postalCode)
            {
                this.postalCode = postalCode;
                return this;
            }
            public string GetSheba()
            {
                return sheba;
            }

            /// <summary> 
            /// scope: legal 
            /// </summary>
            /// <param name="sheba">شبا که به صورت عددی وارد می شود (IR بدون)</param>
            public Builder SetSheba(string sheba)
            {
                this.sheba = sheba;
                return this;
            }
            public string GetProfileImage()
            {
                return profileImage;
            }
            /// <summary>
            /// scope: profile
            /// </summary>
            /// <param name="profileImage">تصویر پروفایل کاربر</param>
            public Builder SetProfileImage(string profileImage)
            {
                this.profileImage = profileImage;
                return this;
            }
            public string GetClientId()
            {
                return clientId;
            }

            public Builder SetClientId(string clientId)
            {
                this.clientId = clientId;
                return this;
            }
            public string GetClientSecret()
            {
                return clientSecret;
            }

            public Builder SetClientSecret(string clientSecret)
            {
                this.clientSecret = clientSecret;
                return this;
            }
            public string GetClientMetadata()
            {
                return clientMetadata;
            }

            /// <param name="clientMetadata">SSO client_metadata</param>
            public Builder SetClientMetadata(string clientMetadata)
            {
                this.clientMetadata = clientMetadata;
                return this;
            }
            public string GetBirthState()
            {
                return birthState;
            }

            /// <param name="birthState">محل تولد</param>
            public Builder SetBirthState(string birthState)
            {
                this.birthState = birthState;
                return this;
            }
            public string GetIdentificationNumber()
            {
                return identificationNumber;
            }

            /// <param name="identificationNumber">شماره شناسنامه</param>
            public Builder SetIdentificationNumber(string identificationNumber)
            {
                this.identificationNumber = identificationNumber;
                return this;
            }
            public string GetFatherName()
            {
                return fatherName;
            }

            /// <param name="fatherName">نام پدر</param>
            public Builder SetFatherName(string fatherName)
            {
                this.fatherName = fatherName;
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

            public EditProfileWithConfirmationVo Build()
            {
                var hasErrorFields=this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new EditProfileWithConfirmationVo(this);
            }
        }
    }
}
