using SuaSaudeService.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuaSaudeService.Interface
{
    public interface ISuaSaudeService
    {
        public double CalcularIMC(double peso, double altura);

        public string ClassificarIMC(double imc);

        public InfoIMCDTO ClassificacaoComCategoria(double peso, double altura);

    }
}
