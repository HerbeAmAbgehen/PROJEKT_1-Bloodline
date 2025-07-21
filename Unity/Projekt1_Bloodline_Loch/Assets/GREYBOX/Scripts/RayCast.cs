using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour
{
    public float RayLength;
    public LayerMask layerMask;
    public GameObject CatInteraction;
    public GameObject SceneInteraction;
    public GameObject BrickInteraction;
    public GameObject BookInteraction;

    private Camera MainCamera;

    // Start is called before the first frame update
    void Start()
    {
        MainCamera = Camera.main;
        CatInteraction.SetActive(false);
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
                CatInteraction.SetActive(true);
                PatCat CP = hit.collider.gameObject.GetComponent<PatCat>();

                if(CP.CanBePatted && Input.GetKeyDown(KeyCode.E))
                {
                    CP.PlayPat();
                }
            }
            if (hit.collider.tag == "SceneChange")
            {
                SceneChange SC = hit.collider.gameObject.GetComponent<SceneChange>();
                SceneInteraction.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    SC.ChangeScene();
                }
            }
            if(hit.collider.tag == "Brick")
            {
                BrokenWall BW = hit.collider.gameObject.GetComponent<BrokenWall>();
                BrickInteraction.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    BW.WallBreak();
                }
            }
            if(hit.collider.tag == "Book")
            {
                TimedDoor TD = hit.collider.gameObject.GetComponent<TimedDoor>();
                BookInteraction.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    TD.OpenDoor();
                }
            }
        }
        
        else
        {
            CatInteraction.SetActive(false);
            SceneInteraction.SetActive(false);
            BrickInteraction.SetActive(false);
            BookInteraction.SetActive(false);
        }

            Debug.DrawRay(transform.position, Vector3.forward);
    }
}
