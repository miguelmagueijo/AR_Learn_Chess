using System.Collections.Generic;

public class Pawn : DefaultChessPiece {
    public override List<int[]> getPossiblePositions(Board board) {
        List<int[]> positions = new();

        int nextX = this.isWhite ? this.x + 1 : this.x - 1;

        if (board.canPieceMoveTo(this, nextX, y) && !board.hasPiece(nextX, this.y)) {
            positions.Add(new int[] { nextX, y });

            if (!this.hasMoved && !board.hasPiece(this.isWhite ? nextX + 1 : nextX - 1, this.y)) {
                positions.Add(new int[] { this.isWhite ? nextX + 1 : nextX - 1, this.y });
            }
        }

        int[][] possibleCapturePos = {
            new int[] {nextX, this.y + 1},
            new int[] {nextX, this.y - 1}
        };

        foreach (int[] pos in possibleCapturePos) {
            if (board.canPieceMoveTo(this, pos[0], pos[1]) && board.hasEnemy(this, pos[0], pos[1])) {
                positions.Add(new int[] {pos[0], pos[1]});
            } 
        }

        return positions;
    }

    public override bool canBePromoted() {
        int endX = this.isWhite ? 7 : 0;
        return endX == this.x;
    }
}