using Usine.Models.Enum;

namespace Usine.Models;

public class MachineAxe: Machine
{
    public override double tempsUsinage { get; set; }
    public override TypePiece TypePiece { get; set; }

    private const double ContTempsUsinageAxe = 2.5;

    public MachineAxe()
    {
        this.tempsUsinage = ContTempsUsinageAxe;
        this.TypePiece = TypePiece.AXE;
        this.ListPiecesNonTraitées = new List<Piece>();
    }
}