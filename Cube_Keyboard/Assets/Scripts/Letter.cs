using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Letter : MonoBehaviour
{
    public string value;

    public Shader outlineShader;
    private void OnMouseEnter() 
    {
        //Fetch the Material from the Renderer of the GameObject
        Material material = GetComponent<Renderer>().material;
        material.shader = Shader.Find("Outlined/Uniform");
    }

    private void OnMouseExit()
    {
        //Fetch the Material from the Renderer of the GameObject
        Material material = GetComponent<Renderer>().material;
        material.shader = Shader.Find("Standard");
    }

    private void OnMouseDown()
    {
        Debug.Log(value);
    }


}
