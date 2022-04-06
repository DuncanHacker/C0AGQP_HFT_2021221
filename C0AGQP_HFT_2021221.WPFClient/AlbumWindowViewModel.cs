using C0AGQP_HFT_2021221.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace C0AGQP_HFT_2021221.WPFClient
{
    public class AlbumWindowViewModel : ObservableRecipient
    {
        public RestCollection<Album> Albums { get; set; }
        private Album selectedAlbum;

        public Album SelectedAlbum
        {
            get { return selectedAlbum; }
            set
            {
                if (value != null)
                {
                    selectedAlbum = new Album()
                    {
                        Name = value.Name,
                        Id = value.Id
                    };
                    OnPropertyChanged();
                    (DeleteAlbumCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        public ICommand CreateAlbumCommand { get; set; }
        public ICommand DeleteAlbumCommand { get; set; }
        public ICommand UpdateAlbumCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }
        public AlbumWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Albums = new RestCollection<Album>("http://localhost:29693/", "album", "hub");
                CreateAlbumCommand = new RelayCommand(
                    () => Albums.Add(new Album()
                    {
                        Name = SelectedAlbum.Name
                    }));
                UpdateAlbumCommand = new RelayCommand(
                    () => Albums.Update(SelectedAlbum));
                DeleteAlbumCommand = new RelayCommand(
                    () => Albums.Delete(SelectedAlbum.Id),
                    () => SelectedAlbum != null);
                SelectedAlbum = new Album();
            }
        }
    }
}
