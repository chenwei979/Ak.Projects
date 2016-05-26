using System;

namespace Ak.Projects.Common.DataAccess
{
    public interface IEntity
    {
        int Id { get; set; }
        Guid Guid { get; set; }
        DateTime? CreateDate { get; set; }
        Guid? CreatorGUID { get; set; }
        string CreatorName { get; set; }
        DateTime? UpdateDate { get; set; }
        Guid? UpdaterGUID { get; set; }
        string UpdaterName { get; set; }
    }

    public interface IMultiLanguageEntity : IEntity
    {
        int? Language { get; set; }
    }
}
