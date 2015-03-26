using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace KDUOFLib.PET.PO
{
    public class CSponsorPO : Fast.EB.Utility.Data.BasePersistentObject
    {
        PETDataSetTableAdapters.TableAdapterManager _myTAM;

        public CSponsorPO()
        {
            _myTAM = new PETDataSetTableAdapters.TableAdapterManager();
            _myTAM.BackupDataSetBeforeUpdate = false;
            _myTAM.UpdateOrder = PETDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            //加入Table Adapter
            _myTAM.TB_PET_SPONSORTableAdapter = new PETDataSetTableAdapters.TB_PET_SPONSORTableAdapter();
            _myTAM.TB_PET_SPONSORTableAdapter.Connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;
           
        }
        public void QueryDatas(string No,DataTable dt)
        {
            string cmdTxt = @"select *, ";

            cmdTxt += @" SPO_SEX = (case";
            cmdTxt += @" when (isnull(SPO_SEX,3)= 0 ) then '女'";
            cmdTxt += @" when (isnull(SPO_SEX,3)= 1 ) then '男'";
            cmdTxt += @" end),";

            cmdTxt += @" SPO_MERRY = (case";
            cmdTxt += @" when (isnull(SPO_MERRY,3)= 0 ) then '未婚'";
            cmdTxt += @" when (isnull(SPO_MERRY,3)= 1 ) then '已婚'";
            cmdTxt += @" end)";

            cmdTxt += @" from TB_PET_SPONSOR where ORDERNO = @ORDERNO order by ID";
            this.m_db.AddParameter("@ORDERNO", No);
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
