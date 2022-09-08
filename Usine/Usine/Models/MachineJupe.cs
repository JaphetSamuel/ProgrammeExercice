using Usine.Models.Enum;

namespace Usine.Models;

public class MachineJupe: Machine
{
    public override double tempsUsinage { get; set; }
    public override TypePiece TypePiece { get; set; }
    private const double ConstTempsUsinageJupe = 3;

    public MachineJupe()
    {
        this.tempsUsinage = ConstTempsUsinageJupe;
        this.TypePiece = TypePiece.JUPE;
        this.ListPiecesNonTraitées = new List<Piece>();
    }
}