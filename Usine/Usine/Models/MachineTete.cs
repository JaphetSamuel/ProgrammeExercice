using Usine.Models.Enum;

namespace Usine.Models;

public class MachineTete: Machine
{
    private const double ConstTempsUsinageTete = 2;
    public override TypePiece TypePiece { get; set; }
    public override double tempsUsinage { get; set; }

    public MachineTete()
    {
        this.tempsUsinage = ConstTempsUsinageTete;
        this.TypePiece = TypePiece.TETE;
        this.ListPiecesNonTraitées = new List<Piece>();
    }

    
}