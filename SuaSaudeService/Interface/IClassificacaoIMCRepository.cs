using SuaSaudeService.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuaSaudeService.Interface
{
    public interface IClassificacaoIMCRepository
    {
        public List<ClassificacaoIMCEntity> ConsultarClassificacaoIMC();

    }
}
