using System;

public class Menu
{
	public void menuCliente()
	{
		Console.WriteLine("0 - Alterar minha senha");
		Console.WriteLine("1 - Listar produtos");
		Console.WriteLine("2 - Consultar carrinho");
	}

	public void menuFuncionario()
	{
		menuCliente();
		Console.WriteLine("3 - Cadastro de produto");
	}

	public void menuRoot()
	{
		menuFuncionario();
		Console.WriteLine("4 - Cadastro de funcionário");
	}

	public string saudacao()
    {
		string cadastro = "3";

		Console.WriteLine("Bem-vindo a nossa loja!");
		while (cadastro != "2" && cadastro != "1")
		{  
			Console.WriteLine("Já possui cadastro em nosso sistema?");
			Console.WriteLine("Digite 1 para sim e 2 para não:");
			cadastro = Console.ReadLine();
			if (cadastro == "1")
			{
				return "login";
			}
			else if (cadastro == "2")
			{
				return "cadastro";
			}
			else
			{
				return "Erro";
			}
		}
		return "Erro";
	}
}
