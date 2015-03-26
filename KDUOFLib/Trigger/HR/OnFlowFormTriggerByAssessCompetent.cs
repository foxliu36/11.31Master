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
    public class OnFlowFormTriggerByAssessCompetent : Fast.EB.WKF.ExternalUtility.ICallbackTriggerPlugin
    {

        #region ICallbackTriggerPlugin 成員

        public void Finally()
        {

        }

        public string GetFormResult(Fast.EB.WKF.ExternalUtility.ApplyTask applyTask)
        {

            //<Form formVersionId="86bd41c0-7a8f-4c16-b0cb-08b84da7f0e1">
            //  <FormFieldValue>
            //    <FieldItem fieldId="Assess-Compettent" fieldValue="WKF121000001" realValue="" />
            //    <FieldItem fieldId="Competent" ConditionValue="" realValue="">
            //      <FieldValue KPI_Performance="" KPI_Ploy="" KPI_Improve=""
            //Communication="" Attitude="" Cooperation="" Subordinate="" Risk=""
            //CS="" Staff_Car="" total="" grade="" />
            //    </FieldItem>
            //  </FormFieldValue>
            //</Form>


            if (applyTask.SignResult == Fast.EB.WKF.Engine.SignResult.Approve)     //簽核中需要同意才進入
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(applyTask.CurrentDocXML);

                XmlNode node = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='Competent']/FieldValue");
                CTB_HR_ASSESS_COMPTENT_DETAILUCO l_detail = new CTB_HR_ASSESS_COMPTENT_DETAILUCO();
                DataRow row = l_detail.NewRow();
                row["GUID"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='GUID']").Attributes["fieldValue"].Value;
                
                //自訂欄位的寫法
                row["SMID"] = node.Attributes["SMID"].Value;
                row["KPI_Performance"] = node.Attributes["KPI_Performance"].Value;
                row["KPI_Ploy"] = node.Attributes["KPI_Ploy"].Value;
                row["KPI_Improve"] = node.Attributes["KPI_Improve"].Value;
                row["Communication"] = node.Attributes["Communication"].Value;
                row["Attitude"] = node.Attributes["Attitude"].Value;
                row["Cooperation"] = node.Attributes["Cooperation"].Value;
                row["Subordinate"] = node.Attributes["Subordinate"].Value;
                row["Risk"] = node.Attributes["Risk"].Value;
                row["CS"] = node.Attributes["CS"].Value;
                if (String.IsNullOrEmpty(node.Attributes["Staff_Car"].Value))
                {
                    node.Attributes["Staff_Car"].Value = "0";
                }
                row["Staff_Car"] = node.Attributes["Staff_Car"].Value;
                row["TOTAL"] = node.Attributes["Total"].Value;
                row["RANK_Y"] = node.Attributes["RANK_Y"].Value;
                row["SIGNER"] = Current.Name;
                row["TASK_ID"] = applyTask.TaskId;
                row["SITE_CODE"] = applyTask.SiteCode;
                row["EDIT_DATE"] = DateTime.Today.ToString("yyyy/MM/dd");
                int l_int月份 = DateTime.Today.Month;
                if (l_int月份 > 9 || l_int月份 < 3)
                {
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

                DataTable l_dt = l_detail.getDatsByID(applyTask.TaskId, applyTask.SiteCode);
                if (l_dt != null && l_dt.Rows.Count > 0)
                {
                    l_detail.UpdateByTASKID(row);
                }
                else
                {
                    l_detail.Insert(row);
                }


                //xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='Competent']").InnerXml = "";
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
