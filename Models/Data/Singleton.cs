using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace L0_MVC_DAVH_AFPE.Models.Data
{
    public sealed class Singleton
    {
        private readonly static Singleton _instance = new Singleton();
        public List<ClientsModel> ClientsList;
        private Singleton()
        {
            ClientsList = new List<ClientsModel>();
        }

        public static Singleton Instance
        {
            get
            {
                return _instance;
            }
        }
    }
}

