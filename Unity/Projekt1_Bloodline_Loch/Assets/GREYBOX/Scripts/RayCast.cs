using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast : MonoBehaviour
{
    public float RayLength;
    public LayerMask layerMask;
    public GameObject CatInteraction;

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

                if(!CP.IsScratching && Input.GetKeyDown(KeyCode.E))
                {
                    CP.PlayPat();
                }
            }

        }
        else
        {
            CatInteraction.SetActive(false);
        }

            Debug.DrawRay(transform.position, Vector3.forward);
    }
}
