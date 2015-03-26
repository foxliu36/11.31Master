using System;
using System.Collections.Generic;
using System.Text;
using Fast.EB.WKF.ExternalUtility;
using System.Xml;
using KDUOFLib.PET.UCO;
using System.Data;
using SlnKDCOMLIB.common;

namespace KDUOFLib.Trigger.PET.PetBySale
{
    public class EndFormTrigger : ICallbackTriggerPlugin
    {
        #region ICallbackTriggerPlugin 成員

        public void Finally()
        {

        }

        public string GetFormResult(ApplyTask applyTask)
        {
            if (applyTask.FormResult == Fast.EB.WKF.Engine.ApplyResult.Adopt)
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(applyTask.CurrentDocXML);
                string ORDERNO = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='data']/FieldValue").Attributes["ORDERNO"].Value;
                CPetitionUCO petitionuco =  new CPetitionUCO();
                DataTable petitiondt = petitionuco.QueryPetition(ORDERNO);
                if (petitiondt.Rows.Count == 0)
                {
                    throw new Exception("資料錯亂，請洽管理員！");
                }
                DataRow row = petitiondt.Rows[0];
                row["ORDERNO"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='data']/FieldValue").Attributes["ORDERNO"].Value;
                row["SMID"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='data']/FieldValue").Attributes["SMID"].Value;
                row["PET_TYPE"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='data']/FieldValue").Attributes["PET_TYPE"].Value;
                row["COM_NAME"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='data']/FieldValue").Attributes["COM_NAME"].Value;
                row["COM_PHONE"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='data']/FieldValue").Attributes["COM_PHONE"].Value;
                row["COM_ADD"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='data']/FieldValue").Attributes["COM_ADD"].Value;
                row["COM_ID"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='data']/FieldValue").Attributes["COM_ID"].Value;
                row["COM_DATE"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='data']/FieldValue").Attributes["COM_DATE"].Value;
                row["PEO_NAME"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='data']/FieldValue").Attributes["PEO_NAME"].Value;
                row["PEO_SEX"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='data']/FieldValue").Attributes["PEO_SEX"].Value;
                row["PEO_ID"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='data']/FieldValue").Attributes["PEO_ID"].Value;
                row["PEO_MERRY"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='data']/FieldValue").Attributes["PEO_MERRY"].Value;
                row["PEO_PHONE"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='data']/FieldValue").Attributes["PEO_PHONE"].Value;
                row["PEO_MOBILE"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='data']/FieldValue").Attributes["PEO_MOBILE"].Value;
                row["PEO_BIRTHDAY"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='data']/FieldValue").Attributes["PEO_BIRTHDAY"].Value;
                row["PEO_ADD"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='data']/FieldValue").Attributes["PEO_ADD"].Value;
                row["PEO_REPORT_ADD"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='data']/FieldValue").Attributes["PEO_REPORT_ADD"].Value;
                row["SER_NAME"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='data']/FieldValue").Attributes["SER_NAME"].Value;
                row["SER_ADD"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='data']/FieldValue").Attributes["SER_ADD"].Value;
                row["SER_YEAR"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='data']/FieldValue").Attributes["SER_YEAR"].Value;
                row["SER_JOB"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='data']/FieldValue").Attributes["SER_JOB"].Value;
                row["SER_PHONE"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='data']/FieldValue").Attributes["SER_PHONE"].Value;
                row["HOUSE_ADD"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='data']/FieldValue").Attributes["HOUSE_ADD"].Value;
                row["HOUSE_NUM"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='data']/FieldValue").Attributes["HOUSE_NUM"].Value;
                row["HOUSE_BUILD"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='data']/FieldValue").Attributes["HOUSE_BUILD"].Value;
                row["HOUSE_NAME"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='data']/FieldValue").Attributes["HOUSE_NAME"].Value;
                row["HOUSE_ID"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='data']/FieldValue").Attributes["HOUSE_ID"].Value;
                row["CREDIT_MONEY"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='data']/FieldValue").Attributes["CREDIT_MONEY"].Value;
                row["CREDIT_PHASES"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='data']/FieldValue").Attributes["CREDIT_PHASES"].Value;
                row["MONTH_MONEY"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='data']/FieldValue").Attributes["MONTH_MONEY"].Value;
                row["SUBSIDIES_MONEY"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='data']/FieldValue").Attributes["SUBSIDIES_MONEY"].Value;
                row["PET_RATE"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='data']/FieldValue").Attributes["PET_RATE"].Value;
                row["PET_SEVERAL"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='data']/FieldValue").Attributes["PET_SEVERAL"].Value;
                row["PET_MONEY"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='data']/FieldValue").Attributes["PET_MONEY"].Value;
                row["PET_SUBSIDIES"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='data']/FieldValue").Attributes["PET_SUBSIDIES"].Value;
                row["PAY_TYPE"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='data']/FieldValue").Attributes["PAY_TYPE"].Value;
                row["CAR_REASON"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='data']/FieldValue").Attributes["CAR_REASON"].Value;
                row["CAR_USER"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='data']/FieldValue").Attributes["CAR_USER"].Value;
                row["PET_RESULT"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='data']/FieldValue").Attributes["MEMO"].Value;
                row["TASK_ID"] = applyTask.TaskId;
                row["DOC_NBR"] = applyTask.FormNumber;
                row["TASK_RESULT"] = (int)applyTask.FormResult;
                petitionuco.UpdatePETITIONAfterWKF(row);
            }
            return "";
        }

        public void OnError(Exception errorException)
        {

        }

        #endregion
    }
}
