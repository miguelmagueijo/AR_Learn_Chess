using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using Unity.VisualScripting;


public class EnemyPiece : DefaultChessPiece
{
    public override List<int[]> getPossiblePositions(Board board) {
        return null;
    }
}