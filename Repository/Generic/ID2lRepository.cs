
using RestWithASPNETUdemy.Configurations;
using RestWithASPNETUdemy.Model.Base;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Repository.Generic
{
    public interface ID2lRepository<T, D, F>
    {
        List<T> GetList(string servico, List<ParamLista> param);
        T Get(string servico, List<ParamLista> param);
        T Post(string servico, List<ParamLista> param, D body);
        T Put(string servico, List<ParamLista> param, F body);
        T Delete(string servico, List<ParamLista> param);
    }
}
