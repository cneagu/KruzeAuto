using KruzeAuto.RepositoryAbstraction.Core;
using System.Configuration;
using KruseAuto.Repository.Core;

namespace KruzeAuto.RepositoryFactory
{
    public class Getter
    {
        //private static string _framework = ConfigurationManager.AppSettings["framework"];
        
        public static IRepositoryContext GetRepository()
        {
            bool framework = true;
            if (framework)
            {
                return new RepositoryContext();                
            }
            return default(IRepositoryContext);
        }
    }
}
