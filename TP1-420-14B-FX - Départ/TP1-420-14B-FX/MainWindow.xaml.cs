using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using TP1_420_14B_FX.enums;
using TP1_420_14B_FX.classes;



namespace TP1_420_14B_FX
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        #region CONSTANTES

        public const string CHEMIN_DOSSIER_IMAGE = @"C:\data-420-14B-FX\images\";

        #endregion

        #region ATTRIBUTS

        private SkateboardBuilder _skateBoardBuilder = new SkateboardBuilder();

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
            //todo: Implémenter la méthode InitialiserFormulaire FAIT
            btnNouveau.IsEnabled = true;
            btnAjouter.IsEnabled = true;

            btnDesassembler.IsEnabled = false;
            btnVendu.IsEnabled = false;
            btnValeurTotal.IsEnabled = true;

            btnAjouterProduit.IsEnabled = false;
            btnEnregistrer.IsEnabled = true;
            btnQuitter.IsEnabled = true;

            AfficherListeSkateboards();
            AfficherProduitsCategorie(CategorieProduit.Decks);

        }

        /// <summary>
        /// Permet l'initialisation de la section « Détails du skateboard »
        /// </summary>
        private void InitialiserDetailsSkateboard()
        {


            txtNomSkateboard.Text = "";
            txtCodeSkateboard.Text = "";

            imgPlanche.Tag = null;
            //todo : Ajouter l'image par défaut d'une plache "deck.png" FAIT
            imgPlanche.Source = new BitmapImage(new Uri(CHEMIN_DOSSIER_IMAGE+"deck.png"));
            imgPlanche.IsEnabled = true;

            imgTrucks.Tag = null;
            //todo : Ajouter l'image par défaut des trucks "trucks.png" FAIT
            imgTrucks.IsEnabled = true;
            imgTrucks.Source = new BitmapImage(new Uri(CHEMIN_DOSSIER_IMAGE + "trucks.png"));
            imgRoues.Tag = null;
            //todo : Ajouter l'image par défaut des trucks "wheels.png" FAIT
            imgRoues.Source = new BitmapImage(new Uri(CHEMIN_DOSSIER_IMAGE + "wheels.png"));
            imgRoues.IsEnabled = true;


            imgGrip.Tag = null;
            //todo : Ajouter l'image par défaut des trucks "grip.png" FAIT
            imgGrip.Source = new BitmapImage(new Uri(CHEMIN_DOSSIER_IMAGE + "grip.png"));
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
            
            for (int i = 0; i < _skateBoardBuilder.Skateboards.Length; i++)
            {
                lstSkateboards.Items.Add(_skateBoardBuilder.Skateboards[i]);
            }

            

            //todo : Implementer la méthode AfficherListeSkateboards FAIT
            
            
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
            //todo : Implémenter la méthode AfficherProduitsCatégories FAIT
            for (int i = 1; i < _skateBoardBuilder.Produits.Length; i++)
            {
                switch (_skateBoardBuilder.Produits[i].Categorie)
                {
                    case CategorieProduit.Decks:
                        lstProduits.Items.Add(_skateBoardBuilder.Produits[i]);
                        break;
                    case CategorieProduit.Truck:
                        lstProduits.Items.Add(_skateBoardBuilder.Produits[i]);
                        break;
                    case CategorieProduit.Wheels:
                        lstProduits.Items.Add(_skateBoardBuilder.Produits[i]);
                        break;
                    case CategorieProduit.GripTape:
                        lstProduits.Items.Add(_skateBoardBuilder.Produits[i]);
                        break;
                    
                }
            }
            
        }


        /// <summary>
        /// Permet l'ajout d'un produit dans l'image correspondant à la composante ajoutée au skateboard
        /// et d'afficher le nom et le prix de la composantes dans la section prix
        /// </summary>
        /// <param name="produit">Produit à ajouter</param>
        private void AjouterProduit(Produit produit)
        {
            //todo: Implémenter la méthode AjouterProduit FAIT
            switch (produit.Categorie)
            {
                case CategorieProduit.Decks:
                    imgProduit.Tag = produit;
                    imgProduit.Source = new BitmapImage(new Uri(produit.Image));
                    break;
                case CategorieProduit.Truck:
                    imgProduit.Tag = produit;
                    imgProduit.Source = new BitmapImage(new Uri(produit.Image));
                    break;
                case CategorieProduit.Wheels:
                    imgProduit.Tag = produit;
                    imgProduit.Source = new BitmapImage(new Uri(produit.Image));
                    break;
                case CategorieProduit.GripTape:
                    imgProduit.Tag = produit;
                    imgProduit.Source = new BitmapImage(new Uri(produit.Image));
                    break;
                
            }

            lblPrixProduit.Content = produit.Prix;
            lblQuantiteProduitDispo.Content = produit.QuantiteDispo;
            lblNomProduit.Text = produit.Nom;
            
        }


        /// <summary>
        /// Permet de valider si un skateboard assemblé est valide
        /// </summary>
        /// <returns>true si le skateboard est valide; false sinon</returns>
        private bool validerSkateboard()
        {
            //todo : Implémenter la méthode ValiderSkateboard FAIT
            string messageErreur = "";
            if (string.IsNullOrEmpty(txtNomSkateboard.Text) || txtNomSkateboard.Text.Length >25)
            {
                messageErreur += "Le nom ne doit pas être vide et contenir au maximum 25 caractères.\n";
            }
            if (imgPlanche.Tag == null)
            {
                messageErreur += "Vous devez sélectionner une planche.\n";
            }
            if (imgTrucks.Tag == null)
            {
                messageErreur += "Vous devez sélectionner un truck.\n";
            }
            if (imgRoues.Tag == null)
            {
                messageErreur += "Vous devez sélectionner des roues.\n";
            }
            if (imgGrip.Tag == null)
            {
                messageErreur += "Vous devez sélectionner un grip.\n";
            }

            if (imgPlanche.Tag == null || imgTrucks.Tag == null || imgRoues.Tag == null || imgGrip.Tag == null)
            {
                return false;
            }
            return true;

            if (messageErreur != "")
            {
                MessageBox.Show(messageErreur, "Attention !", MessageBoxButton.OK);
                return false;
            }
            
        }







        #endregion

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            InitialiserFormulaire();
        }

        private void btnAjouterProduit_Click(object sender, RoutedEventArgs e)
        {
            if (validerSkateboard())
            {
                _skateBoardBuilder.AjouterSkateboard(txtNomSkateboard.Text, (Produit)imgPlanche.Tag, (Produit)imgTrucks.Tag, (Produit)imgRoues.Tag, (Produit)imgGrip.Tag);
            }
        }
    }
}
