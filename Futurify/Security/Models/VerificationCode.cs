using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Security.Models
{
    public class VerificationCode
    {
        [Key]
        public int Id { get; set; }  
        [ForeignKey("AccountId")]
        public virtual Account Account { get; set; }
        [ForeignKey("Account")]
        public int AccountId { get; set; }

        public string VerifyCode { get; set; }
        public DateTime ExpiredAt { get; set; }
        public bool? Checked { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public VerificationPurpose Purpose { get; set; }

        public string SetEmail { get; set; }
        public string SetPhoneNumber { get; set; }

        public int? Retry { get; set; }
        public int? Resend { get; set; }
    }

    public enum VerificationPurpose
    {
        Email,
        RegistrationPhoneNumber,
        Password
    }
}
