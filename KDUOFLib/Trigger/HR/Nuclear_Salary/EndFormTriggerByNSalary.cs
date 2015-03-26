using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using KDUOFLib.HR.UCO;
using System.Data;
using Fast.EB.SystemInfo;

namespace KDUOFLib.Trigger.HR.Nuclear_Salary
{
    class EndFormTriggerByNSalary : Fast.EB.WKF.ExternalUtility.ICallbackTriggerPlugin
    {
        #region ICallbackTriggerPlugin 成員

        public void Finally()
        {
            
        }

        public string GetFormResult(Fast.EB.WKF.ExternalUtility.ApplyTask applyTask)
        {
            CTB_HR_Nuclear_Salary_UCO l_Nuclear_Salary_UCO = new CTB_HR_Nuclear_Salary_UCO();
            //訂單需要同意才進入
            if (applyTask.FormResult == Fast.EB.WKF.Engine.ApplyResult.Adopt)
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(applyTask.CurrentDocXML);
                XmlNode node = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='Nuclear_Salary']/FieldValue");

                DataRow l_row = l_Nuclear_Salary_UCO.NewRow();
                l_row["TASK_ID"] = applyTask.TaskId;
                l_row["NS_GUID"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='NS_GUID']").Attributes["fieldValue"].Value;
                l_row["Creat_Date"] = DateTime.Today;
                l_row["SINGER"] = Current.Name;

                //自訂欄位的寫法
                l_row["USER_GUID"] = node.Attributes["USER_GUID"].Value;
                l_row["CLASS"] = node.Attributes["CLASS"].Value;
                l_row["MOVE_DATE"] = node.Attributes["MOVE_DATE"].Value;
                l_row["MOVE_TYPE"] = node.Attributes["MOVE_TYPE"].Value;
                string l_MOVE_TYPE = node.Attributes["MOVE_TYPE"].Value;
                l_row["MEMO"] = node.Attributes["MEMO"].Value;
                l_row["NS_Year"] = node.Attributes["NS_Year"].Value;
                l_row["NS_Month"] = node.Attributes["NS_Month"].Value;
                if (l_MOVE_TYPE == "N")
                {
                    l_row["Labor_Protectoin"] = node.Attributes["Labor_Protectoin"].Value;
                    l_row["Health_Insurance"] = node.Attributes["Health_Insurance"].Value;
                    l_row["Labor_Pension"] = node.Attributes["Labor_Pension"].Value;
                    l_row["Group_Insurance"] = node.Attributes["Group_Insurance"].Value;
                    l_row["Buraden_Sum"] = node.Attributes["Buraden_Sum"].Value;
                }
                else if (l_MOVE_TYPE == "M")
                {
                    l_row["Posting_Year"] = node.Attributes["Posting_Year"].Value;
                    l_row["Posting_Number"] = node.Attributes["Posting_Number"].Value;
                }
                else if (l_MOVE_TYPE == "O")
                {
                    l_row["Other_Move"] = node.Attributes["Other_Move"].Value;
                }
                l_row["Group_Name"] = node.Attributes["Group_Name"].Value;
                l_row["TITLE_NAME"] = node.Attributes["TITLE_NAME"].Value;
                l_row["OPTION1"] = node.Attributes["OPTION1"].Value;
                l_row["Base_Salary"] = node.Attributes["Base_Salary"].Value;
                l_row["Food_Allowance"] = node.Attributes["Food_Allowance"].Value;
                l_row["Full_Bonus"] = node.Attributes["Full_Bonus"].Value;
                l_row["Position_Bonus"] = node.Attributes["Position_Bonus"].Value;
                l_row["Learder_Bonus"] = node.Attributes["Learder_Bonus"].Value;
                l_row["Skill_Bonus"] = node.Attributes["Skill_Bonus"].Value;
                l_row["License_Bonus"] = node.Attributes["License_Bonus"].Value;
                l_row["Experience_Bonus"] = node.Attributes["Experience_Bonus"].Value;
                l_row["Other_Bonus"] = node.Attributes["Other_Bonus"].Value;
                l_row["Bonus_Sum"] = node.Attributes["Bonus_Sum"].Value;

                l_Nuclear_Salary_UCO.Insert(l_row);
            }

            //訂單否決刪除單子
            else
            {
                l_Nuclear_Salary_UCO.Delete(applyTask.TaskId);
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
