using System;

namespace Ak.Projects.Entities
{
    public class User
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public DateTime? CreateDate { get; set; }
        public Guid? CreatorGUID { get; set; }
        public string CreatorName { get; set; }
        public DateTime? UpdateDate { get; set; }
        public Guid? UpdaterGUID { get; set; }
        public string UpdaterName { get; set; }

        public string UserName { get; set; }
        public string Password { get; set; }
        public string DisplayName { get; set; }
    }
}
