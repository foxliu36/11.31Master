using System;
using System.Collections.Generic;
using System.Text;
using KDUOFLib.HR.UCO;
using System.Xml;
using System.Data;

namespace KDUOFLib.Trigger.HR.Nuclear_Salary
{
    public class OnFormTriggerByNSUpload : Fast.EB.WKF.ExternalUtility.ICallbackTriggerPlugin
    {
        #region ICallbackTriggerPlugin 成員

        public void Finally()
        {
        }

        public string GetFormResult(Fast.EB.WKF.ExternalUtility.ApplyTask applyTask)
        {
            CTB_HR_NS_TempUCO l_Temp = new CTB_HR_NS_TempUCO();
             //訂單需要同意才進入
            if (applyTask.FormResult == Fast.EB.WKF.Engine.ApplyResult.UnKnow)
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(applyTask.CurrentDocXML);
                XmlNode node = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='NS_upload']/FieldValue");
                string l_NS_GUID = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='NS_GUID']").Attributes["fieldValue"].Value;
                
                DataTable l_dt = l_Temp.getData("");
                for (int i = 0; i < l_dt.Rows.Count; i++)
                {
                    string l_GUID = l_dt.Rows[i]["GUID"].ToString();
                    l_Temp.updateGUIDbyDate(l_NS_GUID, l_GUID);

                }

               
            } 
                //訂單否決刪除單子
            else
            {
                l_Temp.DeletebyNS_GUID("");
            }

            return "";
        }

        public void OnError(Exception errorException)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
