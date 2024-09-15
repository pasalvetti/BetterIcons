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

        private static void changeIcon(String partName)
        {
            GameObject gameObject = GameObject.Find(pathToPartsPicker + "BTN-" + partName + "/");
            Image image = gameObject.GetChild("ICO-Category-Placeholder").GetComponent<Image>();
            Debug.Log(partName + " image has been found: " + image.name + " of type " + image.GetType());
            //int width = 48;
            //int height = 48;
            Texture2D texture2D = new Texture2D(width, height);
            texture2D.LoadImage(File.ReadAllBytes("./BepInEx/plugins/BetterIcons/PartCategories-ICO-" + partName + ".png"));
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
            GameObject gameObject = GameObject.Find("OAB(Clone)/HUDSpawner/HUD/widget_PartsPicker/mask_PartsPicker/GRP-Body/GRP-Part-Categories/BTN-Favorites/");
            Image image = gameObject.GetChild("icon_favorites").GetComponent<Image>();
            Debug.Log("Favorite image has been found: "+ image.name+" of type "+ image.GetType());
            int width = 24;
            int height = 24;
            Texture2D texture2D = new Texture2D(width, height);
            texture2D.LoadImage(File.ReadAllBytes("./BepInEx/plugins/BetterIcons/icon.png"));
            image.sprite = Sprite.Create(texture2D, new Rect(0.0f, 0.0f, (float)width, (float)height), new Vector2(0.0f, 0.0f));
            List<GameObject> children = gameObject.GetAllChildren();
            foreach (GameObject child in children)
            {
                Debug.Log("child: " + child.name);
            }
            changeIcon("Pods");
            changeIcon("FuelTanks");
        }

    }
}
