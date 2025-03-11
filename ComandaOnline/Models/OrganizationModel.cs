namespace ComandaOnline.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class OrganizationModel
{


    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Key { get; set; } = string.Empty;
    public int Type { get; set; }
    public int Owner { get; set; }

    public ICollection<UserModel>? Users { get; set; }
}
