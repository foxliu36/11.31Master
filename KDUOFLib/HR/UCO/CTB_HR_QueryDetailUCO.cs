using System;
using System.Collections.Generic;
using System.Text;
using KDUOFLib.HR.PO;
using System.Data;

namespace KDUOFLib.HR.UCO
{
    public class CTB_HR_QueryDetailUCO
    {
        private HRDataSet HR = new HRDataSet();
        private CTB_HR_QueryDetailPO _CTB_HR_QueryDetailPO = null;
        private CTB_HR_QueryDetailPO CTB_HR_QueryDetailPO
        {
            get
            {
                if (_CTB_HR_QueryDetailPO == null)
                    _CTB_HR_QueryDetailPO = new CTB_HR_QueryDetailPO();
                return _CTB_HR_QueryDetailPO;
            }
        }

        public DataTable QuerybyAssistanManager(string p_smid, string p_type)
        {
            DataTable l_dt = new DataTable();
            return this.CTB_HR_QueryDetailPO.QuerybyAssistanManager(l_dt,p_smid, p_type);
        }

        public DataTable QuerybyCOMPTENT(string p_smid)
        {
            DataTable l_dt = new DataTable();
            return this.CTB_HR_QueryDetailPO.QuerybyCOMPTENT(l_dt, p_smid);
        }

        public DataTable QuerybyGENERAL(string p_smid, string p_type)
        {
            DataTable l_dt = new DataTable();
            return this.CTB_HR_QueryDetailPO.QuerybyGENERAL(l_dt, p_smid, p_type);
        }

        public DataTable QuerybySTAFF(string p_smid, string p_type)
        {
            DataTable l_dt = new DataTable();
            return this.CTB_HR_QueryDetailPO.QuerybySTAFF(l_dt, p_smid, p_type);
        }

        public DataTable QuerybySERVICE(string p_smid, string p_type)
        {
            DataTable l_dt = new DataTable();
            return this.CTB_HR_QueryDetailPO.QuerybySERVICE(l_dt, p_smid, p_type);
        }

    

    }
}
