using System.Collections.Generic;

public static class PieceTypeSharer {
    public enum PieceClasses {
        Bishop,
        King,
        Knight,
        Pawn,
        Queen,
        Rook
    }

    public static Dictionary<PieceClasses, string> pieceName = new() {
        { PieceClasses.Bishop, "Bispo" },
        { PieceClasses.King, "Rei" },
        { PieceClasses.Knight, "Cavalo" },
        { PieceClasses.Pawn, "Peão" },
        { PieceClasses.Queen, "Rainha" },
        { PieceClasses.Rook, "Torre" },
    };

    public static Dictionary<PieceClasses, string> pieceMovementInfo = new() {
        { PieceClasses.Bishop, "Pode-se mover na diagonal. Não troca de cor da casa inicial, ou seja, se começa num quadrado preto, continua sempre no quadrado preto! Não passa por cima de outras peças!" },
        { PieceClasses.King, "Move-se para qualquer casa vizinha, no entanto deve ter atenção, pois, não pode-se mover para uma casa sob ataque de uma peça inimiga!" },
        { PieceClasses.Knight, "Movimento semelhante a um 'L', pode passar 'por cima' de outras peças!" },
        { PieceClasses.Pawn, "Move-se unicamente na vertical em direção ao inimigo. Na primeira jogada pode mover 2 casas, depois apenas 1 casa. Captura unicamente na diagonal em direção ao inimigo. Quando alcança a última casa pode-se promover e ser trocada por outra peça! (Dica: escolha a rainha!)" },
        { PieceClasses.Queen, "Move-se em qualquer direção (horizontal, vertical ou diagonal) e o número de casas que quiser! Não passa por cima de outras peças" },
        { PieceClasses.Rook, "Torre move-se apenas horizontalmente ou verticalmente por qualquer número cases! Não passa por cima de outras peças!" },
    };

    public static PieceClasses savedType = PieceClasses.Queen;

    public static string getObjectiveMessage(PieceClasses activeType, int enemyCount) {
        string msg = "Objetivo: capture os restantes " + enemyCount + " inimigos";
        
        if (activeType == PieceClasses.Pawn) {
            msg += " ou promova para outra peça";
        }

        return msg;
    }
}
