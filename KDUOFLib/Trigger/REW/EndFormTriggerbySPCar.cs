using System;
using System.Collections.Generic;
using System.Text;
using KDUOFLib.REW.UCO;
using System.Xml;
using System.Data;
using KDUOFLib.HR.UCO;

namespace KDUOFLib.Trigger.REW
{
    class EndFormTriggerbySPCar : Fast.EB.WKF.ExternalUtility.ICallbackTriggerPlugin
    {
        #region ICallbackTriggerPlugin 成員

        public void Finally()
        {
            
        }

        public string GetFormResult(Fast.EB.WKF.ExternalUtility.ApplyTask applyTask)
        {
            CTB_REW_StaffPresentCarUCO SPC = new CTB_REW_StaffPresentCarUCO();
            CTB_HR_GROUPUCO GROUPUCO = new CTB_HR_GROUPUCO();
            if (applyTask.FormResult == Fast.EB.WKF.Engine.ApplyResult.Adopt)
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(applyTask.CurrentDocXML);

                DataRow l_row = SPC.NewRow();
                l_row["TASK_ID"] = applyTask.TaskId;
                l_row["GUID"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='GUID']").Attributes["fieldValue"].Value;
                l_row["Date"] = DateTime.Today;
                l_row["PresentAccount"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='PresentAccount']").Attributes["fieldValue"].Value;
                string PresentAccount = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='PresentAccount']").Attributes["fieldValue"].Value;
                l_row["PresentUnit"] = GROUPUCO.getGroupIDbySMID(PresentAccount, "", "");
                l_row["PresentName"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='PresentName']").Attributes["fieldValue"].Value;
                l_row["BuyType"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='BuyType']").Attributes["fieldValue"].Value;
                
               
                XmlNode node = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='StaffPresentCar']/FieldValue");
                l_row["Orderno"] = node.Attributes["Orderno"].Value;
                l_row["Plate"] = node.Attributes["Plate"].Value;
                l_row["CarName"] = node.Attributes["CarName"].Value;
                l_row["CustomerName"] = node.Attributes["CustomerName"].Value;
                l_row["EngNo"] = node.Attributes["EngNo"].Value;
                l_row["StaffAccount"] = node.Attributes["StaffAccount"].Value;
                string ACCOUNT = node.Attributes["StaffAccount"].Value;
                //l_row["StaffName"] = node.Attributes["StaffName"].Value;
                l_row["StaffName"] = GROUPUCO.getNamebySMID(ACCOUNT);
                l_row["Unit"] = GROUPUCO.getGroupIDbySMID(ACCOUNT,"","");

                SPC.Insert(l_row);
            }
            //訂單否決刪除單子
            else
            {
                SPC.Delete(applyTask.TaskId);
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
