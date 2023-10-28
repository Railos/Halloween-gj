using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCursor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = 0;
        transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }
}
