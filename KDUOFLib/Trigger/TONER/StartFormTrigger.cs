using System;
using System.Collections.Generic;
using System.Text;
using Fast.EB.WKF.ExternalUtility;
using System.Xml;
using KDUOFLib.TONER.UCO;
using System.Data;

namespace KDUOFLib.Trigger.TONER
{
    public class StartFormTrigger : ICallbackTriggerPlugin
    {
        #region ICallbackTriggerPlugin 成員

        public void Finally()
        {

        }

        public string GetFormResult(ApplyTask applyTask)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(applyTask.CurrentDocXML);
            COrderUCO COrderUCO = new COrderUCO();
            
            //訂單需要同意才進入
            if (applyTask.FormResult == Fast.EB.WKF.Engine.ApplyResult.Adopt)
            {
                DataRow row = COrderUCO.NewRow();
                row["f_orderno"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='f_orderno']").Attributes["fieldValue"].Value;
                row["f_unit"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='f_unit']").Attributes["fieldValue"].Value;
                row["f_EMP"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='f_EMP']").Attributes["fieldValue"].Value;
                row["f_empid"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='f_empid']").Attributes["fieldValue"].Value;
                row["f_phone"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='f_phone']").Attributes["fieldValue"].Value;
                row["f_title"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='f_title']").Attributes["fieldValue"].Value;
                row["f_editday"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='f_editday']").Attributes["fieldValue"].Value;
                row["f_memo"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='f_memo']").Attributes["fieldValue"].Value;
                //以下為自訂表單設計寫法
                //row["f_editday"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='data']/FieldValue").Attributes["f_editday"].Value;
                //row["f_memo"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='data']/FieldValue").Attributes["f_memo"].Value;
                row["TASK_ID"] = applyTask.TaskId;
                row["DOC_NBR"] = applyTask.FormNumber;


                //            <Form formVersionId="9bb3b460-be3a-4c64-966b-d96f51994c13">
                //  <FormFieldValue>
                //    <FieldItem fieldId="f_orderno" fieldValue="" realValue="" />
                //    <FieldItem fieldId="f_editday" fieldValue="2012/06/26" realValue="" fillerName="柯美如" fillerUserGuid="3946ad43-b66f-4abd-a6a6-84a755080f1d" fillerAccount="EA001" fillSiteId="" />
                //    <FieldItem fieldId="f_empid" fieldValue="柯美如" realValue="" />
                //    <FieldItem fieldId="f_unit" fieldValue="資訊室" realValue="435b7eb3-1f24-0d16-42e3-2841ad415fe9,資訊室,False" />
                //    <FieldItem fieldId="det" fillerName="柯美如" fillerUserGuid="3946ad43-b66f-4abd-a6a6-84a755080f1d" fillerAccount="EA001" fillSiteId="">
                //      <DataGrid>
                //        <Row order="0">
                //          <Cell fieldId="f_proname" fieldValue="其他" realValue="" />
                //          <Cell fieldId="f_amount" fieldValue="1" realValue="" />
                //          <Cell fieldId="f_reason" fieldValue="測試" realValue="" />
                //        </Row>
                //      </DataGrid>
                //    </FieldItem>
                //    <FieldItem fieldId="f_memo" fieldValue="" realValue="" fillerName="柯美如" fillerUserGuid="3946ad43-b66f-4abd-a6a6-84a755080f1d" fillerAccount="EA001" fillSiteId="" />
                //  </FormFieldValue>
                //</Form> 
                double l_dou總額 = 0;
                double l_dou數量 = 0;
                COrderdetailUCO COrderdetailUCO = new COrderdetailUCO();
                string l_str名稱 = "";
                //判斷明細有資料列
                if (xmlDoc.SelectNodes("/Form/FormFieldValue/FieldItem[@fieldId='det']/DataGrid/Row") != null)
                {
                    //取得列
                    XmlNodeList sequenceCode = xmlDoc.SelectNodes("/Form/FormFieldValue/FieldItem[@fieldId='det']/DataGrid/Row");
                    //取得欄
                    foreach (XmlNode xmlN in sequenceCode)
                    {
                        DataRow l_row = COrderdetailUCO.NewRow();
                        l_row["f_proname"] = xmlN.SelectSingleNode("./Cell[@fieldId='f_proname']").Attributes["fieldValue"].Value; ;
                        l_str名稱 = l_row["f_proname"].ToString();
                        double l_dou單價 = probyname(l_str名稱);
                        l_row["f_amount"] = xmlN.SelectSingleNode("./Cell[@fieldId='f_amount']").Attributes["fieldValue"].Value;
                        l_dou數量 = Convert.ToDouble(l_row["f_amount"]);
                        l_row["f_reason"] = xmlN.SelectSingleNode("./Cell[@fieldId='f_reason']").Attributes["fieldValue"].Value;
                        l_row["f_orderno"] = row["f_orderno"];
                        l_row["f_price"] = l_dou單價;
                        l_dou總額 += (l_dou單價 * l_dou數量);

                        COrderdetailUCO.Insert(l_row);
                    }
                }

                row["f_total"] = l_dou總額;

                COrderUCO.Insert(row);
            }

            return "";



        }

        public void OnError(Exception errorException)
        {

        }

        private double probyname(string p_name)
        {
            CProjectUCO l_CProjectUCO = new CProjectUCO();
            DataTable l_dt = l_CProjectUCO.QueryDatasByProname(p_name);
            //因為確定只會有一筆資料，所以直接[0]，後面因為為DataTable所以需要手寫
            //l_dt.Rows[0]["f_price"];  ←此為確定的值
            double l_dou價錢 = Convert.ToDouble(l_dt.Rows[0]["f_price"]);

            return l_dou價錢;
        }




        #endregion
    }
}
