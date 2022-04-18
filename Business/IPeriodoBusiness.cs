using RestWithASPNETUdemy.Data.VO.D2lVO;
using RestWithASPNETUdemy.Model;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Business
{
    public interface IPeriodoBusiness
    {
        //acessar banco do log
        Periodo Create(Periodo dado);
        Periodo FindByID(long id);
        List<Periodo> FindAll();
        Periodo Update(Periodo dado);
        void Delete(long id);

        //consumo do webservice d2l
        OrgUnitVO OrgStructurePeriodo(long id);
        List<OrgUnitVO> OrgStructureChildPeriodo(long id);
        OrgUnitVO CreateD2lPeriodo(OrgUnitCreateDataVO dado);
        OrgUnitVO UpdateD2lPeriodo(long id, OrgUnitPropertiesVO dado);

    }
}
