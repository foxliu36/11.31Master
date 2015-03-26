using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using KDUOFLib.HR.PO;

namespace KDUOFLib.HR.UCO
{
    public class CPERTUCO
    {
        private HRDataSet HR = new HRDataSet();
        private CPERTPO _CPERTPO = null;
        private CPERTPO CPERTPO
        {
            get
            {
                if (_CPERTPO == null)
                    _CPERTPO = new CPERTPO();
                return _CPERTPO;
            }
        }

        public DataRow NewRow()
        {
            return HR.TB_HR_PERT.NewRow();
        }
        public void Update(DataRow row)
        {
            this.CPERTPO.Update(HR);
        }
        public void Insert(DataRow row)
        {
            if (row.RowState != DataRowState.Added)
                HR.TB_HR_PERT.Rows.Add(row);
            this.CPERTPO.Update(HR);
        }

        public void Delete(string orderno)
        {
            this.CPERTPO.Delete(orderno);
        }

    }
}
