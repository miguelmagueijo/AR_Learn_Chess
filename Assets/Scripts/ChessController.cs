using UnityEngine;

public class ChessController : MonoBehaviour {
    [SerializeField]
    public GameObject board;

    [SerializeField]
    public GameObject whitePawn;
    [SerializeField]
    public GameObject whiteRook;
    [SerializeField]
    public GameObject whiteKnight;
    [SerializeField]
    public GameObject whiteBishop;
    [SerializeField]
    public GameObject whiteQueen;
    [SerializeField]
    public GameObject whiteKing;

    [SerializeField]
    public GameObject blackPawn;
    [SerializeField]
    public GameObject blackRook;
    [SerializeField]
    public GameObject blackKnight;
    [SerializeField]
    public GameObject blackBishop;
    [SerializeField]
    public GameObject blackQueen;
    [SerializeField]
    public GameObject blackKing;

    [SerializeField]
    public int scale = 5;
    
    private GameObject chessBoard;

    private Vector3[,] boardPositions = new Vector3[8,8];
    private GameObject[,] occupiedPositions = new GameObject[8,8];

    private void Awake() {
        for (int i = 0; i < 8; i++) {
            for (int j = 0; j < 8; j++) {
                boardPositions[i, j] = new Vector3(j, 1, i);
                occupiedPositions[i, j] = null;
            }
        }

        GameObject[,] initialLayout = {
            { whiteRook, whiteKnight, whiteBishop, whiteQueen, whiteKing, whiteBishop, whiteKnight, whiteRook },
            { whitePawn, whitePawn, whitePawn, whitePawn, whitePawn, whitePawn, whitePawn, whitePawn },
            { null, null, null, null, null, null, null, null },
            { null, null, null, null, null, null, null, null },
            { null, null, null, null, null, null, null, null },
            { null, null, null, null, null, null, null, null },
            { blackPawn, blackPawn, blackPawn, blackPawn, blackPawn, blackPawn, blackPawn, blackPawn },
            { blackRook, blackKnight, blackBishop, blackQueen, blackKing, blackBishop, blackKnight, blackRook }
        };

        chessBoard = Instantiate(board, new Vector3(0, 1, 0), Quaternion.identity);
        chessBoard.transform.parent = gameObject.transform;

        for (int i = 0; i < 8; i++) {
            for (int j = 0; j < 8; j++) {
                if (initialLayout[i,j] == null) {
                    continue;
                }

                GameObject pieceObj = Instantiate(initialLayout[i,j], boardPositions[i,j], Quaternion.identity);
                occupiedPositions[i, j] = pieceObj;
                occupiedPositions[i, j].transform.parent = chessBoard.transform;

                if (i == 7) {
                    pieceObj.transform.localRotation = new Quaternion(0, 180, 0, 0);
                }
            }
        }

        gameObject.transform.position = new Vector3(-4f * scale, 0, -4f * scale);
        gameObject.transform.localScale += new Vector3(scale, scale, scale);
    }
}
