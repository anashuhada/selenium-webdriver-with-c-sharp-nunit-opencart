using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCart.Utilities
{
    public static class CSVDataReader
    {
        public static IEnumerable<TestCaseData> GetTestCaseData(string filePath)
        {
            using (var reader = new StreamReader(filePath))
            {
                bool headerSkipped = false;

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();

                    if (!headerSkipped)
                    {
                        headerSkipped = true;
                        continue;
                    }

                    var values = line.Split(',');
                    //yield return new TestCaseData(values[0], values[1]);

                    var userLogin = new UserData
                    {
                        Email = values[0],
                        Password = values[1]
                    };

                    yield return new TestCaseData(userLogin);

                }
            }
        }
    }
}
