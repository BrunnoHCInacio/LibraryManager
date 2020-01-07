using Library.API.Parameters;
using Library.API.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Library.API.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessageResourceType = typeof(ValidationDomain),
                      ErrorMessageResourceName = "MessageErrorNotEmptyEmail")]
        [EmailAddress(ErrorMessageResourceType = typeof(ValidationDomain),
                      ErrorMessageResourceName = "MessageErrorFormatEmail")]
        public string Email { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationDomain),
                      ErrorMessageResourceName = "MessageErrorNotEmptyPassword")]
        [StringLength(DomainParameters.LengthSize100,
                      ErrorMessageResourceType = typeof(ValidationDomain),
                      ErrorMessageResourceName = "MessageErrorLengthPassword",
                      MinimumLength = DomainParameters.LengthSize8)]
        public string Password { get; set; }
        [Compare("Password",
                 ErrorMessageResourceType = typeof(ValidationDomain),
                 ErrorMessageResourceName = "MessageErrorPasswordCompare")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginViewModel
    {
        [Required(ErrorMessageResourceType = typeof(ValidationDomain),
                      ErrorMessageResourceName = "MessageErrorNotEmptyEmail")]
        [EmailAddress(ErrorMessageResourceType = typeof(ValidationDomain),
                      ErrorMessageResourceName = "MessageErrorFormatEmail")]
        public string Email { get; set; }

        [Required(ErrorMessageResourceType = typeof(ValidationDomain),
                      ErrorMessageResourceName = "MessageErrorNotEmptyPassword")]
        [StringLength(DomainParameters.LengthSize100,
                      ErrorMessageResourceType = typeof(ValidationDomain),
                      ErrorMessageResourceName = "MessageErrorLengthPassword",
                      MinimumLength = DomainParameters.LengthSize8)]
        public string Password { get; set; }
    }

    public class LoginTokenViewModel
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string AccessToken { get; set; }
    }
}
