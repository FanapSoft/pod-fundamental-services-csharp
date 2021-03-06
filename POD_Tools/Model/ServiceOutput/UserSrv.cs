﻿using POD_Base_Service.Model.ServiceOutput;

namespace POD_Tools.Model.ServiceOutput
{
    public class UserSrv
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public ImageInfoSrv Image { get; set; }
        public string SsoId { get; set; }
        public int SsoIssuerCode { get; set; }
        public string ProfileImage { get; set; }
    }
}
