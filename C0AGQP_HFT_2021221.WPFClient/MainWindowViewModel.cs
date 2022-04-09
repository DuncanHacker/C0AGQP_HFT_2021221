﻿using C0AGQP_HFT_2021221.Models;
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
    public class MainWindowViewModel : ObservableRecipient
    {
        //Tables
        public RestCollection<Author> Authors { get; set; }
        public RestCollection<Album> Albums { get; set; }
        public RestCollection<Song> Songs { get; set; }

        private Author selectedAuthor;
        public Author SelectedAuthor
        {
            get { return selectedAuthor; }
            set {
                if (value != null)
                {
                    selectedAuthor = new Author()
                    {
                        Name = value.Name,
                        Id = value.Id
                    };
                    OnPropertyChanged();
                    (DeleteAuthorCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

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

        //Author Commands
        public ICommand CreateAuthorCommand { get; set; }
        public ICommand DeleteAuthorCommand { get; set; }
        public ICommand UpdateAuthorCommand { get; set; }
        //Album Commands
        public ICommand CreateAlbumCommand { get; set; }
        public ICommand DeleteAlbumCommand { get; set; }
        public ICommand UpdateAlbumCommand { get; set; }
        //Song Commands
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

        public MainWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Authors = new RestCollection<Author>("http://localhost:29693/", "author", "hub");
                CreateAuthorCommand = new RelayCommand(
                    () => Authors.Add(new Author()
                    {
                        Name = SelectedAuthor.Name
                    }));
                UpdateAuthorCommand = new RelayCommand(
                    () => Authors.Update(SelectedAuthor));
                DeleteAuthorCommand = new RelayCommand(
                    () => Authors.Delete(SelectedAuthor.Id),
                    () => SelectedAuthor != null);
                SelectedAuthor = new Author();
            }
            if (!IsInDesignMode)
            {
                Albums = new RestCollection<Album>("http://localhost:29693/", "album", "hub");
                CreateAlbumCommand = new RelayCommand(
                    () => Albums.Add(new Album()
                    {
                        Name = SelectedAlbum.Name,
                        AuthorId = SelectedAuthor.Id
                    }));
                UpdateAlbumCommand = new RelayCommand(
                    () => Albums.Update(SelectedAlbum));                
                DeleteAlbumCommand = new RelayCommand(
                    () => Albums.Delete(SelectedAlbum.Id),
                    () => SelectedAlbum != null);
                SelectedAlbum = new Album();
            }
            if (!IsInDesignMode)
            {
                Songs = new RestCollection<Song>("http://localhost:29693/", "song", "hub");
                CreateSongCommand = new RelayCommand(
                    () => Songs.Add(new Song()
                    {
                        Title = SelectedSong.Title,
                        AuthorId = SelectedAuthor.Id,
                        AlbumId = SelectedAlbum.Id
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
