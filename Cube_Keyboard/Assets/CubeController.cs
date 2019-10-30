using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;


public class CubeController : MonoBehaviour
{
    public List<GameObject> CubePrefabList;
    int index = 0;
    Vector3 mouse;
    Vector3 worldPos;
    static bool isCreated = false;
   

    public void setCreated(bool created)
    {
        isCreated = created;
    }
    public void generateColoredCubeSquare()
    {
        GameObject mainCube = GameObject.Find("MainCube");

        Camera camera = Camera.main;
        GameObject sim = GameObject.Find("[VRSimulator_CameraRig]");
        Vector3 pos = camera.transform.position;
        Vector3 dir = camera.transform.forward;
        Quaternion rot = camera.transform.rotation;
        float spawnDis = 10;
        Vector3 destination = pos + dir * spawnDis;


        mainCube.transform.position = new Vector3(1.08f, 1.92f, 1.08f) + destination;
        mainCube.transform.eulerAngles = new Vector3(0.0f, rot.eulerAngles.y + +135.0f, 0.0f);

        for (float z = 0; z < 3; z += 1.08f)
        {
            for (float y = 3; y > 0; y -= 1.08f)
            {
                for (float x = 0; x < 3; x += 1.08f)
                {
                    // Check if not the key in the cube's middle
                    if (!(x == 1.08f && y == 1.92f && z == 1.08f))
                    {
                        // Instantiate the key
                        var key = Instantiate(CubePrefabList[index], new Vector3(x, y, z) + destination, Quaternion.identity);
                        key.transform.parent = mainCube.transform;

                        // Increase index
                        if (index < CubePrefabList.Count)
                        {
                            index++;
                        }
                    }
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
            //creates cube only if not existent
            if (isCreated == false)
            {
                
                generateColoredCubeSquare();
                isCreated = true;

            }
            else
            {
                index = 0;
                isCreated = false;
            }
        }
       
    }
}