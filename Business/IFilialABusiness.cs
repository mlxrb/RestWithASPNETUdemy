using RestWithASPNETUdemy.Data.VO.D2lVO;
using RestWithASPNETUdemy.Model;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Business
{
    public interface IFilialABusiness
    {
        //acessar banco do log
        Filial Create(Filial filial);
        Filial FindByID(long id);
        List<Filial> FindAll();
        Filial Update(Filial filial);
        void Delete(long id);

        //consumo do webservice d2l
        OrgUnitVO OrgStructure(long id);
        List<OrgUnitVO> OrgStructureChild(long id);
        OrgUnitVO CreateD2l(OrgUnitCreateDataVO filial);
        OrgUnitVO UpdateD2l(long id, OrgUnitPropertiesVO filial);

    }
}
