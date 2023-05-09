using MVVMTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfPazzle.ViewModels;

namespace WpfPazzle.Models
{
    public class Part : ViewModelBase
    {
        private string path;
        public string Path { get => path; set => OnChanged(out path, value); }
    }
}
