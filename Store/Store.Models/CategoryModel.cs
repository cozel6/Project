using System.ComponentModel.DataAnnotations;

namespace Store.Models
{
    public class CategoryModel
    {
        public int Categoryid { get; set; }

        [Required]
        [MinLength(4)]
        [StringLength(10)]
        public string CategoryName { get; set; } = null!;

        [Required]
        [MinLength(10)]
        public string Description { get; set; } = null!;

        public string CategoryCode
        {
            get
            {
                if (!string.IsNullOrEmpty(CategoryName))
                {
                    return CategoryName.Substring(0, 2).ToUpper();
                }

                return string.Empty;
            }
        }
    }
}
