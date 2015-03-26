using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web.UI.WebControls;
using KDUOFLib.dl;
namespace SlnKDCOMLIB.common
{
    /// <summary>
    /// CUIContext 的摘要描述
    /// </summary>
    public class CUIContext
    {
        public CUIContext()
        {
        }

        private CFactoryManager iv_CFactoryManager = null;
        public CFactoryManager CFactoryManager
        {
            get
            {
                if (iv_CFactoryManager == null)
                    iv_CFactoryManager = new CFactoryManager();
                return iv_CFactoryManager;
            }
        }

        public static string TypeName
        {
            get { return "CUIContext"; }
        }
    }
}