using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onMouseClick : MonoBehaviour {
    private bool _clickable = false;
    BoxCollider myCollider;
    private BoxCollider lineCollider;
    private GameObject line;

    // Use this for initialization
    void Start () {
        myCollider = GetComponent<BoxCollider>();
        line = GameObject.Find("LineHitbox");
        lineCollider = line.GetComponent<BoxCollider>() as BoxCollider;
    }

    // Update is called once per frame
    void Update()
    {
        if (myCollider.bounds.Intersects(lineCollider.bounds))
        {
            //Debug.Log("intersecting");
            OnMouseDown();
        }
        //OnTriggerExit(myCollider);


    }



    void OnMouseDown()
    {
        if (_clickable)
        {
            //do your interaction stuff below this line
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit))
                {
                    BoxCollider bc = hit.collider as BoxCollider;
                    if (bc != null)
                    {
                        Destroy(bc.gameObject);
                    }
                }
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Reaction")
        {
            //Debug.Log("yes");
            _clickable = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        _clickable = false;
        //Debug.Log("no");
    }


}
