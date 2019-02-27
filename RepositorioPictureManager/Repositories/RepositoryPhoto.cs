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

CREATE PROCEDURE ORDERPHOTO
(@IDPHOTO INT, @NUMORDER INT)
AS
	UPDATE PHOTO SET ORDERPHOTO = @NUMORDER
	WHERE ID = @IDPHOTO;
GO

CREATE PROCEDURE MOVEPHOTOS
(@IDPHOTO INT, @IDSESION INT)
AS
	DECLARE @COUNT INT
	
	SELECT @COUNT = COUNT(*) 
	FROM PHOTO
	WHERE IDSESION = @IDSESION

	UPDATE PHOTO 
	SET IDSESION = @IDSESION,
	ORDERPHOTO = @COUNT
	WHERE ID = @IDPHOTO
	
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

        public void MovePhotosSesion(int idPhoto, int idSesion)
        {
            this.entity.MOVEPHOTOS(idPhoto, idSesion);
        }

        public void OrderPhotos(int idPhoto, int orderNumber)
        {
            this.entity.ORDERPHOTO(idPhoto, orderNumber);
        }


        public void RemovePhotos(int idPhoto)
        {
            this.entity.DELETEPHOTO(idPhoto);
        }
    }
}
