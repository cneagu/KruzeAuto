using KruzeAuto.RepositoryAbstraction.Core;
using System.Configuration;
using KruseAuto.Repository.Core;

namespace KruzeAuto.RepositoryFactory
{
    public class Getter
    {
        private static string _framework = ConfigurationManager.AppSettings["framework"];

        public static IRepositoryContext GetRepository()
        {
            if (_framework == "ADONet")
            {
                return new RepositoryContext();                
            }
            return default(IRepositoryContext);
        }
    }
}
