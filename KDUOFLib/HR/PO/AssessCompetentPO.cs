using System;
using System.Collections.Generic;
using System.Text;

namespace KDUOFLib.HR.PO
{
    internal class AssessCompetentPO :Fast.EB.Utility.Data.BasePersistentObject
    {
        internal void UpdateCurrentDoc(string taskId, string currentDoc)
        {
            string cmdTxt = @"UPDATE TB_WKF_TASK
                            SET CURRENT_DOC=@CURRENT_DOC 
                            WHERE TASK_ID=@TASK_ID";

            this.m_db.AddParameter("@CURRENT_DOC" , currentDoc);
            this.m_db.AddParameter(@"TASK_ID" , taskId);

            this.m_db.ExecuteNonQuery(cmdTxt);
        }
    }
}
