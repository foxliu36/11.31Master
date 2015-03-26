using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using KDUOFLib.HR.UCO;
using System.Data;
using Fast.EB.SystemInfo;

namespace KDUOFLib.Trigger.HR.ASSESS
{
    public class StartFormTriggerbyE : Fast.EB.WKF.ExternalUtility.ICallbackTriggerPlugin
    {
        #region ICallbackTriggerPlugin 成員

        public void Finally()
        {
           
        }

        public string GetFormResult(Fast.EB.WKF.ExternalUtility.ApplyTask applyTask)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(applyTask.CurrentDocXML);
            CTB_HR_ASSESS_SEVRICEUCO l_sevrice = new CTB_HR_ASSESS_SEVRICEUCO();

            XmlNodeList sequenceCode = xmlDoc.SelectNodes("/Form/FormFieldValue//FieldValue/Item");
            if (sequenceCode != null)
            {
                foreach (XmlNode xmlN in sequenceCode)
                {
                    DataRow l_row = l_sevrice.NewRow();
                    l_row["TITLE_NAME"] = xmlN.Attributes["TITLE_NAME"].Value;
                    l_row["FUNC_NAME"] = xmlN.Attributes["FUNC_NAME"].Value;
                    l_row["ACCOUNT"] = xmlN.Attributes["ACCOUNT"].Value;
                    l_row["NAME"] = xmlN.Attributes["NAME"].Value;
                    l_row["Total_Y"] = xmlN.Attributes["Total_Y"].Value;
                    l_row["RANK_Y"] = xmlN.Attributes["RANK_Y"].Value;
                    l_row["MEMO"] = xmlN.Attributes["MEMO"].Value;
                    l_row["SMID"] = xmlN.Attributes["SMID"].Value;
                    l_row["GROUP_NAME"] = xmlN.Attributes["GROUP_NAME"].Value;
                    string l_strSMID = xmlN.Attributes["SMID"].Value;
                    l_row["GUID"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='GUID']").Attributes["fieldValue"].Value;
                    l_row["SITE_CODE"] = "S1";
                    l_row["YEAR"] = (Convert.ToInt32(DateTime.Today.Year.ToString()) - 1).ToString();
                    l_row["SIGNER"] = Current.Name;
                    l_row["EDIT_DATE"] = DateTime.Today.ToString("yyyy/MM/dd");
                    l_row["TASK_ID"] = applyTask.TaskId;
                    l_row["ASSESS_TYPE"] = "年終";
                    DataTable l_dt = l_sevrice.getDatsByID(l_strSMID, applyTask.SiteCode, applyTask.TaskId);
                    if (l_dt != null && l_dt.Rows.Count > 0)
                    {
                        l_sevrice.UpdateByTASKID(l_row);
                    }
                    else
                    {
                        l_sevrice.Insert(l_row);
                    }
                }
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
