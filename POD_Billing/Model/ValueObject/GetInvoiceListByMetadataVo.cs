using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;
using POD_Base_Service.Model.ValueObject;


namespace POD_Billing.Model.ValueObject
{
    public class GetInvoiceListByMetadataVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public int? Size { get; }
        public int? OffSet { get; }
        public string MetaQuery { get; }
        public bool? IsCanceled { get; }
        public bool? IsPayed { get; }
        public InternalServiceCallVo ServiceCallParameters { get; }

        public GetInvoiceListByMetadataVo(Builder builder)
        {
            MetaQuery = builder.GetMetaQuery();
            Size = builder.GetSize();
            OffSet = builder.GetOffSet();
            IsCanceled = builder.GetIsCanceled();
            IsPayed = builder.GetIsPayed();
            ServiceCallParameters = builder.GetServiceCallParameters();
        }

        public class Builder
        {    
            [Required]
            private string metaQuery;
            private int? size;
            private int? offSet;
            private bool? isCanceled;
            private bool? isPayed;

            [Required]
            private InternalServiceCallVo serviceCallParameters;

            public string GetMetaQuery()
            {
                return metaQuery;
            }

            public Builder SetMetaQuery(string metaQuery)
            {
                this.metaQuery = metaQuery;
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

            public int? GetOffSet()
            {
                return offSet;
            }

            public Builder SetOffSet(int offSet)
            {
                this.offSet = offSet;
                return this;
            }

            public bool? GetIsCanceled()
            {
                return isCanceled;
            }

            public Builder SetIsCanceled(bool isCanceled)
            {
                this.isCanceled = isCanceled;
                return this;
            }

            public bool? GetIsPayed()
            {
                return isPayed;
            }

            public Builder SetIsPayed(bool isPayed)
            {
                this.isPayed = isPayed;
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

            public GetInvoiceListByMetadataVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new GetInvoiceListByMetadataVo(this);
            }
        }
    }
}
