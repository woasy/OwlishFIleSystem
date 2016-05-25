using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwlishFileSystem.SystemIO
{
    static class Extentions
    {
        static public void INN<Ti>(this Ti _this, Action<Ti> action)
        {
            if (_this != null)
            {
                action(_this);
            }
        }
    }
}
