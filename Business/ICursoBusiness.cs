using RestWithASPNETUdemy.Data.VO.D2lVO;
using RestWithASPNETUdemy.Model;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Business
{
    public interface ICursoBusiness
    {
        //acessar banco do log
        Curso Create(Curso dado);
        Curso FindByID(long id);
        List<Curso> FindAll();
        Curso Update(Curso dado);
        void Delete(long id);

        //consumo do webservice d2l
        OrgUnitVO OrgStructureCurso(long id);
        List<OrgUnitVO> OrgStructureChildCurso(long id);
        OrgUnitVO CreateD2lCurso(OrgUnitCreateDataVO dado);
        OrgUnitVO UpdateD2lCurso(long id, OrgUnitPropertiesVO dado);

    }
}
