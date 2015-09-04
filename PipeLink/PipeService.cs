using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace PipeLink
{
    [ServiceBehavior (InstanceContextMode = InstanceContextMode.Single)]

    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" à la fois dans le code et le fichier de configuration.
    public class PipeService : IPipeService
    {

        public static string URI
           = "net.pipe://localhost/Pipe";

        // This is when we used the HTTP bindings.
        // = "http://localhost:8000/Pipe";

        #region IPipeService Members

        public void PipeIn(int data)
        {
            if (DataReady != null)
                DataReady(data);
        }

        public delegate void DataIsReady(int hotData);
        public DataIsReady DataReady = null;

        #endregion
    }
}
