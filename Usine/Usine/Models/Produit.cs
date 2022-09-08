namespace Usine.Models;

public class Produit
{
    public double TempsAssemblage { get; set; }
    public List<Piece> Composants { get; set; }
    
    public double TempsAssemblagePropre { get; set; }

    public Produit(List<Piece> composants)
    {
        this.Composants = composants;
    }
    
    public virtual double GetTempsAssemblage()
    {
        double temps = 0;
        foreach (Piece piece in Composants)
        {
            temps += piece.TempsUsinage;
        }
        return temps;
    }
}