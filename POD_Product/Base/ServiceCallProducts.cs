using POD_Base_Service.Base;
using POD_Base_Service.Base.Enum;

namespace POD_Product.Base
{
    internal static class ServiceCallProducts
    {
        internal static long AddProduct => Config.ServerType == ServerType.SandBox ? 39347 : 29851;
        internal static long AddProducts => Config.ServerType == ServerType.SandBox ? 39348 : 29852;
        internal static long UpdateProduct => Config.ServerType == ServerType.SandBox ? 39349 : 29853;
        internal static long UpdateProducts => Config.ServerType == ServerType.SandBox ? 39350 : 29854;
        internal static long ProductList => Config.ServerType == ServerType.SandBox ? 39351 : 29855;
        internal static long BusinessProductList => Config.ServerType == ServerType.SandBox ? 39352 : 29856;
        internal static long AttributeTemplateList => Config.ServerType == ServerType.SandBox ? 39353 : 29857;
        internal static long SearchProduct => Config.ServerType == ServerType.SandBox ? 39354 : 29858;
        internal static long SearchSubProduct => Config.ServerType == ServerType.SandBox ? 39355 : 29859;
    }
}
