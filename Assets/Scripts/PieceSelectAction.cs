using UnityEngine;
using UnityEngine.SceneManagement;

public class PieceSelectAction : MonoBehaviour {
    [SerializeField]
    public PieceTypeSharer.PieceClasses pType;

    void Update() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0)) {
            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject) {
                PieceTypeSharer.savedType = pType;
                Debug.Log("Changed piece save type to " + pType);
                SceneManager.LoadScene("MovePiece");
                return;
            }
        }
    }
}
