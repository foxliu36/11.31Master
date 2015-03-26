using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using KDUOFLib.PET.PO;
using System.Web;

namespace KDUOFLib.PET.UCO
{
    public class CPetitionUCO
    {
        private PETDataSet PETDS = new PETDataSet();
        private CPetitionPO _CPetitionPO = null;
        private CPetitionPO CPetitionPO
        {
            get
            {
                if (_CPetitionPO == null)
                    _CPetitionPO = new CPetitionPO();
                return _CPetitionPO;
            }
        }
        public DataRow NewRow()
        {
            return PETDS.TB_PET_PETITION.NewRow();
        }
        /// <summary>
        /// 如果NO空的，回傳空TABLE
        /// </summary>
        /// <returns></returns>
        public DataTable QueryPetitionDatas(string No)
        {
            PETDS.TB_PET_PETITION.Clear();
            if (string.IsNullOrEmpty(No))
            {
                return  PETDS.TB_PET_PETITION;
            }
            CPetitionPO.QueryDatas(No, PETDS.TB_PET_PETITION);
            return PETDS.TB_PET_PETITION;
        }
        /// <summary>
        /// 如果NO空的，回傳空TABLE
        /// </summary>
        /// <returns></returns>
        public DataTable QueryPetitionDatasByWKF(string No)
        {
            PETDS.TB_PET_PETITION.Clear();
            if (string.IsNullOrEmpty(No))
            {
                return PETDS.TB_PET_PETITION;
            }
            CPetitionPO.QueryPetitionDatasByWKF(No, PETDS.TB_PET_PETITION);
            return PETDS.TB_PET_PETITION;
        }
        public DataTable QueryPetition(string No)
        {
            DataTable dt = new DataTable();
            CPetitionPO.QueryDatas(No, dt);
            return dt;
        }

        public DataTable QueryBranchDatas()
        {
            return CPetitionPO.QueryBranchDatas();
        }
        //public void InsertPetitionData(DataRow row)
        //{
        //     CPetitionPO.InsertData(row);
        //}
        public void Delete(DataRow row)
        {
            if (row.RowState != DataRowState.Deleted)
                row.Delete();
            CPetitionPO.Update(PETDS);
        }

        public void Update(DataRow row)
        {
            CPetitionPO.Update(PETDS);
        }
        public void UpdateLicenseNo(DataRow row)
        {
            CPetitionPO.UpdateLicenseNo(row);
        }
        public void UpdatePETITIONAfterWKF(DataRow row)
        {
            CPetitionPO.UpdatePETITIONAfterWKF(row);
        }
        public void UpdatePETITIONByUrge(DataRow row)
        {
            CPetitionPO.UpdatePETITIONByUrge(row);
        }
        
        public void Insert(DataRow row)
        {
            if (row.RowState != DataRowState.Added)
                PETDS.TB_PET_PETITION.Rows.Add(row);
            CPetitionPO.Update(PETDS);
        }
        /// <summary>
        /// FrmPETITIONQuery使用
        /// </summary>
        /// <returns></returns>
        public DataTable QueryDatasByConditions(string txtORDERNO, string txtName, string ddlRESULT, string txtNO, string txtID,string userid)
        {
           return  CPetitionPO.QueryDatasByConditions(txtORDERNO, txtName, ddlRESULT, txtNO, txtID, userid);
        }
        /// <summary>
        /// CDS_PET_PetByManager_FrmPETCOM
        /// </summary>
        /// <returns></returns>
        public DataTable QueryPetitionDatas(DateTime SDATE, DateTime EDATE, string ORDERNO, string Name, string PET_COM, string NO, string ID, string STATUS)
        {
            PETDS.TB_PET_PETITION.Clear();
            CPetitionPO.QueryDatas(SDATE, EDATE, ORDERNO, Name, PET_COM, NO, ID, STATUS, PETDS.TB_PET_PETITION);
            return PETDS.TB_PET_PETITION;
        }
        /// <summary>
        /// CDS_PET_PetByManager_FrmDynamicInsurance
        /// </summary>
        /// <returns></returns>
        public DataTable CDS_PET_PetByManager_FrmDynamicInsurance(DateTime SDATE, DateTime EDATE, string ORDERNO, string Name, string NO, string ID)
        {
            PETDS.TB_PET_PETITION.Clear();
            CPetitionPO.CDS_PET_PetByManager_FrmDynamicInsurance(SDATE, EDATE, ORDERNO, Name, null, NO, ID, null, PETDS.TB_PET_PETITION);
            return PETDS.TB_PET_PETITION;
        }
        /// <summary>
        /// CDS_PET_Account_FrmFINANCE
        /// </summary>
        /// <returns></returns>
        public DataTable QueryPetitionDatas(string branchid, string ORDERNO, string Name, string STATUS)
        {
            return CPetitionPO.QueryDatas(branchid, ORDERNO, Name, STATUS);
        }

        public void Update(string ORDERNO, DateTime PET_BDATE, DateTime PET_EDATE)
        {
            CPetitionPO.Update(ORDERNO, PET_BDATE, PET_EDATE);
        }
        public void UpdateMonthMoney(string ORDERNO, double monthmoney)
        {
            CPetitionPO.UpdateMonthMoney(ORDERNO, monthmoney);
        }
        /// <summary>
        /// CDS_PET_Account_FrmClose使用
        /// </summary>
        /// <returns></returns>
        public DataTable QueryPetitionDatas(string txtORDERNO, string txtName, string txtNO, string txtID, int CLOSE_TYPE)
        {
            PETDS.TB_PET_PETITION.Clear();
            CPetitionPO.QueryDatasByConditions(txtORDERNO, txtName, txtNO, txtID, CLOSE_TYPE, PETDS.TB_PET_PETITION);
            return PETDS.TB_PET_PETITION;
        }
        /// <summary>
        /// CDS_PET_Account_FrmINVOICE使用
        /// </summary>
        /// <returns></returns>
        public DataTable QueryPetitionDatas2(string ORDERNO)
        {
            PETDS.TB_PET_PETITION.Clear();
            CPetitionPO.QueryDatasByConditions(ORDERNO, PETDS.TB_PET_PETITION);
            return PETDS.TB_PET_PETITION;
        }
        #region Print

        public DataTable QueryDatasByPetPrint(string orderno)
        {

            DataTable dt = new DataTable();
            CPetitionPO.QueryDatasByPetPrint(orderno, dt);
            return dt;
        }
        public DataTable QueryDatasByNumPrint(string num)
        {

            DataTable dt = new DataTable();
            CPetitionPO.QueryDatasByNumPrint(num, dt);
            return dt;
        }
        public DataTable QueryDatasByClosePrint(string num, string nums)
        {
            DataTable dt = new DataTable();
            CPetitionPO.QueryDatasByClosePrint(num, nums, dt);
            return dt;
        }

        public DataTable QueryDatasByPETCOMPrint(DateTime BDate, DateTime EDate)
        {
            DataTable dt = new DataTable();
            CPetitionPO.QueryDatasByPETCOMPrint(BDate, EDate, dt);
            return dt;
        }

        public DataTable QueryDatasByDifferentPrint(string BDate, string EDate)
        {
            DataTable dt = new DataTable();
            CPetitionPO.QueryDatasByDifferentPrint(BDate, EDate, dt);
            return dt;
        }

        public DataTable QueryDatasByPETA3Print(string orderno)
        {
            DataTable dt = new DataTable();
            CPetitionPO.QueryDatasByPETA3Print(orderno, dt);
            return dt;
        }
        public DataTable QueryDatasByCHARTERA3Print(string orderno)
        {
            DataTable dt = new DataTable();
            CPetitionPO.QueryDatasByCHARTERA3Print(orderno, dt);
            return dt;
        }

        /// <summary>
        /// CDS_PET_PetByManager_FrmDynamicInsurance
        /// </summary>
        /// <returns></returns>
        public DataTable getDatasByUrge(string ORDERNO, string NO)
        {
            DataTable dt = new DataTable();
            CPetitionPO.getDatasByUrge(ORDERNO, NO, dt);
            return dt;
        }
        #endregion  
    }
}
