using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwlishFileSystem
{
    public interface IOwlishProperty
    {
        string GetName(CultureInfo culture);
    }

    public interface IOwlishPropertyValue
    {
        string ToString(CultureInfo culture);
    }

    public class OwlishProperty : IOwlishProperty
    {
        private Func<CultureInfo, string> _GetNameImpl;

        public OwlishProperty(IReadOnlyDictionary<CultureInfo, string> names, string defaultName)
        {
            _GetNameImpl = ci => names.ContainsKey(ci) ? names[ci] : defaultName;
        }

        public string GetName(CultureInfo culture)
        {
            return _GetNameImpl(culture);
        }
    }
}
