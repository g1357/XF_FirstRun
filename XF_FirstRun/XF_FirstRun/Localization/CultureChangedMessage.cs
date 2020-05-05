using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace XF_FirstRun.Localization
{
    public class CultureChangedMessage
    {
        public CultureInfo NewCultureInfo { get; private set;}

        public CultureChangedMessage(string lngname)
            :this(new CultureInfo(lngname))
        { }

        public CultureChangedMessage(CultureInfo newCultureInfo)
        {
            NewCultureInfo = newCultureInfo;
        }
    }
}
