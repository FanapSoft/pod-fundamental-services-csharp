﻿namespace POD_Base_Service.Result
{
    public class PrivateCallSrv
    {
        public bool HasError { get; set; }
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public long Count { get; set; }
        public string Ott { get; set; }
        public string Result { get; set; }
    }
}
