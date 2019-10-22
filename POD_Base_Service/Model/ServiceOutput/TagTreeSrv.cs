using System;

namespace POD_Base_Service.Model.ServiceOutput
{
    public class TagTreeSrv
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public TagTreeCategorySrv Category { get; set; }
        public DateTime CreationDate { get; set; }
        public long Parent { get; set; }
        public bool Enable { get; set; }
    }
}
