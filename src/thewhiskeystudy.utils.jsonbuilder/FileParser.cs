using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;

using ExcelDataReader;

using Newtonsoft.Json;

using thewhiskeystudy.lib.Common;
using thewhiskeystudy.lib.Objects;

namespace thewhiskeystudy.utils.jsonbuilder
{
    public class FileParser
    {
        public void ParseFile(string fileName, bool outputToJsonFile = false)
        {
            var data = GetDataFromExcel(fileName);

            if (outputToJsonFile)
            {
                WriteJSON(data);
            }
            else
            {
                UploadJson(data);
            }
        }

        private void WriteJSON(List<RawDatabaseItem> data)
        {
            var jsonString = JsonConvert.SerializeObject(data);

            File.WriteAllText(Constants.FILE_JSON_DBFILENAME, jsonString);
        }

        private string ReadToken() => File.ReadAllText(Constants.FILE_TOKEN_FILENAME);

        private async void UploadJson(List<RawDatabaseItem> data)
        {
            var jsonString = JsonConvert.SerializeObject(data);

            using (var httpClient = new HttpClient())
            {
                var httpContent = new StringContent(jsonString, Encoding.UTF8, "application/json");

                httpClient.DefaultRequestHeaders.Add(Constants.HTTP_HEADER_TOKEN, ReadToken());

                await httpClient.PutAsync(Constants.URL_RESTSERVICE, httpContent);
            }            
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