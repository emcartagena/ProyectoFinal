using Proyecto_Final.ConexionDatos;
using System.Diagnostics;

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
            //menuPlatosView.ItemsSourse = await conexionDatos.GetPlatosAsync():
        }
        //Evento Añadir Plato
        async void OnAddPlatoClic(Object sender, EventArgs e)
        {
            Debug.WriteLine("[EVENTO] Botón AddPlato clicleado");
        }
        //Evento Click Sobre el Nombre del Plato de la lista para Editar
        async void OnUpdatePlatoClic(Object sender, SelectionChangedEventArgs e)
        {
            Debug.WriteLine("[EVENTO] Botón Seleccionado clicleado");
        }

    }

}
