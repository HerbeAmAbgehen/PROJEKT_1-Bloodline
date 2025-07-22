using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PatCat : MonoBehaviour
{
    public GameObject Arm;

    public GameObject Player;
    public GameObject PlayerCameraRoot;
    public GameObject PlayerPositionTarget;

    public AnimationClip Pat;
    public AnimationClip Scratch;
    public AnimationClip Look;
    public AnimationClip ArmPat;
    
    private Animator Animator;
    private Animator ArmAnimator;

    private MeshRenderer ArmMesh;

    private CharacterController PC;
    
    private float PlayerRotation = 268.5f;
    private float CameraRootRotation = 30f;

    public bool CanBePatted;
    // Start is called before the first frame update
    void Start()
    {
        Animator = GetComponent<Animator>();
        ArmAnimator = Arm.GetComponent<Animator>();
        PC = Player.GetComponent<CharacterController>();
        ArmMesh = Arm.GetComponent<MeshRenderer>();

        ArmMesh.enabled = false;
        InvokeRepeating("PlayScratch", 15, 25);

        CanBePatted = true;
    }

    private void PlayScratch()
    {
        StartCoroutine(CatScratch());
        Debug.Log("Trigger: Scratch");
    }

    private IEnumerator CatPat()
    {
        
        CanBePatted=false;
        ArmMesh.enabled = true;
        Animator.SetTrigger("Pat");
        ArmAnimator.SetTrigger("Pat");
        yield return new WaitForSeconds(ArmPat.length);
        ArmAnimator.SetTrigger("Idle");
        ArmMesh.enabled=false;
        yield return new WaitForSeconds(Pat.length - ArmPat.length);
        Animator.SetTrigger("Idle");
        PC.gameObject.SetActive(true);
        CanBePatted = true;
    }

    private IEnumerator CatScratch()
    {
        CanBePatted = false;
        Animator.SetTrigger("Scratch");
        yield return new WaitForSeconds(Scratch.length);
        Animator.SetTrigger("Idle");
        yield return new WaitForSeconds(2);
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
