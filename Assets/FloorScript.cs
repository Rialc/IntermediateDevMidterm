using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorScript : MonoBehaviour {
    public GameObject cam;
    bool focus = true;
	// Use this for initialization
	void Start () {
        foreach (Transform child in transform)
        {
            if (child.tag.Equals("VisualBlocker"))
            {
                child.gameObject.SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (focus && cam != null)
        {
            Debug.Log("We should be  moving the camera");
            cam.GetComponent<Transform>().position = Vector3.MoveTowards(cam.transform.position, this.transform.position + cam.GetComponent<mainCameraScript>().initPos, .15f);
            if(cam.GetComponent<Transform>().position.Equals(this.transform.position + cam.GetComponent<mainCameraScript>().initPos))
            {
                focus = false;
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            Debug.Log("We're on the" + this.gameObject.name);
            cam = GameObject.FindWithTag("MainCamera");
            focus = true;
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(true);
            }
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            focus = false;
            foreach (Transform child in transform)
            {
                if (child.tag.Equals("VisualBlocker"))
                {
                    child.gameObject.SetActive(false);
                }
            }
        }
        }
}
