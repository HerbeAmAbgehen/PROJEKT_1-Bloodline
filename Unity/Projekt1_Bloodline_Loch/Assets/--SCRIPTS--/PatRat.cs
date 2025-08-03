using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PatRat : MonoBehaviour
{
    public GameObject Arm;

    public GameObject Player;
    public GameObject PlayerCameraRoot;
    public GameObject PlayerPositionTarget;

    public AnimationClip ArmPat;
    
    private Animator ArmAnimator;

    private MeshRenderer ArmMesh;

    private CharacterController PC;
    
    private float PlayerRotation = 90f;
    private float CameraRootRotation = 20f;

    public bool CanBePatted;
    // Start is called before the first frame update
    void Start()
    {
        ArmAnimator = Arm.GetComponent<Animator>();
        PC = Player.GetComponent<CharacterController>();
        ArmMesh = Arm.GetComponent<MeshRenderer>();

        ArmMesh.enabled = false;

        CanBePatted = true;
    }


    private IEnumerator CatPat()
    {
        CanBePatted=false;
        ArmMesh.enabled = true;;
        ArmAnimator.SetTrigger("Pat");
        yield return new WaitForSeconds(1.5f);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(ArmPat.length - 1.5f);
        ArmAnimator.SetTrigger("Idle");
        ArmMesh.enabled=false;
        PC.gameObject.SetActive(true);
        CanBePatted = true;
        
    }

    private void MovePlayer()
    {
        PC.gameObject.SetActive(false);
        Player.transform.position = PlayerPositionTarget.transform.position;
        Player.transform.localEulerAngles = new Vector3(0, PlayerRotation, 0);
        PlayerCameraRoot.transform.localEulerAngles = new Vector3 (CameraRootRotation,0,0);
        Debug.Log("MovedPlayer");
    }

    public void PlayPat()
    {
        MovePlayer();
        StartCoroutine(CatPat());
    }

}
