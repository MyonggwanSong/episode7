using CustomInspector;
using UnityEngine;
public class MapGenerator : MonoBehaviour
{

    [Header("하이트맵 소스")]
    [SerializeField] Texture2D heightmap;

    [SerializeField] GameObject tile;
    [SerializeField] GameObject Tree;

    [Header("하이트 맵 속성")]
    
    [SerializeField] float heightRange;
    [SerializeField] float treeoffset;

    [Button("GetInfo", size =Size.big)] public bool _b0;
    void GetInfo()
    {
        int w = heightmap.width;
        int h = heightmap.height;
        //Debug.Log(w);
        //Debug.Log(h);

        for (int x = 0; x < w; x++)
        {
            for (int y = 0; y < h; y++)
            {

                Color col = heightmap.GetPixel(x, y);
                Debug.Log($"컬러 r = {col.r}");

            }

        }



    }

    [Button("BuildMap", size =Size.big)] public bool _b1;
    void BuildMap()
    {
        int w = heightmap.width;
        int h = heightmap.height;
        GameObject Empty = new GameObject("Group");
        //Debug.Log(w);
        //Debug.Log(h);

        for (int x = 0; x < w; x++)
        {
            for (int z = 0; z < h; z++)
            {

                Color col = heightmap.GetPixel(x, z);
                float y = heightRange * col.r;
                float y_ = heightRange * col.r + treeoffset / 2 ;



                if (col.g > 0.0f)
                {
                    GameObject tree = Instantiate(Tree, new Vector3(x, y_, z), Quaternion.identity);
                    tree.transform.SetParent(Empty.transform);
                }
                else { }

                GameObject o = Instantiate(tile, new Vector3(x, y, z), Quaternion.identity);
                o.transform.SetParent(Empty.transform);

            }

        }




    }

}
