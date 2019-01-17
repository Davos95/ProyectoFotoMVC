
using RepositorioPictureManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region PROCEDURES
/*
 * 
CREATE PROCEDURE MOSTRARTRABAJOS
AS

    SELECT* FROM WORK;
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

*/
#endregion

namespace RepositorioPictureManager.Repositories
{
    public class RepositoryWork : IRepositoryWork
    {
        EntidadPicturesManager entity;

        public RepositoryWork(EntidadPicturesManager entity) {
            this.entity = entity;
        }

        public List<WORK> GetWORKs()
        {
            List<WORK> works = this.entity.MOSTRARTRABAJOS().ToList();
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
