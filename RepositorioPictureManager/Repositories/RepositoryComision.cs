
using RepositorioPictureManager.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

#region PROCEDURES
/*
 CREATE PROCEDURE INSERTCOMISION
(@NAME NVARCHAR(25), @DESCRIPTION TEXT, @PATH TEXT, @PRICE FLOAT)
AS
	DECLARE @ORDERCOMISION INT

	SELECT @ORDERCOMISION = COUNT(*) FROM COMISION

	SET @ORDERCOMISION = @ORDERCOMISION + 1

	INSERT INTO COMISION VALUES(@NAME,@DESCRIPTION, @ORDERCOMISION,@PRICE,@PATH)

GO

CREATE PROCEDURE GETCOMISIONS
AS
	SELECT * FROM COMISION;
GO 

CREATE PROCEDURE DELETECOMISION
(@ID INT)
AS
	DELETE FROM COMISION
	WHERE ID = @ID;
GO

    CREATE PROCEDURE MODIFYSESSION
(@ID INT, @NAME nvarchar(25), @PHOTO text, @DESCRIPTION TEXT, @PRICE float)
AS
	IF(@PHOTO IS NULL)
	BEGIN
		UPDATE COMISION
		SET NAME = @NAME,
		DESCRIPTION = @DESCRIPTION,
		PRICE = @PRICE
		WHERE ID = @ID;
	END
	ELSE
	BEGIN
		UPDATE COMISION
			SET NAME = @NAME,
			PHOTO = @PHOTO,
			DESCRIPTION = @DESCRIPTION,
			PRICE = @PRICE
			WHERE ID = @ID;
	END
GO

*/
#endregion

namespace RepositorioPictureManager.Repositories
{
    public class RepositoryComision : IRepositoryComision
    {
        EntidadPicturesManager entity;
        public RepositoryComision(EntidadPicturesManager entity)
        {
            this.entity = entity;
        }

        public void InsertComision(String name, String description, String folder, HttpPostedFileBase image, float price)
        {
            String path = Path.Combine(folder, Path.GetFileName(image.FileName));
            entity.INSERTCOMISION(name, description, path, price);
        } 
        public List<COMISION> GetCOMISIONS()
        {
            var comisions = this.entity.GETCOMISIONS().ToList();
            return comisions;
        }

        public void DeleteComision(int id, String folder)
        {
            COMISION comision = GetComisionByID(id);
            String file = comision.PHOTO.Split('\\')[1];
            File.Delete(folder+"\\"+file);
            this.entity.DELETECOMISION(id);
        }

        private COMISION GetComisionByID(int id)
        {
            var comisions = GetCOMISIONS().Where(x => x.ID == id);
            return comisions.FirstOrDefault();
        }

        public void ModifyComision(int id, String name, String description, String folder, HttpPostedFileBase image, float price)
        {
            String img;
            if(image == null)
            {
                img = null;
                
            } else
            {
                img = image.FileName;
            }
            this.entity.MODIFYSESSION(id, name, img, description, price);
        }
    }
}
