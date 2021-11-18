using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/*
导出时，需要手动选中图片(效率更高)
*/
public class SpriteDeletBlackTool : MonoBehaviour
{
    [MenuItem("SpriteTools/导出去黑精灵")]
    static void ExportDelectBlack(){
        Debug.Log("调用 ExportDelectBlack");
        string resourcesPath = "Assets/Resources/";
        foreach (Object item in Selection.objects)
        {
            Debug.Log(item+":::::item选中的");
            string selectionPath = AssetDatabase.GetAssetPath(item);
            if(selectionPath.StartsWith(resourcesPath)){
                string selectionExt  = System.IO.Path.GetExtension(selectionPath);
                if(selectionExt.Length == 0){
                    continue;
                }


                string loadPath = selectionPath.Remove(selectionPath.Length - selectionExt.Length);
                loadPath = loadPath.Substring(resourcesPath.Length);

                //加载此文件夹下的所有资源
                Sprite[] sprites = Resources.LoadAll<Sprite>(loadPath);
                if(sprites.Length>0){
                    //创建导出文件夹
                    string outPath = Application.dataPath + "/delectBlack/";
                    System.IO.Directory.CreateDirectory(outPath);
                    foreach (Sprite sp in sprites)
                    {
                        Color[] colors = sp.texture.GetPixels();
                        for(int i=0;i<colors.Length;i++){
                            Color point = new Color(colors[i].r,colors[i].g,colors[i].b,colors[i].a);
                            if(point.r<0.008f && point.g<0.008f && point.b<0.008f){
                                point.r = 0;
                                point.g = 0;
                                point.b = 0;
                                point.a = 0;
                            }
                            colors[i] = point;
                        }
                        Texture2D texture = new Texture2D( (int)sp.rect.width,(int)sp.rect.height,sp.texture.format,false,false);
                        texture.SetPixels(colors);
                        texture.Apply();
                        System.IO.File.WriteAllBytes(outPath+sp.name+".png",texture.EncodeToPNG());
                    }

                }
            }
            
        }

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
