using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onMouseClick : MonoBehaviour {
    private bool _clickable = false;
    BoxCollider myCollider;
    public BoxCollider lineCollider;
    public GameObject line;

    // Use this for initialization
    void Start () {
        myCollider = GetComponent<BoxCollider>();
        line = GameObject.FindGameObjectWithTag("line");
        lineCollider = line.GetComponent<BoxCollider>() as BoxCollider;
    }

    // Update is called once per frame
    void Update()
    {
        if (myCollider.bounds.Intersects(lineCollider.bounds))
        {
            Debug.Log("intersecting");
            OnMouseDown();
        }
        //OnTriggerExit(myCollider);


    }



    void OnMouseDown()
    {
        if (!_clickable == true)
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
    
    //void OnTriggerExit(Collider2D other)
    //{
    //    if (other.gameObject.name != "LineRenderer")
    //    {
    //        Debug.Log("nope nope nope");
    //        _clickable = false;
    //    }
    //}


}
