using System;
using ZXing;
using ZXing.Common;

namespace App1
{
    internal class BarcodeWriter
    {
        public BarcodeFormat Format { get; set; }
        public EncodingOptions Options { get; set; }

        internal object Write(string identification)
        {
            throw new NotImplementedException();
        }
    }
}