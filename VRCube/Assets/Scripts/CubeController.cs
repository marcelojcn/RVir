using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;
using Assets.Utilities;
using Assets.Utilities.Enums;

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

        ////Camera camera = Camera.main;
        Vector3 destination = OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTrackedRemote) + new Vector3(-0.1f, 1.3f, -0.1f);

        mainCube.transform.position = destination;
        //mainCube.transform.eulerAngles = new Vector3(0.0f, rot.eulerAngles.y +135.0f, 0.0f);

        for (float z = 0; z < 0.3f; z += 0.1f)
        {
            for (float y = 0.3f; y > 0.1f; y -= 0.1f)
            {
                for (float x = 0; x < 0.3f; x += 0.1f)
                {
                    // Check if not the key in the cube's middle
                    if (!(x == 0.2f && y == 0.2f && z == 0.2f))
                    {
                        // Instantiate the key
                        var key = Instantiate(CubePrefabList[index], new Vector3(x, y, z) + destination, Quaternion.identity);
                        key.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
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
        if (OVRInput.Get(OVRInput.RawAxis1D.RIndexTrigger) > 0)
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