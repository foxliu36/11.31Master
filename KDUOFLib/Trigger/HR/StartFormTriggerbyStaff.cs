using System;
using System.Collections.Generic;
using System.Text;
using Fast.EB.WKF.ExternalUtility;
using System.Xml;
using System.Data;
using KDUOFLib.HR.UCO;
using Fast.EB.SystemInfo;
using KDUOFLib.HR.PO;

namespace KDUOFLib.Trigger.HR
{
    public class StartFormTriggerbyStaff : Fast.EB.WKF.ExternalUtility.ICallbackTriggerPlugin
    {
        #region ICallbackTriggerPlugin 成員

        public void Finally()
        {

        }

        public string GetFormResult(ApplyTask applyTask)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(applyTask.CurrentDocXML);
            string l_GUID = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='FormID']").Attributes["fieldValue"].Value;
            string l_SMID = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='Staff']/FieldValue").Attributes["SMID"].Value;
            string l_type = "";
            int l_int月份 = DateTime.Today.Month;
            if (l_int月份 > 9 || l_int月份 < 3)
            {
                l_type = "年終";
            }
            else if (2 < l_int月份 && l_int月份 < 7)
            {
                l_type = "端午";
            }
            else if (6 < l_int月份 && l_int月份 < 10)
            {
                l_type = "中秋";
            }
            string l_year = DateTime.Today.Year.ToString();
            CTB_HR_ASSESS_STAFF_DETAILUCO l_detail = new CTB_HR_ASSESS_STAFF_DETAILUCO();
            l_detail.updateGUID(l_GUID,l_SMID,l_type,l_year);        
                ////判斷明細有資料列
                //if (xmlDoc.SelectNodes("/Form/FormFieldValue/FieldItem[@fieldId='GUID']/DataGrid/Row") != null)
                //{
                //    //取得列
                //    XmlNodeList sequenceCode = xmlDoc.SelectNodes("/Form/FormFieldValue/FieldItem[@fieldId='GUID']/DataGrid/Row");
                //    //取得欄
                //    foreach (XmlNode xmlN in sequenceCode)
                //    {
                //        DataRow l_row = l_detail.NewRow();
                //        l_row["GUID"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='FormID']").Attributes["fieldValue"].Value;
                //        l_row["DEL_GUID"] = Guid.NewGuid();
                //        l_row["PLAN_DRAW"] = xmlN.SelectSingleNode("./Cell[@fieldId='PLAN_DRAW']").Attributes["fieldValue"].Value;
                //        l_row["PLAN_TARGET"] = xmlN.SelectSingleNode("./Cell[@fieldId='PLAN_TARGET']").Attributes["fieldValue"].Value;
                //        l_row["PLAN_KPI"] = xmlN.SelectSingleNode("./Cell[@fieldId='PLAN_KPI']").Attributes["fieldValue"].Value;

                //        l_detail.Insert(l_row);
                //    }
                //}
            

            return "";
        }

        public void OnError(Exception errorException)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
