using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cameraScript : MonoBehaviour
{
    int rot = 0;
    public LineRenderer LoS;
    public bool reverse = false;
    RaycastHit hit;
    public Text text;
    int count = 0;
    // Use this for initialization
    void Start()
    {
        LoS = this.GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {


        if (!reverse)
        {
            rot--;
            transform.rotation = Quaternion.Euler(31.5f, rot, 0);
        }
        else
        {
            rot++;
            transform.rotation = Quaternion.Euler(31.5f, rot, 0);
        }
        if (rot == -90)
        {
            reverse = true;
        }
        else if (rot == 0)
        {
            reverse = false;
        }
        // Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Ray ray = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(ray, out hit))
        {
            //Debug.DrawLine(ray.origin, hit.point, Color.red);
            //Debug.DrawLine(Vector3.zero, new Vector3(1, 0, 0), Color.red);
            //Debug.Log(hit.point);
            LoS.SetPosition(0, ray.origin);
            LoS.SetPosition(1, hit.point);
            Debug.Log("Camera sees:" + hit.transform.gameObject.name);
            if (hit.transform.gameObject.name == "Player")
            {
                count++;
                text.text = ("Frames the noob has been hit:" + count);
            }
            //target = hit.point;
        }
    }
}
