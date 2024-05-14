using caltamiranoT6.Models;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace caltamiranoT6.Vistas;

public partial class vHome : ContentPage
{
    private const string url = "http://192.168.17.23/appmovil/post.php";
    private readonly HttpClient cliente = new HttpClient();
    private ObservableCollection<Estudiantes> estuadientes;
    public vHome()
	{
		InitializeComponent();
        obtener();
    }
    public async void obtener()
    {
        var content = await cliente.GetStringAsync(url);
        List<Estudiantes> ListEs = JsonConvert.DeserializeObject<List<Estudiantes>>(content);
        estuadientes = new ObservableCollection<Estudiantes>(ListEs);
        listaEstudiantes.ItemsSource = estuadientes;
    }

    private void btnAgregar_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Vistas.vAgregar());
    }

    private void listaEstudiantes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        var objectestudiante = (Estudiantes)e.SelectedItem;
        Navigation.PushAsync(new vActualizarEliminar(objectestudiante));
    }
}