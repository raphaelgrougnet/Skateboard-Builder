using System;
using System.Collections.Generic;
using System.Text;
using TP1_420_14B_FX.classes;
using TP1_420_14B_FX.enums;

namespace TP1_420_14B_FX.classes
{
    class SkateboardBuilder
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
        SkateboardBuilder()
            //TODO CONSTRUCTEUR SKATEBOARD BUILDER A FAIRE, DEMANDER AU PROF QUOI FAIRE, SI IL FAUT ATTRIBUIER A produits  LA FONCTION CHARCHER PRODUITS
        {
            this.Produits = ChargerProduits();
            this.Skateboards = ChargerSkateboards();
        }
        #endregion

        #region MÉTHODES
        public Produit[] ChargerProduits()
        {
            string[] vectProduitsString = Utilitaire.ChargerDonnees(CHEMIN_FICHIERS_PRODUITS);
            Produit[] vectProduits = new Produit[vectProduitsString.Length - 1]; //Retire la première ligne
            CategorieProduit categorie = CategorieProduit.Decks;
            string[] vectProduitsVect;
            for (int i = 1; i < vectProduitsString.Length-1; i++)
            {
                vectProduitsVect = vectProduitsString[i].Split(';');
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
                
                vectProduits[i] = new Produit(categorie,Convert.ToUInt32(vectProduitsVect[0]),vectProduitsVect[5],vectProduitsVect[1],Convert.ToDecimal(vectProduitsVect[4]), Convert.ToByte(vectProduitsVect[3]));

            }
            return vectProduits;
        }

        public Produit RechercherProduit(uint codeProduit)
        {
            Produit[] vectProduits = ChargerProduits();
            for (int i = 0; i < vectProduits.Length; i++)
            {
                if (codeProduit == vectProduits[i].Code)
                {
                    return vectProduits[i];
                }
            }

            return null;
        }



        // new Produit(CategorieProduit.Decks, vectProduits[Convert.ToInt32(vectSkateboardsVect[2])].Code, vectProduits[Convert.ToInt32(vectSkateboardsVect[2])].Image, vectProduits[Convert.ToInt32(vectSkateboardsVect[2])].Nom, vectProduits[Convert.ToInt32(vectSkateboardsVect[2])].Prix, vectProduits[Convert.ToInt32(vectSkateboardsVect[2])].QuantiteDispo)
        public Skateboard[] ChargerSkateboards()
        {
            string[] vectSkatebaordsString = Utilitaire.ChargerDonnees(CHEMIN_FICHIERS_SKATEBOARDS);
            Skateboard[] vectSkateboards = new Skateboard[vectSkatebaordsString.Length - 1]; //Retire la première ligne
            Produit[] vectProduits = ChargerProduits();
            string[] vectSkateboardsVect;
            for (int i = 1; i < vectSkatebaordsString.Length-1; i++)
            {
                vectSkateboardsVect = vectSkatebaordsString[i].Split(';');
                vectSkateboards[i] = new Skateboard(vectSkateboardsVect[0], vectSkateboardsVect[1], RechercherProduit(Convert.ToUInt32(vectSkateboardsVect[2])), RechercherProduit(Convert.ToUInt32(vectSkateboardsVect[3])), RechercherProduit(Convert.ToUInt32(vectSkateboardsVect[4])), RechercherProduit(Convert.ToUInt32(vectSkateboardsVect[5])));
            }

            return vectSkateboards;
        }
        #endregion

    }
}
