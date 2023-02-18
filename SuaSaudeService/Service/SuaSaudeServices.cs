using SuaSaudeService.Dto;
using SuaSaudeService.Entity;
using SuaSaudeService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuaSaudeService
{
    public class SuaSaudeServices : ISuaSaudeService
    {
        private IClassificacaoIMCRepository _classificacaoIMCRepository;
        public SuaSaudeServices(IClassificacaoIMCRepository classificacaoIMCRepository)
        {
            _classificacaoIMCRepository = classificacaoIMCRepository;
        }
        public double CalcularIMC(double peso, double altura)
        {
            double imc = peso / Math.Pow(altura, 2);
            return Convert.ToDouble(imc.ToString("F2"));
        }



        //metodo implemetado trazendo dados do banco e retornando sua classificação
        public string ClassificarIMC(double imc)   
        {

            List<ClassificacaoIMCEntity> classificacoes = _classificacaoIMCRepository.ConsultarClassificacaoIMC();

            ClassificacaoIMCEntity? classificacao = classificacoes.FirstOrDefault(x => 
                                                                                imc >= x.IMCInicial && 
                                                                                imc <= x.IMCFinal);

            if(classificacao == null) 
            {
                return "IMC NÃO CLASSIFICADO!";
            }

            return classificacao.Descricao;
        }

        public InfoIMCDTO ClassificacaoComCategoria(double peso, double altura)
        {
            double imcCalculado = CalcularIMC(peso, altura);

            string imcClassificado = ClassificarIMC(imcCalculado);

            return new InfoIMCDTO
            {
                IMC = imcCalculado,
                Classificacao = imcClassificado

            };


        }

    }
}


