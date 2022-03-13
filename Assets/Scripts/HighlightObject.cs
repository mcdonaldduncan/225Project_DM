using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightObject : MonoBehaviour
{
    Color startColor;
    Renderer rend;

    // Cache renderer and starting color
    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    // Set renderer color to cyan on mouseover
    private void OnMouseEnter()
    {
        rend.material.color = Color.cyan;
    }

    // Reset renderer color on mouse exit
    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
