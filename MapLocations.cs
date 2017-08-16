using System;
using System.Collections.Generic;
using TLDKit;
using Harmony;
using UnityEngine;

namespace ShowMapLocation {
    [HarmonyPatch(typeof(Panel_Map))]
    [HarmonyPatch("LoadMapElementsForScene")]
    public class ShowMapLocation {
        public static void Postfix(Panel_Map __instance, String sceneName) {
            List<Vector3> caches = MapManager.LocateSceneByName("PrepperCache");
            foreach (Vector3 each in caches) {
                MapManager.AddToMap(__instance, sceneName, "SCENENAME_PrepperCache", "icoMap_hatch", each);
            }
            MapManager.AddToMap(__instance, sceneName, "GAMEPLAY_Location", "ico_X", GameManager.GetPlayerTransform().localPosition);
        }
    }
}
