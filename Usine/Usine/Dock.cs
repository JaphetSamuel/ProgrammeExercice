using System.Runtime.CompilerServices;
using Usine.Models;
using Usine.Models.Enum;

namespace Usine;
public static class Dock
{
    public static void Trie(List<Carton> cartons, List<Machine> machines)
    {
        foreach (Carton carton in cartons)
        {
            RepartitionDesPieces(carton, machines);
        }
    }

    private static void RepartitionDesPieces(Carton carton,List<Machine> machines )
    {
        foreach (Piece piece in carton.Contenu)
        {
            machines.ForEach(m => m.AjoutPieceAList(piece));
        }
    }

    public static List<Carton> RemplirCartons(int nombreCartons = 1)
    {
        List<Carton> listCartons = new List<Carton>();
        for (int i = 0; i < nombreCartons; i++)
        {
            listCartons.Add(RemplirUnCarton());
        }
        return listCartons;
    }

    private static Carton RemplirUnCarton()
    {
        Carton carton = new Carton();
        for (int i = 0; i < 3; i++)
        {
            var randomInt = new Random().Next(0, 3);
            if (carton.Contenu != null) carton.Contenu.Add(new Piece((TypePiece)randomInt));
        }

        return carton;
    }
}