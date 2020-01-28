using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracking : MonoBehaviour
{
    GameObject tObj;
    float minRoatate = -20;
    float maxRotate = 20;
    Vector3 currentRotate;

    //public GameObject panel;

    // Start is called before the first frame update
    void Start()
    {
        currentRotate = transform.localRotation.eulerAngles;
        tObj = GameObject.Find("trackingObject");
    } // End Start()

    // Update is called once per frame
    void Update()
    {

        currentRotate.x = Mathf.Clamp(currentRotate.x, minRoatate, maxRotate);
        transform.localRotation = Quaternion.Euler(currentRotate);
        transform.LookAt(tObj.transform.position, transform.up);

    } // End Update()
}
