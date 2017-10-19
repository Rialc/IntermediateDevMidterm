using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coneScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        //this.gameObject.transform.Rotate(new Vector3());
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            Debug.Log("FUCK YES TRIGGERED");
            this.gameObject.GetComponentInParent<cameraScript>().RayCheck(other.gameObject.transform.position);
        }
    }
    
    
}
