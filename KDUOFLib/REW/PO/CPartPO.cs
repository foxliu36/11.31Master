using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace KDUOFLib.REW.PO
{
    public class CPartPO : Fast.EB.Utility.Data.BasePersistentObject
    {
        REWDataSetTableAdapters.TableAdapterManager _myTAM;

        public CPartPO()
        {
            _myTAM = new REWDataSetTableAdapters.TableAdapterManager();
            _myTAM.BackupDataSetBeforeUpdate = false;
            _myTAM.UpdateOrder = REWDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            //加入Table Adapter
            _myTAM.TB_REW_PARTTableAdapter = new REWDataSetTableAdapters.TB_REW_PARTTableAdapter();
            _myTAM.TB_REW_PARTTableAdapter.Connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;

        }

        public void QueryDatas(DataTable dt)
        {
            string cmdTxt = @"select * from TB_REW_PART order by PartID";
            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
        }
        public void QueryPartDatasByOrderNo(DataTable dt, string ORDERNO)
        {
            string cmdTxt = @"select * from TB_REW_PART where ORDERNO ='" + ORDERNO + @"' order by PartID ";

            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
        }
        public void DeletePartDatasByOrderNo(string ORDERNO)
        {
            string cmdTxt = @"delete from TB_REW_PART where ORDERNO ='" + ORDERNO + @"'";
            this.m_db.ExecuteReader(cmdTxt);
        }
        public void Update(REWDataSet ds)
        {
            _myTAM.UpdateAll(ds);
        }

        public DataTable QueryAllKDParts()
        {
            DataTable dt = new DataTable();
            string cmdTxt = @"select PartID, PartName, salesprice  from TB_KD_PART ";
            dt.Load(this.m_db.ExecuteReader(cmdTxt));
            return dt;
        }
        public DataTable QueryKDParts(string keyStr)
        {
            DataTable dt = new DataTable();
            string cmdTxt = @"select PartID, PartName, salesprice  from TB_KD_PART Where PartID like '%" + keyStr + "%' Or PartName like '%" + keyStr + "%'";
            dt.Load(this.m_db.ExecuteReader(cmdTxt));
            return dt;
        }
        public DataTable QueryKDPartsByOrderno(string orderno)
        {
            DataTable dt = new DataTable();
            string cmdTxt = @"select PartID, PartName, salesprice  from TB_REW_PART where ORDERNO ='" + orderno + @"'";
            dt.Load(this.m_db.ExecuteReader(cmdTxt));
            return dt;
        }
    }
}
