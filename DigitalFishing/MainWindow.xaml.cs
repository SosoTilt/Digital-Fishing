using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;

namespace DigitalFishing
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Crée une liste de Magazine, de Pigiste et de Contrat dont le nombre n'est pas défini
        List<Magazine> lesMagazines = new List<Magazine>();
        List<Pigiste> lesPigistes = new List<Pigiste>();
        List<Contrat> lesContrats = new List<Contrat>();
        public MainWindow()
        {
            bdd.Initialize();
            InitializeComponent();

            lesMagazines = bdd.SelectMagazine();
            lesPigistes = bdd.SelectPigiste();
            lesContrats = bdd.SelectContrat();
            
            //Lie le Datagrid dtgMagazine avec la collection cMagazine
            dtgMagazine.ItemsSource = lesMagazines;

            //Lie le Datagrid dtgPigiste avec la collection cPigiste
            dtgPigiste.ItemsSource = lesPigistes;

            //Lie le Datagrid dtgContrat avec la collection cContrat
            dtgContrat.ItemsSource = lesContrats;


           // Pigiste p1 = new Pigiste(1, "Liguili", "Guy", "11 rue des lilas", "71000", "Macon", "guy@yopmail.fr", "1820696000000", "cc-01");
           //Pigiste p2 = new Pigiste(2, "Terrieur", "Alain", "12 rue des lilas", "71000", "Macon", "alain@yopmail.fr", "1820696000000", "cc-02");
            Pigiste p3 = new Pigiste(3, "Terrieur", "Alex", "13 rue des lilas", "71000", "Macon", "alex@yopmail.fr", "1820696000000", "cc-03");

           // Magazine m1 = new Magazine(1, "01/01/2022", "01/02/2022", "01/03/2022", 3500);
           //Magazine m2 = new Magazine(2, "01/04/2022", "01/05/2022", "01/06/2022", 3500);
            Magazine m3 = new Magazine(3, "01/07/2022", "01/08/2022", "01/09/2022", 3500);

            //Contrat c1 = new Contrat(1,144,140,true, false,0,p1,m1);
          //  Contrat c2 = new Contrat(3, 288, 280, true, false, 0, "01/09/2022", p2, m2);
          Contrat c3 = new Contrat(2, 144, 140, true, false, 0, "01/09/2022", p3, m3);

            
          //  //// On ajoute nos objets créés dans les collections
          // // lesPigistes.Add(p1);
          // // lesPigistes.Add(p2);
           lesPigistes.Add(p3);
          //  //lesMagazines.Add(m1);
          //  lesMagazines.Add(m2);
          lesMagazines.Add(m3);
          ////  lesContrats.Add(c1);
          //  lesContrats.Add(c2);
          lesContrats.Add(c3);


            // Lie les 2 comboboxs de l'onglet contrat pour les filtres
            cboFiltreMagazine.ItemsSource = lesMagazines;
            cboFiltrePigiste.ItemsSource = lesPigistes;

            // Lie les 2 comboboxs de l'onglet contrat avec les collections cPigiste et cMagazine
            cboPigiste.ItemsSource = lesPigistes;
            cboMagazine.ItemsSource = lesMagazines;

            //Selection de la première ligne dans les 3 datagrids pour éviter les erreurs de manipulation (A/M/S sans selection préalable)
            dtgContrat.SelectedIndex = 0;
            dtgMagazine.SelectedIndex = 0;
            dtgPigiste.SelectedIndex = 0;
        }

//////////////////////////////////
        #region Selection

        #region Select Contrat
        private void dtgContrat_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // On stock dans l'objet selectedContrat le Contrat selectionné dans le datagrid dtgContrat
            Contrat selectedContrat = dtgContrat.SelectedItem as Contrat;
            if (dtgContrat.SelectedItem != null)
            {
                try
                {
                    //Remplissage des Textboxs avec les données de l'objet Contrat selectedContrat récupéré dans le Datagrid dtgContrat
                    txtNumContrat.Text = Convert.ToString(selectedContrat.Num);
                    txtLettreAccordContrat.Text = selectedContrat.LettreAccord;
                    txtMontantBrutContrat.Text = Convert.ToString(selectedContrat.MontantBrut);
                    txtMontantNetContrat.Text = Convert.ToString(selectedContrat.MontantNet);
                    dtpCollabContrat.Text = Convert.ToString(selectedContrat.DateCollab);
                    cboEtatContrat.SelectedIndex = selectedContrat.Etat;

                    // Coche et décoche des 2 cases à cocher chkFacture et chkAgessa
                    if (selectedContrat.Facture == true)
                    { chkFacture.IsChecked = true; }
                    else
                    { chkFacture.IsChecked = false; }

                    if (selectedContrat.DeclarationAgessa == true)
                    { chkAgessa.IsChecked = true; }
                    else
                    { chkAgessa.IsChecked = false; }


                    // Sélection du pigiste concerné dans la Combobox
                    //cboPigiste.SelectedItem = selectedContrat.PigisteContrat;

                    int i = 0;
                    bool trouve = false;

                    while (i < cboPigiste.Items.Count && trouve == false)
                    {
                        if (Convert.ToString(cboPigiste.Items[i]) == Convert.ToString(selectedContrat.LePigiste))
                        {
                            trouve = true;
                            cboPigiste.SelectedIndex = i;
                        }
                        i++;
                    }

                    // Sélection du magazine concerné dans la Combobox
                    //cboPigiste.SelectedItem = selectedContrat.PigisteContrat;

                    i = 0;
                    trouve = false;

                    while (i < cboMagazine.Items.Count && trouve == false)
                    {
                        if (Convert.ToString(cboMagazine.Items[i]) == Convert.ToString(selectedContrat.LeMagazine))
                        {
                            trouve = true;
                            cboMagazine.SelectedIndex = i;
                        }
                        i++;
                    }
                }
                catch (Exception)
                {

                    Console.WriteLine("Erreur sur la mise à jour du formulaire lors du changement dans le Datagrid dtgContrat");
                }
            }
        }
        #endregion

        #region SelectMagazine
        private void dtgMagazine_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Stockage dans l'objet selectedMagazine le Magazine selectionné dans le datagrid dtgMagazine
            Magazine selectedMagazine = dtgMagazine.SelectedItem as Magazine;
            
            if (dtgMagazine.SelectedIndex >= 0)
            {
                try
                {
                    //Remplissage des Textboxs avec les données de l'objet Magazine selectedMagazine récupéré dans le Datagrid dtgMagazine
                    txtNumMagazine.Text = Convert.ToString(selectedMagazine.Num);
                    dtpBouclageMagazine.Text = Convert.ToString(selectedMagazine.DateBouclage);
                    dtpParutionMagazine.Text = Convert.ToString(selectedMagazine.DateParution);
                    dtpPaiementMagazine.Text = Convert.ToString(selectedMagazine.DatePaiement);
                    txtBudgetMagazine.Text = Convert.ToString(selectedMagazine.Budget);
                }
                catch (Exception)
                {
                    Console.WriteLine("Erreur sur la mise à jour du formulaire lors du changement dans le Datagrid dtgMagazine");
                }
            }
            
        }
        #endregion

        #region Select Pigiste
        private void dtgPigiste_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dtgPigiste.SelectedItem != null)
            {
                Pigiste selectedPigiste = dtgPigiste.SelectedItem as Pigiste;

                if (selectedPigiste != null)
                {
                    txtNumPigiste.Text = Convert.ToString(selectedPigiste.Num);
                    txtNomPigiste.Text = selectedPigiste.Nom;
                    txtPrenomPigiste.Text = selectedPigiste.Prenom;
                    txtAdressePigiste.Text = selectedPigiste.Adresse;
                    txtCPPigiste.Text = selectedPigiste.Cp;
                    txtVillePigiste.Text = selectedPigiste.Ville;
                    txtNumSecuPigiste.Text = selectedPigiste.NumSecu;
                    txtMailPigiste.Text = selectedPigiste.Mail;
                    txtContratCadrePigiste.Text = selectedPigiste.ContratCadre;
                }
            }
        }
        #endregion

        #endregion

//////////////////////////////////
        #region Magazine 

        #region Ajouter
        private void btnAjouterMagazine_Click(object sender, RoutedEventArgs e)
        {
            if (dtgMagazine.SelectedIndex >= 0)
            {
                Magazine tmpMag = new Magazine(0, dtpBouclageMagazine.Text, dtpParutionMagazine.Text, dtpPaiementMagazine.Text, Convert.ToInt32(txtBudgetMagazine.Text));
                bdd.InsertMagazine(tmpMag.DateBouclage, tmpMag.DateParution, tmpMag.DatePaiement, tmpMag.Budget);

                // Mets à jour la liste des magazines
                lesMagazines = bdd.SelectMagazine();

                // Mets à jour les données du DataGrid
                dtgMagazine.ItemsSource = lesMagazines;
                dtgMagazine.SelectedIndex = 0;
                //cboMagazine.Items.Refresh();
                dtgMagazine.Items.Refresh();

            }

            //   Magazine tmpMag = new Magazine(Convert.ToInt16(txtNumMagazine.Text), dtpBouclageMagazine.Text, dtpPaiementMagazine.Text, dtpParutionMagazine.Text, Convert.ToInt16(txtBudgetMagazine.Text));
            //   lesMagazines.Add(tmpMag);
            //   dtgMagazine.Items.Refresh();
        }
        #endregion

        #region Modifier Magazine
        private void btnModifierMagazine_Click(object sender, RoutedEventArgs e)
        {
            //On recherche à quel indice de la collection se trouve l'object selectionné dans le datagrid
            int indice = lesMagazines.IndexOf((Magazine)dtgMagazine.SelectedItem);

            if (dtgMagazine.SelectedIndex >= 0)
            {
                // On change les propritétés de l'objet à l'indice trouvé. On ne change pas le numéro de magazine via l'interface, trop de risques d'erreurs en base de données
                lesMagazines.ElementAt(indice).DateParution = dtpParutionMagazine.Text;
                lesMagazines.ElementAt(indice).DatePaiement = dtpPaiementMagazine.Text;
                lesMagazines.ElementAt(indice).DateBouclage = dtpBouclageMagazine.Text;
                lesMagazines.ElementAt(indice).Budget = Convert.ToInt32(txtBudgetMagazine.Text);

                bdd.UpdateMagazine(Convert.ToInt32(txtNumMagazine.Text), Convert.ToString(dtpBouclageMagazine.Text), Convert.ToString(dtpParutionMagazine.Text), Convert.ToString(dtpPaiementMagazine.Text), Convert.ToInt32(txtBudgetMagazine.Text));
            }

            dtgMagazine.Items.Refresh();
        }
        #endregion

        #region Supprimer Magazine
        private void btnSupprimerMagazine_Click(object sender, RoutedEventArgs e)
        {
            if (dtgMagazine.SelectedIndex >= 0)
            {
                bdd.DeleteMagazine(Convert.ToInt16(txtNumMagazine.Text));

                // Actualise magazines dans l'application
                lesMagazines = bdd.SelectMagazine();

                dtgMagazine.ItemsSource = lesMagazines;
                dtgMagazine.SelectedIndex = 0;
            }
            //lesMagazines.Clear();
            //lesMagazines.Remove((Magazine)dtgMagazine.SelectedItem);
            //On préselectionne par défaut le premier élément du Datagrid après la suppression           
        }
        #endregion

        #endregion

//////////////////////////////////
        #region Pigiste

        #region Ajouter Pigiste
        private void btnAjouterPigiste_Click(object sender, RoutedEventArgs e)
        {
            if (dtgPigiste.SelectedIndex >= 0)
            {
                Pigiste tmpPigiste = new Pigiste(0, txtNomPigiste.Text, txtPrenomPigiste.Text, txtAdressePigiste.Text, txtCPPigiste.Text, txtVillePigiste.Text, txtMailPigiste.Text, txtNumSecuPigiste.Text, txtContratCadrePigiste.Text);
                bdd.InsertPigiste(tmpPigiste.Nom, tmpPigiste.Prenom, tmpPigiste.Adresse, tmpPigiste.Cp, tmpPigiste.Ville, tmpPigiste.Mail, tmpPigiste.NumSecu, tmpPigiste.ContratCadre);

                // Mets a jours pigistes
                lesPigistes = bdd.SelectPigiste();

                // Met à jour le DataGrid
                dtgPigiste.ItemsSource = lesPigistes;
                dtgPigiste.SelectedIndex = 0;
                dtgPigiste.Items.Refresh();
            }
        }
        #endregion

        #region Modifier Pigiste
        private void btnModifierPigiste_Click(object sender, RoutedEventArgs e)
        {
            //On recherche à quel indice de la collection se trouve l'object selectionné dans le datagrid
            int indice = lesPigistes.IndexOf((Pigiste)dtgPigiste.SelectedItem);

            if (dtgMagazine.SelectedIndex >= 0)
            {
                bdd.UpdatePigiste(Convert.ToInt32(txtNumPigiste.Text), txtNomPigiste.Text, txtPrenomPigiste.Text, txtAdressePigiste.Text, txtCPPigiste.Text, txtVillePigiste.Text, txtMailPigiste.Text, txtNumSecuPigiste.Text, txtContratCadrePigiste.Text);

                // On change les propritétés de l'objet à l'indice trouvé. On ne change pas le numéro de magazine via l'interface, trop de risques d'erreurs en base de données
                lesPigistes.ElementAt(indice).Nom = txtNomPigiste.Text;
                lesPigistes.ElementAt(indice).Prenom = txtPrenomPigiste.Text;
                lesPigistes.ElementAt(indice).NumSecu = txtNumSecuPigiste.Text;
                lesPigistes.ElementAt(indice).ContratCadre = txtContratCadrePigiste.Text;
                lesPigistes.ElementAt(indice).Adresse = txtAdressePigiste.Text;
                lesPigistes.ElementAt(indice).Cp = txtCPPigiste.Text;
                lesPigistes.ElementAt(indice).Ville = txtVillePigiste.Text;
                lesPigistes.ElementAt(indice).Mail = txtMailPigiste.Text;
            }

            dtgPigiste.Items.Refresh();
        }
        #endregion

        #region Suprimmer Pigiste
        private void btnSupprimerPigiste_Click(object sender, RoutedEventArgs e)
        {
            if (dtgPigiste.SelectedItem != null)
            {
                Pigiste selectedPigiste = dtgPigiste.SelectedItem as Pigiste;

                if (selectedPigiste != null)
                {
                    bdd.DeletePigiste(selectedPigiste.Num);
                    lesPigistes.Remove(selectedPigiste);
                    
                    dtgPigiste.Items.Refresh();
                }
                dtgPigiste.SelectedIndex = 0;
            }
            // lesPigistes.Remove((Pigiste)dtgPigiste.SelectedItem);
            //dtgPigiste.SelectedIndex = 0;
        }
        #endregion
        #endregion

        #region Contrat

        #region Ajouter Contrat 
        private void btnAjouterContrat_Click(object sender, RoutedEventArgs e)
        {
            if (dtgPigiste.SelectedIndex >= 0)
            {
                // Récupération du Pigiste sélectionné dans le Combobox cboPigiste
                Pigiste ModifPigiste = cboPigiste.SelectedItem as Pigiste;

                // Récupération du Magazine sélectionné dans le Combobox cboMagazine
                Magazine ModifMagazine = cboMagazine.SelectedItem as Magazine;


                Contrat tmpContrat = new Contrat(0, Convert.ToInt32(txtMontantBrutContrat.Text), Convert.ToInt32(txtMontantNetContrat.Text), (bool)chkAgessa.IsChecked, (bool)chkFacture.IsChecked, cboEtatContrat.SelectedIndex, dtpCollabContrat.Text, (Pigiste)cboPigiste.SelectedItem, (Magazine)cboMagazine.SelectedItem);
                bdd.InsertContrat(tmpContrat.LettreAccord, tmpContrat.MontantBrut, tmpContrat.MontantNet, tmpContrat.Etat, tmpContrat.Facture, tmpContrat.DeclarationAgessa, tmpContrat.DateCollab, tmpContrat.LePigiste, tmpContrat.LeMagazine);

                // Mets a jours pigistes
                lesContrats = bdd.SelectContrat();

                // Met à jour le DataGrid
                dtgContrat.ItemsSource = lesContrats;
                dtgContrat.SelectedIndex = 0;
                dtgContrat.Items.Refresh();
            }
            // lesContrats.Add(tmpContrat);
        }
        #endregion

        #region Modifier Contrat
        private void btnModifierContrat_Click(object sender, RoutedEventArgs e)
        {
            //On recherche à quel indice de la collection se trouve l'object selectionné dans le datagrid
            int indice = lesContrats.IndexOf((Contrat)dtgContrat.SelectedItem);

            // On change les propritétés de l'objet à l'indice trouvé. On ne change pas le numéro de magazine via l'interface, trop de risques d'erreurs en base de données
            lesContrats.ElementAt(indice).LettreAccord = txtLettreAccordContrat.Text;
            lesContrats.ElementAt(indice).MontantBrut = Convert.ToInt32(txtMontantBrutContrat.Text);
            lesContrats.ElementAt(indice).MontantNet = Convert.ToInt32(txtMontantNetContrat.Text);
            lesContrats.ElementAt(indice).Etat = cboEtatContrat.SelectedIndex;
            lesContrats.ElementAt(indice).LePigiste = (Pigiste)cboPigiste.SelectedItem;
            lesContrats.ElementAt(indice).LeMagazine = (Magazine)cboMagazine.SelectedItem;
            lesContrats.ElementAt(indice).Facture = (bool)chkFacture.IsChecked;
            lesContrats.ElementAt(indice).DeclarationAgessa = (bool)chkAgessa.IsChecked;

            dtgContrat.Items.Refresh();
        }
        #endregion

        #region Suprimmer Contrat
        private void btnSupprimerContrat_Click(object sender, RoutedEventArgs e)
        {


            if (dtgContrat.SelectedIndex >= 0)
            {
                bdd.DeleteMagazine(Convert.ToInt16(txtNumContrat.Text));

                // Actualise magazines dans l'application
                lesContrats = bdd.SelectContrat();

                dtgContrat.ItemsSource = lesContrats;
                dtgContrat.SelectedIndex = 0;
            }
        }

        #endregion
        #endregion
    }
}
