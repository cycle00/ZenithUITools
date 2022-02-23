using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using UnhollowerBaseLib;
using UnityEngine;
using UnityEngine.Networking;

namespace ZenithUITools.Utils
{
    public static class FileUtils
    {

        public static Sprite LoadNewSprite(string manifestName, float ppu = 100.0f)
        {
            var bytes = ToByteArray(Assembly.GetExecutingAssembly().GetManifestResourceStream(manifestName));
            var tex = LoadTexture(bytes);
            var sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(.5f, .5f), ppu, 1, SpriteMeshType.FullRect);
            sprite.border.Set(5, 5, 5, 5);

            return sprite;
        }

        public static byte[] ToByteArray(Stream input) => new BinaryReader(input).ReadBytes((int)input.Length);

        public static Texture2D LoadTexture(byte[] bytes)
        {

            var tex2D = new Texture2D(2, 2);
            if (ImageConversion.LoadImage(tex2D, bytes))
                return tex2D;
            Debug.LogWarning("Error when loading load texture!");
            return null;
        }

        public static byte[] GetResource(Assembly asm, string ResourceName)
        {
            Stream stream = asm.GetManifestResourceStream(ResourceName);
            byte[] data = new byte[stream.Length];
            stream.Read(data, 0, (int)stream.Length);
            return data;
        }

        public static Texture2D GetTexture2DFromResource(Assembly asm, string FilePath, float PixelsPerUnit = 100.0f)
        {

            // Load a PNG or JPG image from disk to a Texture2D, assign this texture to a new sprite and return its reference

            Texture2D SpriteTexture = new Texture2D(100, 100);
            SpriteTexture.name = FilePath;
            SpriteTexture.LoadRawTextureDataImplArray(GetResource(asm, FilePath));
            SpriteTexture.Apply();
            return SpriteTexture;
        }
    }
}
