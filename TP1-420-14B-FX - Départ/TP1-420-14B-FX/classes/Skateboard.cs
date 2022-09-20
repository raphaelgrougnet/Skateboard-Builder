

using System;

namespace TP1_420_14B_FX.classes
{
    /// <summary>
    /// Description générale de la classe.
    /// </summary>
    public class Skateboard
    {
        #region CONSTANTES ET ATTRIBUTS STATIQUES
        public const byte NOM_NB_CARACT_MIN = 1;
        public const byte NOM_NB_CARACT_MAX = 25;
        public const byte CODE_NB_CARAT = 0;
        #endregion


        #region ATTRIBUTS

        /// <summary>
        /// Code du skateboard
        /// </summary>
        private string _code;

        /// <summary>
        /// Nom du skate personnalisé
        /// </summary>
        private string _nom;

        /// <summary>
        /// Planche composant le skate
        /// </summary>
        private Produit _planche;

        /// <summary>
        /// Trucks composant le skate
        /// </summary>
        private Produit _trucks;

        /// <summary>
        /// Roues composant le skate
        /// </summary>
        private Produit _roues;

        /// <summary>
        /// Griptape composant le skate
        /// </summary>
        private Produit _grip;



        #endregion

        #region PROPRIÉTÉS ET INDEXEURS

        /// <summary>
        /// Obtient ou définit le code du skateboard
        /// </summary>
        public string Code
        {
            get { return _code; }
            private set { _code = value; }
        }

        /// <summary>
        /// Obtient ou définit le nom du skate
        /// </summary>
        /// <remarks>la valeur ne peut pas être vide, ne contenir que des espaces ou avoir plus de 25 caractères. 
        /// dans ce cas la valeur n'est pas modifié.</remarks>
        public string Nom
        {
            get { return _nom; }
            private set 
            {
                //todo : Implémenter la propriété Nom FAIT
                if (!String.IsNullOrWhiteSpace(value) && !(value.Length > NOM_NB_CARACT_MAX))
                {
                    _nom = value;
                }
                
            }
        }

        /// <summary>
        /// Obtient ou définit le prix de vente du skate
        /// </summary>
        
        //todo : Implementer la propriété prix de vente FAIT
        public decimal PrixVente
        {
            get
            {
                decimal prixAvantReduc = _grip.Prix + _planche.Prix + _trucks.Prix + _roues.Prix;
                decimal prixApresReduc = prixAvantReduc - (prixAvantReduc * (decimal).1);
                return prixApresReduc;
            }
        }

        /// <summary>
        /// Obtient ou définit le griptape composant le skate
        /// </summary>
        public Produit Grip
        {
            get { return _grip; }
            private set
            {
                _grip = value;
               
            }
        }


        /// <summary>
        /// Obtient ou définit la planche composant le skate
        /// </summary>
        public Produit Planche
        {
            get { return _planche; }
            private set
            {
                _planche = value;
                
            }
        }

        /// <summary>
        /// Obtient ou définit les trucks composant le skate
        /// </summary>
        public Produit Trucks
        {
            get { return _trucks; }
            private set
            {
                _trucks = value;
               
            }
        }

        /// <summary>
        /// Obtient ou définit les roues composant le skate
        /// </summary>
        public Produit Roues
        {
            get { return _roues; }
            private set
            {
                _roues = value;
               
            }
        }


        #endregion

        #region CONSTRUCTEURS
      
        /// <summary>
        /// Constructeur avec paramètres permettant de créer un skate avec toutes ses valeurs
        /// </summary>     
        
        //todo : Implémenter le code du constructeur avec paramètres

        #endregion

        #region MÉTHODES
        /// <summary>
        /// Permet de calculer le prix de vente d'un skate à partir de ces composantes
        /// </summary>
        /// <returns>Le prix de vente du skate</returns>
        private decimal CalculerPrixVente()
        {
            //todo : Implémenter la métode CalculerPrixVente
            throw new NotImplementedException();
        }

        /// <summary>
        /// Permet de vérifier si le skate possède déjà une composante (produit)
        /// </summary>
        /// <param name="produit">Produit à vérifier</param>
        /// <returns>true si le produit existe comme composante du skate; false sinon</returns>
        public bool PossedeProduit(Produit produit)
        {
            //todo : Implémenter la méthode PossedeProduit
            throw new NotImplementedException();
        }

        /// <summary>
        /// Permet d'obtenir une représentation d'un skate.
        /// </summary>
        /// <returns>Un représentation d'un skate sous forme de chaîne de caractères.</returns>
        public override string ToString()
        {

            //todo : Implémenter la méthode ToSTring
            throw new NotImplementedException();
        }

        #endregion
    } 
} 