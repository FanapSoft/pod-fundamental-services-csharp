using System.ComponentModel.DataAnnotations;
using System.Linq;
using Booking_Service.Base.Enum;
using POD_Base_Service.Base;
using POD_Base_Service.CustomAttribute;
using POD_Base_Service.Exception;

namespace Booking_Service.Model.ValueObject
{
    public class CustomerVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public string FirstName { get; }
        public string LastName { get; }
        public string NationalCode { get; }
        public string PassportNum { get; }
        public string PhoneNumber { get; }
        public string Email { get; }
        public string Country { get; }
        public string Address { get; }
        public VehicleType? Vehicle { get; }
        public string VehicleCode { get; }

        public CustomerVo(Builder builder)
        {
            FirstName = builder.GetFirstName();
            LastName = builder.GetLastName();
            PassportNum = builder.GetPassportNum();
            Email = builder.GetEmail();
            PhoneNumber = builder.GetPhoneNumber();
            Vehicle = builder.GetVehicle();
            NationalCode = builder.GetNationalCode();
            Address = builder.GetAddress();
            Country = builder.GetCountry();
            VehicleCode = builder.GetVehicleCode();
        }

        public class Builder
        {
            [Required]
            private string firstName;

            [Required]
            private string lastName;

            [RequiredIf(nameof(passportNum))]
            [RegularExpression(RegexFormat.NationalCode)]
            private string nationalCode;

            private string passportNum;

            [Required]
            [RegularExpression(RegexFormat.MobileNumber)]
            private string phoneNumber;


            [EmailAddress]
            private string email;

            [Required]
            private string country;
            private string address;
            private VehicleType? vehicle;
            private string vehicleCode;

            public string GetFirstName()
            {
                return firstName;
            }
            public Builder SetFirstName(string firstName)
            {
                this.firstName = firstName;
                return this;
            }
            public string GetLastName()
            {
                return lastName;
            }
            public Builder SetLastName(string lastName)
            {
                this.lastName = lastName;
                return this;
            }
            public string GetPassportNum()
            {
                return passportNum;
            }
            public Builder SetPassportNum(string passportNum)
            {
                this.passportNum = passportNum;
                return this;
            }
            public string GetEmail()
            {
                return email;
            }
            public Builder SetEmail(string email)
            {
                this.email = email;
                return this;
            }
            public string GetPhoneNumber()
            {
                return phoneNumber;
            }
            public Builder SetPhoneNumber(string phoneNumber)
            {
                this.phoneNumber = phoneNumber;
                return this;
            }
            public VehicleType? GetVehicle()
            {
                return vehicle;
            }
            public Builder SetVehicle(VehicleType vehicle)
            {
                this.vehicle = vehicle;
                return this;
            }
            public string GetNationalCode()
            {
                return nationalCode;
            }
          
            public Builder SetNationalCode(string nationalCode)
            {
                this.nationalCode = nationalCode;
                return this;
            }
            public string GetAddress()
            {
                return address;
            }
            public Builder SetAddress(string address)
            {
                this.address = address;
                return this;
            }

            public string GetCountry()
            {
                return country;
            }
            public Builder SetCountry(string country)
            {
                this.country = country;
                return this;
            }
            public string GetVehicleCode()
            {
                return vehicleCode;
            }

            public Builder SetVehicleCode(string vehicleCode)
            {
                this.vehicleCode = vehicleCode;
                return this;
            }
  
            public CustomerVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new CustomerVo(this);
            }
        }
    }
}
