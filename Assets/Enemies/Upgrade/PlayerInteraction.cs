using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{

    public float interactionDistance;

    public TMPro.TextMeshProUGUI interactionText;
    Camera cam;

    private void Start() {
        cam = transform.Find("Main Camera").GetComponent<Camera>();
    }

    private void Update() {
        Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width * .5f, Screen.height * .5f, 0f));
        RaycastHit hit;

        bool successfulHit = false;

        if (Physics.Raycast(ray, out hit, interactionDistance)) {
            Interactable interactable = hit.collider.GetComponent<Interactable>();
        
            if (interactable != null) {
                HandleInteraction(interactable);
                interactionText.text = interactable.GetDescription();
                successfulHit = true;
            }
        }

        if (!successfulHit) interactionText.text = "AAA";
    }
    void HandleInteraction(Interactable interactable) {
        KeyCode key = KeyCode.E;
        switch (interactable.interactionType) {
            case Interactable.InteractionType.Click:
                if (Input.GetKeyDown(key)) {
                    interactable.Interact();
                }
                break;
            case Interactable.InteractionType.Hold:
                if (Input.GetKey(key)) {
                    interactable.Interact();
                }
                break;
            default: throw new System.Exception("Unsupported type of interactable");
        }
    }
}
