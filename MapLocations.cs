using System;
using TLDKit;
using Harmony;
using UnityEngine;

namespace ShowMapLocation {
    [HarmonyPatch(typeof(Panel_Map))]
    [HarmonyPatch("LoadMapElementsForScene")]
    public class ShowMapLocation {
        public static void Postfix(Panel_Map __instance, String sceneName) {
            GameObject cacheObj = MapManager.LocateSceneByName("PrepperCache");
            if (cacheObj) {
                MapManager.AddToMap(__instance, sceneName, "Cache", "ico_NoTool", cacheObj.transform.localPosition);
            }
            MapManager.AddToMap(__instance, sceneName, "GAMEPLAY_Location", "ico_X", GameManager.GetPlayerTransform().localPosition);
        }
    }
}
