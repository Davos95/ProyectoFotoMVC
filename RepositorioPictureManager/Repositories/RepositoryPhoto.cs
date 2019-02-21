using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositorioPictureManager.Models;
#region PROCEDURES
/*
 CREATE PROCEDURE GETPHOTOS
(@IDSESION INT)
AS
	SELECT * FROM PHOTO
	WHERE IDSESION = @IDSESION
	ORDER BY ORDERPHOTO DESC;
GO

CREATE PROCEDURE INSERTPHOTO
(@NAMEPHOTO TEXT, @IDSESION INT)
AS
	DECLARE @NUM INT
	SELECT @NUM = COUNT(*) FROM PHOTO WHERE IDSESION = @IDSESION
	INSERT INTO PHOTO VALUES(@NAMEPHOTO,@IDSESION,@NUM)
GO

*/
#endregion
namespace RepositorioPictureManager.Repositories
{
    public class RepositoryPhoto : IRepositoryPhoto
    {
        EntidadPicturesManager entity;
        public RepositoryPhoto(EntidadPicturesManager entity)
        {
            this.entity = entity;
        }
        public List<PHOTO> GetPhotos(int idSesion)
        {
            return this.entity.GETPHOTOS(idSesion).ToList();
        }

        public void InsertPhoto(string name, int idSesion)
        {
            this.entity.INSERTPHOTO(name, idSesion);
        }

        public void MovePhotosSesion()
        {
            throw new NotImplementedException();
        }

        public void OrderPhotos()
        {
            throw new NotImplementedException();
        }

        public void RemovePhotos()
        {
            throw new NotImplementedException();
        }
    }
}
