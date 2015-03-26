using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace KDUOFLib.TONER.PO
{
    public class COrderPO : Fast.EB.Utility.Data.BasePersistentObject
    {
        TONERDataSetTableAdapters.TableAdapterManager _myTAM;

        public COrderPO()
        {
            _myTAM = new TONERDataSetTableAdapters.TableAdapterManager();
            _myTAM.BackupDataSetBeforeUpdate = false;
            _myTAM.UpdateOrder = TONERDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            //加入Table Adapter
            _myTAM.TB_TONER_ORDERTableAdapter = new TONERDataSetTableAdapters.TB_TONER_ORDERTableAdapter();
            _myTAM.TB_TONER_ORDERTableAdapter.Connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;

        }

        public void Delete(string orderno)
        {
            string cmdTxt = @"delete from TB_TONER_ORDER where f_orderno='" + orderno + "'";
            this.m_db.ExecuteNonQuery(cmdTxt);
        }

        public void Update(TONERDataSet ds)
        {
            _myTAM.UpdateAll(ds);
        }

        public void MonthQuery(string SDATE, string EDATE, string p_unit, string p_empid,DataTable p_dt)
        {
            string cmdTxt = @"select o.f_unit,o.f_empid,o.f_editday,t.f_proname,sum(t.f_amount) as f_amount,sum(t.f_price*t.f_amount) as f_total";
            cmdTxt += @" from TB_TONER_ORDER o";
            cmdTxt += @" inner join TB_TONER_ORDERDETAIL t on t.f_orderno = o.f_orderno";
            cmdTxt += @" where 1=1";
            if (SDATE != "" && EDATE != "")
            {
                cmdTxt += @" and o.f_editday between @SDATE and @EDATE";
                this.m_db.AddParameter("@SDATE", SDATE);
                this.m_db.AddParameter("@EDATE", EDATE);
            }
            if (p_unit != "")
            {
                cmdTxt += @" and o.f_unit = @p_unit";
                this.m_db.AddParameter("@p_unit", p_unit);
            }
            if (p_empid !="")
            {
                cmdTxt += @" and o.f_empid = @p_empid";
                this.m_db.AddParameter("@p_empid", p_empid);
            }
            cmdTxt += @" group by o.f_unit,o.f_empid,o.f_editday,t.f_proname";
            cmdTxt += @" order by o.f_editday";

            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            p_dt.Load(dr);
            dr.Dispose();
        }

        public void DateQuery(string p_orderno, string SDATE, string EDATE, string p_unit, string p_empid, DataTable p_dt)
        {
            string cmdTxt = @"select TASK_ID,f_orderno,f_unit,f_empid,f_editday";
            cmdTxt += @" from TB_TONER_ORDER ";
            cmdTxt += @" where 1=1";
            if (p_orderno != "")
            {
                cmdTxt += @" and f_orderno = @p_orderno";
                this.m_db.AddParameter("@p_orderno", p_orderno);
            }
            if (SDATE != "" && EDATE != "")
            {
                cmdTxt += @" and f_editday between @SDATE and @EDATE";
                this.m_db.AddParameter("@SDATE", SDATE);
                this.m_db.AddParameter("@EDATE", EDATE);
            }
            if (p_unit != "")
            {
                cmdTxt += @" and f_unit = @p_unit";
                this.m_db.AddParameter("@p_unit", p_unit);
            }
            if (p_empid != "")
            {
                cmdTxt += @" and f_empid = @p_empid";
                this.m_db.AddParameter("@p_empid", p_empid);
            }
            cmdTxt += @" order by f_editday";

            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            p_dt.Load(dr);
            dr.Dispose();
        }

        public void IflowQuery(string p_companyid, string SDATE, string EDATE, string p_unit, DataTable p_dt)
        {
            string cmdTxt = @" select f_unit,f_syscode,SUM(f_total) as f_total ,'碳粉耗材使用費用' as f_cost,";
            cmdTxt += @" '6242' as f_Subject,'02' as f_son from ( ";
            cmdTxt += @" select f_unit =(case ";
            cmdTxt += @" when o.f_unit ='資訊室' or o.f_unit ='綜合企劃室' or o.f_unit ='總務室'";
            cmdTxt += @" or o.f_unit ='人資法務室' or o.f_unit ='秘書室' then '管理部'";
            cmdTxt += @" when o.f_unit ='會計室' or o.f_unit ='財務室' or o.f_unit ='稽核室' then '財務部'";
            cmdTxt += @" when o.f_unit ='顧客關懷推進室' or o.f_unit ='電話服務中心' then '顧關部'";
            cmdTxt += @" when o.f_unit ='保險分期室' or o.f_unit ='直販室' or o.f_unit ='需給室'";
            cmdTxt += @" or o.f_unit ='教育訓練室' or o.f_unit ='行銷企劃室' then '車輛部'";
            cmdTxt += @" when o.f_unit ='教育室' or o.f_unit ='零件室' or o.f_unit ='技術室'";
            cmdTxt += @" or (o.f_unit ='業務室' and";
            cmdTxt += @" (o.f_empid='K8183' or o.f_empid='82389' or o.f_empid='B8105' or  o.f_empid='AA011'))";
            cmdTxt += @" then '服務部'";
            cmdTxt += @"  when o.f_unit ='服務行銷室' or o.f_unit ='顧客關懷室' or o.f_unit ='企劃室' ";
            cmdTxt += @" or o.f_unit ='業務室' then 'LEXUS部' ";
            cmdTxt += @" when o.f_unit ='PDS物流整備-九如' or o.f_unit ='PDS物流整備-岡山' or o.f_unit ='PDS物流整備-鳳山' ";
            cmdTxt += @" or o.f_unit ='高輊' then 'PDS物流整備' ";
            cmdTxt += @" else o.f_unit end), ";
            cmdTxt += @" c.f_syscode,sum(t.f_price*t.f_amount) as f_total ";
            cmdTxt += @" from TB_TONER_ORDER o";
            cmdTxt += @" inner join TB_TONER_ORDERDETAIL t on t.f_orderno = o.f_orderno";
            cmdTxt += @" left join TB_TONER_PROJECT p on p.f_proname = t.f_proname";
            cmdTxt += @" left join TB_TONER_COMPANY c on c.f_companyid =p.f_companyid";
            cmdTxt += @" where 1=1";
            if (p_companyid != "")
            {
                cmdTxt += @" and o.f_companyid = @p_companyid";
                this.m_db.AddParameter("@p_companyid", p_companyid);
            }
            if (SDATE != "" && EDATE != "")
            {
                cmdTxt += @" and o.f_editday between @SDATE and @EDATE";
                this.m_db.AddParameter("@SDATE", SDATE);
                this.m_db.AddParameter("@EDATE", EDATE);
            }
            if (p_unit != "")
            {
                cmdTxt += @" and o.f_unit = @p_unit";
                this.m_db.AddParameter("@p_unit", p_unit);
            }
            cmdTxt += @" group by c.f_syscode,f_unit,o.f_empid ";
            cmdTxt += @" ) aa";
            cmdTxt += @" group by f_unit,f_syscode";

            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            p_dt.Load(dr);
            dr.Dispose();
        }

        public void PlanningQuery(string p_unit, string p_empid, string p_companyid, DataTable p_dt)
        {
            string cmdTxt = @"select o.f_unit,o.f_editday,o.f_empid,t.f_proname,p.f_companyid";
            cmdTxt += @" from TB_TONER_ORDER o";
            cmdTxt += @" inner join TB_TONER_ORDERDETAIL t on t.f_orderno = o.f_orderno";
            cmdTxt += @" left join TB_TONER_PROJECT p on p.f_proname = t.f_proname";
            cmdTxt += @" where 1=1";
            if (p_unit != "")
            {
                cmdTxt += @" and o.f_unit = @p_unit";
                this.m_db.AddParameter("@p_unit", p_unit);
            }
            if (p_empid != "")
            {
                cmdTxt += @" and o.f_empid = @p_empid";
                this.m_db.AddParameter("@p_empid", p_empid);
            }
            if (p_companyid != "")
            {
                cmdTxt += @" and o.f_companyid = @p_companyid";
                this.m_db.AddParameter("@p_companyid", p_companyid);
            }
            cmdTxt += @" order by o.f_editday";

            System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
            p_dt.Load(dr);
            dr.Dispose();
        }



    }
}
