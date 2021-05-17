using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;

namespace PersonalTrainerApp
{
    public class IO
    {
        public static DataTable ReadCsvFile(string filename)
        {
            DataTable csv_dt = new DataTable();
            try
            {
                using (TextFieldParser csvReader = new TextFieldParser(filename))
                {

                    csvReader.SetDelimiters(new string[] { "," });
                    csvReader.HasFieldsEnclosedInQuotes = true;
                    string[] cols = csvReader.ReadFields();
                    foreach (string column in cols)
                    {
                        DataColumn datacolumn = new DataColumn(column);
                        datacolumn.AllowDBNull = true;
                        csv_dt.Columns.Add(datacolumn);
                    }
                    while (!csvReader.EndOfData)
                    {
                        string[] cells = csvReader.ReadFields();
                        string[] coiumn_titels = { "" };
                        //Making empty value as null
                        for (int i = 0; i < cells.Length; i++)
                        {
                            if (cells[i] == "")
                            {
                                cells[i] = null;
                            }

                        }
                        csv_dt.Rows.Add(cells);
                    }
                    //for (var i = 0; i < csv_dt.Columns.Count; i++)
                    //{
                    //    csv_dt.Columns[i].ColumnName = csv_dt.Rows[0].ToString();
                    //}
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("File not found", e.Source);
                throw;
            }
            catch (IOException e)
            {
                if (e.Source != null)
                    Console.WriteLine("IOException source: {0}", e.Source);
                throw;
            }
            return csv_dt;
        }
 
    }
}

