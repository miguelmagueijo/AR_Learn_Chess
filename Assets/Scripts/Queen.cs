using UnityEngine;
using System.Collections.Generic;

public class Queen : DefaultChessPiece {
    public override List<int[]> getPossiblePositions(Board board) {
        List<int[]> positions = new();

        int leftX = this.x - 1;
        int rightX = this.x + 1;
        for (int i = this.y + 1; i < 8; i++) {
            if (leftX >= 0) {
                if (board.canPieceMoveTo(this, leftX, i)) {
                    positions.Add(new int[] {leftX, i});
                    leftX -= 1;
                }

                if (board.hasPiece(leftX + 1, i))
                    leftX = -1;
            }

            if (rightX < 8) {
                if (board.canPieceMoveTo(this, rightX, i)) {
                    positions.Add(new int[] {rightX, i});
                    rightX += 1;
                }

                if (board.hasPiece(rightX - 1, i))
                    rightX = 8;
            }
        }

        leftX = this.x - 1;
        rightX = this.x + 1;
        for (int i = this.y - 1; i >= 0; i--) {
            if (leftX >= 0) {
                if (board.canPieceMoveTo(this, leftX, i)) {
                    positions.Add(new int[] {leftX, i});
                    leftX -= 1;
                }

                if (board.hasPiece(leftX + 1, i))
                    leftX = -1;
            }

            if (rightX < 8) {
                if (board.canPieceMoveTo(this, rightX, i)) {
                    positions.Add(new int[] {rightX, i});
                    rightX += 1;
                }

                if (board.hasPiece(rightX-1, i))
                    rightX = 8;
            }
        }

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