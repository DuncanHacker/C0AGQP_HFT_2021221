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
    public class SongWindowViewModel : ObservableRecipient
    {
        public RestCollection<Song> Songs { get; set; }
        private Song selectedSong;

        public Song SelectedSong
        {
            get { return selectedSong; }
            set
            {
                if (value != null)
                {
                    selectedSong = new Song()
                    {
                        Title = value.Title,
                        Id = value.Id
                    };
                    OnPropertyChanged();
                    (DeleteSongCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        public ICommand CreateSongCommand { get; set; }
        public ICommand DeleteSongCommand { get; set; }
        public ICommand UpdateSongCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }
        public SongWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Songs = new RestCollection<Song>("http://localhost:29693/", "song", "hub");
                CreateSongCommand = new RelayCommand(
                    () => Songs.Add(new Song()
                    {
                        Title = SelectedSong.Title,
                        AuthorId = 1,
                        AlbumId = 1
                    }));
                UpdateSongCommand = new RelayCommand(
                    () => Songs.Update(SelectedSong));
                DeleteSongCommand = new RelayCommand(
                    () => Songs.Delete(SelectedSong.Id),
                    () => SelectedSong != null);
                SelectedSong = new Song();
            }
        }
    }
}
