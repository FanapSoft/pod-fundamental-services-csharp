using System;
using System.Collections.Generic;
using System.Text;

namespace POD_Banking.Model.ServiceOutput
{
    public class GetDepositBalanceSrv
    {
        public string DepositNumber { get; set; }
        public List<AmountSrv> Amounts { get; set; }
        public List<AmountSrv> WithdrawableAmounts { get; set; }
    }
}
