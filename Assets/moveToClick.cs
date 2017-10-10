using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class moveToClick : MonoBehaviour {
    RaycastHit hit;
    public Vector3 target;
    public Text text;
    // Use this for initialization
    void Start () {
        target = new Vector3(transform.position.x, 0, transform.position.z);
	}

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.identity;
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                Debug.DrawLine(ray.origin, hit.point);
                Debug.Log(hit.point + " " + hit.transform.gameObject.name);
                if (hit.transform.gameObject.tag.Equals("floor"))
                {
                    target = hit.point;
                }
            }
        }

        if (target != null && !Input.GetKey(KeyCode.Space))
        {
            this.GetComponent<Rigidbody>().MovePosition(Vector3.MoveTowards(transform.position, target + new Vector3(0, 0.75f, 0), .1f));
        }
        // transform.position = new Vector3(transform.position.x, 0.75f, transform.position.z);
    }
    private void OnCollisionExit(Collision collision)
    {
        this.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="treasure")
        {
            text.text = "A winner is you!";
        }
    }
}
