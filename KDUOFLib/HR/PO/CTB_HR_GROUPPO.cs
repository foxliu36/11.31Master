using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace KDUOFLib.HR.PO
{
    public class CTB_HR_GROUPPO : Fast.EB.Utility.Data.BasePersistentObject
    {
        HRDataSetTableAdapters.TableAdapterManager _myTAM;
        public CTB_HR_GROUPPO()
        {
            _myTAM = new HRDataSetTableAdapters.TableAdapterManager();
            _myTAM.BackupDataSetBeforeUpdate = false;
            _myTAM.UpdateOrder = HRDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            //加入Table Adapter
            _myTAM.TB_EB_GROUPTableAdapter = new HRDataSetTableAdapters.TB_EB_GROUPTableAdapter();
            _myTAM.TB_EB_GROUPTableAdapter.Connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;

        }

        public DataTable getDatsByID(DataTable p_dt, string p_GroupID)
        {
            string cmdTxt = @"select * from FN_EB_GetGroupIdByRecursive ('" + p_GroupID + "')";
            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            p_dt.Load(dr);   //解析SQL內的資料(可以是DataTable、DataGrid...)
            dr.Dispose();   //切斷與資料庫連線
            return p_dt;
        }

        public string getstringByID(DataTable p_dt, string p_GroupID)
        {
            string cmdTxt = @"select * from FN_EB_GetGroupIdByRecursive ('" + p_GroupID + "')";
            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            p_dt.Load(dr);   //解析SQL內的資料(可以是DataTable、DataGrid...)
            dr.Dispose();   //切斷與資料庫連線
            List<DataRow> l_list = new List<DataRow>();
            foreach (DataRow row in p_dt.Rows)
            {
                l_list.Add(row);
            }
            string l_str部門 = "";
            for (int i = 0; i < l_list.Count; i++)
            {
                l_str部門 += "'" + l_list[i][0].ToString() + "',";
            }

            return l_str部門;
        }

        public string getSMIDbyType(DataTable p_dt, string p_Branch, string p_Type)
        {
            string cmdTxt = @" select u.ACCOUNT";
            cmdTxt += @" from TB_EB_USER u";
            cmdTxt += @" inner join TB_EB_EMPL_DEP e on e.USER_GUID=u.USER_GUID";
            cmdTxt += @" inner join TB_EB_GROUP g on g.GROUP_ID=e.GROUP_ID";
            cmdTxt += @" inner join TB_EB_EMPL_FUNC ef on ef.USER_GUID =u.USER_GUID";
            cmdTxt += @" inner join TB_EB_JOB_FUNC jb on jb.FUNC_ID = ef.FUNC_ID";
            cmdTxt += @" where g.GROUP_ID in(";
            cmdTxt += @" " + p_Branch.Substring(0, p_Branch.Length - 1) + ")";
            cmdTxt += @" and u.EXPIRE_DATE='9999-12-31 23:59:59.997'";
            cmdTxt += @" and jb.FUNC_NAME in (" + p_Type + ")";
            cmdTxt += @" group by u.ACCOUNT,CREATE_DATE,jb.FUNC_NAME";
            cmdTxt += @" order by jb.FUNC_NAME";
            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            p_dt.Load(dr);   //解析SQL內的資料(可以是DataTable、DataGrid...)
            dr.Dispose();   //切斷與資料庫連線
            List<DataRow> l_list = new List<DataRow>();
            foreach (DataRow row in p_dt.Rows)
            {
                l_list.Add(row);
            }
            string l_str員編 = "";
            for (int i = 0; i < l_list.Count; i++)
            {
                l_str員編 += "'" + l_list[i][0].ToString() + "',";
            }

            return l_str員編;
        }

        public double amount(DataTable p_dt, string p_GroupID)
        {
            string cmdTxt = @" select COUNT(*) from TB_EB_USER u";
            cmdTxt += " inner join TB_EB_EMPL_DEP e on e.USER_GUID=u.USER_GUID";
            cmdTxt += " inner join TB_EB_GROUP g on g.GROUP_ID=e.GROUP_ID";
            cmdTxt += " where g.GROUP_ID='" + p_GroupID + "'";
            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            p_dt.Load(dr);   //解析SQL內的資料(可以是DataTable、DataGrid...)
            dr.Dispose();   //切斷與資料庫連線
            List<DataRow> l_list = new List<DataRow>();
            foreach (DataRow row in p_dt.Rows)
            {
                l_list.Add(row);
            }

            double l_int數量 = Convert.ToInt32(l_list[0][0].ToString());

            return l_int數量;
        }

        //public bool Post(DataTable p_dt, string p_SMID)
        //{
        //    string cmdTxt = @" select FUNC_NAME";
        //    cmdTxt += @" from TB_EB_USER u";
        //    cmdTxt += @" inner join TB_EB_EMPL_FUNC ef on ef.USER_GUID=u.USER_GUID";
        //    cmdTxt += @" inner join TB_EB_JOB_FUNC jf on jf.FUNC_ID=ef.FUNC_ID";
        //    cmdTxt += @" where u.ACCOUNT='" + p_SMID + "'";

        //    System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
        //    p_dt.Load(dr);   //解析SQL內的資料(可以是DataTable、DataGrid...)
        //    dr.Dispose();   //切斷與資料庫連線
        //    List<DataRow> l_list = new List<DataRow>();
        //    foreach (DataRow row in p_dt.Rows)
        //    {
        //        l_list.Add(row);
        //    }
        //    string l_str = "";
        //    for (int i = 0; i < l_list.Count; i++)
        //    {
        //        l_str = l_list[i][0].ToString();
        //        if (l_str.Equals("服務廠廠長"))
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}

        public bool Post(DataTable p_dt, string p_SMID, string p_post)
        {
            string cmdTxt = @" select FUNC_NAME";
            cmdTxt += @" from TB_EB_USER u";
            cmdTxt += @" inner join TB_EB_EMPL_FUNC ef on ef.USER_GUID=u.USER_GUID";
            cmdTxt += @" inner join TB_EB_JOB_FUNC jf on jf.FUNC_ID=ef.FUNC_ID";
            cmdTxt += @" where u.ACCOUNT='" + p_SMID + "'";

            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            p_dt.Load(dr);   //解析SQL內的資料(可以是DataTable、DataGrid...)
            dr.Dispose();   //切斷與資料庫連線
            List<DataRow> l_list = new List<DataRow>();
            foreach (DataRow row in p_dt.Rows)
            {
                l_list.Add(row);
            }
            string l_str = "";
            for (int i = 0; i < l_list.Count; i++)
            {
                l_str = l_list[i][0].ToString();
                if (l_str.Equals(p_post))
                {
                    return true;
                }
            }


            return false;
        }

        # region 2013考核
        /// <summary>
        /// 使用員編查詢該部門的單位ID
        /// </summary>
        /// <param name="p_SMID">員編</param>
        /// <param name="p_Group_Name">單位名稱</param>
        /// <param name="p_p_LEV">層級</param>
        /// <returns></returns>
        public string getGroupIDbySMID(DataTable p_dt, string p_SMID, string p_Group_Name, string p_LEV)
        {
            string cmdTxt = @" select g.*";
            cmdTxt += @" from TB_EB_USER u";
            cmdTxt += @" inner join TB_EB_EMPL_DEP ep on ep.USER_GUID =u.USER_GUID";
            cmdTxt += @" inner join TB_EB_GROUP g on g.GROUP_ID =ep.GROUP_ID";
            cmdTxt += @" where u.ACCOUNT='" + p_SMID + "'";
            if (!String.IsNullOrEmpty(p_Group_Name))
            {
                cmdTxt += @" and g.GROUP_NAME='" + p_Group_Name + "'";
            }
            if (!String.IsNullOrEmpty(p_LEV))
            {
                cmdTxt += @" and g.LEV= '" + p_LEV + "'";
            }

            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            p_dt.Load(dr);   //解析SQL內的資料(可以是DataTable、DataGrid...)
            dr.Dispose();   //切斷與資料庫連線
            List<DataRow> l_list = new List<DataRow>();
            foreach (DataRow row in p_dt.Rows)
            {
                l_list.Add(row);
            }
            string l_GroupID = "";
            for (int i = 0; i < l_list.Count; i++)
            {
                l_GroupID = l_list[i][0].ToString();
            }
            return l_GroupID;
        }

        /// <summary>
        /// 使用單位ID查詢該單位所包涵的單位ID
        /// </summary>
        /// <param name="p_GroupID">單位ID</param>
        /// <param name="p_p_LEV">層級</param>
        /// <returns></returns>
        public string getAllGroupByID(DataTable p_dt, string p_GroupID, string p_LEV)
        {
            string cmdTxt = @"select * from FN_EB_GetGroupIdByRecursive ('" + p_GroupID + "')";
            if (!String.IsNullOrEmpty(p_LEV))
            {
                cmdTxt += @" where LEV= '" + p_LEV + "'";
            }
            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            p_dt.Load(dr);   //解析SQL內的資料(可以是DataTable、DataGrid...)
            dr.Dispose();   //切斷與資料庫連線
            List<DataRow> l_list = new List<DataRow>();
            foreach (DataRow row in p_dt.Rows)
            {
                l_list.Add(row);
            }
            string l_str部門 = "";
            for (int i = 0; i < l_list.Count; i++)
            {
                l_str部門 += "'" + l_list[i][0].ToString() + "',";
            }

            return l_str部門;
        }

        /// <summary>
        /// 有邏輯的查詢相關人員資料
        /// </summary>
        /// <param name="p_Branch">部門</param>
        /// <param name="p_TITLE_NAME">職級</param>
        /// <param name="p_FUNC_NAME">職務</param>
        /// <param name="p_userName">特殊人員</param>
        /// <param name="p_SameGroup">是否相同部門</param>
        /// <param name="p_GroupID">單位ID</param>
        /// <param name="p_NotGroupID">不包涵部門</param>
        /// <returns></returns>
        public DataTable getDats(DataTable p_dt, string p_Branch, string p_TITLE_NAME, string p_FUNC_NAME, string p_GroupID, string p_userName, bool p_SameGroup,string p_NotGroupID)
        {
            string cmdTxt = @"select u.ACCOUNT,u.NAME,g.GROUP_NAME,jb.FUNC_NAME,ISnull(s.TARGED,'0') as TARGED,jt.TITLE_NAME";
            cmdTxt += @" from TB_EB_USER u";
            cmdTxt += @" inner join TB_EB_EMPL_DEP e on e.USER_GUID=u.USER_GUID";
            cmdTxt += @" inner join TB_EB_EMPL_DEP ep on ep.USER_GUID =u.USER_GUID";
            cmdTxt += @" inner join TB_EB_GROUP g on g.GROUP_ID =ep.GROUP_ID";
            cmdTxt += @" inner join TB_EB_JOB_TITLE jt on jt.TITLE_ID = e.TITLE_ID ";
            cmdTxt += @" inner join TB_EB_EMPL_FUNC ef on ef.USER_GUID =u.USER_GUID";
            cmdTxt += @" left join dbo.TB_HR_STAFF_CAR s on s.SMID = u.ACCOUNT";
            cmdTxt += @" inner join TB_EB_JOB_FUNC jb on jb.FUNC_ID = ef.FUNC_ID ";
            cmdTxt += @" where u.EXPIRE_DATE='9999-12-31 23:59:59.997'";
            if (!String.IsNullOrEmpty(p_Branch))
            {
                cmdTxt += @" and g.GROUP_ID in (" + p_Branch.Substring(0, p_Branch.Length - 1) + ")";
            }
            cmdTxt += @" and e.ORDERS=0";
            if (!String.IsNullOrEmpty(p_TITLE_NAME))
            {
                cmdTxt += @" and jt.TITLE_NAME in ('" + p_TITLE_NAME + "')";
            }
            if (!String.IsNullOrEmpty(p_FUNC_NAME))
            {
                cmdTxt += @" and jb.FUNC_NAME in('" + p_FUNC_NAME + "')";
            }
            if (p_SameGroup == false)
            {
                cmdTxt += @" and g.GROUP_ID !='" + p_GroupID + "'";
            }
            if (!String.IsNullOrEmpty(p_NotGroupID))
            {
                cmdTxt += @" and g.GROUP_ID not in('" + p_NotGroupID + "')";
            }
            if (!String.IsNullOrEmpty(p_userName))
            {
                cmdTxt += @" and u.NAME not in('" + p_userName + "')";
            }
            cmdTxt += @" group by g.GROUP_NAME,u.ACCOUNT,u.NAME,jb.FUNC_NAME,s.TARGED,jt.TITLE_NAME";
            if (p_NotGroupID.Equals("7f01a398-fe7d-1afa-9a82-015a7f1b612f','e19c0389-3086-a343-5e39-796dbf4a16d3"))
            {
                cmdTxt += @" order by  (CASE jt.TITLE_NAME WHEN '經理（經理1）' THEN '1'";
                cmdTxt += @" WHEN '課長' THEN '2' WHEN '副課長' THEN '3'END)";
            }
            else
            {
                cmdTxt += @" order by jb.FUNC_NAME desc,g.GROUP_NAME";
            }
            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            p_dt.Load(dr);   //解析SQL內的資料(可以是DataTable、DataGrid...)
            dr.Dispose();   //切斷與資料庫連線
            return p_dt;
        }

        /// <summary>
        /// 兩個不同部門合併查詢相關人員資料
        /// </summary>
        /// <param name="p_Branch">第一個部門</param>
        /// <param name="p_Branch2">第二個部門</param>
        /// <param name="p_TITLE_NAME">第一個部門職級</param>
        /// <param name="p_TITLE_NAME2">第二個部門職級</param>
        /// <param name="p_FUNC_NAME">第一個部門職務</param>
        /// <param name="p_FUNC_NAME2">第二個部門職務ID</param>
        /// <returns></returns>
        public DataTable DoubleBranch(DataTable p_dt, string p_Branch, string p_Branch2, string p_TITLE_NAME, string p_TITLE_NAME2, string p_FUNC_NAME, string p_FUNC_NAME2)
        {
            string cmdTxt = @" select * from(";
            cmdTxt += @" select u.ACCOUNT,u.NAME,g.GROUP_NAME,jb.FUNC_NAME,jt.TITLE_NAME,ISnull(s.TARGED,'0') as TARGED";
            cmdTxt += @" from TB_EB_USER u";
            cmdTxt += @" inner join TB_EB_EMPL_DEP e on e.USER_GUID=u.USER_GUID";
            cmdTxt += @" inner join TB_EB_EMPL_DEP ep on ep.USER_GUID =u.USER_GUID";
            cmdTxt += @" inner join TB_EB_GROUP g on g.GROUP_ID =ep.GROUP_ID";
            cmdTxt += @" inner join TB_EB_JOB_TITLE jt on jt.TITLE_ID = e.TITLE_ID ";
            cmdTxt += @" inner join TB_EB_EMPL_FUNC ef on ef.USER_GUID =u.USER_GUID";
            cmdTxt += @" inner join TB_EB_JOB_FUNC jb on jb.FUNC_ID = ef.FUNC_ID ";
            cmdTxt += @" left join dbo.TB_HR_STAFF_CAR s on s.SMID = u.ACCOUNT";
            cmdTxt += @" where u.EXPIRE_DATE='9999-12-31 23:59:59.997'";
            if (!String.IsNullOrEmpty(p_Branch))
            {
                cmdTxt += @" and g.GROUP_ID in (" + p_Branch.Substring(0, p_Branch.Length - 1) + ")";
            }
            if (!String.IsNullOrEmpty(p_TITLE_NAME))
            {
                cmdTxt += @" and jt.TITLE_NAME in ('" + p_TITLE_NAME + "')";
            }
            if (!String.IsNullOrEmpty(p_FUNC_NAME))
            {
                cmdTxt += @" and jb.FUNC_NAME in('" + p_FUNC_NAME + "')";
            }
            cmdTxt += @" and e.ORDERS=0";
            cmdTxt += @" group by u.ACCOUNT,u.NAME,jb.FUNC_NAME,s.TARGED,g.GROUP_NAME,jt.TITLE_NAME";
            cmdTxt += @" ) as aa union all select * from (";
            cmdTxt += @" select u.ACCOUNT,u.NAME,g.GROUP_NAME,jb.FUNC_NAME,jt.TITLE_NAME,ISnull(s.TARGED,'0') as TARGED";
            cmdTxt += @" from TB_EB_USER u";
            cmdTxt += @" inner join TB_EB_EMPL_DEP e on e.USER_GUID=u.USER_GUID";
            cmdTxt += @" inner join TB_EB_EMPL_DEP ep on ep.USER_GUID =u.USER_GUID";
            cmdTxt += @" inner join TB_EB_GROUP g on g.GROUP_ID =ep.GROUP_ID";
            cmdTxt += @" inner join TB_EB_JOB_TITLE jt on jt.TITLE_ID = e.TITLE_ID ";
            cmdTxt += @" inner join TB_EB_EMPL_FUNC ef on ef.USER_GUID =u.USER_GUID";
            cmdTxt += @" inner join TB_EB_JOB_FUNC jb on jb.FUNC_ID = ef.FUNC_ID ";
            cmdTxt += @" left join dbo.TB_HR_STAFF_CAR s on s.SMID = u.ACCOUNT";
            cmdTxt += @" where u.EXPIRE_DATE='9999-12-31 23:59:59.997'";
            if (!String.IsNullOrEmpty(p_Branch2))
            {
                cmdTxt += @" and g.GROUP_ID in ('" + p_Branch2 + "')";
            } 
            if (!String.IsNullOrEmpty(p_TITLE_NAME2))
            {
                cmdTxt += @" and jt.TITLE_NAME in ('" + p_TITLE_NAME2 + "')";
            }
            if (!String.IsNullOrEmpty(p_FUNC_NAME2))
            {
                cmdTxt += @" and jb.FUNC_NAME in('" + p_FUNC_NAME2 + "')";
            }
            cmdTxt += @" and e.ORDERS=0";
            cmdTxt += @" group by u.ACCOUNT,u.NAME,jb.FUNC_NAME,s.TARGED,g.GROUP_NAME,jt.TITLE_NAME";
            cmdTxt += @" ) as bb";
            cmdTxt += @" order by GROUP_NAME desc,TITLE_NAME desc";

            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            p_dt.Load(dr);   //解析SQL內的資料(可以是DataTable、DataGrid...)
            dr.Dispose();   //切斷與資料庫連線
            return p_dt;
        }

        /// <summary>
        /// 例外查詢相關人員資料(毫無邏輯，直接寫死要查詢人員編)
        /// </summary>
        /// <param name="p_ACCOUNT">被查詢人員編</param>
        /// <param name="p_FUNC_NAME">職務</param>
        /// <param name="p_GroupName">部門名稱</param>
        /// <returns></returns>
        public DataTable getSpecialDats(DataTable p_dt, string p_ACCOUNT, string p_FUNC_NAME,string p_GroupName)
        {
            string cmdTxt = @" select u.ACCOUNT,u.NAME,g.GROUP_NAME,jb.FUNC_NAME,ISnull(s.TARGED,'0') as TARGED ,jt.TITLE_NAME";
            cmdTxt += @" from TB_EB_USER u ";
            cmdTxt += @" inner join TB_EB_EMPL_DEP e on e.USER_GUID=u.USER_GUID ";
            cmdTxt += @" inner join TB_EB_EMPL_DEP ep on ep.USER_GUID =u.USER_GUID ";
            cmdTxt += @" inner join TB_EB_GROUP g on g.GROUP_ID =ep.GROUP_ID";
            cmdTxt += @" inner join TB_EB_EMPL_FUNC ef on ef.USER_GUID =u.USER_GUID";
            cmdTxt += @" left join dbo.TB_HR_STAFF_CAR s on s.SMID = u.ACCOUNT";
            cmdTxt += @" inner join TB_EB_JOB_FUNC jb on jb.FUNC_ID = ef.FUNC_ID";
            cmdTxt += @" inner join TB_EB_JOB_TITLE jt on jt.TITLE_ID = e.TITLE_ID ";
            cmdTxt += @" where u.EXPIRE_DATE='9999-12-31 23:59:59.997'";
            cmdTxt += @" and e.ORDERS=0";
            if (!String.IsNullOrEmpty(p_FUNC_NAME))
            {
                cmdTxt += @" and jb.FUNC_NAME in('" + p_FUNC_NAME + "')";
            }
            cmdTxt += @" and u.ACCOUNT in('" + p_ACCOUNT + "')";
            if (!String.IsNullOrEmpty(p_GroupName))
            {
                cmdTxt += @" and g.GROUP_NAME in('" + p_GroupName + "')";
            }
            cmdTxt += @" group by u.ACCOUNT,u.NAME,g.GROUP_NAME,jb.FUNC_NAME,s.TARGED,jt.TITLE_NAME";
            if (p_GroupName.Equals("TOYOTA-KD','TOYOTA本部','LEXUS本部"))
            {
                cmdTxt += @" order by jt.TITLE_NAME desc";
            }
            else
            {
                cmdTxt += @" order by g.GROUP_NAME ";
            }

            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            p_dt.Load(dr);   //解析SQL內的資料(可以是DataTable、DataGrid...)
            dr.Dispose();   //切斷與資料庫連線
            return p_dt;
        }

        public DataTable getDatsbyStaff(DataTable p_dt, string p_Branch, string p_SMID, string p_FUNC_NAME)
        {
            string cmdTxt = @"select u.ACCOUNT,u.NAME,g.GROUP_NAME,jb.FUNC_NAME,ISnull(s.TARGED,'0') as TARGED,jt.TITLE_NAME";
            cmdTxt += @" from TB_EB_USER u";
            cmdTxt += @" inner join TB_EB_EMPL_DEP e on e.USER_GUID=u.USER_GUID";
            cmdTxt += @" inner join TB_EB_EMPL_DEP ep on ep.USER_GUID =u.USER_GUID";
            cmdTxt += @" inner join TB_EB_GROUP g on g.GROUP_ID =ep.GROUP_ID";
            cmdTxt += @" inner join TB_EB_JOB_TITLE jt on jt.TITLE_ID = e.TITLE_ID ";
            cmdTxt += @" inner join TB_EB_EMPL_FUNC ef on ef.USER_GUID =u.USER_GUID";
            cmdTxt += @" left join dbo.TB_HR_STAFF_CAR s on s.SMID = u.ACCOUNT";
            cmdTxt += @" inner join TB_EB_JOB_FUNC jb on jb.FUNC_ID = ef.FUNC_ID ";
            cmdTxt += @" where u.EXPIRE_DATE='9999-12-31 23:59:59.997'";
            if (!String.IsNullOrEmpty(p_Branch))
            {
                cmdTxt += @" and g.GROUP_ID in (" + p_Branch.Substring(0, p_Branch.Length - 1) + ")";
            }
            cmdTxt += @" and e.ORDERS=0";
            if (!String.IsNullOrEmpty(p_FUNC_NAME))
            {
                cmdTxt += @" and jb.FUNC_NAME in('" + p_FUNC_NAME + "')";
            }
            cmdTxt += @" and u.ACCOUNT !='" + p_SMID + "'";
            cmdTxt += @" group by g.GROUP_NAME,u.ACCOUNT,u.NAME,jb.FUNC_NAME,s.TARGED,jt.TITLE_NAME";
            cmdTxt += @" order by jb.FUNC_NAME";
            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            p_dt.Load(dr);   //解析SQL內的資料(可以是DataTable、DataGrid...)
            dr.Dispose();   //切斷與資料庫連線
            return p_dt;
        }

        # endregion

        # region 員介車抓單位名稱
        public string getGroupNamebySMID(DataTable dt,string SMID)
        {
            string cmdTxt = @" select g.GROUP_NAME";
            cmdTxt += @" from TB_EB_USER u";
            cmdTxt += @" inner join TB_EB_EMPL_DEP ep on ep.USER_GUID =u.USER_GUID";
            cmdTxt += @" inner join TB_EB_GROUP g on g.GROUP_ID =ep.GROUP_ID";
            cmdTxt += @" where u.ACCOUNT='" + SMID + "'";

            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);   //解析SQL內的資料(可以是DataTable、DataGrid...)
            dr.Dispose();   //切斷與資料庫連線
            List<DataRow> l_list = new List<DataRow>();
            foreach (DataRow row in dt.Rows)
            {
                l_list.Add(row);
            }
            string l_GroupName = "";
            for (int i = 0; i < l_list.Count; i++)
            {
                l_GroupName = l_list[i][0].ToString();
            }
            return l_GroupName;
        }

        public string getNamebySMID(DataTable dt, string SMID)
        {
            string cmdTxt = @" select u.Name from TB_EB_USER u";
            cmdTxt += @" where ACCOUNT='" + SMID + "'";
            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);   //解析SQL內的資料(可以是DataTable、DataGrid...)
            dr.Dispose();   //切斷與資料庫連線
            List<DataRow> l_list = new List<DataRow>();
            foreach (DataRow row in dt.Rows)
            {
                l_list.Add(row);
            }
            string l_Name = "";
            for (int i = 0; i < l_list.Count; i++)
            {
                l_Name = l_list[i][0].ToString();
            }
            return l_Name;
        }


        # endregion

    }
}
