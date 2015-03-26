using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;

namespace KDUOFLib.REW
{
    public class Utility
    {
        /// <summary>
        /// 2014員介車專用
        /// </summary> 
        /// 總據點名稱
        public static string ReturnUnit(string p_GROUP_id)
        {
            switch (p_GROUP_id)
            {
                case "82bea600-2433-439f-9f67-c1203408184d":  //F03岡山營業所
                case "63acec50-f693-4b21-85cd-f71d6be09759":  //F04屏東營業所
                case "a2b88531-2de5-4a84-9791-fa3f8e6649ce":  //F07北高營業所
                case "cc334965-7ae5-42a0-b9d5-b7cb63e8a373":  //F08旗山營業所
                case "4b587a7f-d7c4-40cc-8078-ab446ce8b643":  //F09潮州營業所
                case "bc5e3430-b032-40a2-b0a7-47fe12ec6cdb":  //F10小港營業所
                case "f8c393ee-17c5-4b29-a414-e8b3ec649fed":  //F11九如營業所
                case "4493decd-5609-4f1b-8637-65fa8f752488":  //F12鳳山營業所
                case "326dedbe-1acf-4994-b4c1-5c7cfc6131e8":  //F13湖內營業所
                case "8b567de9-f340-42da-a2be-d4d4339fe6f3":  //F14北屏營業所
                case "4dde4903-338a-46dd-9b2d-ccd2b1d74045":  //F15青年營業所
                case "ef44d26f-52bd-d024-906e-a517ebb7ab48":  //F16楠梓營業所
                case "8cb80418-d096-4a3d-aa07-b6cd3f0c305c":  //F17瑞豐營業所
                case "4d65a5dc-51fa-432b-b1aa-4aa3a26edf24":  //F18右昌營業所
                case "3111523e-ed56-442f-a351-9e3b7b314776":  //F20東港營業所
                case "7abadd40-4a9a-49aa-9b96-0a8246330bf2":  //F22鳳林營業所
                case "29fa7a83-98d4-4822-99e0-9b75e41b06be":  //F27三多營業所
                case "9386ca5e-9826-448c-8b01-0f88460de097":  //F52民族營業所
                case "8d49be58-a9ad-4ee1-ad4b-519d25c8ec87":  //F53建國營業所
                    return "營業所";
                case "b6cafe73-944f-438f-950e-77942b5e771f":  //F03岡山服務廠
                case "667d6d53-a314-4825-9a39-79c08912e00c":  //F04屏東服務廠
                case "da352403-2f03-4ee8-af9e-3033da572e92":  //F07北高服務廠
                case "593af315-b1db-4224-ae25-dab942dfe88f":  //F08旗山服務廠
                case "9a4bc7db-02f1-4344-9669-048cfcdd9e03":  //F09潮州服務廠
                case "ceefea0e-4093-40d4-ac79-28ccaa2031d6":  //F10小港服務廠
                case "4e44ed39-f4e5-4743-9816-19008aa6c54e":  //F11九如服務廠
                case "c401ebc0-8245-4c38-8c9a-2c724c74c5cf":  //F12鳳山服務廠
                case "f95c0c7e-a6c5-488c-ae49-22f56a7b9f39":  //F13湖內服務廠
                case "bcf72643-8361-4952-b679-8a02a80c5db6":  //F14北屏服務廠
                case "0794312b-7887-4075-b505-9e4a65e393db":  //F15青年服務廠
                case "0b5867c1-1c3a-4990-9c57-0f267b9ac76c":  //F16楠梓服務廠
                case "3ebabded-71f4-44c1-97fe-bf24da011c91":  //F17瑞豐服務廠
                case "160910c6-affe-43de-8d59-4f7d5e6b5702":  //F18右昌服務廠
                case "f65e7301-edf3-4572-bae8-8d847f6805ff":  //F19麟洛服務廠
                case "17ad2b82-b5a0-457a-ba74-248bd2725e95":  //F20東港服務廠
                case "62400218-3134-427e-b0d2-bd159de7eda1":  //F21里港服務廠
                case "463d4d93-f71d-45f5-8727-5963308d7264":  //F22鳳林服務廠
                case "9c23e5fc-252d-4db8-b6d7-a2bfdbf218d3":  //F24恆春服務廠
                case "ea6e9a77-78a3-492f-9375-e14a2b5e4fd7":  //F27三多服務廠
                case "98620a91-1353-4db7-90ec-314d6ac951b3":  //F51LEXUS九如服務廠
                case "20d7d5af-bcb6-4871-8706-e495c99f945b":  //F52民族服務廠
                case "8daddd5e-58cf-4a54-8333-5ce83e599c93":  //F53建國服務廠
                    return "服務廠";
                case "082b8623-6e17-f256-eae4-aa482f3dd91a":  //北區(T營業所)
                case "0dcf2355-0b47-f92a-9138-b92719cb109d":  //服務行銷室
                case "17331132-3720-b694-4c53-b1c5fd859f4e":  //LEXUS服務廠
                case "2a8c9ac9-b1c4-996a-3871-0eb74d9efc01":  //南區(據點/服務廠)
                case "3536f078-58c8-5dfb-1e01-daf422a24a07":  //TOYOTA服務部
                case "3a08451e-4785-12f2-6f5b-7bd2da4c7685":  //TOYOTA服務廠
                case "3a91e7c7-bf37-769e-862d-1c8456920fa4":  //地區擔當室(服務部)
                case "3ad89eda-1775-a969-7df9-86c54b91518f":  //人資法務室
                case "3f56c9a1-fdcf-a20e-e502-739db12d80ce":  //稽核室
                case "426b3490-4430-4979-80eb-64694fdd25a5":  //TOYOTA營業所
                case "435b7eb3-1f24-0d16-42e3-2841ad415fe9":  //資訊室
                case "4387bbe4-e9cc-1d10-0a6c-512c01b4f3fa":  //總務室
                case "44cd4a1f-918e-2694-3aed-74593fb9ea8a":  //顧客服務室
                case "469f356c-3821-cab8-51e4-ce32012e7638":  //TOYOTA顧客關懷部
                case "48588910-cf3c-f692-f3d1-21e6a9abdaee":  //管理本部
                case "5907ee69-ed54-7b56-0c9f-1e79532e3e9a":  //PDS物流整備-岡山
                case "5c24f715-5f11-3e03-53e2-9fc3e8b38799":  //南區(T營業所)
                case "5ecb6b1b-42e4-7aaa-ff4b-bba6a72a81e4":  //高輊
                case "62c1eeb0-0f19-ab19-8e91-40e2400ea894":  //技術室
                case "73dbe37c-255c-fd62-6e57-b5cdae51ff66":  //南區(車輛部/地區擔當室)
                case "7bc8c41d-7343-1cf3-c6ad-32fd2a77435a":  //財務部
                case "7df6ec3f-c86d-9155-ac64-94af2a4e22e1":  //財務室
                case "7e6041b5-a27d-4d68-46e3-855b5abfe89c":  //顧客關懷推進室
                case "8067f8f4-d7ca-6a07-11b3-af99debf2b29":  //會計室
                case "81f997ae-c01a-d334-56b0-0029d0fa9de8":  //北區(據點/服務廠)
                case "83c43e4b-1eb7-ebb6-e6fc-f7399701fcfb":  //企劃室
                case "9d080135-5fe9-2efc-5c38-540e8db2fe50":  //行銷企劃室
                case "9ed8ee69-d262-4960-96ab-5bce4d377afd":  //PDS物流整備-九如
                case "9f0e67c4-1d78-703a-adcd-c401d126bf76":  //保險分期室
                case "9f15257b-3f49-c6c8-e46e-c532d6811fef":  //零件室
                case "a7c15e27-91a6-16f5-afbf-92b17f500238":  //T業務室
                case "ad3c5442-c047-1584-b0fb-fa21e1d68294":  //管理部
                case "ade8e6c5-47aa-883e-2797-c82793e4e3a9":  //L業務室
                case "beb14e1a-cd57-6ac2-14e2-e7aaed635ce3":  //大陸業務部
                case "bfa00b5f-ebd7-74e5-196a-758493393d03":  //福委會
                case "c07f4895-81bd-0459-b89e-421a57b9bf43":  //新強動力
                case "c3099a91-ce71-d747-760e-3ffdd8114fac":  //TOYOTA車輛部
                case "cc44216a-60ef-8eed-d7b9-39027584c18b":  //綜合企劃室
                case "cf6b4093-0c28-3fb6-dfb4-a956b3d5fdb1":  //教育室
                case "Company":                               //TOYOTA-KD
                case "d2c826e8-f05b-0e6d-5b3f-250fe60112df":  //電話服務中心
                case "d9f98002-38a6-f1ce-929b-270e7bdbdc50":  //LEXUS營業所
                case "dba172bc-52db-60aa-71a4-922d5ea86129":  //北區(車輛部/地區擔當室)
                case "dba570b4-05ad-eec3-e957-29618d25234f":  //直販室
                case "dfd2ff59-9f10-c19c-f736-2a7f39ea18ee":  //TOYOTA本部
                case "e153a54d-572d-9c4e-3afb-52d00d5f66b2":  //LEXUS服務部
                case "e19c0389-3086-a343-5e39-796dbf4a16d3":  //教育訓練室
                case "e6c0a779-7c3d-3de9-a8d2-71a1e59f44c3":  //PDS物流整備-鳳山
                case "e9cbf0f4-c634-dd1b-701e-7171cb08497f":  //秘書室
                case "ec3b71f3-085a-a11b-fdf2-35effff188c0":  //LEXUS本部
                case "ee2921c4-551c-f0c8-7371-f0cf606e6534":  //需給室
                case "f481bcd0-e90c-88f9-a636-9061414d52a1":  //LEXUS車輛部
                case "fefaa691-aef0-4725-086a-b33328cfe9af":  //PDS物流整備
                case "ff63429d-c202-6046-91ac-927887d56fca":  //顧問室
                    return "總公司";
                default:
                    return " ";
            }

        }

        /// 介紹人單位名稱
        public static string ReturnPresentUnit(string p_GROUP_id)
        {
            switch (p_GROUP_id)
            {
                case "82bea600-2433-439f-9f67-c1203408184d":  //F03岡山營業所
                    return "岡山營業所";
                case "63acec50-f693-4b21-85cd-f71d6be09759":  //F04屏東營業所
                    return "屏東營業所";
                case "a2b88531-2de5-4a84-9791-fa3f8e6649ce":  //F07北高營業所
                    return "北高營業所";
                case "cc334965-7ae5-42a0-b9d5-b7cb63e8a373":  //F08旗山營業所
                    return "旗山營業所";
                case "4b587a7f-d7c4-40cc-8078-ab446ce8b643":  //F09潮州營業所
                    return "潮州營業所";
                case "bc5e3430-b032-40a2-b0a7-47fe12ec6cdb":  //F10小港營業所
                    return "小港營業所";
                case "f8c393ee-17c5-4b29-a414-e8b3ec649fed":  //F11九如營業所
                    return "九如營業所";
                case "4493decd-5609-4f1b-8637-65fa8f752488":  //F12鳳山營業所
                    return "鳳山營業所";
                case "326dedbe-1acf-4994-b4c1-5c7cfc6131e8":  //F13湖內營業所
                    return "湖內營業所";
                case "8b567de9-f340-42da-a2be-d4d4339fe6f3":  //F14北屏營業所
                    return "北屏營業所";
                case "4dde4903-338a-46dd-9b2d-ccd2b1d74045":  //F15青年營業所
                    return "青年營業所";
                case "ef44d26f-52bd-d024-906e-a517ebb7ab48":  //F16楠梓營業所
                    return "楠梓營業所";
                case "8cb80418-d096-4a3d-aa07-b6cd3f0c305c":  //F17瑞豐營業所
                    return "瑞豐營業所";
                case "4d65a5dc-51fa-432b-b1aa-4aa3a26edf24":  //F18右昌營業所
                    return "右昌營業所";
                case "3111523e-ed56-442f-a351-9e3b7b314776":  //F20東港營業所
                    return "東港營業所";
                case "7abadd40-4a9a-49aa-9b96-0a8246330bf2":  //F22鳳林營業所
                    return "鳳林營業所";
                case "29fa7a83-98d4-4822-99e0-9b75e41b06be":  //F27三多營業所
                    return "三多營業所";
                case "9386ca5e-9826-448c-8b01-0f88460de097":  //F52民族營業所
                    return "民族營業所";
                case "8d49be58-a9ad-4ee1-ad4b-519d25c8ec87":  //F53建國營業所
                    return "建國營業所";
                case "b6cafe73-944f-438f-950e-77942b5e771f":  //F03岡山服務廠
                    return "岡山服務廠";
                case "667d6d53-a314-4825-9a39-79c08912e00c":  //F04屏東服務廠
                    return "屏東服務廠";
                case "da352403-2f03-4ee8-af9e-3033da572e92":  //F07北高服務廠
                    return "北高服務廠";
                case "593af315-b1db-4224-ae25-dab942dfe88f":  //F08旗山服務廠
                    return "旗山服務廠";
                case "9a4bc7db-02f1-4344-9669-048cfcdd9e03":  //F09潮州服務廠
                    return "潮州服務廠";
                case "ceefea0e-4093-40d4-ac79-28ccaa2031d6":  //F10小港服務廠
                    return "小港服務廠";
                case "4e44ed39-f4e5-4743-9816-19008aa6c54e":  //F11九如服務廠
                    return "九如服務廠";
                case "c401ebc0-8245-4c38-8c9a-2c724c74c5cf":  //F12鳳山服務廠
                    return "鳳山服務廠";
                case "f95c0c7e-a6c5-488c-ae49-22f56a7b9f39":  //F13湖內服務廠
                    return "湖內服務廠";
                case "bcf72643-8361-4952-b679-8a02a80c5db6":  //F14北屏服務廠
                    return "北屏服務廠";
                case "0794312b-7887-4075-b505-9e4a65e393db":  //F15青年服務廠
                    return "青年服務廠";
                case "0b5867c1-1c3a-4990-9c57-0f267b9ac76c":  //F16楠梓服務廠
                    return "楠梓服務廠";
                case "3ebabded-71f4-44c1-97fe-bf24da011c91":  //F17瑞豐服務廠
                    return "瑞豐服務廠";
                case "160910c6-affe-43de-8d59-4f7d5e6b5702":  //F18右昌服務廠
                    return "右昌服務廠";
                case "f65e7301-edf3-4572-bae8-8d847f6805ff":  //F19麟洛服務廠
                    return "麟洛服務廠";
                case "17ad2b82-b5a0-457a-ba74-248bd2725e95":  //F20東港服務廠
                    return "東港服務廠";
                case "62400218-3134-427e-b0d2-bd159de7eda1":  //F21里港服務廠
                    return "里港服務廠";
                case "463d4d93-f71d-45f5-8727-5963308d7264":  //F22鳳林服務廠
                    return "鳳林服務廠";
                case "9c23e5fc-252d-4db8-b6d7-a2bfdbf218d3":  //F24恆春服務廠
                    return "恆春服務廠";
                case "ea6e9a77-78a3-492f-9375-e14a2b5e4fd7":  //F27三多服務廠
                    return "三多服務廠";
                case "98620a91-1353-4db7-90ec-314d6ac951b3":  //F51LEXUS九如服務廠
                    return "LEXUS九如服務廠";
                case "20d7d5af-bcb6-4871-8706-e495c99f945b":  //F52民族服務廠
                    return "民族服務廠";
                case "8daddd5e-58cf-4a54-8333-5ce83e599c93":  //F53建國服務廠
                    return "建國服務廠";
                case "ec3b71f3-085a-a11b-fdf2-35effff188c0":  //LEXUS本部
                    return "LEXUS本部";
                case "83c43e4b-1eb7-ebb6-e6fc-f7399701fcfb":  //企劃室
                case "ade8e6c5-47aa-883e-2797-c82793e4e3a9":  //L業務室
                case "f481bcd0-e90c-88f9-a636-9061414d52a1":  //LEXUS車輛部
                    return "LEXUS車輛部";
                case "0dcf2355-0b47-f92a-9138-b92719cb109d":  //服務行銷室
                case "17331132-3720-b694-4c53-b1c5fd859f4e":  //LEXUS服務廠
                case "44cd4a1f-918e-2694-3aed-74593fb9ea8a":  //顧客服務室
                case "d9f98002-38a6-f1ce-929b-270e7bdbdc50":  //LEXUS營業所
                case "e153a54d-572d-9c4e-3afb-52d00d5f66b2":  //LEXUS服務部
                    return "LEXUS服務部";
                case "Company":                               //TOYOTA-KD
                    return "TOYOTA-KD";
                case "dfd2ff59-9f10-c19c-f736-2a7f39ea18ee":  //TOYOTA本部
                    return "TOYOTA本部";
                case "426b3490-4430-4979-80eb-64694fdd25a5":  //TOYOTA營業所
                case "73dbe37c-255c-fd62-6e57-b5cdae51ff66":  //南區(車輛部/地區擔當室)
                case "dba172bc-52db-60aa-71a4-922d5ea86129":  //北區(車輛部/地區擔當室)
                case "9d080135-5fe9-2efc-5c38-540e8db2fe50":  //行銷企劃室
                case "9f0e67c4-1d78-703a-adcd-c401d126bf76":  //保險分期室
                case "c3099a91-ce71-d747-760e-3ffdd8114fac":  //TOYOTA車輛部
                case "e19c0389-3086-a343-5e39-796dbf4a16d3":  //教育訓練室
                case "ee2921c4-551c-f0c8-7371-f0cf606e6534":  //需給室
                    return "TOYOTA車輛部";
                case "3536f078-58c8-5dfb-1e01-daf422a24a07":  //TOYOTA服務部
                case "3a91e7c7-bf37-769e-862d-1c8456920fa4":  //地區擔當室(服務部)
                case "3a08451e-4785-12f2-6f5b-7bd2da4c7685":  //TOYOTA服務廠
                case "62c1eeb0-0f19-ab19-8e91-40e2400ea894":  //技術室
                case "9f15257b-3f49-c6c8-e46e-c532d6811fef":  //零件室
                case "cf6b4093-0c28-3fb6-dfb4-a956b3d5fdb1":  //教育室
                case "a7c15e27-91a6-16f5-afbf-92b17f500238":  //T業務室
                    return "TOYOTA服務部";
                case "dba570b4-05ad-eec3-e957-29618d25234f":  //直販室
                    return "車輛部";
                case "7bc8c41d-7343-1cf3-c6ad-32fd2a77435a":  //財務部
                case "7df6ec3f-c86d-9155-ac64-94af2a4e22e1":  //財務室
                case "8067f8f4-d7ca-6a07-11b3-af99debf2b29":  //會計室
                    return "財務部";
                case "5ecb6b1b-42e4-7aaa-ff4b-bba6a72a81e4":  //高輊
                    return "高輊";
                case "c07f4895-81bd-0459-b89e-421a57b9bf43":  //新強動力
                    return "北高物流";
                case "48588910-cf3c-f692-f3d1-21e6a9abdaee":  //管理本部
                    return "管理本部";
                case "3ad89eda-1775-a969-7df9-86c54b91518f":  //人資法務室
                case "435b7eb3-1f24-0d16-42e3-2841ad415fe9":  //資訊室
                case "4387bbe4-e9cc-1d10-0a6c-512c01b4f3fa":  //總務室
                case "ad3c5442-c047-1584-b0fb-fa21e1d68294":  //管理部
                case "beb14e1a-cd57-6ac2-14e2-e7aaed635ce3":  //大陸業務部
                case "bfa00b5f-ebd7-74e5-196a-758493393d03":  //福委會
                case "cc44216a-60ef-8eed-d7b9-39027584c18b":  //綜合企劃室
                case "e9cbf0f4-c634-dd1b-701e-7171cb08497f":  //秘書室
                    return "管理部";
                case "3f56c9a1-fdcf-a20e-e502-739db12d80ce":  //稽核室
                    return "稽核室";
                case "5907ee69-ed54-7b56-0c9f-1e79532e3e9a":  //PDS物流整備-岡山
                    return "岡山物流";
                case "9ed8ee69-d262-4960-96ab-5bce4d377afd":  //PDS物流整備-九如
                case "e6c0a779-7c3d-3de9-a8d2-71a1e59f44c3":  //PDS物流整備-鳳山
                    return "鳳山物流";
                case "469f356c-3821-cab8-51e4-ce32012e7638":  //TOYOTA顧客關懷部
                case "7e6041b5-a27d-4d68-46e3-855b5abfe89c":  //顧客關懷推進室
                case "d2c826e8-f05b-0e6d-5b3f-250fe60112df":  //電話服務中心
                    return "顧客關懷部";
                case "ff63429d-c202-6046-91ac-927887d56fca":  //顧問室
                    return "顧問室";
                default:
                    return " ";
            }
        }

        /// 交車營業所名稱
        public static string ReturnStaffUnit(string p_GROUP_id)
        {
            switch (p_GROUP_id)
            {
                case "fd309ddb-45a9-6c3b-737e-fcc225b0d9b6":  //F03岡山一課
                case "34261042-efa7-2c7d-0939-a8920cf06478":  //F03岡山二課
                    return "岡山營業所";
                case "139be303-cb80-4944-377d-f9e70401c4be":  //F04屏東一課
                case "b7a0fd14-0380-87a9-c06c-7e8bbdcf1ee9":  //F04屏東二課
                    return "屏東營業所";
                case "4f9e7989-972f-9e13-18d4-729722fa3ade":  //F07北高一課
                case "fbcabd31-2b9e-5350-0d33-134a707c0803":  //F07北高二課
                case "3767b21e-c61c-2be2-9562-05aa679b044f":  //F07北高三課
                case "00c2bab6-dddd-5df5-5f7d-4a79a865705d":  //F07北高四課
                    return "北高營業所";
                case "57c20f59-b799-43ee-a863-e1754892ffcd":  //F07北高五課
                    return "直販課";
                case "a1ba63b4-b7dc-0db1-46ca-9343271329a3":  //F08旗山一課
                    return "旗山營業所";
                case "4414dadd-bd80-7da2-6471-c93f18e04db8":  //F09潮州一課
                    return "潮州營業所";
                case "8dd6d848-db05-b3e9-e5fc-7606819ed8f0":  //F10小港一課
                    return "小港營業所";
                case "c5348132-c8a1-4e71-bd3a-5c63f2d672ff":  //F11九如一課
                case "bd2ef0d7-edc6-c5ba-1784-3240ed247345":  //F11九如二課
                    return "九如營業所";
                case "96cd1be3-0b7e-897e-4345-10451f4ce364":  //F12鳳山一課
                case "88db1f18-8846-5a6d-401d-3b64cdc54883":  //F12鳳山二課
                    return "鳳山營業所";
                case "47e1a518-c4df-148d-237c-53f6c2feea77":  //F13湖內一課
                    return "湖內營業所";
                case "d399418d-a844-f09a-35ea-a8fffafc30e5":  //F14北屏一課
                case "0b122fc9-33a0-616c-c9e8-ac5a34779e4e":  //F14北屏二課
                    return "北屏營業所";
                case "064f1a10-1c1e-6e40-9dfb-7334da92d1e2":  //F15青年一課
                case "44e4fa19-6932-105b-738c-8d593ba4cfb3":  //F15青年二課
                    return "青年營業所";
                case "6a5e05ba-5146-5e42-4e00-004e1deaafbd":  //F16楠梓一課
                    return "楠梓營業所";
                case "5f00d31b-2317-2af9-028d-fae649c39b83":  //F17瑞豐一課
                case "c8181634-3372-2e1f-7c00-af4ac482b973":  //F17瑞豐二課
                    return "瑞豐營業所";
                case "5a48e343-431d-d4b6-f743-dbf1b596679a":  //F18右昌一課
                case "93e3db8e-0011-bf80-6f2e-bf99ccf3a7a4":  //F18右昌二課
                    return "右昌營業所";
                case "17e96a02-0a8e-b057-fb65-33f40f79325e":  //F20東港一課
                    return "東港營業所";
                case "e3a19f1c-378b-a692-fc58-0e255a807124":  //F22鳳林一課
                    return "鳳林營業所";
                case "046479b3-7b3e-da9d-9d09-616c3435a159":  //F27三多一課
                case "b39bc011-6cb9-d9cb-ba78-d245d3e46b40":  //F27三多二課
                    return "三多營業所";
                case "9df642e9-ad92-e633-bb11-37c6dd31b198":  //F52民族一課
                    return "民族營業所";
                case "8d49be58-a9ad-4ee1-ad4b-519d25c8ec87":  //F53建國營業所
                    return "建國營業所";
                default:
                    return " ";
            }
        }

        /// 設定介紹人單位
        public static void setPresentUnit(DropDownList ddl)
        {
            ddl.Items.Add(new ListItem("", ""));
            ddl.Items.Add(new ListItem("F03岡山服務廠", "b6cafe73-944f-438f-950e-77942b5e771f"));
            ddl.Items.Add(new ListItem("F03岡山營業所", "82bea600-2433-439f-9f67-c1203408184d"));
            ddl.Items.Add(new ListItem("F04屏東服務廠", "667d6d53-a314-4825-9a39-79c08912e00c"));
            ddl.Items.Add(new ListItem("F04屏東營業所", "63acec50-f693-4b21-85cd-f71d6be09759"));
            ddl.Items.Add(new ListItem("F07北高服務廠", "da352403-2f03-4ee8-af9e-3033da572e92"));
            ddl.Items.Add(new ListItem("F07北高營業所", "a2b88531-2de5-4a84-9791-fa3f8e6649ce"));
            ddl.Items.Add(new ListItem("F08旗山服務廠", "593af315-b1db-4224-ae25-dab942dfe88f"));
            ddl.Items.Add(new ListItem("F08旗山營業所", "cc334965-7ae5-42a0-b9d5-b7cb63e8a373"));
            ddl.Items.Add(new ListItem("F09潮州服務廠", "9a4bc7db-02f1-4344-9669-048cfcdd9e03"));
            ddl.Items.Add(new ListItem("F09潮州營業所", "4b587a7f-d7c4-40cc-8078-ab446ce8b643"));
            ddl.Items.Add(new ListItem("F10小港服務廠", "ceefea0e-4093-40d4-ac79-28ccaa2031d6"));
            ddl.Items.Add(new ListItem("F10小港營業所", "bc5e3430-b032-40a2-b0a7-47fe12ec6cdb"));
            ddl.Items.Add(new ListItem("F11九如服務廠", "4e44ed39-f4e5-4743-9816-19008aa6c54e"));
            ddl.Items.Add(new ListItem("F11九如營業所", "f8c393ee-17c5-4b29-a414-e8b3ec649fed"));
            ddl.Items.Add(new ListItem("F12鳳山服務廠", "c401ebc0-8245-4c38-8c9a-2c724c74c5cf"));
            ddl.Items.Add(new ListItem("F12鳳山營業所", "4493decd-5609-4f1b-8637-65fa8f752488"));
            ddl.Items.Add(new ListItem("F13湖內服務廠", "f95c0c7e-a6c5-488c-ae49-22f56a7b9f39"));
            ddl.Items.Add(new ListItem("F13湖內營業所", "326dedbe-1acf-4994-b4c1-5c7cfc6131e8"));
            ddl.Items.Add(new ListItem("F14北屏服務廠", "bcf72643-8361-4952-b679-8a02a80c5db6"));
            ddl.Items.Add(new ListItem("F14北屏營業所", "8b567de9-f340-42da-a2be-d4d4339fe6f3"));
            ddl.Items.Add(new ListItem("F15青年服務廠", "0794312b-7887-4075-b505-9e4a65e393db"));
            ddl.Items.Add(new ListItem("F15青年營業所", "4dde4903-338a-46dd-9b2d-ccd2b1d74045"));
            ddl.Items.Add(new ListItem("F16楠梓服務廠", "0b5867c1-1c3a-4990-9c57-0f267b9ac76c"));
            ddl.Items.Add(new ListItem("F16楠梓營業所", "ef44d26f-52bd-d024-906e-a517ebb7ab48"));
            ddl.Items.Add(new ListItem("F17瑞豐服務廠", "3ebabded-71f4-44c1-97fe-bf24da011c91"));
            ddl.Items.Add(new ListItem("F17瑞豐營業所", "8cb80418-d096-4a3d-aa07-b6cd3f0c305c"));
            ddl.Items.Add(new ListItem("F18右昌服務廠", "160910c6-affe-43de-8d59-4f7d5e6b5702"));
            ddl.Items.Add(new ListItem("F18右昌營業所", "4d65a5dc-51fa-432b-b1aa-4aa3a26edf24"));
            ddl.Items.Add(new ListItem("F19麟洛服務廠", "f65e7301-edf3-4572-bae8-8d847f6805ff"));
            ddl.Items.Add(new ListItem("F20東港服務廠", "17ad2b82-b5a0-457a-ba74-248bd2725e95"));
            ddl.Items.Add(new ListItem("F20東港營業所", "3111523e-ed56-442f-a351-9e3b7b314776"));
            ddl.Items.Add(new ListItem("F21里港服務廠", "62400218-3134-427e-b0d2-bd159de7eda1"));
            ddl.Items.Add(new ListItem("F22鳳林服務廠", "463d4d93-f71d-45f5-8727-5963308d7264"));
            ddl.Items.Add(new ListItem("F22鳳林營業所", "7abadd40-4a9a-49aa-9b96-0a8246330bf2"));
            ddl.Items.Add(new ListItem("F24恆春服務廠", "9c23e5fc-252d-4db8-b6d7-a2bfdbf218d3"));
            ddl.Items.Add(new ListItem("F27三多服務廠", "ea6e9a77-78a3-492f-9375-e14a2b5e4fd7"));
            ddl.Items.Add(new ListItem("F27三多營業所", "29fa7a83-98d4-4822-99e0-9b75e41b06be"));
            ddl.Items.Add(new ListItem("F51LEXUS九如服務廠", "98620a91-1353-4db7-90ec-314d6ac951b3"));
            ddl.Items.Add(new ListItem("F52民族服務廠", "20d7d5af-bcb6-4871-8706-e495c99f945b"));
            ddl.Items.Add(new ListItem("F52民族營業所", "9386ca5e-9826-448c-8b01-0f88460de097"));
            ddl.Items.Add(new ListItem("F53建國服務廠", "8daddd5e-58cf-4a54-8333-5ce83e599c93"));
            ddl.Items.Add(new ListItem("F53建國營業所", "8d49be58-a9ad-4ee1-ad4b-519d25c8ec87"));
            ddl.Items.Add(new ListItem("LEXUS本部", "ec3b71f3-085a-a11b-fdf2-35effff188c0"));
            ddl.Items.Add(new ListItem("LEXUS車輛部", "f481bcd0-e90c-88f9-a636-9061414d52a1"));
            ddl.Items.Add(new ListItem("LEXUS服務部", "e153a54d-572d-9c4e-3afb-52d00d5f66b2"));
            ddl.Items.Add(new ListItem("LEXUS營業所", "d9f98002-38a6-f1ce-929b-270e7bdbdc50"));
            ddl.Items.Add(new ListItem("PDS物流整備", "fefaa691-aef0-4725-086a-b33328cfe9af"));
            ddl.Items.Add(new ListItem("PDS物流整備-九如", "9ed8ee69-d262-4960-96ab-5bce4d377afd"));
            ddl.Items.Add(new ListItem("PDS物流整備-岡山", "5907ee69-ed54-7b56-0c9f-1e79532e3e9a"));
            ddl.Items.Add(new ListItem("PDS物流整備-鳳山", "e6c0a779-7c3d-3de9-a8d2-71a1e59f44c3"));
            ddl.Items.Add(new ListItem("TOYOTA本部", "dfd2ff59-9f10-c19c-f736-2a7f39ea18ee"));
            ddl.Items.Add(new ListItem("TOYOTA車輛部", "c3099a91-ce71-d747-760e-3ffdd8114fac"));
            ddl.Items.Add(new ListItem("TOYOTA服務部", "3536f078-58c8-5dfb-1e01-daf422a24a07"));
            ddl.Items.Add(new ListItem("TOYOTA營業所", "426b3490-4430-4979-80eb-64694fdd25a5"));
            ddl.Items.Add(new ListItem("TOYOTA顧客關懷部", "469f356c-3821-cab8-51e4-ce32012e7638"));
            ddl.Items.Add(new ListItem("人資法務室", "3ad89eda-1775-a969-7df9-86c54b91518f"));
            ddl.Items.Add(new ListItem("大陸業務部", "beb14e1a-cd57-6ac2-14e2-e7aaed635ce3"));
            ddl.Items.Add(new ListItem("中古車室", "7f01a398-fe7d-1afa-9a82-015a7f1b612f"));
            ddl.Items.Add(new ListItem("北區", "082b8623-6e17-f256-eae4-aa482f3dd91a"));
            ddl.Items.Add(new ListItem("市區", "2a8c9ac9-b1c4-996a-3871-0eb74d9efc01"));
            ddl.Items.Add(new ListItem("企劃室", "83c43e4b-1eb7-ebb6-e6fc-f7399701fcfb"));
            ddl.Items.Add(new ListItem("T車輛地區擔當室", "5efae20a-f5d7-0cc5-5a25-831dfede9398"));
            ddl.Items.Add(new ListItem("T服務地區擔當室", "3a91e7c7-bf37-769e-862d-1c8456920fa4"));
            ddl.Items.Add(new ListItem("技術室", "62c1eeb0-0f19-ab19-8e91-40e2400ea894"));
            ddl.Items.Add(new ListItem("服務行銷室", "0dcf2355-0b47-f92a-9138-b92719cb109d"));
            ddl.Items.Add(new ListItem("服務廠", "3a08451e-4785-12f2-6f5b-7bd2da4c7685"));
            ddl.Items.Add(new ListItem("直販室", "dba570b4-05ad-eec3-e957-29618d25234f"));
            ddl.Items.Add(new ListItem("保險分期室", "9f0e67c4-1d78-703a-adcd-c401d126bf76"));
            ddl.Items.Add(new ListItem("南區", "5c24f715-5f11-3e03-53e2-9fc3e8b38799"));
            ddl.Items.Add(new ListItem("郊區", "81f997ae-c01a-d334-56b0-0029d0fa9de8"));
            ddl.Items.Add(new ListItem("秘書室", "e9cbf0f4-c634-dd1b-701e-7171cb08497f"));
            ddl.Items.Add(new ListItem("財務室", "7df6ec3f-c86d-9155-ac64-94af2a4e22e1"));
            ddl.Items.Add(new ListItem("財務部", "7bc8c41d-7343-1cf3-c6ad-32fd2a77435a"));
            ddl.Items.Add(new ListItem("高輊", "5ecb6b1b-42e4-7aaa-ff4b-bba6a72a81e4"));
            ddl.Items.Add(new ListItem("教育室", "cf6b4093-0c28-3fb6-dfb4-a956b3d5fdb1"));
            ddl.Items.Add(new ListItem("教育訓練室", "e19c0389-3086-a343-5e39-796dbf4a16d3"));
            ddl.Items.Add(new ListItem("行銷企劃室", "9d080135-5fe9-2efc-5c38-540e8db2fe50"));
            ddl.Items.Add(new ListItem("新強動力", "c07f4895-81bd-0459-b89e-421a57b9bf43"));
            ddl.Items.Add(new ListItem("會計室", "8067f8f4-d7ca-6a07-11b3-af99debf2b29"));
            ddl.Items.Add(new ListItem("L業務室", "ade8e6c5-47aa-883e-2797-c82793e4e3a9"));
            ddl.Items.Add(new ListItem("T業務室", "a7c15e27-91a6-16f5-afbf-92b17f500238"));
            ddl.Items.Add(new ListItem("資訊室", "435b7eb3-1f24-0d16-42e3-2841ad415fe9"));
            ddl.Items.Add(new ListItem("電話服務中心", "d2c826e8-f05b-0e6d-5b3f-250fe60112df"));
            ddl.Items.Add(new ListItem("零件室", "9f15257b-3f49-c6c8-e46e-c532d6811fef"));
            ddl.Items.Add(new ListItem("福委會", "bfa00b5f-ebd7-74e5-196a-758493393d03"));
            ddl.Items.Add(new ListItem("管理本部", "48588910-cf3c-f692-f3d1-21e6a9abdaee"));
            ddl.Items.Add(new ListItem("管理部", "ad3c5442-c047-1584-b0fb-fa21e1d68294"));
            ddl.Items.Add(new ListItem("綜合企劃室", "cc44216a-60ef-8eed-d7b9-39027584c18b"));
            ddl.Items.Add(new ListItem("需給室", "ee2921c4-551c-f0c8-7371-f0cf606e6534"));
            ddl.Items.Add(new ListItem("稽核室", "3f56c9a1-fdcf-a20e-e502-739db12d80ce"));
            ddl.Items.Add(new ListItem("據點", "376cdba5-b793-cda7-af10-f19f6dcf7711"));
            ddl.Items.Add(new ListItem("總務室", "4387bbe4-e9cc-1d10-0a6c-512c01b4f3fa"));
            ddl.Items.Add(new ListItem("顧客服務室", "44cd4a1f-918e-2694-3aed-74593fb9ea8a"));
            ddl.Items.Add(new ListItem("顧客關懷推進室", "7e6041b5-a27d-4d68-46e3-855b5abfe89c"));
            ddl.Items.Add(new ListItem("顧問室", "ff63429d-c202-6046-91ac-927887d56fca"));
        }

        /// 設定業代單位
        public static void setUnit(DropDownList ddl)
        {
            ddl.Items.Add(new ListItem("", ""));
            ddl.Items.Add(new ListItem("岡山一課", "fd309ddb-45a9-6c3b-737e-fcc225b0d9b6"));
            ddl.Items.Add(new ListItem("岡山二課", "34261042-efa7-2c7d-0939-a8920cf06478"));
            ddl.Items.Add(new ListItem("屏東一課", "139be303-cb80-4944-377d-f9e70401c4be"));
            ddl.Items.Add(new ListItem("屏東二課", "b7a0fd14-0380-87a9-c06c-7e8bbdcf1ee9"));
            ddl.Items.Add(new ListItem("北高一課", "4f9e7989-972f-9e13-18d4-729722fa3ade"));
            ddl.Items.Add(new ListItem("北高二課", "fbcabd31-2b9e-5350-0d33-134a707c0803"));
            ddl.Items.Add(new ListItem("北高三課", "3767b21e-c61c-2be2-9562-05aa679b044f"));
            ddl.Items.Add(new ListItem("北高四課", "00c2bab6-dddd-5df5-5f7d-4a79a865705d"));
            ddl.Items.Add(new ListItem("北高五課", "57c20f59-b799-43ee-a863-e1754892ffcd"));
            ddl.Items.Add(new ListItem("旗山一課", "a1ba63b4-b7dc-0db1-46ca-9343271329a3"));
            ddl.Items.Add(new ListItem("潮州一課", "4414dadd-bd80-7da2-6471-c93f18e04db8"));
            ddl.Items.Add(new ListItem("小港一課", "8dd6d848-db05-b3e9-e5fc-7606819ed8f0"));
            ddl.Items.Add(new ListItem("九如一課", "c5348132-c8a1-4e71-bd3a-5c63f2d672ff"));
            ddl.Items.Add(new ListItem("九如二課", "bd2ef0d7-edc6-c5ba-1784-3240ed247345"));
            ddl.Items.Add(new ListItem("鳳山一課", "96cd1be3-0b7e-897e-4345-10451f4ce364"));
            ddl.Items.Add(new ListItem("鳳山二課", "88db1f18-8846-5a6d-401d-3b64cdc54883"));
            ddl.Items.Add(new ListItem("湖內一課", "47e1a518-c4df-148d-237c-53f6c2feea77"));
            ddl.Items.Add(new ListItem("北屏一課", "d399418d-a844-f09a-35ea-a8fffafc30e5"));
            ddl.Items.Add(new ListItem("北屏二課", "0b122fc9-33a0-616c-c9e8-ac5a34779e4e"));
            ddl.Items.Add(new ListItem("青年一課", "064f1a10-1c1e-6e40-9dfb-7334da92d1e2"));
            ddl.Items.Add(new ListItem("青年二課", "44e4fa19-6932-105b-738c-8d593ba4cfb3"));
            ddl.Items.Add(new ListItem("楠梓一課", "6a5e05ba-5146-5e42-4e00-004e1deaafbd"));
            ddl.Items.Add(new ListItem("瑞豐一課", "5f00d31b-2317-2af9-028d-fae649c39b83"));
            ddl.Items.Add(new ListItem("瑞豐二課", "c8181634-3372-2e1f-7c00-af4ac482b973"));
            ddl.Items.Add(new ListItem("右昌一課", "5a48e343-431d-d4b6-f743-dbf1b596679a"));
            ddl.Items.Add(new ListItem("右昌二課", "93e3db8e-0011-bf80-6f2e-bf99ccf3a7a4"));
            ddl.Items.Add(new ListItem("東港一課", "17e96a02-0a8e-b057-fb65-33f40f79325e"));
            ddl.Items.Add(new ListItem("鳳林一課", "e3a19f1c-378b-a692-fc58-0e255a807124"));
            ddl.Items.Add(new ListItem("三多一課", "046479b3-7b3e-da9d-9d09-616c3435a159"));
            ddl.Items.Add(new ListItem("三多二課", "b39bc011-6cb9-d9cb-ba78-d245d3e46b40"));
            ddl.Items.Add(new ListItem("民族一課", "9df642e9-ad92-e633-bb11-37c6dd31b198"));
            ddl.Items.Add(new ListItem("建國營業所", "8d49be58-a9ad-4ee1-ad4b-519d25c8ec87"));
        }

    }
}
