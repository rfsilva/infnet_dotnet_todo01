using System.ComponentModel.DataAnnotations;

namespace ToDo.Web.Mvc.Models
{

    public class UpdateItemModel
    {
        public Guid Id { get; set; }
        [StringLength(256, MinimumLength = 5)]
        public string Description { get; set; }

    }
}
