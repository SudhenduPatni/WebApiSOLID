using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utils
{
    public class Util
    {
        public static readonly string LOCAL_PATH = @"C:\Users\sudhe\source\repos\PmcTest\Store";
        public static readonly string CLIENT_STORAGE = @"local-storage.json";
        public static readonly string CLIENT_DETAILS_PATH = string.Format(@"{0}\{1}", Util.LOCAL_PATH, Util.CLIENT_STORAGE);
        public static readonly string FILE_STORAGE = @"local-files.json";
        public static readonly string FILE_DETAILS_PATH = string.Format(@"{0}\{1}", Util.LOCAL_PATH, Util.FILE_STORAGE);
        public static readonly string SUBSCRIPTION_STORAGE = @"local-subscriptions.json";
        public static readonly string SUBSCRIPTION_DETAILS_PATH = string.Format(@"{0}\{1}", Util.LOCAL_PATH, Util.SUBSCRIPTION_STORAGE);

        public enum CloudProvider
        {
            Azure = 1,
            DropBox = 2
        }
    }
}
