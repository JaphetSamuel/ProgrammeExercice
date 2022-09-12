using Usine.Models.Enum;

namespace Usine.Models;
public abstract class Machine: Brokable
{
    
    public List<Piece> ListPiecesNonTraitées { get; set; }

    public abstract TypePiece TypePiece { get; set; }
    

    public void AjouterPieceAList(Piece piece)
    {
        //perte performance
        if (piece.TypePiece == this.TypePiece)
        {
            this.ListPiecesNonTraitées.Add(piece);
        }
        
    }

    public void Usinage()
    {
        foreach (Piece piece in ListPiecesNonTraitées)
        {
            VerifierType(piece.TypePiece);
            
            piece.TempsUsinage += tempsUsinage + TempsSiEstEnPanne();
            
            CollectePiece(piece);
        }
    }

    private double TempsSiEstEnPanne()
    {
        if (EstEnPanne())
        {
            return this.CalculeTempsReparation();
        }

        return 0;
    }

    private void VerifierType(TypePiece typePiece)
    {
        if (typePiece != this.TypePiece)
        {
            throw new Exception("Erreur : type de piece non pris en charge par cette machine");
        }
    }

    //Ajout des pieces traitées 
    public void CollectePiece(Piece piece)
    {
        MachinePrincipale.GetInstance().AjouteAMachinePrincipale(piece);
    }
    
    public void AfficheListPiece()
    {
        foreach (Piece piece in ListPiecesNonTraitées)
        {
            Console.WriteLine("machine usinage" +this.TypePiece+ " :"+piece.TypePiece);
        }
        Console.WriteLine("_____________");
    }
    
}