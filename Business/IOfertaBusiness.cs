using RestWithASPNETUdemy.Data.VO.D2lVO;
using RestWithASPNETUdemy.Model;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Business
{
    public interface IOfertaBusiness
    {
        //acessar banco do log
        Oferta Create(Oferta dado);
        Oferta FindByID(long id);
        List<Oferta> FindAll();
        Oferta Update(Oferta dado);
        void Delete(long id);

        //consumo do webservice d2l
        OfertaVO getOfertas(long id);
        List<OrgUnitVO> OrgStructureAncestorsOferta(long id);
        OfertaVO CreateD2lOferta(OfertaVOPost dado);
        OfertaVO UpdateD2lOferta(long id, OfertaVO dado);

    }
}
