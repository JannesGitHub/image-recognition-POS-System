using DetectionLibrary;
using KassenManagementLibrary;

internal class Program
{
    private static void Main(string[] args)
    {
        List<CLIPVector> Vektoren = new List<CLIPVector>(DummiVektorForLineofGoods());
        getdummi(Vektoren).safe();
    }
}