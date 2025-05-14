using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using UnityEngine;

public class SlowTrap : MonoBehaviour
{
    public float speedMult;
    
    public float StunTime;

    public float ArmsSpeed;

    public GameObject TrapArms;

    private GameObject playerGO;

    private BoxCollider ArmsCollider;
    
    private FirstPersonController playerFPC;

    private float defaultMoveSpeed;

    private float defaultSprintSpeed;

    private bool PlayerCollision = false;

    private bool ArmsWait = false;

    private float ArmsRestPositionX;
  
    // Start is called before the first frame update
    void Start()
    {
        playerGO = GameObject.Find("Player");

        playerFPC = playerGO.GetComponent<FirstPersonController>();

        ArmsCollider = TrapArms.GetComponent<BoxCollider>();

        defaultMoveSpeed = playerFPC.MoveSpeed;

        defaultSprintSpeed = playerFPC.SprintSpeed;

        ArmsRestPositionX = TrapArms.transform.position.x;

        TrapArms.SetActive(false);
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider collider)
    {

        StartCoroutine(StunTimer());
        PlayerCollision = true;
        ArmsWait = true;
    }

    private void OnTriggerExit(Collider collider)
    {
        playerFPC.MoveSpeed = defaultMoveSpeed;

        playerFPC.SprintSpeed = defaultSprintSpeed;

        PlayerCollision = false;

        TrapArms.SetActive(false);
    }

    private void Update()
    {
        if (ArmsWait && (TrapArms.transform.position.x < ArmsRestPositionX + ArmsCollider.size.y))
        {
            
            TrapArms.transform.Translate(Vector3.down * Time.deltaTime * ArmsSpeed);
        }
        else if (!ArmsWait && TrapArms.transform.position.x > ArmsRestPositionX)
        {
            TrapArms.transform.Translate(Vector3.down * Time.deltaTime * -0.01f* ArmsSpeed);
        }
        else if (TrapArms.transform.position.x == ArmsRestPositionX-0.1f)
        {
            TrapArms.SetActive(false);
        }
        

        
    }
    private IEnumerator StunTimer()
    {
        playerFPC.MoveSpeed = 0;
        playerFPC.SprintSpeed = 0;
        
        TrapArms.SetActive(true);
        yield return new WaitForSeconds(StunTime);
        ArmsWait = false;
        playerFPC.MoveSpeed = defaultMoveSpeed * speedMult;
        playerFPC.SprintSpeed = defaultSprintSpeed * speedMult;
    }




}
