using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickItEasy.Application.Common
{
    public class Barcode
    {
        public static string GetBase64(string idString)
        {
            var numericString = BarcodeGuidConvert.ToNumericString(idString);
            var barcode = new NetBarcode.Barcode(numericString, NetBarcode.Type.Code128, true);
            var result = barcode.GetBase64Image();
            return result;
        }

        public static string GetBase64(Guid idGuid)
        {
            var numericString = BarcodeGuidConvert.ToNumericString(idGuid);
            var barcode = new NetBarcode.Barcode(numericString, NetBarcode.Type.Code128, true);
            var result = barcode.GetBase64Image();
            return result;
        }
    }
}
