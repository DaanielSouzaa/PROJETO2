using Projeto2;
using System;
using System.Collections.Generic;

public class Login
{
	private List<string> nome = new List<string>();
	private List<string> user = new List<string>();
	private List<string> senha = new List<string>();
	public List<int> permissao = new List<int>();

	private int id_user;

	public bool alterarSenha(int index)
    {
		Console.WriteLine("Digite sua antiga senha:");
		string senha = Console.ReadLine();
		if (senha == this.senha[index])
        {
			Console.WriteLine("Digite sua nova senha:");
			senha = Console.ReadLine();
			this.senha[index] = senha;

			return true;

		}

		return false;
    }

	public void setId(int id_user)
	{
		this.id_user = id_user;
	}

	

	public int getUser()
    {
		return this.id_user;
	}

	private void setRoot()
	{
		this.nome.Add("root");
		this.permissao.Add(99);
		this.user.Add("root");
		this.senha.Add("Teste@1234");
	}


	public Login()
	{
		setRoot();
	}

	public bool setFunc(string nome,string user,string senha)
    {
		this.nome.Add(nome);
		this.permissao.Add(2);
		this.user.Add(user);
		this.senha.Add(senha);

		return true;
    }

	public void setUser(string nome, string user, string senha)
    {
		this.nome.Add(nome);
		this.permissao.Add(1);
		this.user.Add(user);
		this.senha.Add(senha);

	}

	public bool verificaUser(string user, string senha)
    {
        for (int i = 0;i < this.user.Count;i++)
        {
			if (this.user[i] == user && this.senha[i] == senha)
			{
				setId(i);
				return true;
            }
        }

		return false;
    }

	public bool verificaCad(string user, string senha)
	{
		for (int i = 0; i < this.user.Count; i++)
		{
			if (this.user[i] == user && this.senha[i] == senha)
			{
				return false;
			}
		}

		return true;
	}
}
