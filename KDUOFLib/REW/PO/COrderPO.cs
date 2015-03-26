using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace KDUOFLib.REW.PO
{
    public class COrderPO : Fast.EB.Utility.Data.BasePersistentObject
    {
        REWDataSetTableAdapters.TableAdapterManager _myTAM;
        public COrderPO()
        {
            _myTAM = new REWDataSetTableAdapters.TableAdapterManager();
            _myTAM.BackupDataSetBeforeUpdate = false;
            _myTAM.UpdateOrder = REWDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            //加入Table Adapter
            _myTAM.TB_KD_ORDERSTableAdapter = new REWDataSetTableAdapters.TB_KD_ORDERSTableAdapter();
            _myTAM.TB_KD_ORDERSTableAdapter.Connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;

        }
        public void QueryDatasByOrderno(DataTable dt,string orderno)
        {
            string cmdTxt = @"select o.*,c.MadeDay,cm.CAR_PRICE,u.NAME,cu.Name as CustomerName,cu.MailAddress";
            cmdTxt += @" from TB_KD_ORDERS o";
            cmdTxt += @" left join TB_KD_CAR c on o.EngNo = c.EngNo";
            cmdTxt += @" inner join TB_REW_CARMODEL cm on cm.CAR_CODE = o.CarCod and cm.CAR_MDL = o.CarMdl and cm.CAR_SFX = o.SFX";
            cmdTxt += @" inner join TB_EB_USER u on u.ACCOUNT = o.SMId";
            cmdTxt += @" left join Customer cu on cu.CustomerID = o.CarOwnerId";
            cmdTxt += @" where o.OrderNo='" + orderno + @"'";
            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
        }
        public void QueryDatasByGuid(DataTable dt, string guid)
        {
            string cmdTxt = @"select t.TITLE_NAME";
            cmdTxt += @" from TB_EB_EMPL_DEP d";
            cmdTxt += @" inner join TB_EB_JOB_TITLE t on d.TITLE_ID = t.TITLE_ID";
            cmdTxt += @" where USER_GUID = '" + guid + "'";
            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
        }
        
        public void IsTrueOrderNO(DataTable dt, string orderno)
        {
            string cmdTxt = @"select * from TB_KD_ORDERS where OrderNo = '" + orderno + "'";
            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
        }
        public void Update(REWDataSet ds)
        {
            _myTAM.UpdateAll(ds);
        }

        //20140804新增獎金明細
        public DataTable RUNBonus(DataTable dt,string BDate,string EDate)
        {
            string cmdTxt = @" select o.SMId,u.NAME,o.BranchId,o.SectorId,o.OrderNo,c.Name as CustomerName,o.CarCod,o.CarMdl,o.SFX,o.EngNo,";
            cmdTxt += @" o.SaleDay,o.OrderDay,s.BIG_TYPE,s.SPECIAL_TYPE,s.M_APPLY_NUM,s.INSURANCE_TYPE,s.SUPPORT_TYPE";
            cmdTxt += @" from dbo.TB_KD_ORDERS o";
            cmdTxt += @" inner join TB_REW_SPECIALSALE s on o.OrderNo = s.ORDERNO";
            cmdTxt += @" inner join TB_REW_SALEDOC sc on s.OrderNo = sc.ORDERNO";
            cmdTxt += @" inner join Customer c on o.CustomerId = c.CustomerID";
            cmdTxt += @" inner join TB_EB_USER u on o.SMId = u.ACCOUNT";
            cmdTxt += @" where o.SaleDay between  '" + BDate + "' and '" + EDate + "'";
            cmdTxt += @" order by o.SMId,u.NAME,o.BranchId";

            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);   //解析SQL內的資料(可以是DataTable、DataGrid...)
            dr.Dispose();   //切斷與資料庫連線
            return dt;
        }

        //20140806 新增員介車表單用
        public DataTable QueryDatabyStaffCar(DataTable dt,string Orderno)
        {
            string cmdTxt = @" select o.OrderNo,o.BranchId as Unit,o.SMId as StaffAccount,O.EngNo,";
            cmdTxt += @" CarName =IsNull((case when (C.CAR_TYPE_NAME is null) then 'LEXUS'";
            cmdTxt += @" end),C.CAR_TYPE_NAME),";
            cmdTxt += @" cu.Name as CustomerName";
            cmdTxt += @" from TB_KD_ORDERS o";
            cmdTxt += @" left join TB_REW_CARNAME c on c.CAR_CODE=o.CarCod";
            cmdTxt += @" left join Customer cu on cu.CustomerID = o.CarOwnerId";
            cmdTxt += @" where o.OrderNo='" + Orderno + "'";

            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);   //解析SQL內的資料(可以是DataTable、DataGrid...)
            dr.Dispose();
            return dt;
        }


    }
}
