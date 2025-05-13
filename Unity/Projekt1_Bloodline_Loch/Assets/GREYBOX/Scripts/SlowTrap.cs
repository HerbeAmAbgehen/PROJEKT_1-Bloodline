using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using UnityEngine;

public class SlowTrap : MonoBehaviour
{
    public float speedMult;
    
    public float StunTime;

    private GameObject playerGO;
    
    private FirstPersonController playerFPC;

    private float defaultMoveSpeed;

    private float defaultSprintSpeed;

    // Start is called before the first frame update
    void Start()
    {
        playerGO = GameObject.Find("Player");

        playerFPC = playerGO.GetComponent<FirstPersonController>();

        defaultMoveSpeed = playerFPC.MoveSpeed;

        defaultSprintSpeed = playerFPC.SprintSpeed;
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider collider)
    {

        StartCoroutine(StunTimer());
        
    }

    private void OnTriggerExit(Collider collider)
    {
        playerFPC.MoveSpeed = defaultMoveSpeed;

        playerFPC.SprintSpeed = defaultSprintSpeed;
    }

    private IEnumerator StunTimer()
    {
        playerFPC.MoveSpeed = 0;
        playerFPC.SprintSpeed = 0;

        yield return new WaitForSeconds(StunTime);
        
        playerFPC.MoveSpeed = defaultMoveSpeed * speedMult;
        playerFPC.SprintSpeed = defaultSprintSpeed * speedMult;
    }



}
