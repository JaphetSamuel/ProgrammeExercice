namespace Usine.Models;

public class Carton
{
    public List<Piece> Contenu { get; set; }

    public Carton()
    {
        this.Contenu = new List<Piece>();
    }

    public void AfficheContenu()
    {
        foreach (Piece piece in Contenu)
        {
            Console.WriteLine(piece.TypePiece);
        }
    }
}