using Proyecto_Final.ConexionDatos;
using Proyecto_Final.Modelo;
using Proyecto_Final.Paginas;
using System.Diagnostics;
using System.Globalization;

namespace Proyecto_Final
{
    public partial class MainPage : ContentPage
    {
        private readonly IRestConexionDatos conexionDatos;

        public MainPage(IRestConexionDatos conexionDatos)
        {
            InitializeComponent();
            this.conexionDatos = conexionDatos;
        }

        protected async override void OnAppearing()
        { 
            base.OnAppearing();
            MenuPlatosView.ItemsSource = await conexionDatos.GetPlatosAsync();
        }
        //Evento Añadir Plato
        async void OnAddPlatoClic(Object sender, EventArgs e)
        {
            Debug.WriteLine("[EVENTO] Botón AddPlato clicleado");            
            
            var param = new Dictionary<string, object>
            {
                { nameof(Plato),new Plato()},
                
            };
            await Shell.Current.GoToAsync(nameof(GestionPlatosPage),param);
        }
        //Evento Click Sobre el Nombre del Plato de la lista para Editar
        async void OnUpdatePlatoClic(Object sender, SelectionChangedEventArgs e)
        {
            Debug.WriteLine("[EVENTO] Botón Seleccionado clicleado");
            
            var param = new Dictionary<string, object>
            {
                { nameof(Plato), e.CurrentSelection.FirstOrDefault() as Plato},
                /*{ nameof(Plato.Nombre), platoSeleccionado.Nombre }, // Obtener el nombre del objeto
                {nameof(Plato.Ingredientes), platoSeleccionado.Ingredientes }, // Obtener la descripción
                {nameof(Plato.Precio), precio }, // Este será un decimal*/
            };
            await Shell.Current.GoToAsync(nameof(GestionPlatosPage), param);
        }

    }

}
