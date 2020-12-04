namespace POD_VirtualAccount.Base.Enum
{
    public enum CauseCode
    {
        /// <summary>
        /// خرید از طریق درگاه بانکی و پرداخت با کارت و و برگشت فاکتور
        /// </summary>
        CASHOUT_CAUSE_TYPE_INVOICE,

        /// <summary>
        /// ثبت درخواست برای تسویه از کیف پول مجازی
        /// </summary>
        CASHOUT_CAUSE_TYPE_SETTLEMENT
    }
}
