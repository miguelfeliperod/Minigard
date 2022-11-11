using System.Collections.Generic;
using UnityEngine;

public static class BattlerSpriteMerger
{
    public static Sprite GetMergedSprites(List<Texture2D> textureList)
    {
        Resources.UnloadUnusedAssets();
        var newTexture = new Texture2D(textureList[0].width, textureList[0].height);
        newTexture.filterMode = FilterMode.Point;

        SetInvisibleBackground(newTexture);

        for(int index = 0; index < textureList.Count; index++)
        {
            for (int width = 0; width < textureList[index].width; width++)
            {
                for (int height = 0; height < textureList[index].height; height++)
                {
                    var color = textureList[index].GetPixel(width, height).a < 0.3f  ?
                        newTexture.GetPixel(width, height) :
                        textureList[index].GetPixel(width, height);
                    newTexture.SetPixel(width, height, color);
                }
            }
        }
        newTexture.Apply();
        var finalSprite = Sprite.Create(newTexture, new Rect(0, 0, newTexture.width, newTexture.height), new Vector2(0.5f, 0.5f));
        finalSprite.name = "New Sprite";
        return finalSprite;
    }

    static void SetInvisibleBackground(Texture2D newTexture) {
        for (int width = 0; width < newTexture.width; width++)
        {
            for (int height = 0; height < newTexture.height; height++)
            {
                newTexture.SetPixel(width, height, new Color(1, 1, 1, 0f));
            }
        }
    }
}
