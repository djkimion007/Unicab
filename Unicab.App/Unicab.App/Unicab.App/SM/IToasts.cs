using System;
using System.Collections.Generic;
using System.Text;

namespace Unicab.App.SM
{
    public interface IToasts
    {
        void LongToast(string message);
        void ShortToast(string message);
    }
}
