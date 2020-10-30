using System;
using System.Collections.Generic;

namespace Projeto2
{
    class Program
    {


        static void Main()
        {
            Login login = new Login(); // INSTÂNCIA LOGIN
            Carrinho carrinho = new Carrinho(); // INSTÂNCIA CARRINHO
            Menu menu = new Menu(); // INSTÂNCIA MENU
            Produtos produtos = new Produtos(); // INSTÂNCIA PRODUTOS
            List<int> opcoes = new List<int>(); // INSTÂNCIA OPCOES

            int session_index = -50; // VARIÁVEL PARA INDEX DO USUÁRIO
            int permissao = 0; // VARIÁVEL PARA PERMISSÃO DO USUÁRIO

            bool verificador = false; //VERIFICADOR PARA FUNÇÕES BOOLEANAS
            string retorno = ""; //VERIFICADOR DO WHILE

            while (verificador == false && retorno != "logado") //WHILE PARA VERIFICAR LOGIN
            {
                retorno = menu.saudacao(); // EXIBE SAUDAÇÃO DO SISTEMA E MOSTRA A OPÇÃO ESCOLHIDA PELA PESSOA

                if (retorno == "login") // INICIA PROCESSO DE LOGIN
                {
                    string username; // VARIÁVEL PARA USUÁRIO DO SISTEMA
                    string passwd; // VARIÁVEL PARA SENHA

                    int contador = 0; // CONTADOR DA QUANTIDADE DE TENTATIVAS
                    string option = "nada"; //VARIÁVEL DA OPÇÃO ESCOLHIDA

                    while (verificador == false) //VERIFICADOR DE LOGIN OU CADASTRO
                    {
                        if (contador >= 3) //ENTRADA APÓS 3 TENTATIVAS
                        {
                            Console.WriteLine("Mais de 3 tentativas, você tem mesmo cadastro?");
                            Console.WriteLine("Digite 0 para que eu te direcione para o menu anterior:");
                            option = Console.ReadLine();

                            if (option == "0") // RETORNA CASO A ESCOLHA SEJA SAIR
                            {
                                retorno = "nada";
                                break;
                            }

                            contador = 0;
                        }

                        if (verificador == false) // VAI PARA A PÁGINA DE LOGIN
                        {
                            Console.WriteLine("Digite seu usuário:");
                            username = Console.ReadLine();
                            Console.WriteLine("Digite sua senha:");
                            passwd = Console.ReadLine();

                            verificador = login.verificaUser(username, passwd); // VERIFICA SE O USUÁRIO ESTÁ CORRETO

                            if (verificador == true)
                            {
                                retorno = "logado"; //SAI DOS LOOPS E PASSA
                            }
                            else
                            {
                                Console.WriteLine("Usuário ou senha não encontrados!");
                            }

                            contador++;
                        }
                    }

                    if (verificador == true)
                    {
                        session_index = login.getUser(); //ATRIBUI O INDEX O USUÁRIO PARA FUTURAS PESQUISAS
                        permissao = login.permissao[session_index];//ATRIBUI PERMISSÃO DO USUÁRIO
                    }
                }
                else if (retorno == "cadastro") //INICIA SESSÃO DE CADASTRO
                {
                    string nome = ""; //VARIÁVEL DE NOME
                    string user = "";//VARIÁVEL DE USUÁRIO
                    string senha = "";//VARIÁVEL DE SENHA

                    while (nome == "" || senha == "" || user == "")//ENQUANTO AS TRÊS NÃO FOREM PREENCHIDAS, RETORNA A ESSE MENU
                    {

                        if (nome == "") //TRATA QUE VARÍAVEL ESTÁ VAZIA
                        {
                            Console.WriteLine("Digite seu nome:");
                            nome = Console.ReadLine();
                        }
                        if (user == "")//TRATA QUE VARÍAVEL ESTÁ VAZIA
                        {
                            Console.WriteLine("Digite seu usuário:");
                            user = Console.ReadLine();
                        }
                        if (senha == "")//TRATA QUE VARÍAVEL ESTÁ VAZIA
                        {
                            Console.WriteLine("Digite sua senha:");
                            senha = Console.ReadLine();
                        }

                        verificador = login.verificaCad(user, senha); //VERIFICA SE JÁ EXISTE O CADASTRO

                        if (verificador == false)
                        {
                            user = "";
                            senha = "";
                            Console.WriteLine("Usuário ou senha inválidos!"); //RETORNA QUANDO USUÁRIO E SENHA ESTÃO CADASTRADOS
                        }
                        else
                        {
                            login.setUser(nome, user, senha); //INCLUIR USUÁIRO NO SISTEMA
                            Console.WriteLine("Usuário {0} cadastrado com sucesso!", nome);
                            Console.WriteLine("Por favor, faça login novamente!");
                            Console.WriteLine();
                        }

                    } // while user

                    retorno = "login";
                    verificador = false;

                } //else if
            } // while verificador

            string menu1 = ""; //VARIÁVEL PARA PRIMEIRA ESCOLHA DO MENU

            while (true)
            {
                switch (permissao) //EXIBE MENU DE ACORDO SUA PERMISSÃO
                {
                    case 1:
                        menu.menuCliente(); //MENU CLIENTE
                        menu1 = Console.ReadLine();
                        break;
                    case 2:
                        menu.menuFuncionario();//MENU FUNCIONÁRIO
                        menu1 = Console.ReadLine();
                        break;
                    case 99:
                        menu.menuRoot(); //MENU ROOT
                        menu1 = Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("Erro");
                        break;
                }

                switch (menu1) //EXECUTA AÇÃO DA PRIMEIRA ESCOLHA
                {
                    case "0": //ALTERAÇÃO DE SENHA DO USUÁRIO
                        bool verificaSenha = login.alterarSenha(session_index);
                        if (verificaSenha == true)
                        {
                            Console.WriteLine("Senha alterada com sucesso!");
                        }
                        else
                        {
                            Console.WriteLine("Erro ao alterar sua senha!");
                        }
                        break;
                    case "1": // LISTAR PRODUTOS E ESCOLHER COMPRA
                        produtos.listaProdutos();//LISTA PRODUTOS
                        Console.WriteLine("Digite o ID de um de nossos itens para que ele vá para seu carrinho ou digite e para sair");
                        string item = Console.ReadLine();//RECEBE ESCOLHA
                        Console.WriteLine("Digite a quantidade que você deseja:");
                        string quant = Console.ReadLine();
                        if (item != "e")//SAI DO SISTEMA CASO O USUÁRIO QUEIRA
                        {
                            try //TRATAR ESCOLHA DE ITENS INVÁLIDOS
                            {
                                int convert_item = int.Parse(item); //TENTA CONVERSÃO PARA INTEIRO

                                if (convert_item >= 0 && convert_item < produtos.getCount())
                                {
                                    bool repetido = carrinho.procuraRepetido(convert_item);
                                    if (repetido == true)
                                    {
                                        int convert_quant = int.Parse(quant);
                                        int index_repetido = carrinho.getIndex(convert_item);
                                        int quant_anterior = carrinho.getQuant(index_repetido);

                                        convert_quant = convert_quant + quant_anterior;

                                        bool valida = produtos.validaQuant(convert_item, convert_quant); // VALIDA QUANTIDADE ESCOLHIDA PELO USUÁRIO

                                        if (valida == true)
                                        {
                                            carrinho.atualizaSaldo(index_repetido, convert_quant);
                                            Console.WriteLine("Saldo atualizado com sucesso!");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Quantidade maior do que a do nosso estoque!");
                                        }
                                        break;
                                    }
                                    else
                                    {
                                        int convert_quant = int.Parse(quant);
                                        bool valida_quant = produtos.validaQuant(convert_item, convert_quant); // VALIDA QUANTIDADE ESCOLHIDA PELO USUÁRIO
                                        if (valida_quant == true)
                                        {
                                            if (convert_item >= 0 && convert_item < produtos.getCount()) //VALIDA ESCOLHA DE ACORDO COM
                                            {                                                           //TAMANHO DO ARRAY DOS ITENS CADASTRADOS
                                                bool verifica_add_carrinho = carrinho.AddCarrinho(convert_item, convert_quant);//INSERIR INDÍCE NO ARRAY CARRINHO
                                                Console.WriteLine("Item incluído com sucesso!");
                                            }
                                            else
                                            {
                                                Console.WriteLine("Livro não encontrado!");//NÚMEOR MAIOR OU MENOR QUE TAMANHO DO ARRAY
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Quantidade maior do que a do nosso estoque!");
                                        }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Item inexistente!");
                                }
                            }
                            catch (FormatException)//EXCEÇÃO PARA TRATAR ERRO DE FORMATO
                            {
                                Console.WriteLine("Opção inválida!");//LETRA DIGITADA
                            }
                            break;
                        }
                        else
                        {
                            break;
                        }
                        break;
                    case "2":
                        int item_carrinho;
                        string tit_Carrinho;
                        int quant_carrinho;
                        double preco_item;

                        double total_compra = 0.0;

                        string f_compra;

                        if (carrinho.getCount() > 0)
                        {

                            for (int i = 0; i < carrinho.getCount(); i++)
                            {
                                item_carrinho = carrinho.getItem(i);
                                tit_Carrinho = produtos.retornaTitulo(item_carrinho);
                                quant_carrinho = carrinho.getQuant(i);
                                preco_item = produtos.getPreco(item_carrinho);

                                Console.Write("Item: {0} - ", item_carrinho);
                                Console.Write("Título: {0} |", tit_Carrinho);
                                Console.Write("Quantidade: {0} |", quant_carrinho);
                                Console.WriteLine("Valor unitário: R${0} | Valor total item: R${1} |", preco_item, preco_item * quant_carrinho);
                                total_compra = total_compra + preco_item * quant_carrinho;
                            }
                            Console.WriteLine("Valor Total da compra: R$ {0}", total_compra);

                            string retira_item = "s";

                            while (retira_item == "s" || retira_item == "S")
                            {
                                Console.WriteLine("Digite 's' para retirar algum item:");
                                retira_item = Console.ReadLine();

                                if (retira_item == "s")
                                {
                                    Console.WriteLine("Digite o nº do item que deseja retirar");
                                    string item_retira = Console.ReadLine();
                                    try
                                    {
                                        int item_retira_convert = int.Parse(item_retira);
                                        carrinho.removeItem(item_retira_convert);
                                    }
                                    catch (FormatException)//EXCEÇÃO PARA TRATAR ERRO DE FORMATO
                                    {
                                        Console.WriteLine("Opção inválida!");//LETRA DIGITADA
                                    }
                                }
                            }

                            Console.WriteLine("Digite 's' para finalizar sua compra?");
                            f_compra = Console.ReadLine();
                            if (f_compra == "s")
                            {
                                carrinho.exibePagamento(total_compra);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Nenhum item adicionado ao carrinho!");
                        }
                        break;
                    case "3":
                        string autor_insert;
                        int quant_insert;
                        double preco_insert;

                        Console.WriteLine("Digite o titulo do produto");
                        string titulo = Console.ReadLine();
                        bool verifica_tit = produtos.verificaTitulo(titulo);
                        if (verifica_tit == true)
                        {
                            while (true) 
                            { 
                                try
                                {
                                    Console.WriteLine("Qual é o autor do livro?");
                                    autor_insert = Console.ReadLine();
                                    Console.WriteLine("Qual o estoque do produto?");
                                    quant_insert = int.Parse(Console.ReadLine());
                                    Console.WriteLine("Qual o preço do produto?");
                                    preco_insert = double.Parse(Console.ReadLine());
                                    break;
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Formato Inválido!");
                                }
                            }
                            produtos.cadItem(titulo, autor_insert, quant_insert, preco_insert);
                        }
                        else
                        {
                            Console.WriteLine("Produto já cadastrado anteriormente!");
                        }
                        break;
                    case "4":
                        bool verifica_func = false;
                        string nome_func = "";
                        string user_func = "";
                        string senha_func = "";

                        while (verifica_func == false)
                        {
                            if (nome_func == "" || user_func == "" || senha_func == "") 
                            { 
                                if (nome_func == "")
                                {
                                    Console.WriteLine("Digite o nome do funcionário:");
                                    nome_func = Console.ReadLine();
                                }
                                if (user_func == "")
                                {
                                    Console.WriteLine("Digite o usuário do sistema");
                                    user_func = Console.ReadLine();
                                }
                                if (senha_func == "")
                                {
                                    Console.WriteLine("Digite a senha do usuário:");
                                    senha_func = Console.ReadLine();
                                }
                            } else
                            {
                                bool verifica_cad = login.verificaCad(user_func, senha_func);

                                if (verifica_cad == true)
                                {
                                    login.setFunc(nome_func, user_func, senha_func);
                                    verifica_func = true;
                                    Console.WriteLine("Cadastrado com sucesso!");
                                }
                                else
                                {
                                    Console.WriteLine("Usuário já cadastrado!");
                                    user_func = "";
                                    senha_func = "";
                                }
                                verifica_func = true;
                            }
                        }
                        break;
                    case "5":
                        produtos.listaProdutos();
                        break;
                    default:
                        Console.WriteLine("Erro!");
                        break;
                }

            }

        }
    }
}
