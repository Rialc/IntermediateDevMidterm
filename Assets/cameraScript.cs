using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class cameraScript : MonoBehaviour
{
    public float rotStart = 0;
    float rot = 0;
   // public LineRenderer LoS;
    public bool reverse = false;
    RaycastHit hit;
    public Text text;
    int count = 0;
    public int RotBig = 0;
    public int RotSmall = -90;
    public float startAngle = 31.5f;
    Image img;
    //int layermask;
    // Use this for initialization
    void Start()
    {
       // LoS = this.GetComponent<LineRenderer>();
       rot=rotStart;
        img = GameObject.FindWithTag("circle").GetComponent<Image>();
       //layermask = 1 << LayerMask.NameToLayer("Cone");
    }

    // Update is called once per frame
    void Update()
    {


        if (!reverse)
        {
            rot-=.25f;
            transform.rotation = Quaternion.Euler(startAngle, rot, 0);
        }
        else
        {
            rot+=.25f;
            transform.rotation = Quaternion.Euler(startAngle, rot, 0);
        }
        if (rot <= RotSmall)
        {
            reverse = true;
           
        }
        else if (rot >= RotBig)
        {
            reverse = false;
           
        }
        // Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
       
        
        
    }
    public void RayCheck(Vector3 q)
    {
        
        if (Physics.Linecast(transform.position, q,  out hit))//This gets us the center of the camera, but we could do 4 lines going from the corners outwards for a cone of sight, like a flashlight. How would we make the renderer look good?
        {

            //Debug.DrawLine(ray.origin, hit.point, Color.red);
            //Debug.DrawLine(Vector3.zero, new Vector3(1, 0, 0), Color.red);
            //Debug.Log(hit.point);
           
            //Debug.Log("Camera sees:" + hit.transform.gameObject.name);
            if (hit.transform.gameObject.name == "Player")
            {
                count++;
                img.fillAmount = img.fillAmount - .01f;
                if (img.fillAmount <= 0)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
                //text.text = ("Frames the noob has been hit:" + count);
            }
            //target = hit.point;
        }
    }
}

/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class cameraScript : MonoBehaviour
{
    public float rotStart = 0;
    float rot = 0;
    public LineRenderer LoS;
    public bool reverse = false;
    RaycastHit hit;
    public Text text;
    int count = 0;
    public int RotBig = 0;
    public int RotSmall = -90;
    public float startAngle = 31.5f;
    //int layermask;
    // Use this for initialization
    void Start()
    {
        LoS = this.GetComponent<LineRenderer>();
       rot=rotStart;
       //layermask = 1 << LayerMask.NameToLayer("Cone");
    }

    // Update is called once per frame
    void Update()
    {


        if (!reverse)
        {
            rot-=.25f;
            transform.rotation = Quaternion.Euler(startAngle, rot, 0);
        }
        else
        {
            rot+=.25f;
            transform.rotation = Quaternion.Euler(startAngle, rot, 0);
        }
        if (rot <= RotSmall)
        {
            reverse = true;
           
        }
        else if (rot >= RotBig)
        {
            reverse = false;
           
        }
        // Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Ray ray = new Ray(transform.position, transform.forward);
        
        if (Physics.Raycast(ray, out hit))//This gets us the center of the camera, but we could do 4 lines going from the corners outwards for a cone of sight, like a flashlight. How would we make the renderer look good?
        {

            //Debug.DrawLine(ray.origin, hit.point, Color.red);
            //Debug.DrawLine(Vector3.zero, new Vector3(1, 0, 0), Color.red);
            //Debug.Log(hit.point);
            LoS.SetPosition(0, ray.origin);
            LoS.SetPosition(1, hit.point);
            //Debug.Log("Camera sees:" + hit.transform.gameObject.name);
            if (hit.transform.gameObject.name == "Player")
            {
                count++;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                //text.text = ("Frames the noob has been hit:" + count);
            }
            //target = hit.point;
        }
    }
}*/
