using System;
namespace RPG
{
    internal class Places
    {
        public string name;
        public string cas;

        public void PlaceDialog(string name, string cas)
        {
            Console.WriteLine("");
            Console.WriteLine($"《Poloha》{name},《čas》{cas}");
        }
    }
}