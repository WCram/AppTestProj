using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastTest : MonoBehaviour
{

    RaycastHit Rch;
    public float rayLength;
    public Material[] materials;
    public bool isHit;
    GameObject currentItem;
    GameObject lastItem;

    Vector3 origSize;
    Vector3 grow;

    // Start is called before the first frame update
    void Start()
    {
        grow = new Vector3(.3f,.3f, .1f);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * rayLength, Color.red, 0.5f);

        if(Physics.Raycast(transform.position, transform.forward, out Rch, rayLength))
        {

            if(Rch.collider.tag == "MenuItem")
            {
                currentItem = Rch.transform.gameObject;
                //origSize = currentItem.transform.localScale;

            }

            if(currentItem != null)
            {
                currentItem.transform.GetComponent<Renderer>().material = materials[1];
                //currentItem.transform.localScale = grow ;
            }

            if((currentItem != lastItem && lastItem != null))
            {
                lastItem.GetComponent<Renderer>().material = materials[0];
                //lastItem.transform.localScale = origSize;
                lastItem = null;
            }

            lastItem = currentItem;

            //if(Rch.collider.tag != "MenuItem")
            //{
            //    lastItem.transform.localScale = origSize;
            //    lastItem.GetComponent<Renderer>().material = materials[0];
            //    currentItem = lastItem = null;
            //}

            //if (Rch.collider.tag != "MenuItem")
            //{
            //    Debug.Log("Not a menu Item");
            //    lastItem.GetComponent<Renderer>().material = materials[0];
            //    lastItem.transform.localScale = origSize;
            //    lastItem = null;

            //    currentItem = lastItem = null;


            //}

        }
    }
}
