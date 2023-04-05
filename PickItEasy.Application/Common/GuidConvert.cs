using System.Numerics;

namespace PickItEasy.Application.Common
{
    public static class GuidConvert
    {
        private const string alphabet = "0123456789abcdef";

        public static string ToNumStr(string guidStr)
        {
            if (!Guid.TryParse(guidStr, out Guid guid))
                throw new ApplicationException($"Guid. Failure to parse ({guidStr}) ");

            string value = guid.ToString("n");

            BigInteger bigInt = 0;

            for (int i = 0; i < value.Length; i++)
            {
                bigInt = bigInt * 16 + alphabet.IndexOf(value.Substring(i, 1));
            }

            string result = bigInt.ToString();

            result = result.Length % 2 != 0 ? $"0{result}" : result;
            
            return result;
        }

        public static string FromNumStr(string numStr)
        {
            if(! BigInteger.TryParse(numStr, out BigInteger bigInt))
                throw new ApplicationException($"BigInteger. Failure to parse ({numStr}) ");
            string result = "";

            while (bigInt > 0)
            {
                int remainder = (int)(bigInt % 16);
                result = alphabet.Substring(remainder, 1) + result;
                bigInt = (bigInt - remainder) / 16;
            }

            while (result.Length < 32)
                result = $"0{result}";

            if(!Guid.TryParse(result, out Guid guid))
                throw new ApplicationException($"Guid. Failure to parse ({result}) ");

            return guid.ToString();
        }
    }
}
