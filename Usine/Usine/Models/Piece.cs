using Usine.Models.Enum;

namespace Usine.Models;

public class Piece
{
    public readonly Guid NumeroSerie;
    public double TempsUsinage { get; set; }
    public TypePiece TypePiece { get; set; }

    public Piece(TypePiece typePiece)
    {
        this.TypePiece = typePiece;
        this.NumeroSerie = Guid.NewGuid();
    }
}