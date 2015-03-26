using System;
using System.Collections.Generic;
using System.Text;
using Fast.EB.WKF.ExternalUtility;
using System.Xml;
using KDUOFLib.REW.UCO;
using System.Data;
using Fast.EB.SystemInfo;

namespace KDUOFLib.Trigger.REW.RewBySale
{
    public class EndFormTriggerBySaleDoc : ICallbackTriggerPlugin
    {

        #region ICallbackTriggerPlugin 成員

        public void Finally()
        {

        }

        public string GetFormResult(ApplyTask applyTask)
        {
      
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(applyTask.CurrentDocXML);
            CSaleDocUCO SaleDocUCO = new CSaleDocUCO();
            DataRow row = SaleDocUCO.NewRow();

            row["ORDERNO"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='data']/FieldValue").Attributes["ORDERNO"].Value;
            row["INSURANCE_COM_ITEM"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='data']/FieldValue").Attributes["INSURANCE_COM_ITEM"].Value;
            row["INSURANCE_NUM"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='data']/FieldValue").Attributes["INSURANCE_NUM"].Value;
            row["OLDCAR"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='data']/FieldValue").Attributes["OLDCAR"].Value;
            row["INSURANCE_ITME"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='data']/FieldValue").Attributes["INSURANCE_ITME"].Value;
            row["INVOICE_FILE"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='data']/FieldValue").Attributes["INVOICE_FILE"].Value;
            row["CREATE_DATE"] = DateTime.Today;
            row["CREATOR"] = Current.Account;
            row["STATUS"] = 0;
            row["DISCOUNT_MONEY"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='data']/FieldValue").Attributes["DISCOUNT_MONEY"].Value;
            row["SUBSIDIES_MONEY"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='data']/FieldValue").Attributes["SUBSIDIES_MONEY"].Value;
            row["INVOICE_MONEY"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='data']/FieldValue").Attributes["INVOICE_MONEY"].Value;
            SaleDocUCO.Insert(row);
            return "";
        }

        public void OnError(Exception errorException)
        {

        }

        #endregion
    }
}
