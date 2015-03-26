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
    class OnFlowFormTriggerByAssessAssistanManager : Fast.EB.WKF.ExternalUtility.ICallbackTriggerPlugin
    {
        #region ICallbackTriggerPlugin 成員

        public void Finally()
        {

        }

        public string GetFormResult(Fast.EB.WKF.ExternalUtility.ApplyTask applyTask)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(applyTask.CurrentDocXML);
            CTB_HR_ASSESS_ASSISTAN_MANAGERUCO l_MANAGER = new CTB_HR_ASSESS_ASSISTAN_MANAGERUCO();
            //簽核中需要同意才進入
            if (applyTask.SignResult == Fast.EB.WKF.Engine.SignResult.Approve)
            {
                DataRow row = l_MANAGER.NewRow();
                row["GUID"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='GUID']").Attributes["fieldValue"].Value;
                //自訂欄位的寫法
                row["SMID"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='Assiatan_Manager']/FieldValue").Attributes["SMID"].Value;  
                row["KPI_Performance"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='Assiatan_Manager']/FieldValue").Attributes["KPI_Performance"].Value;             
                row["KPI_Ploy"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='Assiatan_Manager']/FieldValue").Attributes["KPI_Ploy"].Value;             
                row["KPI_Improve"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='Assiatan_Manager']/FieldValue").Attributes["KPI_Improve"].Value;               
                row["Cooperation"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='Assiatan_Manager']/FieldValue").Attributes["Cooperation"].Value;             
                row["Subordinate"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='Assiatan_Manager']/FieldValue").Attributes["Subordinate"].Value;          
                row["Risk"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='Assiatan_Manager']/FieldValue").Attributes["Risk"].Value;          
                row["Communication"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='Assiatan_Manager']/FieldValue").Attributes["Communication"].Value;        
                row["Attitude"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='Assiatan_Manager']/FieldValue").Attributes["Attitude"].Value;
                row["Total"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='Assiatan_Manager']/FieldValue").Attributes["Total"].Value;
                row["RANK"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='Assiatan_Manager']/FieldValue").Attributes["RANK"].Value;             
                row["SIGNER"] = Current.Name;
                row["EDIT_DATE"] = DateTime.Today.ToString("yyyy/MM/dd");
                row["TASK_ID"] = applyTask.TaskId;
                row["SITE_CODE"] = applyTask.SiteCode;
                int l_int月份 = DateTime.Today.Month;
                //非年終不用進去
                if (l_int月份 > 9 || l_int月份 < 3)
                {
                    row["KPI_Performance_Y"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='Assiatan_Manager']/FieldValue").Attributes["KPI_Performance_Y"].Value;
                    row["KPI_Ploy_Y"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='Assiatan_Manager']/FieldValue").Attributes["KPI_Ploy_Y"].Value;
                    row["KPI_Improve_Y"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='Assiatan_Manager']/FieldValue").Attributes["KPI_Improve_Y"].Value;
                    row["Cooperation_Y"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='Assiatan_Manager']/FieldValue").Attributes["Cooperation_Y"].Value;
                    row["Subordinate_Y"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='Assiatan_Manager']/FieldValue").Attributes["Subordinate_Y"].Value;
                    row["Risk_Y"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='Assiatan_Manager']/FieldValue").Attributes["Risk_Y"].Value;
                    row["Communication_Y"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='Assiatan_Manager']/FieldValue").Attributes["Communication_Y"].Value;
                    row["Attitude_Y"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='Assiatan_Manager']/FieldValue").Attributes["Attitude_Y"].Value;
                    row["Staff_Car"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='Assiatan_Manager']/FieldValue").Attributes["Staff_Car"].Value;
                    row["Total_Y"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='Assiatan_Manager']/FieldValue").Attributes["Total_Y"].Value;
                    row["RANK_Y"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='Assiatan_Manager']/FieldValue").Attributes["RANK_Y"].Value;
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
                DataTable l_dt = l_MANAGER.getDatsByID(applyTask.TaskId, applyTask.SiteCode);
                if (l_dt != null && l_dt.Rows.Count > 0)
                {
                    l_MANAGER.UpdateByTASKID(row);
                }
                else
                {
                    l_MANAGER.Insert(row);
                }

                //xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='Assiatan_Manager']").InnerXml = "";
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
