using BepInEx;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;
using UnityEngine;

namespace AmongUsMedicMod
{
    [BepInPlugin(PluginGuid, PluginName, PluginVersion)]
    [BepInProcess("com.innersloth.spacemafia")] // Android paket adı
    public class MedicPlugin : BasePlugin
    {
        public const string PluginGuid = "com.yourname.amongus.medicrole";
        public const string PluginName = "Medic Role Mod";
        public const string PluginVersion = "1.0.0";

        public override void Load()
        {
            // Harmony yamalarını aktifleştir
            Harmony.CreateAndPatchAll(typeof(MedicPlugin));
            Log.LogInfo($"[{PluginName}] başarıyla yüklendi!");
        }

        // 1) İsim Rengini Mavi Yapma Yaması
        [HarmonyPatch(typeof(PlayerControl), nameof(PlayerControl.FixedUpdate))]
        [HarmonyPostfix]
        public static void PostfixPlayerUpdate(PlayerControl __instance)
        {
            if (__instance == null || __instance.nameText == null) return;

            // Örnek: Eğer oyuncu Medic rolündeyse ismi mavi yap
            // Gerçek projede rol atama mantığınızı buraya bağlamalısınız.
            if (IsMedic(__instance))
            {
                __instance.nameText.color = Color.blue;
            }
        }

        // Rol kontrolü için örnek metot
        private static bool IsMedic(PlayerControl player)
        {
            // Kendi rol yönetim sisteminize göre burayı düzenleyebilirsiniz
            // Örnek olarak yerel oyuncunun ID'si veya özel bir liste kontrol edilebilir.
            return false; 
        }

        // 2) Revive (Yeniden Doğurma) Mantığı İçin Etkileşim Örneği
        // Ölü bir oyuncunun cesediyle etkileşime geçildiğinde tetiklenecek mantık
        public static void TryRevivePlayer(PlayerControl medic, DeadBody targetBody)
        {
            if (medic == null || targetBody == null) return;

            // Sadece Medic rolündekiler diriltebilir
            if (!IsMedic(medic)) return;

            // Mesafe kontrolü (Örn: 1.5 birim yakınlık)
            float distance = Vector2.Distance(medic.transform.position, targetBody.transform.position);
            if (distance <= 1.5f)
            {
                // RPC veya Sunucu tabanlı diriltme isteği gönderme
                // Among Us mimarisinde netcode üzerinden RPC çağrılması gerekir.
                // Örnek mantık:
                // targetBody.ParentId -> Diriltilecek oyuncunun ID'si
                Debug.Log($"[Medic] {medic.Data.PlayerName}, {targetBody.ParentId} adlı oyuncuyu diriltiyor.");
                
                // Not: Gerçek hayatta sunucu yetkisi (Rpc) gereklidir.
            }
        }
    }
}
dotnet build
