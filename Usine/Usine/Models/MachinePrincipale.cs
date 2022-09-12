using Usine.Models.Enum;

namespace Usine.Models;
/// <summary>
/// Responsabilité:
///  - Verifier si les pieces sont au complet pour un assemblage
///  - Assemble les piece pour fabriquer un produit
/// </summary>
public class MachinePrincipale: Brokable
{
    public sealed override double tempsUsinage { get; set; }
    private const double TempsTraitement = 1;
    public List<Produit> ListProduit { get; set; }
    private List<Piece> _listAttentePiece = new List<Piece>();

    private static MachinePrincipale? _instance = null;

    private MachinePrincipale()
    {
        this.tempsUsinage = TempsTraitement;
        ListProduit = new List<Produit>();
    }
    //Pour le gain de performance
    public static MachinePrincipale GetInstance()
    {
        if (_instance is null)
        {
            _instance = new MachinePrincipale();
        }

        return _instance;
    }

    // Verifie si la composition de la liste d'attente permet l'assemblage d'un produit
    private bool PieceAuComplet()
    {
        return (
            _listAttentePiece.Exists(p => p.TypePiece == TypePiece.JUPE)
            & _listAttentePiece.Exists(p => p.TypePiece == TypePiece.AXE)
            & _listAttentePiece.Exists(p => p.TypePiece == TypePiece.TETE)
        );
    }

    public void AjouteAMachinePrincipale(Piece piece)
    {
        _listAttentePiece.Add(piece);
        VerificationDeLaPossibilitéDassemblage();
    }

    //Lance la fonction d'assemblage apres Verification
    // A lancer depuis l'exterieur
    public void VerificationDeLaPossibilitéDassemblage()
    {
        if (PieceAuComplet())
        {
            AssembleProduit();
        }
    }

    private void AssembleProduit()
    {
        Piece tete = _listAttentePiece.Find(p => p.TypePiece == TypePiece.TETE)!;
        Piece axe = _listAttentePiece.Find(p => p.TypePiece == TypePiece.AXE)!;
        Piece jupe = _listAttentePiece.Find(p => p.TypePiece == TypePiece.JUPE)!;

        Produit produit = new Produit(new List<Piece>(){tete,axe, jupe});
        
        if (EstEnPanne())
        {
            produit.TempsAssemblagePropre = this.tempsUsinage + this.CalculeTempsReparation();
        }

        produit.TempsAssemblagePropre = this.tempsUsinage;
        
        ListProduit.Add(produit);
        
        PurificationListAttente(tete, axe, jupe);
    }
 
    // Retire les elements déjà utilisés pour le montage
    private void PurificationListAttente(Piece tete, Piece axe, Piece jupe)
    {
        _listAttentePiece.Remove(tete);
        _listAttentePiece.Remove(axe);
        _listAttentePiece.Remove(jupe);
    }

    public double TempsTotal()
    {
        double tempsTotal = 0;
        
        foreach (Produit produit in ListProduit)
        {
            tempsTotal += produit.TempsAssemblagePropre;
        }
        return tempsTotal;
    }

    public List<Piece> GetListAttentePiece()
    {
        return this._listAttentePiece;
    }
}