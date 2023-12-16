using System.Collections.Generic;


public class Knight : DefaultChessPiece {
    public override List<int[]> getPossiblePositions(Board board) {
        List<int[]> positions = new();

        int[][] possiblePos = new int[][]{
            new int[] {this.x + 2, this.y - 1},
            new int[] {this.x + 2, this.y + 1},
            new int[] {this.x - 2, this.y + 1},
            new int[] {this.x - 2, this.y - 1},
            new int[] {this.x + 1, this.y - 2},
            new int[] {this.x + 1, this.y + 2},
            new int[] {this.x - 1, this.y + 2},
            new int[] {this.x - 1, this.y - 2},
        };

        foreach (int[] pos in possiblePos) {
            if (board.canPieceMoveTo(this, pos[0], pos[1])) {
                positions.Add(new int[] {pos[0], pos[1]});
            } 
        }

        return positions;
    }
}