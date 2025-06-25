using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedDoor : MonoBehaviour
{
    public GameObject InteractionText;

    public GameObject Door;

    public float slideSpeed;

    public int DoorOpenTime;

    public float OpenXPosition;

    private float ClosedXPosition;

    

    private BoxCollider DoorCollider;

    private bool DoorOpen;

    private bool PlayerCollision;

    private void Start()
    {
        InteractionText.SetActive(false);
        DoorCollider = Door.GetComponent<BoxCollider>();
        DoorOpen = false;
        PlayerCollision = false;
        ClosedXPosition = Door.transform.position.x;

        Debug.Log(Door.transform.position.x);
        Debug.Log(DoorCollider.size.z);
    }

    private void OnTriggerEnter(Collider collider)
    {
        InteractionText.SetActive(true);
        PlayerCollision = true;
    }

    private void OnTriggerExit(Collider other)
    {
        InteractionText.SetActive(false);
        PlayerCollision = false;
    }
    private void Update()
    {
        if (PlayerCollision && Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(DoorTimer());
        }

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

}
