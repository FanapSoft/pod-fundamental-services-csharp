using POD_Base_Service.Base.Enum;

namespace POD_Base_Service.Base
{
    public static class Config
    {
        /// <summary>
        /// Production : تمام سرویس ها بر روی سرور اصلی اجرا می شوند
        /// SandBox : تمام سرویس ها بر روی سرور تست اجرا می شوند
        /// </summary>
        public static ServerType ServerType { get; set; }


        /// <summary>
        /// توکن های داخلی : 0
        /// توکن های دریافت شده از SSO  : 1
        /// </summary>
        public static int TokenIssuer { get; set; } = 1;
    }
}
