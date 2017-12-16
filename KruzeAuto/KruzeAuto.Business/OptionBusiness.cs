using KruzeAuto.Business.Core;
using KruzeAuto.Model;
using System;
using System.Collections.Generic;

namespace KruzeAuto.Business
{
    public class OptionBusiness
    {
        #region Methdos
        public void Insert(Option option)
        {
            BusinessContext.Current.RepositoryContext.OptionRepository.Insert(option);
        }

        public void Update(Option option)
        {
            BusinessContext.Current.RepositoryContext.OptionRepository.Update(option);
        }

        public void Delete(Guid optionID)
        {
            BusinessContext.Current.RepositoryContext.OptionRepository.Delete(optionID);
        }

        public List<Option> ReadAll()
        {
            return BusinessContext.Current.RepositoryContext.OptionRepository.ReadAll();
        }

        public Option ReadByID(Guid optionID)
        {
            return BusinessContext.Current.RepositoryContext.OptionRepository.ReadByID(optionID);
        }
        #endregion
    }
}
