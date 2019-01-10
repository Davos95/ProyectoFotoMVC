using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

#region
/*
---------- PARTICIPANTES -----------------

CREATE PROCEDURE MOSTRARPARTICIPANTES
AS
	SELECT * FROM WORKER;
GO

CREATE PROCEDURE ADDPARTICIPANTE
(@NAME NVARCHAR(30), @CONTACT NVARCHAR(30), @URLCONTACT NVARCHAR(255))
AS
	INSERT INTO WORKER VALUES (@NAME, @CONTACT, @URLCONTACT)
GO

CREATE PROCEDURE DELETEPARTICIPANTE
(@ID INT)
AS
	DELETE FROM WORKER WHERE ID = @ID
GO

CREATE PROCEDURE UPDATEPARTICIPANTE
(@ID INT, @NAME NVARCHAR(30), @CONTACT NVARCHAR(30), @URLCONTACT NVARCHAR(30))
AS
	UPDATE WORKER
	SET NAME = @NAME, CONTACT = @CONTACT, URLCONTACT = @URLCONTACT
	WHERE ID = @ID
GO

----------- TRABAJOS -----------------

CREATE PROCEDURE MOSTRARTRABAJOS
AS
	SELECT * FROM WORK;
GO

CREATE PROCEDURE ADDTRABAJO
(@NAME NVARCHAR(100))
AS
	INSERT INTO WORK VALUES(@NAME)
GO

CREATE PROCEDURE DELETETRABAJO
(@ID INT)
AS
	DELETE FROM WORK WHERE ID = @ID
GO





CREATE PROCEDURE MOSTRARSESIONES
AS
	SELECT * FROM SESION;
GO




*/
#endregion

namespace ProyectoFotoMVC.Models
{
    public class HelperPartnerWork
    {
        EntidadPicturesManager entity;

        public HelperPartnerWork()
        {
            entity = new EntidadPicturesManager();
        }


        //PARTNERS

        public List<WORKER> GetPartners()
        {

            List<WORKER> participantes = this.entity.MOSTRARPARTICIPANTES().ToList();
            return participantes;
        }

        public void InsertPartner(String name, String contact, String urlContact)
        {
            this.entity.ADDPARTICIPANTE(name, contact, urlContact);
        }

        public void RemovePartner(int id)
        {
            this.entity.DELETEPARTICIPANTE(id);
        }

        public void UpdatePartner(int id, String name, String contact, String urlContact)
        {
            this.entity.UPDATEPARTICIPANTE(id, name, contact, urlContact);
        }


        //Works
        public List<WORK> GetWorks()
        {
           List<WORK> works =  this.entity.MOSTRARTRABAJOS().ToList();
           return works;
        }

        public void InsertWork(String name)
        {
            this.entity.ADDTRABAJO(name);
        }

        public void DeleteWork(int id)
        {
            this.entity.DELETETRABAJO(id);
        }
    }
}