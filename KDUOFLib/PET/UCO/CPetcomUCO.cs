using System;
using System.Collections.Generic;
using System.Text;
using KDUOFLib.PET.PO;
using System.Data;

namespace KDUOFLib.PET.UCO
{
    public class CPetcomUCO
    {
        private PETDataSet PETDS=new PETDataSet();
        private CPetcomPO _CPetcomPO = null;
        private CPetcomPO CPetcomPO {
            get
            {
                if (_CPetcomPO == null)
                    _CPetcomPO = new CPetcomPO();
                return _CPetcomPO;
            }
        }

        public DataTable QueryPetcomDatas()
        {
            PETDS.TB_PET_PETCOM.Clear();
             CPetcomPO.QueryDatas(PETDS.TB_PET_PETCOM);
             return PETDS.TB_PET_PETCOM;
        }

    }
}
