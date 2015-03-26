using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;

namespace KDUOFLib.TONER
{
    public class Utility
    {
        public static void setBranch(DropDownList ddl)
        {
            ddl.Items.Add(new ListItem("", ""));
            ddl.Items.Add(new ListItem("岡山營業所", "F03岡山營業所"));
            ddl.Items.Add(new ListItem("屏東營業所", "F04屏東營業所"));
            ddl.Items.Add(new ListItem("北高營業所", "F07北高營業所"));
            ddl.Items.Add(new ListItem("旗山營業所", "F08旗山營業所"));
            ddl.Items.Add(new ListItem("潮州營業所", "F09潮州營業所"));
            ddl.Items.Add(new ListItem("小港營業所", "F10小港營業所"));
            ddl.Items.Add(new ListItem("九如營業所", "F11九如營業所"));
            ddl.Items.Add(new ListItem("鳳山營業所", "F12鳳山營業所"));
            ddl.Items.Add(new ListItem("湖內營業所", "F13湖內營業所"));
            ddl.Items.Add(new ListItem("北屏營業所", "F14北屏營業所"));
            ddl.Items.Add(new ListItem("青年營業所", "F15青年營業所"));
            ddl.Items.Add(new ListItem("楠梓營業所", "F16楠梓營業所"));
            ddl.Items.Add(new ListItem("瑞豐營業所", "F17瑞豐營業所"));
            ddl.Items.Add(new ListItem("右昌營業所", "F18右昌營業所"));
            ddl.Items.Add(new ListItem("東港營業所", "F20東港營業所"));
            ddl.Items.Add(new ListItem("鳳林營業所", "F22鳳林營業所"));
            ddl.Items.Add(new ListItem("三多營業所", "F27三多營業所"));
            ddl.Items.Add(new ListItem("民族營業所", "F52民族營業所"));
            ddl.Items.Add(new ListItem("建國營業所", "F53建國營業所"));
            ddl.Items.Add(new ListItem("岡山服務廠", "F03岡山服務廠"));
            ddl.Items.Add(new ListItem("屏東服務廠", "F04屏東服務廠"));
            ddl.Items.Add(new ListItem("北高服務廠", "F07北高服務廠"));
            ddl.Items.Add(new ListItem("旗山服務廠", "F08旗山服務廠"));
            ddl.Items.Add(new ListItem("潮州服務廠", "F09潮州服務廠"));
            ddl.Items.Add(new ListItem("小港服務廠", "F10小港服務廠"));
            ddl.Items.Add(new ListItem("九如服務廠", "F11九如服務廠"));
            ddl.Items.Add(new ListItem("鳳山服務廠", "F12鳳山服務廠"));
            ddl.Items.Add(new ListItem("湖內服務廠", "F13湖內服務廠"));
            ddl.Items.Add(new ListItem("北屏服務廠", "F14北屏服務廠"));
            ddl.Items.Add(new ListItem("青年服務廠", "F15青年服務廠"));
            ddl.Items.Add(new ListItem("楠梓服務廠", "F16楠梓服務廠"));
            ddl.Items.Add(new ListItem("瑞豐服務廠", "F17瑞豐服務廠"));
            ddl.Items.Add(new ListItem("右昌服務廠", "F18右昌服務廠"));
            ddl.Items.Add(new ListItem("麟洛服務廠", "F19麟洛服務廠"));
            ddl.Items.Add(new ListItem("東港服務廠", "F20東港服務廠"));
            ddl.Items.Add(new ListItem("里港服務廠", "F21里港服務廠"));
            ddl.Items.Add(new ListItem("鳳林服務廠", "F22鳳林服務廠"));
            ddl.Items.Add(new ListItem("恆春服務廠", "F24恆春服務廠"));
            ddl.Items.Add(new ListItem("三多服務廠", "F27三多服務廠"));
            ddl.Items.Add(new ListItem("LEXUS九如服務廠", "F51LEXUS九如服務廠"));
            ddl.Items.Add(new ListItem("民族服務廠", "F52民族服務廠"));
            ddl.Items.Add(new ListItem("建國服務廠", "F53建國服務廠"));
            ddl.Items.Add(new ListItem("PDS物流整備-九如", "PDS物流整備-九如"));
            ddl.Items.Add(new ListItem("PDS物流整備-岡山", "PDS物流整備-岡山"));
            ddl.Items.Add(new ListItem("PDS物流整備-鳳山", "PDS物流整備-鳳山"));
            ddl.Items.Add(new ListItem("資訊室", "資訊室"));
            ddl.Items.Add(new ListItem("綜合企劃室", "綜合企劃室"));
            ddl.Items.Add(new ListItem("總務室", "總務室"));
            ddl.Items.Add(new ListItem("人資法務室", "人資法務室"));
            ddl.Items.Add(new ListItem("秘書室", "秘書室"));
            ddl.Items.Add(new ListItem("保險分期室", "保險分期室"));
            ddl.Items.Add(new ListItem("直販室", "直販室"));
            ddl.Items.Add(new ListItem("需給室", "需給室"));
            ddl.Items.Add(new ListItem("教育訓練室", "教育訓練室"));
            ddl.Items.Add(new ListItem("行銷企劃室", "行銷企劃室"));
            ddl.Items.Add(new ListItem("會計室", "會計室"));
            ddl.Items.Add(new ListItem("財務室", "財務室"));
            ddl.Items.Add(new ListItem("稽核室", "稽核室"));
            ddl.Items.Add(new ListItem("教育室", "教育室"));
            ddl.Items.Add(new ListItem("零件室", "零件室"));
            ddl.Items.Add(new ListItem("技術室", "技術室"));
            ddl.Items.Add(new ListItem("業務室", "業務室"));
            ddl.Items.Add(new ListItem("顧客關懷推進室", "顧客關懷推進室"));
            ddl.Items.Add(new ListItem("電話服務中心", "電話服務中心"));
            ddl.Items.Add(new ListItem("服務行銷室", "服務行銷室"));
            ddl.Items.Add(new ListItem("顧客關懷室", "顧客關懷室"));
            ddl.Items.Add(new ListItem("企劃室", "企劃室"));
            //ddl.Items.Add(new ListItem("管理部", "F820"));
            //ddl.Items.Add(new ListItem("車輛部", "F830"));
            //ddl.Items.Add(new ListItem("財務部", "F840"));
            //ddl.Items.Add(new ListItem("服務部", "F870"));
            //ddl.Items.Add(new ListItem("顧關部", "F880"));
            //ddl.Items.Add(new ListItem("LEXUS部", "F980"));
        }

    }
}
