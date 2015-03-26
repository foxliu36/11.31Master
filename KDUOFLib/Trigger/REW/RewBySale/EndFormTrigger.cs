using System;
using System.Collections.Generic;
using System.Text;
using Fast.EB.WKF.ExternalUtility;
using KDUOFLib.REW.UCO;
using System.Xml;
using System.Data;

namespace KDUOFLib.Trigger.REW.RewBySale
{
    public class EndFormTrigger : ICallbackTriggerPlugin
    {
        #region ICallbackTriggerPlugin 成員

        public void Finally()
        {

        }

        public string GetFormResult(ApplyTask applyTask)
        {
            //         <Form formVersionId="181f6479-a6e4-409b-820a-9a151e338f74">
            //  <FormFieldValue>
            //    <FieldItem fieldId="NO" fieldValue="" realValue="" />
            //    <FieldItem fieldId="data" ConditionValue="" realValue="">
            //      <FieldValue ORDERNO="F03001000301" INSURANCE_TYPE="0" SPECIAL_TYPE="0" APPLY_NUM="6" DISCOUNT="6" PAY_TYPE="0" BIG_TYPE="2" MEMO="666" />
            //    </FieldItem>
            //  </FormFieldValue>
            //</Form>

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(applyTask.CurrentDocXML);

            string ORDERNO = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='data']/FieldValue").Attributes["ORDERNO"].Value;

            CSpecialsaleUCO CSpecialsaleUCO = new CSpecialsaleUCO();
            CPartUCO CPartUCO = new CPartUCO();

            string SPECIAL_MONEY = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='data']/FieldValue").Attributes["HARDCOVER_PRICE"].Value;
            string SUPPORT_TYPE = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='type']").Attributes["fieldValue"].Value;
            string LAST_MONTH = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='last']").Attributes["fieldValue"].Value;
            string SUPPORT_MONEY = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='money']").Attributes["fieldValue"].Value;

            double CAR_PRICE = Convert.ToDouble(xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='data']/FieldValue").Attributes["CAR_PRICE"].Value);
            double APPLY_NUM = Convert.ToDouble(xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='data']/FieldValue").Attributes["APPLY_NUM"].Value);
            double HARDCOVER_PRICE = Convert.ToDouble(xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='data']/FieldValue").Attributes["HARDCOVER_PRICE"].Value);
            string SPECIAL_TYPE = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='data']/FieldValue").Attributes["SPECIAL_TYPE"].Value;
           
            DateTime SaleDay = DateTime.Today;
            string rdoAPPLY_TYPE = "";
            try
            {
                rdoAPPLY_TYPE = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='data']/FieldValue").Attributes["rdoAPPLY_TYPE"].Value;
                if (!String.IsNullOrEmpty(xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='data']/FieldValue").Attributes["SaleDay"].Value))
                {
                    SaleDay = Convert.ToDateTime(xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='data']/FieldValue").Attributes["SaleDay"].Value);
                }
            }
            catch { }
         
           
            double APPLY_NUM_month = 0;
            string BIG_TYPE = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='data']/FieldValue").Attributes["BIG_TYPE"].Value;
            if (applyTask.FormResult == Fast.EB.WKF.Engine.ApplyResult.Adopt)
            {

                //新增兩個欄位同意申請%數與配件同意總金額
                double M_NUM = 0;
                int PART_NUM = 0;
               
                switch (SUPPORT_TYPE)
                {
                    case "大口批售": SUPPORT_TYPE = "1"; break;
                    case "僅核發交車獎金": SUPPORT_TYPE = "2"; break;
                    case "員工購車": SUPPORT_TYPE = "3"; break;
                    case "全不計": SUPPORT_TYPE = "4"; break;
                    case "一般": SUPPORT_TYPE = "5"; break;
                    //20130517 將僅核發交車獎金改成不准，一般改成准 way
                    case "准": SUPPORT_TYPE = "5"; break;
                    case "不准": SUPPORT_TYPE = "2"; break;
                }
                switch (LAST_MONTH)
                {
                    case "准": LAST_MONTH = "0"; break;
                    case "不准": LAST_MONTH = "1"; break;
                }

                try
                {
                    //M_NUM = Convert.ToDouble(xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='m_num']").Attributes["fieldValue"].Value) / 100;
                    M_NUM = Convert.ToDouble(xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='data']/FieldValue").Attributes["M_APPLY_NUM"].Value) / 100;
                    PART_NUM = Convert.ToInt32(xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='part_num']").Attributes["fieldValue"].Value);

                  
                }
                catch { }
                DataTable specialsaledt = CSpecialsaleUCO.QueryCSpecialsaleDatas(ORDERNO);
                if (specialsaledt.Rows.Count == 0)
                {
                    throw new Exception("無特販申請資料，請重新確認！");
                }
                DataRow row = specialsaledt.Rows[0];


                row["TASK_ID"] = applyTask.TaskId;
                row["DOC_NBR"] = applyTask.FormNumber;
                row["TASK_RESULT"] = (int)applyTask.FormResult;
                row["SUPPORT_TYPE"] = Convert.ToInt32(SUPPORT_TYPE);
                row["LAST_MONTH"] = Convert.ToInt32(LAST_MONTH);
                row["SUPPORT_MONEY"] = Convert.ToInt32(SUPPORT_MONEY);
                try
                {
                    row["SPECIAL_MONEY"] = Convert.ToInt32(SPECIAL_MONEY);
                }
                catch { row["SPECIAL_MONEY"] = 0; }

                //地擔可能修改%數，故結案時在驗算一次
                row["M_APPLY_NUM"] = M_NUM;
                row["SPECIAL_TYPE"] = SPECIAL_TYPE;
                row["PART_MONEY"] = PART_NUM;

                //舊表單無M_NUM欄位，故沿用舊算法 20120110 way
                if (M_NUM <= 0)
                {
                    M_NUM = APPLY_NUM;
                }

                //空車:0或精裝:1
                if ("0".Equals(SPECIAL_TYPE))
                {

                    row["DISCOUNT"] = ((Convert.ToInt32((CAR_PRICE * M_NUM)) / 100) * 100).ToString("N0");
                    //可摺車架 = 空車*精裝%數 PS:取值至百位數
                }
                else if ("1".Equals(SPECIAL_TYPE))
                {
                    //可摺車架 = (空車+精裝)*精裝%數 PS:取值至百位數
                    row["DISCOUNT"] = ((Convert.ToInt32(((CAR_PRICE + HARDCOVER_PRICE) * M_NUM)) / 100) * 100).ToString("N0");
                }
                CSpecialsaleUCO.Update(row);


            }
            else//若表單狀態不為同意則刪除資料避免無法申請
            {
                CSpecialsaleUCO.Delete(ORDERNO);
                //刪除特販也要刪除配件資料
                CPartUCO.DeletePartDatasByOrderNo(ORDERNO);
                if (!String.IsNullOrEmpty(rdoAPPLY_TYPE))
                {
                    if ("0".Equals(BIG_TYPE))
                    {
                        //20131002 新增須限制超過條件之單據，若作廢或不同意單據則須扣回
                        APPLY_NUM_month = getApplyNum(xmlDoc, SPECIAL_TYPE, rdoAPPLY_TYPE);

                        if (APPLY_NUM > APPLY_NUM_month)
                        {
                            CSpecialCntUCO CSpecialCntUCO = new CSpecialCntUCO();
                            string l_strBranch = ORDERNO.Substring(1, 2);
                            DataTable specialcnt = CSpecialCntUCO.QueryDatasByBranch(l_strBranch, SaleDay);
                            DataRow row_cnt = specialcnt.Rows[0];
                            row_cnt["CNT_NOW"] = Convert.ToInt32(row_cnt["CNT_NOW"]) - 1;
                            CSpecialCntUCO.Update(row_cnt);
                        }
                    }
                }
                return "";
            }


            return "";
        }
        private double getApplyNum(XmlDocument xmlDoc,string p_SPECIAL_TYPE, string p_rdoAPPLY_TYPE)
        {
            double APPLY_NUM_MONTH = Convert.ToDouble("0"+xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='data']/FieldValue").Attributes["APPLY_NUM_MONTH"].Value);
            double APPLY_NUM_MONTH_EMPTY = Convert.ToDouble("0" + xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='data']/FieldValue").Attributes["APPLY_NUM_MONTH_EMPTY"].Value);
            double APPLY_NUM_25 = Convert.ToDouble("0" + xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='data']/FieldValue").Attributes["APPLY_NUM_25"].Value);
            double APPLY_NUM_EMPTY_25 = Convert.ToDouble("0" + xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='data']/FieldValue").Attributes["APPLY_NUM_EMPTY_25"].Value);
            double APPLY_NUM_GET = Convert.ToDouble("0" + xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='data']/FieldValue").Attributes["APPLY_NUM_GET"].Value);
            double APPLY_NUM_EMPTY_GET = Convert.ToDouble("0" + xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='data']/FieldValue").Attributes["APPLY_NUM_EMPTY_GET"].Value);
            double APPLY_NUM_IM = Convert.ToDouble("0" + xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='data']/FieldValue").Attributes["APPLY_NUM_IM"].Value);
            double APPLY_NUM_EMPTY_IM = Convert.ToDouble("0" + xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='data']/FieldValue").Attributes["APPLY_NUM_EMPTY_IM"].Value);
            double APPLY_NUM_TIC = Convert.ToDouble("0" + xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='data']/FieldValue").Attributes["APPLY_NUM_TIC"].Value);
            double APPLY_NUM_EMPTY_TIC = Convert.ToDouble("0" + xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='data']/FieldValue").Attributes["APPLY_NUM_EMPTY_TIC"].Value);
            double APPLY_NUM_25IM = Convert.ToDouble("0" + xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='data']/FieldValue").Attributes["APPLY_NUM_25IM"].Value);
            double APPLY_NUM_EMPTY_25IM = Convert.ToDouble("0" + xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='data']/FieldValue").Attributes["APPLY_NUM_EMPTY_25IM"].Value);
            double APPLY_NUM_25TIC = Convert.ToDouble("0" + xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='data']/FieldValue").Attributes["APPLY_NUM_25TIC"].Value);
            double APPLY_NUM_EMPTY_25TIC = Convert.ToDouble("0" + xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='data']/FieldValue").Attributes["APPLY_NUM_EMPTY_25TIC"].Value);

            double APPLY_NUM_RES = Convert.ToDouble("0" + xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='data']/FieldValue").Attributes["APPLY_NUM_RES"].Value);
            double APPLY_NUM_EMPTY_RES = Convert.ToDouble("0" + xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='data']/FieldValue").Attributes["APPLY_NUM_EMPTY_RES"].Value);

            string  INSURANCE_TYPE = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='data']/FieldValue").Attributes["INSURANCE_TYPE"].Value;
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

        public void OnError(Exception errorException)
        {

        }

        #endregion
    }
}
