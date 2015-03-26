using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using KDUOFLib.HR.UCO;
using System.Data;

namespace KDUOFLib.Trigger.HR.OffDuty
{
    class OnFormTriggerOffDuty : Fast.EB.WKF.ExternalUtility.ICallbackTriggerPlugin
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

            //訂單需要同意才進入
            if (applyTask.FormResult == Fast.EB.WKF.Engine.ApplyResult.Adopt)
            {
            }
            else
            {
                string l_EMPNO = node.Attributes["EMPNO"].Value;
                OffDutyUCO.DeleteData(l_EMPNO);
            }

            return "";
        }

        public void OnError(Exception errorException)
        {
            throw new NotImplementedException();
        }
    }
}
