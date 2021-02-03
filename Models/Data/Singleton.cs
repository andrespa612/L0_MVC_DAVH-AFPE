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

        private char[] Abecedario = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'Ñ', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

        private bool GreaterThan(string A, string B)
        {
            int WordLength = A.Length;
            if (B.Length < WordLength)
            {
                WordLength = B.Length;
            }
            for (int j = 0; j < WordLength; j++)
            {
                int IndexOfA = -1;
                int IndexOfB = -1;
                for (int i = 0; i < Abecedario.Length; i++)
                {
                    if (Abecedario[i] == A[j])
                    {
                        IndexOfA = i;
                    }
                    if (Abecedario[i] == B[j])
                    {
                        IndexOfB = i;
                    }
                    if (IndexOfB >= 0 && IndexOfA >= 0)
                    {
                        break;
                    }
                }
                if (IndexOfA < IndexOfB)
                {
                    return true;
                }
                else if (IndexOfA > IndexOfB)
                {
                    return false;
                }
            }
            if (B.Length > A.Length)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void SortByName()
        {

            for (int i = 0; i < Singleton.Instance.ClientsList.Count - 1; i++)
            {
                for (int j = i+1; j < Singleton.Instance.ClientsList.Count; j++)
                {
                    if (GreaterThan(Singleton.Instance.ClientsList[j].Name, Singleton.Instance.ClientsList[i].Name))
                    {
                        var temp = Singleton.Instance.ClientsList[i];
                        Singleton.Instance.ClientsList[i] = Singleton.Instance.ClientsList[j];
                        Singleton.Instance.ClientsList[j] = temp;
                    }
                }
            }            
        }

        public void SortByLastName()
        {

            for (int i = 0; i < Singleton.Instance.ClientsList.Count - 1; i++)
            {
                for (int j = i+1; j < Singleton.Instance.ClientsList.Count; j++)
                {
                    if (GreaterThan(Singleton.Instance.ClientsList[j].Lastname, Singleton.Instance.ClientsList[i].Lastname))
                    {
                        var temp = Singleton.Instance.ClientsList[i];
                        Singleton.Instance.ClientsList[i] = Singleton.Instance.ClientsList[j];
                        Singleton.Instance.ClientsList[j] = temp;
                    }
                }
            }            
        }
    }
}

