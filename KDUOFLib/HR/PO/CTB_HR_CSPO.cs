using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace KDUOFLib.HR.PO
{
    public class CTB_HR_CSPO: Fast.EB.Utility.Data.BasePersistentObject
    {
        HRDataSetTableAdapters.TableAdapterManager _myTAM;

        public CTB_HR_CSPO()
        {
            _myTAM = new HRDataSetTableAdapters.TableAdapterManager();
            _myTAM.BackupDataSetBeforeUpdate = false;
            _myTAM.UpdateOrder = HRDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            //加入Table Adapter
            _myTAM.TB_HR_CSTableAdapter = new HRDataSetTableAdapters.TB_HR_CSTableAdapter();
            _myTAM.TB_HR_CSTableAdapter.Connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;
        }

        public string getDatsByID(DataTable p_dt, string p_SMID)
        {
            string cmdTxt = @"select TOTAL from TB_HR_CS where SMID='" + p_SMID + "'";
            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            p_dt.Load(dr);
            dr.Dispose();
            List<DataRow> l_list = new List<DataRow>();
            foreach (DataRow row in p_dt.Rows)
            {
                l_list.Add(row);
            }
            if (l_list.Count > 0)
            {
                string l_str分數 = l_list[0][0].ToString();
                return l_str分數;

            }
            return "0";
        }

    }
}
