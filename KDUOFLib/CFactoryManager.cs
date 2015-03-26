using System;
using System.Data;
using System.Configuration;
using System.Web;
using KDUOFLib.PETDataSetTableAdapters;
using KDUOFLib.PET.UCO;
using SlnKDCOMLIB.common;
using KDUOFLib.REW.UCO;
using KDUOFLib.HR.UCO;

namespace KDUOFLib.dl
{
    public class CFactoryManager
    {
        private CUIContext _context { get; set; }
        public CFactoryManager()
        {
            if (_context == null)
            {
                _context = new CUIContext();
            }
        }

        #region PET
        private CSuperviseUCO _CSuperviseUCO = null;
        public CSuperviseUCO CSuperviseUCO
        {
            get
            {
                if (_CSuperviseUCO == null)
                    _CSuperviseUCO = new CSuperviseUCO();
                return _CSuperviseUCO;
            }
        }
        private CTargetUCO _CTargetUCO = null;
        public CTargetUCO CTargetUCO
        {
            get
            {
                if (_CTargetUCO == null)
                    _CTargetUCO = new CTargetUCO();
                return _CTargetUCO;
            }
        }
        private CPetitionUCO _CPetitionUCO = null;
        public CPetitionUCO CPetitionUCO
        {
            get
            {
                if (_CPetitionUCO == null)
                    _CPetitionUCO = new CPetitionUCO();
                return _CPetitionUCO;
            }
        }

        private CSponsorUCO _CSponsorUCO = null;
        public CSponsorUCO CSponsorUCO
        {
            get
            {
                if (_CSponsorUCO == null)
                    _CSponsorUCO = new CSponsorUCO();
                return _CSponsorUCO;
            }
        }
        private CAgreeUCO _CAgreeUCO = null;
        public CAgreeUCO CAgreeUCO
        {
            get
            {
                if (_CAgreeUCO == null)
                    _CAgreeUCO = new CAgreeUCO();
                return _CAgreeUCO;
            }
        }

        private CPetcomUCO _CPetcomUCO = null;
        public CPetcomUCO CPetcomUCO
        {
            get
            {
                if (_CPetcomUCO == null)
                    _CPetcomUCO = new CPetcomUCO();
                return _CPetcomUCO;
            }
        }
        private CFinanceUCO _CFinanceUCO = null;
        public CFinanceUCO CFinanceUCO
        {
            get
            {
                if (_CFinanceUCO == null)
                    _CFinanceUCO = new CFinanceUCO();
                return _CFinanceUCO;
            }
        }
        #endregion



        #region REWUCO Object
        private CCarnameUCO _CCarnameUCO = null;
        public CCarnameUCO CCarnameUCO
        {
            get
            {
                if (_CCarnameUCO == null)
                    _CCarnameUCO = new CCarnameUCO();
                return _CCarnameUCO;
            }
        }

        private CPartUCO _CPartUCO = null;
        public CPartUCO CPartUCO
        {
            get
            {
                if (_CPartUCO == null)
                    _CPartUCO = new CPartUCO();
                return _CPartUCO;
            }
        }
        private CCarmodelUCO _CCarmodelUCO = null;
        public CCarmodelUCO CCarmodelUCO
        {
            get
            {
                if (_CCarmodelUCO == null)
                    _CCarmodelUCO = new CCarmodelUCO();
                return _CCarmodelUCO;
            }
        }

        private CCaryearUCO _CCaryearUCO = null;
        public CCaryearUCO CCaryearUCO
        {
            get
            {
                if (_CCaryearUCO == null)
                    _CCaryearUCO = new CCaryearUCO();
                return _CCaryearUCO;
            }
        }

        private CCarcolorUCO _CCarcolorUCO = null;
        public CCarcolorUCO CCarcolorUCO
        {
            get
            {
                if (_CCarcolorUCO == null)
                    _CCarcolorUCO = new CCarcolorUCO();
                return _CCarcolorUCO;
            }
        }
        private CBaseawardUCO _CBaseawardUCO = null;
        public CBaseawardUCO CBaseawardUCO
        {
            get
            {
                if (_CBaseawardUCO == null)
                    _CBaseawardUCO = new CBaseawardUCO();
                return _CBaseawardUCO;
            }
        }
        private CSpecialsaleUCO _CSpecialsaleUCO = null;
        public CSpecialsaleUCO CSpecialsaleUCO
        {
            get
            {
                if (_CSpecialsaleUCO == null)
                    _CSpecialsaleUCO = new CSpecialsaleUCO();
                return _CSpecialsaleUCO;
            }
        }
        private COrderUCO _COrderUCO  = null;
        public COrderUCO COrderUCO
        {
            get
            {
                if (_COrderUCO == null)
                    _COrderUCO = new COrderUCO();
                return _COrderUCO;
            }
        }
        private CSaleDocUCO _CSaleDocUCO = null;
        public CSaleDocUCO CSaleDocUCO
        {
            get
            {
                if (_CSaleDocUCO == null)
                    _CSaleDocUCO = new CSaleDocUCO();
                return _CSaleDocUCO;
            }
        }

        private CQaUCO _CQaUCO = null;
        public CQaUCO CQaUCO
        {
            get
            {
                if (_CQaUCO == null)
                    _CQaUCO = new CQaUCO();
                return _CQaUCO;
            }
        }
        private CRewardDetailUCO _RewardDetailUCO = null;
        public CRewardDetailUCO RewardDetailUCO
        {
            get
            {
                if (_RewardDetailUCO == null)
                    _RewardDetailUCO = new CRewardDetailUCO();
                return _RewardDetailUCO;
            }
        }
        private CRewardUCO _CRewardUCO = null;
        public CRewardUCO CRewardUCO
        {
            get
            {
                if (_CRewardUCO == null)
                    _CRewardUCO = new CRewardUCO();
                return _CRewardUCO;
            }
        }
        private CPERTUCO _CPERTUCO = null;
        public CPERTUCO CPERTUCO
        {
            get
            {
                if (_CPERTUCO == null)
                    _CPERTUCO = new CPERTUCO();
                return _CPERTUCO;
            }
        }
        private WORKTIMEUCO _WORKTIMEUCO = null;
        public WORKTIMEUCO WORKTIMEUCO
        {
            get
            {
                if (_WORKTIMEUCO == null)
                    _WORKTIMEUCO = new WORKTIMEUCO();
                return _WORKTIMEUCO;
            }
        }

        private CTB_HR_JOBTIMEUCO _CTB_HR_JOBTIMEUCO = null;
        public CTB_HR_JOBTIMEUCO CTB_HR_JOBTIMEUCO
        {
            get
            {
                if (_CTB_HR_JOBTIMEUCO == null)
                    _CTB_HR_JOBTIMEUCO = new CTB_HR_JOBTIMEUCO();
                return _CTB_HR_JOBTIMEUCO;
            }
        }

        #endregion

        #region HR Object
        private CTB_HR_JoinCore_UCO _CTB_HR_JoinCore_UCO = null;
        public CTB_HR_JoinCore_UCO CTB_HR_JoinCore_UCO
        {
            get
            {
                if (_CTB_HR_JoinCore_UCO == null)
                    _CTB_HR_JoinCore_UCO = new CTB_HR_JoinCore_UCO();
                return _CTB_HR_JoinCore_UCO;
            }
        }



        private CSpecialCntUCO _CSpecialCntUCO = null;
        public CSpecialCntUCO CSpecialCntUCO
        {
            get
            {
                if (_CSpecialCntUCO == null)
                    _CSpecialCntUCO = new CSpecialCntUCO();
                return _CSpecialCntUCO;
            }
        }
        #endregion
    }
}
