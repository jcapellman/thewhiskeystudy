using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

using ExcelDataReader;

using Newtonsoft.Json;

using thewhiskeystudy.lib.Objects;

namespace thewhiskeystudy.utils.jsonbuilder
{
    public class FileParser
    {
        public void ParseFile(string fileName, string outputFileName)
        {
            var data = GetDataFromExcel(fileName);

            WriteToJson(data, outputFileName);
        }

        private void WriteToJson(List<RawDatabaseItem> data, string outputFileName)
        {
            var jsonString = JsonConvert.SerializeObject(data);

            File.WriteAllText(outputFileName, jsonString);
        }

        private List<RawDatabaseItem> GetDataFromExcel(string fileName)
        {
            using (var stream = File.Open(fileName, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {                 
                    var rows = reader.AsDataSet().Tables[0].Rows.Cast<DataRow>().Skip(1);

                    var data = new List<RawDatabaseItem>();

                    foreach (var row in rows)
                    {
                        var databaseItem = new RawDatabaseItem(row);

                        // TODO: Once all legacy reviews have been performed removed
                        if (databaseItem.Rating == -1.0)
                        {
                            continue;
                        }

                        data.Add(databaseItem);
                    }

                    return data;
                }
            }
        }
    }
}