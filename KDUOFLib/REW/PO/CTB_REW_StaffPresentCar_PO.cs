using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace KDUOFLib.REW.PO
{
    public class CTB_REW_StaffPresentCar_PO : Fast.EB.Utility.Data.BasePersistentObject
    {
         REWDataSetTableAdapters.TableAdapterManager _myTAM;
         public CTB_REW_StaffPresentCar_PO()
        {
            _myTAM = new REWDataSetTableAdapters.TableAdapterManager();
            _myTAM.BackupDataSetBeforeUpdate = false;
            _myTAM.UpdateOrder = REWDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            //加入Table Adapter
            _myTAM.TB_REW_StaffPresentCarTableAdapter = new REWDataSetTableAdapters.TB_REW_StaffPresentCarTableAdapter();
            _myTAM.TB_REW_StaffPresentCarTableAdapter.Connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;

        }

         public void Update(REWDataSet ds)
         {
             _myTAM.UpdateAll(ds);
         }

         public void Delete(string OrderNo)
         {
             string cmdTxt = @"delete from TB_REW_StaffPresentCar where OrderNo='" + OrderNo + "'";
             this.m_db.ExecuteNonQuery(cmdTxt);
         }

         public DataTable HaveData(DataTable dt, string OrderNo)
         {
             string cmdTxt = @"select * from TB_REW_StaffPresentCar where OrderNo='" + OrderNo + "'";

             System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
             dt.Load(dr);
             dr.Dispose();
             return dt;
         }

         public DataTable getData(DataTable dt, string SDate, string EDate, string PresentUnit, string Unit,string PresentAccount,string StaffAccount,string OrderNo,string Plate)
         {
             string cmdTxt = @" select '0000000' as NoGUID ,'總.所.廠' as UnitType,sc.*,s.SUPPORT_TYPE,";  //sc.OrderNo+'@'+sc.Plate+'@'+sc.PresentAccount as keyword,
             cmdTxt += @" casetype = IsNull((case when (s.SUPPORT_TYPE in ('2')) then '特販件'";
             cmdTxt += @" when (s.SUPPORT_TYPE in ('5')) then '標準件' end),'')";
             cmdTxt += @" from TB_REW_StaffPresentCar sc";
             cmdTxt += @" left join TB_REW_SPECIALSALE s on s.ORDERNO=sc.OrderNo";
             cmdTxt += @" where Date between '" + SDate + "' and '" + EDate + "'";
             if (!string.IsNullOrEmpty(PresentUnit))
             {
                 cmdTxt += @" and sc.PresentUnit='" + PresentUnit + "'";
             }
             else if (!string.IsNullOrEmpty(Unit))
             {
                 cmdTxt += @" and sc.Unit='" + Unit + "'";
             }
             else if (!string.IsNullOrEmpty(PresentAccount))
             {
                 cmdTxt += @" and sc.PresentAccount='" + PresentAccount + "'";
             }
             else if (!string.IsNullOrEmpty(StaffAccount))
             {
                 cmdTxt += @" and sc.StaffAccount='" + StaffAccount + "'";
             }
             else if (!string.IsNullOrEmpty(OrderNo))
             {
                 cmdTxt += @" and sc.OrderNo='" + OrderNo + "'";
             }
             else if (!string.IsNullOrEmpty(Plate))
             {
                 cmdTxt += @" and sc.Plate='" + Plate + "'";
             }
             cmdTxt += @" order by sc.OrderNo";

             System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
             dt.Load(dr);
             dr.Dispose();
             return dt;
         }

         public void UpdatebyManager(DataRow row)
         {
             string cmdTxt = @" update TB_REW_StaffPresentCar set PresentAccount='" + row["PresentAccount"].ToString() + "'";
             cmdTxt += @" ,Plate='" + row["Plate"].ToString() + "',Memo='" + row["Memo"].ToString() + "'";
             cmdTxt += @" where OrderNo='" + row["OrderNo"].ToString() + "'";

             this.m_db.ExecuteNonQuery(cmdTxt);
         }

    }
}
