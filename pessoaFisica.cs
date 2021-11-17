using System;

namespace cadastroPessoa
{
    public class pessoaFisica : Pessoa
    {
        public string cpf { get; set; }
        
        public DateTime dataNasc { get; set; }

        public override double pagarImposto(float rendimento){
            if (rendimento <= 1500)
            {
                return 0;
            }
            else if (rendimento > 1500 && rendimento <= 5000)
            {
                return rendimento * .03;
            }
            else
            {
                return rendimento * .05;
            }

        }  

        public bool validarDataNasc(DateTime data){

        DateTime dataAtual = DateTime.Today;

        double anos = (dataAtual - dataNasc).TotalDays / 365;

        if (anos >= 18){

            return true;
        }
         else {
            
            return false;

        }
        
      }
   }
}
