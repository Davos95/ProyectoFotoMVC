using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unity;
using Unity.AspNet.Mvc;
using RepositorioPictureManager.Repositories;
using RepositorioPictureManager.Models;

namespace ProyectoFotoMVC.App_Start
{
    public class IoCConfigurationUnity
    {
        public static void Configure()
        {
            UnityContainer container = new UnityContainer();
            RegistrarContext(container);
            RegistrarRepos(container);
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        private static void RegistrarContext(UnityContainer container)
        {
            container.RegisterType<EntidadPicturesManager>();
        }

        public static void RegistrarRepos(UnityContainer container)
        {
            container.RegisterType<IRepositoryLogin, RepositoryLogin>();
            container.RegisterType<IRepositoryPartner, RepositoryPartner>();
            container.RegisterType<IRepositoryWork, RepositoryWork>();
            container.RegisterType<IRepositoryComision, RepositoryComision>();
            container.RegisterType<IRepositorySesion, RepositorySesion>();
        }
    }
}