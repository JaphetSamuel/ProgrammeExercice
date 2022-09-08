using Usine.Models.Enum;

namespace Usine.Models;

// public class Machine<T> where T: Piece

public abstract class Machine: Brokable, IUsine
{
    
    public List<Piece> ListPiecesNonTraitées { get; set; }

    public abstract TypePiece TypePiece { get; set; }

    public bool AjoutPieceAList(Piece piece)
    {
        //perte performance
        if (piece.TypePiece != this.TypePiece)
        {
            return false;
        }
        this.ListPiecesNonTraitées.Add(piece);
        return true;
    }

    public void Usinage()
    {
        foreach (Piece piece in ListPiecesNonTraitées)
        {
            //Todo : checker les types
            double tempsEcoule = 0;
            if (EstEnPanne())
            {
                tempsEcoule += this.CalculeTempsReparation();
            }

            tempsEcoule += tempsUsinage;

            piece.TempsUsinage = tempsEcoule;
            
            CollectePiece(piece);
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