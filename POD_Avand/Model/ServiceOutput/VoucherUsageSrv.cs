
namespace POD_Avand.Model.ServiceOutput
{
    public class VoucherUsageSrv
    {
        public string Hash { get; set; }
        public long ConsumDate { get; set; }
        public decimal UsedAmount { get; set; }
        public bool Canceled { get; set; }
    }
}
