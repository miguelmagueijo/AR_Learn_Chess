public static class PieceTypeSharer {
    public enum PieceClasses {
        Bishop,
        King,
        Knight,
        Pawn,
        Queen,
        Rook
    }

    public static PieceClasses savedType = PieceClasses.Queen;

    public static string getObjectiveMessage(PieceClasses activeType, int enemyCount) {
        string msg = "Objetivo: capture os restantes " + enemyCount + " inimigos";
        
        if (activeType == PieceClasses.Pawn) {
            msg += " ou promova para outra peça";
        }

        return msg;
    }
}
