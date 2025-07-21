using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedDoor : MonoBehaviour
{

    public GameObject Door;

    public float slideSpeed;

    public int DoorOpenTime;

    public float OpenXPosition;

    private float ClosedXPosition;

    

    private BoxCollider DoorCollider;

    private bool DoorOpen;


    private void Start()
    {
        DoorCollider = Door.GetComponent<BoxCollider>();
        DoorOpen = false;
        ClosedXPosition = Door.transform.position.x;

        Debug.Log(Door.transform.position.x);
        Debug.Log(DoorCollider.size.z);
    }

    private void Update()
    {


        if (DoorOpen && Door.transform.position.x > OpenXPosition)
        {
            Door.transform.Translate(Vector3.forward * Time.deltaTime * slideSpeed);
        }
        else if (!DoorOpen && Door.transform.position.x < ClosedXPosition)
        {
            Door.transform.Translate(Vector3.forward * Time.deltaTime * -slideSpeed);
        }
    }

    IEnumerator DoorTimer()
    {
        DoorOpen = true;
        yield return new WaitForSeconds(DoorOpenTime);
        DoorOpen = false;
    }

    public void OpenDoor()
    {
        StartCoroutine(DoorTimer());
    }

}
