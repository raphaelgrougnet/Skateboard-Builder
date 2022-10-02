using System;
using System.Collections.Generic;
using System.Text;
using TP1_420_14B_FX.classes;
using TP1_420_14B_FX.enums;

namespace TP1_420_14B_FX.classes
{
    public class SkateboardBuilder
    {

        #region CONSTANTES
        public const string CHEMIN_FICHIERS_PRODUITS = @"C:\data-420-14B-FX\produits.csv";
        public const string CHEMIN_DOSSIER_IMAGES = @"C:\data-420-14B-FX\images";
        public const string CHEMIN_FICHIERS_SKATEBOARDS = @"C:\data-420-14B-FX\skateboards.csv";
        #endregion

        #region ATTRIBUTS
        Produit[] _produits;
        Skateboard[] _skateboards;
        #endregion

        #region PROPRIÉTÉS ET INDEXEURS
        public Produit[] Produits
        {
            get { return _produits; }
            private set { _produits = value; }
        }

        public Skateboard[] Skateboards
        {
            get { return _skateboards; }
            private set { _skateboards = value; }
        }
        #endregion

        #region CONSTRUCTEURS
        public SkateboardBuilder()
            
        {
            this.Produits = ChargerProduits();
            this.Skateboards = ChargerSkateboards();
        }
        #endregion

        #region MÉTHODES
        /// <summary>
        /// Permet d'obtenir un vecteur de produits qui sera créé à partir des données contenues dans le fichier des produits.
        /// </summary>
        /// <returns>Vecteur de produits</returns>
        private Produit[] ChargerProduits()
        {
            string[] vectProduitsString = Utilitaire.ChargerDonnees(CHEMIN_FICHIERS_PRODUITS);
            Produit[] vectProduits = new Produit[vectProduitsString.Length - 1]; //Retire la première ligne
            CategorieProduit categorie = CategorieProduit.Decks;
            string[] vectProduitsVect;
            for (int i = 0; i < vectProduitsString.Length-1; i++)
            {
                vectProduitsVect = vectProduitsString[i].Split(';');
                for (int y = 0; y < vectProduitsVect.Length; y++)
                {
                    vectProduitsVect[y] = vectProduitsVect[y].Trim();
                }
                switch (vectProduitsVect[2])
                {
                    case "Decks":
                        categorie = CategorieProduit.Decks;
                        break;
                    case "Wheels":
                        categorie = CategorieProduit.Wheels;
                        break;
                    case "GripTape":
                        categorie = CategorieProduit.GripTape;
                        break;
                    case "Trucks":
                        categorie = CategorieProduit.Truck;
                        break;
                    
                }

                uint code = Convert.ToUInt32(vectProduitsVect[0]);
                string img = vectProduitsVect[5];
                string nom = vectProduitsVect[1];
                decimal prix = Decimal.Parse(vectProduitsVect[4].Replace('.',','));
                byte qteDispo = Convert.ToByte(vectProduitsVect[3]);

                
                vectProduits[i] = new Produit(categorie,code,img,nom,prix,qteDispo);
                
            }
            return vectProduits;
        }

        /// <summary>
        /// Permet de recherche un produit en fonction de son numéro d'identification (code).
        /// </summary>
        /// <param name="codeProduit">Code du produit à rechercher</param>
        /// <returns>null si aucun produit ne correspond au numéro d'identification, sinon le produit.</returns>
        public Produit RechercherProduit(uint codeProduit)
        {
            Produit[] vectProduits = ChargerProduits();
            for (int i = 1; i < vectProduits.Length; i++)
            {
                if (codeProduit == vectProduits[i].Code)
                {
                    return vectProduits[i];
                }
            }

            return null;
        }



        // new Produit(CategorieProduit.Decks, vectProduits[Convert.ToInt32(vectSkateboardsVect[2])].Code, vectProduits[Convert.ToInt32(vectSkateboardsVect[2])].Image, vectProduits[Convert.ToInt32(vectSkateboardsVect[2])].Nom, vectProduits[Convert.ToInt32(vectSkateboardsVect[2])].Prix, vectProduits[Convert.ToInt32(vectSkateboardsVect[2])].QuantiteDispo)

        /// <summary>
        /// Permet d'obtenir un vecteur de skateboards qui sera créé à partir des données contenues dans le fichier des skateboards.
        /// </summary>
        /// <returns>Vecteur de skateboards</returns>
        private Skateboard[] ChargerSkateboards()
        {
            string[] vectSkateboardsString = Utilitaire.ChargerDonnees(CHEMIN_FICHIERS_SKATEBOARDS);
            Skateboard[] vectSkateboards = new Skateboard[vectSkateboardsString.Length]; //Retire la première ligne
            Produit[] vectProduits = ChargerProduits();
            string[] vectSkateboardsVect;
            for (int i = 0; i < vectSkateboardsString.Length-1; i++)
            {
                vectSkateboardsVect = vectSkateboardsString[i].Split(';');
                vectSkateboards[i] = new Skateboard(vectSkateboardsVect[0], vectSkateboardsVect[1], RechercherProduit(Convert.ToUInt32(vectSkateboardsVect[2])), RechercherProduit(Convert.ToUInt32(vectSkateboardsVect[3])), RechercherProduit(Convert.ToUInt32(vectSkateboardsVect[4])), RechercherProduit(Convert.ToUInt32(vectSkateboardsVect[5])));
            }
            int count = 0;
            for (int i = 0; i < vectSkateboards.Length; i++)
            {
                if (vectSkateboards[i] != null)
                {
                    count++;
                }
                
            }
            Skateboard[] vectSkateboardsNew = new Skateboard[count];
            for (int i = 0; i < vectSkateboards.Length; i++)
            {
                if (vectSkateboards[i] != null)
                {
                    vectSkateboardsNew[i] = vectSkateboards[i];
                }
            }
            return vectSkateboardsNew;
        }

        /// <summary>
        /// Permet l'ajout d'un skateboard au vecteur de skateboards. De plus, ajuste    la quantité disponible de chaque produit composant le skateboard.
        /// </summary>
        /// <param name="nom">Nom du skateboard</param>
        /// <param name="planche">Objet planche du skateboard</param>
        /// <param name="trucks">Objet trucks du skateboard</param>
        /// <param name="roues">Objet roues du skateboard</param>
        /// <param name="grip">Objet grip du skateboard</param>
        /// <returns>Vrai si le skateboard a bien été ajouté. Sinon retourne faux.</returns>
        public bool AjouterSkateboard(string nom, Produit planche, Produit trucks, Produit roues, Produit grip)
        {
            Skateboard[] vectSkateboardsBase = this.Skateboards;
            Skateboard[] vectSkateboardsNew;
            if (vectSkateboardsBase.Length > 0)
            {
                vectSkateboardsNew = new Skateboard[vectSkateboardsBase.Length + 1];
                for (int i = 0; i < vectSkateboardsBase.Length - 1; i++)
                {
                    vectSkateboardsNew[i] = vectSkateboardsBase[i];
                }
                Random aleatoire = new Random();
                int nb_Aleatoire;

                string code;
                do
                {
                    nb_Aleatoire = aleatoire.Next(1, 100);
                    code = string.Format("{0}{1}{2}{3}{4}", planche.Nom[0], trucks.Nom[0], roues.Nom[0], grip.Nom[0], nb_Aleatoire);
                } while (ValiderCode(code));

                if (VerifierDoublon(planche, trucks, roues, grip) == null)
                {
                    if (vectSkateboardsBase[vectSkateboardsBase.Length - 1] == null)
                    {
                        vectSkateboardsBase[vectSkateboardsBase.Length - 1] = new Skateboard(code, nom, planche, trucks, roues, grip);
                    }
                    else
                    {
                        vectSkateboardsNew[vectSkateboardsNew.Length - 1] = new Skateboard(code, nom, planche, trucks, roues, grip);

                    }

                    planche.RetirerQuantiteInventaire(1);
                    trucks.RetirerQuantiteInventaire(1);
                    roues.RetirerQuantiteInventaire(1);
                    grip.RetirerQuantiteInventaire(1);

                    Skateboards = vectSkateboardsNew;
                }
            }
            else
            {
                vectSkateboardsNew = new Skateboard[1];
                Random aleatoire = new Random();
                int nb_Aleatoire;

                string code;
                
                
                nb_Aleatoire = aleatoire.Next(1, 100);
                code = string.Format("{0}{1}{2}{3}{4}", planche.Nom[0], trucks.Nom[0], roues.Nom[0], grip.Nom[0], nb_Aleatoire);

                vectSkateboardsNew[0] = new Skateboard(code, nom, planche, trucks, roues, grip);
                Skateboards = vectSkateboardsNew;
            }



            if (Skateboards.Length > 1)
            {
                if (!(Skateboards[Skateboards.Length - 1] == null))
                {
                    return true;
                }
            }
            else
            {
                if (!(Skateboards[0] == null))
                {
                    return true;
                }
            }
            
            return false;
        }

        /// <summary>
        /// Permet de vérifier si le code d’un skateboard existe déjà dans les skateboards assemblés.
        /// </summary>
        /// <param name="code">Code du skateboard à valider</param>
        /// <returns>Vrai si le code n’existe pas et faux si celui-ci existe déjà.</returns>
        private bool ValiderCode(string code)
        {
            for (int i = 1; i < Skateboards.Length; i++)
            {
                if (Skateboards[i] != null)
                {
                    if (Skateboards[i].Code == code)
                    {
                        return true;
                    }
                }
                
            }
            return false;
        }

        /// <summary>
        /// Méthode permettant de vérifier s'il existe un skateboard possédant déjà les même composantes.
        /// </summary>
        /// <param name="planche">Objet Planche</param>
        /// <param name="trucks">Objet Trucks</param>
        /// <param name="roues">Objet Roues</param>
        /// <param name="grip">Objet Grip</param>
        /// <returns>Retourne le skateboard trouvé ou null s'il n'existe aucun skateboard identique.</returns>
        public Skateboard VerifierDoublon(Produit planche, Produit trucks, Produit roues, Produit grip)
        {
            for (int i = 1; i < Skateboards.Length; i++)
            {
                if (Skateboards[i] != null)
                {
                    if (Skateboards[i].Planche == planche)
                    {
                        if (Skateboards[i].Trucks == trucks)
                        {
                            if (Skateboards[i].Roues == roues)
                            {
                                if (Skateboards[i].Grip == grip)
                                {
                                    return Skateboards[i];
                                }
                            }
                        }
                    }
                }
                
            }

            return null;
        }

        /// <summary>
        /// Permet de supprimer un skateboard du vecteur de skateboards assemblés.
        /// </summary>
        /// <param name="skateboard">Skateboard à supprimer</param>
        /// <returns>Retourne vrai si le skateboard a bien été retiré de la liste. Sinon retourne faux.</returns>
        public bool SupprimerSkateboard(Skateboard skateboard)
        {
            Skateboard[] vectSkateboardsBase = this.Skateboards;
            bool valide = true;
            for (int i = 0; i < vectSkateboardsBase.Length; i++)
            {
                if (vectSkateboardsBase[i].Code == skateboard.Code)
                {
                    vectSkateboardsBase[i] = null;
                }
            }

            int nbVide = 0;
            for (int i = 0; i < vectSkateboardsBase.Length; i++)
            {
                if (vectSkateboardsBase[i] != null)
                {
                    nbVide++;
                }
            }
            Skateboard[] vectSkateboardsNew = new Skateboard[nbVide];
            int incrementeur = 0;
            for (int i = 0; i < vectSkateboardsBase.Length; i++)
            {
                if (vectSkateboardsBase[i] != null)
                {
                    vectSkateboardsNew[incrementeur] = vectSkateboardsBase[i];
                    incrementeur++;
                }
            }
            Skateboards = vectSkateboardsNew;

            for (int i = 0; i < Skateboards.Length; i++)
            {
                if (Skateboards[i] == null)
                {
                    valide = false;
                }
            }

            //bool valide = true;
            //for (int i = 0; i < vectSkateboardsBase.Length; i++)
            //{
            //    if (vectSkateboardsBase[i] != null)
            //    {
            //        if (skateboard.Code == vectSkateboardsBase[i].Code)
            //        {
            //            vectSkateboardsBase[i] = null;
            //        }
            //    }
                
            //}
            //int incrementeur = 0;
            
            
            //for (int i = 0; i < vectSkateboardsBase.Length; i++)
            //{

            //    if (vectSkateboardsBase[i] != null)
            //    {
            //        vectSkateboardsNew[incrementeur] = vectSkateboardsBase[i];
            //    }
            //    incrementeur++;
            //}
            
            //vectSkateboardsBase = vectSkateboardsNew;
            return valide;
            
        }

        /// <summary>
        /// Permet de désassembler un skateboard lorsque celui-ci ne se vend pas. Ainsi, chaque composante du skateboard est retournée à l'inventaire des produits et le skateboard est supprimé.
        /// </summary>
        /// <param name="skateboard">Skateboard à désassembler</param>
        /// <returns>Retourne vrai si bien été désassemblé, sinon faux.</returns>
        public bool DesassemblerSkateboard(Skateboard skateboard)
        {
            skateboard.Trucks.AjouterQuantiteInventaire(1);
            skateboard.Roues.AjouterQuantiteInventaire(1);
            skateboard.Grip.AjouterQuantiteInventaire(1);
            skateboard.Trucks.AjouterQuantiteInventaire(1);
            return SupprimerSkateboard(skateboard);
        }

        /// <summary>
        /// Permet de calculer la valeur des skateboards assemblés.
        /// </summary>
        /// <returns>Valeur total des Skateboards</returns>
        public decimal CalculerValTotalSkateboards()
        {
            decimal valTotal = 0;
            for (int i = 0; i < Skateboards.Length; i++)
            {
                valTotal += Skateboards[i].PrixVente;
            }
            return valTotal;
        }

        /// <summary>
        /// Permet d'enregistrer les produits dans le fichier des produits.
        /// </summary>
        public void EnregistrerProduit()
        {
            string donnees = "Code;Nom;Categorie;Quantite;Prix;Image\n";
            for (int i = 0; i < Produits.Length; i++)
            {
                string categorie = "";
                switch (Produits[i].Categorie)
                {
                    case CategorieProduit.Decks:
                        categorie = "Decks";
                        break;
                    case CategorieProduit.Truck:
                        categorie = "Trucks";
                        break;
                    case CategorieProduit.Wheels:
                        categorie = "Wheels";
                        break;
                    case CategorieProduit.GripTape:
                        categorie = "GripTape";
                        break;
                    
                }
                donnees += String.Format("{0};{1};{2};{3};{4};{5}\n",Produits[i].Code, Produits[i].Nom, categorie, Produits[i].QuantiteDispo, Produits[i].Prix.ToString().Replace(",","."), Produits[i].Image);
            }

            Utilitaire.EnregistrerDonnees(CHEMIN_FICHIERS_PRODUITS, donnees);
        }

        /// <summary>
        /// Permet d'enregistrer les skateboards assemblés dans le fichier des skateboards.
        /// </summary>
        public void EnregistrerSkateboard()
        {
            string donnees = "Code;Nom;Planche;Trucks;Roues;Griptape\n";
            for (int i = 0; i < Skateboards.Length; i++)
            {
                donnees += String.Format("{0};{1};{2};{3};{4};{5}\n", Skateboards[i].Code, Skateboards[i].Nom, Skateboards[i].Planche, Skateboards[i].Trucks, Skateboards[i].Roues, Skateboards[i].Grip);
            }

            Utilitaire.EnregistrerDonnees(CHEMIN_FICHIERS_SKATEBOARDS, donnees);
        }
        #endregion

    }
}
