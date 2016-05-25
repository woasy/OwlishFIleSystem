using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public static class SystemExtentions
    {
        public static void OnNextIfNotNull<T>(this IObserver<T> _this, T value)
        {
            if (_this != null) _this.OnNext(value);
        }
        public static void OnErrorIfNotNull<T>(this IObserver<T> _this, Exception e)
        {
            if (_this != null) _this.OnError(e);
        }
        public static void OnCompletedIfNotNull<T>(this IObserver<T> _this)
        {
            if (_this != null) _this.OnCompleted();
        }
    }
}
