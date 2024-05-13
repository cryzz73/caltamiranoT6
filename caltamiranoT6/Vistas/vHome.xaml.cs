using caltamiranoT6.Models;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace caltamiranoT6.Vistas;

public partial class vHome : ContentPage
{
    private const string url = "http://127.0.0.1:80/appMovil/post.php";
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
}