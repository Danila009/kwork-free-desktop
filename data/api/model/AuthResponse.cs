using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeWPF.data.api.model
{
    internal class AuthResponse
    {
        public string Access_token { get; set; } = String.Empty;
        public string Username { get; set; } = String.Empty;
    }
}
