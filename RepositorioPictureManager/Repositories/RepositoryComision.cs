
using RepositorioPictureManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositorioPictureManager.Repositories
{
    public class RepositoryComision : IRepositoryComision
    {
        EntidadPicturesManager entity;
        public RepositoryComision(EntidadPicturesManager entity)
        {
            this.entity = entity;
        }

    }
}
