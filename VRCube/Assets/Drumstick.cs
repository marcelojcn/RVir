using UnityEngine;

public class Drumstick : MonoBehaviour
{
    public GameObject RightDrumstick;
    public GameObject LeftDrumstick;

    public GameObject RightSphere;
    public GameObject LeftSphere;

    public bool IsActive = false;

    public Material OutlinedMaterial;

    private void OnTriggerEnter(Collider other)
    {
        if (!IsActive)
        {
            RightDrumstick.SetActive(true);
            LeftDrumstick.SetActive(true);
            RightSphere.SetActive(false);
            LeftSphere.SetActive(false);

            IsActive = true;
        }
        else
        {
            RightDrumstick.SetActive(false);
            LeftDrumstick.SetActive(false);
            RightSphere.SetActive(true);
            LeftSphere.SetActive(true);

            IsActive = false;
        }

        ToggleOutlined(IsActive);
    }

    private void ToggleOutlined(bool status)
    {
        if (status)
        {
            GetComponent<Renderer>().material = OutlinedMaterial;
        }
        else
        {
            //Fetch the Material from the Renderer of the GameObject
            Material material = GetComponent<Renderer>().material;
            material.shader = Shader.Find("Standard");
            material.renderQueue = 3000;
        }
    }
}
