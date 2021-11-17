using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
将图片去黑
(需要将原本图片format 换成bit32)
*/
public class SpriteDeletBlack : MonoBehaviour
{
    public Image test_img;
    public Image temp_img;
    // static string path = "Assets/Resources/";
    // Start is called before the first frame update
    void Start()
    {
        Sprite sp = test_img.sprite;
        Color[] tex = sp.texture.GetPixels();
        Color seeColor = tex[1000];
        Debug.Log(seeColor + "::seeColor");
        for (int i = 0; i < tex.Length; i++)
        {
            Color point = new Color(tex[i].r,tex[i].g,tex[i].b,tex[i].a) ;
            //从接近的值去剔除
            if ((point.r < 0.01f && point.g < 0.01f && point.b < 0.01f) || (point.r < 0.01f && point.g >= 0.9f && point.b < 0.01f))
            {
                // point.a = 0.0f;
                // point.r = 0.0f;
                // point.g = 0.0f;
                // point.b = 0.0f;
                point = new Color(0,0,0,0);
                // Debug.Log("改变数值");
            }
            // Debug.Log(tex[i]+"::::::tex[i]");
            tex[i] = point;
        }

        Texture2D tex1 = new Texture2D((int)sp.rect.width, (int)sp.rect.height, sp.texture.format, false, false);
        tex1.SetPixels(tex);
        tex1.Apply();
        System.IO.File.WriteAllBytes(Application.dataPath+"/deletBlack/tes11.png",tex1.EncodeToPNG());

        // a.texture.SetPixels(tex);
        // test_img.sprite = a;
        // Debug.Log(tex[0] + "::tex[0]");


    }

    float toFixedValue(float v)
    {
        if (v < 0.001)
        {
            v = 0;
        }
        return v;
    }
}
