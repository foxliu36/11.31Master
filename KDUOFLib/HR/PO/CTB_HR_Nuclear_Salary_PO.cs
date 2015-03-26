using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace KDUOFLib.HR.PO
{
    public class CTB_HR_Nuclear_Salary_PO : Fast.EB.Utility.Data.BasePersistentObject
    {
        HRDataSetTableAdapters.TableAdapterManager _myTAM;
        public CTB_HR_Nuclear_Salary_PO()
        {
            _myTAM = new HRDataSetTableAdapters.TableAdapterManager();
            _myTAM.BackupDataSetBeforeUpdate = false;
            _myTAM.UpdateOrder = HRDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            //加入Table Adapter
            _myTAM.TB_HR_Nuclear_SalaryTableAdapter = new HRDataSetTableAdapters.TB_HR_Nuclear_SalaryTableAdapter();
            _myTAM.TB_HR_Nuclear_SalaryTableAdapter.Connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;
        }

        public void Update(HRDataSet ds)
        {
            _myTAM.UpdateAll(ds);
        }

        public void Delete(string p_TASK_ID)
        {
            string cmdTxt = @"delete from TB_HR_Nuclear_Salary where TASK_ID='" + p_TASK_ID + "'";
            this.m_db.ExecuteNonQuery(cmdTxt);
        }

        public DataTable getUSER_GUIDbyACCOUNT(DataTable p_dt, string p_ACCOUNT)
        {
            string cmdTxt = @" select u.USER_GUID,u.NAME,u.OPTION1,p.BIRTHDAY,p.ARRIVE_DATE ,eh.MILITARY_SERVICE,he.SCHOOL,he.MAJOR ";
            cmdTxt += @" from TB_EB_USER u";
            cmdTxt += @" left join TB_EB_EMPL p on p.USER_GUID=u.USER_GUID";
            cmdTxt += @" left join TB_EB_EMPL_HR eh on eh.USER_GUID = p.USER_GUID";
            cmdTxt += @" left join TB_EB_EMPL_HR_EDUACTION he on he.USER_GUID = p.USER_GUID";
            cmdTxt += @" where u.ACCOUNT= '" + p_ACCOUNT + "'";

            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            p_dt.Load(dr);   //解析SQL內的資料(可以是DataTable、DataGrid...)
            dr.Dispose();   //切斷與資料庫連線
            return p_dt;
        }

        public DataTable getData(DataTable p_dt, string p_USER_GUID)
        {
            string cmdTxt = @" select ns.USER_GUID,ns.CLASS,ns.TITLE_NAME,ns.Base_Salary,";
            cmdTxt += @" ns.Food_Allowance,ns.Full_Bonus,ns.Position_Bonus,ns.Learder_Bonus,ns.Skill_Bonus,ns.License_Bonus,";
            cmdTxt += @" ns.Experience_Bonus,ns.Other_Bonus,ns.Bonus_Sum,ns.Creat_Date,ns.OPTION1 from (";
            cmdTxt += @" select USER_GUID,CLASS,MAX(Creat_Date) as Creat_Date,Base_Salary,Food_Allowance,Full_Bonus,Position_Bonus,Learder_Bonus,";
            cmdTxt += @" Skill_Bonus,License_Bonus,Experience_Bonus,Other_Bonus,Bonus_Sum,OPTION1,TITLE_NAME";
            cmdTxt += @" from TB_HR_Nuclear_Salary";
            cmdTxt += @" group by USER_GUID,CLASS,Creat_Date,Base_Salary,Food_Allowance,Full_Bonus,Position_Bonus,Learder_Bonus,";
            cmdTxt += @" Skill_Bonus,License_Bonus,Experience_Bonus,Other_Bonus,Bonus_Sum,OPTION1,CLASS,TITLE_NAME) as ns";         
            cmdTxt += @" left join TB_EB_EMPL_DEP ed on ed.USER_GUID = ns.USER_GUID";
            cmdTxt += @" left join TB_EB_JOB_TITLE jt on jt.TITLE_ID = ed.TITLE_ID";           
            cmdTxt += @" where ed.ORDERS = 0";
            cmdTxt += @" and ns.USER_GUID= '" + p_USER_GUID + "'";
            cmdTxt += @" order by Creat_Date desc";

            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            p_dt.Load(dr);   //解析SQL內的資料(可以是DataTable、DataGrid...)
            dr.Dispose();   //切斷與資料庫連線
            return p_dt;
        }

        public DataTable getDetailbyDate(DataTable p_dt, string p_BDate, string p_EDate)
        {
            string cmdTxt = @"select u.ACCOUNT,u.NAME,p.ARRIVE_DATE,p.BIRTHDAY,eh.MILITARY_SERVICE,he.SCHOOL,he.MAJOR,ns.CLASS,";
            cmdTxt += @" ns.MOVE_DATE,ns.MOVE_TYPE,ns.Group_Name,ns.TITLE_NAME,ns.OPTION1,ns.Base_Salary,ns.SINGER,ns.TASK_ID,";
            cmdTxt += @" ns.Food_Allowance,ns.Full_Bonus,ns.Position_Bonus,ns.Learder_Bonus,ns.Skill_Bonus,ns.License_Bonus,";
            cmdTxt += @" ns.Experience_Bonus,ns.Other_Bonus,ns.Bonus_Sum,ns.Creat_Date,ns.MEMO from (";
            cmdTxt += @" select USER_GUID,CLASS,Creat_Date,MOVE_DATE,MOVE_TYPE,Group_Name,TITLE_NAME,";
            cmdTxt += @" OPTION1, Base_Salary,Food_Allowance,Full_Bonus,Position_Bonus,Learder_Bonus,TASK_ID,";
            cmdTxt += @" Skill_Bonus,License_Bonus,Experience_Bonus,Other_Bonus,Bonus_Sum,SINGER ,MEMO";
            cmdTxt += @" from TB_HR_Nuclear_Salary ) as ns ";
            cmdTxt += @" left join TB_EB_USER u on u.USER_GUID =ns.USER_GUID";
            cmdTxt += @" left join TB_EB_EMPL p on p.USER_GUID=ns.USER_GUID";
            cmdTxt += @" left join TB_EB_EMPL_HR_EDUACTION he on he.USER_GUID = p.USER_GUID";
            cmdTxt += @" left join TB_EB_EMPL_DEP ed on ed.USER_GUID = p.USER_GUID";
            cmdTxt += @" left join TB_EB_JOB_TITLE jt on jt.TITLE_ID = ed.TITLE_ID";
            cmdTxt += @" left join TB_EB_EMPL_HR eh on eh.USER_GUID = p.USER_GUID";
            cmdTxt += @" where ed.ORDERS = 0";
            cmdTxt += @" and ns.MOVE_DATE between '" + p_BDate + "' and '" + p_EDate + "'";
            cmdTxt += @" order by u.ACCOUNT desc,ns.Creat_Date,ns.MOVE_DATE";

            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            p_dt.Load(dr);   //解析SQL內的資料(可以是DataTable、DataGrid...)
            dr.Dispose();   //切斷與資料庫連線
            return p_dt;
        }

        public DataTable getDetailbySMID(DataTable p_dt, string p_smid, string p_type)
        {
            string cmdTxt = @"select u.ACCOUNT,u.NAME,p.ARRIVE_DATE,p.BIRTHDAY,eh.MILITARY_SERVICE,he.SCHOOL,he.MAJOR,ns.CLASS,";
            cmdTxt += @" ns.MOVE_DATE,ns.MOVE_TYPE,ns.Group_Name,ns.TITLE_NAME,ns.OPTION1,ns.Base_Salary,ns.SINGER,ns.TASK_ID,";
            cmdTxt += @" ns.Food_Allowance,ns.Full_Bonus,ns.Position_Bonus,ns.Learder_Bonus,ns.Skill_Bonus,ns.License_Bonus,";
            cmdTxt += @" ns.Experience_Bonus,ns.Other_Bonus,ns.Bonus_Sum,ns.Creat_Date,ns.MEMO from (";
            cmdTxt += @" select USER_GUID,CLASS,Creat_Date,MOVE_DATE,MOVE_TYPE,Group_Name,TITLE_NAME,";
            cmdTxt += @" OPTION1, Base_Salary,Food_Allowance,Full_Bonus,Position_Bonus,Learder_Bonus,TASK_ID,";
            cmdTxt += @" Skill_Bonus,License_Bonus,Experience_Bonus,Other_Bonus,Bonus_Sum,SINGER ,MEMO";
            cmdTxt += @" from TB_HR_Nuclear_Salary ) as ns ";
            cmdTxt += @" left join TB_EB_USER u on u.USER_GUID =ns.USER_GUID";
            cmdTxt += @" left join TB_EB_EMPL p on p.USER_GUID=ns.USER_GUID";
            cmdTxt += @" left join TB_EB_EMPL_HR_EDUACTION he on he.USER_GUID = p.USER_GUID";
            cmdTxt += @" left join TB_EB_EMPL_DEP ed on ed.USER_GUID = p.USER_GUID";
            cmdTxt += @" left join TB_EB_JOB_TITLE jt on jt.TITLE_ID = ed.TITLE_ID";
            cmdTxt += @" left join TB_EB_EMPL_HR eh on eh.USER_GUID = p.USER_GUID";
            cmdTxt += @" where ed.ORDERS = 0";
            if (p_type.Equals("Branch") || p_type.Equals("TITLE_NAME"))
            {
                cmdTxt += @" and u.EXPIRE_DATE='9999-12-31 23:59:59.997'";
            }
            cmdTxt += @" and u.ACCOUNT in (" + p_smid.Substring(0, p_smid.Length - 1) + ")";
            if (p_type.Equals("DATE") || p_type.Equals("ACCOUNT"))
            {
                cmdTxt += @" order by ns.MOVE_DATE,ns.Creat_Date ";
            }
            else
            {
                cmdTxt += @" order by ns.MOVE_DATE desc,ns.Creat_Date desc";
            }

            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            p_dt.Load(dr);   //解析SQL內的資料(可以是DataTable、DataGrid...)
            dr.Dispose();   //切斷與資料庫連線
            return p_dt;
        }

        public DataTable getAllDetailbySMID(DataTable p_dt, string p_smid, string p_type)
        {
            string cmdTxt = @"select u.ACCOUNT,u.NAME,p.ARRIVE_DATE,p.BIRTHDAY,eh.MILITARY_SERVICE,he.SCHOOL,he.MAJOR,ns.CLASS,";
            cmdTxt += @" ns.MOVE_DATE,ns.MOVE_TYPE,ns.Group_Name,ns.TITLE_NAME,ns.OPTION1,ns.Base_Salary,ns.SINGER,ns.TASK_ID,";
            cmdTxt += @" ns.Food_Allowance,ns.Full_Bonus,ns.Position_Bonus,ns.Learder_Bonus,ns.Skill_Bonus,ns.License_Bonus,";
            cmdTxt += @" ns.Experience_Bonus,ns.Other_Bonus,ns.Bonus_Sum,ns.Creat_Date,ns.MEMO from (";
            cmdTxt += @" select USER_GUID,CLASS,Creat_Date,MOVE_DATE,MOVE_TYPE,Group_Name,TITLE_NAME,";
            cmdTxt += @" OPTION1, Base_Salary,Food_Allowance,Full_Bonus,Position_Bonus,Learder_Bonus,TASK_ID,";
            cmdTxt += @" Skill_Bonus,License_Bonus,Experience_Bonus,Other_Bonus,Bonus_Sum,SINGER ,MEMO";
            cmdTxt += @" from TB_HR_Nuclear_Salary ) as ns ";
            cmdTxt += @" left join TB_EB_USER u on u.USER_GUID =ns.USER_GUID";
            cmdTxt += @" left join TB_EB_EMPL p on p.USER_GUID=ns.USER_GUID";
            cmdTxt += @" left join TB_EB_EMPL_HR_EDUACTION he on he.USER_GUID = p.USER_GUID";
            cmdTxt += @" left join TB_EB_EMPL_DEP ed on ed.USER_GUID = p.USER_GUID";
            cmdTxt += @" left join TB_EB_JOB_TITLE jt on jt.TITLE_ID = ed.TITLE_ID";
            cmdTxt += @" left join TB_EB_EMPL_HR eh on eh.USER_GUID = p.USER_GUID";
            cmdTxt += @" where ed.ORDERS = 0";
            cmdTxt += @" and u.ACCOUNT in (" + p_smid.Substring(0, p_smid.Length - 1) + ")";
            if (p_type.Equals("DATE") || p_type.Equals("ACCOUNT"))
            {
                cmdTxt += @" order by ns.MOVE_DATE,ns.Creat_Date ";
            }
            else
            {
                cmdTxt += @" order by ns.MOVE_DATE desc,ns.Creat_Date ";
            }

            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            p_dt.Load(dr);   //解析SQL內的資料(可以是DataTable、DataGrid...)
            dr.Dispose();   //切斷與資料庫連線
            return p_dt;
        }

        public DataTable getDetailbyGroup_Name(DataTable p_dt, string p_Group_Name)
        {
            string cmdTxt = @"select u.ACCOUNT,u.NAME,p.ARRIVE_DATE,p.BIRTHDAY,eh.MILITARY_SERVICE,he.SCHOOL,he.MAJOR,ns.CLASS,";
            cmdTxt += @" ns.MOVE_DATE,ns.MOVE_TYPE,ns.Group_Name,ns.TITLE_NAME,ns.OPTION1,ns.Base_Salary,ns.SINGER,ns.TASK_ID,";
            cmdTxt += @" ns.Food_Allowance,ns.Full_Bonus,ns.Position_Bonus,ns.Learder_Bonus,ns.Skill_Bonus,ns.License_Bonus,";
            cmdTxt += @" ns.Experience_Bonus,ns.Other_Bonus,ns.Bonus_Sum,ns.Creat_Date,ns.MEMO from (";
            cmdTxt += @" select USER_GUID,CLASS,Creat_Date,MOVE_DATE,MOVE_TYPE,Group_Name,TITLE_NAME,";
            cmdTxt += @" OPTION1, Base_Salary,Food_Allowance,Full_Bonus,Position_Bonus,Learder_Bonus,TASK_ID,";
            cmdTxt += @" Skill_Bonus,License_Bonus,Experience_Bonus,Other_Bonus,Bonus_Sum,SINGER ,MEMO";
            cmdTxt += @" from TB_HR_Nuclear_Salary ) as ns ";
            cmdTxt += @" left join TB_EB_USER u on u.USER_GUID =ns.USER_GUID";
            cmdTxt += @" left join TB_EB_EMPL p on p.USER_GUID=ns.USER_GUID";
            cmdTxt += @" left join TB_EB_EMPL_HR_EDUACTION he on he.USER_GUID = p.USER_GUID";
            cmdTxt += @" left join TB_EB_EMPL_DEP ed on ed.USER_GUID = p.USER_GUID";
            cmdTxt += @" left join TB_EB_JOB_TITLE jt on jt.TITLE_ID = ed.TITLE_ID";
            cmdTxt += @" left join TB_EB_EMPL_HR eh on eh.USER_GUID = p.USER_GUID";
            cmdTxt += @" where ed.ORDERS = 0";
            cmdTxt += @" and u.EXPIRE_DATE='9999-12-31 23:59:59.997'";
            cmdTxt += @" and ns.Group_Name in (" + p_Group_Name.Substring(0, p_Group_Name.Length - 1) + ")";
            cmdTxt += @" order by ns.Creat_Date desc,ns.MOVE_DATE,u.ACCOUNT";

            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            p_dt.Load(dr);   //解析SQL內的資料(可以是DataTable、DataGrid...)
            dr.Dispose();   //切斷與資料庫連線
            return p_dt;
        }

        public DataTable getDetailbyTITLE_NAME(DataTable p_dt, string p_TITLE_NAME)
        {
            string cmdTxt = @"select u.ACCOUNT,u.NAME,p.ARRIVE_DATE,p.BIRTHDAY,eh.MILITARY_SERVICE,he.SCHOOL,he.MAJOR,ns.CLASS,";
            cmdTxt += @" ns.MOVE_DATE,ns.MOVE_TYPE,ns.Group_Name,ns.TITLE_NAME,ns.OPTION1,ns.Base_Salary,ns.SINGER,ns.TASK_ID,";
            cmdTxt += @" ns.Food_Allowance,ns.Full_Bonus,ns.Position_Bonus,ns.Learder_Bonus,ns.Skill_Bonus,ns.License_Bonus,";
            cmdTxt += @" ns.Experience_Bonus,ns.Other_Bonus,ns.Bonus_Sum,ns.Creat_Date,ns.MEMO from (";
            cmdTxt += @" select USER_GUID,CLASS,Creat_Date,MOVE_DATE,MOVE_TYPE,Group_Name,TITLE_NAME,";
            cmdTxt += @" OPTION1, Base_Salary,Food_Allowance,Full_Bonus,Position_Bonus,Learder_Bonus,TASK_ID,";
            cmdTxt += @" Skill_Bonus,License_Bonus,Experience_Bonus,Other_Bonus,Bonus_Sum,SINGER ,MEMO";
            cmdTxt += @" from TB_HR_Nuclear_Salary ) as ns ";
            cmdTxt += @" left join TB_EB_USER u on u.USER_GUID =ns.USER_GUID";
            cmdTxt += @" left join TB_EB_EMPL p on p.USER_GUID=ns.USER_GUID";
            cmdTxt += @" left join TB_EB_EMPL_HR_EDUACTION he on he.USER_GUID = p.USER_GUID";
            cmdTxt += @" left join TB_EB_EMPL_DEP ed on ed.USER_GUID = p.USER_GUID";
            cmdTxt += @" left join TB_EB_JOB_TITLE jt on jt.TITLE_ID = ed.TITLE_ID";
            cmdTxt += @" left join TB_EB_EMPL_HR eh on eh.USER_GUID = p.USER_GUID";
            cmdTxt += @" where ed.ORDERS = 0";
            cmdTxt += @" and u.EXPIRE_DATE='9999-12-31 23:59:59.997'";
            cmdTxt += @" and ns.TITLE_NAME = '" + p_TITLE_NAME + "'";
            cmdTxt += @" order by ns.Creat_Date desc,ns.MOVE_DATE,u.ACCOUNT";

            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            p_dt.Load(dr);   //解析SQL內的資料(可以是DataTable、DataGrid...)
            dr.Dispose();   //切斷與資料庫連線
            return p_dt;
        }

    }
}
