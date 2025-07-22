using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour
{
    public float RayLength;
    public LayerMask layerMask;
    public GameObject HandIcon;
    public GameObject SceneIcon;
    public GameObject EyeIcon;

    private Camera MainCamera;

    // Start is called before the first frame update
    void Start()
    {
        MainCamera = Camera.main;
        HandIcon.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Raycast();
    }

    private void Raycast()
    {
        Ray ray = MainCamera.ViewportPointToRay(new Vector3 (0.5f, 0.5f, 0));

        if (Physics.Raycast(ray, out RaycastHit hit, RayLength, layerMask))
        {
            

            if (hit.collider.tag == "Cat")
            {
                
                PatCat CP = hit.collider.gameObject.GetComponent<PatCat>();

                if (CP.CanBePatted)
                {
                    HandIcon.SetActive(true);
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        CP.PlayPat();
                        HandIcon.SetActive(false);
                    }
                }

            }
            if (hit.collider.tag == "SceneChange")
            {
                SceneChange SC = hit.collider.gameObject.GetComponent<SceneChange>();
                SceneIcon.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    SC.ChangeScene();
                    SceneIcon.SetActive(false);
                }
            }
            if(hit.collider.tag == "Brick")
            {
                BrokenWall BW = hit.collider.gameObject.GetComponent<BrokenWall>();
                HandIcon.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    BW.WallBreak();
                    HandIcon.SetActive(false);
                }
            }
            if(hit.collider.tag == "Book")
            {
                TimedDoor TD = hit.collider.gameObject.GetComponent<TimedDoor>();
                HandIcon.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    TD.OpenDoor();
                    HandIcon.SetActive(false);
                }
            }
            if(hit.collider.tag == "Secret")
            {
                SecretItem SI = hit.collider.gameObject.GetComponent<SecretItem>();
                CharacterController PC = GetComponent<CharacterController>();
                EyeIcon.SetActive(true);
                if(Input.GetKeyDown(KeyCode.E))
                {
                    SI.ShowText();
                    EyeIcon.SetActive(false);
                }
            }
            /*if(hit.collider.tag == "ScareCat")
            {
                CatScare CS = hit.collider.gameObject.GetComponent<CatScare>();
                CatInteraction.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    CS.scare = true;
                }
            }*/
        }
        
        else
        {
            HandIcon.SetActive(false);
            SceneIcon.SetActive(false);
            EyeIcon.SetActive(false);
        }

            Debug.DrawRay(transform.position, Vector3.forward);
    }
}
