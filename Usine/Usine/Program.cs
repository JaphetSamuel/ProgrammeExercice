// See https://aka.ms/new-console-template for more information

using Usine.Models.Enum;
using Usine.Models;

namespace Usine;

public class Program
{
    public static void Main(String[] args)
    {
        List<Machine> machines = new List<Machine>()
        {
            new MachineTete(),
            new MachineAxe(),
            new MachineJupe()
        };
        MachinePrincipale machinePrincipale = MachinePrincipale.GetInstance(); 
        
        //Mise en marche du process
        while (machinePrincipale.ListProduit.Count <= 5)
        {
            var cartons = Dock.RemplirCartons();
            Dock.Trie(cartons, machines);
            machines.ForEach(m=> m.Usinage());
        }
        
        //bilan
        foreach (Piece piece in machinePrincipale.GetListAttentePiece())
        {
            Console.WriteLine($"{piece.NumeroSerie} : {piece.TypePiece} --> {piece.TempsUsinage}");
        }
        
        Console.WriteLine(machinePrincipale.ListProduit.Count);
        
        Console.WriteLine(machinePrincipale.TempsTotal() + " minutes");

    }
    
}