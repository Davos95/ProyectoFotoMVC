﻿using RepositorioPictureManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositorioPictureManager.Repositories
{
    public interface IRepositoryLogin
    {
        USERS GetUser(String nick, String pwd);

    }
}
