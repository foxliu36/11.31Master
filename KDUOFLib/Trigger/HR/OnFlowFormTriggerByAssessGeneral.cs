using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using KDUOFLib.HR.UCO;
using System.Data;
using Fast.EB.SystemInfo;
using KDUOFLib.HR.PO;

namespace KDUOFLib.Trigger.HR
{
    class OnFlowFormTriggerByAssessGeneral : Fast.EB.WKF.ExternalUtility.ICallbackTriggerPlugin
    {
        #region ICallbackTriggerPlugin 成員

        public void Finally()
        {

        }

        public string GetFormResult(Fast.EB.WKF.ExternalUtility.ApplyTask applyTask)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(applyTask.CurrentDocXML);
            CTB_HR_ASSESS_GENERALUCO l_General = new CTB_HR_ASSESS_GENERALUCO();

            if (applyTask.SignResult == Fast.EB.WKF.Engine.SignResult.Approve)     //簽核中需要同意才進入
            {
                DataRow row = l_General.NewRow();
                row["GUID"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='GUID']").Attributes["fieldValue"].Value;
                
                //自訂欄位的寫法
                row["SMID"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='General']/FieldValue").Attributes["SMID"].Value;
                row["EFFICIENCY"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='General']/FieldValue").Attributes["EFFICIENCY"].Value;                
                row["PERFORMANCE"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='General']/FieldValue").Attributes["PERFORMANCE"].Value;               
                row["ATTITUDE"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='General']/FieldValue").Attributes["ATTITUDE"].Value;                
                row["PROVISION"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='General']/FieldValue").Attributes["PROVISION"].Value;              
                row["SPIRIT"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='General']/FieldValue").Attributes["SPIRIT"].Value;               
                row["TIDY"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='General']/FieldValue").Attributes["TIDY"].Value;               
                row["COORDINATION"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='General']/FieldValue").Attributes["COORDINATION"].Value;               
                row["SPECIALTY"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='General']/FieldValue").Attributes["SPECIALTY"].Value;               
                row["REACTION"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='General']/FieldValue").Attributes["REACTION"].Value;
                row["Total"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='General']/FieldValue").Attributes["Total"].Value;                
                row["RANK"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='General']/FieldValue").Attributes["RANK"].Value;                
                row["SIGNER"] = Current.Name;
                row["EDIT_DATE"] = DateTime.Today.ToString("yyyy/MM/dd");
                row["TASK_ID"] = applyTask.TaskId;
                row["SITE_CODE"] = applyTask.SiteCode;
                int l_int月份 = DateTime.Today.Month;
                //Current.User.GroupID  此為登入者的部門
                //非年終不用進去
                if (l_int月份 > 9 || l_int月份 < 3)
                {
                    row["EFFICIENCY_Y"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='General']/FieldValue").Attributes["EFFICIENCY_Y"].Value;
                    row["PERFORMANCE_Y"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='General']/FieldValue").Attributes["PERFORMANCE_Y"].Value;
                    row["ATTITUDE_Y"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='General']/FieldValue").Attributes["ATTITUDE_Y"].Value;
                    row["PROVISION_Y"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='General']/FieldValue").Attributes["PROVISION_Y"].Value;
                    row["SPIRIT_Y"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='General']/FieldValue").Attributes["SPIRIT_Y"].Value;
                    row["TIDY_Y"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='General']/FieldValue").Attributes["TIDY_Y"].Value;
                    row["COORDINATION_Y"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='General']/FieldValue").Attributes["COORDINATION_Y"].Value;
                    row["SPECIALTY_Y"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='General']/FieldValue").Attributes["SPECIALTY_Y"].Value;
                    row["REACTION_Y"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='General']/FieldValue").Attributes["REACTION_Y"].Value;
                    row["Staff_Car"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='General']/FieldValue").Attributes["Staff_Car"].Value;
                    row["Total_Y"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='General']/FieldValue").Attributes["Total_Y"].Value;
                    row["RANK_Y"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='General']/FieldValue").Attributes["RANK_Y"].Value;
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
                DataTable l_dt = l_General.getDatsByID(applyTask.TaskId, applyTask.SiteCode);
                if (l_dt != null && l_dt.Rows.Count > 0)
                {
                    l_General.UpdateByTASKID(row);
                }
                else
                {
                    l_General.Insert(row);
                }

                //xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='General']").InnerXml = "";
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
