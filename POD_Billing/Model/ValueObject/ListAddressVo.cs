using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;

namespace POD_Billing.Model.ValueObject
{
    public class ListAddressVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public int? Size { get; }
        public int? Offset { get; }

        public ListAddressVo(Builder builder)
        {
            Size = builder.GetSize();
            Offset = builder.GetOffset();
        }

        public class Builder
        {
            [Required]
            private int? offset;
            private int? size;

            public int? GetOffset()
            {
                return offset;
            }

            /// <param name="offset">در صورت تمایل به دریافت کل لیست، این مقدار را صفر وارد نمایید</param>
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

            public ListAddressVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new ListAddressVo(this);
            }
        }
    }
}
