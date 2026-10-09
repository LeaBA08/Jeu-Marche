
string[] panier = [
    "",
    "",
    "",
    "",
    ""
];

System.Console.WriteLine("Bienvenu au Marché!");
ChoixMenu choix = ChoixMenu.Ajouter;

do
{
    System.Console.WriteLine("Veuillez entrer le numéro correspondant à ce que vous souhaitez faire dans la liste ci-dessous: ");
    System.Console.WriteLine(" 1) " + ChoixMenu.Ajouter + "\n 2) " + ChoixMenu.Retirer + "\n 3) " + ChoixMenu.Afficher + "\n 4) " + ChoixMenu.Rechercher + "\n 5) " + ChoixMenu.Quitter);

    bool reussi = int.TryParse(Console.ReadLine(), out int nombre);
    while (!reussi || (nombre < 1 || nombre > 5))
    {
        System.Console.WriteLine("Veuillez entrer un chiffre valide!: ");
        reussi = int.TryParse(Console.ReadLine(), out nombre);
    }
    choix = (ChoixMenu)nombre;
    switch (choix)
    {
        case ChoixMenu.Ajouter:
            Ajouter(panier);
            break;
        case ChoixMenu.Retirer:
            Retirer(panier);
            break;
        case ChoixMenu.Afficher:
            Afficher(panier);
            break;
        case ChoixMenu.Rechercher:
            Rechercher(panier);
            break;
        case ChoixMenu.Quitter:
            System.Console.WriteLine("Au revoir!");
            break;
    }

} while (choix != ChoixMenu.Quitter);

static void Afficher(string[] panier)
{
    for (int i = 0; i < panier.Length; i++)
    {
        if (string.IsNullOrWhiteSpace(panier[i]))
        {
            System.Console.WriteLine(i + 1 + ") " + "(vide)");
        }
        else
        {
            System.Console.WriteLine(i + 1 + ") " + panier[i]);
        }
    }
}

static void Ajouter(string[] panier)
{
    System.Console.WriteLine("Que souhaitez vous ajouter?: ");
    string nouvElement = EntreElement();

    int indice = TrouverIndice(panier, nouvElement);
    if (indice != -1)
    {
        System.Console.WriteLine("Vous avez déjà ajouté cet élément dans votre panier.");
        return;
    }


    bool placeTrouvee = false;
    int i = 0;

    //ajouter fruit/legume à cond. que celui si n'existe pas
    while (i < panier.Length && !placeTrouvee)
    {
        if (string.IsNullOrWhiteSpace(panier[i]))
        {
            placeTrouvee = true;
        }
        else
        {
            i++;
        }
    }


    if (placeTrouvee)
    {
        panier[i] = nouvElement;
        System.Console.WriteLine(nouvElement + " a bien été ajouté dans votre panier!");
    }
    else
    {
        System.Console.WriteLine("Il n'y a pas de place dans le panier pour le moment.");
    }
}

static int TrouverIndice(string[] panier, string nom)
{
    for (int cpt = 0; cpt < panier.Length; cpt++)
    {
        if (string.Equals(nom, panier[cpt], StringComparison.OrdinalIgnoreCase))
        {
            return cpt;
        }
    }
    return -1;
}

static void Rechercher(string[] panier)
{
    System.Console.WriteLine("Quel fruit/légume recherchez vous?: ");
    string elementRecherche = EntreElement();
    int i = TrouverIndice(panier, elementRecherche);
    if (i == -1)
    {
        System.Console.WriteLine(elementRecherche + " n'est pas dans le panier.");
    }
    else
    {
        System.Console.WriteLine(elementRecherche + " est bien dans le panier.");
    }
}

static string EntreElement()
{
    string nouvElement = Console.ReadLine();
    while (string.IsNullOrWhiteSpace(nouvElement))
    {
        System.Console.WriteLine("Veuillez entrer un fruit/légume valide!: ");
        nouvElement = Console.ReadLine();
    }
    nouvElement = nouvElement.Trim();
    return nouvElement;
}

static void Retirer(string[] panier)
{
    System.Console.WriteLine("Que souhaitez vous retirer?: ");
    string element = EntreElement();
    int i = TrouverIndice(panier, element);
    if (i == -1)
    {
        System.Console.WriteLine(element + " n'est pas dans le panier, il n'est donc pas possible de le retirer.");
    }
    else
    {
        panier[i] = "";
        System.Console.WriteLine(element + " a bien été enlevé du panier.");
    }
}

enum ChoixMenu
{
    Ajouter = 1,
    Retirer = 2,
    Afficher = 3,
    Rechercher = 4,
    Quitter = 5
}

