namespace Usine.Models;

public abstract class Brokable
{
    public abstract double tempsUsinage { get; set; }
    private double tempsReparation {get; set; }

    public virtual bool EstEnPanne()
    {
        int sortie = new Random().Next(1, 5);

        if (sortie == 4)
        {
            return true;
        }
        return  false;
    }
    // public void LogiquePanne();

    public virtual double CalculeTempsReparation()
    {
        return GenererTempsPanne();
    }

    private double GenererTempsPanne()
    {
        if (this.EstEnPanne())
        {
            //TODOD; return double
            this.tempsReparation = new Random().Next(5,11) * new Random().NextDouble();
        }

        return this.tempsReparation;
    }
}