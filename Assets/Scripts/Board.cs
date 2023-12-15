using UnityEngine;

public class Board : MonoBehaviour {
    public DefaultChessPiece[,] positions = new DefaultChessPiece[8,8];

    private bool isInsideBoard(int x, int y) {
        return x >= 0 && x <= 7 && y >= 0 && y <= 7;
    }

    public DefaultChessPiece getPiece(int x, int y) {
        return this.positions[x, y];
    }

    public bool hasPiece(int x, int y) {
        return this.getPiece(x, y) != null;
    }

    public void removePieceFrom(int x, int y) {
        this.positions[x, y] = null;
    }

    public bool canPieceMoveTo(DefaultChessPiece piece, int x, int y) {
        if (!isInsideBoard(x, y))
            return false;
        
        DefaultChessPiece posPiece = this.positions[x, y];
        
        if (posPiece == null)
            return true;

        return piece.isEnemy(posPiece);
    }

    public void putPieceIn(DefaultChessPiece piece, int x, int y) {
        positions[x,y] = piece;
        piece.x = x;
        piece.y = y;
    }

    public void wipePositions() {
        positions = new DefaultChessPiece[8,8];
    }
}