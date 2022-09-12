namespace Usine.Models;

public class Piston : Produit
{
    public Piece[] Composant;
    public double TempsAssemblagePropre { get; set; }

    public Piston(Piece[] pieces): base(pieces.ToList())
    {
        this.Composant = pieces;
    }
    public override double GetTempsAssemblage()
    {
        Console.WriteLine("Ajout du temps d'assemblage propre");
        return base.GetTempsAssemblage() + TempsAssemblagePropre;
    }
}