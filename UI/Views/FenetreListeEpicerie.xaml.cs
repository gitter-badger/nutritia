﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Nutritia.UI.Views
{
    /// <summary>
    /// Logique d'interaction pour ListeEpicerie.xaml
    /// </summary>
    public partial class ListeEpicerie : UserControl
    {
        public Menu MenuGenere { get; set; }
        public ObservableCollection<Aliment> ListeAliments { get; set; }

        /// <summary>
        /// Constructeur par défaut de la classe.
        /// </summary>
        public ListeEpicerie(Menu menu)
        {
            InitializeComponent();

            MenuGenere = menu;

            ListeAliments = new ObservableCollection<Aliment>();

            GenererListe();
            GenererListeConviviale();

        }

        /// <summary>
        /// Méthode permettant de générer la liste d'épicerie.
        /// </summary>
        private void GenererListe()
        {
            foreach(Plat platCourant in MenuGenere.ListePlats)
            {
                foreach(Aliment ingredient in platCourant.ListeIngredients)
                {
                    ListeAliments.Add(ingredient);
                }
            }

            dgListeEpicerie.ItemsSource = ListeAliments;

        }

        /// <summary>
        /// Méthode permettant de générer les rangées de la grid de la liste conviviale.
        /// </summary>
        private void GenererRangees()
        {
            RowDefinition rowDefinition;

            for (int i = 0; i < ListeAliments.Count; i++)
            {
                rowDefinition = new RowDefinition();
                rowDefinition.Height = new GridLength(30);

                grdListeConviviale.RowDefinitions.Add(rowDefinition);
            }
        }

        /// <summary>
        /// Méthode permettant de générer la liste d'épicerie conviviale.
        /// </summary>
        private void GenererListeConviviale()
        {
            GenererRangees();

            Label lblArticle;

            for(int i = 0; i < ListeAliments.Count; i++)
            {
                lblArticle = new Label();
                lblArticle.Content = ListeAliments[i].Nom;
                Grid.SetRow(lblArticle, i);
                grdListeConviviale.Children.Add(lblArticle);
            }
        }
    }
}
