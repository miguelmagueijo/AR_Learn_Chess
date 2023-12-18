using UnityEngine;

public class MovementPosition : MonoBehaviour
{
    [SerializeField]
    public bool goodMove = true;

    public int x = 0;
    public int y = 0;

    public PieceMovementAnimController controller;

    void Update() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0)) {
            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject) {
                if (goodMove)
                    this.controller.movePieceTo(x, y);
            }
        }
    }

    public void setMovementController(PieceMovementAnimController reference) {
        this.controller = reference;
    }
}
