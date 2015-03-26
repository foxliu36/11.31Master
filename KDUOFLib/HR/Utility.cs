using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;

namespace KDUOFLib.HR
{
    public class Utility
    {

        /// <summary>
        /// 考核專用
        /// </summary> 
        public static void setRANK(DropDownList ddl)
        {
            ddl.Items.Add(new ListItem("", ""));
            ddl.Items.Add(new ListItem("A. (90分以上)", "A"));
            ddl.Items.Add(new ListItem("B+(87~89分)", "B+"));
            ddl.Items.Add(new ListItem("B. (84~86分)", "B"));
            ddl.Items.Add(new ListItem("B- (80~83分)", "B-"));
            ddl.Items.Add(new ListItem("C+(77~79分)", "C+"));
            ddl.Items.Add(new ListItem("C (74~76分)", "C"));
            ddl.Items.Add(new ListItem("C- (70~73分)", "C-"));
            ddl.Items.Add(new ListItem("D+(67~69分)", "D+"));
            ddl.Items.Add(new ListItem("D. (64~66分)", "D"));
            ddl.Items.Add(new ListItem("D- (60~63分)", "D-"));
            ddl.Items.Add(new ListItem("F. (未滿59分)", "F"));
        }

        public static void setBranch(DropDownList ddl)
        {
            ddl.Items.Add(new ListItem("", ""));
            ddl.Items.Add(new ListItem( "F03岡山服務廠","b6cafe73-944f-438f-950e-77942b5e771f"));
            ddl.Items.Add(new ListItem( "F03岡山營業所","82bea600-2433-439f-9f67-c1203408184d"));
            ddl.Items.Add(new ListItem( "F04屏東服務廠","667d6d53-a314-4825-9a39-79c08912e00c"));
            ddl.Items.Add(new ListItem( "F04屏東營業所","63acec50-f693-4b21-85cd-f71d6be09759"));
            ddl.Items.Add(new ListItem( "F07北高服務廠","da352403-2f03-4ee8-af9e-3033da572e92"));
            ddl.Items.Add(new ListItem( "F07北高營業所","a2b88531-2de5-4a84-9791-fa3f8e6649ce"));
            ddl.Items.Add(new ListItem( "F08旗山服務廠","593af315-b1db-4224-ae25-dab942dfe88f"));
            ddl.Items.Add(new ListItem( "F08旗山營業所","cc334965-7ae5-42a0-b9d5-b7cb63e8a373"));
            ddl.Items.Add(new ListItem( "F09潮州服務廠","9a4bc7db-02f1-4344-9669-048cfcdd9e03"));
            ddl.Items.Add(new ListItem( "F09潮州營業所","4b587a7f-d7c4-40cc-8078-ab446ce8b643"));
            ddl.Items.Add(new ListItem( "F10小港服務廠","ceefea0e-4093-40d4-ac79-28ccaa2031d6"));
            ddl.Items.Add(new ListItem( "F10小港營業所","bc5e3430-b032-40a2-b0a7-47fe12ec6cdb"));
            ddl.Items.Add(new ListItem( "F11九如服務廠","4e44ed39-f4e5-4743-9816-19008aa6c54e"));
            ddl.Items.Add(new ListItem( "F11九如營業所","f8c393ee-17c5-4b29-a414-e8b3ec649fed"));
            ddl.Items.Add(new ListItem( "F12鳳山服務廠","c401ebc0-8245-4c38-8c9a-2c724c74c5cf"));
            ddl.Items.Add(new ListItem( "F12鳳山營業所","4493decd-5609-4f1b-8637-65fa8f752488"));
            ddl.Items.Add(new ListItem( "F13湖內服務廠","f95c0c7e-a6c5-488c-ae49-22f56a7b9f39"));
            ddl.Items.Add(new ListItem( "F13湖內營業所","326dedbe-1acf-4994-b4c1-5c7cfc6131e8"));
            ddl.Items.Add(new ListItem( "F14北屏服務廠","bcf72643-8361-4952-b679-8a02a80c5db6"));
            ddl.Items.Add(new ListItem( "F14北屏營業所","8b567de9-f340-42da-a2be-d4d4339fe6f3"));
            ddl.Items.Add(new ListItem( "F15青年服務廠","0794312b-7887-4075-b505-9e4a65e393db"));
            ddl.Items.Add(new ListItem( "F15青年營業所","4dde4903-338a-46dd-9b2d-ccd2b1d74045"));
            ddl.Items.Add(new ListItem( "F16楠梓服務廠","0b5867c1-1c3a-4990-9c57-0f267b9ac76c"));
            ddl.Items.Add(new ListItem( "F16楠梓營業所","ef44d26f-52bd-d024-906e-a517ebb7ab48"));
            ddl.Items.Add(new ListItem( "F17瑞豐服務廠","3ebabded-71f4-44c1-97fe-bf24da011c91"));
            ddl.Items.Add(new ListItem( "F17瑞豐營業所","8cb80418-d096-4a3d-aa07-b6cd3f0c305c"));
            ddl.Items.Add(new ListItem( "F18右昌服務廠","160910c6-affe-43de-8d59-4f7d5e6b5702"));
            ddl.Items.Add(new ListItem( "F18右昌營業所","4d65a5dc-51fa-432b-b1aa-4aa3a26edf24"));
            ddl.Items.Add(new ListItem( "F19麟洛服務廠","f65e7301-edf3-4572-bae8-8d847f6805ff"));
            ddl.Items.Add(new ListItem( "F20東港服務廠","17ad2b82-b5a0-457a-ba74-248bd2725e95"));
            ddl.Items.Add(new ListItem( "F20東港營業所","3111523e-ed56-442f-a351-9e3b7b314776"));
            ddl.Items.Add(new ListItem( "F21里港服務廠","62400218-3134-427e-b0d2-bd159de7eda1"));
            ddl.Items.Add(new ListItem( "F22鳳林服務廠","463d4d93-f71d-45f5-8727-5963308d7264"));
            ddl.Items.Add(new ListItem( "F22鳳林營業所","7abadd40-4a9a-49aa-9b96-0a8246330bf2"));
            ddl.Items.Add(new ListItem( "F24恆春服務廠","9c23e5fc-252d-4db8-b6d7-a2bfdbf218d3"));
            ddl.Items.Add(new ListItem( "F27三多服務廠","ea6e9a77-78a3-492f-9375-e14a2b5e4fd7"));
            ddl.Items.Add(new ListItem( "F27三多營業所","29fa7a83-98d4-4822-99e0-9b75e41b06be"));
            ddl.Items.Add(new ListItem( "F51LEXUS九如服務廠","98620a91-1353-4db7-90ec-314d6ac951b3"));
            ddl.Items.Add(new ListItem( "F52民族服務廠","20d7d5af-bcb6-4871-8706-e495c99f945b"));
            ddl.Items.Add(new ListItem( "F52民族營業所","9386ca5e-9826-448c-8b01-0f88460de097"));
            ddl.Items.Add(new ListItem( "F53建國服務廠","8daddd5e-58cf-4a54-8333-5ce83e599c93"));
            ddl.Items.Add(new ListItem( "F53建國營業所","8d49be58-a9ad-4ee1-ad4b-519d25c8ec87"));
            ddl.Items.Add(new ListItem( "LEXUS本部","ec3b71f3-085a-a11b-fdf2-35effff188c0"));
            ddl.Items.Add(new ListItem( "LEXUS車輛部","f481bcd0-e90c-88f9-a636-9061414d52a1"));
            ddl.Items.Add(new ListItem( "LEXUS服務部","e153a54d-572d-9c4e-3afb-52d00d5f66b2"));
            ddl.Items.Add(new ListItem( "LEXUS營業所","d9f98002-38a6-f1ce-929b-270e7bdbdc50"));
            ddl.Items.Add(new ListItem( "PDS物流整備","fefaa691-aef0-4725-086a-b33328cfe9af"));
            ddl.Items.Add(new ListItem( "PDS物流整備-九如","9ed8ee69-d262-4960-96ab-5bce4d377afd"));
            ddl.Items.Add(new ListItem( "PDS物流整備-岡山","5907ee69-ed54-7b56-0c9f-1e79532e3e9a"));
            ddl.Items.Add(new ListItem( "PDS物流整備-鳳山","e6c0a779-7c3d-3de9-a8d2-71a1e59f44c3"));
            ddl.Items.Add(new ListItem( "TOYOTA本部","dfd2ff59-9f10-c19c-f736-2a7f39ea18ee"));
            ddl.Items.Add(new ListItem( "TOYOTA車輛部","c3099a91-ce71-d747-760e-3ffdd8114fac"));
            ddl.Items.Add(new ListItem( "TOYOTA服務部","3536f078-58c8-5dfb-1e01-daf422a24a07"));
            ddl.Items.Add(new ListItem( "TOYOTA營業所","426b3490-4430-4979-80eb-64694fdd25a5"));
            ddl.Items.Add(new ListItem( "TOYOTA顧客關懷部","469f356c-3821-cab8-51e4-ce32012e7638"));
            ddl.Items.Add(new ListItem( "人資法務室","3ad89eda-1775-a969-7df9-86c54b91518f"));
            ddl.Items.Add(new ListItem( "大陸業務部","beb14e1a-cd57-6ac2-14e2-e7aaed635ce3"));
            ddl.Items.Add(new ListItem( "中古車室","7f01a398-fe7d-1afa-9a82-015a7f1b612f"));
            ddl.Items.Add(new ListItem( "北區","082b8623-6e17-f256-eae4-aa482f3dd91a"));
            ddl.Items.Add(new ListItem( "市區","2a8c9ac9-b1c4-996a-3871-0eb74d9efc01"));
            ddl.Items.Add(new ListItem( "企劃室","83c43e4b-1eb7-ebb6-e6fc-f7399701fcfb"));
            ddl.Items.Add(new ListItem( "T車輛地區擔當室","5efae20a-f5d7-0cc5-5a25-831dfede9398"));
            ddl.Items.Add(new ListItem( "T服務地區擔當室","3a91e7c7-bf37-769e-862d-1c8456920fa4"));
            ddl.Items.Add(new ListItem( "技術室","62c1eeb0-0f19-ab19-8e91-40e2400ea894"));
            ddl.Items.Add(new ListItem( "服務行銷室","0dcf2355-0b47-f92a-9138-b92719cb109d"));
            ddl.Items.Add(new ListItem( "服務廠","3a08451e-4785-12f2-6f5b-7bd2da4c7685"));
            ddl.Items.Add(new ListItem( "直販室","dba570b4-05ad-eec3-e957-29618d25234f"));
            ddl.Items.Add(new ListItem( "保險分期室","9f0e67c4-1d78-703a-adcd-c401d126bf76"));
            ddl.Items.Add(new ListItem( "南區","5c24f715-5f11-3e03-53e2-9fc3e8b38799"));
            ddl.Items.Add(new ListItem( "郊區","81f997ae-c01a-d334-56b0-0029d0fa9de8"));
            ddl.Items.Add(new ListItem( "秘書室","e9cbf0f4-c634-dd1b-701e-7171cb08497f"));
            ddl.Items.Add(new ListItem( "財務室","7df6ec3f-c86d-9155-ac64-94af2a4e22e1"));
            ddl.Items.Add(new ListItem( "財務部","7bc8c41d-7343-1cf3-c6ad-32fd2a77435a"));
            ddl.Items.Add(new ListItem( "高輊","5ecb6b1b-42e4-7aaa-ff4b-bba6a72a81e4"));
            ddl.Items.Add(new ListItem( "教育室","cf6b4093-0c28-3fb6-dfb4-a956b3d5fdb1"));
            ddl.Items.Add(new ListItem( "教育訓練室","e19c0389-3086-a343-5e39-796dbf4a16d3"));
            ddl.Items.Add(new ListItem("行銷企劃室", "9d080135-5fe9-2efc-5c38-540e8db2fe50"));
            ddl.Items.Add(new ListItem( "新強動力","c07f4895-81bd-0459-b89e-421a57b9bf43"));
            ddl.Items.Add(new ListItem( "會計室","8067f8f4-d7ca-6a07-11b3-af99debf2b29"));
            ddl.Items.Add(new ListItem( "L業務室","ade8e6c5-47aa-883e-2797-c82793e4e3a9"));
            ddl.Items.Add(new ListItem( "T業務室","a7c15e27-91a6-16f5-afbf-92b17f500238"));
            ddl.Items.Add(new ListItem( "資訊室","435b7eb3-1f24-0d16-42e3-2841ad415fe9"));
            ddl.Items.Add(new ListItem( "電話服務中心","d2c826e8-f05b-0e6d-5b3f-250fe60112df"));
            ddl.Items.Add(new ListItem( "零件室","9f15257b-3f49-c6c8-e46e-c532d6811fef"));
            ddl.Items.Add(new ListItem( "福委會","bfa00b5f-ebd7-74e5-196a-758493393d03"));
            ddl.Items.Add(new ListItem( "管理本部","48588910-cf3c-f692-f3d1-21e6a9abdaee"));
            ddl.Items.Add(new ListItem( "管理部","ad3c5442-c047-1584-b0fb-fa21e1d68294"));
            ddl.Items.Add(new ListItem( "綜合企劃室","cc44216a-60ef-8eed-d7b9-39027584c18b"));
            ddl.Items.Add(new ListItem( "需給室","ee2921c4-551c-f0c8-7371-f0cf606e6534"));
            ddl.Items.Add(new ListItem( "稽核室","3f56c9a1-fdcf-a20e-e502-739db12d80ce"));
            ddl.Items.Add(new ListItem( "據點","376cdba5-b793-cda7-af10-f19f6dcf7711"));
            ddl.Items.Add(new ListItem( "總務室","4387bbe4-e9cc-1d10-0a6c-512c01b4f3fa"));
            ddl.Items.Add(new ListItem( "顧客服務室","44cd4a1f-918e-2694-3aed-74593fb9ea8a"));
            ddl.Items.Add(new ListItem( "顧客關懷推進室","7e6041b5-a27d-4d68-46e3-855b5abfe89c"));
            ddl.Items.Add(new ListItem( "顧問室","ff63429d-c202-6046-91ac-927887d56fca"));
        }

        public static string ReturnGROUP_ID(string p_GROUP_NAME)
        {
            switch (p_GROUP_NAME)
            {
                case "岡山營業所/營一課":
                    return "fd309ddb-45a9-6c3b-737e-fcc225b0d9b6";
                case "岡山營業所/營二課":
                    return "34261042-efa7-2c7d-0939-a8920cf06478";
                case "TOYOTA服務部/岡山服務廠":
                case "岡山服務廠/引擎組":
                case "岡山服務廠/服務專員組":
                case "岡山服務廠/鈑金組":
                case "岡山服務廠/零件組":
                case "岡山服務廠/噴漆組":
                case "岡山服務廠/檢驗線組":
                    return "b6cafe73-944f-438f-950e-77942b5e771f";
                case "TOYOTA車輛部/岡山營業所":
                    return "82bea600-2433-439f-9f67-c1203408184d";
                case "屏東營業所/營一課":
                    return "139be303-cb80-4944-377d-f9e70401c4be";
                case "屏東營業所/營二課":
                    return "b7a0fd14-0380-87a9-c06c-7e8bbdcf1ee9";
                case "TOYOTA服務部/屏東服務廠":
                case "屏東服務廠/引擎組":
                case "屏東服務廠/服務專員組":
                case "屏東服務廠/鈑金組":
                case "屏東服務廠/零件組":
                case "屏東服務廠/噴漆組":
                    return "667d6d53-a314-4825-9a39-79c08912e00c";
                case "TOYOTA車輛部/屏東營業所":
                    return "63acec50-f693-4b21-85cd-f71d6be09759";
                case "北高營業所/營一課":
                    return "4f9e7989-972f-9e13-18d4-729722fa3ade";
                case "北高營業所/營二課":
                    return "fbcabd31-2b9e-5350-0d33-134a707c0803";
                case "北高營業所/營三課":
                    return "3767b21e-c61c-2be2-9562-05aa679b044f";
                case "北高營業所/營五課":
                    return "57c20f59-b799-43ee-a863-e1754892ffcd";
                case "北高營業所/營四課":
                    return "00c2bab6-dddd-5df5-5f7d-4a79a865705d";
                case "TOYOTA服務部/北高服務廠":
                case "北高服務廠/引擎組":
                case "北高服務廠/服務專員組":
                case "北高服務廠/鈑金組":
                case "北高服務廠/零件組":
                case "北高服務廠/噴漆組":
                case "北高服務廠/檢驗線組":
                    return "da352403-2f03-4ee8-af9e-3033da572e92";
                case "TOYOTA車輛部/北高營業所":
                    return "a2b88531-2de5-4a84-9791-fa3f8e6649ce";
                case "旗山營業所/營一課":
                    return "a1ba63b4-b7dc-0db1-46ca-9343271329a3";
                case "TOYOTA服務部/旗山服務廠":
                case "旗山服務廠/引擎組":
                case "旗山服務廠/服務專員組":
                case "旗山服務廠/鈑金組":
                case "旗山服務廠/零件組":
                case "旗山服務廠/噴漆組":
                    return "593af315-b1db-4224-ae25-dab942dfe88f";
                case "TOYOTA車輛部/旗山營業所":
                    return "cc334965-7ae5-42a0-b9d5-b7cb63e8a373";
                case "潮州營業所/營一課":
                    return "4414dadd-bd80-7da2-6471-c93f18e04db8";
                case "潮州營業所/營二課":
                    return "ca76db58-dc39-757c-04d5-95b69b33fb6e";
                case "TOYOTA服務部/潮州服務廠":
                case "潮州服務廠/引擎組":
                case "潮州服務廠/服務專員組":
                case "潮州服務廠/鈑金組":
                case "潮州服務廠/零件組":
                case "潮州服務廠/噴漆組":
                    return "9a4bc7db-02f1-4344-9669-048cfcdd9e03";
                case "TOYOTA車輛部/潮州營業所":
                    return "4b587a7f-d7c4-40cc-8078-ab446ce8b643";
                case "小港營業所/營一課":
                    return "8dd6d848-db05-b3e9-e5fc-7606819ed8f0";
                case "TOYOTA服務部/小港服務廠":
                case "小港服務廠/引擎組":
                case "小港服務廠/服務專員組":
                case "小港服務廠/鈑金組":
                case "小港服務廠/零件組":
                case "小港服務廠/噴漆組":
                    return "ceefea0e-4093-40d4-ac79-28ccaa2031d6";
                case "TOYOTA車輛部/小港營業所":
                    return "bc5e3430-b032-40a2-b0a7-47fe12ec6cdb";
                case "九如營業所/營一課":
                    return "c5348132-c8a1-4e71-bd3a-5c63f2d672ff";
                case "九如營業所/營二課":
                    return "bd2ef0d7-edc6-c5ba-1784-3240ed247345";
                case "TOYOTA服務部/九如服務廠":
                case "九如服務廠/引擎組":
                case "九如服務廠/服務專員組":
                case "九如服務廠/鈑金組":
                case "九如服務廠/零件組":
                case "九如服務廠/噴漆組":
                case "九如服務廠/檢驗線組":
                    return "4e44ed39-f4e5-4743-9816-19008aa6c54e";
                case "TOYOTA車輛部/九如營業所":
                    return "f8c393ee-17c5-4b29-a414-e8b3ec649fed";
                case "鳳山營業所/營一課":
                    return "96cd1be3-0b7e-897e-4345-10451f4ce364";
                case "鳳山營業所/營二課":
                    return "88db1f18-8846-5a6d-401d-3b64cdc54883";
                case "TOYOTA服務部/鳳山服務廠":
                case "鳳山服務廠/引擎組":
                case "鳳山服務廠/服務專員組":
                case "鳳山服務廠/鈑金組":
                case "鳳山服務廠/零件組":
                case "鳳山服務廠/噴漆組":
                case "鳳山服務廠/檢驗線組":
                    return "c401ebc0-8245-4c38-8c9a-2c724c74c5cf";
                case "TOYOTA車輛部/鳳山營業所":
                    return "4493decd-5609-4f1b-8637-65fa8f752488";
                case "湖內營業所/營一課":
                    return "47e1a518-c4df-148d-237c-53f6c2feea77";
                case "TOYOTA服務部/湖內服務廠":
                case "湖內服務廠/引擎組":
                case "湖內服務廠/服務專員組":
                case "湖內服務廠/鈑金組":
                case "湖內服務廠/零件組":
                case "湖內服務廠/噴漆組":
                    return "f95c0c7e-a6c5-488c-ae49-22f56a7b9f39";
                case "TOYOTA車輛部/湖內營業所":
                    return "326dedbe-1acf-4994-b4c1-5c7cfc6131e8";
                case "北屏營業所/營一課":
                    return "d399418d-a844-f09a-35ea-a8fffafc30e5";
                case "北屏營業所/營二課":
                    return "0b122fc9-33a0-616c-c9e8-ac5a34779e4e";
                case "TOYOTA服務部/北屏服務廠":
                case "北屏服務廠/引擎組":
                case "北屏服務廠/服務專員組":
                case "北屏服務廠/零件組":
                    return "bcf72643-8361-4952-b679-8a02a80c5db6";
                case "TOYOTA車輛部/北屏營業所":
                    return "8b567de9-f340-42da-a2be-d4d4339fe6f3";
                case "青年營業所/營一課":
                    return "064f1a10-1c1e-6e40-9dfb-7334da92d1e2";
                case "青年營業所/營二課":
                    return "44e4fa19-6932-105b-738c-8d593ba4cfb3";
                case "TOYOTA服務部/青年服務廠":
                case "青年服務廠/引擎組":
                case "青年服務廠/服務專員組":
                case "青年服務廠/零件組":
                    return "0794312b-7887-4075-b505-9e4a65e393db";
                case "TOYOTA車輛部/青年營業所":
                    return "4dde4903-338a-46dd-9b2d-ccd2b1d74045";
                case "楠梓營業所/營一課":
                    return "6a5e05ba-5146-5e42-4e00-004e1deaafbd";
                case "TOYOTA服務部/楠梓服務廠":
                case "楠梓服務廠/引擎組":
                case "楠梓服務廠/服務專員組":
                case "楠梓服務廠/鈑金組":
                case "楠梓服務廠/零件組":
                case "楠梓服務廠/噴漆組":
                    return "0b5867c1-1c3a-4990-9c57-0f267b9ac76c";
                case "TOYOTA車輛部/楠梓營業所":
                    return "ef44d26f-52bd-d024-906e-a517ebb7ab48";
                case "瑞豐營業所/營一課":
                    return "5f00d31b-2317-2af9-028d-fae649c39b83";
                case "瑞豐營業所/營二課":
                    return "c8181634-3372-2e1f-7c00-af4ac482b973";
                case "TOYOTA服務部/瑞豐服務廠":
                case "瑞豐服務廠/引擎組":
                case "瑞豐服務廠/服務專員組":
                case "瑞豐服務廠/零件組":
                    return "3ebabded-71f4-44c1-97fe-bf24da011c91";
                case "TOYOTA車輛部/瑞豐營業所":
                    return "8cb80418-d096-4a3d-aa07-b6cd3f0c305c";
                case "右昌營業所/營一課":
                    return "5a48e343-431d-d4b6-f743-dbf1b596679a";
                case "右昌營業所/營二課":
                    return "93e3db8e-0011-bf80-6f2e-bf99ccf3a7a4";
                case "TOYOTA服務部/右昌服務廠":
                case "右昌服務廠/引擎組":
                case "右昌服務廠/服務專員組":
                case "右昌服務廠/零件組":
                    return "160910c6-affe-43de-8d59-4f7d5e6b5702";
                case "TOYOTA車輛部/右昌營業所":
                    return "4d65a5dc-51fa-432b-b1aa-4aa3a26edf24";
                case "TOYOTA服務部/麟洛服務廠":
                case "麟洛服務廠/引擎組":
                case "麟洛服務廠/服務專員組":
                case "麟洛服務廠/鈑金組":
                case "麟洛服務廠/零件組":
                case "麟洛服務廠/噴漆組":
                    return "f65e7301-edf3-4572-bae8-8d847f6805ff";
                case "東港營業所/營一課":
                    return "17e96a02-0a8e-b057-fb65-33f40f79325e";
                case "TOYOTA服務部/東港服務廠":
                case "東港服務廠/引擎組":
                case "東港服務廠/服務專員組":
                case "東港服務廠/鈑金組":
                case "東港服務廠/零件組":
                case "東港服務廠/噴漆組":
                    return "17ad2b82-b5a0-457a-ba74-248bd2725e95";
                case "TOYOTA車輛部/東港營業所":
                    return "3111523e-ed56-442f-a351-9e3b7b314776";
                case "TOYOTA服務部/里港服務廠":
                case "里港服務廠/引擎組":
                case "里港服務廠/服務專員組":
                    return "62400218-3134-427e-b0d2-bd159de7eda1";
                case "鳳林營業所/營一課":
                    return "e3a19f1c-378b-a692-fc58-0e255a807124";
                case "TOYOTA服務部/鳳林服務廠":
                case "鳳林服務廠/引擎組":
                case "鳳林服務廠/服務專員組":
                case "鳳林服務廠/鈑金組":
                case "鳳林服務廠/零件組":
                case "鳳林服務廠/噴漆組":
                    return "463d4d93-f71d-45f5-8727-5963308d7264";
                case "TOYOTA車輛部/鳳林營業所":
                    return "7abadd40-4a9a-49aa-9b96-0a8246330bf2";
                case "TOYOTA服務部/恆春服務廠":
                case "恆春服務廠/引擎組":
                case "恆春服務廠/服務專員組":
                case "恆春服務廠/鈑金組":
                case "恆春服務廠/零件組":
                case "恆春服務廠/噴漆組":
                    return "9c23e5fc-252d-4db8-b6d7-a2bfdbf218d3";
                case "三多營業所/營一課":
                    return "046479b3-7b3e-da9d-9d09-616c3435a159";
                case "三多營業所/營二課":
                    return "b39bc011-6cb9-d9cb-ba78-d245d3e46b40";
                case "TOYOTA服務部/三多服務廠":
                case "三多服務廠/引擎組":
                case "三多服務廠/服務專員組":
                case "三多服務廠/零件組":
                    return "ea6e9a77-78a3-492f-9375-e14a2b5e4fd7";
                case "TOYOTA車輛部/三多營業所":
                    return "29fa7a83-98d4-4822-99e0-9b75e41b06be";
                case "LEXUS九如服務廠/引擎組":
                case "LEXUS九如服務廠/服務專員組":
                case "LEXUS九如服務廠/鈑金組":
                case "LEXUS九如服務廠/零件組":
                case "LEXUS九如服務廠/噴漆組":
                case "LEXUS九如服務廠/接待取送組":
                case "LEXUS九如服務廠/TEAM A":
                case "LEXUS服務部/LEXUS九如服務廠":
                    return "98620a91-1353-4db7-90ec-314d6ac951b3";
                case "LEXUS車輛部/民族營業所":
                    return "9df642e9-ad92-e633-bb11-37c6dd31b198";
                case "LEXUS服務部/民族服務廠":
                case "民族服務廠/TEAM A":
                case "民族服務廠/引擎組":
                case "民族服務廠/服務專員組":
                case "民族服務廠/鈑金組":
                case "民族服務廠/零件組":
                case "民族服務廠/噴漆組":
                case "民族服務廠/接待取送組":
                    return "20d7d5af-bcb6-4871-8706-e495c99f945b";
                case "LEXUS服務部/建國服務廠":
                case "建國服務廠/TEAM A":
                case "建國服務廠/引擎組":
                case "建國服務廠/服務專員組":
                case "建國服務廠/鈑金組":
                case "建國服務廠/零件組":
                case "建國服務廠/噴漆組":
                case "建國服務廠/接待取送組":
                    return "8daddd5e-58cf-4a54-8333-5ce83e599c93";
                case "LEXUS車輛部/建國營業所":
                    return "8d49be58-a9ad-4ee1-ad4b-519d25c8ec87";
                case "總經理室/LEXUS本部":
                    return "ec3b71f3-085a-a11b-fdf2-35effff188c0";
                case "LEXUS本部/LEXUS車輛部":
                    return "f481bcd0-e90c-88f9-a636-9061414d52a1";
                case "LEXUS本部/LEXUS服務部":
                    return "e153a54d-572d-9c4e-3afb-52d00d5f66b2";
                case "TOYOTA車輛部/九如物流管理室":
                    return "9ed8ee69-d262-4960-96ab-5bce4d377afd";
                case "TOYOTA車輛部/岡山物流管理室":
                    return "5907ee69-ed54-7b56-0c9f-1e79532e3e9a";
                case "TOYOTA車輛部/鳳山物流管理室":
                    return "e6c0a779-7c3d-3de9-a8d2-71a1e59f44c3";
                case "總經理室/TOYOTA本部":
                    return "c3099a91-ce71-d747-760e-3ffdd8114fac";
                case "TOYOTA本部/TOYOTA服務部":
                    return "3536f078-58c8-5dfb-1e01-daf422a24a07";
                case "TOYOTA本部/TOYOTA顧客關懷部":
                    return "469f356c-3821-cab8-51e4-ce32012e7638";
                case "管理部/人資法務室":
                    return "3ad89eda-1775-a969-7df9-86c54b91518f";
                case "總經理室/大陸事業部":
                    return "beb14e1a-cd57-6ac2-14e2-e7aaed635ce3";
                case "LEXUS車輛部/企劃室":
                    return "83c43e4b-1eb7-ebb6-e6fc-f7399701fcfb";
                case "TOYOTA車輛部/行銷企劃室":
                    return "9d080135-5fe9-2efc-5c38-540e8db2fe50";
                case "TOYOTA服務部/技術室":
                    return "62c1eeb0-0f19-ab19-8e91-40e2400ea894";
                case "LEXUS服務部/服務行銷室":
                    return "0dcf2355-0b47-f92a-9138-b92719cb109d";
                case "TOYOTA車輛部/保險分期室":
                    return "9f0e67c4-1d78-703a-adcd-c401d126bf76";
                case "管理本部/秘書室":
                    return "e9cbf0f4-c634-dd1b-701e-7171cb08497f";
                case "財務部/財務室":
                    return "7df6ec3f-c86d-9155-ac64-94af2a4e22e1";
                case "管理本部/財務部":
                    return "7bc8c41d-7343-1cf3-c6ad-32fd2a77435a";
                case "TOYOTA服務部/教育室":
                    return "cf6b4093-0c28-3fb6-dfb4-a956b3d5fdb1";
                case "TOYOTA車輛部/教育訓練室":
                    return "e19c0389-3086-a343-5e39-796dbf4a16d3";
                case "財務部/會計室":
                    return "8067f8f4-d7ca-6a07-11b3-af99debf2b29";
                case "LEXUS車輛部/業務室":
                    return "ade8e6c5-47aa-883e-2797-c82793e4e3a9";
                case "TOYOTA服務部/業務室":
                    return "a7c15e27-91a6-16f5-afbf-92b17f500238";
                case "管理部/資訊室":
                    return "435b7eb3-1f24-0d16-42e3-2841ad415fe9";
                case "TOYOTA服務部/零件室":
                    return "9f15257b-3f49-c6c8-e46e-c532d6811fef";
                case "TOYOTA顧客關懷部/電話服務中心":
                    return "d2c826e8-f05b-0e6d-5b3f-250fe60112df";
                case "管理本部/管理部":
                    return "ad3c5442-c047-1584-b0fb-fa21e1d68294";
                case "TOYOTA車輛部/需給室":
                    return "ee2921c4-551c-f0c8-7371-f0cf606e6534";
                case "總經理室/稽核室":
                    return "3f56c9a1-fdcf-a20e-e502-739db12d80ce";
                case "管理部/總務室":
                    return "4387bbe4-e9cc-1d10-0a6c-512c01b4f3fa";
                case "LEXUS服務部/顧客服務室":
                    return "44cd4a1f-918e-2694-3aed-74593fb9ea8a";
                case "TOYOTA顧客關懷部/顧客關懷推進室":
                    return "7e6041b5-a27d-4d68-46e3-855b5abfe89c";
                case "TOYOTA本部/TOYOTA車輛部":
                    return "c3099a91-ce71-d747-760e-3ffdd8114fac";
                case "TOYOTA車輛部/北高物流管理室":
                    return "c07f4895-81bd-0459-b89e-421a57b9bf43";
                case "總經理室/管理本部":
                    return "48588910-cf3c-f692-f3d1-21e6a9abdaee";
                case "董事長室":
                case "總經理室":
                    return "Company";
                default:
                    return " ";
            }
        }

        public static void setChinBranch(DropDownList ddl)
        {
            ddl.Items.Add(new ListItem("", ""));
            ddl.Items.Add(new ListItem("F03岡山服務廠", "F03岡山服務廠"));
            ddl.Items.Add(new ListItem("F03岡山營業所", "F03岡山營業所"));
            ddl.Items.Add(new ListItem("F04屏東服務廠", "F04屏東服務廠"));
            ddl.Items.Add(new ListItem("F04屏東營業所", "F04屏東營業所"));
            ddl.Items.Add(new ListItem("F07北高服務廠", "F07北高服務廠"));
            ddl.Items.Add(new ListItem("F07北高營業所", "F07北高營業所"));
            ddl.Items.Add(new ListItem("F08旗山服務廠", "F08旗山服務廠"));
            ddl.Items.Add(new ListItem("F08旗山營業所", "F08旗山營業所"));
            ddl.Items.Add(new ListItem("F09潮州服務廠", "F09潮州服務廠"));
            ddl.Items.Add(new ListItem("F09潮州營業所", "F09潮州營業所"));
            ddl.Items.Add(new ListItem("F10小港服務廠", "F10小港服務廠"));
            ddl.Items.Add(new ListItem("F10小港營業所", "F10小港營業所"));
            ddl.Items.Add(new ListItem("F11九如服務廠", "F11九如服務廠"));
            ddl.Items.Add(new ListItem("F11九如營業所", "F11九如營業所"));
            ddl.Items.Add(new ListItem("F12鳳山服務廠", "F12鳳山服務廠"));
            ddl.Items.Add(new ListItem("F12鳳山營業所", "F12鳳山營業所"));
            ddl.Items.Add(new ListItem("F13湖內服務廠", "F13湖內服務廠"));
            ddl.Items.Add(new ListItem("F13湖內營業所", "F13湖內營業所"));
            ddl.Items.Add(new ListItem("F14北屏服務廠", "F14北屏服務廠"));
            ddl.Items.Add(new ListItem("F14北屏營業所", "F14北屏營業所"));
            ddl.Items.Add(new ListItem("F15青年服務廠", "F15青年服務廠"));
            ddl.Items.Add(new ListItem("F15青年營業所", "F15青年營業所"));
            ddl.Items.Add(new ListItem("F16楠梓服務廠", "F16楠梓服務廠"));
            ddl.Items.Add(new ListItem("F16楠梓營業所", "F16楠梓營業所"));
            ddl.Items.Add(new ListItem("F17瑞豐服務廠", "F17瑞豐服務廠"));
            ddl.Items.Add(new ListItem("F17瑞豐營業所", "F17瑞豐營業所"));
            ddl.Items.Add(new ListItem("F18右昌服務廠", "F18右昌服務廠"));
            ddl.Items.Add(new ListItem("F18右昌營業所", "F18右昌營業所"));
            ddl.Items.Add(new ListItem("F19麟洛服務廠", "F19麟洛服務廠"));
            ddl.Items.Add(new ListItem("F20東港服務廠", "F20東港服務廠"));
            ddl.Items.Add(new ListItem("F20東港營業所", "F20東港營業所"));
            ddl.Items.Add(new ListItem("F21里港服務廠", "F21里港服務廠"));
            ddl.Items.Add(new ListItem("F22鳳林服務廠", "F22鳳林服務廠"));
            ddl.Items.Add(new ListItem("F22鳳林營業所", "F22鳳林營業所"));
            ddl.Items.Add(new ListItem("F24恆春服務廠", "F24恆春服務廠"));
            ddl.Items.Add(new ListItem("F27三多服務廠", "F27三多服務廠"));
            ddl.Items.Add(new ListItem("F27三多營業所", "F27三多營業所"));
            ddl.Items.Add(new ListItem("F51LEXUS九如服務廠", "F51LEXUS九如服務廠"));
            ddl.Items.Add(new ListItem("F52民族服務廠", "F52民族服務廠"));
            ddl.Items.Add(new ListItem("F52民族營業所", "F52民族營業所"));
            ddl.Items.Add(new ListItem("F53建國服務廠", "F53建國服務廠"));
            ddl.Items.Add(new ListItem("F53建國營業所", "F53建國營業所"));
            ddl.Items.Add(new ListItem("LEXUS本部", "LEXUS本部"));
            ddl.Items.Add(new ListItem("LEXUS車輛部", "LEXUS車輛部"));
            ddl.Items.Add(new ListItem("LEXUS服務部", "LEXUS服務部"));
            ddl.Items.Add(new ListItem("LEXUS服務廠", "LEXUS服務廠"));
            ddl.Items.Add(new ListItem("LEXUS營業所", "LEXUS營業所"));
            ddl.Items.Add(new ListItem("TOYOTA-KD", "TOYOTA-KD"));
            ddl.Items.Add(new ListItem("TOYOTA本部", "TOYOTA本部"));
            ddl.Items.Add(new ListItem("TOYOTA車輛部", "TOYOTA車輛部"));
            ddl.Items.Add(new ListItem("TOYOTA服務部", "TOYOTA服務部"));
            ddl.Items.Add(new ListItem("TOYOTA服務廠", "TOYOTA服務廠"));
            ddl.Items.Add(new ListItem("TOYOTA營業所", "TOYOTA營業所"));
            ddl.Items.Add(new ListItem("TOYOTA顧客關懷部", "TOYOTA顧客關懷部"));
            ddl.Items.Add(new ListItem("人資法務室", "人資法務室"));
            ddl.Items.Add(new ListItem("大陸業務部", "大陸業務部"));
            ddl.Items.Add(new ListItem("北區(車輛)", "北區(車輛)"));
            ddl.Items.Add(new ListItem("南區(車輛)", "南區(車輛)"));
            ddl.Items.Add(new ListItem("北區(服務)", "北區(服務)"));
            ddl.Items.Add(new ListItem("南區(服務)", "南區(服務)"));
            ddl.Items.Add(new ListItem("企劃室", "企劃室"));
            ddl.Items.Add(new ListItem("車輛地區擔當室", "車輛地區擔當室"));
            ddl.Items.Add(new ListItem("服務地區擔當室", "服務地區擔當室"));
            ddl.Items.Add(new ListItem("地區擔當室-北區", "地區擔當室-北區"));
            ddl.Items.Add(new ListItem("地區擔當室-南區", "地區擔當室-南區"));
            ddl.Items.Add(new ListItem("明誠", "明誠"));
            ddl.Items.Add(new ListItem("技術室", "技術室"));
            ddl.Items.Add(new ListItem("服務行銷室", "服務行銷室"));
            ddl.Items.Add(new ListItem("保險分期室", "保險分期室"));
            ddl.Items.Add(new ListItem("秘書室", "秘書室"));
            ddl.Items.Add(new ListItem("財務室", "財務室"));
            ddl.Items.Add(new ListItem("財務部", "財務部"));
            ddl.Items.Add(new ListItem("高輊", "高輊"));
            ddl.Items.Add(new ListItem("教育室", "教育室"));
            ddl.Items.Add(new ListItem("教育訓練室", "教育訓練室"));
            ddl.Items.Add(new ListItem("行銷企劃室", "行銷企劃室"));
            //ddl.Items.Add(new ListItem("新強動力", "新強動力"));
            ddl.Items.Add(new ListItem("會計室", "會計室"));
            ddl.Items.Add(new ListItem("L業務室", "L業務室"));
            ddl.Items.Add(new ListItem("T業務室", "T業務室"));
            ddl.Items.Add(new ListItem("資訊室", "資訊室"));
            ddl.Items.Add(new ListItem("零件室", "零件室"));
            ddl.Items.Add(new ListItem("電話服務中心", "電話服務中心"));
            ddl.Items.Add(new ListItem("福委會", "福委會"));
            ddl.Items.Add(new ListItem("管理本部", "管理本部"));
            ddl.Items.Add(new ListItem("管理部", "管理部"));
            //ddl.Items.Add(new ListItem("綜合企劃室", "綜合企劃室"));
            ddl.Items.Add(new ListItem("需給室", "需給室"));
            ddl.Items.Add(new ListItem("澄清", "澄清"));
            ddl.Items.Add(new ListItem("稽核室", "稽核室"));
            ddl.Items.Add(new ListItem("總務室", "總務室"));
            ddl.Items.Add(new ListItem("顧客服務室", "顧客服務室"));
            ddl.Items.Add(new ListItem("顧客關懷推進室", "顧客關懷推進室"));
            //ddl.Items.Add(new ListItem("顧問室", "顧問室"));
        }

        public static void setOPTION1(DropDownList ddl)
        {
            ddl.Items.Add(new ListItem("", ""));
            ddl.Items.Add(new ListItem("一職等", "一職等"));
            ddl.Items.Add(new ListItem("二職等", "二職等"));
            ddl.Items.Add(new ListItem("三職等", "三職等"));
            ddl.Items.Add(new ListItem("四職等", "四職等"));
            ddl.Items.Add(new ListItem("五職等", "五職等"));
            ddl.Items.Add(new ListItem("六職等", "六職等"));
            ddl.Items.Add(new ListItem("七職等", "七職等"));
            ddl.Items.Add(new ListItem("八職等", "八職等"));
            ddl.Items.Add(new ListItem("九職等", "九職等"));
            ddl.Items.Add(new ListItem("十職等", "十職等"));
            ddl.Items.Add(new ListItem("十一職等", "十一職等"));
            ddl.Items.Add(new ListItem("十二職等", "十二職等"));
            ddl.Items.Add(new ListItem("十三職等", "十三職等"));
            ddl.Items.Add(new ListItem("十四職等", "十四職等"));
            ddl.Items.Add(new ListItem("十五職等", "十五職等"));
            ddl.Items.Add(new ListItem("十六職等", "十六職等"));
            ddl.Items.Add(new ListItem("十七職等", "十七職等"));
            ddl.Items.Add(new ListItem("十八職等", "十八職等"));
            ddl.Items.Add(new ListItem("十九職等", "十九職等"));
            ddl.Items.Add(new ListItem("二十職等", "二十職等"));
        }

        public static void setTITLE_NAME(DropDownList ddl)
        {
            ddl.Items.Add(new ListItem("", ""));
            ddl.Items.Add(new ListItem("技術員（技師）", "技術員（技師）"));
            ddl.Items.Add(new ListItem("副課長", "副課長"));
            ddl.Items.Add(new ListItem("課長級銷售顧問", "課長級銷售顧問"));
            ddl.Items.Add(new ListItem("資深副理", "資深副理"));
            ddl.Items.Add(new ListItem("經理2", "經理2"));
            ddl.Items.Add(new ListItem("銷售主任", "銷售主任"));
            ddl.Items.Add(new ListItem("銷售副理", "銷售副理"));
            ddl.Items.Add(new ListItem("高級助理長", "高級助理長"));
            ddl.Items.Add(new ListItem("初級專員", "初級專員"));
            ddl.Items.Add(new ListItem("廠長", "廠長"));
            ddl.Items.Add(new ListItem("班長", "班長"));
            ddl.Items.Add(new ListItem("高級專員", "高級專員"));
            ddl.Items.Add(new ListItem("課長", "課長"));
            ddl.Items.Add(new ListItem("初級助理長", "初級助理長"));
            ddl.Items.Add(new ListItem("所長", "所長"));
            ddl.Items.Add(new ListItem("服務總監", "服務總監"));
            ddl.Items.Add(new ListItem("財管總監", "財管總監"));
            ddl.Items.Add(new ListItem("課長代行", "課長代行"));
            ddl.Items.Add(new ListItem("總經理", "總經理"));
            ddl.Items.Add(new ListItem("副課長代行", "副課長代行"));
            ddl.Items.Add(new ListItem("辦事員", "辦事員"));
            ddl.Items.Add(new ListItem("建教生", "建教生"));
            ddl.Items.Add(new ListItem("銷售經理", "銷售經理"));
            ddl.Items.Add(new ListItem("清潔員", "清潔員"));
            ddl.Items.Add(new ListItem("福委會人員", "福委會人員"));
            ddl.Items.Add(new ListItem("監工", "監工"));
            ddl.Items.Add(new ListItem("副廠長", "副廠長"));
            ddl.Items.Add(new ListItem("守衛", "守衛"));
            ddl.Items.Add(new ListItem("副理代行", "副理代行"));
            ddl.Items.Add(new ListItem("經理代行", "經理代行"));
            ddl.Items.Add(new ListItem("常務董事", "常務董事"));
            ddl.Items.Add(new ListItem("經理（經理1）", "經理（經理1）"));
            ddl.Items.Add(new ListItem("助理", "助理"));
            ddl.Items.Add(new ListItem("副理", "副理"));
            ddl.Items.Add(new ListItem("技師長", "技師長"));
            ddl.Items.Add(new ListItem("洗車員", "洗車員"));
            ddl.Items.Add(new ListItem("高級銷售顧問", "高級銷售顧問"));
            ddl.Items.Add(new ListItem("庶務工", "庶務工"));
            ddl.Items.Add(new ListItem("副理級銷售顧問", "副理級銷售顧問"));
            ddl.Items.Add(new ListItem("檢驗員", "檢驗員"));
            ddl.Items.Add(new ListItem("水電維護員", "水電維護員"));
            ddl.Items.Add(new ListItem("經理級銷售顧問", "經理級銷售顧問"));
            ddl.Items.Add(new ListItem("練習生（見習生）", "練習生（見習生）"));
            ddl.Items.Add(new ListItem("幫管理師", "幫管理師"));
            ddl.Items.Add(new ListItem("儲備專員", "儲備專員"));
            ddl.Items.Add(new ListItem("顧問", "顧問"));
            ddl.Items.Add(new ListItem("組長", "組長"));
            ddl.Items.Add(new ListItem("董事長", "董事長"));
            ddl.Items.Add(new ListItem("銷售襄理", "銷售襄理"));
            ddl.Items.Add(new ListItem("中級助理長", "中級助理長"));
            ddl.Items.Add(new ListItem("副總經理", "副總經理"));
            ddl.Items.Add(new ListItem("協理", "協理"));
            ddl.Items.Add(new ListItem("臨時人員", "臨時人員"));
            ddl.Items.Add(new ListItem("銷售專員", "銷售專員"));
            ddl.Items.Add(new ListItem("銷售課長", "銷售課長"));
            ddl.Items.Add(new ListItem("銷售顧問", "銷售顧問"));
            ddl.Items.Add(new ListItem("中級專員", "中級專員"));
        }

        public static void setCLASS(DropDownList ddl)
        {
            ddl.Items.Add(new ListItem("", ""));
            ddl.Items.Add(new ListItem("TEAM A", "TEAM A"));
            ddl.Items.Add(new ListItem("引擎組", "引擎組"));
            ddl.Items.Add(new ListItem("服務專員組", "服務專員組"));
            ddl.Items.Add(new ListItem("接待取送組", "接待取送組"));
            ddl.Items.Add(new ListItem("鈑金組", "鈑金組"));
            ddl.Items.Add(new ListItem("零件組", "零件組"));
            ddl.Items.Add(new ListItem("噴漆組", "噴漆組"));
            ddl.Items.Add(new ListItem("檢驗線組", "檢驗線組"));
            ddl.Items.Add(new ListItem("營一課", "營一課"));
            ddl.Items.Add(new ListItem("營二課", "營二課"));
            ddl.Items.Add(new ListItem("營三課", "營三課"));
            ddl.Items.Add(new ListItem("營四課", "營四課"));
            ddl.Items.Add(new ListItem("營五課", "營五課"));           
        }

        public static void setM_Movetype(DropDownList ddl)
        {
            ddl.Items.Add(new ListItem("", ""));
            ddl.Items.Add(new ListItem("調任", "調任"));
            ddl.Items.Add(new ListItem("晉升", "晉升"));
            ddl.Items.Add(new ListItem("調升", "調升"));
            ddl.Items.Add(new ListItem("降調", "降調"));
            ddl.Items.Add(new ListItem("改敘", "改敘"));
            ddl.Items.Add(new ListItem("降任", "降任"));
            ddl.Items.Add(new ListItem("並任", "並任"));
        }

    }
}
