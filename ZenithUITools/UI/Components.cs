using System;
using System.Collections.Generic;
using System.Text;
using BepInEx.IL2CPP;
using BepInEx;

using UnityEngine;
using UnityEngine.UI;
using TMPro;
using ZenithUITools.Utils;
using System.Reflection;

namespace ZenithUITools.UI
{
    public static class Components
    {
        public static Button CreateButton(string name, string displayText, Transform parent, Enums.ButtonStyle buttonType, Action onClick)
        {
            GameObject buttonGameObject = new GameObject(name);
            buttonGameObject.transform.parent = parent;
            buttonGameObject.transform.localPosition = Vector3.zero;
            buttonGameObject.transform.localScale = Vector3.one;
            GameObject backgroundGameObject = new GameObject("BG");
            backgroundGameObject.transform.parent = buttonGameObject.transform;
            backgroundGameObject.transform.localPosition = Vector3.zero;
            backgroundGameObject.transform.localScale = Vector3.one;
            GameObject textGameObject = new GameObject("Text");
            textGameObject.transform.parent = buttonGameObject.transform;
            textGameObject.transform.transform.localScale = Vector3.one;
            textGameObject.transform.localPosition = Vector3.zero;
            TextMeshProUGUI text = textGameObject.AddComponent<TextMeshProUGUI>();
            text.text = displayText.ToUpper();
            text.horizontalAlignment = HorizontalAlignmentOptions.Center;
            text.verticalAlignment = VerticalAlignmentOptions.Middle;

            Image image = backgroundGameObject.AddComponent<Image>();
            switch(buttonType)
            {
                case Enums.ButtonStyle.White:
                    image.sprite = FileUtils.LoadNewSprite("ZenithUITools.Assets.button0.png");
                    backgroundGameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(247, 89);
                    break;
                case Enums.ButtonStyle.Gray:
                    image.sprite = FileUtils.LoadNewSprite("ZenithUITools.Assets.button1.png");
                    backgroundGameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(274, 91);
                    break;
                case Enums.ButtonStyle.Blue:
                    image.sprite = FileUtils.LoadNewSprite("ZenithUITools.Assets.button2.png");
                    backgroundGameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(264, 89);
                    break;
                case Enums.ButtonStyle.Yellow:
                    image.sprite = FileUtils.LoadNewSprite("ZenithUITools.Assets.button3.png");
                    backgroundGameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(274, 98);
                    break;
            }

            Button button = buttonGameObject.AddComponent<Button>();
            button.onClick.AddListener(onClick);
            button.image = image;
            return button;
        } 
    }
}
