using BepInEx;
using HarmonyLib;
using UnityEngine;

namespace OVRManagerPatch
{
    [BepInPlugin(ModConstants.ModConstants.modGUID, ModConstants.ModConstants.modName, ModConstants.ModConstants.modVersion)]
    public class Main : BaseUnityPlugin
    {
        void Awake()
        {
            HarmonyPatcher.Patch.Apply();
        }
    }

    [HarmonyPatch(typeof(GorillaLocomotion.Player))]
    [HarmonyPatch("Awake", MethodType.Normal)]
    internal class PlayerAwake
    {
        /* Just disable an OVRManager! */
        /* (Thanks A Haunted Army#2861)! */
        public static void Postfix()
        {
            GameObject OVRManager = GameObject.Find("Photon Manager/oculusvr");
            if (OVRManager != null) OVRManager.SetActive(false);
        }
    }
}