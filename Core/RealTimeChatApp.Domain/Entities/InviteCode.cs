using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealTimeChatApp.Domain.Common;

namespace RealTimeChatApp.Domain.Entities
{
    public class InviteCode : EntityBase
    {
        public InviteCode()
        {
            
        }
        public InviteCode(string encryptedCode, int maxUsage)
        {
            EncryptedCode = encryptedCode;
            MaxUsage = maxUsage;
        }


        public string EncryptedCode { get; set; }
        public int MaxUsage { get; set; }

       
    }
}
