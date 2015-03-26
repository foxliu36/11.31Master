using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace KDUOFLib.HR.PO
{
    public class CTB_HR_ASSESS_SERVICEPO : Fast.EB.Utility.Data.BasePersistentObject
    {
         HRDataSetTableAdapters.TableAdapterManager _myTAM;

         public CTB_HR_ASSESS_SERVICEPO()
        {
            _myTAM = new HRDataSetTableAdapters.TableAdapterManager();
            _myTAM.BackupDataSetBeforeUpdate = false;
            _myTAM.UpdateOrder = HRDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            //加入Table Adapter
            _myTAM.TB_HR_ASSESS_SERVICETableAdapter = new HRDataSetTableAdapters.TB_HR_ASSESS_SERVICETableAdapter();
            _myTAM.TB_HR_ASSESS_SERVICETableAdapter.Connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;
        }

         public void DeletebyReject(string taskid)
         {
             string cmdTxt = @"delete from TB_HR_ASSESS_SERVICE where TASK_ID='" + taskid + "'";
             this.m_db.ExecuteNonQuery(cmdTxt);
         }
         public void Delete(string taskid, string p_siteCode)
         {
             string cmdTxt = @"delete from TB_HR_ASSESS_SERVICE where TASK_ID='" + taskid + "' and SITE_CODE = '" + p_siteCode + "'";
             this.m_db.ExecuteNonQuery(cmdTxt);
         }
         public DataTable getDatsByID(DataTable p_dt, string ACCOUNT, string p_siteCode,string TASK_ID)
         {
             string cmdTxt = @"select * from TB_HR_ASSESS_SERVICE where ACCOUNT='" + ACCOUNT + "' and SITE_CODE = '" + p_siteCode + "'";
             cmdTxt += @" and TASK_ID= '" + TASK_ID + "'";
             System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
             p_dt.Load(dr);
             dr.Dispose();
             return p_dt;
         }

         public void Update(HRDataSet ds)
         {
             _myTAM.UpdateAll(ds);
         }

         public void UpdateByTASKID(DataRow row)
         {
             string cmdTxt = @"UPDATE [TB_HR_ASSESS_SERVICE]";
             cmdTxt += @" SET [RANK_Y] = '" + row["RANK_Y"].ToString() + "'";
             cmdTxt += @" where TASK_ID = @TASK_ID";
             cmdTxt += @" and ACCOUNT = @ACCOUNT";
             cmdTxt += @" and SITE_CODE = @SITE_CODE";
             this.m_db.AddParameter("@TASK_ID", row["TASK_ID"].ToString());
             this.m_db.AddParameter("@ACCOUNT", row["ACCOUNT"].ToString());
             this.m_db.AddParameter("@SITE_CODE", row["SITE_CODE"].ToString());
             this.m_db.ExecuteNonQuery(cmdTxt);
         }

         public DataTable getDatabyString(DataTable p_dt, string p_Branch)
         {
             string cmdTxt = @" select u.NAME,g.GROUP_NAME,u.ACCOUNT,convert(char(10) ,CREATE_DATE,111) as CREATE_DATE";
             cmdTxt += @" from TB_EB_USER u";
             cmdTxt += @" inner join TB_EB_EMPL_DEP e on e.USER_GUID=u.USER_GUID";
             cmdTxt += @" inner join TB_EB_GROUP g on g.GROUP_ID=e.GROUP_ID";
             cmdTxt += @" where g.GROUP_ID in(";
             cmdTxt += @" " + p_Branch.Substring(0, p_Branch.Length - 1) + ")";
             cmdTxt += @" and u.EXPIRE_DATE='9999-12-31 23:59:59.997'";
             cmdTxt += @" order by u.ACCOUNT";

             System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
             p_dt.Load(dr);
             dr.Dispose();
             return p_dt;
         }

         #region 職務類別
         public DataTable getDatabyEngine(DataTable p_dt, string p_Branch)
         {
             string cmdTxt = @" select u.NAME,jb.FUNC_NAME,jt.TITLE_NAME,u.ACCOUNT,convert(char(10) ,CREATE_DATE,111) as CREATE_DATE,ISnull(s.TARGED,'0') as TARGED";
             cmdTxt += @" from TB_EB_USER u";
             cmdTxt += @" inner join TB_EB_EMPL_DEP e on e.USER_GUID=u.USER_GUID";
             cmdTxt += @" inner join TB_EB_GROUP g on g.GROUP_ID=e.GROUP_ID";
             cmdTxt += @" inner join TB_EB_EMPL_FUNC ef on ef.USER_GUID =u.USER_GUID";
             cmdTxt += @" inner join TB_EB_JOB_FUNC jb on jb.FUNC_ID = ef.FUNC_ID";
             cmdTxt += @" inner join TB_EB_JOB_TITLE jt on jt.TITLE_ID=e.TITLE_ID";
             cmdTxt += @" left join dbo.TB_HR_STAFF_CAR s on s.SMID = u.ACCOUNT";
             cmdTxt += @" where g.GROUP_ID in(";
             cmdTxt += @" " + p_Branch.Substring(0, p_Branch.Length - 1) + ")";
             cmdTxt += @" and u.EXPIRE_DATE='9999-12-31 23:59:59.997'";
             cmdTxt += @" and jb.FUNC_NAME ='服務廠一般職_引擎組'";
             cmdTxt += @" group by u.NAME,jb.FUNC_NAME,jt.TITLE_NAME,u.ACCOUNT,CREATE_DATE,TARGED ";
             cmdTxt += @" order by jb.FUNC_NAME,u.ACCOUNT";

             System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
             p_dt.Load(dr);
             dr.Dispose();
             return p_dt;
         }

         public DataTable getDatabylacquer(DataTable p_dt, string p_Branch)
         {
             string cmdTxt = @"select u.NAME,jb.FUNC_NAME,jt.TITLE_NAME,u.ACCOUNT,convert(char(10) ,CREATE_DATE,111) as CREATE_DATE,ISnull(s.TARGED,'0') as TARGED";
             cmdTxt += @" from TB_EB_USER u";
             cmdTxt += @" inner join TB_EB_EMPL_DEP e on e.USER_GUID=u.USER_GUID";
             cmdTxt += @" inner join TB_EB_GROUP g on g.GROUP_ID=e.GROUP_ID";
             cmdTxt += @" inner join TB_EB_EMPL_FUNC ef on ef.USER_GUID =u.USER_GUID";
             cmdTxt += @" inner join TB_EB_JOB_FUNC jb on jb.FUNC_ID = ef.FUNC_ID";
             cmdTxt += @" inner join TB_EB_JOB_TITLE jt on jt.TITLE_ID=e.TITLE_ID";
             cmdTxt += @" left join dbo.TB_HR_STAFF_CAR s on s.SMID = u.ACCOUNT";
             cmdTxt += @" where g.GROUP_ID in(";
             cmdTxt += @" " + p_Branch.Substring(0, p_Branch.Length - 1) + ")";
             cmdTxt += @" and u.EXPIRE_DATE='9999-12-31 23:59:59.997'";
             cmdTxt += @" and jb.FUNC_NAME in('服務廠一般職_鈑金組','服務廠一般職_噴漆組')";
             cmdTxt += @" group by u.NAME,jb.FUNC_NAME,jt.TITLE_NAME,u.ACCOUNT,CREATE_DATE,TARGED ";
             cmdTxt += @" order by jb.FUNC_NAME,u.ACCOUNT";

             System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
             p_dt.Load(dr);
             dr.Dispose();
             return p_dt;
         }

         public DataTable getDatabyParts(DataTable p_dt, string p_Branch)
         {
             string cmdTxt = @" select u.NAME,jb.FUNC_NAME,jt.TITLE_NAME,u.ACCOUNT,convert(char(10) ,CREATE_DATE,111) as CREATE_DATE,ISnull(s.TARGED,'0') as TARGED";
             cmdTxt += @" from TB_EB_USER u";
             cmdTxt += @" inner join TB_EB_EMPL_DEP e on e.USER_GUID=u.USER_GUID";
             cmdTxt += @" inner join TB_EB_GROUP g on g.GROUP_ID=e.GROUP_ID";
             cmdTxt += @" inner join TB_EB_EMPL_FUNC ef on ef.USER_GUID =u.USER_GUID";
             cmdTxt += @" inner join TB_EB_JOB_FUNC jb on jb.FUNC_ID = ef.FUNC_ID";
             cmdTxt += @" inner join TB_EB_JOB_TITLE jt on jt.TITLE_ID=e.TITLE_ID";
             cmdTxt += @" left join dbo.TB_HR_STAFF_CAR s on s.SMID = u.ACCOUNT";
             cmdTxt += @" where g.GROUP_ID in(";
             cmdTxt += @" " + p_Branch.Substring(0, p_Branch.Length - 1) + ")";
             cmdTxt += @" and u.EXPIRE_DATE='9999-12-31 23:59:59.997'";
             cmdTxt += @" and jb.FUNC_NAME ='服務廠一般職_零件組'";
             cmdTxt += @" group by u.NAME,jb.FUNC_NAME,jt.TITLE_NAME,u.ACCOUNT,CREATE_DATE,TARGED ";
             cmdTxt += @" order by jb.FUNC_NAME,u.ACCOUNT";

             System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
             p_dt.Load(dr);
             dr.Dispose();
             return p_dt;
         }

         public DataTable getDatabyOther(DataTable p_dt, string p_Branch)
         {
             string cmdTxt = @" select u.NAME,jb.FUNC_NAME,jt.TITLE_NAME,u.ACCOUNT,convert(char(10) ,CREATE_DATE,111) as CREATE_DATE,ISnull(s.TARGED,'0') as TARGED";
             cmdTxt += @" from TB_EB_USER u";
             cmdTxt += @" inner join TB_EB_EMPL_DEP e on e.USER_GUID=u.USER_GUID";
             cmdTxt += @" inner join TB_EB_GROUP g on g.GROUP_ID=e.GROUP_ID";
             cmdTxt += @" inner join TB_EB_EMPL_FUNC ef on ef.USER_GUID =u.USER_GUID";
             cmdTxt += @" inner join TB_EB_JOB_FUNC jb on jb.FUNC_ID = ef.FUNC_ID";
             cmdTxt += @" inner join TB_EB_JOB_TITLE jt on jt.TITLE_ID=e.TITLE_ID";
             cmdTxt += @" left join dbo.TB_HR_STAFF_CAR s on s.SMID = u.ACCOUNT";
             cmdTxt += @" where g.GROUP_ID in(";
             cmdTxt += @" " + p_Branch.Substring(0, p_Branch.Length - 1) + ")";
             cmdTxt += @" and u.EXPIRE_DATE='9999-12-31 23:59:59.997'";
             cmdTxt += @" and jb.FUNC_NAME in ('服務廠一般職_其他','服務廠一般職_服務專員','服務廠一般職_檢驗組')";
             cmdTxt += @" group by u.NAME,jb.FUNC_NAME,jt.TITLE_NAME,u.ACCOUNT,CREATE_DATE,TARGED ";
             cmdTxt += @" order by jb.FUNC_NAME,u.ACCOUNT";

             System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
             p_dt.Load(dr);
             dr.Dispose();
             return p_dt;
         }

         public DataTable getDatabyPDS(DataTable p_dt, string p_Branch)
         {
             string cmdTxt = @" select u.NAME,jb.FUNC_NAME,jt.TITLE_NAME,u.ACCOUNT,convert(char(10) ,CREATE_DATE,111) as CREATE_DATE,ISnull(s.TARGED,'0') as TARGED";
             cmdTxt += @" from TB_EB_USER u";
             cmdTxt += @" inner join TB_EB_EMPL_DEP e on e.USER_GUID=u.USER_GUID";
             cmdTxt += @" inner join TB_EB_GROUP g on g.GROUP_ID=e.GROUP_ID";
             cmdTxt += @" inner join TB_EB_EMPL_FUNC ef on ef.USER_GUID =u.USER_GUID";
             cmdTxt += @" inner join TB_EB_JOB_FUNC jb on jb.FUNC_ID = ef.FUNC_ID";
             cmdTxt += @" inner join TB_EB_JOB_TITLE jt on jt.TITLE_ID=e.TITLE_ID";
             cmdTxt += @" left join dbo.TB_HR_STAFF_CAR s on s.SMID = u.ACCOUNT";
             cmdTxt += @" where g.GROUP_ID in(";
             cmdTxt += @" " + p_Branch.Substring(0, p_Branch.Length - 1) + ")";
             cmdTxt += @" and u.EXPIRE_DATE='9999-12-31 23:59:59.997'";
             cmdTxt += @" and jb.FUNC_NAME in( 'PDS一般職_技術組','PDS一般職_庫房組','PDS一般職_整備組')";
             cmdTxt += @" group by u.NAME,jb.FUNC_NAME,jt.TITLE_NAME,u.ACCOUNT,CREATE_DATE,TARGED ";
             cmdTxt += @" order by jb.FUNC_NAME,u.ACCOUNT";

             System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
             p_dt.Load(dr);
             dr.Dispose();
             return p_dt;
         }

         public DataTable getDatabyService(DataTable p_dt, string p_Branch)
         {
             string cmdTxt = @" select u.NAME,jb.FUNC_NAME,jt.TITLE_NAME,u.ACCOUNT,convert(char(10) ,CREATE_DATE,111) as CREATE_DATE,ISnull(s.TARGED,'0') as TARGED";
             cmdTxt += @" from TB_EB_USER u";
             cmdTxt += @" inner join TB_EB_EMPL_DEP e on e.USER_GUID=u.USER_GUID";
             cmdTxt += @" inner join TB_EB_GROUP g on g.GROUP_ID=e.GROUP_ID";
             cmdTxt += @" inner join TB_EB_EMPL_FUNC ef on ef.USER_GUID =u.USER_GUID";
             cmdTxt += @" inner join TB_EB_JOB_FUNC jb on jb.FUNC_ID = ef.FUNC_ID";
             cmdTxt += @" inner join TB_EB_JOB_TITLE jt on jt.TITLE_ID=e.TITLE_ID";
             cmdTxt += @" left join dbo.TB_HR_STAFF_CAR s on s.SMID = u.ACCOUNT";
             cmdTxt += @" where g.GROUP_ID in(";
             cmdTxt += @" " + p_Branch.Substring(0, p_Branch.Length - 1) + ")";
             cmdTxt += @" and u.EXPIRE_DATE='9999-12-31 23:59:59.997'";
             cmdTxt += @" and jb.FUNC_NAME in ( '高輊一般職_技師','高輊一般職_專員','高輊一般職_練習員','高輊一般職_出納助理')";
             cmdTxt += @" group by u.NAME,jb.FUNC_NAME,jt.TITLE_NAME,u.ACCOUNT,CREATE_DATE,TARGED ";
             cmdTxt += @" order by jb.FUNC_NAME,u.ACCOUNT";

             System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
             p_dt.Load(dr);
             dr.Dispose();
             return p_dt;
         }

         public DataTable getDatabyBranch(DataTable p_dt, string p_Branch)
         {
             string cmdTxt = @" select h.SIGNER,f_A=IsNull(sum(case when h.RANK_Y ='A' then 1 end),0),";
             cmdTxt += @" f_B1=IsNull(sum(case when h.RANK_Y ='B+' then 1 end),0),";
             cmdTxt += @" f_B=IsNull(sum(case when h.RANK_Y ='B' then 1 end),0),";
             cmdTxt += @" f_B3=IsNull(sum(case when h.RANK_Y ='B-' then 1 end),0),";
             cmdTxt += @" f_C1=IsNull(sum(case when h.RANK_Y ='C+' then 1 end),0),";
             cmdTxt += @" f_C=IsNull(sum(case when h.RANK_Y ='C' then 1 end),0),";
             cmdTxt += @" f_C3=IsNull(sum(case when h.RANK_Y ='C-' then 1 end),0),";
             cmdTxt += @" f_D1=IsNull(sum(case when h.RANK_Y ='D+' then 1 end),0),";
             cmdTxt += @" f_D=IsNull(sum(case when h.RANK_Y ='D' then 1 end),0),";
             cmdTxt += @" f_D3=IsNull(sum(case when h.RANK_Y ='D-' then 1 end),0),";
             cmdTxt += @" f_F=IsNull(sum(case when h.RANK_Y ='F' then 1 end),0),";
             cmdTxt += @" h.SITE_CODE,h.SIGNER+'_'+h.SITE_CODE as keyword";
             cmdTxt += @" from TB_HR_ASSESS_SERVICE h";
             cmdTxt += @" inner join TB_EB_USER u on u.ACCOUNT = h.SMID";
             cmdTxt += @" inner join TB_EB_EMPL_DEP e on e.USER_GUID=u.USER_GUID";
             cmdTxt += @" inner join TB_EB_GROUP g on g.GROUP_ID=e.GROUP_ID";
             cmdTxt += @" where g.GROUP_ID in ( ";
             cmdTxt += @" " + p_Branch.Substring(0, p_Branch.Length - 1) + ")";
             cmdTxt += @" group by h.SIGNER,h.SITE_CODE";

             System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
             p_dt.Load(dr);
             dr.Dispose();
             return p_dt;
         }

         public DataTable getDataforSevrice(DataTable p_dt, string p_TYPE, string p_GruopName,bool boPost,string p_ASSESS_TYPE,string p_year)
         {
             string cmdTxt = @" select SIGNER,f_A=IsNull(sum(case when RANK_Y ='A' then 1 end),0),";
             cmdTxt += @" f_B1=IsNull(sum(case when RANK_Y ='B+' then 1 end),0),";
             cmdTxt += @" f_B=IsNull(sum(case when RANK_Y ='B' then 1 end),0),";
             cmdTxt += @" f_B3=IsNull(sum(case when RANK_Y ='B-' then 1 end),0),";
             cmdTxt += @" f_C1=IsNull(sum(case when RANK_Y ='C+' then 1 end),0),";
             cmdTxt += @" f_C=IsNull(sum(case when RANK_Y ='C' then 1 end),0),";
             cmdTxt += @" f_C3=IsNull(sum(case when RANK_Y ='C-' then 1 end),0),";
             cmdTxt += @" f_D1=IsNull(sum(case when RANK_Y ='D+' then 1 end),0),";
             cmdTxt += @" f_D=IsNull(sum(case when RANK_Y ='D' then 1 end),0),";
             cmdTxt += @" f_D3=IsNull(sum(case when RANK_Y ='D-' then 1 end),0),";
             cmdTxt += @" f_F=IsNull(sum(case when RANK_Y ='F' then 1 end),0),";
             cmdTxt += @" SITE_CODE,SITE_CODE +'/'+'" + p_TYPE.Replace("'", "") + "'+'/'+ GROUP_NAME as keyword";    //將原職務合併成一個欄位
             //cmdTxt += @" SITE_CODE,SIGNER+'_'+SITE_CODE as keyword ,'" + p_TYPE.Replace("'", "") + "' as code";
             cmdTxt += @" from TB_HR_ASSESS_SERVICE";
             cmdTxt += @" where FUNC_NAME in (" + p_TYPE + ")";
             if (boPost == true)
             {
                 cmdTxt += @" and GROUP_NAME='" + p_GruopName + "'";
             }
             cmdTxt += @" and ASSESS_TYPE='" + p_ASSESS_TYPE + "'";
             cmdTxt += @" and SUBSTRING(EDIT_DATE,1,4)='" + p_year + "'";
             cmdTxt += @" group by SIGNER,SITE_CODE,GROUP_NAME";
             
             System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
             p_dt.Load(dr);
             dr.Dispose();
             return p_dt;
         }

         public DataTable getSingerforSevrice(DataTable p_dt, string p_TYPE)
         {
             string cmdTxt = @" select SIGNER from TB_HR_ASSESS_SERVICE";
             cmdTxt += @" where FUNC_NAME in (" + p_TYPE + ")";
             cmdTxt += @" group by SIGNER";
             System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
             p_dt.Load(dr);
             dr.Dispose();
             return p_dt;
         }

         #endregion

         #region 2013新架構考核
         public DataTable getDatabyHead(DataTable p_dt, string p_Branch)
         {
             string cmdTxt = @" select u.NAME,jb.FUNC_NAME,u.ACCOUNT,ISnull(s.TARGED,'0') as TARGED";
             cmdTxt += @" from TB_EB_USER u";
             cmdTxt += @" inner join TB_EB_EMPL_DEP e on e.USER_GUID=u.USER_GUID";
             cmdTxt += @" inner join TB_EB_GROUP g on g.GROUP_ID=e.GROUP_ID";
             cmdTxt += @" inner join TB_EB_EMPL_FUNC ef on ef.USER_GUID =u.USER_GUID";
             cmdTxt += @" inner join TB_EB_JOB_FUNC jb on jb.FUNC_ID = ef.FUNC_ID";
             cmdTxt += @" left join dbo.TB_HR_STAFF_CAR s on s.SMID = u.ACCOUNT";
             cmdTxt += @" where g.GROUP_ID in(";
             cmdTxt += @" " + p_Branch.Substring(0, p_Branch.Length - 1) + ")";
             cmdTxt += @" and u.EXPIRE_DATE='9999-12-31 23:59:59.997'";
             cmdTxt += @" and u.CREATE_DATE <='2013-07-01'";
             cmdTxt += @" and jb.FUNC_NAME in ('總公司一般職','服務廠一般職_服務專員','服務廠一般職_引擎組','服務廠一般職_出納助理',";
             cmdTxt += @" '服務廠一般職_鈑金組','服務廠一般職_零件組','服務廠一般職_噴漆組','服務廠一般職_其他')";
             cmdTxt += @" group by u.NAME,jb.FUNC_NAME,u.ACCOUNT,TARGED ";
             cmdTxt += @" order by jb.FUNC_NAME,u.ACCOUNT";

             System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
             p_dt.Load(dr);
             dr.Dispose();
             return p_dt;
         }



         #endregion



         #region 職務類別比例
         public DataTable Sevrice_Type(DataTable p_dt, string p_Branch, string p_SMID)
         {
             string cmdTxt = @" select h.SIGNER,f_A=IsNull(sum(case when h.RANK_Y ='A' then 1 end),0),";
             cmdTxt += @" f_B1=IsNull(sum(case when h.RANK_Y ='B+' then 1 end),0),";
             cmdTxt += @" f_B=IsNull(sum(case when h.RANK_Y ='B' then 1 end),0),";
             cmdTxt += @" f_B3=IsNull(sum(case when h.RANK_Y ='B-' then 1 end),0),";
             cmdTxt += @" f_C1=IsNull(sum(case when h.RANK_Y ='C+' then 1 end),0),";
             cmdTxt += @" f_C=IsNull(sum(case when h.RANK_Y ='C' then 1 end),0),";
             cmdTxt += @" f_C3=IsNull(sum(case when h.RANK_Y ='C-' then 1 end),0),";
             cmdTxt += @" f_D1=IsNull(sum(case when h.RANK_Y ='D+' then 1 end),0),";
             cmdTxt += @" f_D=IsNull(sum(case when h.RANK_Y ='D' then 1 end),0),";
             cmdTxt += @" f_D3=IsNull(sum(case when h.RANK_Y ='D-' then 1 end),0),";
             cmdTxt += @" f_F=IsNull(sum(case when h.RANK_Y ='F' then 1 end),0),";
             cmdTxt += @" h.SITE_CODE,h.SIGNER+'_'+h.SITE_CODE as keyword";
             cmdTxt += @" from TB_HR_ASSESS_SERVICE h";
             cmdTxt += @" inner join TB_EB_USER u on u.ACCOUNT = h.SMID";
             cmdTxt += @" inner join TB_EB_EMPL_DEP e on e.USER_GUID=u.USER_GUID";
             cmdTxt += @" inner join TB_EB_GROUP g on g.GROUP_ID=e.GROUP_ID";
             cmdTxt += @" where g.GROUP_ID in ( ";
             cmdTxt += @" " + p_Branch.Substring(0, p_Branch.Length - 1) + ")";
             cmdTxt += @" and h.ACCOUNT in ( ";
             cmdTxt += @" " + p_SMID.Substring(0, p_SMID.Length - 1) + ")";
             cmdTxt += @" group by h.SIGNER,h.SITE_CODE";

             System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
             p_dt.Load(dr);
             dr.Dispose();
             return p_dt;
         }

        #endregion

        #region 明細
         public DataTable detail_dailog(DataTable p_dt, string p_SITE_CODE, string p_FUNC_NAME, string p_GROUP_NAME, string p_ASSESS_TYPE, string p_year)
         {
             string cmdTxt = @" select GROUP_NAME,NAME,FUNC_NAME,ACCOUNT,TITLE_NAME,RANK_Y";
             cmdTxt += @" from TB_HR_ASSESS_SERVICE";
             cmdTxt += @" where SITE_CODE ='" + p_SITE_CODE + "'";
             cmdTxt += @" and FUNC_NAME in ('" + p_FUNC_NAME.Replace(",", "','") + "')";
             cmdTxt += @" and GROUP_NAME ='" + p_GROUP_NAME + "'";
             cmdTxt += @" and ASSESS_TYPE='" + p_ASSESS_TYPE + "'";
             cmdTxt += @" and SUBSTRING(EDIT_DATE,1,4)='" + p_year + "'";
             cmdTxt += @" order by ACCOUNT";

             System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
             p_dt.Load(dr);
             dr.Dispose();
             return p_dt;
         }

         public DataTable detail_dailogforSinger(DataTable p_dt, string p_FUNC_NAME, string p_GROUP_NAME, string p_ASSESS_TYPE, string p_year)
         {
             string cmdTxt = @" select GROUP_NAME,NAME,FUNC_NAME,ACCOUNT,TITLE_NAME, RANK_Y,SITE_CODE";
             cmdTxt += @" from TB_HR_ASSESS_SERVICE";
             cmdTxt += @" where SITE_CODE in ('S1','S2')";
             cmdTxt += @" and FUNC_NAME in ('" + p_FUNC_NAME.Replace(",", "','") + "')";
             cmdTxt += @" and GROUP_NAME ='" + p_GROUP_NAME + "'";
             cmdTxt += @" and ASSESS_TYPE='" + p_ASSESS_TYPE + "'";
             cmdTxt += @" and SUBSTRING(EDIT_DATE,1,4)='" + p_year + "'";
             cmdTxt += @" order by ACCOUNT,SITE_CODE";

             System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
             p_dt.Load(dr);
             dr.Dispose();
             return p_dt;
         }

         public DataTable getdatail(DataTable p_dt, string p_Bdate, string p_Edate, string p_smid, string p_GruopID, string p_GUID, string p_type)
         {
             string cmdTxt = @" select s.GUID,s.ASSESS_TYPE,s.ACCOUNT as SMID,s.NAME,s.TITLE_NAME,g.GROUP_NAME,s.RANK,s.RANK_Y,s.SITE_CODE,s.SIGNER,s.MEMO";
             cmdTxt += @" from TB_HR_ASSESS_SERVICE s";
             cmdTxt += @" left join TB_EB_USER u on u.ACCOUNT=s.ACCOUNT";
             cmdTxt += @" inner join TB_EB_EMPL_DEP e on e.USER_GUID=u.USER_GUID";
             cmdTxt += @" inner join TB_EB_GROUP g on g.GROUP_ID=e.GROUP_ID";
             cmdTxt += @" where e.ORDERS = 0";
             cmdTxt += @" and s.EDIT_DATE between '" + p_Bdate + "' and '" + p_Edate + "'";
             if (!String.IsNullOrEmpty(p_smid))
             {
                 cmdTxt += @" and s.ACCOUNT='" + p_smid + "'";
             }
             if (!String.IsNullOrEmpty(p_GruopID))
             {
                 cmdTxt += @" and g.GROUP_ID in(" + p_GruopID.Substring(0, p_GruopID.Length - 1) + ")";
             }
             if (!String.IsNullOrEmpty(p_GUID))
             {
                 cmdTxt += @" and s.GUID='" + p_GUID + "'";
             }
             if (!String.IsNullOrEmpty(p_type))
             {
                 cmdTxt += @" and s.ASSESS_TYPE='" + p_type + "'";
             }
             cmdTxt += @" order by s.ACCOUNT,s.SITE_CODE";

             System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
             p_dt.Load(dr);
             dr.Dispose();
             return p_dt;
         }
        #endregion

         #region 宏偉製表用
         public DataTable getUserByGroupID(DataTable p_dt, string p_GroupID, string p_smid)
         {
             string cmdTxt = @" select u.USER_GUID,u.ACCOUNT,u.NAME,g.GROUP_NAME";
             cmdTxt += @" from dbo.TB_EB_USER u";
             cmdTxt += @" inner join dbo.TB_EB_EMPL_DEP d on u.USER_GUID = d.USER_GUID";
             cmdTxt += @" inner join dbo.TB_EB_GROUP g on g.GROUP_ID = d.GROUP_ID";
             //cmdTxt += @" inner join dbo.TB_EB_GROUP g on g.GROUP_ID = d.GROUP_ID";
             if (String.IsNullOrEmpty(p_GroupID))
             {
                 cmdTxt += @" where 1=1";
             }
             else
             {
                 cmdTxt += @" where d.GROUP_ID = '" + p_GroupID + "'";
             }
             if (!String.IsNullOrEmpty(p_smid))
             {
                 cmdTxt += @" and u.Account = '" + p_smid + "'";
             }
             cmdTxt += @" and u.EXPIRE_DATE='9999-12-31 23:59:59.997'";
             cmdTxt += @" order by u.ACCOUNT";
             System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
             p_dt.Load(dr);
             dr.Dispose();
             return p_dt;
         }

         public DataTable getUserByGroupIDBy所廠(DataTable p_dt, string p_GroupID, string p_smid)
         {
             string cmdTxt = @" select u.USER_GUID,u.ACCOUNT,u.NAME,g.GROUP_NAME";
             cmdTxt += @" from dbo.TB_EB_USER u";
             cmdTxt += @" inner join dbo.TB_EB_EMPL_DEP d on u.USER_GUID = d.USER_GUID";
             cmdTxt += @" inner join dbo.TB_EB_GROUP g on g.GROUP_ID = d.GROUP_ID";
             if (String.IsNullOrEmpty(p_GroupID))
             {
                 cmdTxt += @" where 1=1";
             }
             else
             {
                 cmdTxt += @" where (g.PARENT_GROUP_ID = '" + p_GroupID + "' or g.GROUP_ID = '" + p_GroupID + "')";
             }
             cmdTxt += @" and u.EXPIRE_DATE='9999-12-31 23:59:59.997'";
             if (!String.IsNullOrEmpty(p_smid))
             {
                 cmdTxt += @" and u.Account = '" + p_smid + "'";
             }
             cmdTxt += @" order by u.ACCOUNT ";

             System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
             p_dt.Load(dr);
             dr.Dispose();
             return p_dt;
         }
         public DataTable getUserByGroupIDByPrint(DataTable p_dt, string p_GroupID)
         {
             string cmdTxt = @" select u.USER_GUID,u.ACCOUNT,u.NAME,g.GROUP_NAME";
             cmdTxt += @" from dbo.TB_EB_USER u";
             cmdTxt += @" inner join dbo.TB_EB_EMPL_DEP d on u.USER_GUID = d.USER_GUID";
             cmdTxt += @" inner join dbo.TB_EB_GROUP g on g.GROUP_ID = d.GROUP_ID";
             cmdTxt += @" where d.GROUP_ID = '" + p_GroupID + "'";
             cmdTxt += @" and u.EXPIRE_DATE='9999-12-31 23:59:59.997'";

             System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
             p_dt.Load(dr);
             dr.Dispose();
             return p_dt;
         }
         public DataTable getUserByGroupIDByPrint所廠(DataTable p_dt, string p_GroupID)
         {
             string cmdTxt = @" select u.USER_GUID,u.ACCOUNT,u.NAME,g.GROUP_NAME";
             cmdTxt += @" from dbo.TB_EB_USER u";
             cmdTxt += @" inner join dbo.TB_EB_EMPL_DEP d on u.USER_GUID = d.USER_GUID";
             cmdTxt += @" inner join dbo.TB_EB_GROUP g on g.GROUP_ID = d.GROUP_ID";
             cmdTxt += @" where (g.PARENT_GROUP_ID = '" + p_GroupID + "' or g.GROUP_ID = '" + p_GroupID + "')";
             cmdTxt += @" and u.EXPIRE_DATE='9999-12-31 23:59:59.997'";


             System.Data.Common.DbDataReader dr = this.m_db.ExecuteReader(cmdTxt);
             p_dt.Load(dr);
             dr.Dispose();
             return p_dt;
         }
         #endregion

       
    }
}
