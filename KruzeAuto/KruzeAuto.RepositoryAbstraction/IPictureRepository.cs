using KruzeAuto.Model;
using System;
using System.Collections.Generic;

namespace KruzeAuto.RepositoryAbstraction
{
    public interface IPictureRepository
    {
        void Insert(Picture picture);
        void Update(Picture picture);
        void Delete(Guid pictureID);
        List<Picture> ReadAll();
        Picture ReadByID(Guid pictureID);
    }
}
