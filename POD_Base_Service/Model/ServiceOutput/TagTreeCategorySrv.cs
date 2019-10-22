
namespace POD_Base_Service.Model.ServiceOutput
{
    public class TagTreeCategorySrv
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public BusinessSoftSrv BusinessSoftSrv { get; set; }
        public string CreationDate { get; set; }
        public bool Enable { get; set; }
    }
}
