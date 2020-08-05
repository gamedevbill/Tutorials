using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotator : MonoBehaviour
{
    public Vector3 factor;
    Transform t;
    // Start is called before the first frame update
    void Start()
    {
        t = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //t.Rotate(0, 0.5f, 0);
        t.Rotate(factor);
    }
}
