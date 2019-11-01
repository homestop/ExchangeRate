﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Net;

namespace Exchange.Private.Scripts
{
    class DownloadScript
    {
        public static void Download(string url, string name)
        {
            using (var client = new WebClient())
            {
                client.DownloadFile(url, name);
            }
        }
    }
}
