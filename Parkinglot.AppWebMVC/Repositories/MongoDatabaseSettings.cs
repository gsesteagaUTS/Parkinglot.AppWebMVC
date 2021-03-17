using System;

namespace Parkinglot.AppWebMVC.Repositories
{
    public class MongoDatabaseSettings: IMongoDatabaseSettings
    {
        //MongoDatabaseSettings variable = new MongoDatabaseSettings(); //Instancia
        public string UserCollection {get; set;} //= "Books"

        public string ConnectionString {get; set;} // mongodb://148.233.85.168:5057"

        public string DatabaseName {get; set;} //"isabelfloresl"
    }

    public interface IMongoDatabaseSettings
    {
        string UserCollection {get; set;} //= "Books"

        string ConnectionString {get; set;} // mongodb://148.233.85.168:5057"

        string DatabaseName {get; set;} //"isabelflores"
    }
}
