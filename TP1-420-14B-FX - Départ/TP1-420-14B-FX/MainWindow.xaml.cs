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

        private const string CHEMIN_DOSSIER_IMAGE = @"C:\data-420-14B-FX\images\";

        #endregion

        #region ATTRIBUTS

        private SkateboardBuilder _skateBoardBuilder = new SkateboardBuilder();
        private bool modif = false;

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

            lstProduits.Items.Clear();
            lstSkateboards.Items.Clear();

            AfficherListeSkateboards();
            
            InitialiserDetailsSkateboard();
            InitialiserListeProduits();

            AfficherProduitsCategorie(CategorieProduit.Decks);

        }

        /// <summary>
        /// Permet l'initialisation de la section « Détails du skateboard »
        /// </summary>
        private void InitialiserDetailsSkateboard()
        {


            txtNomSkateboard.Text = "";
            txtCodeSkateboard.Text = "";

            
            //todo : Ajouter l'image par défaut d'une plache "deck.png" FAIT
            imgPlanche.Source = new BitmapImage(new Uri(CHEMIN_DOSSIER_IMAGE+"deck.png"));
            imgPlanche.IsEnabled = true;
            imgPlanche.Tag = null;

            imgTrucks.Tag = null;
            //todo : Ajouter l'image par défaut des trucks "trucks.png" FAIT
            imgTrucks.IsEnabled = true;
            imgTrucks.Source = new BitmapImage(new Uri(CHEMIN_DOSSIER_IMAGE + "trucks.png"));
            imgTrucks.Tag = null;
            
            //todo : Ajouter l'image par défaut des trucks "wheels.png" FAIT
            imgRoues.Source = new BitmapImage(new Uri(CHEMIN_DOSSIER_IMAGE + "wheels.png"));
            imgRoues.IsEnabled = true;
            imgRoues.Tag = null;


            //todo : Ajouter l'image par défaut des trucks "grip.png" FAIT
            imgGrip.Source = new BitmapImage(new Uri(CHEMIN_DOSSIER_IMAGE + "grip.png"));
            imgGrip.IsEnabled = true;
            imgGrip.Tag = null;



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
            InitialiserListeProduits();
            lstProduits.SelectedIndex = -1;
            lstProduits.Items.Clear();
            //todo : Implémenter la méthode AfficherProduitsCatégories FAIT
            for (int i = 0; i < _skateBoardBuilder.Produits.Length-1; i++)
            {
                if (_skateBoardBuilder.Produits[i].Categorie == categorie)
                {
                    lstProduits.Items.Add(_skateBoardBuilder.Produits[i]);
                }
                
            }
            gpListeProduits.Header = string.Format("Liste des produits - {0}", categorie);
            
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

                    imgPlanche.Tag = produit;
                    imgPlanche.Source = new BitmapImage(new Uri(CHEMIN_DOSSIER_IMAGE + produit.Image));
                    lblNomPlanche.Text = produit.Nom;
                    lblPrixPlanche.Content = $"{produit.Prix:c2}";
                    break;
                case CategorieProduit.Truck:
                    imgTrucks.Tag = produit;
                    imgTrucks.Source = new BitmapImage(new Uri(CHEMIN_DOSSIER_IMAGE + produit.Image));
                    lblNomTrucks.Text = produit.Nom;
                    lblPrixTrucks.Content = $"{produit.Prix:c2}";
                    break;
                case CategorieProduit.Wheels:
                    imgRoues.Tag = produit;
                    imgRoues.Source = new BitmapImage(new Uri(CHEMIN_DOSSIER_IMAGE + produit.Image));
                    lblNomRoues.Text = produit.Nom;
                    lblPrixRoues.Content = $"{produit.Prix:c2}";
                    break;
                case CategorieProduit.GripTape:
                    imgGrip.Tag = produit;
                    imgGrip.Source = new BitmapImage(new Uri(CHEMIN_DOSSIER_IMAGE + produit.Image));
                    lblNomGrip.Text = produit.Nom;
                    lblPrixGrip.Content = $"{produit.Prix:c2}";
                    break;

            }
            
            
            

            
            
        }


        /// <summary>
        /// Permet de valider si un skateboard assemblé est valide
        /// </summary>
        /// <returns>true si le skateboard est valide; false sinon</returns>
        private bool validerSkateboard()
        {
            //todo : Implémenter la méthode ValiderSkateboard FAIT
            

            if (imgPlanche.Tag == null || imgTrucks.Tag == null || imgRoues.Tag == null || imgGrip.Tag == null || String.IsNullOrWhiteSpace(txtNomSkateboard.Text))
            {
                return false;
            }
            return true;

            
            
        }







        #endregion

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            InitialiserFormulaire();
            
        }

        private void btnAjouterProduit_Click(object sender, RoutedEventArgs e)
        {
            AjouterProduit((Produit)imgProduit.Tag);
        }

        private void lstProduits_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Produit prodSelect =(Produit) lstProduits.SelectedItem;
            if (lstProduits.SelectedIndex != -1)
            {

                btnAjouterProduit.IsEnabled = true;
                Produit produitSelected = (Produit)lstProduits.SelectedItem;
                lblNomProduit.Text = produitSelected.Nom;
                lblPrixProduit.Content = $"{produitSelected.Prix:c2}";
                lblQuantiteProduitDispo.Content = produitSelected.QuantiteDispo;
                imgProduit.Source = new BitmapImage(new Uri(CHEMIN_DOSSIER_IMAGE + produitSelected.Image));
                imgProduit.Tag = produitSelected;
            }
            if (prodSelect.QuantiteDispo < 1)
            {
                btnAjouterProduit.IsEnabled = false;
            }
            
        }

        private void lstSkateboards_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstSkateboards.SelectedIndex != -1)
            {
                Skateboard skate = (Skateboard)lstSkateboards.SelectedItem;
                txtNomSkateboard.Text = skate.Nom;
                txtCodeSkateboard.Text = skate.Code;
                lblNomPlanche.Text = skate.Planche.Nom;
                lblNomTrucks.Text = skate.Trucks.Nom;
                lblNomRoues.Text = skate.Roues.Nom;
                lblNomGrip.Text = skate.Grip.Nom;

                lblPrixPlanche.Content = $"{skate.Planche.Prix:c2}";
                lblPrixTrucks.Content = $"{skate.Trucks.Prix:c2}";
                lblPrixRoues.Content = $"{skate.Roues.Prix:c2}";
                lblPrixGrip.Content = $"{skate.Grip.Prix:c2}";

                lblMontantReduction.Content = $"{((skate.Planche.Prix + skate.Trucks.Prix + skate.Roues.Prix + skate.Grip.Prix) * (decimal)0.1):c2}";
                lblPrixVente.Content = $"{skate.PrixVente:c2}";

                lstProduits.Items.Clear();

                imgPlanche.Source = new BitmapImage(new Uri(CHEMIN_DOSSIER_IMAGE + skate.Planche.Image));
                imgTrucks.Source = new BitmapImage(new Uri(CHEMIN_DOSSIER_IMAGE + skate.Trucks.Image));
                imgRoues.Source = new BitmapImage(new Uri(CHEMIN_DOSSIER_IMAGE + skate.Roues.Image));
                imgGrip.Source = new BitmapImage(new Uri(CHEMIN_DOSSIER_IMAGE + skate.Grip.Image));
                imgProduit.Source = null;
                lblPrixProduit.Content = "";
                lblNomProduit.Text = "";
                lblQuantiteProduitDispo.Content = "";

                btnAjouter.IsEnabled = false;
                btnVendu.IsEnabled = true;
                btnDesassembler.IsEnabled = true;


            }
            
        }

        private void btnEnregistrer_Click(object sender, RoutedEventArgs e)
        {
            _skateBoardBuilder.EnregistrerProduit();
            _skateBoardBuilder.EnregistrerSkateboard();
            modif = false;
        }

        private void btnQuitter_Click(object sender, RoutedEventArgs e)
        {
            if (modif)
            {
                MessageBoxResult messageResult = MessageBox.Show("Voulez sauvegarder les modifications avant de quitter ?", "Quitter l'application", MessageBoxButton.YesNoCancel);

                switch (messageResult)
                {
                    
                    
                    case MessageBoxResult.Cancel:
                        break;
                    case MessageBoxResult.Yes:
                        _skateBoardBuilder.EnregistrerProduit();
                        _skateBoardBuilder.EnregistrerSkateboard();
                        Close();
                        break;
                    case MessageBoxResult.No:
                        Close();
                        break;
                    
                }
            }
            else
            {
                Close();
            }
        }

        private void btnValeurTotal_Click(object sender, RoutedEventArgs e)
        {
            decimal valTot = 0;
            for (int i = 0; i < _skateBoardBuilder.Skateboards.Length; i++)
            {
                if (_skateBoardBuilder.Skateboards[i] != null)
                {
                    valTot += _skateBoardBuilder.Skateboards[i].PrixVente;
                }
                
            }
            MessageBox.Show($"La valeur des skateboards est de {valTot:c2}", "Valeur des skateboards", MessageBoxButton.OK);
        }

        private void btnVendu_Click(object sender, RoutedEventArgs e)
        {
            if (lstSkateboards.SelectedIndex != -1 && lstSkateboards.SelectedItem != null)
            {
                bool supr = _skateBoardBuilder.SupprimerSkateboard((Skateboard)lstSkateboards.SelectedItem);
                if (supr)
                {
                    lstSkateboards.Items.Clear();
                    AfficherListeSkateboards();
                    MessageBox.Show($"Le skateboard sélectionné a bien été vendu !", "Vente de skateboard", MessageBoxButton.OK);
                    InitialiserFormulaire();
                }
                else
                {
                    MessageBox.Show($"Le skateboard n'a pas pu être vendu suite a une erreur", "Vente de skateboard", MessageBoxButton.OK);
                    InitialiserFormulaire();
                }
            }

            modif = true;
            
        }

        private void btnDesassembler_Click(object sender, RoutedEventArgs e)
        {
            if (lstSkateboards.SelectedIndex != -1 && lstSkateboards.SelectedItem != null)
            {
                Skateboard skate = (Skateboard)lstSkateboards.SelectedItem;
                
                bool supr = _skateBoardBuilder.SupprimerSkateboard(skate);
                if (supr)
                {
                    skate.Planche.AjouterQuantiteInventaire(1);
                    skate.Trucks.AjouterQuantiteInventaire(1);
                    skate.Roues.AjouterQuantiteInventaire(1);
                    skate.Grip.AjouterQuantiteInventaire(1);
                    lstSkateboards.Items.Clear();
                    AfficherListeSkateboards();
                    lstProduits.Items.Clear();
                    
                    MessageBox.Show($"Le skateboard sélectionné a bien été désassemblé !", "Désassemblage de skateboard", MessageBoxButton.OK);
                    InitialiserFormulaire();
                    modif = true;
                }
                else
                {
                    MessageBox.Show($"Le skateboard n'a pas pu être désassemblé suite a une erreur", "Désassemblage de skateboard", MessageBoxButton.OK);
                    InitialiserFormulaire();
                }
            }
        }

        private void btnAjouter_Click(object sender, RoutedEventArgs e)
        {
            if (validerSkateboard())
            {
                _skateBoardBuilder.AjouterSkateboard(txtNomSkateboard.Text, (Produit)imgPlanche.Tag, (Produit)imgTrucks.Tag, (Produit)imgRoues.Tag, (Produit)imgGrip.Tag);
                lstSkateboards.Items.Clear();

                AfficherListeSkateboards();
                btnDesassembler.IsEnabled = false;
                btnAjouter.IsEnabled = false;
                btnAjouterProduit.IsEnabled = false;
                lblNomProduit.Text = "";
                lblPrixProduit.Content = "";
                lblQuantiteProduitDispo.Content = "";
                imgProduit.Source = null;
                lstProduits.Items.Clear();
                InitialiserDetailsSkateboard();
                AfficherProduitsCategorie(CategorieProduit.Decks);
                MessageBox.Show("La création du skateboard à fonctionné avec succès.", "Ajout d'un skateboard", MessageBoxButton.OK);
                modif = true;
            }
            else
            {
                string messageErreur = "";
                if (string.IsNullOrEmpty(txtNomSkateboard.Text) || txtNomSkateboard.Text.Length > Skateboard.NOM_NB_CARACT_MAX)
                {
                    messageErreur += $"Le nom ne doit pas être vide et contenir au maximum {Skateboard.NOM_NB_CARACT_MAX} caractères.\n";
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

                if (messageErreur != "")
                {
                    MessageBox.Show(messageErreur, "Attention !", MessageBoxButton.OK);

                }
            }
        }

        private void btnNouveau_Click(object sender, RoutedEventArgs e)
        {
            
            InitialiserFormulaire();
        }

        private void imgPlanche_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (lstSkateboards.SelectedIndex == -1)
            {
                
                AfficherProduitsCategorie(CategorieProduit.Decks);
            }
            
        }

        private void imgTrucks_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (lstSkateboards.SelectedIndex == -1)
            {
                
                AfficherProduitsCategorie(CategorieProduit.Truck);
            }
            
        }

        private void imgRoues_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (lstSkateboards.SelectedIndex==-1)
            {
                
                AfficherProduitsCategorie(CategorieProduit.Wheels);
            }
            
        }

        private void imgGrip_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (lstSkateboards.SelectedIndex==-1)
            {
                
                AfficherProduitsCategorie(CategorieProduit.GripTape);
            }
            
        }

        
    }
}
