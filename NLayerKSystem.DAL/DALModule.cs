using Autofac;
using NLayerKSystem.DAL.Interfaces;
using NLayerKSystem.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerKSystem.DAL
{
    public class DALModule: Module
    {
        private string connectionString;

        public DALModule(string connectionString) {
            this.connectionString = connectionString;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EFUnitOfWork>().As<IUnitOfWork>().WithParameter("connectionString", connectionString);
        }
    }
}
