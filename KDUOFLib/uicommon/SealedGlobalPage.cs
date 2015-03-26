using System;
using System.Collections.Generic;
using System.Text;

using System.Web;
using System.Web.UI;
using System.Web.Configuration;

namespace SlnKDCOMLIB.common
{
    public class SealedGlobalPage
    {
        #region Context相關
        /// <summary>
        /// getContext
        /// </summary>
        /// <param name="p_control">Web Control</param>
        /// <returns>Context</returns>
        public static CUIContext getContext(System.Web.UI.UserControl p_control)
        {
            return getContext(p_control.Page);
        }
        /// <summary>
        /// getContext
        /// </summary>
        /// <param name="p_page"> Web Page</param>
        /// <returns>Context</returns>
        public static CUIContext getContext(System.Web.UI.Page p_page)
        {
            CUIContext l_context = (CUIContext)p_page.Session[CUIContext.TypeName];
            if (l_context == null && p_page.Parent != null)
            {
                l_context = (CUIContext)((Page)p_page.Parent).Session[CUIContext.TypeName];
            }
            if (l_context == null)
            {
                l_context = new CUIContext();
                setContext(p_page, l_context);
            }
            return l_context;
        }
        /// <summary>
        /// setContext 把Context放置Session & Application
        /// </summary>
        /// <param name="p_control"> Web Control</param>
        /// <param name="p_context"> Context</param>
        public static void setContext(System.Web.UI.UserControl p_control, CUIContext p_context)
        {
            setContext(p_control.Page, p_context);
        }
        /// <summary>
        /// setContext 把Context放置Session & Application
        /// </summary>
        /// <param name="p_page">Web Page</param>
        /// <param name="p_context">Context</param>
        public static void setContext(System.Web.UI.Page p_page, CUIContext p_context)
        {
            p_page.Session.Add(CUIContext.TypeName, p_context);
        }
        #endregion

        #region SessionKeys

        public static string SESSION_KEY_PETCONTEXT = "SESSION_KEY_PETCONTEXT";
        public static string SESSION_KEY_TARGETDATATABLE = "SESSION_KEY_TARGETDATATABLE";
        public static string SESSION_KEY_TARGETMODIFYDATA = "SESSION_KEY_TARGETMODIFYDATA";
        public static string SESSION_KEY_TARGETBRANCHDATAS = "SESSION_KEY_TARGETBRANCHDATAS";
        public static string SESSION_KEY_SUPERVISEDATATABLE = "SESSION_KEY_SUPERVISEDATATABLE";
        public static string SESSION_KEY_SUPERVISEMODIFYDATA = "SESSION_KEY_SUPERVISEMODIFYDATA";
        public static string SESSION_KEY_AGREEDATATABLE = "SESSION_KEY_AGREEDATATABLE";
        public static string SESSION_KEY_AGREEMODIFYDATA = "SESSION_KEY_AGREEMODIFYDATA";
        public static string SESSION_KEY_PETCOMDATATABLE = "SESSION_KEY_PETCOMDATATABLE";
        public static string SESSION_KEY_PETCOMMODIFYDATA = "SESSION_KEY_PETCOMMODIFYDATA";
        public static string SESSION_KEY_PETCOMDATAS = "SESSION_KEY_PETCOMDATAS";
        public static string SESSION_KEY_DYNAMICINSURANCEDATATABLE = "SESSION_KEY_DYNAMICINSURANCEDATATABLE";
        public static string SESSION_KEY_DYNAMICINSURANCEMODIFYDATA = "SESSION_KEY_DYNAMICINSURANCEMODIFYDATA";
        public static string SESSION_KEY_SUPERVISEDATAS = "SESSION_KEY_SUPERVISEDATAS";
        public static string SESSION_KEY_FINANCEDATATABLE = "SESSION_KEY_FINANCEDATATABLE";
        public static string SESSION_KEY_FINANCEMODIFYDATA = "SESSION_KEY_FINANCEMODIFYDATA";
        public static string SESSION_KEY_CLOSEDATATABLE = "SESSION_KEY_CLOSEDATATABLE";
        public static string SESSION_KEY_CLOSEMODIFYDATA = "SESSION_KEY_CLOSEMODIFYDATA";
        public static string SESSION_KEY_INVOICEDATATABLE = "SESSION_KEY_INVOICEDATATABLE";
        public static string SESSION_KEY_INVOICEMODIFYDATA = "SESSION_KEY_INVOICEMODIFYDATA";




        public static string SESSION_KEY_CARNAMEDATATABLE = "SESSION_KEY_CARNAMEDATATABLE";
        public static string SESSION_KEY_CARNAMEMODIFYDATA = "SESSION_KEY_CARNAMEMODIFYDATA";
        public static string SESSION_KEY_CARMODELDATATABLE = "SESSION_KEY_CARMODELDATATABLE";
        public static string SESSION_KEY_CARMODELMODIFYDATA = "SESSION_KEY_CARMODELMODIFYDATA";
        public static string SESSION_KEY_CARYEARDATATABLE = "SESSION_KEY_CARYEARDATATABLE";
        public static string SESSION_KEY_CARYEARMODIFYDATA = "SESSION_KEY_CARYEARMODIFYDATA";
        public static string SESSION_KEY_CARYEARCARMODELDATATABLE = "SESSION_KEY_CARYEARCARMODELDATATABLE";
        public static string SESSION_KEY_CARYEARMODIFYDATAS = "SESSION_KEY_CARYEARMODIFYDATAS";
        public static string SESSION_KEY_CARCOLORDATATABLE = "SESSION_KEY_CARCOLORDATATABLE";
        public static string SESSION_KEY_CARCOLORMODIFYDATA = "SESSION_KEY_CARCOLORMODIFYDATA";


        public static string SESSION_KEY_BASEAWARDDOCTABLE = "SESSION_KEY_BASEAWARDDOCTABLE";
        public static string SESSION_KEY_BASEAWARDETAILTABLE = "SESSION_KEY_BASEAWARDETAILTABLE";
        public static string SESSION_KEY_BASEAWARDETAILMODIFYDATA = "SESSION_KEY_BASEAWARDETAILMODIFYDATA";
        public static string SESSION_KEY_BASEAWARDADDMODIFYDATAS = "SESSION_KEY_BASEAWARDADDMODIFYDATAS";


        public static string SESSION_KEY_PARTMODIFYDATAS = "SESSION_KEY_PARTMODIFYDATAS";


        public static string SESSION_KEY_IMPORTTABLE = "SESSION_KEY_IMPORTTABLE";
        public static string SESSION_KEY_IMPORTMODIFYDATA = "SESSION_KEY_IMPORTMODIFYDATA";

        public static string SESSION_KEY_REWARDDETAILTABLE = "SESSION_KEY_REWARDDETAILTABLE";
        public static string SESSION_KEY_REWARDDETAILMODIFYDATA = "SESSION_KEY_REWARDDETAILMODIFYDATA";
        public static string SESSION_KEY_SALEDOCTABLE = "SESSION_KEY_SALEDOCTABLE";
        public static string SESSION_KEY_SALEDOCMODIFYDATA = "SESSION_KEY_SALEDOCMODIFYDATA";

        public static string SESSION_KEY_QADATATABLE = "SESSION_KEY_QADATATABLE";
        public static string SESSION_KEY_QAMODIFYDATA = "SESSION_KEY_QAMODIFYDATA";


        public static string SESSION_KEY_SPECIALSALEMODIFYDATA = "SESSION_KEY_SPECIALSALEMODIFYDATA";


        public static string SESSION_KEY_SPECIALSALEAREADATAS = "SESSION_KEY_SPECIALSALEAREADATAS";

        public static string SESSION_KEY_URGEDATATABLE = "SESSION_KEY_URGEDATATABLE";
        public static string SESSION_KEY_URGEMODIFYDATA = "SESSION_KEY_URGEMODIFYDATA";

        public static string SESSION_KEY_TONERORDER = "SESSION_KEY_TONERORDER";
        public static string SESSION_KEY_TONERCOMPANY = "SESSION_KEY_TONERCOMPANY";
        public static string SESSION_KEY_TONERPROJECT = "SESSION_KEY_TONERPROJECT";

        public static string SESSION_KEY_HRGENERAL = "SESSION_KEY_HRGENERAL";

        public static string SESSION_KEY_HRPERT = "SESSION_KEY_HRPERT";
        public static string SESSION_KEY_HRSTAFFDETAIL = "SESSION_KEY_HRSTAFFDETAIL";


        public static string SESSION_KEY_SPECIALCNTTABLE = "SESSION_KEY_SPECIALCNTTABLE";
        public static string SESSION_KEY_SPECIALCNTMODIFYDATA = "SESSION_KEY_SPECIALCNTMODIFYDATA";
        #endregion

    }
}
