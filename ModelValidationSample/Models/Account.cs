using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ModelValidationSample.Models
{
    public class Account
    {
        //Required ve MinimumLength öznitelikleri bir özelliğin bir değere sahip olması gerektiğini belirtir
        //RegularExpression hangi karakterlerin girişi yapabileceğini sınırlamak için kullanılır.
        //StringLength  en büyük uzunluğunu ve isteğe bağlı olarak en düşük uzunluğunu ayarlamanıza olanak sağlar.
        //Örnekte yer almasada bahselim
        //Range özniteliği, bir değeri belirtilen bir aralık içinde kısıtlar.
        //Değer türleri(örneğin, decimal int ), doğal olarak float DateTime gereklidir ve özniteliğe gerek kalmaz.
        //[Range(1, 100)]
        //DataType(DataType.Currency)]
        //[Column(TypeName = "decimal(18, 2)")]
        //public decimal PriceTL { get; set; }
        //ApplyFormatInEditMode = true ApplyFormatInEditMode değer düzenlenmek üzere görüntülendiğinde biçimlendirmenin uygulanacağını belirtir.

        [Display(Name = "İsim")]
        [StringLength(60, MinimumLength = 3,ErrorMessage = "{0} {1} ila {2} karakter arasında olmalıdır.")]
        [Required(ErrorMessage = "Lütfen adınızı giriniz.")]
        public string Name { get; set; }
        [Display(Name = "Soyisim")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} {1} ila {2} karakter arasında olmalıdır.")]
        [Required(ErrorMessage = "Lütfen soyadınızı giriniz.")]
        public string LastName { get; set; }
        [Display(Name = "Telefon Numarası")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(15, MinimumLength = 10, ErrorMessage = "{0} {1} ila {2} karakter arasında olmalıdır.")]
        [Required(ErrorMessage = "Lütfen telefon numaranızı giriniz.")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
                   ErrorMessage = "Telefon Formatı Geçersiz")]

        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email boş bırakılamaz")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                           @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                           @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
                           ErrorMessage = "Email adresi geçersiz")]
        [Display(Name = "E-Posta")]
        public string Email { get; set; }
        [Display(Name = "Açıklama")]
        [StringLength(250, MinimumLength = 20, ErrorMessage = "{0} {1} ila {2} karakter arasında olmalıdır.")]
        [Required(ErrorMessage = "Mesajın konusu boş geçilemez.")]
        public string Description { get; set; }

        //Bu şekilde ile servisleriniz üzerinden veya metodlarınız üzerinizde özel veri tipleriniz doğrulama yaptırılabilir
        //[Remote(action: "VerifyEmail", controller: "Validation")]
        //public string Email2 { get; set; }
        //[Remote(action: "VerifyName", controller: "Users", AdditionalFields = nameof(LastName2))]
        //[Display(Name = "İsim")]
        //public string FirstName2 { get; set; }

        //[Remote(action: "VerifyName", controller: "Users", AdditionalFields = nameof(FirstName2))]
        //[Display(Name = "Soyisim")]
        //public string LastName2 { get; set; }
    }
}
