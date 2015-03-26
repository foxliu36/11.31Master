using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace KDUOFLib.REW.PO
{
    public class CCarmodelPO : Fast.EB.Utility.Data.BasePersistentObject
    {
        REWDataSetTableAdapters.TableAdapterManager _myTAM;

        public CCarmodelPO()
        {
            _myTAM = new REWDataSetTableAdapters.TableAdapterManager();
            _myTAM.BackupDataSetBeforeUpdate = false;
            _myTAM.UpdateOrder = REWDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            //加入Table Adapter
            _myTAM.TB_REW_CARMODELTableAdapter = new REWDataSetTableAdapters.TB_REW_CARMODELTableAdapter();
            _myTAM.TB_REW_CARMODELTableAdapter.Connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;
           
        }

        public void QueryDatas(DataTable dt)
        {
            string cmdTxt = @"select * from TB_REW_CARMODEL order by CAR_CODE,CAR_MDL,CAR_SFX";
            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
        }
        public void Update(REWDataSet ds)
        {
            _myTAM.UpdateAll(ds);
        }
        public void QueryDatasBySearch(DataTable dt, string carcode, string sfx)
        {
            string cmdTxt = @"select * from TB_REW_CARMODEL where 1=1";
            if (!"".Equals(carcode))
            {
                cmdTxt += " and CAR_CODE='" + carcode + "'";
            }
            if (!"".Equals(sfx))
            {
                cmdTxt += " and CAR_SFX='" + sfx + "'";
            }
            cmdTxt += @" order by CAR_CODE,CAR_MDL,CAR_SFX";
            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
        }

        public void QueryPriceBySearch(DataTable dt, string carcode, string carmdl, string sfx)
        {
            string cmdTxt = @"select * from TB_REW_CARMODEL where ";
            cmdTxt += "  CAR_CODE='" + carcode + "'";
            cmdTxt += " and CAR_MDL='" + carmdl + "'";
            cmdTxt += " and CAR_SFX='" + sfx + "'";
            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
        }

        public DataTable QueryCAR_MDLs(string CAR_CODE)
        {
            DataTable dt = new DataTable();
            string cmdTxt = @"select distinct CAR_MDL from TB_REW_CARMODEL where CAR_CODE = '" + CAR_CODE + "'";
            dt.Load(this.m_db.ExecuteReader(cmdTxt));
            return dt;
        }

        public DataTable QuerySFXs(string CAR_CODE, string CAR_MDL)
        {
            DataTable dt = new DataTable();
            string cmdTxt = @"select CAR_SFX from TB_REW_CARMODEL where CAR_CODE='" + CAR_CODE + "' and CAR_MDL = '" + CAR_MDL + "'";
            dt.Load(this.m_db.ExecuteReader(cmdTxt));
            return dt;
        }
    }
}
