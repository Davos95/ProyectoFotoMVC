using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

#region
/*
 CREATE PROCEDURE MOSTRARSESIONES
AS
	SELECT * FROM SESION;
GO

CREATE PROCEDURE ADDSESION
(@NAME NVARCHAR, @DESCRIPTION TEXT, @IDPHOTO INT, @DATESESION DATE, @IDCOMISION INT)
AS
	INSERT INTO SESION VALUES (@NAME, @DESCRIPTION, @IDPHOTO, @DATESESION, @IDCOMISION);
GO

*/
#endregion

namespace ProyectoFotoMVC.Models
{
    public class HelperSesion
    {
        EntidadPicturesManager entity;

        public HelperSesion()
        {
            entity = new EntidadPicturesManager();
        }

        public List<SESION> GetSesion()
        {
            var sql = this.entity.MOSTRARSESIONES();
            List<SESION> sesions = sql.ToList();
            return sesions;
        }
    }
}