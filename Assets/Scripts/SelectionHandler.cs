using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionHandler : MonoBehaviour
{
    [System.NonSerialized] public Transform selection;

    void Update()
    {
        SelectTarget();
    }

    // On click, cast ray and assign any hit enemy gameobject transform as selection
    void SelectTarget()
    {
        if (!Input.GetMouseButtonDown(0))
            return;

        Vector3 mp = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(mp);

        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            if (hitInfo.transform.tag == "Enemy")
            {
                selection = hitInfo.transform;
                Debug.Log($"Selection is {hitInfo.transform.name}");
            }
        }
    }
}
