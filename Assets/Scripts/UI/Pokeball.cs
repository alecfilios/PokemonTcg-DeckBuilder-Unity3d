using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pokeball : MonoBehaviour
{
    public int rotateSpeed;
    // Update is called once per frame
    void Update()
    {
        // spin spin spin
        transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
    }
}
