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
    public class MainWindowViewModel : ObservableRecipient
    {
        public RestCollection<Author> Authors { get; set; }
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

        public ICommand CreateAuthorCommand { get; set; }
        public ICommand DeleteAuthorCommand { get; set; }
        public ICommand UpdateAuthorCommand { get; set; }

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
        }
    }
}
