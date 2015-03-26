using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace KDUOFLib.PET.PO
{
    public class CFinancePO : Fast.EB.Utility.Data.BasePersistentObject
    {
        PETDataSetTableAdapters.TableAdapterManager _myTAM;

        public CFinancePO()
        {
            _myTAM = new PETDataSetTableAdapters.TableAdapterManager();
            _myTAM.BackupDataSetBeforeUpdate = false;
            _myTAM.UpdateOrder = PETDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            //加入Table Adapter
            _myTAM.TB_PET_FINANCETableAdapter = new PETDataSetTableAdapters.TB_PET_FINANCETableAdapter();
            _myTAM.TB_PET_FINANCETableAdapter.Connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;
           
        }


        #region Print
        public void QueryDatasByPrint(string orderno, DataTable dt)
        {
            string cmdTxt = @"select f.ID,f.ORDERNO,p.SMID,u.NAME,p.PEO_NAME,p.PEO_MOBILE,";
            cmdTxt += @" p.PEO_REPORT_ADD,f.SEVERAL,f.PAY_DATE,p.MONTH_MONEY,p.COM_NAME";
            cmdTxt += @" from TB_PET_FINANCE f";
            cmdTxt += @" inner join TB_PET_PETITION p on p.ORDERNO = f.ORDERNO";
            cmdTxt += @" inner join TB_KD_ORDERS s on s.OrderNo = p.ORDERNO";
            cmdTxt += @" inner join TB_EB_USER u on s.SMId = u.ACCOUNT";
            cmdTxt += @" where f.ORDERNO ='" + orderno + "'";
            cmdTxt += @" order by f.SEVERAL";

            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
        }
        public void QueryDatasByCrytalPrint(string id, DataTable dt)
        {
            string cmdTxt = @"select f.ORDERNO,p.SMID,u.NAME,p.PEO_NAME,p.PEO_MOBILE,";
            cmdTxt += @" p.PEO_REPORT_ADD,f.SEVERAL,f.PAY_DATE,p.MONTH_MONEY,p.COM_NAME";
            cmdTxt += @" from TB_PET_FINANCE f";
            cmdTxt += @" inner join TB_PET_PETITION p on p.ORDERNO = f.ORDERNO";
            cmdTxt += @" inner join TB_KD_ORDERS s on s.OrderNo = p.ORDERNO";
            cmdTxt += @" inner join TB_EB_USER u on s.SMId = u.ACCOUNT";
            cmdTxt += @" where f.ID = '" + id + "'";
            cmdTxt += @" order by f.SEVERAL";

            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
        }
        #endregion

        public void QueryDatas(string ORDERNO, DataTable dt)
        {
            string cmdTxt = @"select * from TB_PET_FINANCE where ORDERNO = @ORDERNO Order by SEVERAL";
            this.m_db.AddParameter("@ORDERNO", ORDERNO);
            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
        }
        public void Update(PETDataSet ds)
        {
            _myTAM.UpdateAll(ds);
        }
    }
}
