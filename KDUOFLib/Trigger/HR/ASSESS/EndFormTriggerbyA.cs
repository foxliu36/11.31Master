using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using KDUOFLib.HR.UCO;
using System.Data;

namespace KDUOFLib.Trigger.HR.ASSESS
{
    public class EndFormTriggerbyA : Fast.EB.WKF.ExternalUtility.ICallbackTriggerPlugin        
    {
        #region ICallbackTriggerPlugin 成員

        public void Finally()
        {
           
        }

        public string GetFormResult(Fast.EB.WKF.ExternalUtility.ApplyTask applyTask)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(applyTask.CurrentDocXML);
            CTB_HR_PERTUCO l_pert = new CTB_HR_PERTUCO();
            //訂單需要同意才進入
            if (applyTask.FormResult == Fast.EB.WKF.Engine.ApplyResult.Adopt)
            {
                string l_str考核種類 = "";
                string l_年度 = "";
                XmlNodeList sequenceCode = xmlDoc.SelectNodes("/Form/FormFieldValue//FieldValue/Item");
                if (sequenceCode != null)
                {
                    foreach (XmlNode xmlN in sequenceCode)
                    {
                        DataRow l_row = l_pert.NewRow();
                        l_row["PERTNO"] = Guid.NewGuid().ToString();
                        l_row["GUID"] = xmlDoc.SelectSingleNode("/Form/FormFieldValue/FieldItem[@fieldId='GUID']").Attributes["fieldValue"].Value;
                        l_row["SMID"] = xmlN.Attributes["ACCOUNT"].Value;
                        int l_int月份 = DateTime.Today.Month;
                        if (l_int月份 > 9 || l_int月份 < 3)
                        {
                            l_row["ASSESS_TYPE"] = "年終";
                            l_row["RANK_Y"] = xmlN.Attributes["RANK_Y"].Value;
                            l_str考核種類 = "年終";
                        }
                        else if (2 < l_int月份 && l_int月份 < 7)
                        {
                            l_row["ASSESS_TYPE"] = "端午";
                            l_str考核種類 = "端午";
                        }
                        else if (6 < l_int月份 && l_int月份 < 10)
                        {
                            l_row["ASSESS_TYPE"] = "中秋";
                            l_str考核種類 = "中秋";
                        }
                        l_row["RANK"] = xmlN.Attributes["RANK"].Value;
                        l_row["EDIT_DATE"] = DateTime.Today.ToString("yyyy/MM/dd");
                        //年終考核年度為去年度，非當年度，所以需要-1
                        if (l_str考核種類 == "年終")
                        {
                            l_row["YEAR"] = (Convert.ToInt32(DateTime.Today.Year.ToString()) - 1).ToString();
                            l_年度 = (Convert.ToInt32(DateTime.Today.Year.ToString()) - 1).ToString();
                        }
                        else
                        {
                            l_row["YEAR"] = DateTime.Today.Year.ToString();
                            l_年度 = DateTime.Today.Year.ToString();
                        }
                        l_row["TASK_ID"] = applyTask.TaskId;
                        
                        DataTable l_dt = l_pert.check(xmlN.Attributes["ACCOUNT"].Value, l_str考核種類, l_年度);
                        if (l_dt != null && l_dt.Rows.Count > 0)
                        {
                            return "";
                        }
                        else
                        {
                            l_pert.Insert(l_row);
                        }

                    }
                }
            }
            //訂單否決刪除單子
            else
            {
                //刪除明細檔
                CTB_HR_ASSESS_SEVRICEUCO l_SEVRICE = new CTB_HR_ASSESS_SEVRICEUCO();
                l_SEVRICE.DeletebyReject(applyTask.TaskId);
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
