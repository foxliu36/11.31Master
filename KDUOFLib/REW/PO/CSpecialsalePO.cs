using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;

namespace KDUOFLib.REW.PO
{
    public class CSpecialsalePO : Fast.EB.Utility.Data.BasePersistentObject
    {
        REWDataSetTableAdapters.TableAdapterManager _myTAM;
        public CSpecialsalePO()
        {
            _myTAM = new REWDataSetTableAdapters.TableAdapterManager();
            _myTAM.BackupDataSetBeforeUpdate = false;
            _myTAM.UpdateOrder = REWDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            //加入Table Adapter
            _myTAM.TB_REW_SPECIALSALETableAdapter = new REWDataSetTableAdapters.TB_REW_SPECIALSALETableAdapter();
            _myTAM.TB_REW_SPECIALSALETableAdapter.Connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;

        }
        public void QueryDatas(DataTable dt)
        {
            string cmdTxt = @"select * from TB_REW_SPECIALSALE order by CREATE_DATE";
            dt.Load(this.m_db.ExecuteReader(cmdTxt));
        }
        public void QueryDatasByQuery(DataTable dt, string BDate, string EDate, string orderno, string status,string smid)
        {
            string cmdTxt = @" select sp.ORDERNO,o.CustomerId,o.ordpnm,sp.CREATE_DATE,o.CarCod,o.CarMdl,o.yeartype,o.SFX,u.NAME,sp.TASK_ID";
            cmdTxt += @" ,TASK_RESULT = IsNull((case";
            cmdTxt += @" when (isnull(sp.TASK_RESULT,'9')= '0' ) then '同意'";
            cmdTxt += @" when (isnull(sp.TASK_RESULT,'9')= '1' ) then '否決'";
            cmdTxt += @" when (isnull(sp.TASK_RESULT,'9')= '2' ) then '作廢'";
            cmdTxt += @" when (isnull(sp.TASK_RESULT,'9')= '9' ) then '未審核'";
            cmdTxt += @" end),0)";
            cmdTxt += @" from TB_REW_SPECIALSALE sp";
            cmdTxt += @" inner join TB_KD_ORDERS o on sp.ORDERNO = o.OrderNo";
            cmdTxt += @" left join TB_KD_CAR c on c.EngNo = o.EngNo";
            cmdTxt += @" inner join TB_EB_USER u on u.ACCOUNT = sp.CREATOR";
            cmdTxt += @" where u.ACCOUNT = '" + smid + "'";
            if (!"".Equals(BDate))
            {
                cmdTxt += " and sp.CREATE_DATE between '" + BDate + "' and '" + EDate + "'";
            }
            if (!"".Equals(orderno))
            {
                cmdTxt += " and sp.ORDERNO = '" + orderno + "'";
            }
            if (!"".Equals(status))
            {
                cmdTxt += " and isnull(sp.TASK_RESULT,'9') = '" + status + "'";
            }
            cmdTxt += @" order by CREATE_DATE";

            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
        }

        public void QueryDatasByJOBQuery(DataTable dt, string BDate, string EDate, string orderno, string status, string groupid,string smid)
        {
            string cmdTxt = @" select sp.ORDERNO,o.CustomerId,o.ordpnm,sp.CREATE_DATE,o.CarCod,o.CarMdl,o.yeartype,o.SFX,u.NAME,sp.TASK_ID";
            cmdTxt += @" ,TASK_RESULT = IsNull((case";
            cmdTxt += @" when (isnull(sp.TASK_RESULT,'9')= '0' ) then '同意'";
            cmdTxt += @" when (isnull(sp.TASK_RESULT,'9')= '1' ) then '否決'";
            cmdTxt += @" when (isnull(sp.TASK_RESULT,'9')= '2' ) then '作廢'";
            cmdTxt += @" when (isnull(sp.TASK_RESULT,'9')= '9' ) then '未審核'";
            cmdTxt += @" end),0)";
            cmdTxt += @" from TB_REW_SPECIALSALE sp";
            cmdTxt += @" inner join TB_KD_ORDERS o on sp.ORDERNO = o.OrderNo";
            cmdTxt += @" left join TB_KD_CAR c on c.EngNo = o.EngNo";
            cmdTxt += @" inner join TB_EB_USER u on u.ACCOUNT = sp.CREATOR";
            cmdTxt += @" inner join TB_EB_EMPL_DEP d on d.USER_GUID = u.USER_GUID";
            cmdTxt += @" inner join TB_EB_GROUP g on d.GROUP_ID = g.GROUP_ID";
            cmdTxt += @" where g.PARENT_GROUP_ID = '" + groupid + "'";
            if (!"".Equals(BDate))
            {
                cmdTxt += " and o.SaleDay between '" + BDate + "' and '" + EDate + "'";
            }
            if (!"".Equals(orderno))
            {
                cmdTxt += " and sp.ORDERNO = '" + orderno + "'";
            }
            if (!"".Equals(status))
            {
                cmdTxt += " and isnull(sp.TASK_RESULT,'9') = '" + status + "'";
            }
            if (!"".Equals(smid))
            {
                cmdTxt += " and sp.CREATOR = '" + smid + "'";
            }
            cmdTxt += @" order by u.NAME,CREATE_DATE";

            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
        }

        public void QueryDatasByJOBQueryNoDoc(DataTable dt, string BDate, string EDate, string orderno, string status, string groupid, string smid)
        {
            string cmdTxt = @" select sp.ORDERNO,o.CustomerId,o.ordpnm,sp.CREATE_DATE,o.CarCod,o.CarMdl,o.yeartype,o.SFX,u.NAME,sp.TASK_ID";
            cmdTxt += @" ,TASK_RESULT = IsNull((case";
            cmdTxt += @" when (isnull(sp.TASK_RESULT,'9')= '0' ) then '同意'";
            cmdTxt += @" when (isnull(sp.TASK_RESULT,'9')= '1' ) then '否決'";
            cmdTxt += @" when (isnull(sp.TASK_RESULT,'9')= '2' ) then '作廢'";
            cmdTxt += @" when (isnull(sp.TASK_RESULT,'9')= '9' ) then '未審核'";
            cmdTxt += @" end),0)";
            cmdTxt += @" from TB_REW_SPECIALSALE sp";
            cmdTxt += @" inner join TB_KD_ORDERS o on sp.ORDERNO = o.OrderNo";
            cmdTxt += @" left join TB_KD_CAR c on c.EngNo = o.EngNo";
            cmdTxt += @" inner join TB_EB_USER u on u.ACCOUNT = sp.CREATOR";
            cmdTxt += @" inner join TB_EB_EMPL_DEP d on d.USER_GUID = u.USER_GUID";
            cmdTxt += @" inner join TB_EB_GROUP g on d.GROUP_ID = g.GROUP_ID";
            cmdTxt += @" left join TB_REW_SALEDOC s on s.ORDERNO = sp.ORDERNO";
            cmdTxt += @" where g.PARENT_GROUP_ID = '" + groupid + "'";
            cmdTxt += @" and ISNULL(s.ORDERNO,'') = ''";
             
            if (!"".Equals(BDate))
            {
                cmdTxt += " and o.SaleDay between '" + BDate + "' and '" + EDate + "'";
            }
            if (!"".Equals(orderno))
            {
                cmdTxt += " and sp.ORDERNO = '" + orderno + "'";
            }
            if (!"".Equals(status))
            {
                cmdTxt += " and isnull(sp.TASK_RESULT,'9')  = '" + status + "'";
            }
            if (!"".Equals(smid))
            {
                cmdTxt += " and sp.CREATOR = '" + smid + "'";
            }
            cmdTxt += @" order by u.NAME,CREATE_DATE";

            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
        }

        public void QueryDatasByJOBQueryYESDoc(DataTable dt, string BDate, string EDate, string orderno, string status, string groupid, string smid)
        {
            string cmdTxt = @" select sp.ORDERNO,o.CustomerId,o.ordpnm,sp.CREATE_DATE,o.CarCod,o.CarMdl,o.yeartype,o.SFX,u.NAME,sp.TASK_ID";
            cmdTxt += @" ,TASK_RESULT = IsNull((case";
            cmdTxt += @" when (isnull(sp.TASK_RESULT,'9')= '0' ) then '同意'";
            cmdTxt += @" when (isnull(sp.TASK_RESULT,'9')= '1' ) then '否決'";
            cmdTxt += @" when (isnull(sp.TASK_RESULT,'9')= '2' ) then '作廢'";
            cmdTxt += @" when (isnull(sp.TASK_RESULT,'9')= '9' ) then '未審核'";
            cmdTxt += @" end),0)";
            cmdTxt += @" from TB_REW_SPECIALSALE sp";
            cmdTxt += @" inner join TB_KD_ORDERS o on sp.ORDERNO = o.OrderNo";
            cmdTxt += @" left join TB_KD_CAR c on c.EngNo = o.EngNo";
            cmdTxt += @" inner join TB_EB_USER u on u.ACCOUNT = sp.CREATOR";
            cmdTxt += @" inner join TB_EB_EMPL_DEP d on d.USER_GUID = u.USER_GUID";
            cmdTxt += @" inner join TB_EB_GROUP g on d.GROUP_ID = g.GROUP_ID";
            cmdTxt += @" left join TB_REW_SALEDOC s on s.ORDERNO = sp.ORDERNO";
            cmdTxt += @" where g.PARENT_GROUP_ID = '" + groupid + "'";
            cmdTxt += @" and ISNULL(s.ORDERNO,'') <> ''";
             
            if (!"".Equals(BDate))
            {
                cmdTxt += " and o.SaleDay between '" + BDate + "' and '" + EDate + "'";
            }
            if (!"".Equals(orderno))
            {
                cmdTxt += " and sp.ORDERNO = '" + orderno + "'";
            }
            if (!"".Equals(status))
            {
                cmdTxt += " and isnull(sp.TASK_RESULT,'9')  = '" + status + "'";
            }
            if (!"".Equals(smid))
            {
                cmdTxt += " and sp.CREATOR = '" + smid + "'";
            }
            cmdTxt += @" order by u.NAME,CREATE_DATE";

            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
        }

        public void QueryDatasByNTSQuery(DataTable dt, string BDate, string EDate, string orderno, string status, string branchid, string smid, string engo)
        {
            string cmdTxt = @" select o.EngNo,o.CustomerId,o.ordpnm,o.CarCod,o.CarMdl,o.yeartype,o.SFX,u.NAME";
            cmdTxt += @" ,o.BranchId,p.PartID,p.PartName,p.salesprice,sp.MEMO";
            cmdTxt += @" ,SPECIAL_TYPE = IsNull((case";
            cmdTxt += @" when (isnull(sp.SPECIAL_TYPE,'')= '0' ) then '空車'";
            cmdTxt += @" when (isnull(sp.SPECIAL_TYPE,'')= '1' ) then '精裝'";
            cmdTxt += @" end),0),sp.*";
            cmdTxt += @" from TB_REW_SPECIALSALE sp";
            cmdTxt += @" inner join TB_KD_ORDERS o on sp.ORDERNO = o.OrderNo";
            cmdTxt += @" left join TB_KD_CAR c on c.EngNo = o.EngNo";
            cmdTxt += @" inner join TB_EB_USER u on u.ACCOUNT = sp.CREATOR";
            cmdTxt += @" left join TB_REW_PART p on p.ORDERNO = sp.ORDERNO";
            cmdTxt += @" where 1=1";
            if (!"".Equals(BDate))
            {
                cmdTxt += " and o.SaleDay between '" + BDate + "' and '" + EDate + "'";
            }
            if (!"".Equals(orderno))
            {
                cmdTxt += " and sp.ORDERNO = '" + orderno + "'";
            }
            if (!"".Equals(status))
            {
                cmdTxt += " and isnull(sp.TASK_RESULT,'9') = '" + status + "'";
            }
            if (!"".Equals(branchid))
            {
                cmdTxt += " and o.BranchId = '" + branchid + "'";
            }
            if (!"".Equals(smid))
            {
                cmdTxt += " and sp.CREATOR = '" + smid + "'";
            }
            if (!"".Equals(engo))
            {
                cmdTxt += " and o.EngNo = '" + engo + "'";
            }
            cmdTxt += @" order by o.BranchId,u.ACCOUNT";

            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
        }
        public void QueryDatasByAdminQuery(DataTable dt, string BDate, string EDate, string orderno, string status, string branchid, string smid)
        {
            string cmdTxt = @" select sp.ORDERNO,o.CustomerId,o.ordpnm,sp.CREATE_DATE,o.CarCod,o.CarMdl,o.yeartype,o.SFX,u.NAME,sp.TASK_ID";
            cmdTxt += @" ,sp.CREATOR,o.BranchId,TASK_RESULT = IsNull((case";
            cmdTxt += @" when (isnull(sp.TASK_RESULT,'9')= '0' ) then '同意'";
            cmdTxt += @" when (isnull(sp.TASK_RESULT,'9')= '1' ) then '否決'";
            cmdTxt += @" when (isnull(sp.TASK_RESULT,'9')= '2' ) then '作廢'";
            cmdTxt += @" when (isnull(sp.TASK_RESULT,'9')= '9' ) then '處理中'";
            cmdTxt += @" end),0),sp.TASK_ID";
            cmdTxt += @" from TB_REW_SPECIALSALE sp";
            cmdTxt += @" inner join TB_KD_ORDERS o on sp.ORDERNO = o.OrderNo";
            cmdTxt += @" left join TB_KD_CAR c on c.EngNo = o.EngNo";
            cmdTxt += @" inner join TB_EB_USER u on u.ACCOUNT = sp.CREATOR";
            //cmdTxt += @" left join Customer c1 on c1.CustomerID = o.CarOwnerId";
            cmdTxt += @" where 1=1";
            if (!"".Equals(BDate))
            {
                cmdTxt += " and sp.CREATE_DATE between '" + BDate + "' and '" + EDate + "'";
            }
            if (!"".Equals(orderno))
            {
                cmdTxt += " and sp.ORDERNO = '" + orderno + "'";
            }
            if (!"".Equals(status))
            {
                cmdTxt += " and isnull(sp.TASK_RESULT,'9') = '" + status + "'";
            }
            if (!"".Equals(branchid))
            {
                cmdTxt += " and o.BranchId = '" + branchid + "'";
            }
            if (!"".Equals(smid))
            {
                cmdTxt += " and sp.CREATOR = '" + smid + "'";
            }
            cmdTxt += @" order by o.BranchId";

            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
        }

        public void QueryDatasByAdminQuery1(DataTable dt, string BDate, string EDate, string orderno, string status, string branchid, string smid, string insurance, string bigtype, string specialtype, string carcod, string p_supportMoney, string supprottype)
        {
            string cmdTxt = @" select sp.ORDERNO,o.CustomerId,o.ordpnm,sp.CREATE_DATE,o.CarCod,o.CarMdl,o.yeartype,o.SFX,u.NAME,sp.TASK_ID";
            cmdTxt += @" ,sp.CREATOR,o.BranchId,TASK_RESULT = IsNull((case";
            cmdTxt += @" when (isnull(sp.TASK_RESULT,'9')= '0' ) then '同意'";
            cmdTxt += @" when (isnull(sp.TASK_RESULT,'9')= '1' ) then '否決'";
            cmdTxt += @" when (isnull(sp.TASK_RESULT,'9')= '2' ) then '作廢'";
            cmdTxt += @" when (isnull(sp.TASK_RESULT,'9')= '9' ) then '處理中'";
            cmdTxt += @" end),0),sp.TASK_ID,sp.APPLY_NUM,sp.M_APPLY_NUM,o.EngNo,sp.SUPPORT_MONEY,c1.Name as CustomerName";
            cmdTxt += @" ,SUPPORT_TYPE = IsNull((case";
            cmdTxt += @" when (sp.SUPPORT_TYPE <> '2' ) then '准'";
            cmdTxt += @" when (sp.SUPPORT_TYPE = '2') then '不准'";
            cmdTxt += @" when (isnull(sp.SUPPORT_TYPE,'') = '' ) then '未核'";
     
            cmdTxt += @" end),0)";

            cmdTxt += @" from TB_REW_SPECIALSALE sp";
            cmdTxt += @" inner join TB_KD_ORDERS o on sp.ORDERNO = o.OrderNo";
            cmdTxt += @" left join TB_KD_CAR c on c.EngNo = o.EngNo";
            cmdTxt += @" inner join TB_EB_USER u on u.ACCOUNT = sp.CREATOR";
            cmdTxt += @" left join Customer c1 on c1.CustomerID = o.CarOwnerId";
            cmdTxt += @" where 1=1";
            if (!"".Equals(BDate))
            {
                cmdTxt += " and o.SaleDay between '" + BDate + "' and '" + EDate + "'";
            }
            if (!"".Equals(orderno))
            {
                cmdTxt += " and sp.ORDERNO = '" + orderno + "'";
            }
            if (!"".Equals(status))
            {
                cmdTxt += " and isnull(sp.TASK_RESULT,'9') = '" + status + "'";
            }
            if (!"".Equals(branchid))
            {
                cmdTxt += " and o.BranchId = '" + branchid + "'";
            }
            if (!"".Equals(smid))
            {
                cmdTxt += " and sp.CREATOR = '" + smid + "'";
            }
            if (!"".Equals(insurance))
            {
                cmdTxt += " and sp.INSURANCE_TYPE = '" + insurance + "'";
            }
            if (!"".Equals(bigtype))
            {
                cmdTxt += " and sp.BIG_TYPE = '" + bigtype + "'";
            }
            if (!"".Equals(specialtype))
            {
                cmdTxt += " and sp.SPECIAL_TYPE = '" + specialtype + "'";
            }

            if (!"".Equals(carcod))
            {
                cmdTxt += " and o.CarCod = '" + carcod + "'";
            }
            if (!"".Equals(p_supportMoney))
            {
                cmdTxt += " and sp.SUPPORT_MONEY > 1500";
            }
            if (!"".Equals(supprottype))
            {
                if ("2".Equals(supprottype))
                {
                    cmdTxt += " and sp.SUPPORT_TYPE = '2'";
                }
                else
                {
                    cmdTxt += " and sp.SUPPORT_TYPE <> '2'";
                }
            }
            cmdTxt += @" order by o.BranchId";

            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
        }

        public void QueryDatasByAdminQuery1NoDoc(DataTable dt, string BDate, string EDate, string orderno, string status, string branchid, string smid, string insurance, string bigtype, string specialtype, string carcod, string p_supportMoney, string supprottype)
        {
            string cmdTxt = @" select sp.ORDERNO,o.CustomerId,o.ordpnm,sp.CREATE_DATE,o.CarCod,o.CarMdl,o.yeartype,o.SFX,u.NAME,sp.TASK_ID";
            cmdTxt += @" ,sp.CREATOR,o.BranchId,TASK_RESULT = IsNull((case";
            cmdTxt += @" when (isnull(sp.TASK_RESULT,'9')= '0' ) then '同意'";
            cmdTxt += @" when (isnull(sp.TASK_RESULT,'9')= '1' ) then '否決'";
            cmdTxt += @" when (isnull(sp.TASK_RESULT,'9')= '2' ) then '作廢'";
            cmdTxt += @" when (isnull(sp.TASK_RESULT,'9')= '9' ) then '處理中'";
            cmdTxt += @" end),0),sp.TASK_ID,sp.APPLY_NUM,sp.M_APPLY_NUM,o.EngNo,sp.SUPPORT_MONEY,c1.Name as CustomerName";
            cmdTxt += @" ,SUPPORT_TYPE = IsNull((case";
            cmdTxt += @" when (sp.SUPPORT_TYPE <> '2' ) then '准'";
            cmdTxt += @" when (sp.SUPPORT_TYPE = '2') then '不准'";
            cmdTxt += @" when (isnull(sp.SUPPORT_TYPE,'') = '' ) then '未核'";
            cmdTxt += @" end),0)";

            cmdTxt += @" from TB_REW_SPECIALSALE sp";
            cmdTxt += @" inner join TB_KD_ORDERS o on sp.ORDERNO = o.OrderNo";
            cmdTxt += @" left join TB_KD_CAR c on c.EngNo = o.EngNo";
            cmdTxt += @" inner join TB_EB_USER u on u.ACCOUNT = sp.CREATOR";
            cmdTxt += @" left join TB_REW_SALEDOC s on s.ORDERNO = sp.ORDERNO";
            cmdTxt += @" left join Customer c1 on c1.CustomerID = o.CarOwnerId";
            cmdTxt += @" where ISNULL(s.ORDERNO,'') = ''";
            if (!"".Equals(BDate))
            {
                cmdTxt += " and o.SaleDay between '" + BDate + "' and '" + EDate + "'";
            }
            if (!"".Equals(orderno))
            {
                cmdTxt += " and sp.ORDERNO = '" + orderno + "'";
            }
            if (!"".Equals(status))
            {
                cmdTxt += " and isnull(sp.TASK_RESULT,'9') = '" + status + "'";
            }
            if (!"".Equals(branchid))
            {
                cmdTxt += " and o.BranchId = '" + branchid + "'";
            }
            if (!"".Equals(smid))
            {
                cmdTxt += " and sp.CREATOR = '" + smid + "'";
            }
            if (!"".Equals(insurance))
            {
                cmdTxt += " and sp.INSURANCE_TYPE = '" + insurance + "'";
            }
            if (!"".Equals(bigtype))
            {
                cmdTxt += " and sp.BIG_TYPE = '" + bigtype + "'";
            }
            if (!"".Equals(specialtype))
            {
                cmdTxt += " and sp.SPECIAL_TYPE = '" + specialtype + "'";
            }
            if (!"".Equals(carcod))
            {
                cmdTxt += " and o.CarCod = '" + carcod + "'";
            }
            if (!"".Equals(p_supportMoney))
            {
                cmdTxt += " and sp.SUPPORT_MONEY > 1500";
            }

            if (!"".Equals(supprottype))
            {
                if ("2".Equals(supprottype))
                {
                    cmdTxt += " and sp.SUPPORT_TYPE = '2'";
                }
                else
                {
                    cmdTxt += " and sp.SUPPORT_TYPE <> '2'";
                }
            }

            cmdTxt += @" order by o.BranchId";

            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
        }

        public void QueryDatasByAdminQuery1YESDoc(DataTable dt, string BDate, string EDate, string orderno, string status, string branchid, string smid, string insurance, string bigtype, string specialtype, string carcod, string p_supportMoney, string supprottype)
        {
            string cmdTxt = @" select sp.ORDERNO,o.CustomerId,o.ordpnm,sp.CREATE_DATE,o.CarCod,o.CarMdl,o.yeartype,o.SFX,u.NAME,sp.TASK_ID";
            cmdTxt += @" ,sp.CREATOR,o.BranchId,TASK_RESULT = IsNull((case";
            cmdTxt += @" when (isnull(sp.TASK_RESULT,'9')= '0' ) then '同意'";
            cmdTxt += @" when (isnull(sp.TASK_RESULT,'9')= '1' ) then '否決'";
            cmdTxt += @" when (isnull(sp.TASK_RESULT,'9')= '2' ) then '作廢'";
            cmdTxt += @" when (isnull(sp.TASK_RESULT,'9')= '9' ) then '處理中'";
            cmdTxt += @" end),0),sp.TASK_ID,sp.APPLY_NUM,sp.M_APPLY_NUM,o.EngNo,sp.SUPPORT_MONEY,c1.Name as CustomerName";
            cmdTxt += @" ,SUPPORT_TYPE = IsNull((case";
            cmdTxt += @" when (sp.SUPPORT_TYPE <> '2' ) then '准'";
            cmdTxt += @" when (sp.SUPPORT_TYPE = '2') then '不准'";
            cmdTxt += @" when (isnull(sp.SUPPORT_TYPE,'') = '' ) then '未核'";
            cmdTxt += @" end),0)";

            cmdTxt += @" from TB_REW_SPECIALSALE sp";
            cmdTxt += @" inner join TB_KD_ORDERS o on sp.ORDERNO = o.OrderNo";
            cmdTxt += @" left join TB_KD_CAR c on c.EngNo = o.EngNo";
            cmdTxt += @" inner join TB_EB_USER u on u.ACCOUNT = sp.CREATOR";
            cmdTxt += @" left join TB_REW_SALEDOC s on s.ORDERNO = sp.ORDERNO";
            cmdTxt += @" left join Customer c1 on c1.CustomerID = o.CarOwnerId";
            cmdTxt += @" where ISNULL(s.ORDERNO,'') <> ''";
            if (!"".Equals(BDate))
            {
                cmdTxt += " and o.SaleDay between '" + BDate + "' and '" + EDate + "'";
            }
            if (!"".Equals(orderno))
            {
                cmdTxt += " and sp.ORDERNO = '" + orderno + "'";
            }
            if (!"".Equals(status))
            {
                cmdTxt += " and isnull(sp.TASK_RESULT,'9') = '" + status + "'";
            }
            if (!"".Equals(branchid))
            {
                cmdTxt += " and o.BranchId = '" + branchid + "'";
            }
            if (!"".Equals(smid))
            {
                cmdTxt += " and sp.CREATOR = '" + smid + "'";
            }
            if (!"".Equals(insurance))
            {
                cmdTxt += " and sp.INSURANCE_TYPE = '" + insurance + "'";
            }
            if (!"".Equals(bigtype))
            {
                cmdTxt += " and sp.BIG_TYPE = '" + bigtype + "'";
            }
            if (!"".Equals(specialtype))
            {
                cmdTxt += " and sp.SPECIAL_TYPE = '" + specialtype + "'";
            }
            if (!"".Equals(carcod))
            {
                cmdTxt += " and o.CarCod = '" + carcod + "'";
            }
            if (!"".Equals(p_supportMoney))
            {
                cmdTxt += " and sp.SUPPORT_MONEY > 1500";
            }

            if (!"".Equals(supprottype))
            {
                if ("2".Equals(supprottype))
                {
                    cmdTxt += " and sp.SUPPORT_TYPE = '2'";
                }
                else
                {
                    cmdTxt += " and sp.SUPPORT_TYPE <> '2'";
                }
            }
            cmdTxt += @" order by o.BranchId";

            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
        }
        public void QueryDatasByCarQuery(DataTable dt, string BDate, string EDate, string orderno, string branchid, string smid, string signuser)
        {
            string cmdTxt = @" select o.BranchId,o.OrderNo,u.ACCOUNT,u.NAME,s.CREATE_DATE,t.TASK_ID,t.CURRENT_SITE_ID,s.TASK_RESULT";
            cmdTxt += @" from dbo.TB_REW_SPECIALSALE s";
            cmdTxt += @" inner join TB_KD_ORDERS o on o.OrderNo = s.ORDERNO";
            cmdTxt += @" inner join TB_WKF_TASK t on s.TASK_ID = t.TASK_ID";
            cmdTxt += @" inner join TB_EB_USER u on u.ACCOUNT = s.CREATOR";
            cmdTxt += @" inner join  TB_WKF_TASK_NODE n on n.SITE_ID = t.CURRENT_SITE_ID ";
            cmdTxt += @" where s.TASK_RESULT is null";
            if (!"".Equals(BDate))
            {
                cmdTxt += @" and o.SaleDay between '" + BDate + "' and '" + EDate + "'";

            }
            if (!"".Equals(smid))
            {
                cmdTxt += @" and u.ACCOUNT = '" + smid + "'";

            }
            if (!"".Equals(branchid))
            {
                cmdTxt += @" and o.BranchId = '" + branchid + "'";

            }
            if (!"".Equals(orderno))
            {
                cmdTxt += @" and o.OrderNo = '" + orderno + "'";

            }
            if (!"".Equals(signuser))
            {
                cmdTxt += @" and n.ORIGINAL_SIGNER = '" + signuser + "'";

            }
            cmdTxt += @" order by o.BranchId";

            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
        }

        public void QueryDatasByCarSingQuery(DataTable dt, string BDate, string EDate, string orderno, string smid, string groupid)
        {
            string cmdTxt = @" select sp.ORDERNO,o.CustomerId,o.ordpnm,sp.CREATE_DATE,o.CarCod,o.CarMdl,o.yeartype,o.SFX,u.NAME,sp.TASK_ID";
            cmdTxt += @" ,TASK_RESULT = IsNull((case";
            cmdTxt += @" when (isnull(sp.TASK_RESULT,'9')= '0' ) then '同意'";
            cmdTxt += @" when (isnull(sp.TASK_RESULT,'9')= '1' ) then '否決'";
            cmdTxt += @" when (isnull(sp.TASK_RESULT,'9')= '2' ) then '作廢'";
            cmdTxt += @" when (isnull(sp.TASK_RESULT,'9')= '9' ) then '未審核'";
            cmdTxt += @" end),0)";
            cmdTxt += @" from TB_REW_SPECIALSALE sp";
            cmdTxt += @" inner join TB_KD_ORDERS o on sp.ORDERNO = o.OrderNo";
            cmdTxt += @" left join TB_KD_CAR c on c.EngNo = o.EngNo";
            cmdTxt += @" inner join TB_EB_USER u on u.ACCOUNT = sp.CREATOR";
            cmdTxt += @" where isnull(sp.TASK_RESULT,'9') <> '9'";

            if (!"".Equals(BDate))
            {
                cmdTxt += @" and o.SaleDay between '" + BDate + "' and '" + EDate + "'";

            }
            if (!"".Equals(smid))
            {
                cmdTxt += @" and u.ACCOUNT = '" + smid + "'";

            }
            if ("南區".Equals(groupid))
            {
                cmdTxt += " and o.BranchId  in ('03','04','07','09','13','14','20','22')";
            }
            else
            {
                cmdTxt += " and o.BranchId  not in ('03','04','07','09','13','14','20','22')";
            }
            if (!"".Equals(orderno))
            {
                cmdTxt += " and sp.ORDERNO = '" + orderno + "'";
            }
            cmdTxt += @" order by o.BranchId";

            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
        }
        public void QuerySignerName(DataTable dt, string taskid)
        {
            string cmdTxt = @"select u.NAME";
            cmdTxt += @" FROM TB_REW_SPECIALSALE sp";
            cmdTxt += @" inner join TB_WKF_TASK t on t.TASK_ID = sp.TASK_ID ";
            cmdTxt += @" inner join TB_WKF_TASK_NODE tn on tn.SITE_ID = t.CURRENT_SITE_ID";
            cmdTxt += @" left join TB_EB_USER u on u.USER_GUID = tn.ORIGINAL_SIGNER ";
            cmdTxt += @" where sp.TASK_ID = '" + taskid + "'";

            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
        }
        public void QueryDatasByOrderno(DataTable dt, string orderno)
        {
            string cmdTxt = @"select * from TB_REW_SPECIALSALE where ORDERNO='" + orderno + "'";

            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
        }

        public void QueryDatasBySPECIALSALE(DataTable dt, string bDate, string eDate, string orderno, string status)
        {
            string cmdTxt = @"select s.*,o.CustomerId, o.ordpnm,c.SFX,o.CarCod,o.yeartype,c.CarMdl";
            cmdTxt += @" from TB_REW_SPECIALSALE s";
            cmdTxt += @" inner join TB_KD_ORDERS o on o.OrderNo = s.ORDERNO";
            cmdTxt += @" inner join TB_KD_CAR c on c.EngNo = o.EngNo";
            cmdTxt += @" where s.TASK_RESULT = 0";
            if (!"".Equals(bDate))
            {
                cmdTxt += " and s.CREATE_DATE between '" + bDate + "' and '" + eDate + "'";
            }
            if (!"".Equals(orderno))
            {
                cmdTxt += " and s.ORDERNO =  '" + orderno + "'";
            }
            if (!"".Equals(status))
            {
                cmdTxt += " and s.STATUS =  '" + status + "'";
            }

            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
        }


        public void Delete(string orderno)
        {
            string cmdTxt = @"delete from TB_REW_SPECIALSALE where ORDERNO='" + orderno + "'";
            this.m_db.ExecuteNonQuery(cmdTxt);
        }
        public void Update(REWDataSet ds)
        {
            _myTAM.UpdateAll(ds);
        }

        public void QueryDatasBySPECIALSALE(DataTable dt, string Orderno)
        {
            string cmdTxt = @" select o.BranchId,o.SMId,c.CustomerID,o.ordpnm,o.oaddr,o.ortelh,o.CarCod";
            cmdTxt += @" ,o.CarMdl,o.SFX,o.yeartype,o.yeartype,o.EngNo,cm.CAR_PRICE,u.NAME,s.*,c.Name as CustomerName";
            cmdTxt += @" from dbo.TB_REW_SPECIALSALE s";
            cmdTxt += @" inner join TB_KD_ORDERS o on o.OrderNo = s.ORDERNO";
            cmdTxt += @" inner join TB_EB_USER u on u.ACCOUNT = o.SMId";
            cmdTxt += @" inner join TB_REW_CARMODEL cm on cm.CAR_CODE = o.CarCod and cm.CAR_MDL = o.CarMdl and cm.CAR_SFX = o.SFX";
            cmdTxt += @" left join Customer c on c.CustomerID = o.CarOwnerId";
            cmdTxt += @" where s.TASK_RESULT = 0";
            cmdTxt += @" and s.ORDERNO = '" + Orderno + "'";

            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
        }

        public void QueryDatasBySPECIALSALEByNTS(DataTable dt, string Orderno)
        {
            string cmdTxt = @" select o.BranchId,o.SMId,c.CustomerID,o.ordpnm,o.oaddr,o.ortelh,o.CarCod";
            cmdTxt += @" ,o.CarMdl,o.SFX,o.yeartype,o.yeartype,o.EngNo,cm.CAR_PRICE,u.NAME,s.*,c.Name as CustomerName";
            cmdTxt += @" from dbo.TB_REW_SPECIALSALE s";
            cmdTxt += @" inner join TB_KD_ORDERS o on o.OrderNo = s.ORDERNO";
            cmdTxt += @" inner join TB_EB_USER u on u.ACCOUNT = o.SMId";
            cmdTxt += @" inner join TB_REW_CARMODEL cm on cm.CAR_CODE = o.CarCod and cm.CAR_MDL = o.CarMdl and cm.CAR_SFX = o.SFX";
            cmdTxt += @" left join Customer c on c.CustomerID = o.CarOwnerId";
            cmdTxt += @" where s.ORDERNO = '" + Orderno + "'";

            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
        }

        public void QueryDatasBySaleDoc(DataTable dt, string Orderno)
        {
            string cmdTxt = @"select s.SPECIAL_TYPE,cm.CAR_PRICE,s.SPECIAL_MONEY ";
            cmdTxt += @" from dbo.TB_REW_SPECIALSALE s";
            cmdTxt += @" inner join TB_KD_ORDERS o on o.OrderNo = s.ORDERNO ";
            cmdTxt += @" inner join TB_REW_CARMODEL cm on cm.CAR_CODE = o.CarCod and cm.CAR_MDL = o.CarMdl and cm.CAR_SFX = o.SFX";
            cmdTxt += @" where s.TASK_RESULT = 0";
            cmdTxt += @" and s.ORDERNO = '" + Orderno + "'";

            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
        }


        public void QueryLocationRewCount(DataTable dt, string BranchId, string BDate, string EDate, ArrayList al)
        {
            string cmdTxt = @"select o.BranchId,icnt = COUNT(o.BranchId),";
            cmdTxt += @" location = IsNull(sum(case ";
            for (int i = 0; i < al.Count; i++)
            {
                cmdTxt += @" when (PATINDEX('%" + al[i].ToString() + "%',c.MailAddress) >0) Then 1";
            }
            cmdTxt += @" end),0)";
            cmdTxt += @" from dbo.TB_REW_SPECIALSALE s";
            cmdTxt += @" inner join TB_KD_ORDERS o on o.OrderNo = s.ORDERNO";
            cmdTxt += @" left join Customer c on o.CarOwnerId = c.CustomerID";
            cmdTxt += @" where o.BranchId = '" + BranchId + "'";
            cmdTxt += @" and o.SaleDay between '" + BDate + "' and '" + EDate + "'";
            cmdTxt += @" group by o.BranchId";

            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
        }

        public void QueryLocationRewCountDetail(DataTable dt, string BranchId, string BDate, string EDate)
        {
            string cmdTxt = @"select o.BranchId,o.SMId,u.NAME,o.ordpnm,o.CarCod,o.CarMdl,o.SFX,o.yeartype,o.EngNo,o.OrderDay,o.SaleDay,c.MailAddress,o.OrderNO";
            cmdTxt += @" from dbo.TB_REW_SPECIALSALE s ";
            cmdTxt += @" inner join TB_KD_ORDERS o on o.OrderNo = s.ORDERNO";
            cmdTxt += @" left join Customer c on o.CarOwnerId = c.CustomerID";
            cmdTxt += @" inner join TB_EB_USER u on o.SMId = u.ACCOUNT";
            cmdTxt += @" where 1=1";
            if (!String.IsNullOrEmpty(BranchId))
            {
                cmdTxt += @" and o.BranchId = '" + BranchId + "'";
            }         
            cmdTxt += @" and o.SaleDay between '" + BDate + "' and '" + EDate + "'";
            cmdTxt += @" order by o.BranchId,o.SMId";

            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
        }

        public void QuerySaleOROrederCnt(DataTable dt, string BDate, string EDate, string type)
        {
            string cmdTxt = @"";
            cmdTxt += @" select 'GROUP_NAME'=g.GROUP_NAME, 'ACCOUNT'=u.ACCOUNT,'NAME'=u.NAME,'ARRIVE_DATE' = em.ARRIVE_DATE,";
            cmdTxt += @" 'CAMRY'=isnull(o.camry,0),'CAMRYH'=isnull(o.CAMRYH,0),'WISH'=isnull(o.WISH,0),";
            cmdTxt += @" 'ALTIS'=isnull(o.ALTIS,0),'VIOS'=isnull(o.VIOS,0),";
            cmdTxt += @" 'PREVIA'=isnull(o.PREVIA,0),'PRIUS'=isnull(o.PRIUS,0),'PRIUSC'=isnull(o.PRIUSC,0),";
            cmdTxt += @" 'YARIS'=isnull(o.YARIS,0),'INNOVA'=isnull(o.INNOVA,0),'RAV4'=isnull(o.RAV4,0)";
            cmdTxt += @" ,'ALPHARD'=isnull(o.ALPHARD,0),'PRADO'=isnull(o.PRADO,0),'86'=isnull(o.AE86,0),'cnt'=isnull(o.cnt,0)";
            cmdTxt += @" from TB_EB_USER u";
            cmdTxt += @" inner join TB_EB_EMPL_DEP e on u.USER_GUID = e.USER_GUID";
            cmdTxt += @" inner join TB_EB_EMPL em on u.USER_GUID = em.USER_GUID";
            cmdTxt += @" inner join TB_EB_GROUP g on e.GROUP_ID = g.GROUP_ID";
            cmdTxt += @" inner join TB_EB_JOB_TITLE j on e.TITLE_ID = j.TITLE_ID";
           
            cmdTxt += @" left join (";
            //先查出訂單檔資料再left join給TB_EB_USER(沒業績的業務也要顯現)
            cmdTxt += @" select smid,";
            cmdTxt += @" CAMRY=sum(case when o.carcod = 'K' then 1 else 0 end),";
            cmdTxt += @" WISH=sum(case when o.carcod = 'W' then 1 else 0 end),";
            cmdTxt += @" ALTIS=sum(case when o.carcod = 'V' then 1 else 0 end),";
            cmdTxt += @" VIOS=sum(case when o.carcod = 'O' then 1 else 0 end),";
            cmdTxt += @" PREVIA=sum(case when o.carcod = 'U' then 1 else 0 end),";
            cmdTxt += @" PRIUS=sum(case when o.carcod = 'PS' then 1 else 0 end),";
            cmdTxt += @" YARIS=sum(case when o.carcod = 'YS' then 1 else 0 end),";
            cmdTxt += @" INNOVA=sum(case when o.carcod = 'IN' then 1 else 0 end),";
            cmdTxt += @" RAV4=sum(case when o.carcod = 'R' then 1 else 0 end),";
            cmdTxt += @" CAMRYH=sum(case when o.carcod = 'KH' then 1 else 0 end),";
            cmdTxt += @" PRIUSC=sum(case when o.carcod = 'PC' then 1 else 0 end),";
            cmdTxt += @" ALPHARD=sum(case when carcod = 'AL' then 1 else 0 end),";
            cmdTxt += @" PRADO=sum(case when carcod = 'PD' then 1 else 0 end),";
            cmdTxt += @" AE86=sum(case when carcod = '86' then 1 else 0 end),";
            cmdTxt += @" cnt = count(*)";
            cmdTxt += @" from TB_KD_ORDERS o";
            if ("受訂日".Equals(type))
            {
                cmdTxt += @" where orderday between '" + BDate + "' and  '" + EDate + "'";
                cmdTxt += @" and status <=5";
            }
            else
            {
                cmdTxt += @" where saleday between '" + BDate + "' and  '" + EDate + "'";
                cmdTxt += @" and status between '3' and '5'";
            }
            cmdTxt += @" group by smid";
            cmdTxt += @" ) o on o.smid = u.ACCOUNT";

            //離職的不抓
            cmdTxt += @" where u.EXPIRE_DATE = '9999-12-31 23:59:59.997'";
            //只抓營業所
            cmdTxt += @" and g.LEV = 5";
            //只抓業代
            cmdTxt += @" and j.TITLE_NAME in ('課長級銷售顧問','銷售主任','銷售副理','銷售經理','高級銷售顧問','副理級銷售顧問','經理級銷售顧問','銷售襄理','銷售專員','銷售課長','銷售顧問')";
            cmdTxt += @" order by g.GROUP_NAME,u.ACCOUNT";
            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
        }

        public void QuerySaleOROrederDet(DataTable dt, string BDate, string EDate, string type)
        {
            string cmdTxt = @"";
            cmdTxt += @" select 'GROUP_NAME'=g.GROUP_NAME, 'ACCOUNT'=u.ACCOUNT , 'NAME'=u.NAME ,'ARRIVE_DATE' = em.ARRIVE_DATE,";
            cmdTxt += @" 'orderno'=o.orderno, 'orderday'=o.orderday, 'saleday'=o.saleday,";
            cmdTxt += @" 'status'=case o.status ";
            cmdTxt += @" when '0' then '受訂'";
            cmdTxt += @" when '1' then '受訂'";
            cmdTxt += @" when '2' then '受訂'";
            cmdTxt += @" when '3' then '販賣' ";
            cmdTxt += @" when '4' then '領照' ";
            cmdTxt += @" when '5' then '交車' ";
            cmdTxt += @" else '' end,";
            cmdTxt += @" 'engno'=o.engno,'madeday' = c.madeday,'cartypename'=n.CAR_TYPE_NAME,'carmdl'=o.carmdl,o.sfx,'custname'=r.name";

            cmdTxt += @" from TB_KD_ORDERS o";
            cmdTxt += @" inner join TB_EB_USER u on u.ACCOUNT = o.smid";
            cmdTxt += @" inner join Customer r on r.customerid = o.customerid";
            cmdTxt += @" inner join TB_REW_CARNAME n on n.CAR_CODE = o.carcod ";
            cmdTxt += @" left join TB_KD_CAR c on c.engno = o.engno";
            cmdTxt += @" inner join TB_EB_EMPL_DEP e on u.USER_GUID = e.USER_GUID";
            cmdTxt += @" inner join TB_EB_EMPL em on u.USER_GUID = em.USER_GUID";
            cmdTxt += @" inner join TB_EB_GROUP g on e.GROUP_ID = g.GROUP_ID";
            cmdTxt += @" inner join TB_EB_JOB_TITLE j on e.TITLE_ID = j.TITLE_ID";
            if ("受訂日".Equals(type))
            {
                cmdTxt += @" where o.status <=5";
                cmdTxt += @" and o.orderday between '" + BDate + "' and  '" + EDate + "'";
              
            }
            else
            {
                cmdTxt += @" where o.status <=5";
                cmdTxt += @" and o.saleday between '" + BDate + "' and  '" + EDate + "'";
                cmdTxt += @" and o.status between '3' and '5'";
            } 
            //只抓營業所
            cmdTxt += @" and g.LEV = 5";
            //只抓業代
            cmdTxt += @" and j.TITLE_NAME in ('課長級銷售顧問','銷售主任','銷售副理','銷售經理','高級銷售顧問','副理級銷售顧問','經理級銷售顧問','銷售襄理','銷售專員','銷售課長','銷售顧問')";
            cmdTxt += @" order by 1,2,3,4";
            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
        }
       
    }
}
