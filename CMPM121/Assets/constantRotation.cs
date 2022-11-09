using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class constantRotation : MonoBehaviour
{
    public Vector3 rotationSpeed;
    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}
