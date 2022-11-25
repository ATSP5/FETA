using FETA.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FETA.ViewModel
{
    public class AboutViewModel
    {
        public AboutModel AboutModel_O { get; set; }
        public AboutViewModel()
        {
            var wasLoadSuccesful = false;
            AboutModel_O = new AboutModel();
            try
            {
                var aboutPath = Directory.GetCurrentDirectory()+"\\about.txt";
                AboutModel_O.AboutText = File.ReadAllText(aboutPath);
                wasLoadSuccesful = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                wasLoadSuccesful = false;
            }
            finally
            {
                if(wasLoadSuccesful==false)
                    AboutModel_O.AboutText = "Could not load about.txt file. Is it present?";
            }
        }
    }
}
