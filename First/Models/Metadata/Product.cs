using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.Web.Mvc;

namespace First.Models
{
    [MetadataType(typeof(ProductMD))]
    public partial class Product
    {
        public class ProductMD
        {
            [ScaffoldColumn(false)]
            public int ProductID { get; set; }

            [Display(Name ="產品名稱")]
            //[StringLength(50,ErrorMessage ="{0}的長度需介於{2}到{1}",MinimumLength = 4)]
            //[Required(ErrorMessage = "這列不能為空你是不知道歐?")]
            [CustomValidation(typeof(StringValidator), "Invalid")]
            public string ProductName { get; set; }

            [Required]
            public string QuantityPerUnit { get; set; }
            [Required]
            public bool Discontinued { get; set; }
            [Display(Name = "產品")]
            [Range(0,32767,ErrorMessage ="{0}必須介於{2}到{1}之間")]
            public Nullable<short> UnitsInStock { get; set; }

            [Remote("Price","Validations")]
            public Nullable<decimal> UnitPrice { get; set; }



        }

    }

    public class StringValidator
    {
        public static ValidationResult Invalid(string productName ,ValidationContext validationContext)
        {
            Regex regex = new Regex(@"[^\w\.-]", RegexOptions.IgnoreCase);
            return (productName != null && regex.Match(productName).Length > 0)
                ? new ValidationResult("只許含只許英數字元，句號(.)，連字號(-)。")
                : ValidationResult.Success;
        }
    }


    /// <summary>
    /// 擴充驗證
    /// </summary>
    public class EmailAttribute : RegularExpressionAttribute
    {
        public EmailAttribute(): base(@"^[a-zA-Z0-9.!#$%&'*+/=?^_ˋ{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$") { }
    }
}