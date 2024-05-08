namespace adonet_db_videogame
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string scelta = "";
            while (scelta != "5")
            {
                Console.WriteLine("Seleziona l'azione:");
                Console.WriteLine("1. Inserisci un videogame");
                Console.WriteLine("2. Visualizza tramite ID");
                Console.WriteLine("3. Visualizza tramite nome");
                Console.WriteLine("4. Elimina un videogame");
                Console.WriteLine("5. Esci");

                scelta = Console.ReadLine();

                if (scelta == "1")
                {
                    Console.WriteLine("Inserisci i dettagli del videogioco:");


                    Console.Write("Nome: ");
                    string name = Console.ReadLine();

                    Console.Write("Descrizione: ");
                    string overview = Console.ReadLine();

                    Console.Write("Data di rilascio (YYYY-MM-DD): ");
                    DateTime release_date = DateTime.Parse(Console.ReadLine());

                    Console.Write("Associa una Software House (ID): ");
                    int software_house_id = int.Parse(Console.ReadLine());

                    DateTime now = DateTime.Now;

                    VideogiocoManager.InserisciVideogame(1, name, overview, release_date, now, now, software_house_id);

                    Console.WriteLine("Gioco aggiunto con successo!");
                }
                else if (scelta == "2")
                {
                    Console.WriteLine("Inserisci un numero Id:");
                    int id = int.Parse(Console.ReadLine());

                    VideogiocoManager.GetVideogiocoById(id);
                }
                else if (scelta == "3")
                {
                    Console.WriteLine("Inserisci un nome:");
                    string name = Console.ReadLine();

                    VideogiocoManager.GetVideogiocoByName(name);
                }
                else if (scelta == "4")
                {
                    Console.WriteLine("Inserisci un Id per eliminare un videogioco:");
                    int id = int.Parse(Console.ReadLine());

                    VideogiocoManager.Delete(id);
                }


                Console.WriteLine("Arrivederci!");
            }


        }
    }
}