using System;
using System.Collections.Generic;
using System.Text;

namespace KDUOFLib
{
    public class PETContext : Fast.EB.Utility.Data.BasePersistentObject
    {
        public PETDataSet PETDS;
        PETDataSetTableAdapters.TableAdapterManager _myTAM;
        public PETContext()
        {
            PETDS = new PETDataSet();
            _myTAM = new PETDataSetTableAdapters.TableAdapterManager();
            _myTAM.BackupDataSetBeforeUpdate = false;
            _myTAM.UpdateOrder = PETDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            //加入Table Adapter
            _myTAM.TB_PET_TARGETTableAdapter = new PETDataSetTableAdapters.TB_PET_TARGETTableAdapter();
            _myTAM.TB_PET_SUPERVISETableAdapter = new PETDataSetTableAdapters.TB_PET_SUPERVISETableAdapter();
        }
        public bool updateDataSet()
        {
            try
            {
                _myTAM.UpdateAll(PETDS);
                return true;
            }
            catch
            {
                return false;
            }
        }
        #region TB_PET_SUPERVISE表格的查詢
        public bool getTB_PET_SUPERVISE()
        {
            try
            {
                string cmdTxt = @"select * from TB_PET_SUPERVISE order by ID";
                PETDS.TB_PET_SUPERVISE.Load(this.m_db.ExecuteReader(cmdTxt));
                //_myTAM.TB_PET_SUPERVISETableAdapter.Fill(PETDS.TB_PET_SUPERVISE);
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region TB_PET_TARGET表格的查詢
        public bool getTB_PET_TARGET()
        {
            try
            {
                _myTAM.TB_PET_TARGETTableAdapter.Fill(PETDS.TB_PET_TARGET);

                ///////////////////SqlCommand
                //string cmdTxt = @"select * from YJTest where name Like @name+'%'";
                //this.m_db.AddParameter("@name", "1");
                //KDDS.YJTest.Load(this.m_db.ExecuteReader(cmdTxt));
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion
    }
}
