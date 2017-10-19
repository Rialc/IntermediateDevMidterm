using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireframeRendererScript : MonoBehaviour {
    public GameObject MainCamera;
    
    Camera cam;
	// Use this for initialization
	void Start () {
		MainCamera = GameObject.FindWithTag("MainCamera");
        cam = this.gameObject.GetComponent<Camera>();
        cam.cullingMask = (1 << LayerMask.NameToLayer("Cone"));
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = MainCamera.GetComponent<Transform>().position;
        transform.rotation = MainCamera.GetComponent<Transform>().rotation;
    }
  
    void OnPreRender()
    {
        GL.wireframe = true;
    }
    void OnPostRender()
    {
        GL.wireframe = false;
    }

}
