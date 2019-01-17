using RepositorioPictureManager.Models;
using RepositorioPictureManager.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

#region PROCEDURES
/*

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





*/
#endregion

namespace RepositorioPictureManager.Repositories
{
    public class RepositoryPartner : IRepositoryPartner
    {
        EntidadPicturesManager entity;

        public RepositoryPartner(EntidadPicturesManager entity)
        {
            this.entity = entity;
        }
        
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



    }
}