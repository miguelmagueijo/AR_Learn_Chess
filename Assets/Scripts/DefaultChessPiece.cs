using System.Collections.Generic;
using UnityEngine;

public abstract class DefaultChessPiece : MonoBehaviour {
    [SerializeField]
    public int moveDurationSecs = 2;

    public int x;
    public int y;

    private bool isMoving = false;

    public bool isWhite = false;

    public abstract List<int[]> getPossiblePositions(Board board);

    public bool isEnemy(DefaultChessPiece enemy) {
        return enemy.isWhite != this.isWhite;
    }

    public void moveTo(Vector3 targetPos) {
    
    }
}
