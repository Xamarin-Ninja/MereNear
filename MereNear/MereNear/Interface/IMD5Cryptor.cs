using System;
using System.Collections.Generic;
using System.Text;

namespace MereNear.Interface
{
    public interface IMD5Cryptor
    {
        string Encrypt(string inputString);
        string Decrypt(string inputString);
    }
}
