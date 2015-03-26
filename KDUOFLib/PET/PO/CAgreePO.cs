using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace KDUOFLib.PET.PO
{
    public class CAgreePO : Fast.EB.Utility.Data.BasePersistentObject
    {
        PETDataSetTableAdapters.TableAdapterManager _myTAM;

        public CAgreePO()
        {
            _myTAM = new PETDataSetTableAdapters.TableAdapterManager();
            _myTAM.BackupDataSetBeforeUpdate = false;
            _myTAM.UpdateOrder = PETDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            //加入Table Adapter
            _myTAM.TB_PET_AGREETableAdapter = new PETDataSetTableAdapters.TB_PET_AGREETableAdapter();
            _myTAM.TB_PET_AGREETableAdapter.Connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;
           
        }
        public void QueryDatas(DataTable dt)
        {
            string cmdTxt = @"select * from TB_PET_AGREE order by ID";
            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
        }
        public void QueryDatasByOrderno(DataTable dt,string orderno)
        {
            string cmdTxt = @"select * from TB_PET_AGREE a ";
            string conditionStr = "";
            if (!string.IsNullOrEmpty(orderno))
            {
                conditionStr += "And a.ORDERNO = @ORDERNO";
                this.m_db.AddParameter("@ORDERNO", orderno);
            }
            if (conditionStr.Length > 0)
                cmdTxt += " where " + conditionStr.Substring(4);
            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
        }

        public void Update(PETDataSet ds)
        {
            _myTAM.UpdateAll(ds);
        }

        public void QueryDatasByConditions(DataTable dt, string txtORDERNO, string txtNO)
        {
            string cmdTxt = @"select a.*,c.LicenseNo,p.PEO_NAME,c.EngNo ";
            cmdTxt += @" from TB_PET_AGREE a";
            cmdTxt += @" inner join TB_KD_ORDERS o on a.ORDERNO = o.OrderNo";
            cmdTxt += @" inner join TB_KD_CAR c on o.EngNo = c.EngNo ";
            cmdTxt += @" inner join TB_PET_PETITION p on p.ORDERNO = a.ORDERNO";
            string conditionStr = "";
            if (!string.IsNullOrEmpty(txtORDERNO))
            {
                conditionStr += "And a.ORDERNO = @ORDERNO";
                this.m_db.AddParameter("@ORDERNO", txtORDERNO);
            }
            if (!string.IsNullOrEmpty(txtNO))//車主姓名
            {
                conditionStr += "And c.LicenseNo = @Name";
                this.m_db.AddParameter("@Name", txtNO);
            }
            if (conditionStr.Length > 0)
                cmdTxt += " where " + conditionStr.Substring(4);
            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
        }

        public void QueryDatasByInsert(DataTable dt, string txtORDERNO)
        {
            string cmdTxt = @"select c.LicenseNo,p.PEO_NAME,c.EngNo ";
            cmdTxt += @" from TB_KD_ORDERS o";
            cmdTxt += @" inner join TB_KD_CAR c on o.EngNo = c.EngNo ";
            cmdTxt += @" inner join TB_PET_PETITION p on p.ORDERNO = o.OrderNo";
            cmdTxt += @" inner join TB_PET_SUPERVISE s on s.ID = p.PET_SUPID";
            string conditionStr = "";
            if (!string.IsNullOrEmpty(txtORDERNO))
            {
                conditionStr += "And o.OrderNo = @ORDERNO";
                this.m_db.AddParameter("@ORDERNO", txtORDERNO);
            }
            if (conditionStr.Length > 0)
                cmdTxt += " where " + conditionStr.Substring(4);
            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
        }
        #region Print
        public void QueryDatasByAgreePrint(string licenseno, string orderno, string name, DataTable dt)
        {
            string cmdTxt = @"select p.KD_NUM,p.PEO_NAME,a.TYPE,c.LicenseNo,c.EngNo,s.NAME";
            cmdTxt += @" from TB_PET_AGREE a";
            cmdTxt += @" inner join TB_PET_PETITION p on p.ORDERNO = a.ORDERNO";
            cmdTxt += @" inner join TB_KD_ORDERS o on o.OrderNo = a.ORDERNO";
            cmdTxt += @" inner join TB_KD_CAR c on c.EngNo = o.EngNo";
            cmdTxt += @" inner join TB_PET_SUPERVISE s on s.ID = p.PET_SUPID";
            cmdTxt += @" where 1=1";

            if (!"".Equals(licenseno))
            {
                cmdTxt += @" and c.LicenseNo = '" + licenseno + "'";
            }
            if (!"".Equals(orderno))
            {
                cmdTxt += @" and a.ORDERNO = '" + orderno + "'";
            }
            if (!"".Equals(name))
            {
                cmdTxt += @" and p.PEO_NAME = '" + name + "'";
            }
            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
        }
        #endregion
    }
}
