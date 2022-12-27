﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicinalPlants.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class PlantDetailViewModel : BaseViewModel
    {
        public PlantDetailViewModel()
        {
            Title = "Detalle de la planta";
        }

        private string itemId;
        private string name;
        private string commonNames;
        private string scientificNames;
        private string uses;

        public int Id { get; set; }

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        public string CommonNames
        {
            get => commonNames;
            set => SetProperty(ref commonNames, value);
        }

        public string ScientificNames
        {
            get => scientificNames;
            set => SetProperty(ref scientificNames, value);
        }


        public string Uses
        {
            get => uses;
            set => SetProperty(ref uses, value);
        }

        public string ItemId
        {
            get => itemId;
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }

        public async void LoadItemId(string id)
        {
            try
            {
                var item = await App.Database.GetItemAsync(Convert.ToInt32(id));
                Id = item.Id;
                Name = item.Name;
                CommonNames = item.CommonNames;
                ScientificNames = item.ScientificNames;
                Uses = item.Uses;
            }
            catch (Exception)
            {
                Debug.WriteLine("Error al cargar la planta");
            }
        }
    }
}
