using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.localEulerAngles = new Vector3(0, 90, 0);
        transform.rotation = Quaternion.Euler(0, 180, 0);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
