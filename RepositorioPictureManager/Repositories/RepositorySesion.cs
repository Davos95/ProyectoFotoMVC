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

CREATE PROCEDURE DELETESESION
(@ID INT)
AS
DELETE FROM SESION WHERE ID = @ID;
GO

CREATE PROCEDURE GETSESIONID
(@ID INT)
AS
SELECT * FROM SESION WHERE ID = @ID;
GO

CREATE PROCEDURE GETPARTNERWORKBYSESION
(@ID INT)
AS
	SELECT sw.IDWORKER as IDPARTNER, p.NAME as PARTNER, sw.IDWORK as IDWORK, w.NAME as WORK
FROM SESION_WORKER sw
INNER JOIN SESION s
on s.ID =  sw.IDSESION
INNER JOIN WORK w
on w.ID = sw.IDWORK
INNER JOIN WORKER p
ON sw.IDWORKER = p.ID
WHERE s.ID = @ID;

GO

CREATE PROCEDURE ADDPARTNERWORKINTOSESION
(@IDSESION INT, @IDPARTER INT, @IDWORK INT)
AS
	INSERT INTO SESION_WORKER VALUES (@IDSESION,@IDPARTER,@IDWORK)
	
GO

CREATE PROCEDURE DELETEPARTERWORKFROMSESION
(@ID INT, @IDPARTNER INT, @IDWORK INT)
AS
DELETE FROM SESION_WORKER WHERE IDSESION = @ID AND IDWORKER = @IDPARTNER AND IDWORK = @IDWORK;
GO

CREATE PROCEDURE MODIFYSESION
(@ID INT, @NAME NVARCHAR(250), @DESCRIPTION TEXT, @DATESESION DATE, @IDCOMISION INT)
AS
UPDATE SESION 
SET NAME = @NAME, 
DESCRIPTION = @DESCRIPTION, 
DATESESION = @DATESESION, 
IDCOMISION = @IDCOMISION
WHERE ID = @ID
GO
*/
#endregion
namespace RepositorioPictureManager.Repositories
{
    public class RepositorySesion : IRepositorySesion
    {
        EntityPictureManager entity;
        public RepositorySesion(EntityPictureManager entity)
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

        public void DeleteSesion(int id)
        {
            this.entity.DELETESESION(id);
        }

        public SESION GetSESIONID(int id)
        {
            SESION sesion = this.entity.GETSESIONID(id).FirstOrDefault();
            return sesion;
        }


        #region EDIT SESION
        public void AddPartnerWorkIntoSesion(int idSesion, int idPartner, int idWork)
        {
            this.entity.ADDPARTNERWORKINTOSESION(idSesion, idPartner, idWork);
        }

        public List<GETPARTNERWORKBYSESION_Result> GetPartnerWorkBySesion(int idSesion)
        {
            return this.entity.GETPARTNERWORKBYSESION(idSesion).ToList();
        }

        public void DeletePartnerWorkFromSesion(int idSesion, int idPartner, int idWork)
        {
            this.entity.DELETEPARTERWORKFROMSESION(idSesion, idPartner, idWork);
        }

        public void ModifySesion(int idSesion, String name, String desciption, DateTime date, int idComision)
        {
            this.entity.MODIFYSESION(idSesion, name, desciption, date, idComision);
        }

        #endregion
    }
}
