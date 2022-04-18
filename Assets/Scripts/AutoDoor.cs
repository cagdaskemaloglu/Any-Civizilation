using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDoor : MonoBehaviour
{
    public bool openDoor;

    [SerializeField] private float speed=2f;
    //---DoorVariables---
    private GameObject door1,door2,lamb;
    private Vector3 startPos1;
    private Vector3 startPos2;
    [SerializeField]private Vector3 endPos1 = new Vector3(.108f,.01f,-.87f);
    [SerializeField]private Vector3 endPos2 = new Vector3(.108f,.01f,.87f);
    //---EndDoorVariables---


    // Start is called before the first frame update
    void Start()
    {
        door1=gameObject.transform.GetChild(0).gameObject;
        door2=gameObject.transform.GetChild(1).gameObject;
        lamb=gameObject.transform.GetChild(2).gameObject;
        startPos1 = door1.transform.localPosition;
        startPos2 = door2.transform.localPosition;
        

    }

    // Update is called once per frame
    void Update()
    {
        OpenDoor(endPos1,endPos2);
    }

     private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player"){
            openDoor=true;
        }
    }
    private void OnTriggerStay(Collider other) {

         if(other.tag=="Player"){
            openDoor=true;
        }
        
    }

    private void OnTriggerExit(Collider other) {
         if(other.tag=="Player"){
            openDoor=false;
        }
    }


       void OpenDoor(Vector3 goalPos1,Vector3 goalPos2){
        if(openDoor){
            door1.transform.localPosition = Vector3.Lerp(door1.transform.localPosition,goalPos1,speed*Time.deltaTime);
            door2.transform.localPosition = Vector3.Lerp(door2.transform.localPosition,goalPos2,speed*Time.deltaTime);
            lamb.SetActive(true);
        }
        else{
            door1.transform.localPosition = Vector3.Lerp(door1.transform.localPosition,startPos1,speed*Time.deltaTime);
            door2.transform.localPosition = Vector3.Lerp(door2.transform.localPosition,startPos2,speed*Time.deltaTime);
            lamb.SetActive(false);
        }
    }


    
}
