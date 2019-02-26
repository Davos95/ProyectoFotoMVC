using RepositorioPictureManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositorioPictureManager.Repositories
{
    public interface IRepositoryPhoto
    {
        List<PHOTO> GetPhotos(int idSesion);
        void InsertPhoto(String name, int idSesion);
        void MovePhotosSesion();
        void OrderPhotos();
        void RemovePhotos(int idPhoto);
        PHOTO GetPhotoById(int idPhoto);
    }
}
