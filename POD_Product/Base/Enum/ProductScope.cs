
namespace POD_Product.Base.Enum
{
    public enum ProductScope
    {
        /// <summary> لیست کلیه مححصولات کسب و کار بدون فیلتر </summary>
        BUSINESS_PRODUCT,

        /// <summary>لیست محصولاتی از کسب و کار خودتان، که روی آن محصولات به کسب و کار واسطی اجازه صدور فاکتور داده اید.</summary>
        DEALER_PRODUCT_PERMISSION,

        /// <summary>شده است parent لیست محصولاتی از کسب  و کار خودتان که در کسب و کار دیگری،</summary>
        PARENT_PRODUCT
    }
}
