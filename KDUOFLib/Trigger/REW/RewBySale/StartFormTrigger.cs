using System;
using System.Collections.Generic;
using System.Text;
using Fast.EB.WKF.ExternalUtility;
using System.Xml;
using KDUOFLib.REW.UCO;
using System.Data;

namespace KDUOFLib.Trigger.REW.PetBySale
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
            CSpecialsaleUCO specialsaleUCO = new CSpecialsaleUCO();
            DataRow row = specialsaleUCO.NewRow();
            string ORDERNO = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='data']/FieldValue").Attributes["ORDERNO"].Value;
            row["ORDERNO"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='data']/FieldValue").Attributes["ORDERNO"].Value;
            row["INSURANCE_TYPE"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='data']/FieldValue").Attributes["INSURANCE_TYPE"].Value;
            row["SPECIAL_TYPE"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='data']/FieldValue").Attributes["SPECIAL_TYPE"].Value;
            row["APPLY_NUM"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='data']/FieldValue").Attributes["APPLY_NUM"].Value;
            row["DISCOUNT"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='data']/FieldValue").Attributes["DISCOUNT"].Value;
            row["PAY_TYPE"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='data']/FieldValue").Attributes["PAY_TYPE"].Value;
            row["BIG_TYPE"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='data']/FieldValue").Attributes["BIG_TYPE"].Value;
            row["MEMO"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='data']/FieldValue").Attributes["MEMO"].Value;
            row["CREATE_DATE"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='data']/FieldValue").Attributes["CREATE_DATE"].Value;
            row["CREATOR"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='data']/FieldValue").Attributes["Smid"].Value;
            row["STATUS"] = 0;
            row["TASK_ID"] = applyTask.TaskId;
            row["DOC_NBR"] = applyTask.FormNumber;
            row["SPECIAL_MONEY"] =xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='data']/FieldValue").Attributes["HARDCOVER_PRICE"].Value ;

            try
            {
                specialsaleUCO.Insert(row);
            }
            catch { }

            string rdoAPPLY_TYPE = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='data']/FieldValue").Attributes["rdoAPPLY_TYPE"].Value;
            string SPECIAL_TYPE = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='data']/FieldValue").Attributes["SPECIAL_TYPE"].Value;
            double APPLY_NUM_month = 0;
            try
            {
                APPLY_NUM_month = getApplyNum(xmlDoc, SPECIAL_TYPE, rdoAPPLY_TYPE);
            }
            catch { }

            if ("0".Equals(row["BIG_TYPE"].ToString()))//不是大口建材加入判斷
            {
                //20131002 新增須限制超過條件之單據
                if (Convert.ToInt32(row["APPLY_NUM"]) > APPLY_NUM_month)
                {
                    CSpecialCntUCO CSpecialCntUCO = new CSpecialCntUCO();
                    string l_strBranch = ORDERNO.Substring(1, 2);

                    string l_SaleDay = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='data']/FieldValue").Attributes["SaleDay"].Value;
                    DateTime SaleDay = DateTime.Today;
                    if (!String.IsNullOrEmpty(l_SaleDay))
                    {
                        SaleDay = Convert.ToDateTime(l_SaleDay);
                    }
                   
                    DataTable specialcnt = CSpecialCntUCO.QueryDatasByBranch(l_strBranch, SaleDay);

                    DataRow row_cnt = specialcnt.Rows[0];

                    row_cnt["CNT_NOW"] = Convert.ToInt32(row_cnt["CNT_NOW"]) + 1;

                    CSpecialCntUCO.Update(row_cnt);
                }
            }

            //因預設值有問題，故強制修改成值 2013/05/24 振益
 
            xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='is_up']").Attributes["fieldValue"].Value = "否";
            xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='type']").Attributes["fieldValue"].Value = "准";
            xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='last']").Attributes["fieldValue"].Value = "准";
            //2015/03/05 需給室的新需求
            CSpecialCntUCO CSpecialCntUCO2 = new CSpecialCntUCO();
            string l_saledate = CSpecialCntUCO2.QueryDate(ORDERNO);
            DateTime l_date = DateTime.Now;
            DateTime dt = DateTime.ParseExact(l_saledate, "yyyy/MM/dd HH:mm", null);
            TimeSpan ts = l_date - dt;  //TimeSpan為時間的幅度
            string l_money = "";
            if (ts.Days < 7)
            {
                l_money= "1500";
            }
            else
            {
                l_money = "1000";
            }
            
            xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='money']").Attributes["fieldValue"].Value = l_money;
            xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='part_num']").Attributes["fieldValue"].Value = "0";

            applyTask.Task.UpdateCurrentDoc(applyTask.TaskId, xmlDoc.OuterXml);
            return "";
        }

        public void OnError(Exception errorException)
        {

        }
        private double getApplyNum(XmlDocument xmlDoc, string p_SPECIAL_TYPE, string p_rdoAPPLY_TYPE)
        {
            double APPLY_NUM_MONTH = Convert.ToDouble(xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='data']/FieldValue").Attributes["APPLY_NUM_MONTH"].Value);
            double APPLY_NUM_MONTH_EMPTY = Convert.ToDouble(xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='data']/FieldValue").Attributes["APPLY_NUM_MONTH_EMPTY"].Value);
            double APPLY_NUM_25 = Convert.ToDouble(xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='data']/FieldValue").Attributes["APPLY_NUM_25"].Value);
            double APPLY_NUM_EMPTY_25 = Convert.ToDouble(xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='data']/FieldValue").Attributes["APPLY_NUM_EMPTY_25"].Value);
            double APPLY_NUM_GET = Convert.ToDouble(xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='data']/FieldValue").Attributes["APPLY_NUM_GET"].Value);
            double APPLY_NUM_EMPTY_GET = Convert.ToDouble(xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='data']/FieldValue").Attributes["APPLY_NUM_EMPTY_GET"].Value);
            double APPLY_NUM_IM = Convert.ToDouble(xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='data']/FieldValue").Attributes["APPLY_NUM_IM"].Value);
            double APPLY_NUM_EMPTY_IM = Convert.ToDouble(xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='data']/FieldValue").Attributes["APPLY_NUM_EMPTY_IM"].Value);
            double APPLY_NUM_TIC = Convert.ToDouble(xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='data']/FieldValue").Attributes["APPLY_NUM_TIC"].Value);
            double APPLY_NUM_EMPTY_TIC = Convert.ToDouble(xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='data']/FieldValue").Attributes["APPLY_NUM_EMPTY_TIC"].Value);
            double APPLY_NUM_25IM = Convert.ToDouble(xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='data']/FieldValue").Attributes["APPLY_NUM_25IM"].Value);
            double APPLY_NUM_EMPTY_25IM = Convert.ToDouble(xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='data']/FieldValue").Attributes["APPLY_NUM_EMPTY_25IM"].Value);
            double APPLY_NUM_25TIC = Convert.ToDouble(xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='data']/FieldValue").Attributes["APPLY_NUM_25TIC"].Value);
            double APPLY_NUM_EMPTY_25TIC = Convert.ToDouble(xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='data']/FieldValue").Attributes["APPLY_NUM_EMPTY_25TIC"].Value);

            double APPLY_NUM_RES = Convert.ToDouble(xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='data']/FieldValue").Attributes["APPLY_NUM_RES"].Value);
            double APPLY_NUM_EMPTY_RES = Convert.ToDouble(xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='data']/FieldValue").Attributes["APPLY_NUM_EMPTY_RES"].Value);

            string INSURANCE_TYPE = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='data']/FieldValue").Attributes["INSURANCE_TYPE"].Value;
            //是否有保乙式
            double isOne = 0;
            if ("0".Equals(INSURANCE_TYPE) || "1".Equals(INSURANCE_TYPE))
            {
            }
            else
            {
                //沒保乙式條件再-1%
                isOne = 1;
            }
            //空車
            if ("0".Equals(p_SPECIAL_TYPE))
            {
                switch (p_rdoAPPLY_TYPE)
                {
                    case "一般車": return APPLY_NUM_MONTH_EMPTY - isOne;
                    case "25週年": return APPLY_NUM_EMPTY_25 - isOne;
                    case "領牌車": return APPLY_NUM_EMPTY_GET - isOne;
                    case "重點車": return APPLY_NUM_EMPTY_IM - isOne;
                    case "發票車": return APPLY_NUM_EMPTY_TIC - isOne;
                    case "25週年+重點車": return APPLY_NUM_EMPTY_25IM - isOne;
                    case "25週年+發票車": return APPLY_NUM_EMPTY_25TIC - isOne;
                    case "回饋車": return APPLY_NUM_EMPTY_RES - isOne;
                    default: return 0;
                }
            }
            else
            {
                switch (p_rdoAPPLY_TYPE)
                {
                    case "一般車": return APPLY_NUM_MONTH - isOne;
                    case "25週年": return APPLY_NUM_25 - isOne;
                    case "領牌車": return APPLY_NUM_GET - isOne;
                    case "重點車": return APPLY_NUM_IM - isOne;
                    case "發票車": return APPLY_NUM_TIC - isOne;
                    case "25週年+重點車": return APPLY_NUM_25IM - isOne;
                    case "25週年+發票車": return APPLY_NUM_25TIC - isOne;
                    case "回饋車": return APPLY_NUM_RES - isOne;
                    default: return 0;
                }
            }
        }
        #endregion
    }
}
