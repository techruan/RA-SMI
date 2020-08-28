using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegueFlecha : MonoBehaviour
{
    public Transform flechaNav;
    public Transform cameraRA;

    // Update is called once per frame
    void Update()
    {
        transform.position = flechaNav.position;
        transform.rotation = cameraRA.rotation;

    }
}
