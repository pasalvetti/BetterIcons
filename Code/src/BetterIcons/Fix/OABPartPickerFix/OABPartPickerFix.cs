using HarmonyLib;
using KSP.Map;
using KSP.Messages;
using KSP.OAB;
using RTG;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.UI.Image;

namespace BetterIcons.Fix.OABPartPickerFix
{
    [Fix("xxx")]
    internal class OABPartPickerFix : BaseFix
    {
        static String pathToPartsPicker = "OAB(Clone)/HUDSpawner/HUD/widget_PartsPicker/mask_PartsPicker/GRP-Body/GRP-Part-Categories/";
        static int width = 48;
        static int height = 48;

        public override void OnInitialized()
        {
            HarmonyInstance.PatchAll(typeof(OABPartPickerFix));
        }

        private static void changeIcon(String objectName, String imageName)
        {
            GameObject gameObject = GameObject.Find(pathToPartsPicker + objectName + "/");
            Image image = gameObject.GetChild(imageName).GetComponent<Image>();
            Debug.Log(imageName + " image has been found: " + image.name);
            Texture2D texture2D = new Texture2D(width, height);
            texture2D.LoadImage(File.ReadAllBytes("./BepInEx/plugins/BetterIcons/" + imageName + ".png"));
            image.sprite = Sprite.Create(texture2D, new Rect(0.0f, 0.0f, (float)width, (float)height), new Vector2(0.0f, 0.0f));
            List<GameObject> children = gameObject.GetAllChildren();
            foreach (GameObject child in children)
            {
                Debug.Log("child: " + child.name);
            }
        }

        [HarmonyPatch(typeof(AssemblyPartsPicker), nameof(AssemblyPartsPicker.Start))]
        [HarmonyPostfix]
        public static void StartPostfix()
        {
            changeIcon("BTN-Favorites", "icon_favorites");
            changeIcon("BTN-Pods", "ICO-Category-Placeholder");
            changeIcon("BTN-Fuel", "icon_fuel");
            changeIcon("BTN-Engines", "icon_engines");
        }

    }
}
