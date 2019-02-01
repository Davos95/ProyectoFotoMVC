
using RepositorioPictureManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


#region PROCEDURE
/*
CREATE PROCEDURE GETUSER
(@NICK NVARCHAR(25), @PWD NVARCHAR(25))
AS
    SELECT *

    FROM USERS

    WHERE NICK LIKE @NICK

    AND PWD LIKE @PWD;
GO
*/
#endregion

namespace RepositorioPictureManager.Repositories
{
    public class RepositoryLogin : IRepositoryLogin
    {
        EntidadPicturesManager entity;
        public RepositoryLogin(EntidadPicturesManager entity)
        {
            this.entity = entity;
        }

        public USERS GetUser(String nick, String pwd)
        {
            USERS user = this.entity.GETUSER(nick, pwd).FirstOrDefault();
            return user;
        }

        private String createMD5Hash(String input)
        {
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("X2"));
            }
            return sb.ToString();            
        }
    }
}
