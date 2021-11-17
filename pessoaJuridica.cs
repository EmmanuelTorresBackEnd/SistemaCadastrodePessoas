using System.Collections.Generic;
using System.IO;

namespace cadastroPessoa
{
    public class pessoaJuridica : Pessoa
    {
        public string cnpj { get; set; }
        
        public string razaoSocial { get; set; }

        public string caminho { get; private set; } = "Database/PessoaJuridica.csv";
        
        
        
        public override double pagarImposto(float rendimento){
            if (rendimento <= 5000)
            {
                return rendimento * .06;
            }
            else if (rendimento > 5000 && rendimento <= 10000)
            {
                return rendimento * .08;
            }
            else
            {
                return rendimento * .10;
            }
            
        }
       
        public bool validarCnpj(string cnpj){
            
            if (cnpj.Length == 14 && cnpj.Substring(cnpj.Length - 6, 4) == "0001")
        {
            return (true);
        }
            return (false);
        }




        public string PrepararLinhasCsv(pessoaJuridica pj){

            return $"{pj.cnpj};{pj.razaoSocial}";
        }

        public void Inserir(pessoaJuridica pj){

            string[] linhas = {PrepararLinhasCsv(pj)};

            File.AppendAllLines(caminho, linhas);
        }

        public List<pessoaJuridica> Ler(){

            List<pessoaJuridica> listapJ = new List<pessoaJuridica>();

            string[] linhas = File.ReadAllLines(caminho);

            foreach (var cadaLinha in linhas)
            {
                string[] atributos = cadaLinha.Split(";");

                pessoaJuridica cadaPj = new pessoaJuridica();

                cadaPj.cnpj = atributos[0];
                cadaPj.razaoSocial = atributos[1];
            
                listapJ.Add(cadaPj);

            }

            return listapJ;
            
        }


        
    }
}

