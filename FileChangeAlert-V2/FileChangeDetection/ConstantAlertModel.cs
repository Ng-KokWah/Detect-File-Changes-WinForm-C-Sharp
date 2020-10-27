using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileChangeDetection
{
    class ConstantAlertModel
    {
        public string Filepath { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string MD5Hash { get; set; }
        public string SHA256Hash { get; set; }
        public string SHA512Hash { get; set; }
    }
}
