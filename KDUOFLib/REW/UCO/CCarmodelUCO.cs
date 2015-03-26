using System;
using System.Collections.Generic;
using System.Text;
using KDUOFLib.REW.PO;
using System.Data;

namespace KDUOFLib.REW.UCO
{
    public class CCarmodelUCO
    {
        private REWDataSet REWDS = new REWDataSet();
        private CCarmodelPO _CCarmodelPO = null;
        private CCarmodelPO CCarmodelPO
        {
            get
            {
                if (_CCarmodelPO == null)
                    _CCarmodelPO = new CCarmodelPO();
                return _CCarmodelPO;
            }
        }


        public DataTable QueryCarmodelDatas()
        {
            REWDS.TB_REW_CARMODEL.Clear();
            this.CCarmodelPO.QueryDatas(REWDS.TB_REW_CARMODEL);
            return REWDS.TB_REW_CARMODEL;
        }
        public DataTable QueryPriceBySearch(string carcode,string carmdl, string sfx)
        {
            REWDS.TB_REW_CARMODEL.Clear();
            this.CCarmodelPO.QueryPriceBySearch(REWDS.TB_REW_CARMODEL, carcode, carmdl, sfx);
            return REWDS.TB_REW_CARMODEL;
        }
        public DataTable QueryDatasBySearch(string carcode, string sfx)
        {
            REWDS.TB_REW_CARMODEL.Clear();
            this.CCarmodelPO.QueryDatasBySearch(REWDS.TB_REW_CARMODEL, carcode, sfx);
            return REWDS.TB_REW_CARMODEL;
        }

        public void Update(DataRow row)
        {
            this.CCarmodelPO.Update(REWDS);
        }
        public void Insert(DataRow row)
        {
            if (row.RowState != DataRowState.Added)
                REWDS.TB_REW_CARMODEL.Rows.Add(row);
            this.CCarmodelPO.Update(REWDS);
        }
        public void Delete(DataRow row)
        {
            if (row.RowState != DataRowState.Deleted)
                row.Delete();
            this.CCarmodelPO.Update(REWDS);
        }

        public DataTable QueryCAR_MDLs(string CAR_CODE)
        {
            return this.CCarmodelPO.QueryCAR_MDLs(CAR_CODE);
        }
        public DataTable QuerySFXs(string CAR_CODE,string CAR_MDL)
        {
            return this.CCarmodelPO.QuerySFXs(CAR_CODE,CAR_MDL);
        }
    }
}
