using RepositorioPictureManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region PROCEDURES
/*
CREATE PROCEDURE INSERTSESION
(@NAME NVARCHAR(25), @DESCRIPTION TEXT, @DATE DATE, @IDCOMISION INT)
AS
	INSERT INTO SESION VALUES(@NAME,@DESCRIPTION,NULL,@DATE,@IDCOMISION)
GO

CREATE PROCEDURE GETSESION
AS
SELECT * FROM SESION;
GO

*/
#endregion
namespace RepositorioPictureManager.Repositories
{
    public class RepositorySesion : IRepositorySesion
    {
        EntidadPicturesManager entity;
        public RepositorySesion(EntidadPicturesManager entity)
        {
            this.entity = entity;
        }

        public List<SESION> GetSesions()
        {
            var sesion = this.entity.GETSESION();
            return sesion.ToList();
        }

        public void InsertSesion(String name, String description, DateTime date, int comision)
        {
            this.entity.INSERTSESION(name, description, date, comision);
        }

    }
}
