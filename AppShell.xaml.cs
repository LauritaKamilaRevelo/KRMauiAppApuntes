namespace KRMauiAppApuntes
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(Views.KRNotePage), typeof(Views.KRNotePage));
        }
    }
}
