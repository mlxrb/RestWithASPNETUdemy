using RestWithASPNETUdemy.Data.Converter.Contract;
using RestWithASPNETUdemy.Data.VO.D2lVO;
using RestWithASPNETUdemy.Model;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASPNETUdemy.Data.Converter.Implementations
{
    public class PeriodoConverter : IParser<OrgUnitVO, Periodo>, IParser<Periodo, OrgUnitVO>
    {
        private string _action = "";        
        public Periodo Parse(OrgUnitVO origin)
        {
            if (origin == null) return null;            
            return new Periodo
            {
                IdentifierAva = origin.Identifier,
                Type = origin.Type.Code,
                Action = _action,
                Code = origin.Code,
                Name = origin.Name,
                CustomCode = _action,
                MomentExec = System.DateTime.Today
            };
        }

        public Periodo ParseFilial(OrgUnitVO origin, string action)
        {
            _action = action;            
            return Parse(origin);
        }

        public OrgUnitVO Parse(Periodo origin)
        {
            if (origin == null) return null;

            OrgUnitTypeInfoVO TypeLista = new OrgUnitTypeInfoVO
            {
                Id = 0,
                Code = origin.Type,
                Name = origin.Type
            };

            return new OrgUnitVO
            {
                Identifier = origin.IdentifierAva,
                Name = origin.Name,
                Code = origin.Code,                
                Type = TypeLista
            };
        }

        public List<Periodo> Parse(List<OrgUnitVO> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }

        public List<OrgUnitVO> Parse(List<Periodo> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
