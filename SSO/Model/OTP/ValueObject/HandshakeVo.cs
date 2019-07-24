using System.ComponentModel.DataAnnotations;
using System.Linq;
using POD_Base_Service.Base;
using POD_Base_Service.Exception;
using POD_SSO.Base.Enum;

namespace POD_SSO.Model.OTP.ValueObject
{
    public class HandshakeVo
    {
        public static Builder ConcreteBuilder => new Builder();
        public string DeviceUid { get; }
        public double? DeviceLat { get; }
        public double? DeviceLon { get; }
        public string DeviceOs { get; }
        public string DeviceOsVersion { get; }
        public string DeviceType { get; }
        public string DeviceName { get; }
        public string Authorization { get; }

        public HandshakeVo(Builder builder)
        {
            DeviceUid = builder.GetDeviceUid();
            DeviceLat = builder.GetDeviceLat();
            DeviceLon = builder.GetDeviceLon();
            DeviceOs = builder.GetDeviceOs();
            DeviceOsVersion = builder.GetDeviceOsVersion();
            DeviceType = builder.GetDeviceType();
            DeviceName = builder.GetDeviceName();
            Authorization = builder.GetAuthorization();
        }

        public class Builder
        {
            [Required]
            private string authorization;

            [Required]
            [StringLength(255)]
            private string deviceUid;
            private double? deviceLat;
            private double? deviceLon;
            private string deviceOs;
            private string deviceOsVersion;
            private string deviceType;
            private string deviceName;

            public string GetAuthorization()
            {
                return authorization;
            }
            public Builder SetAuthorization(string apiToken)
            {
                this.authorization = $"Bearer {apiToken}";
                return this;
            }
            public string GetDeviceUid()
            {
                return deviceUid;
            }

            public Builder SetDeviceUid(string deviceUid)
            {
                this.deviceUid = deviceUid;
                return this;
            }
            public double? GetDeviceLat()
            {
                return deviceLat;
            }

            public Builder SetDeviceLat(double deviceLat)
            {
                this.deviceLat = deviceLat;
                return this;
            }
            public double? GetDeviceLon()
            {
                return deviceLon;
            }

            public Builder SetDeviceLon(double deviceLon)
            {
                this.deviceLon = deviceLon;
                return this;
            }
            public string GetDeviceOs()
            {
                return deviceOs;
            }
            public Builder SetDeviceOs(string deviceOs)
            {
                this.deviceOs = deviceOs;
                return this;
            }
            public string GetDeviceOsVersion()
            {
                return deviceOsVersion;
            }

            public Builder SetDeviceOsVersion(string deviceOsVersion)
            {
                this.deviceOsVersion = deviceOsVersion;
                return this;
            }
            public string GetDeviceType()
            {
                return deviceType;
            }

            public Builder SetDeviceType(DeviceType deviceType)
            {
                if (deviceType == Base.Enum.DeviceType.MobilePhone)
                    this.deviceType = "Mobile Phone";
                else if (deviceType == Base.Enum.DeviceType.TvDevice)
                    this.deviceType = "TV Device";
                else this.deviceType = deviceType.ToString();
                return this;
            }

            public string GetDeviceName()
            {
                return deviceName;
            }
            public Builder SetDeviceName(string deviceName)
            {
                this.deviceName = deviceName;
                return this;
            }

            public HandshakeVo Build()
            {
                var hasErrorFields = this.ValidateByAttribute();

                if (hasErrorFields.Any())
                {
                    throw PodException.BuildException(new InvalidParameter(hasErrorFields));
                }

                return new HandshakeVo(this);
            }
        }
    }
}
