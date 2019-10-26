using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class CubeController : MonoBehaviour
{
    public List<GameObject> CubePrefabList;
    int index = 0;
    Vector3 mouse;
    Vector3 worldPos;

    public void generateColoredCubeSquare()
    {
         for (float z = 0; z < 3; z += 1.08f)
            {
            for (float y = 3; y > 0; y -= 1.08f)
            {
                for (float x = 0; x < 3; x += 1.08f)
                {
                    Instantiate(CubePrefabList[index], new Vector3(x, y, z), Quaternion.identity);
                    if (index < 11) index++;
                }
            }
        }

       
    }


    public void Start()
    {
       
    }

    public void Update()
    {

        if (Input.GetMouseButtonDown(1))
        {
            //mouse = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f);
          
            generateColoredCubeSquare();

        }
    }
}