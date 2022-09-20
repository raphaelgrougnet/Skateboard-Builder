using System;
using TP1_420_14B_FX.enums;


namespace TP1_420_14B_FX.classes
{
    /// <summary>
    /// Classe représentant un produit
    /// </summary>
    public class Produit
    {

        #region CONSTANTES
        
        #endregion

        #region ATTRIBUTS

        /// <summary>
        /// Identifiant unique du produit
        /// </summary>
        private uint _code;

        /// <summary>
        ///Nom du produit
        /// </summary>
        private string _nom;

        /// <summary>
        /// Catégorie du produit
        /// </summary>
        //todo : Créer l'attribut pour la catégorie FAIT
        private CategorieProduit _categorie;

        /// <summary>
        /// Quantité disponible en inventaire
        /// </summary>
        private byte _quantiteDispo;

        /// <summary>
        /// Prix de vente du produit
        /// </summary>
        private decimal _prix;

        /// <summary>
        /// Nom de l'image du produit
        /// </summary>
        private string _image;

        #endregion

        #region PROPRIÉTÉS ET INDEXEURS

        /// <summary>
        /// Identifiant unique du produit.
        /// </summary>
        public uint Code
        {
            get { return _code; }
            private set { _code = value; }
        }

        /// <summary>
        /// Nom du produit
        /// </summary>
        public string Nom
        {
            get { return _nom; }
            private set { _nom = value; }
        }

        /// <summary>
        /// Catégorie à laquelle appartient le produit
        /// </summary>
        //Todo : implémenter la propriété pour la catégorie FAIT
        public CategorieProduit Categorie
        {
            get { return _categorie; }
            private set { _categorie = value; }
        }

        /// <summary>
        /// Quantité disponible du produit en inventaire
        /// </summary>
        public byte QuantiteDispo
        {
            get { return _quantiteDispo; }
            private set { _quantiteDispo = value; }
        }

        /// <summary>
        /// Prix de vente du produit
        /// </summary>
        public decimal Prix
        {
            get { return _prix; }
            private set
            {
                _prix = value >= 0 ? value : 0 ;
            }
        }

        /// <summary>
        /// Nom du fichier image du produit.
        /// </summary>
        public String Image
        {
            get { return _image; }
            private set { _image = value; }
        }

        #endregion

        #region CONSTRUCTEURS
        /// <summary>
        /// Permet de construire un produit avec toutes ses valeurs.
        /// </summary>
        //todo : Implémenter le constructeur avec paramètres de la classe. FAIT
        public Produit(CategorieProduit categorie, uint code, string image, string nom, decimal prix, byte quantiteDispo)
        {
            this.Categorie = categorie;
            this.Code = code;
            this.Image = image;
            this.Nom = nom;
            this.Prix = prix;
            this.QuantiteDispo = quantiteDispo;
        }

        #endregion

        #region MÉTHODES

       /// <summary>
       /// Permet de retirer une quantité de ce produit de l'inventaire
       /// </summary>
       /// <param name="quantite">Quantite à retirer de l'inventaire</param>
       /// <returns>true si au moins un exemplaire du produit existe dans l'inventaire</returns>
        public bool RetirerQuantiteInventaire(byte quantite)
        {
            //todo : Implémenter la méthode RetirerQuantiteInventaire FAIT
            if (QuantiteDispo >= quantite)
            {
                QuantiteDispo -= quantite;
                return true;
            }
            return false;
            
        }

        /// <summary>
        /// Permet d'ajouter une quantité du produit en inventaire
        /// </summary>
        /// <param name="quantite">Quantité à ajouter</param>
        public void AjouterQuantiteInventaire(byte quantite)
        {
            //todo : Implémenter la méthode AjouterQuantiteInventaire FAIT
            QuantiteDispo += quantite;
            
        }

        /// <summary>
        /// Permet d'obtenir une représentation du produit.
        /// </summary>
        /// <returns>Un représentation d'un produit sous forme de chaîne de caractères.</returns>
        public override string ToString()
        {

            //todo : Implémenter la méthode ToString FAIT
            return this.Nom;
            
        }

        #endregion

    } 
} 