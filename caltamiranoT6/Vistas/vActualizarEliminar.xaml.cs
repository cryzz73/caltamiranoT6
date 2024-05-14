using caltamiranoT6.Models;
using System.Net;

namespace caltamiranoT6.Vistas;

public partial class vActualizarEliminar : ContentPage
{
    private string idAEliminar;

    public vActualizarEliminar(Estudiantes datos)
    {
        InitializeComponent();
        txtCodigo.Text = datos.codigo.ToString();
        txtNombre.Text = datos.nombre.ToString();
        txtApellido.Text = datos.apellido.ToString();
        txtEdad.Text = datos.edad.ToString();
    }

    private void btnActualizar_Clicked(object sender, EventArgs e)
    {

    }

    private void btnEliminar_Clicked(object sender, EventArgs e)
    {
        try
        {
            WebClient cliente = new WebClient();

            var parametros = new System.Collections.Specialized.NameValueCollection();
            parametros.Add("nombre", txtNombre.Text);
            parametros.Add("codigo", txtCodigo.Text);
            parametros.Add("apellido", txtApellido.Text);
            parametros.Add("edad", txtEdad.Text);

            cliente.UploadValues("http://192.168.17.23/appmovil/delete.php", "POST", parametros);
            // Aseg�rate de cambiar la URL y el nombre del archivo PHP seg�n tu configuraci�n

            // Si necesitas alguna confirmaci�n o manejo posterior despu�s de la eliminaci�n, puedes hacerlo aqu�

            // Por ejemplo, si quieres navegar a una p�gina despu�s de la eliminaci�n:
            Navigation.PushAsync(new Vistas.vHome());
        }
        catch (Exception ex)
        {
            DisplayAlert("Alerta", ex.Message, "Cerrar");
        }

    }
}
