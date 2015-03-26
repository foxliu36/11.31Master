using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;
using KDUOFLib.REW.UCO;
using System.Data;
using Fast.EB.SystemInfo;
using System.IO;
using System.Text.RegularExpressions;
using KDUOFLib.PET.UCO;
using System.Collections;
using KDUOFLib.HR.UCO;

namespace KDUOFLib
{
    public class Utility
    {
        public static DDLObject[] getBRANCHs(){
            List<DDLObject> results = new List<DDLObject>();
            CPetitionUCO CPetitionUCO = new CPetitionUCO();
            DataTable dt = CPetitionUCO.QueryBranchDatas();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                results.Add(new DDLObject() { ID = dt.Rows[i]["GROUP_ID"].ToString(), Name = dt.Rows[i]["GROUP_NAME"].ToString() });
            }
            //results.Add(new DDLObject() { ID = "01", Name = "北高" });
            //results.Add(new DDLObject() { ID = "02", Name = "屏東" });
            //results.Add(new DDLObject() { ID = "03", Name = "九如" });
            //results.Add(new DDLObject() { ID = "04", Name = "麟洛" });
            //results.Add(new DDLObject() { ID = "05", Name = "小港" });
            //results.Add(new DDLObject() { ID = "06", Name = "Test" });
            //results.Add(new DDLObject() { ID = "07", Name = "AAAA" });

            return results.ToArray();
        }

        public static void setDataRowModifyData(System.Data.DataRow row)
        {
            if (row["CREATE_DATE"] == DBNull.Value)
            {
                row["CREATE_FROM"] = Current.UserIPAddress;
                row["CREATE_DATE"] = DateTime.Now;
                row["CREATOR"] = Current.User.Account;
            }
            row["MODIFY_FROM"] = Current.UserIPAddress;
            row["MODIFY_DATE"] = DateTime.Now;
            row["MODIFIER"] = Current.User.Account;
        }
        public static void JSAlert(string msg)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type='text/javascript'> \n");
            sb.Append("alert('" + msg + "') \n");
            sb.Append("</script> \n");
            HttpContext.Current.Response.Write(sb.ToString());
           
        }
        public static string JSAlertForUpl(string msg)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type='text/javascript'> \n");
            sb.Append("alert('" + msg + "') \n");
            sb.Append("</script> \n");
            return sb.ToString();
        }


        internal static void SetBasePersistentObjectParameters(Fast.EB.Utility.Data.DatabaseHelper databaseHelper, System.Data.DataRow row)
        {
            System.Data.DataTable dt = row.Table;

            for (int i = 0; i < dt.Columns.Count; i++)
            {
                string caption = dt.Columns[i].Caption;

                databaseHelper.AddParameter("@" + caption, row[caption]);
            }
        }

        public static void setCarCod(DropDownList ddl)
        {
            CCarnameUCO CCarnameUCO = new CCarnameUCO();
            DataTable dt = new DataTable();
            dt = CCarnameUCO.QueryCarnameDatas();
            ddl.Items.Clear();

            ddl.DataSource = dt;
            ddl.DataValueField = "CAR_CODE";
            ddl.DataTextField = "CAR_TYPE_NAME";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("", ""));
        }
        public static void setSFXByCarCode(DropDownList ddl, string carCode)
        {
            CCarmodelUCO CCarnameUCO = new CCarmodelUCO();
            DataTable dt = CCarnameUCO.QueryDatasBySearch(carCode, "");
            ddl.Items.Clear();
            ddl.DataSource = dt;
            ddl.DataValueField = "CAR_SFX";
            ddl.DataTextField = "CAR_SFX";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("", ""));
        }
        public static void setYearByCarCode(DropDownList ddl, string carCode)
        {
            CCaryearUCO CCaryearUCO = new CCaryearUCO();
            DataTable dt = CCaryearUCO.QueryYearsByCarcod(carCode);
            ddl.Items.Clear();
            ddl.DataSource = dt;
            ddl.DataValueField = "CAR_YEAR";
            ddl.DataTextField = "CAR_YEAR";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("", ""));

        }
        public static void setPetCom(DropDownList ddl)
        {
            CPetcomUCO CPetcomUCO = new CPetcomUCO();
            DataTable dt = CPetcomUCO.QueryPetcomDatas();
            ddl.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ddl.Items.Add(new ListItem(dt.Rows[i]["COM_NAME"].ToString(),dt.Rows[i]["COM_ID"].ToString()));
            }
            ddl.Items.Insert(0, new ListItem("", ""));

        }

        public static void setBRANCHs(DropDownList ddl)
        {
            CPetitionUCO CPetitionUCO = new CPetitionUCO();
            DataTable dt = CPetitionUCO.QueryBranchDatas();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ddl.Items.Add(new ListItem(dt.Rows[i]["GROUP_NAME"].ToString(), dt.Rows[i]["GROUP_ID"].ToString()));
            }
            ddl.Items.Insert(0, new ListItem("", ""));

        }
        public static string GetChineseNumber(int number)
        {
            String[] chineseNumber = { "零", "壹", "貳", "參", "肆", "伍", "陸", "柒", "捌", "玖" };
            String[] unit = { "", "拾", "佰", "仟", "萬", "拾萬", "佰萬", "仟萬", "億", "拾億", "佰億", "仟億", "兆", "拾兆", "佰兆", "仟兆" };
            StringBuilder ret = new StringBuilder();
            string inputNumber = number.ToString();
            int idx = inputNumber.Length;
            bool needAppendZero = false;
            foreach (char c in inputNumber)
            {
                idx--;
                if (c > '0')
                {
                    if (needAppendZero)
                    {
                        ret.Append(chineseNumber[0]);
                        needAppendZero = false;
                    }
                    ret.Append(chineseNumber[(int)(c - '0')] + unit[idx]);
                }
                else
                {
                    needAppendZero = true;
                }
            }
            return ret.Length == 0 ? chineseNumber[0] : ret.ToString();
        }

        public static string getCarBrand(string carcod)
        {
            switch (carcod)
            {
                case "F": return "國瑞"; 
                case "IN": return "國瑞";
                case "K": return "國瑞";
                case "KH": return "國瑞"; 
                case "O": return "國瑞";
                case "P": return "國瑞";
                case "PD": return "國瑞"; 
                case "V": return "國瑞"; 
                case "W": return "國瑞"; 
                case "YS": return "國瑞"; 
                case "U": return "TOYOTA"; 
                case "PS": return "TOYOTA";
                case "R": return "TOYOTA";
                case "PC": return "TOYOTA"; 
                case "AL": return "TOYOTA"; 
                default: return "LEXUS";
            }
        }

        public static string getCarCod(string carcod)
        {
            switch (carcod.Trim())
            {
                case "F": return "ZACE";
                case "IN": return "INNOVA";
                case "K": return "CAMRY-L";
                case "KH": return "CAMRY-HV";
                case "O": return "VIOS";
                case "P": return "PREMIO";
                case "PD": return "PRADO";
                case "V": return "ALTIS";
                case "W": return "WISH";
                case "YS": return "YARIS";
                case "U": return "PREVIA";
                case "PS": return "PRIUS";
                case "R": return "RAV4";
                case "AL": return "ALPHARD";
                default: return carcod;
            }
        }
        public static void setBranchByDataTable(DropDownList ddl)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("BRANCH", typeof(string)));
            dt.Columns.Add(new DataColumn("BRANCH_NAME", typeof(string)));
            DataRow l_row03 = dt.NewRow();
            l_row03["BRANCH"] = "03";
            l_row03["BRANCH_NAME"] = "F03岡山";
            dt.Rows.Add(l_row03);
            DataRow l_row04 = dt.NewRow();
            l_row04["BRANCH"] = "04";
            l_row04["BRANCH_NAME"] = "F04屏東";
            dt.Rows.Add(l_row04);
            DataRow l_row07 = dt.NewRow();
            l_row07["BRANCH"] = "07";
            l_row07["BRANCH_NAME"] = "F07北高";
            dt.Rows.Add(l_row07);
            DataRow l_row08 = dt.NewRow();
            l_row08["BRANCH"] = "08";
            l_row08["BRANCH_NAME"] = "F08旗山";
            dt.Rows.Add(l_row08);
            DataRow l_row09 = dt.NewRow();
            l_row09["BRANCH"] = "09";
            l_row09["BRANCH_NAME"] = "F09潮州";
            dt.Rows.Add(l_row09);
            DataRow l_row10 = dt.NewRow();
            l_row10["BRANCH"] = "10";
            l_row10["BRANCH_NAME"] = "F10小港";
            dt.Rows.Add(l_row10);
            DataRow l_row11 = dt.NewRow();
            l_row11["BRANCH"] = "11";
            l_row11["BRANCH_NAME"] = "F11九如";
            dt.Rows.Add(l_row11);
            DataRow l_row12 = dt.NewRow();
            l_row12["BRANCH"] = "12";
            l_row12["BRANCH_NAME"] = "F12鳳山";
            dt.Rows.Add(l_row12);
            DataRow l_row13 = dt.NewRow();
            l_row13["BRANCH"] = "13";
            l_row13["BRANCH_NAME"] = "F13湖內";
            dt.Rows.Add(l_row13);
            DataRow l_row14 = dt.NewRow();
            l_row14["BRANCH"] = "14";
            l_row14["BRANCH_NAME"] = "F14北屏";
            dt.Rows.Add(l_row14);
            DataRow l_row15 = dt.NewRow();
            l_row15["BRANCH"] = "15";
            l_row15["BRANCH_NAME"] = "F15青年";
            dt.Rows.Add(l_row15);
            DataRow l_row16 = dt.NewRow();
            l_row16["BRANCH"] = "16";
            l_row16["BRANCH_NAME"] = "F16楠梓";
            dt.Rows.Add(l_row16);
            DataRow l_row17 = dt.NewRow();
            l_row17["BRANCH"] = "17";
            l_row17["BRANCH_NAME"] = "F17瑞豐";
            dt.Rows.Add(l_row17);
            DataRow l_row18 = dt.NewRow();
            l_row18["BRANCH"] = "18";
            l_row18["BRANCH_NAME"] = "F18右昌";
            dt.Rows.Add(l_row18);
            DataRow l_row20 = dt.NewRow();
            l_row20["BRANCH"] = "20";
            l_row20["BRANCH_NAME"] = "F20東港";
            dt.Rows.Add(l_row20);
            DataRow l_row22 = dt.NewRow();
            l_row22["BRANCH"] = "22";
            l_row22["BRANCH_NAME"] = "F22鳳林";
            dt.Rows.Add(l_row22);
            DataRow l_row27 = dt.NewRow();
            l_row27["BRANCH"] = "27";
            l_row27["BRANCH_NAME"] = "F27三多";
            dt.Rows.Add(l_row27);
            DataRow l_row52 = dt.NewRow();
            l_row52["BRANCH"] = "52";
            l_row52["BRANCH_NAME"] = "F52民族";
            dt.Rows.Add(l_row52);
            DataRow l_row53 = dt.NewRow();
            l_row53["BRANCH"] = "53";
            l_row53["BRANCH_NAME"] = "F53建國";
            dt.Rows.Add(l_row53);

            ddl.DataSource = dt;
            ddl.DataValueField = "BRANCH";
            ddl.DataTextField = "BRANCH_NAME";
            ddl.DataBind();
            ddl.Items.Insert(0, new ListItem("", ""));
        }

        public static void setBranch(DropDownList ddl)
        {

            ddl.Items.Add(new ListItem("", ""));
            ddl.Items.Add(new ListItem("F03岡山", "03"));
            ddl.Items.Add(new ListItem("F04屏東", "04"));
            ddl.Items.Add(new ListItem("F07北高", "07"));
            ddl.Items.Add(new ListItem("F08旗山", "08"));
            ddl.Items.Add(new ListItem("F09潮州", "09"));
            ddl.Items.Add(new ListItem("F10小港", "10"));
            ddl.Items.Add(new ListItem("F11九如", "11"));
            ddl.Items.Add(new ListItem("F12鳳山", "12"));
            ddl.Items.Add(new ListItem("F13湖內", "13"));
            ddl.Items.Add(new ListItem("F14北屏", "14"));
            ddl.Items.Add(new ListItem("F15青年", "15"));
            ddl.Items.Add(new ListItem("F16楠梓", "16"));
            ddl.Items.Add(new ListItem("F17瑞豐", "17"));
            ddl.Items.Add(new ListItem("F18右昌", "18"));
            ddl.Items.Add(new ListItem("F20東港", "20"));
            ddl.Items.Add(new ListItem("F22鳳林", "22"));
            ddl.Items.Add(new ListItem("F27三多", "27"));
            ddl.Items.Add(new ListItem("F53建國", "53"));
            ddl.Items.Add(new ListItem("F52民族", "52"));

        }
        public static void setBranch(DropDownList ddl,string groupid)
        {
            ddl.Items.Add(new ListItem("", ""));
            if (groupid.Equals("南區"))
            {
                ddl.Items.Add(new ListItem("F04屏東", "04"));
                ddl.Items.Add(new ListItem("F07北高", "07"));
                ddl.Items.Add(new ListItem("F09潮州", "09"));
                ddl.Items.Add(new ListItem("F10小港", "10"));
                ddl.Items.Add(new ListItem("F14北屏", "14"));
                ddl.Items.Add(new ListItem("F17瑞豐", "17"));
                ddl.Items.Add(new ListItem("F20東港", "20"));
                ddl.Items.Add(new ListItem("F22鳳林", "22"));
            }
            else if (groupid.Equals("北區"))
            {
                ddl.Items.Add(new ListItem("F03岡山", "03"));
                ddl.Items.Add(new ListItem("F08旗山", "08"));
                ddl.Items.Add(new ListItem("F11九如", "11"));
                ddl.Items.Add(new ListItem("F12鳳山", "12"));
                ddl.Items.Add(new ListItem("F13湖內", "13"));
                ddl.Items.Add(new ListItem("F15青年", "15"));
                ddl.Items.Add(new ListItem("F16楠梓", "16"));
                ddl.Items.Add(new ListItem("F18右昌", "18"));
                ddl.Items.Add(new ListItem("F27三多", "27"));
            }
            else if (groupid.Equals("人資"))
            {
                ddl.Items.Add(new ListItem("F03岡山", "82bea600-2433-439f-9f67-c1203408184d"));
                ddl.Items.Add(new ListItem("F04屏東", "63acec50-f693-4b21-85cd-f71d6be09759"));
                ddl.Items.Add(new ListItem("F07北高", "a2b88531-2de5-4a84-9791-fa3f8e6649ce"));
                ddl.Items.Add(new ListItem("F08旗山", "cc334965-7ae5-42a0-b9d5-b7cb63e8a373"));
                ddl.Items.Add(new ListItem("F09潮州", "4b587a7f-d7c4-40cc-8078-ab446ce8b643"));
                ddl.Items.Add(new ListItem("F10小港", "bc5e3430-b032-40a2-b0a7-47fe12ec6cdb"));
                ddl.Items.Add(new ListItem("F11九如", "f8c393ee-17c5-4b29-a414-e8b3ec649fed"));
                ddl.Items.Add(new ListItem("F12鳳山", "4493decd-5609-4f1b-8637-65fa8f752488"));
                ddl.Items.Add(new ListItem("F13湖內", "326dedbe-1acf-4994-b4c1-5c7cfc6131e8"));
                ddl.Items.Add(new ListItem("F14北屏", "8b567de9-f340-42da-a2be-d4d4339fe6f3"));
                ddl.Items.Add(new ListItem("F15青年", "4dde4903-338a-46dd-9b2d-ccd2b1d74045"));
                ddl.Items.Add(new ListItem("F16楠梓", "ef44d26f-52bd-d024-906e-a517ebb7ab48"));
                ddl.Items.Add(new ListItem("F17瑞豐", "8cb80418-d096-4a3d-aa07-b6cd3f0c305c"));
                ddl.Items.Add(new ListItem("F18右昌", "4d65a5dc-51fa-432b-b1aa-4aa3a26edf24"));
                ddl.Items.Add(new ListItem("F20東港", "3111523e-ed56-442f-a351-9e3b7b314776"));
                ddl.Items.Add(new ListItem("F22鳳林", "7abadd40-4a9a-49aa-9b96-0a8246330bf2"));
                ddl.Items.Add(new ListItem("F27三多", "29fa7a83-98d4-4822-99e0-9b75e41b06be"));
                ddl.Items.Add(new ListItem("F52民族", "9386ca5e-9826-448c-8b01-0f88460de097"));
                ddl.Items.Add(new ListItem("F53建國", "8d49be58-a9ad-4ee1-ad4b-519d25c8ec87"));           
            }
            else
            {
                ddl.Items.Add(new ListItem("F03岡山", "03"));
                ddl.Items.Add(new ListItem("F04屏東", "04"));
                ddl.Items.Add(new ListItem("F07北高", "07"));
                ddl.Items.Add(new ListItem("F08旗山", "08"));
                ddl.Items.Add(new ListItem("F09潮州", "09"));
                ddl.Items.Add(new ListItem("F10小港", "10"));
                ddl.Items.Add(new ListItem("F11九如", "11"));
                ddl.Items.Add(new ListItem("F12鳳山", "12"));
                ddl.Items.Add(new ListItem("F13湖內", "13"));
                ddl.Items.Add(new ListItem("F14北屏", "14"));
                ddl.Items.Add(new ListItem("F15青年", "15"));
                ddl.Items.Add(new ListItem("F16楠梓", "16"));
                ddl.Items.Add(new ListItem("F17瑞豐", "17"));
                ddl.Items.Add(new ListItem("F18右昌", "18"));
                ddl.Items.Add(new ListItem("F20東港", "20"));
                ddl.Items.Add(new ListItem("F22鳳林", "22"));
                ddl.Items.Add(new ListItem("F27三多", "27"));
            }
        }
        public static ArrayList setBranchByLoaction(string location)
        {
            ArrayList l_al = new ArrayList();
            switch (location)
            {
                case "03":
                    l_al.Add("岡山區");
                    l_al.Add("田寮區");
                    l_al.Add("梓官區");
                    l_al.Add("橋頭區");
                    l_al.Add("燕巢區");
                    l_al.Add("彌陀區");
                    l_al.Add("永安區");
                    break;
                case "04":
                    l_al.Add("屏東市"); 
                    l_al.Add("內埔鄉"); 
                    l_al.Add("萬丹鄉"); 
                    l_al.Add("麟洛鄉");
                    break;
                case "07":
                    l_al.Add("三民區");
                    l_al.Add("左營區");
                    l_al.Add("仁武區");
                    l_al.Add("鳥松區");
                    break;
                case "09": 
                    l_al.Add("竹田鄉");
                    l_al.Add("來義鄉");
                    l_al.Add("枋山鄉");
                    l_al.Add("枋寮鄉");
                    l_al.Add("春日鄉");
                    l_al.Add("崁頂鄉");
                    l_al.Add("泰武鄉");
                    l_al.Add("新埤鄉");
                    l_al.Add("獅子鄉");
                    l_al.Add("潮州鎮");
                    l_al.Add("萬丹鄉");
                    break;
                case "13":					
                    l_al.Add("湖內區");
                    l_al.Add("阿蓮區");
                    l_al.Add("茄萣區");
                    l_al.Add("永安區");
                    l_al.Add("路竹區");
                    l_al.Add("田寮區");
                    break;
                case "14":							
                    l_al.Add("九如鄉");
                    l_al.Add("三地門");
                    l_al.Add("里港鄉");
                    l_al.Add("長治鄉");
                    l_al.Add("屏東市");
                    l_al.Add("高樹鄉");
                    l_al.Add("瑪家鄉");
                    l_al.Add("霧台鄉");
                    l_al.Add("鹽埔鄉");
                    break;
                case "20":
                    l_al.Add("東港鎮");
                    l_al.Add("佳冬鄉");
                    l_al.Add("林邊鄉");
                    l_al.Add("南州鄉");
                    l_al.Add("枋山鄉");
                    l_al.Add("新園鄉");
                    l_al.Add("琉球鄉");
                    l_al.Add("車城鄉");
                    l_al.Add("牡丹鄉");
                    l_al.Add("恆春鎮");
                    break;
                case "22":
                    l_al.Add("大寮區");
                    l_al.Add("林園區");
                    l_al.Add("鳳山區");
                    break;
                //北區
                case "08":
                    l_al.Add("旗山區");
                    l_al.Add("六龜區");
                    l_al.Add("甲仙區");
                    l_al.Add("杉林區");
                    l_al.Add("美濃區");
                    l_al.Add("茂林區");
                    l_al.Add("桃源區");
                    l_al.Add("內門區");
                    l_al.Add("那瑪夏");
                    break;
                case "10":
                    l_al.Add("小港區");
                    l_al.Add("林園區");
                    l_al.Add("前鎮區");
                    l_al.Add("旗津區");
                    break;
                case "11":
                    l_al.Add("鹽埕區");
                    l_al.Add("鼓山區");
                    l_al.Add("左營區");
                    l_al.Add("三民區");
                    break;
                case "12":
                    l_al.Add("鳳山區");
                    l_al.Add("鳥松區");
                    l_al.Add("大寮區");
                    l_al.Add("大樹區");
                    break;
                case "15":
                    l_al.Add("前金區");
                    l_al.Add("前鎮區");
                    l_al.Add("苓雅區");
                    l_al.Add("新興區");
                    break;
                case "16":
                    l_al.Add("左營區");
                    l_al.Add("仁武區");
                    l_al.Add("大社區");
                    l_al.Add("楠梓區");
                    l_al.Add("橋頭區");
                    l_al.Add("燕巢區");
                    break;
                case "17":
                    l_al.Add("前鎮區");
                    l_al.Add("苓雅區");
                    l_al.Add("鳳山區");
                    break;
                case "18":
                    l_al.Add("左營區");
                    l_al.Add("仁武區");
                    l_al.Add("大社區");
                    l_al.Add("楠梓區");
                    l_al.Add("橋頭區");
                    l_al.Add("燕巢區");
                    l_al.Add("梓官區");
                    break;
                case "27":
                    l_al.Add("前鎮區");
                    l_al.Add("苓雅區");
                    l_al.Add("鳳山區");
                    break;
                default: return null;	
            }
            return l_al;
        }
        public static string BranchChange(string UOFBranch)
        {
            switch (UOFBranch)
            {
                case "F03岡山一課": return "";
                case "F03岡山二課": return "";
                case "F08旗山一課": return "";
                case "F11九如一課": return "";
                case "F11九如二課": return "";
                case "F12鳳山一課": return "";
                case "F12鳳山二課": return "";
                case "F13湖內一課": return "";
                case "F15青年一課": return "";
                case "F15青年二課": return "";
                case "F18右昌一課": return "";
                case "F18右昌二課": return "";
                case "F27三多一課": return "";
                case "F27三多二課": return "";

                case "F04屏東一課": return "";
                case "F04屏東二課": return "";
                case "F07北高一課": return "";
                case "F07北高二課": return "";
                case "F07北高三課": return "";
                case "F07北高四課": return "";
                case "F09潮州一課": return "";
                case "F09潮州二課": return "";
                case "F10小港一課": return "";
                case "F14北屏一課": return "";
                case "F14北屏二課": return "";
                case "F17瑞豐一課": return "";
                case "F17瑞豐二課": return "";
                case "F20東港一課": return "";
                case "F22鳳林一課": return "";
                default:return "";
            }
        }

        public static string getJOBTitle(string user_guid)
        {
            COrderUCO COrderUCO = new COrderUCO();
            DataTable dt = COrderUCO.QueryDatasByGuid(user_guid);
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["TITLE_NAME"].ToString();
            }
            return "";
        }

        public static string getPAPER_TYPE(string p_formName)
        {
            if (p_formName.IndexOf("部長級以上") > 0)
            {
                return "部長級";
            }
            if (p_formName.IndexOf("經副理級") > 0)
            {
                return "經副理級";
            }
            if (p_formName.IndexOf("課長級") > 0)
            {
                return "課長級";
            }
            if (p_formName.IndexOf("副課長級") > 0)
            {
                return "副課長級";
            }
            if (p_formName.IndexOf("所助理") > 0)
            {
                return "所助理";
            }
            if (p_formName.IndexOf("總務外據點") > 0)
            {
                return "總務外據點";
            }
            if (p_formName.IndexOf("總務福委會") > 0)
            {
                return "總務福委會";
            }
            return "";
        }


        public static string getASSESS_TYPE(DateTime p_dtToday)
        {
            if (p_dtToday.Month >= 8 && p_dtToday.Month <= 10)
            {
                return "中秋";
            }
            else if (p_dtToday.Month >= 4 && p_dtToday.Month <= 6)
            {
                return "端午";
            }
            else if (p_dtToday.Month >= 1 && p_dtToday.Month <= 2)
            {
                return "年節";
            }
            return "";
        }

        public static string getPERT_LEVEL(int p_PERT)
        {
            if (p_PERT >= 90)
            {
                return "A";
            }
            else if (p_PERT >= 87 && p_PERT <= 89)
            {
                return "B+";
            }
            else if (p_PERT >= 84 && p_PERT <= 86)
            {
                return "B";
            }
            else if (p_PERT >= 80 && p_PERT <= 83)
            {
                return "B-";
            }
            else if (p_PERT >= 77 && p_PERT <= 79)
            {
                return "C+";
            }
            else if (p_PERT >= 74 && p_PERT <= 76)
            {
                return "C";
            }
            else if (p_PERT >= 70 && p_PERT <= 73)
            {
                return "C-";
            }
            else if (p_PERT >= 67 && p_PERT <= 69)
            {
                return "D+";
            }
            else if (p_PERT >= 64 && p_PERT <= 66)
            {
                return "D";
            }
            else if (p_PERT >= 60 && p_PERT <= 63)
            {
                return "D-";
            }
            else if (p_PERT <= 59)
            {
                return "F";
            }
            return "";
        }
    }


}
