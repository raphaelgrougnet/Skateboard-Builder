using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;



namespace TP1_420_14B_FX
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        #region CONSTANTES

        #endregion

        #region ATTRIBUTS

      
        #endregion

        #region PROPRIÉTÉS ET INDEXEURS

        #endregion

        #region CONSTRUCTEURS

        public MainWindow()
        {
            InitializeComponent();
        }

        #endregion

        #region MÉTHODES

       

        /// <summary>
        /// Permet d'initialiser l'interface.
        /// <remark>l'interface est dans l'état d'ajout d'un skateboad</remark>
        /// </summary>
        private void InitialiserFormulaire()
        {
            //todo: Implémenter la méthode InitialiserFormulaire
            throw new NotImplementedException();

        }

        /// <summary>
        /// Permet l'initialisation de la section « Détails du skateboard »
        /// </summary>
        private void InitialiserDetailsSkateboard()
        {


            txtNomSkateboard.Text = "";
            txtCodeSkateboard.Text = "";

            imgPlanche.Tag = null;
            //todo : Ajouter l'image par défaut d'une plache "deck.png"
            imgPlanche.IsEnabled = true;

            imgTrucks.Tag = null;
            //todo : Ajouter l'image par défaut des trucks "trucks.png"
            imgTrucks.IsEnabled = true;

            imgRoues.Tag = null;
            //todo : Ajouter l'image par défaut des trucks "wheels.png"
            imgRoues.IsEnabled = true;


            imgGrip.Tag = null;
            //todo : Ajouter l'image par défaut des trucks "grip.png"
            imgGrip.IsEnabled = true;

            lblNomPlanche.Text = "";
            lblPrixPlanche.Content = $"{0:c2}";

            lblNomTrucks.Text = "";
            lblPrixTrucks.Content = $"{0:c2}";

            lblNomRoues.Text = "";
            lblPrixRoues.Content = $"{0:c2}";

            lblNomGrip.Text = "";
            lblPrixGrip.Content = $"{0:c2}";

            lblMontantReduction.Content = $"{0:c2}";
            lblPrixVente.Content = $"{0:c2}";

            txtCodeSkateboard.IsEnabled = false;
        }


        /// <summary>
        /// Permet l'affichage de la liste des skateboards assemblés dans la section « Skateboards »
        /// <remarks>Affiche la liste des skateboards assemblées et ajuste l'état des boutons</remarks>
        /// </summary>
        private void AfficherListeSkateboards()
        {
            //todo : Implementer la méthode AfficherListeSkateboards
            throw new NotImplementedException();
        }

        /// <summary>
        /// Permet l'inialisation de l'interface de la section « liste des produits »
        /// </summary>
        private void InitialiserListeProduits()
        {
            lstProduits.Items.Clear();
            imgProduit.Source = null;
            lblNomProduit.Text = "";
            lblPrixProduit.Content = "";
            lblQuantiteProduitDispo.Content = "";
            btnAjouterProduit.IsEnabled = false;
        }

        /// <summary>
        /// Permet l'affichage de la liste des produits selon une catégorie sélectionnée
        /// </summary>
        /// <param name="categorie">Catégorie de produit à afficher</param>
        private void AfficherProduitsCategorie(CategorieProduit categorie)
        {
            //todo : Implémenter la méthode AfficherProduitsCatégories
            throw new NotImplementedException();
        }


        /// <summary>
        /// Permet l'ajout d'un produit dans l'image correspondant à la composante ajoutée au skateboard
        /// et d'afficher le nom et le prix de la composantes dans la section prix
        /// </summary>
        /// <param name="produit">Produit à ajouter</param>
        private void AjouterProduit(Produit produit)
        {
            //todo: Implémenter la méthode AjouterProduit
            throw new NotImplementedException();
        }


        /// <summary>
        /// Permet de valider si un skateboard assemblé est valide
        /// </summary>
        /// <returns>true si le skateboard est valide; false sinon</returns>
        private bool validerSkateboard()
        {
            //todo : Implémenter la méthode ValiderSkateboard
            throw new NotImplementedException();
        }

        
        #endregion

       

       

        
    }
}
