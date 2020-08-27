using UnityEngine;

public class CameraSegueFlechaNav : MonoBehaviour
{
    public Transform flechaNav;
    public Vector3 offset;

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.position = flechaNav.position + offset;
        this.transform.LookAt(flechaNav);
        
    }
}
