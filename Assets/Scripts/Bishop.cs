using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using Unity.VisualScripting;


public class Bishop : DefaultChessPiece {
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

                if (board.hasPiece(rightX-1, i))
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

        return positions;
    }
}