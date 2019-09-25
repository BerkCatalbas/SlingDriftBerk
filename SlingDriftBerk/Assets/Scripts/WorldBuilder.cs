using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldBuilder : MonoBehaviour
{
    float offset = 6.25f;
    float barreloffset = 4.25f;
    public GameObject Vertical, Horizontal, UprRight, UpLeft, DownRight, DownLeft, Finish,Barrel;
    public GameObject previousRoad,car;
    string Direction;   
    
    void FinishLine()
    {
        GameObject FCopy;
        switch (Direction)
        {
            case "Up":
                Instantiate(Finish, new Vector3(previousRoad.transform.position.x, previousRoad.transform.position.y + offset, previousRoad.transform.position.z), Quaternion.identity);
                break;
            case "Right":
                FCopy = Instantiate(Finish, new Vector3(previousRoad.transform.position.x + offset, previousRoad.transform.position.y, previousRoad.transform.position.z), Quaternion.identity);
                FCopy.transform.Rotate(0, 0, 90);
                break;
            case "Left":
                FCopy = Instantiate(Finish, new Vector3(previousRoad.transform.position.x - offset, previousRoad.transform.position.y, previousRoad.transform.position.z), Quaternion.identity);
                FCopy.transform.Rotate(0, 0, 90);
                break;
        }
    }
    

    void Start()
    {
        Time.timeScale = 1f;
        Direction = "Up";
        GameObject barrelcopy=null, copied = null;
        int barrelnumber = 0;
       

        for (int i = 0; i< 20; i++)
        {
            int rnd;
            if (previousRoad.tag != "Corner")
                rnd = Random.Range(0, 3);
            else
                rnd = 0;

            if (Direction == "Up")
            {           
                                     
                switch (rnd)
                {
                    case 0:
                        copied = Instantiate(Vertical, new Vector3(previousRoad.transform.position.x, previousRoad.transform.position.y + offset, previousRoad.transform.position.z), Quaternion.identity);
                        Direction = "Up";                        
                        break;
                    case 1:
                        copied = Instantiate(UprRight, new Vector3(previousRoad.transform.position.x, previousRoad.transform.position.y + offset, previousRoad.transform.position.z), Quaternion.identity);
                        Direction = "Right";
                        barrelcopy= Instantiate(Barrel, new Vector3(copied.transform.position.x + barreloffset,copied.transform.position.y -barreloffset, previousRoad.transform.position.z), Quaternion.identity);
                        barrelnumber++;
                        barrelcopy.name = barrelnumber.ToString();
                        break;
                    case 2:
                        copied = Instantiate(UpLeft, new Vector3(previousRoad.transform.position.x, previousRoad.transform.position.y + offset, previousRoad.transform.position.z), Quaternion.identity);
                        Direction = "Left";
                        barrelcopy = Instantiate(Barrel, new Vector3(copied.transform.position.x-barreloffset, copied.transform.position.y - barreloffset, previousRoad.transform.position.z), Quaternion.identity);
                        barrelnumber++;
                        barrelcopy.name = barrelnumber.ToString();
                        break;

                }
                
            }
            else if (Direction == "Right")
            {           
                  
                switch (rnd)
                {

                    case 0:
                        copied = Instantiate(Horizontal, new Vector3(previousRoad.transform.position.x + offset, previousRoad.transform.position.y, previousRoad.transform.position.z), Quaternion.identity);
                        Direction = "Right";
                        break;
                    case 1:
                        copied = Instantiate(DownLeft, new Vector3(previousRoad.transform.position.x + offset, previousRoad.transform.position.y, previousRoad.transform.position.z), Quaternion.identity);
                        Direction = "Up";
                        barrelcopy = Instantiate(Barrel, new Vector3(copied.transform.position.x - barreloffset, copied.transform.position.y + barreloffset, previousRoad.transform.position.z), Quaternion.identity);
                        barrelnumber++;
                        barrelcopy.name = barrelnumber.ToString();
                        break;
                }
            }
            else if (Direction == "Left")
            {        
                              
                switch (rnd)
                {
                    case 0:
                        copied = Instantiate(Horizontal, new Vector3(previousRoad.transform.position.x - offset, previousRoad.transform.position.y, previousRoad.transform.position.z), Quaternion.identity);
                        Direction = "Left";                       
                        break;
                    case 1:
                        copied = Instantiate(DownRight, new Vector3(previousRoad.transform.position.x - offset, previousRoad.transform.position.y, previousRoad.transform.position.z), Quaternion.identity);
                        Direction = "Up";
                        barrelcopy = Instantiate(Barrel, new Vector3(copied.transform.position.x + barreloffset, copied.transform.position.y + barreloffset, previousRoad.transform.position.z), Quaternion.identity);
                        barrelnumber++;
                        barrelcopy.name = barrelnumber.ToString();
                        break;

                }
            }
            previousRoad = copied;
            if (barrelcopy != null)
            barrelcopy.transform.parent = GameObject.Find("Barrels").transform;

            if (i == 19)            
                FinishLine();
            }    
        
        car.GetComponent<CarMovement>().enabled = true;        
    }

    void Update()
    {        
      

    }
}
