using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;
using POD_Base_Service.Model.ValueObject;

namespace POD_UserOperation.Model.ValueObject
{
    public class ConfirmEditProfileVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public long? Code { get; }
        public string CellphoneNumber { get; }
        public InternalServiceCallVo ServiceCallParameters { get; }

        public ConfirmEditProfileVo(Builder builder)
        {
            Code = builder.GetCode();
            CellphoneNumber = builder.GetCellphoneNumber();
            ServiceCallParameters = builder.GetServiceCallParameters();
        }

        public class Builder
        {
            [Required]
            private string cellphoneNumber;

            [Required]
            private long? code;

            [Required]
            private InternalServiceCallVo serviceCallParameters;

            public string GetCellphoneNumber()
            {
                return cellphoneNumber;
            }

            /// <param name="cellphoneNumber">در صورت تمایل به دریافت کل لیست، این مقدار را صفر وارد نمایید</param>
            public Builder SetCellphoneNumber(string cellphoneNumber)
            {
                this.cellphoneNumber = cellphoneNumber;
                return this;
            }

            public long? GetCode()
            {
                return code;
            }

            public Builder SetCode(long code)
            {
                this.code = code;
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

            public ConfirmEditProfileVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new ConfirmEditProfileVo(this);
            }
        }
    }
}
