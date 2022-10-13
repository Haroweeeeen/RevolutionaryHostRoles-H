﻿using RevolutionaryHostRoles;
using System.Collections.Generic;
using UnityEngine;
using static RevolutionaryHostRoles.Roles.RoleDatas;
using static Rewired.Utils.Classes.Utility.ObjectInstanceTracker;
using UnityEngine.Networking.Types;
using static UnityEngine.ParticleSystem.PlaybackState;
using Types = RevolutionaryHostRoles.CustomOption.CustomOptionType;
using System.Diagnostics;

namespace RevolutionaryHostRoles
{
    //TheOtherRolesAUさん本当にありがとうございます！！！
    public class CustomOptionHolder
    {
        public static string[] rates = new string[] { "0%", "10%", "20%", "30%", "40%", "50%", "60%", "70%", "80%", "90%", "100%" };
        public static string[] ratesModifier = new string[] { "1", "2", "3" };
        public static string[] presets = new string[] { "プリセット 1", "プリセット 2", "プリセット 3", "プリセット 4", "プリセット 5" };

        public static CustomOption presetSelection;

        public static CustomOption InversionMode;

        public static CustomOption crewmateRolesCountMax;
        public static CustomOption neutralRolesCountMax;
        public static CustomOption impostorRolesCountMax;

        public static CustomOption TrackerOption;
        public static CustomOption TrackerPlayerCount;


        internal static Dictionary<byte, byte[]> blockedRolePairings = new Dictionary<byte, byte[]>();

        public static string cs(Color c, string s)
        {
            return string.Format("<color=#{0:X2}{1:X2}{2:X2}{3:X2}>{4}</color>", ToByte(c.r), ToByte(c.g), ToByte(c.b), ToByte(c.a), s);
        }

        private static byte ToByte(float f)
        {
            f = Mathf.Clamp01(f);
            return (byte)(f * 255);
        }

        public static void Load()
        {

            //役職

            TrackerOption = CustomOption.Create(1000, Types.Impostor, cs(Color.red, "トラッカー"), rates, null, true);
            TrackerPlayerCount = CustomOption.Create(1001, Types.Impostor, "人数", 1f, 1f, 3f, 1f, TrackerOption);
            //temple(Role) = CustomOption.Create(Id, Types.Impostor, cs(Color.red, "トラッカー"), rates, null, true);
            //temple(float) = CustomOption.Create(Id, Types.Impostor, "設定名", //デフォルトf, //最小の値f, //最大の値f, //刻む数字(語彙力)f, templeOption)
            //temple(bool) = CustomOption.Create(Id, Types.Crewmate, "設定名", false, templeOption);

            //プリセットと最小and最大人数
            presetSelection = CustomOption.Create(0, Types.General, cs(new Color(204f / 255f, 204f / 255f, 0, 1f), "プリセット"), presets, null, true);
            //InversionMode = CustomOption.Create(7, Types.General, cs(new Color(204f / 255f, 204f / 255f, 0, 1f), "操作反転モード"), false, null, true);

            crewmateRolesCountMax = CustomOption.Create(2, Types.General, cs(new Color(204f / 255f, 204f / 255f, 0, 1f), "クルーメイトの数"), 15f, 0f, 15f, 1f, null, true);
            neutralRolesCountMax = CustomOption.Create(4, Types.General, cs(new Color(204f / 255f, 204f / 255f, 0, 1f), "第三陣営の数"), 15f, 0f, 15f, 1f);
            impostorRolesCountMax = CustomOption.Create(6, Types.General, cs(new Color(204f / 255f, 204f / 255f, 0, 1f), "インポスターの数"), 15f, 0f, 3f, 1f);


        }
    }
}