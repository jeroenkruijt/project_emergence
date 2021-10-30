using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blueprint_script : MonoBehaviour
{
    RaycastHit hit;
    Vector3 movePoint;
    public GameObject prefab;
    private bool building = false;

    private void Start() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 50000.0f, (1 << 8))) {
            transform.position = hit.point;
        }
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.G) || building == true) {
            building = true;
            ShowBlueprint();
        }

        if (Input.GetKeyDown(KeyCode.Escape)) building = false;
    }

    private void ShowBlueprint() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 50000.0f, (1 << 8))) {
            transform.position = hit.point;
        }

        if (Input.GetKeyDown(KeyCode.G)) {
            Instantiate(prefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
