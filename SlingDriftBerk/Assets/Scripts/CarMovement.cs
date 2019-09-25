using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public GameObject Menu ;
    public GameObject Rope;
    GameObject Barrels;   
    float speed = 10;
    Rigidbody2D rb;
    bool turned = false, isDistanceOk = false;
    int barrel=1;
    LineRenderer gunLine;
    void LineTheCar()
    {
        if (this.transform.rotation.z < -0.4f)
        {
            if (this.transform.rotation.z < -0.71 && turned != true)
            {
                rb.angularVelocity = 20;

            }
            else if (this.transform.rotation.z > -0.69 && turned != true)
            {
                rb.angularVelocity = -20;
            }
            else
            {
                rb.angularVelocity = 0;
            }
        }
        else if (this.transform.rotation.z > 0.4f)
        {
            if (this.transform.rotation.z < 0.69 && turned != true)
            {
                rb.angularVelocity = 20;

            }
            else if (this.transform.rotation.z > 0.71 && turned != true)
            {
                rb.angularVelocity = -20;
            }
            else
            {
                rb.angularVelocity = 0;
            }
        }
        else
        {
            if (this.transform.rotation.z < -0.01 && turned != true)
            {
                rb.angularVelocity = 20;

            }
            else if (this.transform.rotation.z > 0.01 && turned != true)
            {
                rb.angularVelocity = -20;
            }
            else
            {
                rb.angularVelocity = 0;
            }
        }
    }
    void CheckBarrel()
    {
        if(Barrels!=null)
        if (Vector2.Distance(Barrels.transform.position, this.transform.position) < 6.5f)
        {
            Barrels.GetComponent<SpriteRenderer>().color = Color.red;
            isDistanceOk = true;
        }
        
    }
    void DrawRope(Vector3 Vehicle,Vector3 Destination)
    {
        gunLine.SetPosition(0, Vehicle);
        gunLine.SetPosition(1, Destination);
    }
    
    void Start()
    {
        gunLine =Rope.GetComponent<LineRenderer>();
        gunLine.enabled = true;
        rb = this.GetComponent<Rigidbody2D>();
        Barrels = GameObject.Find("1");
        Barrels.GetComponent<HingeJoint2D>().enabled = false;
        Barrels.GetComponent<HingeJoint2D>().connectedBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (isDistanceOk)
        {
            if (Input.GetMouseButton(0))
            {
                Barrels.GetComponent<HingeJoint2D>().enabled = true;
                turned = true;
                DrawRope(transform.position, Barrels.transform.position);

            }
            else if (Input.GetMouseButtonUp(0))
            {
                Barrels.GetComponent<HingeJoint2D>().enabled = false;
                turned = false;
                barrel++;
                Barrels.GetComponent<SpriteRenderer>().color = Color.white;
                isDistanceOk = false;
                Barrels = GameObject.Find(barrel.ToString());
                if (Barrels != null)
                {
                    Barrels.GetComponent<HingeJoint2D>().connectedBody = GetComponent<Rigidbody2D>();
                    Barrels.GetComponent<HingeJoint2D>().enabled = false;
                }
                DrawRope(new Vector3(0,0,0),new Vector3(0,0,0));


            }

        }
        CheckBarrel();
        
    }

    void FixedUpdate()
    {         
        rb.AddForce(transform.up * speed);
        LineTheCar();
        
      
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Time.timeScale = 0f;
        Menu.GetComponent<Menu>().MenuCreate(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Time.timeScale = 0f;
        Menu.GetComponent<Menu>().MenuCreate(true);
    }


}
