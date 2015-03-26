using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Fast.EB.SystemInfo;
using System.Xml;
using KDUOFLib.HR.UCO;
using KDUOFLib.HR.PO;

namespace KDUOFLib.Trigger.HR
{
    class OnFlowFormTriggerByAssessStaff : Fast.EB.WKF.ExternalUtility.ICallbackTriggerPlugin
    {
        #region ICallbackTriggerPlugin 成員

        public void Finally()
        {

        }

        public string GetFormResult(Fast.EB.WKF.ExternalUtility.ApplyTask applyTask)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(applyTask.CurrentDocXML);
            CTB_HR_ASSESS_STAFF_UCO l_STAFF = new CTB_HR_ASSESS_STAFF_UCO();

            if (applyTask.SignResult == Fast.EB.WKF.Engine.SignResult.Approve)     //簽核中需要同意才進入
            {
                DataRow row = l_STAFF.NewRow();
                row["GUID"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='FormID']").Attributes["fieldValue"].Value;
                //row["SMID"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='SMID']").Attributes["fieldValue"].Value;

                //自訂欄位的寫法
                row["SMID"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='Staff']/FieldValue").Attributes["SMID"].Value;
                row["KNOWLEDGE"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='Staff']/FieldValue").Attributes["KNOWLEDGE"].Value;              
                row["FORCE"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='Staff']/FieldValue").Attributes["FORCE"].Value;              
                row["SENSE"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='Staff']/FieldValue").Attributes["SENSE"].Value;              
                row["INTERGITY"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='Staff']/FieldValue").Attributes["INTERGITY"].Value;                
                row["EXECUTION"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='Staff']/FieldValue").Attributes["EXECUTION"].Value;                
                row["ABILITY"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='Staff']/FieldValue").Attributes["ABILITY"].Value;                
                row["EQ"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='Staff']/FieldValue").Attributes["EQ"].Value;
                row["Total"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='Staff']/FieldValue").Attributes["Total"].Value;                
                row["RANK"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='Staff']/FieldValue").Attributes["RANK"].Value;               
                row["SIGNER"] = Current.Name;
                row["EDIT_DATE"] = DateTime.Today.ToString("yyyy/MM/dd");
                row["TASK_ID"] = applyTask.TaskId;
                row["SITE_CODE"] = applyTask.SiteCode;       
                int l_int月份 = DateTime.Today.Month;
                //非年終不用進去
                if (l_int月份 > 9 || l_int月份 < 3)
                {
                    row["KNOWLEDGE_Y"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='Staff']/FieldValue").Attributes["KNOWLEDGE_Y"].Value;
                    row["FORCE_Y"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='Staff']/FieldValue").Attributes["FORCE_Y"].Value;
                    row["SENSE_Y"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='Staff']/FieldValue").Attributes["SENSE_Y"].Value;
                    row["INTERGITY_Y"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='Staff']/FieldValue").Attributes["INTERGITY_Y"].Value;
                    row["EXECUTION_Y"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='Staff']/FieldValue").Attributes["EXECUTION_Y"].Value;
                    row["ABILITY_Y"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='Staff']/FieldValue").Attributes["ABILITY_Y"].Value;
                    row["EQ_Y"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='Staff']/FieldValue").Attributes["EQ_Y"].Value;
                    row["Staff_Car"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='Staff']/FieldValue").Attributes["Staff_Car"].Value;
                    row["Total_Y"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='Staff']/FieldValue").Attributes["Total_Y"].Value;
                    row["RANK_Y"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='Staff']/FieldValue").Attributes["RANK_Y"].Value;
                    row["ASSESS_TYPE"] = "年終";
                }
                else if (2 < l_int月份 && l_int月份 < 7)
                {
                    row["ASSESS_TYPE"] = "端午";
                }
                else if (6 < l_int月份 && l_int月份 < 10)
                {
                    row["ASSESS_TYPE"] = "中秋";
                }

                //row["DOC_NBR"] = applyTask.FormNumber;

                DataTable l_dt = l_STAFF.getDatsByID(applyTask.TaskId, applyTask.SiteCode);
                if (l_dt != null && l_dt.Rows.Count > 0)
                {
                    l_STAFF.UpdateByTASKID(row);
                }
                else
                {
                    l_STAFF.Insert(row);
                }

                //xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='Staff']").InnerXml = "";
                //AssessCompetentPO po = new AssessCompetentPO();
                //po.UpdateCurrentDoc(applyTask.TaskId, xmlDoc.OuterXml);
            }

            return "";

        }

        public void OnError(Exception errorException)
        {

        }

        #endregion
    }
}
