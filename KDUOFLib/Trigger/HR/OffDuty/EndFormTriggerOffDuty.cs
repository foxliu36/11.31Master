using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using KDUOFLib.HR.UCO;
using System.Data;

/*** Design by fox ***/
namespace KDUOFLib.Trigger.HR.OffDuty
{
    public class EndFormTriggerOffDuty : Fast.EB.WKF.ExternalUtility.ICallbackTriggerPlugin        
    {
        public void Finally()
        {
            
        }

        public string GetFormResult(Fast.EB.WKF.ExternalUtility.ApplyTask applyTask)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(applyTask.CurrentDocXML);

            CTB_HR_OffDuty_UCO OffDutyUCO = new CTB_HR_OffDuty_UCO();

            XmlNode node = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='OffDutyPaper']/FieldValue");

            //表單需要起單就進入
            if (applyTask.FormResult == Fast.EB.WKF.Engine.ApplyResult.UnKnow)
            {   
                DataRow dr = OffDutyUCO.NewRow();

                dr["Sid"] = Guid.NewGuid().ToString();
                dr["EmpNo"] = node.Attributes["EMPNO"].Value;
                dr["Name"] = node.Attributes["NAME"].Value;
                dr["Unit"] = node.Attributes["UNIT"].Value;
                dr["Title"] = node.Attributes["TITLE"].Value;
                dr["OnDutyDate"] = node.Attributes["ONDUTYDATE"].Value;
                dr["OffDutyDate"] = node.Attributes["OFFDUTYDATE"].Value;
                dr["Phone"] = node.Attributes["PHONE"].Value;
                dr["CellPhone"] = node.Attributes["CELLPHONE"].Value;
                dr["Address"] = node.Attributes["ADDRESS"].Value;
                dr["Reason"] = node.Attributes["REASON"].Value;
                string memo = "";
                for (int i = 1; i <= 10; i++)
                {
                    if (node.Attributes["CB"+i].Value.Equals("true"))
                    {
                        memo += i + "_";
                    }
                }
                dr["Memo"] = memo;

                OffDutyUCO.InsertData(dr);
                
            }

            return "";
        }

        public void OnError(Exception errorException)
        {
            throw errorException;
        }
    }
}
