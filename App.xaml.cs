using Autofac;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Lab13
{
    /// <summary>
    /// Logika interakcji dla klasy App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            //rejestracja danych dla autofaga zeby wiedział jakie ma interfejsy dostępne
            var builder = new ContainerBuilder();
            //POŹNIEJ PÓŹNIEJ JAK RECTANGLE ZROBIE teraz jak chce zeby zamiast labelki robił rectangle to zmienia label na rectangle
            //builder.RegisterType<LabelGenerator>().As<IControlGenerator>(); //wpisz na liste label generatora i podpisz go jako IControlGeneric
            builder.RegisterType<RectangleGenerator>().As<IControlGenerator>(); //
            //czyli jak jakas klasa bd szukałą IControlGenerator to on pokaza LabelGenerator
            builder.RegisterType<PanelFiller>().As<IPanelFiller>();
            //builder.RegisterType<FileDataProvider>().As<IDataProvider>(); 
            builder.RegisterType<DBDataProvider>().As<IDataProvider>(); //.Keyed() <- kilka typów dla jakiego interfejsu
            //zrobione dwa zachowania w razie sytaucji x

            builder.RegisterType<MainWindow>().AsSelf(); // zablokowałem głowny konstruktor dla tego as self zeby szukął sam po swojej nazwie konstruktora dla niego
            builder.RegisterType<Context>().AsSelf().InstancePerLifetimeScope();


            var container = builder.Build(); //przygotowanie operacji i siebie do działania
                                             //Tylko dla WPF

            using (var scope = container.BeginLifetimeScope()) //wpf nie wstrzyknie zaleznosci IPanelFelaer dla tego trzeba to obejsc, zeby autofag ogarnąl drugi konstruktor ja jego tez musze sotwrzyc przy pomocy autofaga pokazac wpfowi ze w mainwindow jest ten drugi konstruktor
            {
                //lifeTimeScope bd istniał przez cały czas działania apki
                //var windows = scope.Resolve<IControlGenerator>(); //on teraz z scopa zwróciłby LabelGenerator bo szuka go tam na swojej liscie i iwdiz ze ICOntrol powiazany z labelkiem
                var window = scope.Resolve<MainWindow>();  //AUTOFAG spróbuje zrobic MainWIndow ale do tego potrzebuje IPanelFiller wiec sprawdza liste widzi PanelFeller wjedzie do niego i sprobuje go zrobic - poniewaz tam nic nie ma szczegolnego przechodzi no problemos
                //conajwazniejsze jezeli bysmy przesli przez kompilacje jak robi PanelFiller konstruktor wymaga przysłania mu interfejsu i autofag sobie go wygerneruje sam
                window.Show(); //startup uri w app.xaml <- powoduje ze aplikacja wpfowa uruchamia sie przez podstawowy konstruktor wiec ja wywalamy
            }
        }
    }
}
