using MVVMTools;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using WpfPazzle.Models;

namespace WpfPazzle.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            Parts = new ObservableCollection<Part>();
            Check = new ObservableCollection<Part>();

            Timer = new DispatcherTimer();
            Timer.Interval = TimeSpan.FromSeconds(1);
            Timer.Tick += Timer_Tick;
        }

        private int seconds = 0;
        private int minutes = 0;
        private ObservableCollection<Part> Check;
        public DispatcherTimer Timer;

        private ObservableCollection<Part> parts;
        public ObservableCollection<Part> Parts { get => parts; set => OnChanged(out parts, value); }

        private string time;
        public string Time { get => time; set => OnChanged(out time, value); }

        private Part select;
        public Part Select { get => select; set => OnChanged(out select, value); }

        private int choise;

        private void RandomPuzzle()
        {
            Random random = new Random();

            for (int i = 0; i < Parts.Count; i++)
            {
                int num = random.Next(0, Parts.Count);
                var value = Parts[num];
                Parts[num] = Parts[i];
                Parts[i] = value;
            }
        }
        private void FillPazzle()
        {
            for (int i = 1; i < 25; i++)
            {
                if (choise == 1)
                {
                    Parts.Add(new Part() { Path = $@"img/Forest/{i}.jpg" });
                    Check.Add(new Part() { Path = $@"img/Forest/{i}.jpg" });
                }
                else if (choise == 2)
                {
                    Parts.Add(new Part() { Path = $@"img/Lake/{i}.jpg" });
                    Check.Add(new Part() { Path = $@"img/Lake/{i}.jpg" });
                }
                else if (choise == 3)
                {
                    Parts.Add(new Part() { Path = $@"img/Waterfall/{i}.jpg" });
                    Check.Add(new Part() { Path = $@"img/Waterfall/{i}.jpg" });
                }
            }
        }
        private void Timer_Tick(object? sender, EventArgs e)
        {
            seconds++;

            if (seconds == 60)
            {
                seconds = 0;
                minutes++;
            }

            if (minutes >= 10)
            {
                if (seconds < 10) Time = minutes.ToString() + ":0" + seconds.ToString();
                else Time = minutes.ToString() + ":" + seconds.ToString();
            }
            else
            {
                if (seconds < 10) Time = "0" + minutes.ToString() + ":0" + seconds.ToString();
                else Time = "0" + minutes.ToString() + ":" + seconds.ToString();
            }
        }

        private Command choiseImageForest;
        public Command ChoiseImageForest => choiseImageForest ??= new Command(x =>
            {
                choise = 1;
                FillPazzle();
                RandomPuzzle();
                Timer.Start();
            }
        );
        private Command choiseImageLake;
        public Command ChoiseImageLake => choiseImageLake ??= new Command(x =>
            {
                choise = 2;
                FillPazzle();
                RandomPuzzle();
                Timer.Start();
            }
        );
        private Command choiseImageWaterfall;
        public Command ChoiseImageWaterfall => choiseImageWaterfall ??= new Command(x =>
            {
                choise = 3;
                FillPazzle();
                RandomPuzzle();
                Timer.Start();
            }
        );

        private Command<ObservableCollection<Part>> clickButtonShow = null;
        public Command<ObservableCollection<Part>> ClickButtonShow => clickButtonShow ??= new Command<ObservableCollection<Part>>(
            (value) =>
            {
                ObservableCollection<Part>? Value = Parts;
                Parts = Check;
                Check = Value;
            }
        );

        private Command<Part> clickCommand = null;
        public Command<Part> ClickCommand => clickCommand ??= new Command<Part>(
            (img) =>
            {
                if (Select == null) Select = img;
                else
                {
                    var index1 = Parts.IndexOf(img);
                    var index2 = Parts.IndexOf(Select);

                    var value = Parts[index2];
                    Parts[index2] = Parts[index1];
                    Parts[index1] = value;

                    Select = null;

                    if (CheckWin()) { Timer.Stop(); MessageBox.Show("You Win!"); }
                }
            }
        );

        public bool CheckWin()
        {
            for (int i = 0; i < parts.Count; i++)
            {
                if (!Parts[i].Path.Equals(Check[i].Path)) return false;
            }
            return true;
        }
    }
}