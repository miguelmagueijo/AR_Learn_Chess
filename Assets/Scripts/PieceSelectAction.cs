using UnityEngine;

public class PieceSelectAction : MonoBehaviour {
    

    void Update() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0)) {
            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject) {
                Debug.Log("Button Clicked");
            }
        }


        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) {
            Debug.Log("TAPPING ME");
        }
    }
}
