using ZXing;
using ZXing.QrCode;
using UnityEngine;

namespace FunkySheep.QrCode
{
    public class Manager
    {
        private static Color32[] Encode(string textForEncoding, int width, int height)
        {
            var writer = new BarcodeWriter
            {
                Format = BarcodeFormat.QR_CODE,
                Options = new QrCodeEncodingOptions
                {
                    Height = height,
                    Width = width
                }
            };
            return writer.Write(textForEncoding);
        }

        public static Texture2D Generate(string text, int size = 256)
        {
            var encoded = new Texture2D(size, size);
            var color32 = Encode(text, encoded.width, encoded.height);
            encoded.SetPixels32(color32);
            encoded.Apply();
            return encoded;
        }
    }
}
