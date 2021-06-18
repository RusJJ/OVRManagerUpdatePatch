using BepInEx;
using HarmonyLib;

namespace OVRManagerPatch
{
    [BepInPlugin(ModConstants.ModConstants.modGUID, ModConstants.ModConstants.modName, ModConstants.ModConstants.modVersion)]
    public class Main : BaseUnityPlugin
    {
        public static bool shouldCallFunction = false;
        void Awake()
        {
            HarmonyPatcher.Patch.Apply();
        }
        private void OnEnable()
        {
            shouldCallFunction = false;
        }
        private void OnDisable()
        {
            shouldCallFunction = true;
        }
    }

    [HarmonyPatch(typeof(OVRManager))]
    [HarmonyPatch("Update", MethodType.Normal)]
    internal class OVRManagerUpdate
    {
        /* OVRManager::Update flooding... */
        public static bool Prefix()
        {
            return Main.shouldCallFunction;
        }
    }
}