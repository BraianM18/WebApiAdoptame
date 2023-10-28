using API_Adoptame.DAL.Entities;

namespace API_Adoptame.Domain.Interfaces
{
    public interface ICountryService
    {
        //Aqui relacionamos las firmas de los metodos
        //Primera firma del metodo que sirve para exponer a los controladores
        //Task= tarea a realizar   Await= que es el que va con el metodo que estoy invoncando Async = el metodo que se vuelve asincronico
        //para una lista podemos usar esta IEnumerable para listas estaticas hay mas (IList y Icolletion)
        //tiporetornolista  listPais return   metodo
        Task<IEnumerable<Country>> GetCountriesAsync();//Esto es una firma de metodo, aqui retorno esta lista
        //La logica de este metodo estara en la carpeta de servicios
        Task<Country> CreateCountryAsync(Country country);//Aqui necesito el objeto completo, y este ya tiene nombre,fecha de modificacion y ID(Lo veo en entities)
    }
}
