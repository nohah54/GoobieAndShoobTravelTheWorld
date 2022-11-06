using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipFollowMouse : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        worldPosition.z = 95;
        Vector3 shipPos = this.transform.position;
        transform.position = Vector3.Lerp(shipPos, worldPosition, 0.01f);
    }
}
