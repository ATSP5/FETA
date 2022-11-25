using FETA.Controllers;
using FETA.Model;
using FETA.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FETA.ViewModel
{
    public class HashViewModel
    {
        public HashModel HashModel_O { get; set; }
        private ISHAService _shaService;
        public HashViewModel()
        {
            HashModel_O = new HashModel();
            _shaService = new SHAService();
        }

        ICommand process = null;
        public ICommand Process
        {
            get
            {
                if (process == null)
                {
                    process = new RelayCommand
                        (
                            (object o) =>
                            {
                                if(HashModel_O.HCAction == HashCompareAction.Hash)
                                {
                                    HashModel_O.Output = _shaService.ComputeSha256Hash(HashModel_O.Input + HashModel_O.Seed);
                                }
                                else
                                {
                                    var hashCode = _shaService.ComputeSha256Hash(HashModel_O.Input + HashModel_O.Seed);
                                    if(hashCode == HashModel_O.Output)
                                    {
                                        MessageBox.Show("Input and seeds are equal to the hash given","Success",MessageBoxButton.OK, MessageBoxImage.Information);
                                    }
                                    else
                                    {
                                        MessageBox.Show("Input and seeds are NOT equal to the hash given", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                                    }
                                }
                            },
                            (object o) =>
                            {
                                return true;
                            }
                        );
                }
                return process;
            }
        }
    }
}
