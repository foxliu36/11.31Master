using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using KDUOFLib.HR.UCO;
using System.Data;

namespace KDUOFLib.Trigger.HR
{
    class EndFormTriggerbyStaff : Fast.EB.WKF.ExternalUtility.ICallbackTriggerPlugin
    {
        #region ICallbackTriggerPlugin 成員

        public void Finally()
        {
           
        }

        public string GetFormResult(Fast.EB.WKF.ExternalUtility.ApplyTask applyTask)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(applyTask.CurrentDocXML);
            CTB_HR_PERTUCO l_pert = new CTB_HR_PERTUCO();
            string l_FormID = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='FormID']").Attributes["fieldValue"].Value;
             //訂單需要同意才進入
            if (applyTask.FormResult == Fast.EB.WKF.Engine.ApplyResult.Adopt)
            {
                string l_str考核種類 = "";
                DataRow l_row = l_pert.NewRow();
                l_row["PERTNO"] = Guid.NewGuid().ToString();
                l_row["GUID"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='FormID']").Attributes["fieldValue"].Value;
                string l_strTaskid = applyTask.TaskId;
                CTB_HR_ASSESS_STAFF_UCO l_STAFF = new CTB_HR_ASSESS_STAFF_UCO();
                DataTable dt = l_STAFF.getlast(l_strTaskid);
                l_row["SMID"] = dt.Rows[0]["SMID"].ToString();
                string l_strSMID = dt.Rows[0]["SMID"].ToString();
                l_row["RANK"] = dt.Rows[0]["RANK"].ToString();
                int l_int月份 = DateTime.Today.Month;
                if (l_int月份 > 9 || l_int月份 < 3)
                {
                    l_row["ASSESS_TYPE"] = "年終";
                    l_row["RANK_Y"] = dt.Rows[0]["RANK_Y"].ToString();
                    l_str考核種類 = "年終";
                }
                else if (2 < l_int月份 && l_int月份 < 7)
                {
                    l_row["ASSESS_TYPE"] = "端午";
                    l_str考核種類 = "端午";
                }
                else if (6 < l_int月份 && l_int月份 < 10)
                {
                    l_row["ASSESS_TYPE"] = "中秋";
                    l_str考核種類 = "中秋";
                }
                l_row["Form_TYPE"] = "課長級以下";
                l_row["EDIT_DATE"] = DateTime.Today.ToString("yyyy/MM/dd");
                l_row["YEAR"] = DateTime.Today.Year.ToString();
                l_row["TASK_ID"] = applyTask.TaskId;
                string l_年度 = DateTime.Today.Year.ToString();
                DataTable l_dt = l_pert.check(l_strSMID, l_str考核種類, l_年度);
                if (l_dt != null && l_dt.Rows.Count > 0)
                {
                    return "";
                }
                else
                {
                    l_pert.Insert(l_row);
                }
            }
            //訂單否決刪除單子
            else
            {
                //刪除明細檔
                CTB_HR_ASSESS_STAFF_DETAILUCO l_STAFF_DETAIL = new CTB_HR_ASSESS_STAFF_DETAILUCO();
                l_STAFF_DETAIL.DeletebyReject(l_FormID);
                CTB_HR_ASSESS_STAFF_UCO l_STAFF = new CTB_HR_ASSESS_STAFF_UCO();
                l_STAFF.DeletebyReject(applyTask.TaskId);
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
