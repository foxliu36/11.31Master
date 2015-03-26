using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.IO;
using System.Text;


namespace Eshooping.Tools
{
    public class CTools
    {
        public static DataTable getFilledColumnsDataTable(string[] p_strColumns)
        {

            DataTable l_table = new DataTable();//  產生欄位標題
            for (int i = 0; i < p_strColumns.Length; i++)
            {
                l_table.Columns.Add(new DataColumn(p_strColumns[i], typeof(string)));
            }
            return l_table;
        }


        public static string getID()
        {
            string l_strDateTime = DateTime.Today.ToString("yyyyMMdd");


            //int seed = (int)DateTime.Now.Ticks; 
            //以時間產生亂數種子(在極短的時間內一樣是無法有效的取得不同的亂數種子)
            //int seed = (int)DateTime.Now.Millisecond; 
            //以時間產生亂數種子(在極短的時間內一樣是無法有效的取得不同的亂數種子)
            //int seed = Guid.NewGuid().GetHashCode();
            //以時間產生亂數種子(之所以能這樣寫是因為亂數種子必須要在極短的時間內帶入不同的值，而GUID剛好能有效的產生不重複的識別值)

            //string l_workid = Guid.NewGuid().ToString().Substring(0, 7);
            string seed = DateTime.Now.Millisecond.ToString();

            if (seed.Length < 3)
            {
                seed += "0";
            }

            Random R = new Random((int)System.DateTime.Now.Ticks);
            int n = R.Next(9999);

            //string l_str日期 = (Convert.ToInt32(DateTime.Today.ToString("yyyyMMdd")) - 1911).ToString();
            //if (l_str日期.Length >= 3)
            //{
            //    l_str日期 = l_str日期.Substring(0, 2);
            //}

            string l_workid = l_strDateTime + seed + n;
            return l_workid;
        }


        public static List<string> getidCollection(HttpCookieCollection cookies)
        {
            //宣告 TempStrArray 字串陣列做為暫存之用
            string[] TempStrArray;

            //創一個List<>
            List<string> l_idCollection = new List<string>();

            foreach (string CItem in cookies)
            {
                //如果 Cookie 名稱以 "Product_" 開頭
                //StartsWith判斷這個執行個體的開頭是否符合指定的字串。
                if (CItem.StartsWith("Product_"))
                {
                    //將 Cookie 名稱以 "_" 符號分割, 放入 TempStrArray
                    //所以 TempStrArray(1) 的值便是產品編號
                    TempStrArray = CItem.Split('_');
                    string l_strid = CItem.Substring(CItem.IndexOf("_") + 1);
                    l_idCollection.Add(l_strid);
                }
            }
            return l_idCollection;
        }


        /// <summary>
        /// 從某個存在檔案的檔案路徑去另存新檔
        /// </summary>
        /// <param name="FilePath">來源檔路徑</param>
        /// <param name="FileName">另存新檔檔名</param>
        public static void FileSaveAs(FileInfo file, string FileName)
        {
            System.Web.HttpResponse Response = System.Web.HttpContext.Current.Response;
            // Clear the content of the response     
            Response.ClearContent();      
            // LINE1: Add the file name and attachment, which will force the open/cance/save dialog to show, to the header     
            Response.AddHeader("Content-Disposition", String.Format("attachment; filename={0}", file.Name));      
            // Add the file size into the response header     
            Response.AddHeader("Content-Length", file.Length.ToString());      
            // Set the ContentType     
            //Response.ContentType = "application/vnd.text";
            Response.ContentType = ReturnFiletype(file.Extension.ToLower()); 
            // Write the file into the response (TransmitFile is for ASP.NET 2.0. In ASP.NET 1.1 you have to use WriteFile instead)    
            Response.TransmitFile(file.FullName);      
            // End the response    
            Response.End();      
            //send statistics to the class 
        }
        //return the filetype to tell the browser. 
        //defaults to "application/octet-stream" if it cant find a match, as this works for all file types.
        public static string ReturnFiletype(string fileExtension)
        {
            switch (fileExtension)
            {
                case ".htm":
                case ".html":
                case ".log":
                    return "text/HTML";
                case ".txt":
                    return "text/plain";
                case ".doc":
                    return "application/ms-word";
                case ".tiff":
                case ".tif":
                    return "image/tiff";
                case ".asf":
                    return "video/x-ms-asf";
                case ".avi":
                    return "video/avi";
                case ".zip":
                    return "application/zip";
                case ".xls":
                case ".csv":
                    return "application/vnd.ms-excel";
                case ".gif":
                    return "image/gif";
                case ".jpg":
                case "jpeg":
                    return "image/jpeg";
                case ".bmp":
                    return "image/bmp";
                case ".wav":
                    return "audio/wav";
                case ".mp3":
                    return "audio/mpeg3";
                case ".mpg":
                case "mpeg":
                    return "video/mpeg";
                case ".rtf":
                    return "application/rtf";
                case ".asp":
                    return "text/asp";
                case ".pdf":
                    return "application/pdf";
                case ".fdf":
                    return "application/vnd.fdf";
                case ".ppt":
                    return "application/mspowerpoint";
                case ".dwg":
                    return "image/vnd.dwg";
                case ".msg":
                    return "application/msoutlook";
                case ".xml":
                case ".sdxl":
                    return "application/xml";
                case ".xdp":
                    return "application/vnd.adobe.xdp+xml";
                default:
                    return "application/octet-stream";
            }
        }

        /// <summary>
        /// 將傳入的DataView參數Persistant到指定的Folder中
        /// </summary>
        /// <param name="p_dataView">要輸出的資料</param>
        /// <param name="p_strPath">要輸出Excel的路徑</param>
        /// <param name="p_strHeader">頁首(報表標題)</param>
        public static void toExcelByDataView(DataView p_dataView, string p_strPath, string p_strHeader)
        {
            string l_strContent = "";
            DataTable l_table = p_dataView.Table;
            // fill columns from dataview.
            for (int i = 0; i < l_table.Columns.Count; i++)
            {
                l_strContent += l_table.Columns[i].ToString() + "\t";
            }
            l_strContent = l_strContent.Substring(0, l_strContent.Length - 1) + "\n";

            // fill rows from dataview
            for (int i = 0; i < l_table.Rows.Count; i++)
            {
                for (int j = 0; j < l_table.Columns.Count; j++)
                {
                    string l_strRow = l_table.Rows[i][j].ToString();
                    if (isNumberic(l_strRow) && l_strRow.Length > 8)
                    {
                        l_strContent += "ˉ";
                    }

                    l_strContent += l_strRow + "\t";
                }
                l_strContent = l_strContent.Substring(0, l_strContent.Length - 1) + "\n";
            }
            if (!"".Equals(p_strHeader))
            {

                l_strContent = p_strHeader + "\n" + l_strContent;
            }

            // flush to server disk
            StreamWriter l_writer = new StreamWriter(p_strPath, false, Encoding.Default);
            l_writer.Write(l_strContent);
            l_writer.Close();

        }
        private static bool isNumberic(string p_strValue)
        {
            try
            {
                double l_dbl = Convert.ToDouble(p_strValue);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}