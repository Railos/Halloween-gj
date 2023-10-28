using System;
using UnityEngine;

public class LookAtCursor : MonoBehaviour
{
    private void Update()
    {
        Vector2 mousePos = GetMouseWorldPosition();
        Vector3 dir = mousePos - (Vector2)transform.position;
        Vector3 myLocation = transform.position;
        Vector3 targetLocation = mousePos;
        targetLocation.z = myLocation.z; // ensure there is no 3D rotation by aligning Z position
 
// vector from this object towards the target location
        Vector3 vectorToTarget = targetLocation - myLocation;
// rotate that vector by 90 degrees around the Z axis
        Vector3 rotatedVectorToTarget = Quaternion.Euler(0, 0, 90) * vectorToTarget;
 
// get the rotation that points the Z axis forward, and the Y axis 90 degrees away from the target
// (resulting in the X axis facing the target)
        Quaternion targetRotation = Quaternion.LookRotation(forward: Vector3.forward, upwards: rotatedVectorToTarget);

        transform.rotation = targetRotation;
    }
    
    private Vector2 GetMouseWorldPosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = -Camera.main.transform.position.z;
        return Camera.main.ScreenToWorldPoint(mousePosition);
    }
}
