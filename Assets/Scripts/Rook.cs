using System.Collections.Generic;


public class Rook : DefaultChessPiece {
    public override List<int[]> getPossiblePositions(Board board) {
        List<int[]> positions = new();

        for (int i = this.x + 1; i < 8; i++) {
            if (board.canPieceMoveTo(this, i, this.y))
                positions.Add(new int[] {i, this.y});

            if (board.hasPiece(i, this.y))
                break;
        }

        for (int i = this.x - 1; i >= 0; i--) {
            if (board.canPieceMoveTo(this, i, this.y))
                positions.Add(new int[] {i, this.y});

            if (board.hasPiece(i, this.y))
                break;
        }

        for (int i = this.y + 1; i < 8; i++) {
            if (board.canPieceMoveTo(this, this.x, i))
                positions.Add(new int[] {this.x, i});

            if (board.hasPiece(this.x, i))
                break;
        }

        for (int i = this.y - 1; i >= 0; i--) {
            if (board.canPieceMoveTo(this, this.x, i))
                positions.Add(new int[] {this.x, i});

            if (board.hasPiece(this.x, i))
                break;
        }

        return positions;
    }
}