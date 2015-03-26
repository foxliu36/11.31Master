using System;
using System.Collections.Generic;
using System.Text;
using KDUOFLib.HR.UCO;
using System.Xml;
using System.Data;
using Fast.EB.SystemInfo;

namespace KDUOFLib.Trigger.HR.Nuclear_Salary
{
    public class EndFromTriggerByNSUpload : Fast.EB.WKF.ExternalUtility.ICallbackTriggerPlugin
    {
        #region ICallbackTriggerPlugin 成員

        public void Finally()
        {
        }

        public string GetFormResult(Fast.EB.WKF.ExternalUtility.ApplyTask applyTask)
        {
            CTB_HR_Nuclear_Salary_UCO l_Nuclear_Salary_UCO = new CTB_HR_Nuclear_Salary_UCO();
            CTB_HR_NS_TempUCO l_Temp = new CTB_HR_NS_TempUCO();

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(applyTask.CurrentDocXML);
            XmlNode node = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='NS_upload']/FieldValue");
            string l_NS_GUID = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='NS_GUID']").Attributes["fieldValue"].Value;

            //訂單需要同意才進入
            if (applyTask.FormResult == Fast.EB.WKF.Engine.ApplyResult.Adopt)
            {
               DataTable l_dt = l_Temp.getData(l_NS_GUID);
                for (int i = 0; i < l_dt.Rows.Count; i++)
                {
                    string l_strAccoiun = l_dt.Rows[i]["ACCOUNT"].ToString();
                    string l_US_GUID = l_Temp.getUS_GUIDbyACCOUNT(l_strAccoiun);
                        DataRow l_row = l_Nuclear_Salary_UCO.NewRow();
                        l_row["TASK_ID"] = applyTask.TaskId;
                        l_row["NS_GUID"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='NS_GUID']").Attributes["fieldValue"].Value;
                        l_row["Creat_Date"] = DateTime.Today;
                        l_row["SINGER"] = Current.Name;

                        l_row["USER_GUID"] = l_US_GUID;
                        l_row["NS_Year"] = node.Attributes["NS_Year"].Value;
                        l_row["NS_Month"] = node.Attributes["NS_Month"].Value;
                        l_row["CLASS"] = l_dt.Rows[i]["CLASS"].ToString();
                        l_row["MOVE_DATE"] = l_dt.Rows[i]["MOVE_DATE"].ToString();
                        l_row["MOVE_TYPE"] = TurnWord(l_dt.Rows[i]["MOVE_TYPE"].ToString());
                        l_row["MEMO"] = l_dt.Rows[i]["MEMO"].ToString();
                        l_row["Group_Name"] = l_dt.Rows[i]["Group_Name"].ToString();
                        l_row["TITLE_NAME"] = l_dt.Rows[i]["TITLE_NAME"].ToString();
                        l_row["OPTION1"] = l_dt.Rows[i]["OPTION1"].ToString();
                        l_row["Base_Salary"] = l_dt.Rows[i]["Base_Salary"].ToString();
                        l_row["Food_Allowance"] = l_dt.Rows[i]["Food_Allowance"].ToString();
                        l_row["Full_Bonus"] = l_dt.Rows[i]["Full_Bonus"].ToString();
                        l_row["Position_Bonus"] = l_dt.Rows[i]["Position_Bonus"].ToString();
                        l_row["Learder_Bonus"] = l_dt.Rows[i]["Learder_Bonus"].ToString();
                        l_row["Skill_Bonus"] = l_dt.Rows[i]["Skill_Bonus"].ToString();
                        l_row["License_Bonus"] = l_dt.Rows[i]["License_Bonus"].ToString();
                        l_row["Experience_Bonus"] = l_dt.Rows[i]["Experience_Bonus"].ToString();
                        l_row["Other_Bonus"] = l_dt.Rows[i]["Other_Bonus"].ToString();
                        l_row["Bonus_Sum"] = l_dt.Rows[i]["Bonus_Sum"].ToString();

                        l_Nuclear_Salary_UCO.Insert(l_row);
                    }
                             

            }
            //訂單否決刪除單子
            else
            {
                l_Nuclear_Salary_UCO.Delete(applyTask.TaskId);
                l_Temp.DeletebyNS_GUID(l_NS_GUID);
            }

            return "";
        }

        public void OnError(Exception errorException)
        {
            throw new NotImplementedException();
        }

        private string TurnWord(string p_異動原因)
        {
            string l_異動原因 = "";
            switch (p_異動原因)
            {
                case "人令異動": l_異動原因 = "M"; break;
                case "其他異動": l_異動原因 = "O"; break;
                case "新進人員": l_異動原因 = "N"; break;

                default: break;
            }
            return l_異動原因;
        }

        #endregion
    }
}
