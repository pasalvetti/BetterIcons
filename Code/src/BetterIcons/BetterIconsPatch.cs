using HarmonyLib;
using KSP.OAB;
using RTG;
using UnityEngine;
using UnityEngine.UI;

namespace BetterIcons
{
    internal class BetterIconsPatch
    {
        static string pathToPartsPicker = "OAB(Clone)/HUDSpawner/HUD/widget_PartsPicker/mask_PartsPicker/GRP-Body/GRP-Part-Categories/";
        static int width = 48;
        static int height = 48;

        private static void changeIcon(string objectName, string imageName)
        {
            GameObject gameObject = GameObject.Find(pathToPartsPicker + objectName + "/");
            Image image = gameObject.GetChild(imageName).GetComponent<Image>();
            Debug.Log(imageName + " image has been found: " + image.name);
            Texture2D texture2D = new Texture2D(width, height);
            texture2D.LoadImage(File.ReadAllBytes("./BepInEx/plugins/BetterIcons/" + imageName + ".png"));
            image.sprite = Sprite.Create(texture2D, new Rect(0.0f, 0.0f, width, height), new Vector2(0.0f, 0.0f));
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
            changeIcon("BTN-Structures", "icon_structures");
            changeIcon("BTN-Couplers", "icon_couplers");
            changeIcon("BTN-Payloads", "icon_payloads");
            changeIcon("BTN-Aerodynamics", "icon_aero");
            changeIcon("BTN-Ground", "icon_ground");
            changeIcon("BTN-Thermal", "icon_thermal");
            changeIcon("BTN-Electrical", "icon_electrical");
            changeIcon("BTN-Communications", "icon_communications");
            changeIcon("BTN-Science", "icon_science");
        }

    }
}
