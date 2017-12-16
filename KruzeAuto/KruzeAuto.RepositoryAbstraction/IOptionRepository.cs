using KruzeAuto.Model;
using System;
using System.Collections.Generic;

namespace KruzeAuto.RepositoryAbstraction
{
    public interface IOptionRepository
    {
        void Insert(Option option);
        void Update(Option option);
        void Delete(Guid optionID);
        List<Option> ReadAll();
        Option ReadByID(Guid optionID);
    }
}
