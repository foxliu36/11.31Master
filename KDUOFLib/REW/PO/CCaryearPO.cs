using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace KDUOFLib.REW.PO
{
    public class CCaryearPO : Fast.EB.Utility.Data.BasePersistentObject
    {
        REWDataSetTableAdapters.TableAdapterManager _myTAM;

        public CCaryearPO()
        {
            _myTAM = new REWDataSetTableAdapters.TableAdapterManager();
            _myTAM.BackupDataSetBeforeUpdate = false;
            _myTAM.UpdateOrder = REWDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            //加入Table Adapter
            _myTAM.TB_REW_CARYEARTableAdapter = new REWDataSetTableAdapters.TB_REW_CARYEARTableAdapter();
            _myTAM.TB_REW_CARYEARTableAdapter.Connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;

        }
        public void QueryDatas(DataTable dt)
        {
            string cmdTxt = @"select * from TB_REW_CARYEAR order by CAR_CODE,CAR_BDATE";
            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
        }
        public void Update(REWDataSet ds)
        {
            _myTAM.UpdateAll(ds);
        }

        public void QueryDatasBySearch(DataTable dt, string carcode, string year)
        {
            string cmdTxt = @"select * from TB_REW_CARYEAR where 1=1";
            if (!"".Equals(carcode))
            {
                cmdTxt += " and CAR_CODE='" + carcode + "'";
            }
            if (!"".Equals(year))
            {
                cmdTxt += " and CAR_YEAR='" + year + "'";
            }
            cmdTxt += @" order by CAR_CODE,CAR_MDL,CAR_SFX,CAR_YEAR";
            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
        }


        public void QueryYearsByCarcod(DataTable dt, string carcode)
        {
            string cmdTxt = @"select CAR_YEAR from dbo.TB_REW_CARYEAR where CAR_CODE  = '" + carcode + @"'"+ @"group by CAR_YEAR order by CAR_YEAR";
            //string cmdTxt = @"select * from TB_REW_CARYEAR where CAR_CODE = '" + carcode + @"' ";

            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            dt.Load(dr);
            dr.Dispose();
        }

        public DataTable QuerySFXDatasByConditions(string CarCode, DateTime BDate, DateTime EDate)
        {
            DataTable dt = new DataTable();
            string cmdTxt = @"select DISTINCT CAR_MDL, CAR_SFX from dbo.TB_REW_CARYEAR where CAR_CODE  = '" + CarCode + @"'"
                + @" And (CAR_BDATE between '" + BDate.ToString("yyyy/MM/dd") + "' And '" + EDate.ToString("yyyy/MM/dd") + "'"
                + @" Or CAR_EDATE between '" + BDate.ToString("yyyy/MM/dd") + "' And '" + EDate.ToString("yyyy/MM/dd") + "')";
            //string cmdTxt = @"select * from TB_REW_CARYEAR where CAR_CODE = '" + carcode + @"' ";

            dt.Load(this.m_db.ExecuteReader(cmdTxt));
            return dt;
        }
    }
}
