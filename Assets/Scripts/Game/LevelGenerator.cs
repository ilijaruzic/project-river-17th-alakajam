using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[ExecuteInEditMode]
public class LevelGenerator : MonoBehaviour
{
    /*
     * G - GRASS (random)
     * S - SAND
     * W - WATER
     * D - DIRT
     * 
     */
    //

    //
    // 

    string[] levelMap = {
        "GDGDDDGGGGGGGGDGGDGGGGGGDGGGGGGGDGGGDGDGGGGGGDGGGG",
        "DGGDDDGGGGGGGGGDDGDGGGGDDDDDGGGGDDGGGDGGGGDGDGGDGG",
        "DGGDGGDDDDDDDDDDDDDDDDDDDDDDDDDDDDDGDDGGDGDDDDDGGG",
        "DDGDGDDDSSSSWWWWWWWWWWWWWWWWWWWWDDGDDGGGDDGDGGGDGG",
        "GGGGGDDSSSSSWWWWWWWWWWWWWWWWWWWWWDDDDDDGGGGGGGDGGD",
        "GGGGDDSSSSSSWWWWWWWWWWWWWWWWWWWWWWDDGDDGGDGGDGGDDG",
        "GGGDDSSSSSSSWWWWWWWWWWWWWWWWWWWWWWWDDDDDGGDDDDDGDD",
        "GGGDSSSSSSSSWWWWWWWWWWWWWWWWWWWWWWWWDDGGGDDSSDDDGG",
        "GGGDSSSSSSSSWWWWWWWWWWWWWWWWWWWWWWWWWDDGDDSSSSDDGG",
        "GGGDSSSSSSSSWWWWWWWWWWWWWWWWWWWWWWWWWWDDDSSSSSSDGG",
        "DDDDSSSSSSSSWWWWWWWWWWWWWWWWWWWWWWWWWWWDDSSSSSSDGG",
        "GDGDSSSSSSSSWWWWWWWWWWWWWWWDDDDDWWWWWWWWDDSSSSDDGG",
        "DGGDDSSSSSSSWWWWWWWWWWWWWWDDGGGDDWWWWWWWWDDSSWWDGG",
        "DGDGDDSSSSSSWWWWWWWWWWWWWDDGGGGGDDWWWWWWWDDDWWWDGG",
        "GGGGDDDSSSSSWWWWWWWWWWWWDDGGGDGGGDDWWWWWWWWWWWDDGG",
        "GGGGGDDDSSSSWWWWWWWWWWWDDGGGDGDDGGDDWWWWWWWWWWDGGG",
        "GGGDGDGDDDDDDDDDDDDDDDDDGDGDGGDDDDGDDWWWWWWWWDDDDG",
        "GGGGGGDGDGGDGGDDDGGGGDDDDGGGDDDDGGGGDDDDDDDDDDGGDG",
        "GGGDGDDGGGGGGDGGGGGGGDGGDDGGDDDGDGGGGGGGGGGGGGGGDG",
        "GGGGGDGGGGGGDDGDGGGGGDGDDDGGGGGGGGGGGGGGGGGGGGGDGD",
    };

    [SerializeField] private GameObject[] GrassTiles;
    [SerializeField] private GameObject SandTile;
    [SerializeField] private GameObject DirtTile;
    [SerializeField] private GameObject WaterTile;
    [SerializeField] private GameObject EmptyTile;

    [SerializeField] private GameObject[] Trees;
    [SerializeField] private GameObject[] Bushes;
    [SerializeField] private GameObject[] Stones;
    [SerializeField] private Transform Parent;

    private float width = 3.2f;
    private float height = 3.2f;

    // Grid is [x,y]
    [SerializeField] float startPosX;
    [SerializeField] float startPosY; 

    void Awake()
    {

        //GrassTiles 

        //if (GameObject.Find("DirtObject(Clone)"))
        //{
        //    return;
        //}

        for (int i = 0; i < levelMap.Length; i++)
        {
            string row = levelMap[i];
            for (int j = 0; j < row.Length; j++)
            {
                char sym = row[j];
                GameObject toClone = null;
                switch (sym)
                {
                    case 'G':
                    case 'D':
                        //int randVal = Mathf.RoundToInt(Random.Range(0, 4));
                        //toClone = Bushes[randVal];
                        break;
                    case 'S':
                        //toClone = SandTile;
                        break;
                    case 'W':
                        //int randVal = Mathf.RoundToInt(Random.Range(0, 10));
                        //if (randVal <= 2)
                        //{
                        //    toClone = Stones[randVal];
                        //}
                        break;
                }

                Vector3 clonePos = new Vector3(
                    Random.Range(startPosX + width * (i - 1), startPosX + width * i),
                    2, //4.2f, //(sym == 'S') ? 2.6f : 1,
                    Random.Range(startPosY + height * (j - 1), startPosY + height * j)
                );
                Quaternion cloneRot = Quaternion.identity;
                if (toClone != null)
                {
                    GameObject clone = Instantiate(toClone, clonePos, cloneRot, Parent);
                }
            }
        }
        
    }
}
