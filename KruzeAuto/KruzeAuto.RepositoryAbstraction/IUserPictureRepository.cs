using KruzeAuto.Model;
using System;
using System.Collections.Generic;

namespace KruzeAuto.RepositoryAbstraction
{
    public interface IUserPictureRepository
    {
        void Insert(UserPicture userPicture);
        void Update(UserPicture userPicture);
        void Delete(Guid userID);
        List<UserPicture> ReadAll();
        UserPicture ReadByID(Guid userID);
    }
}
