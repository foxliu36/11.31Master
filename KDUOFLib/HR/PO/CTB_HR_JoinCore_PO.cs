using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using KDUOFLib.HR.UCO;
using Fast.EB.Organization.Util;
using HMI;

namespace KDUOFLib.HR.PO
{
    public class CTB_HR_JoinCore_PO : Fast.EB.Utility.Data.BasePersistentObject
    {
        HRDataSetTableAdapters.TableAdapterManager _myTAM;
        public CTB_HR_JoinCore_PO()
        {
            _myTAM = new HRDataSetTableAdapters.TableAdapterManager();
            _myTAM.BackupDataSetBeforeUpdate = false;
            _myTAM.UpdateOrder = HRDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            //加入Table Adapter
            _myTAM.TB_EB_GROUPTableAdapter = new HRDataSetTableAdapters.TB_EB_GROUPTableAdapter();
            _myTAM.TB_EB_GROUPTableAdapter.Connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;
        }

        //刪除員工主檔
        public void DeleteTB_EB_USER(string p_USER_GUID)
        {
            string cmdTxt = @"delete from TB_EB_USER where USER_GUID = '" + p_USER_GUID + "'";
            this.m_db.ExecuteNonQuery(cmdTxt);
        }
        //刪除部門職級
        public void DeleteTB_EB_EMPL_DEP(string p_USER_GUID)
        {
            string cmdTxt = @"delete from TB_EB_EMPL_DEP where USER_GUID = '" + p_USER_GUID + "'";
            this.m_db.ExecuteNonQuery(cmdTxt);
        }
        //刪除員工職務
        public void DeleteTB_EB_EMPL_FUNC(string p_USER_GUID)
        {
            string cmdTxt = @"delete from TB_EB_EMPL_FUNC where USER_GUID = '" + p_USER_GUID + "'";
            this.m_db.ExecuteNonQuery(cmdTxt);
        }
        //刪除員工設定
        public void DeleteTB_EB_EMPL(string p_USER_GUID)
        {
            string cmdTxt = @"delete from TB_EB_EMPL where USER_GUID = '" + p_USER_GUID + "'";
            this.m_db.ExecuteNonQuery(cmdTxt);
        }
        //刪除使用者人事
        public void DeleteTB_EB_EMPL_HR(string p_USER_GUID)
        {
            string cmdTxt = @"delete from TB_EB_EMPL_HR where USER_GUID = '" + p_USER_GUID + "'";
            this.m_db.ExecuteNonQuery(cmdTxt);
        }
        //刪除使用者學歷
        public void DeleteTB_EB_EMPL_HR_EDUACTION(string p_USER_GUID)
        {
            string cmdTxt = @"delete from TB_EB_EMPL_HR_EDUACTION where USER_GUID = '" + p_USER_GUID + "'";
            this.m_db.ExecuteNonQuery(cmdTxt);
        }

        private string CoreMARRIED(string p_MARRIED)
        {
            if (p_MARRIED == "未婚")
            {
                p_MARRIED = "0";
            }
            else
            {
                p_MARRIED = "1";
            }

            return p_MARRIED;
        }

        private string CoreSEX(string p_SEX)
        {
            if (p_SEX == "女")
            {
                p_SEX = "F";
            }
            else
            {
                p_SEX = "M";
            }

            return p_SEX;
        }

        public DataTable ifdouble(DataTable p_dt, string p_ACCOUNT)
        {

            string cmdTxt = @" select * from TB_EB_USER";
            cmdTxt += @" where ACCOUNT= '" + p_ACCOUNT + "'";

            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            p_dt.Load(dr);   //解析SQL內的資料(可以是DataTable、DataGrid...)
            dr.Dispose();   //切斷與資料庫連線

            return p_dt;
        }

        public void insertData(DataTable p_dtImport)
        {
            this.m_db.BeginTransaction();
            try
            {
                DateTime l_dt = DateTime.Now;
                string l_dtstr = l_dt.ToString("yyyy-MM-dd HH:mm:sss");
                for (int i = 0; i < p_dtImport.Rows.Count; i++)
                {
                    string l_strUser_Guid = Guid.NewGuid().ToString();
                    //先刪除舊有的資料
                    string l_ACCOUNT = p_dtImport.Rows[i]["員工編號"].ToString();
                    string l_Email = p_dtImport.Rows[i]["伊媚兒"].ToString();

                    string l_USER_GUID = getUSER_GUIDbyACCOUNT(l_ACCOUNT);
                    if (!l_USER_GUID.Equals(""))
                    {
                        DeleteTB_EB_USER(l_USER_GUID);
                        DeleteTB_EB_EMPL_DEP(l_USER_GUID);
                        DeleteTB_EB_EMPL_FUNC(l_USER_GUID);
                        DeleteTB_EB_EMPL(l_USER_GUID);
                        DeleteTB_EB_EMPL_HR(l_USER_GUID);
                        DeleteTB_EB_EMPL_HR_EDUACTION(l_USER_GUID);
                    }

                    //新增員工主檔
                    UserUCO userUCO = new UserUCO();
                    string l_PASSWORD = userUCO.HashPassword(p_dtImport.Rows[i]["員工編號"].ToString(), "");

                    string l_NAME = p_dtImport.Rows[i]["員工姓名"].ToString();
                    string l_SID = p_dtImport.Rows[i]["身分證字號"].ToString();
                    string l_OPTION1 = p_dtImport.Rows[i]["職等名稱"].ToString();
                    insertTB_EB_USER(l_strUser_Guid, l_ACCOUNT, l_NAME, l_PASSWORD, l_Email, l_dtstr, l_SID, l_OPTION1);

                    //新增部門＆職級
                    string l_GroupID = Utility.ReturnGROUP_ID(p_dtImport.Rows[i]["單位名稱"].ToString());
                    string l_TITLENAME = getTITLEIDbyTITLENAME(p_dtImport.Rows[i]["職稱名稱"].ToString());
                    insertTB_EB_EMPL_DEP(l_strUser_Guid, l_GroupID, l_TITLENAME);

                    //新增職務
                    string l_FUNC_ID = getFUNC_IDbyFUNC_NAME(p_dtImport.Rows[i]["職務名稱"].ToString());
                    insertTB_EB_EMPL_FUN(l_strUser_Guid, l_GroupID, l_FUNC_ID);

                    //新增兵役
                    string l_MILITARY_SERVICE = p_dtImport.Rows[i]["服役名稱"].ToString();
                    string l_MARRIED = CoreMARRIED(p_dtImport.Rows[i]["婚姻狀況"].ToString());
                    insertTB_EB_EMPL_HR(l_strUser_Guid, l_MARRIED, l_MILITARY_SERVICE);

                    //新增學歷
                    string l_EDUC_ID = getEDUC_IDbyEDUC_NAME(p_dtImport.Rows[i]["教育程度"].ToString());
                    string l_SCHOOL = p_dtImport.Rows[i]["畢業學校"].ToString();
                    string l_MAJOR = p_dtImport.Rows[i]["科系名稱"].ToString();
                    insertTB_EB_EMPL_HR_EDUACTION(l_strUser_Guid, l_EDUC_ID, l_SCHOOL, l_MAJOR);

                    //新增員工
                    string l_SEX = CoreSEX(p_dtImport.Rows[i]["性別"].ToString());
                    string l_BIRTHDAY = p_dtImport.Rows[i]["出生年月日"].ToString();
                    string l_ARRIVE_DATE = p_dtImport.Rows[i]["到職日"].ToString();
                    insertTB_EB_EMPL(l_strUser_Guid, l_EDUC_ID, l_ARRIVE_DATE, l_BIRTHDAY, l_SEX);
                }
                this.m_db.CommitTransaction();
            }
            catch(Exception ex)
            {
                this.m_db.RollbackTransaction();
                throw ex;
            }
        }

        //新增員工主檔
        public void insertTB_EB_USER(string p_userguid, string p_ACCOUNT,  string p_NAME,string p_PASSWORD, string p_Email, string p_datim, string p_SID, string p_OPTION1)
        {
            Dao l_Dao = new Dao("Data Source = 172.26.100.8;Initial Catalog=KDGAS;User ID=sa;Password=hp1020.;");

            string cmdTxt = @"insert into TB_EB_USER (USER_GUID,ACCOUNT,NAME,LANG,EMAIL,PASSWORD,IS_PASSWORD_RESET,";
            cmdTxt += @" CREATE_DATE,IS_LOCKED_OUT,USER_TYPE,PASSWORD_INVALID_ATTEMPTS,PW_RESET_REASON,";
            cmdTxt += @" IS_SUSPENDED,SID,OPTION1,OPTION2,OPTION3,OPTION4,OPTION5,OPTION6,NICKNAME,EXPIRE_DATE";
            cmdTxt += @" ) Values ('" + p_userguid + "'";
            cmdTxt += @" ,'" + p_ACCOUNT + "'";
            cmdTxt += @" ,'" + p_NAME + "'";
            cmdTxt += @" ,'','','" + p_PASSWORD + "',1,'" + p_datim + "',0,'Employee',0,0,0";
            cmdTxt += @" ,'" + p_SID + "'";
            cmdTxt += @" ,'" + p_OPTION1 + "'";
            cmdTxt += @" ,'','','','','','','9999-12-31 23:59:59.997')";
            this.m_db.ExecuteNonQuery(cmdTxt);

            //把資料也輸入GAS裡面
            string gascmdTxt =  @"insert into TB_EB_USER (ACCOUNT, NAME, EMAIL,PASSWORD,IS_PASSWORD_RESET";
            gascmdTxt += @" ,CREATE_DATE ,IS_SUSPENDED, SID";
            gascmdTxt += @" ) Values (";
            gascmdTxt += @" '" + p_ACCOUNT + "'";
            gascmdTxt += @" ,'" + p_NAME + "'";
            gascmdTxt += @" ,'" + p_Email + "'";
            gascmdTxt += @" ,''";
            gascmdTxt += @" ,'0'";

            gascmdTxt += @" ,GETDATE()";
            gascmdTxt += @" ,0";
            gascmdTxt += @" ,'" + p_SID + "')";
            

            l_Dao.ExcuteNonQuery(gascmdTxt);
        }

        //新增員工部門職級
        private void insertTB_EB_EMPL_DEP(string p_userguid, string p_GROUPID, string p_TITLEID)
        {
            string cmdTxt = @"insert into TB_EB_EMPL_DEP (USER_GUID,GROUP_ID,TITLE_ID,ORDERS) Values (";
            cmdTxt += @" '" + p_userguid + "',";
            cmdTxt += @" '" + p_GROUPID + "',";
            cmdTxt += @" '" + p_TITLEID + "','0') ";
            this.m_db.ExecuteNonQuery(cmdTxt);
        }

        //新增員工職務
        private void insertTB_EB_EMPL_FUN(string p_userguid, string p_GROUPID, string p_FUNC_ID)
        {
            string cmdTxt = @"insert into TB_EB_EMPL_FUNC (GROUP_ID,USER_GUID,FUNC_ID) Values (";
            cmdTxt += @" '" + p_GROUPID + "',";
            cmdTxt += @" '" + p_userguid + "',";
            cmdTxt += @" '" + p_FUNC_ID + "') ";
            this.m_db.ExecuteNonQuery(cmdTxt);
        }

        //新增使用者人事
        private void insertTB_EB_EMPL_HR(string p_userguid, string p_MARRIED, string p_MILITARY_SERVICE)
        {
            string cmdTxt = @"insert into TB_EB_EMPL_HR (USER_GUID,MARRIED,FAITH,BLOOD,CONSTELLATION,PERMANENT_ADDR,PERMANENT_ZIP,";
            cmdTxt += @" PERMANENT_PHONE,PRESENT_ADDR,PRESENT_ZIP,PRESENT_PHONE,EMER_CONTACT,EMER_PHONE1,EMER_PHONE2,EMER_MOBILE,";
            cmdTxt += @" PAYROLL_BANK,PAYROLL_ACC,PAYROLL_FILE,JOB_TYPE,IDENTITY_TYPE,IDENTITY_FILE,MILITARY_SERVICE,MILITARY_DUTY,";
            cmdTxt += @" MILITARY_TYPE,MILITARY_RANK,CARD_NO) Values ( ";
            cmdTxt += @" '" + p_userguid + "',";
            cmdTxt += @" '" + p_MARRIED + "','','','','','','','','','','','','','','','','','','','',";
            cmdTxt += @" '" + p_MILITARY_SERVICE + "','','','','') ";
            this.m_db.ExecuteNonQuery(cmdTxt);
        }

        //新增學歷
        private void insertTB_EB_EMPL_HR_EDUACTION(string p_userguid, string p_EDUC_ID, string p_SCHOOL, string p_MAJOR)
        {
            string cmdTxt = @"insert into TB_EB_EMPL_HR_EDUACTION (EDU_GUID,USER_GUID,SCHOOL,MAJOR,""FROM"",""TO"",GRADUATED,LEVEL,";
            cmdTxt += @" NUMBER,FILE_GROUP,HIGHEST) Values (";
            cmdTxt += @" '" + Guid.NewGuid().ToString() + "',";
            cmdTxt += @" '" + p_userguid + "',";
            cmdTxt += @" '" + p_SCHOOL + "',";
            cmdTxt += @" '" + p_MAJOR + "', ";
            cmdTxt += @" '2005-07-01 00:00:00.000','2007-06-30 00:00:00.000','1',";
            cmdTxt += @" '" + p_EDUC_ID + "','','','1')";
            this.m_db.ExecuteNonQuery(cmdTxt);
        }

        //新增員工
        private void insertTB_EB_EMPL(string p_userguid, string p_EDUC_ID, string p_ARRIVE_DATE, string p_BIRTHDAY, string p_SEX)
        {
            string cmdTxt = @"insert into TB_EB_EMPL (USER_GUID,ARRIVE_DATE,BIRTHDAY,EDUC_ID,SEX,FILE_TYPE,MAX_FILE_SIZE";
            cmdTxt += @" ,MSN,QQ,YAHOO,BLOG,SKYPE,MOBILE,EMERGENCY,EXT_NUM,ADDRESS,SIGNATURE,PHOTO) Values (";
            cmdTxt += @" '" + p_userguid + "',";
            cmdTxt += @" '" + p_ARRIVE_DATE + "',";
            cmdTxt += @" '" + p_BIRTHDAY + "', ";
            cmdTxt += @" '" + p_EDUC_ID + "',";
            cmdTxt += @" '" + p_SEX + "','System','0','','','','','','','','','','','')";
            this.m_db.ExecuteNonQuery(cmdTxt);
        }

        //查詢職級id
        public string getTITLEIDbyTITLENAME(string p_TITLENAME)
        {
            DataTable l_dt = new DataTable();
            string cmdTxt = @" select TITLE_ID from TB_EB_JOB_TITLE";
            cmdTxt += @" where TITLE_NAME= '" + p_TITLENAME + "'";

            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            l_dt.Load(dr);   //解析SQL內的資料(可以是DataTable、DataGrid...)
            dr.Dispose();   //切斷與資料庫連線
            List<DataRow> l_list = new List<DataRow>();
            foreach (DataRow row in l_dt.Rows)
            {
                l_list.Add(row);
            }
            string l_str職級id = l_list[0][0].ToString();
            return l_str職級id;
        }

        //查詢職務id
        public string getFUNC_IDbyFUNC_NAME(string p_FUNC_NAME)
        {
            DataTable l_dt = new DataTable();
            string cmdTxt = @" select FUNC_ID from TB_EB_JOB_FUNC";
            cmdTxt += @" where FUNC_NAME= '" + p_FUNC_NAME + "'";

            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            l_dt.Load(dr);   //解析SQL內的資料(可以是DataTable、DataGrid...)
            dr.Dispose();   //切斷與資料庫連線
            List<DataRow> l_list = new List<DataRow>();
            foreach (DataRow row in l_dt.Rows)
            {
                l_list.Add(row);
            }
            string l_str職務id = l_list[0][0].ToString();
            return l_str職務id;
        }

        //查詢學歷id
        public string getEDUC_IDbyEDUC_NAME(string p_EDUC_NAME)
        {
            if (!String.IsNullOrEmpty(p_EDUC_NAME))
            {
                DataTable l_dt = new DataTable();
                string cmdTxt = @" select EDUC_ID from TB_EB_EDUC";
                cmdTxt += @" where EDUC_NAME= '" + p_EDUC_NAME + "'";

                System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
                l_dt.Load(dr);   //解析SQL內的資料(可以是DataTable、DataGrid...)
                dr.Dispose();   //切斷與資料庫連線
                List<DataRow> l_list = new List<DataRow>();
                foreach (DataRow row in l_dt.Rows)
                {
                    l_list.Add(row);
                }
                string l_str學歷id = l_list[0][0].ToString();
                return l_str學歷id;
            }
            else
            {
                return "";
            }
            
        }

        //查詢USER_GUID
        public string getUSER_GUIDbyACCOUNT(string p_ACCOUNT)
        {
            DataTable l_dt = new DataTable();
            string cmdTxt = @" select USER_GUID from TB_EB_USER";
            cmdTxt += @" where ACCOUNT= '" + p_ACCOUNT + "'";

            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            l_dt.Load(dr);   //解析SQL內的資料(可以是DataTable、DataGrid...)
            dr.Dispose();   //切斷與資料庫連線
            if (l_dt.Rows.Count > 0)
            {
                List<DataRow> l_list = new List<DataRow>();
                foreach (DataRow row in l_dt.Rows)
                {
                    l_list.Add(row);
                }

                string l_USER_GUID = l_list[0][0].ToString();
                return l_USER_GUID;
            }
            return "";
        }
    }
}
