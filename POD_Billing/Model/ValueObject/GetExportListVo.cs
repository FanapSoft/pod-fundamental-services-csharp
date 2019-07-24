using System.Collections.Generic;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Billing.Model.ServiceOutput;
using POD_Billing.Base.Enum;

namespace POD_Billing.Model.ValueObject
{
    public class GetExportListVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public long? Id { get; }
        public int? Offset { get; }
        public int? Size { get; }
        public FileStatusCode? StatusCode { get; }
        public string ServiceUrl { get; }

        public GetExportListVo(Builder builder)
        {
            Id = builder.GetId();
            Offset = builder.GetOffset();
            Size = builder.GetSize();
            StatusCode = builder.GetStatusCode();
            ServiceUrl = builder.GetServiceUrl();
        }

        public class Builder
        {
            private long? id;
            [Required]
            private int? offset;

            [Required]
            private int? size;
            private FileStatusCode? statusCode;
            private string serviceUrl;


            public long? GetId()
            {
                return id;
            }

            public Builder SetId(long id)
            {
                this.id = id;
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

            public FileStatusCode? GetStatusCode()
            {
                return statusCode;
            }

            public Builder SetStatusCode(FileStatusCode statusCode)
            {
                this.statusCode = statusCode;
                return this;
            }

            public string GetServiceUrl()
            {
                return serviceUrl;
            }

            public Builder SetServiceUrl(string serviceUrl)
            {
                this.serviceUrl = serviceUrl;
                return this;
            }


            public GetExportListVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new GetExportListVo(this);
            }
        }
        public LinkSrv GetLink(long fileId,string hashCode)
        {
            var message = "The field is required.";
            var hasErrorFields=new List<KeyValuePair<string,string>>();
            if (string.IsNullOrEmpty(hashCode)) hasErrorFields.Add(new KeyValuePair<string, string>("HashCode",message));
            if (fileId <= 0) hasErrorFields.Add(new KeyValuePair<string, string>("FileId", message));
            if(hasErrorFields.Any()) throw PodException.BuildException(new InvalidParameter(hasErrorFields));
            return new LinkSrv() { HashCode = hashCode, RedirectUrl = $"{BaseUrl.FileServerAddress}/nzh/file/?fileId={fileId}&hashCode={hashCode}" };
        }
    }
}
