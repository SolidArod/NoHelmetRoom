global using static NoHelmetRoom.Logger;
using HarmonyLib;
using ModLoader.Framework;
using ModLoader.Framework.Attributes;
using System.IO;
using System.Reflection;

namespace NoHelmetRoom
{
    [ItemId("NoHelmet.room")] // Harmony ID for your mod, make sure this is unique
    [HarmonyPatch(typeof(LoadingSceneHelmet), "Start")]
    public class Main : VtolMod
    {
        public string ModFolder;

        private void Awake()
        {
            ModFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            Log($"Awake at {ModFolder}");
        }

        public override void UnLoad()
        {
            // Destroy any objects
        }

        private static void Postfix(LoadingSceneHelmet __instance)
        {
            LoadingSceneController.instance.PlayerReady();
        }
    }
}