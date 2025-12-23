using System.ComponentModel.DataAnnotations;

namespace OptiMark.DAL.Common;

public abstract class BaseEntity
{
    [Key]
    public int Id;

    public DateTime CreatedAt;

    public DateTime UpdatedAt;

    public DateTime CreatedBy;

    public DateTime UpdatedBy;
}