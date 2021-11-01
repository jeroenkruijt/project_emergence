using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blueprint : MonoBehaviour
{
    public float buildDistance = 3f;
    public enum BuildState {
        Idle,
        Blueprint,
        Building
    };
    BuildState state;
    Camera cam;
    public GameObject blueprintPrefab;
    public GameObject WallPrefab;
    private bool building = false;
    private bool blueprintActive = false;

    private void Start() {
        cam = transform.Find("Main Camera").GetComponent<Camera>();
        state = BuildState.Idle;
    }

    private void Update() {
        /*/build wall in place of blueprint
        if (Input.GetKeyDown(KeyCode.Q) && blueprintActive) {
            Instantiate(WallPrefab, blueprintPrefab.transform.position, transform.rotation);
            building = false;
            blueprintActive = false;
            blueprintPrefab.GetComponent<MeshRenderer>().enabled = blueprintActive;
        } 
        //show blueprint
        if (Input.GetKeyDown(KeyCode.Q) && building == false) {
            building = true;
            RaycastBlueprint();
        }*/
        switch(state) {
            case BuildState.Idle:
                if (Input.GetKeyDown(KeyCode.Q)) { state = BuildState.Blueprint; }
                break;
            case BuildState.Blueprint:
                building = true;
                RaycastBlueprint();
                if (Input.GetKeyDown(KeyCode.Q) && blueprintActive) { state = BuildState.Building; }
                if (Input.GetKeyDown(KeyCode.Escape)) { state = BuildState.Idle; }
                break;
            case BuildState.Building:
                Instantiate(WallPrefab, blueprintPrefab.transform.position, transform.rotation);
                building = false;
                blueprintActive = false;
                blueprintPrefab.GetComponent<MeshRenderer>().enabled = blueprintActive;
                state = BuildState.Idle;
                break;
            default:
                state = BuildState.Idle;
                break;
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
}
