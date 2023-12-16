using System.Collections.Generic;
using UnityEngine;

public abstract class DefaultChessPiece : MonoBehaviour {
    [SerializeField]
    public int moveDurationSecs = 2;

    public int x;
    public int y;

    public bool hasMoved = false;

    public bool isWhite = false;

    public abstract List<int[]> getPossiblePositions(Board board);

    public bool isEnemy(DefaultChessPiece enemy) {
        return enemy.isWhite != this.isWhite;
    }

    public bool isIn(int x, int y) {
        return this.x == x && this.y == y;
    }

    public virtual bool canBePromoted() {
        return false;
    }
}
