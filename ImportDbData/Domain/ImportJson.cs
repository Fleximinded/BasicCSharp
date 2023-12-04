using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ImportDbData.Domain
{
    public class JsonToSql
    {

        public const int StdVarcharSize  = 250;
        public int VarcharSize { get; internal set; } = StdVarcharSize;
        public string JSonContent { get; internal set; } = string.Empty;    
        public string TableName { get; internal set; } = string.Empty;
        public string SqlScript { get; internal set; } = string.Empty;

        public JsonToSql()        {                        }
        public static JsonToSql? FromFile(string table,string jsonPath, int varcharSize=-1)
        {
            if(File.Exists(jsonPath))
            {
                var content = File.ReadAllText(jsonPath);
                if(content?.Length > 0) {
                    return new JsonToSql(table, content, varcharSize);
                }
            }
            return null;
        }
        public JsonToSql(string table, string jsonContent, int varcharSize=-1)
        {
            TableName = table;
            varcharSize = varcharSize>0?varcharSize:StdVarcharSize;
            JSonContent = jsonContent;  
        }
        public static bool TryImportTo(string tableName, string path, out string script)
        {
            JsonToSql? importer = JsonToSql.FromFile(tableName, path);
            script = string.Empty;
            if(importer?.Import()==true)
            {
                script = importer.SqlScript;
                return true;

            }
            return false;

        }

        public bool Import() { 
            if(JSonContent.Length>0)
            {
                List<Dictionary<string, object>> data = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(JSonContent) ?? new List<Dictionary<string, object>>();
                StringBuilder sw = new StringBuilder();
                if(data.Count > 0)
                {
                    if(GenerateCreateTableScript(data[0], sw)&& GenerateInsertStatements(data, sw)){
                        SqlScript = sw.ToString();
                        return true;
                    }
                }

            }
            return false;
        }

        bool GenerateCreateTableScript(Dictionary<string, object> sampleData,StringBuilder sw)
        {
            if(sampleData.Count > 0)
            {
                List<string> columns = new List<string>();
                columns.Add("Id INT IDENTITY(1,1) PRIMARY KEY");
                foreach(var property in sampleData)
                {
                    string columnType = GetSqlType(property.Value.GetType());
                    columns.Add($"{property.Key} {columnType}");
                }

                sw.Append($"CREATE TABLE {TableName} ({string.Join(", ", columns)});");
                sw.AppendLine();
                return true;
            }
            return false;
        }

        bool GenerateInsertStatements(List<Dictionary<string, object>> data, StringBuilder sw)
        {
            if(data.Count > 0)
            {
                foreach(var record in data)
                {
                    List<string> values = new List<string>();

                    List<string> names = new List<string>();
                    foreach(var property in record)
                    {
                        string formattedValue = FormatSqlValue(property.Value);
                        names.Add(property.Key);
                        values.Add(formattedValue);
                    }
                    string insertStatement = $"INSERT INTO {TableName}({string.Join(", ", names)}) VALUES ({string.Join(", ", values)});";
                    sw.AppendLine(insertStatement);
                }

                sw.AppendLine();
                return true;
            }
            return false;
        }

        string GetSqlType(Type type)
        {
            if(type == typeof(string))
                return $"VARCHAR({VarcharSize})";
            else if(type == typeof(int) || type == typeof(double) || type == typeof(float) || type == typeof(long) || type == typeof(short))
                return "INT";
            else
                throw new ArgumentException($"Unsupported data type: {type}");
        }

        static string FormatSqlValue(object value)
        {
            string? text=value as string;
            return text?.Length>0 ? $"'{text.Replace("'", "-")}'" : value.ToString() ?? "NULL";
        }

       
    }



}
