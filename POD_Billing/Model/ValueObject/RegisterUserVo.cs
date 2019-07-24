using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;

namespace POD_Billing.Model.ValueObject
{
    public class RegisterUserVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public string UserName { get; }
        public string CellphoneNumber { get; }
        public string Email { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string NationalCode { get; }
        public string Sheba { get; }

        public RegisterUserVo(Builder builder)
        {
            UserName = builder.GetUserName();
            CellphoneNumber = builder.GetCellphoneNumber();
            Email = builder.GetEmail();
            FirstName = builder.GetFirstName();
            LastName = builder.GetLastName();
            NationalCode = builder.GetNationalCode();
            Sheba = builder.GetSheba();
        }

        public class Builder
        {
            [Required]
            private string userName;

            [RegularExpression(RegexFormat.MobileNumber)]
            private string cellphoneNumber;

            [EmailAddress]
            private string email;
            private string firstName;
            private string lastName;

            [RegularExpression(RegexFormat.NationalCode)]
            private string nationalCode;

            [RegularExpression(RegexFormat.Sheba)]
            private string sheba;

            public string GetUserName()
            {
                return userName;
            }

            public Builder SetUserName(string userName)
            {
                this.userName = userName;
                return this;
            }

            public string GetCellphoneNumber()
            {
                return cellphoneNumber;
            }

            public Builder SetCellphoneNumber(string cellphoneNumber)
            {
                this.cellphoneNumber = cellphoneNumber;
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
            public string GetNationalCode()
            {
                return nationalCode;
            }

            public Builder SetNationalCode(string nationalCode)
            {
                this.nationalCode = nationalCode;
                return this;
            }
            public string GetSheba()
            {
                return sheba;
            }

            public Builder SetSheba(string sheba)
            {
                this.sheba = sheba;
                return this;
            }

            public RegisterUserVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new RegisterUserVo(this);
            }
        }
    }
}
