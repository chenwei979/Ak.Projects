using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ak.Entities
{
    /// <summary>
    /// Entity 基础字段
    /// </summary>
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
    /// <summary>
    /// 语言字段 
    /// </summary>
    public interface IMultiLanguageEntity : IEntity
    {
        int? Language { get; set; }
    }

    public partial class User : IEntity
    {
    }

    public partial class Role : IEntity
    {
    }

    public partial class Department : IEntity
    {
    }

    public partial class News : IEntity
    {
    }

    public partial class Product : IEntity
    {
    }
}
