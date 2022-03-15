using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightObject : MonoBehaviour
{
    [SerializeField] GameObject indicatorPrefab;
    [SerializeField] float indicatorHeight;

    GameObject indicator;
    Renderer rend;

    Vector3 indicatorPosition;

    Color startColor;

    // Cache renderer and starting color
    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        indicatorPosition = transform.position + Vector3.up * indicatorHeight;
    }

    // Set renderer color to cyan on mouseover
    private void OnMouseEnter()
    {
        rend.material.color = Color.cyan;
        indicator = Instantiate(indicatorPrefab);
        indicator.transform.position = indicatorPosition;
        
    }

    // Reset renderer color on mouse exit
    private void OnMouseExit()
    {
        rend.material.color = startColor;
        Destroy(indicator);
    }
}
