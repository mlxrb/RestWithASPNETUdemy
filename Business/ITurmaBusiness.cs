using RestWithASPNETUdemy.Data.VO.D2lVO;
using RestWithASPNETUdemy.Model;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Business
{
    public interface ITurmaBusiness
    {
        //acessar banco do log
        Turma Create(Turma dado);
        Turma FindByID(long id);
        List<Turma> FindAll();
        Turma Update(Turma dado);
        void Delete(long id);

        //consumo do webservice d2l
        CourseTemplateVO OrgStructureTurma(long id);
        List<OrgUnitVO> OrgStructureChildTurma(long id);
        CourseTemplateVO CreateD2lTurma(CreateCourseTemplateVO dado);
        CourseTemplateVO UpdateD2lTurma(long id, CourseTemplateInfoVO dado);

    }
}
