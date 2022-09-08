namespace Usine.Models;


/// <summary>
/// Respoonsabilité : 
/// </summary>
public interface IUsine
{
    void Usinage();
    void CollectePiece(Piece piece);
}