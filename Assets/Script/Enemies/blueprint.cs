using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blueprint : MonoBehaviour
{
    public float buildDistance = 3f;

    Camera cam;
    public GameObject blueprintPrefab;
    public GameObject WallPrefab;
    private bool building = false;
    private bool blueprintActive = false;

    private void Start() {
        cam = transform.Find("Main Camera").GetComponent<Camera>();
    }

    private void Update() {

        if (Input.GetKeyDown(KeyCode.G) || Input.GetMouseButtonDown(0) && blueprintActive) {
            Instantiate(WallPrefab, blueprintPrefab.transform.position, transform.rotation);
            building = false;
            blueprintActive = false;
            blueprintPrefab.GetComponent<MeshRenderer>().enabled = blueprintActive;
        } 
        if (Input.GetKeyDown(KeyCode.G) || building == true) {
            building = true;
            RaycastBlueprint();
        }



        if (Input.GetKeyDown(KeyCode.Escape)) building = false;
    }

    private void RaycastBlueprint() {
        Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width * .5f, Screen.height * .5f, 0f));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 5000.0f)) {
            if (hit.distance < buildDistance) {
                blueprintPrefab.transform.position = hit.point;
                blueprintPrefab.transform.rotation = transform.rotation;
                blueprintActive = true;
                Debug.Log(buildDistance);
            } else {
                blueprintActive = false;
            }
        }
        //Set mesh renderer visible if blueprint is active and in build range
        blueprintPrefab.GetComponent<MeshRenderer>().enabled = blueprintActive;
    }
    /*
    private void ShowBlueprint() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 50000.0f, (1 << 8))) {
            transform.position = hit.point;
        }

        if (Input.GetKeyDown(KeyCode.G)) {
            Instantiate(prefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }*/
}
