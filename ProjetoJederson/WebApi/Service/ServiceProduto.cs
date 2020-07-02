using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Service
{
    public class ServiceProduto
    {
        public ServiceCasquinha serviceCasquinha;
        public ServiceAcompanhamentos serviceAcompanhamentos;
        public ServiceAdicional serviceAdicional;
        public ServiceSabores serviceSabores;
      
        public ServiceProduto(Contexto db)
        {
            serviceAcompanhamentos = new ServiceAcompanhamentos(db);
            serviceAdicional = new ServiceAdicional(db);
            serviceSabores = new ServiceSabores(db);
            serviceCasquinha = new ServiceCasquinha(db);
                    }
    }
}
