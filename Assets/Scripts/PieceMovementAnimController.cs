using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PieceMovementAnimController : MonoBehaviour {
    [SerializeField]
    public GameObject badPlane;
    [SerializeField]
    public GameObject goodPlane;

    [SerializeField]
    public TMP_Text objectiveText;

    [SerializeField]
    public GameObject objectivePanel;

    [SerializeField]
    public GameObject successPanel;

    [SerializeField]
    public GameObject board;

    [SerializeField]
    public int totalEnemyPieces = 3;

    [SerializeField]
    public bool startRandomPos = false;

    [SerializeField]
    public int startRow = 0;
    [SerializeField]
    public int startCol = 0;

    [SerializeField]
    public const int scale = 10;

    private PieceTypeSharer.PieceClasses pieceType;

    private List<GameObject> enemies = new();

    private GameObject pieceObj;

    private DefaultChessPiece pieceScript;

    private List<GameObject> movementPlanes = new();

    private Board boardScript;

    private bool isPlayerWhiteTeam;

    private void updateObjectiveText() {
        if (enemies.Count == 0) {
            this.objectivePanel.SetActive(false);
            this.successPanel.SetActive(true);
            
            return;
        }
        
        this.objectiveText.SetText("Objetivo: capture os restantes " + enemies.Count + " inimigos");

        
    }

    private void putEnemies() {
        while(enemies.Count < totalEnemyPieces) {
            int x = UnityEngine.Random.Range(0, 8);
            int y = UnityEngine.Random.Range(0, 8);

            if (boardScript.hasPiece(x, y))
                continue;

            GameObject enemy = Instantiate(Resources.Load("Pawn" + (isPlayerWhiteTeam ? "Dark" : "Light")) as GameObject);
            enemy.AddComponent<EnemyPiece>();
            enemy.transform.parent = board.transform;
            
            DefaultChessPiece enemyScript = enemy.GetComponent<EnemyPiece>();
            enemyScript.isWhite = !isPlayerWhiteTeam;
            enemyScript.x = x;
            enemyScript.y = y;

            boardScript.putPieceIn(enemyScript, x, y);
            enemy.transform.localPosition = new Vector3(y, 0, x);
            enemy.transform.localRotation = new Quaternion(0, 0, 0, 0);
            enemy.transform.localScale = new Vector3(1, 1, 1);
            enemies.Add(enemy);
        }

        this.updateObjectiveText();
    }

    private void putPiece() {
        string prefabSufix = isPlayerWhiteTeam ? "Light" : "Dark";

        int startX = startRow;
        int startY = startCol;

        if (startRandomPos) {
            while (true) {
                startX = UnityEngine.Random.Range(0, 8);
                startY = UnityEngine.Random.Range(0, 8);

                if (boardScript.hasPiece(startX, startY))
                    continue;
                
                break;
            }
        }

        Vector3 startPos = new Vector3(startY, 0, startX); 

        switch (pieceType) {
            case PieceTypeSharer.PieceClasses.Rook:
                pieceObj = Instantiate(Resources.Load("Rook" + prefabSufix) as GameObject);
                pieceObj.AddComponent<Rook>();
                pieceScript = pieceObj.GetComponent<Rook>();
                break;
            case PieceTypeSharer.PieceClasses.Bishop:
                pieceObj = Instantiate(Resources.Load("Bishop" + prefabSufix) as GameObject);
                pieceObj.AddComponent<Bishop>();
                pieceScript = pieceObj.GetComponent<Bishop>();
                break;
            case PieceTypeSharer.PieceClasses.Knight:
                pieceObj = Instantiate(Resources.Load("Knight" + prefabSufix) as GameObject);
                pieceObj.AddComponent<Knight>();
                pieceScript = pieceObj.GetComponent<Knight>();
                break;
            case PieceTypeSharer.PieceClasses.King:
                pieceObj = Instantiate(Resources.Load("King" + prefabSufix) as GameObject);
                pieceObj.AddComponent<King>();
                pieceScript = pieceObj.GetComponent<King>();
                break;
            case PieceTypeSharer.PieceClasses.Queen:
                pieceObj = Instantiate(Resources.Load("Queen" + prefabSufix) as GameObject);
                pieceObj.AddComponent<Queen>();
                pieceScript = pieceObj.GetComponent<Queen>();
                break;
            case PieceTypeSharer.PieceClasses.Pawn:
                break;
            default:
                throw new Exception("NO OBJECT FOR NEW TYPE");
        }

        pieceScript.isWhite = isPlayerWhiteTeam;
        pieceObj.transform.parent = board.transform;
        pieceObj.transform.localPosition = startPos;
        pieceObj.transform.localRotation = new Quaternion(0, 0, 0, 0);
        pieceObj.transform.localScale = new Vector3(1, 1, 1);
        boardScript.putPieceIn(pieceScript, startX, startY);

        pStartMovePos = pEndMovePos = pieceObj.transform.localPosition;

        this.showMovementPlanes();
    }

    void Start() {
        this.pieceType = PieceTypeSharer.savedType;

        isPlayerWhiteTeam = UnityEngine.Random.value > 0.5;
        this.boardScript = this.board.GetComponent<Board>();

        this.putEnemies();
        this.putPiece();
        
        this.transform.parent.position = new Vector3(-4f * scale, 0, -4f * scale);
        this.transform.parent.localScale = new Vector3(scale, scale, scale);
        this.objectivePanel.SetActive(true);
        this.successPanel.SetActive(false);
    }

    public void showMovementPlanes() {
        foreach (int[] pos in pieceScript.getPossiblePositions(boardScript)) {
            // Debug.Log(pos[0] + ", " + pos[1]);

            GameObject plane = Instantiate(goodPlane);
            plane.transform.parent = board.transform;
            plane.transform.localPosition = new Vector3(pos[1], 0.025f, pos[0]);
            plane.transform.localRotation = new Quaternion(0,0,0,0);
            plane.transform.localScale = new Vector3(0.08f, 0.08f, 0.08f);
            movementPlanes.Add(plane);
            
            MovementPosition planeScript = plane.transform.GetComponent<MovementPosition>();

            planeScript.x = pos[0];
            planeScript.y = pos[1];
            planeScript.setMovementController(this);
        }
    }

    public void removeMovementPlanes() {
        foreach (GameObject plane in movementPlanes) {
            Destroy(plane);
        }
        movementPlanes = new();
    }

    
    float moveTime;
    float timeToReachTarget = 2;
    Vector3 pStartMovePos;
    Vector3 pEndMovePos;
    bool pieceMoving = false;

    // https://discussions.unity.com/t/move-from-one-position-to-another-in-x-seconds/145985
    void Update() {
        if (pieceMoving) {
            moveTime += Time.deltaTime / timeToReachTarget;
            pieceObj.transform.localPosition = Vector3.Lerp(pStartMovePos, pEndMovePos, moveTime);
            
            if (pieceObj.transform.localPosition == pEndMovePos) {
                pieceMoving = false;
                showMovementPlanes();
            }
        }
    }

    public int euclideanDistance(int x1, int x2, int y1, int y2) {
        return (int) Math.Sqrt(Math.Abs(x1 - x2) + Math.Abs(y1 - y2));
    }

    public void startPieceMovement() {
        moveTime = 0;
        pStartMovePos = pieceObj.transform.localPosition;
        pEndMovePos = new Vector3(pieceScript.y, 0, pieceScript.x);
        pieceMoving = true;
        timeToReachTarget = euclideanDistance((int) pStartMovePos.z, pieceScript.x, (int) pStartMovePos.x, pieceScript.y);
        Debug.Log(timeToReachTarget);

        Debug.Log("Piece will be moving to ("+pEndMovePos.x+", "+pEndMovePos.y+", "+pEndMovePos.z+")");
    }
    
    public void movePieceTo(int x, int y) {
        removeMovementPlanes();
        boardScript.removePieceFrom(pieceScript.x, pieceScript.y);

        if (boardScript.hasPiece(x, y)) {
            DefaultChessPiece foundPieceScript = boardScript.getPiece(x,y);
            for (int i = 0; i < enemies.Count; i++) {
                DefaultChessPiece enemyScript = enemies[i].GetComponent<DefaultChessPiece>();
                if (foundPieceScript == enemyScript) {
                    GameObject enemy = enemies[i];
                    Destroy(enemy);
                    enemies.RemoveAt(i);
                    boardScript.removePieceFrom(x, y);
                    break;
                }
            }
            this.updateObjectiveText();
        }

        boardScript.putPieceIn(pieceScript, x, y);
        startPieceMovement();

        Debug.Log("Piece needs to be moved to X: " + x + ", Y:" + y);
    }


    public void restartBoard() {
        if (this.pieceMoving) {
            return;
        }

        this.boardScript.wipePositions();
        removeMovementPlanes();

        for (int i = 0; i < enemies.Count; i++) {
            Destroy(enemies[i]);
        }

        Destroy(pieceObj);
        
        this.enemies = new();
        this.pieceObj = null;
        this.pieceScript = null;

        this.putEnemies();
        this.putPiece();

        this.objectivePanel.SetActive(true);
        this.successPanel.SetActive(false);
    }
}
