using System.Collections.Generic;

namespace VigenerEncryptor.Tests.Utils
{
    internal static class TestListGenerator
    {
        internal static List<string> GetList(int listLength)
        {
            List<string> resultList = new List<string>();
            for (int i = 0; i < listLength; i++)
            {
                resultList.Add("0");
            }

            return resultList;
        }
    }
}
