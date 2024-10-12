using Proyecto_Final.Paginas;

namespace Proyecto_Final
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(GestionPlatosPage), typeof(GestionPlatosPage));
        }
    }
}
