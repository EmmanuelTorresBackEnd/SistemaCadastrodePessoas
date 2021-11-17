using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace cadastroPessoa
{
    class program
    {
        static void Main(string[] args)
        {
            List<pessoaFisica> listaPf = new List<pessoaFisica>();
            List<pessoaJuridica> listaPj = new List<pessoaJuridica>();

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            
            Console.WriteLine(@$"
==================================================
|        Bem vindo ao sistema de cadastro        |
|                   de pessoas                   |
|               fisica e jurídica                |
==================================================
");
        Console.ResetColor();
        Thread.Sleep(1000);

        Console.Write("Iniciando");
        Thread.Sleep(1000);
        for (var i = 0; i < 5; i++)
        {
            Console.Write(".");
            Thread.Sleep(300);
        }
        Console.ResetColor();

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.DarkBlue;

        string opcao;
        do
        {
            Console.WriteLine(@$"
====================================================
|        Selecione uma das opções abaixo           |
|--------------------------------------------------|
|                 PESSOA FÍSICA                    |
|            1 - Cadastrar Pessoa Física           |
|            2 - Listar Pessoa Física              |
|            3 - Remover Pessoa Física             |
|                                                  |
|                 PESSOA JURÍDICA                  |
|            4 - Cadastrar Pessoa Jurídica         |
|            5 - Listar Pessoa Jurídica            |
|            6 - Remover Pessoa Juridica           |
|                                                  |
|            0 - Sair                              |
====================================================
");
        Console.ResetColor();
        opcao = (Console.ReadLine());

        switch (opcao)
        {
            case "1":

            pessoaFisica pFisica = new pessoaFisica();
            pessoaFisica novapFisica = new pessoaFisica();
            endereco end = new endereco();

            Console.WriteLine($"Digite seu Nome");
            novapFisica.nome = Console.ReadLine();
            
            Console.WriteLine($"Digite o seu CPF (apenas números)");
            novapFisica.cpf = Console.ReadLine();

            Console.WriteLine($"Digite sua Data de Nascimento  AAAA-MM-DD");
            novapFisica.dataNasc = DateTime.Parse(Console.ReadLine());
            
            bool idadeValida = pFisica.validarDataNasc(novapFisica.dataNasc);
            
            if (idadeValida == true)
            {
            }
            else
            {
                Console.WriteLine($"Cadastro nao permitido para menores de idade");
            }
            
            Console.WriteLine($"Digite seu e-mail");
            novapFisica.email = Console.ReadLine();
            
            Console.WriteLine($"Digite seu rendimento (apenas números)");
            novapFisica.rendimento = float.Parse(Console.ReadLine());
            
            
            Console.WriteLine($"Digite o nome da Rua");
            end.logradouro = Console.ReadLine();
            
            Console.WriteLine($"Digite o número");
            end.numero = int.Parse(Console.ReadLine());

            Console.WriteLine($"Digite o complemento (Caso não possua, aperte ENTER!) ");
            end.complemento = Console.ReadLine();
            
            Console.WriteLine($"O endereço é comercial? S/N");
            string endComercial = Console.ReadLine().ToUpper();
            
            if (endComercial == "S")
             {
               end.enderecoComec = true;
             }
            else
             {
                end.enderecoComec = false;
             }
             
             novapFisica.endereco = end;

            Thread.Sleep(500);
            Console.WriteLine($"Cadastro concluido");
            listaPf.Add(novapFisica);
            Thread.Sleep(500);
            Console.WriteLine(pFisica.pagarImposto(novapFisica.rendimento));
            
                
            

                using (StreamWriter sw = new StreamWriter($"{novapFisica.nome}.txt"))
                {
                     sw.Write($"{novapFisica.nome}, {novapFisica.cpf}, {novapFisica.dataNasc}");
                }

                using (StreamReader sr = new StreamReader($"{novapFisica.nome}.txt"))
                {
                     string linha;

                     while ((linha = sr.ReadLine()) != null)
                     {
                         Console.WriteLine($"{linha}");
                         
                     }
                }

                break;

            case "2":

                    foreach (pessoaFisica cadaItem in listaPf)
                    {
                        Console.WriteLine($"Nome:{cadaItem.nome}, CPF:{cadaItem.cpf}, Data de Nascimento:{cadaItem.dataNasc}, E-mail:{cadaItem.email}, Endereço:{cadaItem.endereco.logradouro}, {cadaItem.endereco.numero}"); 
                    }
                
                break;

            case "3":
                    Console.WriteLine($"Digite o CPF que deseja remover do sistema");
                    string cpfProcurado = Console.ReadLine();
                    
                    pessoaFisica pessoaEncontrada = listaPf.Find(cadaItem => cadaItem.cpf == cpfProcurado);

                    if (pessoaEncontrada != null)
                    {
                    listaPf.Remove(pessoaEncontrada);
                    Console.WriteLine($"Cadastro removido!");
                    }
                    else 
                    {
                        Console.WriteLine($"CPF não encontrado");
                    }

                break;

            case "4":
                        
            pessoaJuridica pj = new pessoaJuridica();  //puxar o metodo

            pessoaJuridica novaPjuridica = new pessoaJuridica(); //receber o valor

            endereco endPj = new endereco();

            Console.WriteLine($"Digite a sua Razão Social");
            novaPjuridica.razaoSocial = Console.ReadLine();
            
            Console.WriteLine($"Digite o seu CNPJ");
            novaPjuridica.cnpj = Console.ReadLine();

            for (var i = 0; i < 10 ; i++)
            {
                
            }

            if (pj.validarCnpj(novaPjuridica.cnpj))
            { 
                Console.WriteLine("CNPJ Valido !!!");
            }
            else {
                Console.WriteLine($"Cnpj inválido");   
            }
            
            Console.WriteLine($"Digite o seu rendimento (apenas numeros)");
            novaPjuridica.rendimento = float.Parse(Console.ReadLine());
            
            Console.WriteLine($"Digite o nome da Rua");
            endPj.logradouro = Console.ReadLine();
            
            Console.WriteLine($"Digite o número");
            endPj.numero = int.Parse(Console.ReadLine());

            Console.WriteLine($"Digite o complemento (Caso não possua, Aperte ENTER!)");
            endPj.complemento = Console.ReadLine();
            
            Console.WriteLine($"O endereço é Comercial? S/N");
            string endComercialPj = Console.ReadLine().ToUpper();
            
            if (endComercialPj == "S")
             {
               endPj.enderecoComec = true;
             }
            else
             {
                endPj.enderecoComec = false;
             }

            novaPjuridica.endereco = endPj;
            
            Thread.Sleep(500);
            Console.WriteLine($"Cadastro concluido");
            listaPj.Add(novaPjuridica);
            Thread.Sleep(500);
            Console.WriteLine(pj.pagarImposto(novaPjuridica.rendimento));
            




                pj.verificarArquivo(pj.caminho);
                pj.Inserir(novaPjuridica);


                break;

            case "5":
                    foreach (var cadaItemPj in listaPj)
                    {
                        Console.WriteLine($"Razão Social:{cadaItemPj.razaoSocial}, CNPJ:{cadaItemPj.cnpj}, Endereço:{cadaItemPj.endereco.logradouro}, {cadaItemPj.endereco.numero}");     
                    }

                break;

            case "6":
                    Console.WriteLine($"Digite o CNPJ que deseja remover do sistema");
                    string cnpjProcurado = Console.ReadLine();
                    
                    pessoaFisica pessoaJuridEncontrada = listaPf.Find(cadaItem => cadaItem.cpf == cnpjProcurado);

                    if (pessoaJuridEncontrada != null)
                    {
                    listaPf.Remove(pessoaJuridEncontrada);
                        Console.WriteLine($"Cadastro removido!");
                    }
                    else 
                    {
                        Console.WriteLine($"CNPJ não encontrado");
                    }

                break;

            case "0":
                    
                    Console.Clear();
                    Console.WriteLine($"Obrigado por utilizar nosso sistema!!");

                    Console.Write("Finalizando");
                    Thread.Sleep(1000);
                    for (var i = 0; i < 5; i++)
                    {
                    Console.Write(".");
                    Thread.Sleep(300);
                    }
                    Console.ResetColor();
                    break;

                    default:
                    Console.ResetColor();
                    Console.WriteLine($"Opção inválida, selecione uma opção válida");
                    break;

        }
                    
        } while (opcao != "0");
        
        }
    }
}