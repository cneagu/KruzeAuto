using KruzeAuto.Business.Core;
using KruzeAuto.Model;
using System;
using System.Collections.Generic;

namespace KruzeAuto.Business
{
    public class PictureBusiness
    {
        #region Methdos
        public void Insert(Picture picture)
        {
            BusinessContext.Current.RepositoryContext.PictureRepository.Insert(picture);
        }

        public void Update(Picture picture)
        {
            BusinessContext.Current.RepositoryContext.PictureRepository.Update(picture);
        }

        public void Delete(Guid pictureID)
        {
            BusinessContext.Current.RepositoryContext.PictureRepository.Delete(pictureID);
        }

        public List<Picture> ReadAll()
        {
            return BusinessContext.Current.RepositoryContext.PictureRepository.ReadAll();
        }

        public Picture ReadByID(Guid pictureID)
        {
            return BusinessContext.Current.RepositoryContext.PictureRepository.ReadByID(pictureID);
        }
        #endregion
    }
}
