using RestWithASPNETUdemy.Data.VO.D2lVO;
using RestWithASPNETUdemy.Model;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Business
{
    public interface ISegmentoBusiness
    {
        //acessar banco do log
        Segmento Create(Segmento segmento);
        Segmento FindByID(long id);
        List<Segmento> FindAll();
        Segmento Update(Segmento segmento);
        void Delete(long id);

        //consumo do webservice d2l
        OrgUnitVO OrgStructureSeg(long id);
        List<OrgUnitVO> OrgStructureChildSeg(long id);
        OrgUnitVO CreateD2lSeg(OrgUnitCreateDataVO segmento);
        OrgUnitVO UpdateD2lSeg(long id, OrgUnitPropertiesVO segmento);

    }
}
