
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

    }
}
