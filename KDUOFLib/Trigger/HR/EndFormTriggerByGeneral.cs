using System;
using System.Collections.Generic;
using System.Text;
using Fast.EB.WKF.ExternalUtility;
using System.Xml;
using KDUOFLib.HR.UCO;
using System.Data;

namespace KDUOFLib.Trigger.HR
{
    public class EndFormTriggerByGeneral : ICallbackTriggerPlugin
    {
        public void Finally()
        {
            throw new NotImplementedException();
        }

        public string GetFormResult(ApplyTask applyTask)
        {
            if (applyTask.FormResult == Fast.EB.WKF.Engine.ApplyResult.Adopt)
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(applyTask.CurrentDocXML);
                CPERTUCO CPERTUCO = new CPERTUCO();
                DataRow row = CPERTUCO.NewRow();
                row["GUID"] = Guid.NewGuid().ToString();
                row["ASSESS_TYPE"] = KDUOFLib.Utility.getASSESS_TYPE(DateTime.Today);
                row["SMID"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='number']").Attributes["fieldValue"].Value.ToUpper();
                row["OTHER_PERT1"] = Convert.ToInt32("0" + xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='PERT1']").Attributes["fieldValue"].Value);
                row["OTHER_PERT2"] = Convert.ToInt32("0" + xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='PERT2']").Attributes["fieldValue"].Value);
                row["OTHER_PERT3"] = Convert.ToInt32("0" + xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='PERT3']").Attributes["fieldValue"].Value);
                row["OTHER_PERT4"] = Convert.ToInt32("0" + xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='PERT4']").Attributes["fieldValue"].Value);
                row["OTHER_PERT5"] = Convert.ToInt32("0" + xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='PERT5']").Attributes["fieldValue"].Value);
                row["OTHER_PERT6"] = Convert.ToInt32("0" + xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='PERT6']").Attributes["fieldValue"].Value);
                row["OTHER_PERT7"] = Convert.ToInt32("0" + xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='PERT7']").Attributes["fieldValue"].Value);
                row["OTHER_PERT8"] = Convert.ToInt32("0" + xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='PERT8']").Attributes["fieldValue"].Value);
                row["OTHER_PERT9"] = Convert.ToInt32("0" + xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='PERT9']").Attributes["fieldValue"].Value);
                row["PERT"] = Convert.ToInt32("0" + xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='PERT']").Attributes["fieldValue"].Value);
                string l_strPERT_LEVEL1 = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='LEVEL1']").Attributes["fieldValue"].Value;
                string l_strPERT_LEVEL2 = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='LEVEL2']").Attributes["fieldValue"].Value;
                row["PERT_LEVEL1"] = l_strPERT_LEVEL1.Substring(0, l_strPERT_LEVEL1.IndexOf("_"));
                row["PERT_LEVEL2"] = l_strPERT_LEVEL2.Substring(0, l_strPERT_LEVEL2.IndexOf("@"));
                try
                {
                    string l_strPERT_LEVEL3 = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='LEVEL3']").Attributes["fieldValue"].Value;
                    if (!String.IsNullOrEmpty(l_strPERT_LEVEL3))
                    {
                        row["PERT_LEVEL3"] = l_strPERT_LEVEL3.Substring(0, l_strPERT_LEVEL3.IndexOf("@"));
                    }
                }
                catch { row["PERT_LEVEL3"] = ""; }
                row["EDIT_DATE"] = DateTime.Today.ToString("yyyy/MM/dd");
                row["PAPER_TYPE"] = KDUOFLib.Utility.getPAPER_TYPE(applyTask.Task.FormName);
                row["TASK_ID"] = applyTask.TaskId;
                row["DOC_NBR"] = applyTask.FormNumber;
                CPERTUCO.Insert(row);
            }
            return "";
        }

        public void OnError(Exception errorException)
        {
            throw new NotImplementedException();
        }
    }
}
