using System.ComponentModel.DataAnnotations;

namespace AccesaQuests.Web.Models.ViewsName
{
    public class AddTagRequest
    {
      [Required]
      public string Name { get; set; }

      [Required]
      public string DisplayName { get;set; }

    }
}
