using System.Runtime.CompilerServices;
using BepInEx;
using TMPro;
using UnityEngine;

namespace SimpleUILib
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        internal static Canvas canvas;
        internal static int nextId = 0;
        private void Awake()
        {
            // Plugin startup logic
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
        }

        private void Update()
        {
            // name of canvas is "Canvas (1)" because zapray makes messy gameobjects smh
            canvas = GameObject.Find("Canvas (1)").GetComponent<Canvas>();
            if (nextId == 0) {
                // Testing time!!!!!!! :realization:
                new Text("Hello World", new Vector2(0, 0), new Vector2(7, 0.5f), Color.black);
            }
        }
        private void OnSceneLoad()
        {

        }
    }
    public class Text
    {
        public int id;
        public string text;
        public Vector2 pos;
        public Vector2 size;
        public GameObject gameObject;
        public RectTransform rectTransform;
        public TextMeshProUGUI tmpComponent;
        public Color color;
        public Text(string text, Vector2 position, Vector2 size, Color color)
        {
            this.text = text;
            this.pos = position;
            this.size = size;
            this.id = Plugin.nextId;
            this.color = color;
            Plugin.nextId++;
            gameObject = new GameObject("TEXT_" + this.id.ToString());
            gameObject.transform.SetParent(Plugin.canvas.transform);
            gameObject.transform.position = pos;
            gameObject.AddComponent<TextMeshProUGUI>();
            tmpComponent = gameObject.GetComponent<TextMeshProUGUI>();
            tmpComponent.font = LocalizedText.localizationTable.GetFont(Settings.Get().Language, false);
            tmpComponent.color = color;
            tmpComponent.fontSize = 0.27f;
            tmpComponent.alignment = TextAlignmentOptions.TopLeft;
            gameObject.GetComponent<TextMeshProUGUI>().text = text;
            gameObject.AddComponent<RectTransform>();
            rectTransform = gameObject.GetComponent<RectTransform>();
            rectTransform.anchorMin = new Vector2(1, 0);
            rectTransform.anchorMax = new Vector2(1, 0);
            rectTransform.pivot = new Vector2(1, 0);
            rectTransform.anchoredPosition = pos;
            rectTransform.sizeDelta = this.size;
        }

    }
}
