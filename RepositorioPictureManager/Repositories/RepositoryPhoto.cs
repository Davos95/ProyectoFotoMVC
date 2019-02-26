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
	ORDER BY ORDERPHOTO ASC;
GO

CREATE PROCEDURE INSERTPHOTO
(@NAMEPHOTO TEXT, @IDSESION INT)
AS
	DECLARE @NUM INT
	SELECT @NUM = COUNT(*) FROM PHOTO WHERE IDSESION = @IDSESION
	INSERT INTO PHOTO VALUES(@NAMEPHOTO,@IDSESION,@NUM)
GO

CREATE PROCEDURE DELETEPHOTO
(@IDPHOTO INT)
AS
	DELETE FROM PHOTO
	WHERE ID = @IDPHOTO;
GO
*/
#endregion

namespace RepositorioPictureManager.Repositories
{
    public class RepositoryPhoto : IRepositoryPhoto
    {
        EntityPictureManager entity;
        public RepositoryPhoto(EntityPictureManager entity)
        {
            this.entity = entity;
        }

        public PHOTO GetPhotoById(int idPhoto)
        {
            return this.entity.GETPHOTOBYID(idPhoto).FirstOrDefault();
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


        public void RemovePhotos(int idPhoto)
        {
            this.entity.DELETEPHOTO(idPhoto);
        }
    }
}
