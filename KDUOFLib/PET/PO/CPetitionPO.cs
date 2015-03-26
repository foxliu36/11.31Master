using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace KDUOFLib.PET.PO
{
    public class CPetitionPO : Fast.EB.Utility.Data.BasePersistentObject
    {
        PETDataSetTableAdapters.TableAdapterManager _myTAM;

        public CPetitionPO()
        {
            _myTAM = new PETDataSetTableAdapters.TableAdapterManager();
            _myTAM.BackupDataSetBeforeUpdate = false;
            _myTAM.UpdateOrder = PETDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            //加入Table Adapter
            _myTAM.TB_PET_PETITIONTableAdapter = new PETDataSetTableAdapters.TB_PET_PETITIONTableAdapter();
            _myTAM.TB_PET_PETITIONTableAdapter.Connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;

        }
        //public void QueryDatas(string No,DataTable dt)
        //{
        //    //string cmdTxt = @"select * from TB_PET_PETITION where ORDERNO = @ORDERNO";

        //    string cmdTxt = @"select p.*,cm.CAR_PRICE,o.CarMdl,o.EngNo ";
        //    cmdTxt += @" from TB_PET_PETITION p";
        //    cmdTxt += @" inner join TB_KD_ORDERS o on o.OrderNo = p.ORDERNO";
        //    cmdTxt += @" inner join TB_REW_CARMODEL cm on cm.CAR_CODE = o.CarCod and cm.CAR_MDL = o.CarMdl and cm.CAR_SFX = o.SFX";
        //    cmdTxt += @" where p.ORDERNO = @ORDERNO";
        //    this.m_db.AddParameter("@ORDERNO", No);
        //    dt.Load(this.m_db.ExecuteReader(cmdTxt));
        //}
        public void QueryDatas(string No, DataTable dt)
        {
            //string cmdTxt = @"select * from TB_PET_PETITION where ORDERNO = @ORDERNO";

            string cmdTxt = @"select *";
            cmdTxt += @" from TB_PET_PETITION p";
            cmdTxt += @" where ORDERNO = @ORDERNO";
            this.m_db.AddParameter("@ORDERNO", No);
            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
        }
        public void QueryPetitionDatasByWKF(string No, DataTable dt)
        {
            //string cmdTxt = @"select * from TB_PET_PETITION where ORDERNO = @ORDERNO";
            dt = new PETDataSet().TB_PET_PETITION;
            string cmdTxt = @"select p.*";
            cmdTxt += @" from TB_PET_PETITION p";
            cmdTxt += @" inner join TB_KD_ORDERS o on o.OrderNo = p.ORDERNO";
            cmdTxt += @" inner join TB_REW_CARMODEL cm on cm.CAR_CODE = o.CarCod and cm.CAR_MDL = o.CarMdl and cm.CAR_SFX = o.SFX";
            cmdTxt += @" where p.ORDERNO = @ORDERNO";
            this.m_db.AddParameter("@ORDERNO", No);
            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
        }

        public void Update(PETDataSet ds)
        {
            _myTAM.UpdateAll(ds);
        }

        public void UpdateLicenseNo(DataRow row)
        {
            string cmdTxt = @"UPDATE [TB_KD_CAR]";
            cmdTxt += @" SET [LicenseNo] = '" + row["LicenseNo"].ToString() + "'";
            cmdTxt += @" where EngNo = @EngNo";
            this.m_db.AddParameter("@EngNo", row["EngNo"].ToString());
            this.m_db.ExecuteNonQuery(cmdTxt);
        }
        
        public void UpdatePETITIONAfterWKF(DataRow row)
        {
            string cmdTxt = @"UPDATE [TB_PET_PETITION]";
            cmdTxt += @" SET [SMID] = '" + row["SMID"].ToString() + "'";
            cmdTxt += @" ,[PET_TYPE] ='" + row["PET_TYPE"].ToString() + "'";
            cmdTxt += @" ,[COM_NAME] ='" + row["COM_NAME"].ToString() + "'";
            cmdTxt += @" ,[COM_PHONE] ='" + row["COM_PHONE"].ToString() + "'";
            cmdTxt += @" ,[COM_ADD] ='" + row["COM_ADD"].ToString() + "'";
            cmdTxt += @" ,[COM_ID] ='" + row["COM_ID"].ToString() + "'";
            cmdTxt += @" ,[COM_DATE] ='" + row["COM_DATE"].ToString() + "'";
            cmdTxt += @" ,[PEO_NAME] ='" + row["PEO_NAME"].ToString() + "'";
            cmdTxt += @" ,[PEO_SEX] =" + row["PEO_SEX"].ToString();
            cmdTxt += @" ,[PEO_ID] ='" + row["PEO_ID"].ToString() + "'";
            cmdTxt += @" ,[PEO_MERRY] =" + row["PEO_MERRY"].ToString();
            cmdTxt += @" ,[PEO_PHONE] ='" + row["PEO_PHONE"].ToString() + "'";
            cmdTxt += @" ,[PEO_MOBILE] ='" + row["PEO_MOBILE"].ToString() + "'";
            cmdTxt += @" ,[PEO_BIRTHDAY] ='" + row["PEO_BIRTHDAY"].ToString() + "'";
            cmdTxt += @"  ,[PEO_ADD] ='" + row["PEO_ADD"].ToString() + "'";
            cmdTxt += @" ,[PEO_REPORT_ADD] ='" + row["PEO_REPORT_ADD"].ToString() + "'";
            cmdTxt += @"  ,[SER_NAME] ='" + row["SER_NAME"].ToString() + "'";
            cmdTxt += @" ,[SER_ADD] ='" + row["SER_ADD"].ToString() + "'";
            cmdTxt += @"  ,[SER_YEAR] =" + row["SER_YEAR"].ToString();
            cmdTxt += @"  ,[SER_JOB] ='" + row["SER_JOB"].ToString() + "'";
            cmdTxt += @"  ,[SER_PHONE] ='" + row["SER_PHONE"].ToString() + "'";
            cmdTxt += @" ,[HOUSE_ADD] ='" + row["HOUSE_ADD"].ToString() + "'";
            cmdTxt += @" ,[HOUSE_NUM] ='" + row["HOUSE_NUM"].ToString() + "'";
            cmdTxt += @" ,[HOUSE_BUILD] ='" + row["HOUSE_BUILD"].ToString() + "'";
            cmdTxt += @" ,[HOUSE_NAME] ='" + row["HOUSE_NAME"].ToString() + "'";
            cmdTxt += @" ,[HOUSE_ID] ='" + row["HOUSE_ID"].ToString() + "'";
            cmdTxt += @" ,[CREDIT_MONEY] =" + row["CREDIT_MONEY"].ToString();
            cmdTxt += @" ,[CREDIT_PHASES] =" + row["CREDIT_PHASES"].ToString();
            cmdTxt += @" ,[MONTH_MONEY] =" + row["MONTH_MONEY"].ToString();
            cmdTxt += @" ,[SUBSIDIES_MONEY] =" + row["SUBSIDIES_MONEY"].ToString();
            cmdTxt += @" ,[PET_RATE] =" + row["PET_RATE"].ToString();
            cmdTxt += @" ,[PET_SEVERAL] =" + row["PET_SEVERAL"].ToString() ;
            cmdTxt += @" ,[PET_MONEY] =" + row["PET_MONEY"].ToString();
            cmdTxt += @" ,[PET_SUBSIDIES] =" + row["PET_SUBSIDIES"].ToString();
            cmdTxt += @" ,[PAY_TYPE] =" + row["PAY_TYPE"].ToString();
            cmdTxt += @" ,[CAR_REASON] =" + row["CAR_REASON"].ToString();
            cmdTxt += @" ,[CAR_USER] =" + row["CAR_USER"].ToString();
            cmdTxt += @" ,[PET_RESULT] ='" + row["PET_RESULT"].ToString() + "'";
            cmdTxt += @"   ,[TASK_ID] ='" + row["TASK_ID"].ToString() + "'";
            cmdTxt += @"   ,[DOC_NBR] ='" + row["DOC_NBR"].ToString() + "'";
            cmdTxt += @" ,[TASK_RESULT] ='" + row["TASK_RESULT"].ToString() + "'";
            cmdTxt += @" where ORDERNO = @ORDERNO";
            this.m_db.AddParameter("@ORDERNO", row["ORDERNO"].ToString());
            this.m_db.ExecuteNonQuery(cmdTxt);
        }

        public void UpdatePETITIONByUrge(DataRow row)
        {
            string cmdTxt = @"UPDATE [TB_PET_PETITION]";
            cmdTxt += @" SET [TELVIEW] = '" + row["TELVIEW"].ToString() + "'";
            cmdTxt += @" ,[TRACK] ='" + row["TRACK"].ToString() + "'";
            cmdTxt += @" ,[LicenseBack] ='" + row["LicenseBack"].ToString() + "'";
            cmdTxt += @" ,[LicenseBackDate] ='" + row["LicenseBackDate"].ToString() + "'";
            cmdTxt += @" where ORDERNO = @ORDERNO";
            this.m_db.AddParameter("@ORDERNO", row["ORDERNO"].ToString());
            this.m_db.ExecuteNonQuery(cmdTxt);
        }

        public DataTable QueryBranchDatas()
        {
            DataTable dt = new DataTable();
            string cmdTxt = "select GROUP_ID,GROUP_NAME";
            cmdTxt += " from TB_EB_GROUP";
            cmdTxt += " where PARENT_GROUP_ID in( '082b8623-6e17-f256-eae4-aa482f3dd91a','5c24f715-5f11-3e03-53e2-9fc3e8b38799')";
            cmdTxt += " order by GROUP_NAME";
            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
            return dt;
        }

        public DataTable QueryDatasByConditions(string txtORDERNO, string txtName, string ddlRESULT, string txtNO, string txtID, string userid)
        {
            DataTable dt = new DataTable();
            string cmdTxt = @"select p.TASK_ID, p.ORDERNO, STR(p.CREDIT_MONEY) + '/' + STR(p.CREDIT_PHASES) + '/' + STR(p.PET_RATE,10,2) as PET,";
            cmdTxt += @" p.CREATE_DATE, c.LicenseNo, p.PEO_NAME, pc.COM_NAME,";
            cmdTxt += @" TASK_RESULT = IsNull((case";
            cmdTxt += @" when (isnull(p.TASK_RESULT,'9')= '0' ) then '通過'";
            cmdTxt += @" when (isnull(p.TASK_RESULT,'9')= '1' ) then '否決'";
            cmdTxt += @" when (isnull(p.TASK_RESULT,'9')= '2' ) then '作廢'";
            cmdTxt += @" when (isnull(p.TASK_RESULT,'9')= '9' ) then '未結案'";
            cmdTxt += @" end),0)";
            cmdTxt += @" from TB_PET_PETITION as p ";
            //cmdTxt += @" inner join TB_PET_PETCOM pc on pc.COM_ID = p.PET_COM";
            //cmdTxt += @" inner join TB_KD_ORDERS o on o.OrderNo = p.ORDERNO";
            //cmdTxt += @" inner join TB_KD_CAR c on c.EngNo = o.EngNo";
            cmdTxt += @" left join TB_PET_PETCOM pc on pc.COM_ID = p.PET_COM";
            cmdTxt += @" inner join TB_KD_ORDERS o on o.OrderNo = p.ORDERNO";
            cmdTxt += @" left join TB_KD_CAR c on c.EngNo = o.EngNo";
            cmdTxt += @" where p.SMID = '" + userid + "'";
            string conditionStr = "";
            if (!string.IsNullOrEmpty(txtORDERNO))
            {
                conditionStr += " And p.ORDERNO = @ORDERNO";
                this.m_db.AddParameter("@ORDERNO", txtORDERNO);
            }
            if (!string.IsNullOrEmpty(txtName))//車主姓名
            {
                conditionStr += " And p.PEO_NAME like @Name + '%'";
                this.m_db.AddParameter("@Name", txtName);
            }
            if (!string.IsNullOrEmpty(ddlRESULT))//狀態
            {
                if (ddlRESULT.Equals("0"))
                    conditionStr += " And p.TASK_RESULT = null";
                if (ddlRESULT.Equals("1"))
                    conditionStr += " And p.TASK_RESULT = 0";
            }
            if (!string.IsNullOrEmpty(txtNO))//車牌
            {
                conditionStr += " And c.LicenseNo = @NO";
                this.m_db.AddParameter("@NO", txtNO);
            }
            if (!string.IsNullOrEmpty(txtID))//車主身分證
            {
                conditionStr += " And p.PEO_ID = @ID";
                this.m_db.AddParameter("@ID", txtID.ToUpper());
            }
            if (conditionStr.Length > 0)
                cmdTxt += conditionStr;

            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
            return dt;
        }

        #region Print
        public void QueryDatasByPetPrint(string orderno, DataTable dt)
        {
            string cmdTxt = @"select o.TotalPrice,o.CarMdl,c.EngNo,p.ORDERNO,p.SMID,p.PET_TYPE,p.COM_NAME,p.COM_PHONE,";
            cmdTxt += @" p.COM_ADD,p.COM_ID,p.COM_DATE,p.PEO_NAME,p.PEO_ID,p.PEO_PHONE,p.PEO_MOBILE,";
            cmdTxt += @" p.PEO_BIRTHDAY,p.PEO_ADD,p.PEO_REPORT_ADD,p.SER_NAME,p.SER_ADD,p.SER_YEAR,p.SER_JOB,";
            cmdTxt += @" p.SER_PHONE,p.HOUSE_ADD,p.HOUSE_NUM,p.HOUSE_BUILD,p.HOUSE_NAME,";
            cmdTxt += @" p.HOUSE_ID,p.CREDIT_MONEY,p.CREDIT_PHASES,p.MONTH_MONEY,p.SUBSIDIES_MONEY,p.PET_RATE,";
            cmdTxt += @" p.PET_SEVERAL,p.PET_MONEY,p.PET_SUBSIDIES,p.PET_RESULT,p.CREATE_DATE,";

            cmdTxt += @" PEO_SEX = (case";
            cmdTxt += @" when (isnull(p.PEO_SEX,'')= '0' ) then '女'";
            cmdTxt += @" when (isnull(p.PEO_SEX,'')= '1' ) then '男'";
            cmdTxt += @" end),";

            cmdTxt += @" PEO_MERRY = (case";
            cmdTxt += @" when (isnull(p.PEO_MERRY,'')= '0' ) then '未婚'";
            cmdTxt += @" when (isnull(p.PEO_MERRY,'')= '1' ) then '已婚'";
            cmdTxt += @" end),";

            cmdTxt += @" PAY_TYPE = (case";
            cmdTxt += @" when (isnull(p.PAY_TYPE,'')= '0' ) then '支票'";
            cmdTxt += @" when (isnull(p.PAY_TYPE,'')= '1' ) then '劃撥單'";
            cmdTxt += @" when (isnull(p.PAY_TYPE,'')= '2' ) then '超商繳款'";
            cmdTxt += @" when (isnull(p.PAY_TYPE,'')= '3' ) then 'ACH'";
            cmdTxt += @" end),";

            cmdTxt += @" CAR_REASON = (case";
            cmdTxt += @" when (isnull(p.CAR_REASON,'')= '0' ) then '新購'";
            cmdTxt += @" when (isnull(p.CAR_REASON,'')= '1' ) then '換車'";
            cmdTxt += @" when (isnull(p.CAR_REASON,'')= '2' ) then '添購'";
            cmdTxt += @" end),";

            cmdTxt += @" CAR_USER = (case";
            cmdTxt += @" when (isnull(p.CAR_USER,'')= '0' ) then '車主'";
            cmdTxt += @" when (isnull(p.CAR_USER,'')= '1' ) then '保人'";
            cmdTxt += @" when (isnull(p.CAR_USER,'')= '2' ) then '公務車'";
            cmdTxt += @" when (isnull(p.CAR_USER,'')= '3' ) then '其他'";
            cmdTxt += @" end),o.BranchId,u.NAME,e.MOBILE,p.TYPE,g.GROUP_NAME";
            cmdTxt += @" from TB_PET_PETITION p";
            cmdTxt += @" inner join TB_KD_ORDERS o on o.OrderNo = p.ORDERNO";
            cmdTxt += @" left join TB_KD_CAR c on c.EngNo = o.EngNo";
            cmdTxt += @" inner join TB_EB_USER u on u.ACCOUNT = p.SMID";
            cmdTxt += @" inner join TB_EB_EMPL e on e.USER_GUID = u.USER_GUID";
            cmdTxt += @" inner join TB_EB_EMPL_DEP ed on ed.USER_GUID = u.USER_GUID";
            cmdTxt += @" inner join TB_EB_GROUP g on g.GROUP_ID = ed.GROUP_ID";
            cmdTxt += @" where p.ORDERNO ='" + orderno + "'";
            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
        }
        public void QueryDatasByNumPrint(string num, DataTable dt)
        {
            string cmdTxt = @"select o.oadcd,p.PEO_REPORT_ADD,p.PEO_NAME,c.LicenseNo,p.KD_NUM";
            cmdTxt += @" from TB_PET_PETITION p";
            cmdTxt += @" inner join TB_KD_ORDERS o on p.ORDERNO = o.OrderNo";
            cmdTxt += @" inner join TB_KD_CAR c on o.EngNo = c.EngNo";
            cmdTxt += @" where KD_NUM like '" + num + "%'";
            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
        }
        public void QueryDatasByClosePrint(string num, string nums, DataTable dt)
        {
            string cmdTxt = @"select p.KD_NUM,p.PEO_NAME,c.CarCod,p.CAR_TYPE,c.LicenseNo,c.EngNo,s.NAME";
            cmdTxt += @" from TB_PET_PETITION p";
            cmdTxt += @" inner join TB_KD_ORDERS o on p.ORDERNO = o.OrderNo";
            cmdTxt += @" inner join TB_KD_CAR c on o.EngNo = c.EngNo";
            cmdTxt += @" inner join TB_PET_SUPERVISE s on s.ID = p.PET_SUPID";
            cmdTxt += @" where CLOSE_TYPE in(0,1)";
            if (!"".Equals(num))
            {
                cmdTxt += @" and KD_NUM = '" + num + "'";
            }
            if (!"".Equals(nums))
            {
                cmdTxt += @" and KD_NUM like '" + num + "%'";
            }

            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
        }


        public void QueryDatasByPETCOMPrint(DateTime BDate, DateTime EDate, DataTable dt)
        {
            string cmdTxt = @"select ";
            //高都和潤
            cmdTxt += @" KDHZ = IsNull(sum(case ";
            cmdTxt += @" when (isnull(p.PET_COM,'')= 'HZ' )  ";
            cmdTxt += @" and g.GROUP_NAME not in ('F52民族一課','F53建國營業所') then 1.0";
            cmdTxt += @" end),0),";
            //高都
            cmdTxt += @" KDKD = IsNull(sum(case ";
            cmdTxt += @" when (isnull(p.PET_COM,'')= 'KD' )";
            cmdTxt += @" and g.GROUP_NAME not in ('F52民族一課','F53建國營業所') then 1.0";
            cmdTxt += @" end),0),";
            //高都台壽保
            cmdTxt += @" KDTSP = IsNull(sum(case ";
            cmdTxt += @" when (isnull(p.PET_COM,'')= 'TSP' )";
            cmdTxt += @" and g.GROUP_NAME not in ('F52民族一課','F53建國營業所') then 1.0";
            cmdTxt += @" end),0),";
            //高都台新
            cmdTxt += @" KDTS = IsNull(sum(case";
            cmdTxt += @" when (isnull(p.PET_COM,'')= 'TS' ) ";
            cmdTxt += @" and g.GROUP_NAME not in ('F52民族一課','F53建國營業所') then 1.0";
            cmdTxt += @" end),0),";
            //LEXUS和潤
            cmdTxt += @" LSHZ = IsNull(sum(case ";
            cmdTxt += @" when (isnull(p.PET_COM,'')= 'HZ' )  ";
            cmdTxt += @" and g.GROUP_NAME in ('F52民族一課','F53建國營業所') then 1.0";
            cmdTxt += @" end),0),";
            //LEXUS高都
            cmdTxt += @" LSKD = IsNull(sum(case";
            cmdTxt += @" when (isnull(p.PET_COM,'')= 'KD' ) ";
            cmdTxt += @" and g.GROUP_NAME in ('F52民族一課','F53建國營業所') then 1.0";
            cmdTxt += @" end),0),";
            //LEXUS台壽保
            cmdTxt += @" LSTSP = IsNull(sum(case ";
            cmdTxt += @" when (isnull(p.PET_COM,'')= 'TSP' )";
            cmdTxt += @" and g.GROUP_NAME in ('F52民族一課','F53建國營業所') then 1.0";
            cmdTxt += @" end),0),";
            //LEXUS台新
            cmdTxt += @" LSTS = IsNull(sum(case";
            cmdTxt += @" when (isnull(p.PET_COM,'')= 'TS' ) ";
            cmdTxt += @" and g.GROUP_NAME in ('F52民族一課','F53建國營業所') then 1.0";
            cmdTxt += @" end),0)";

            cmdTxt += @" from TB_PET_PETITION p";
            cmdTxt += @" inner join TB_PET_PETCOM pc on pc.COM_ID = p.PET_COM";
            cmdTxt += @" left join TB_EB_USER u on u.ACCOUNT = p.SMID";
            cmdTxt += @" left join TB_EB_EMPL_DEP d on d.USER_GUID = u.USER_GUID";
            cmdTxt += @" left join TB_EB_GROUP g on g.GROUP_ID = d.GROUP_ID";
            //簽核通過才算
            cmdTxt += @" where p.TASK_RESULT = 0";
            if (!"".Equals(BDate))
            {
                cmdTxt += @" and p.CREATE_DATE between '" + BDate + "' and '" + EDate + "'";
            }

            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
        }


        public void QueryDatasByDifferentPrint(string BDate, string EDate, DataTable dt)
        {
            string cmdTxt = @"select g.GROUP_NAME,NUM = count(p.ORDERNO)";
            cmdTxt += @" from TB_PET_PETITION p";
            cmdTxt += @" inner join TB_EB_USER u on u.ACCOUNT = p.SMID";
            cmdTxt += @" inner join TB_EB_EMPL_DEP e on e.USER_GUID = u.USER_GUID";
            cmdTxt += @" inner join TB_EB_GROUP g on g.GROUP_ID = e.GROUP_ID";
            cmdTxt += @" where p.TASK_RESULT = 0";
            if (!"".Equals(BDate))
            {
                cmdTxt += @" and p.CREATE_DATE between '" + BDate + "' and '" + EDate + "'";
            }
            cmdTxt += @" group by g.GROUP_NAME";

            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
        }

        public void QueryDatasByPETA3Print(string orderno, DataTable dt)
        {
            string cmdTxt = @"select p.ORDERNO,p.COM_ID,p.COM_NAME,p.COM_ADD,p.PEO_NAME,o.CarCod,p.CAR_TYPE,c.LicenseNo,o.EngNo,o.CarMdl,c.MadeDay,p.PEO_ADD,p.PEO_ID,p.CREDIT_MONEY,s.NAME,p.CAR_TYPE,p.PEO_BIRTHDAY,p.PET_RATE,p.PET_MONEY";
            cmdTxt += @" from TB_PET_PETITION p";
            cmdTxt += @" inner join TB_KD_ORDERS o on p.ORDERNO = o.OrderNo";
            cmdTxt += @" left join TB_KD_CAR c on o.EngNo = c.EngNo";
            cmdTxt += @" inner join TB_PET_SUPERVISE s on s.ID = p.PET_SUPID";
            cmdTxt += @" where p.TASK_RESULT = 0";
            if (!"".Equals(orderno))
            {
                cmdTxt += @" and p.ORDERNO = '" + orderno + "'";
            }

            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
        }

        public void QueryDatasByCHARTERA3Print(string orderno, DataTable dt)
        {
            string cmdTxt = @"select p.ORDERNO,p.KD_NUM,p.COM_ID,p.COM_NAME,p.PEO_PHONE,p.COM_ADD,p.COM_PHONE,p.PEO_NAME,o.CarCod,p.CAR_TYPE,c.LicenseNo,o.EngNo,o.CarMdl,c.MadeDay,p.PEO_ADD,p.PEO_ID";
            cmdTxt += @" ,p.CREDIT_MONEY,s.NAME,p.CAR_TYPE,p.PET_RATE,p.CREDIT_MONEY,p.CREDIT_PHASES,sp.SPO_NAME,sp.SPO_SER_PHONE,sp.SPO_ADD,o.TotalPrice,p.PET_SUBSIDIES,p.MONTH_MONEY";
            cmdTxt += @" from TB_PET_PETITION p";
            cmdTxt += @" inner join TB_KD_ORDERS o on p.ORDERNO = o.OrderNo";
            cmdTxt += @" left join TB_KD_CAR c on o.EngNo = c.EngNo";
            cmdTxt += @" inner join TB_PET_SUPERVISE s on s.ID = p.PET_SUPID";
            cmdTxt += @" inner join TB_PET_SPONSOR sp on sp.ORDERNO = p.ORDERNO";
            cmdTxt += @" where p.TASK_RESULT = 0";
            if (!"".Equals(orderno))
            {
                cmdTxt += @" and p.ORDERNO = '" + orderno + "'";
            }

            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
        }
        #endregion
        public void CDS_PET_PetByManager_FrmDynamicInsurance(DateTime SDATE, DateTime EDATE, string ORDERNO,
            string Name, string PET_COM, string NO, string ID, string STATUS, DataTable dt)
        {
            string cmdTxt = @"select p.*,c.LicenseNo,u.NAME,o.EngNo ";
            cmdTxt += @" from TB_PET_PETITION as p ";
            cmdTxt += @" left join TB_PET_PETCOM pc on pc.COM_ID = p.PET_COM";
            cmdTxt += @" inner join TB_KD_ORDERS o on o.OrderNo = p.ORDERNO";
            cmdTxt += @" left join TB_KD_CAR c on c.EngNo = o.EngNo";
            cmdTxt += @" inner join TB_EB_USER u on u.ACCOUNT = p.SMID";
            cmdTxt += @" where isnull(TASK_ID,'') <> '' and isnull(TASK_RESULT,9) = 0";
            if (SDATE != null && EDATE != null)
            {
                cmdTxt += " And p.CREATE_DATE Between @SDATE And @EDATE";
                this.m_db.AddParameter("@SDATE", SDATE.ToString("yyyy/MM/dd") + " 00:00:00");
                this.m_db.AddParameter("@EDATE", EDATE.ToString("yyyy/MM/dd") + " 23:59:59");
            }
            if (!string.IsNullOrEmpty(ORDERNO))
            {
                cmdTxt += " And p.ORDERNO = @ORDERNO";
                this.m_db.AddParameter("@ORDERNO", ORDERNO);
            }
            if (!string.IsNullOrEmpty(Name))//車主姓名
            {
                cmdTxt += " And p.PEO_NAME like @Name + '%'";
                this.m_db.AddParameter("@Name", Name);
            }
            if (!string.IsNullOrEmpty(PET_COM))
            {
                cmdTxt += " And PET_COM = @PET_COM";
                this.m_db.AddParameter("@PET_COM", PET_COM);
            }
            if (!string.IsNullOrEmpty(NO))//車牌
            {
                cmdTxt += " And c.LicenseNo = @NO";
                this.m_db.AddParameter("@NO", NO);
            }
            if (!string.IsNullOrEmpty(ID))//車主身分證
            {
                cmdTxt += " And p.PEO_ID = @ID";
                this.m_db.AddParameter("@ID", ID);
            }
            if (!string.IsNullOrEmpty(STATUS))
            {
                cmdTxt += " And p.STATUS = @STATUS";
                this.m_db.AddParameter("@STATUS", STATUS);
            }
            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
        }

        public void QueryDatas(DateTime SDATE, DateTime EDATE, string ORDERNO,
            string Name, string PET_COM, string NO, string ID, string STATUS, DataTable dt)
        {
            string cmdTxt = @"select p.* ";
            cmdTxt += @" from TB_PET_PETITION as p ";
            cmdTxt += @" left join TB_PET_PETCOM pc on pc.COM_ID = p.PET_COM";
            cmdTxt += @" inner join TB_KD_ORDERS o on o.OrderNo = p.ORDERNO";
            cmdTxt += @" left join TB_KD_CAR c on c.EngNo = o.EngNo";
            cmdTxt += @" where isnull(TASK_ID,'') <> '' and isnull(TASK_RESULT,9) = 0";
            if (SDATE != null && EDATE != null)
            {
                cmdTxt += " And p.CREATE_DATE Between @SDATE And @EDATE";
                this.m_db.AddParameter("@SDATE", SDATE.ToString("yyyy/MM/dd") + " 00:00:00");
                this.m_db.AddParameter("@EDATE", EDATE.ToString("yyyy/MM/dd") + " 23:59:59");
            }
            if (!string.IsNullOrEmpty(ORDERNO))
            {
                cmdTxt += " And p.ORDERNO = @ORDERNO";
                this.m_db.AddParameter("@ORDERNO", ORDERNO);
            }
            if (!string.IsNullOrEmpty(Name))//車主姓名
            {
                cmdTxt += " And p.PEO_NAME like @Name + '%'";
                this.m_db.AddParameter("@Name", Name);
            }
            if (!string.IsNullOrEmpty(PET_COM))
            {
                cmdTxt += " And PET_COM = @PET_COM";
                this.m_db.AddParameter("@PET_COM", PET_COM);
            }
            if (!string.IsNullOrEmpty(NO))//車牌
            {
                cmdTxt += " And c.LicenseNo = @NO";
                this.m_db.AddParameter("@NO", NO);
            }
            if (!string.IsNullOrEmpty(ID))//車主身分證
            {
                cmdTxt += " And p.PEO_ID = @ID";
                this.m_db.AddParameter("@ID", ID);
            }
            if (!string.IsNullOrEmpty(STATUS))
            {
                cmdTxt += " And p.STATUS = @STATUS";
                this.m_db.AddParameter("@STATUS", STATUS);
            }
            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
        }
        /// <summary>
        /// CDS_PET_Account_FrmFINANCE
        /// </summary>
        /// <param name="所別"></param>
        /// <param name="ORDERNO"></param>
        /// <param name="Name"></param>
        /// <param name="STATUS"></param>
        public DataTable QueryDatas(string branchid, string ORDERNO, string Name, string STATUS)
        {
            DataTable dt = new DataTable();
            //string cmdTxt = @"select * from (select distinct p.ORDERNO, p.SMID, p.PEO_NAME, p.MONTH_MONEY, p.CREDIT_PHASES, p.CREDIT_MONEY, p.PET_RATE, f.STATUS from TB_PET_PETITION p  LEFT OUTER join TB_PET_FINANCE f on f.ORDERNO = p.ORDERNO  where p.TASK_ID <> '' and p.TASK_ID is not null ) as DT ";
            string cmdTxt = @"select * from ";
            cmdTxt += @" (";
            cmdTxt += @" select distinct p.ORDERNO, p.SMID, p.PEO_NAME, p.MONTH_MONEY, p.CREDIT_PHASES, ";
            cmdTxt += @" p.CREDIT_MONEY, p.PET_RATE, f.STATUS ,o.BranchId";
            cmdTxt += @" from TB_PET_PETITION p";
            cmdTxt += @" LEFT OUTER join TB_PET_FINANCE f on f.ORDERNO = p.ORDERNO";
            cmdTxt += @" inner join TB_KD_ORDERS o on o.OrderNo = p.ORDERNO";
            cmdTxt += @" where p.TASK_ID <> '' and p.TASK_ID is not null";
            cmdTxt += @" ) as DT";
            string conditionStr = "";

            if (!string.IsNullOrEmpty(branchid))
            {
                conditionStr += " And BranchId = @branchid";//所別
                this.m_db.AddParameter("@branchid", branchid);
            }
            if (!string.IsNullOrEmpty(ORDERNO))
            {
                conditionStr += " And ORDERNO = @ORDERNO";
                this.m_db.AddParameter("@ORDERNO", ORDERNO);
            }
            if (!string.IsNullOrEmpty(Name))//車主姓名
            {
                conditionStr += " And PEO_NAME = @Name";
                this.m_db.AddParameter("@Name", Name);
            }
            if (!string.IsNullOrEmpty(STATUS))//狀態
            {
                if (STATUS.Equals("已設定"))
                    conditionStr += " And STATUS is null";
                else if (STATUS.Equals("未設定"))
                    conditionStr += " And STATUS is not null";
            }
            if (conditionStr.Length > 0)
                cmdTxt += " Where " + conditionStr.Substring(4);
            dt.Load(this.m_db.ExecuteReader(cmdTxt));
            return dt;
        }
        public void Update(string ORDERNO, DateTime PET_BDATE, DateTime PET_EDATE)
        {
            string cmdTxt = @"update TB_PET_PETITION set PET_BDATE=@PET_BDATE, PET_EDATE=@PET_EDATE where ORDERNO = @ORDERNO";
            this.m_db.AddParameter("@ORDERNO", ORDERNO);
            this.m_db.AddParameter("@PET_BDATE", PET_BDATE);
            this.m_db.AddParameter("@PET_EDATE", PET_EDATE);
            this.m_db.ExecuteNonQuery(cmdTxt);
        }
        public void UpdateMonthMoney(string ORDERNO, double monthmoney)
        {
            string cmdTxt = @"update TB_PET_PETITION set MONTH_MONEY=@MONTH_MONEY where ORDERNO = @ORDERNO";
            this.m_db.AddParameter("@ORDERNO", ORDERNO);
            this.m_db.AddParameter("@MONTH_MONEY", monthmoney);
            this.m_db.ExecuteNonQuery(cmdTxt);
        }
        
        public void QueryDatasByConditions(string ORDERNO, string Name, string NO, string ID, int CLOSE_TYPE, DataTable dt)
        {
            string cmdTxt = @"select * from TB_PET_PETITION ";
            string conditionStr = " where TASK_ID <> '' and TASK_ID is not null ";

            if (!string.IsNullOrEmpty(ORDERNO))
            {
                conditionStr += " And ORDERNO = @ORDERNO";
                this.m_db.AddParameter("@ORDERNO", ORDERNO);
            }
            if (CLOSE_TYPE != -1)
            {
                conditionStr += " And CLOSE_TYPE = @CLOSE_TYPE";
                this.m_db.AddParameter("@CLOSE_TYPE", CLOSE_TYPE);
            }
            if (!string.IsNullOrEmpty(Name))//車主姓名
            {
                conditionStr += " And 車主姓名 = @Name";
                this.m_db.AddParameter("@Name", Name);
            }
            if (!string.IsNullOrEmpty(NO))//車牌
            {
                conditionStr += " And 車牌 = @NO";
                this.m_db.AddParameter("@NO", NO);
            }
            if (!string.IsNullOrEmpty(ID))//車主身分證
            {
                conditionStr += " And 車主身分證 = @ID";
                this.m_db.AddParameter("@ID", ID);
            }
            if (conditionStr.Length > 0)
                cmdTxt += conditionStr;
            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
        }
        public void QueryDatasByConditions(string ORDERNO, DataTable dt)
        {
            string cmdTxt = @"select * from TB_PET_PETITION ";
            string conditionStr = " where TASK_ID <> '' and TASK_ID is not null ";

            if (!string.IsNullOrEmpty(ORDERNO))
            {
                conditionStr += " And ORDERNO = @ORDERNO";
                this.m_db.AddParameter("@ORDERNO", ORDERNO);
            }
            if (conditionStr.Length > 0)
                cmdTxt += conditionStr;
            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
        }

        public void getDatasByUrge(string ORDERNO, string NO, DataTable dt)
        {
            string cmdTxt = @"select p.*,c.LicenseNo,u.NAME,o.EngNo";
            cmdTxt += @" from TB_PET_PETITION p";
            cmdTxt += @" inner join TB_KD_ORDERS o on o.OrderNo = p.ORDERNO";
            cmdTxt += @" left join TB_KD_CAR c on c.EngNo = o.EngNo";
            cmdTxt += @" inner join TB_EB_USER u on u.ACCOUNT = p.SMID";
            cmdTxt += @" where 1=1";
            if (!"".Equals(ORDERNO))
            {
                cmdTxt += @" and o.OrderNo = '" + ORDERNO + "'";
            }
            if (!"".Equals(NO))
            {
                cmdTxt += @" and c.LicenseNo = '" + NO + "'";
            }
            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
        }
        
    }
}
