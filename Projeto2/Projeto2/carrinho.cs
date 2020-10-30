using System;
using System.Collections.Generic;
using System.Threading;

public class Carrinho
{
	List<int> carrinho_item = new List<int>();
	List<int> carrinho_quant = new List<int>();
	public bool AddCarrinho(int indice, int quantidade)
	{
		this.carrinho_item.Add(indice);
		this.carrinho_quant.Add(quantidade);

		return true;
	}

	public void atualizaSaldo(int index,int quantidade)
    {
		this.carrinho_quant[index] = quantidade;

	}

	public int getIndex(int item)
    {
		return this.carrinho_item.IndexOf(item);
    }

	public bool procuraRepetido(int item)
    {
		if (this.carrinho_item.IndexOf(item) == -1)
		{
			return false;
		}

		return true;
    }
	public void removeItem(int index)
    {
		this.carrinho_item.Remove(index);
	}

	public void cronometro(int limite)
    {
		for (int i = 0;i < limite;i++)
		{
			Thread.Sleep(1000);
			Console.WriteLine("{0} segundo(s)",i);
		}
	}

	public void cartao()
	{
		Console.WriteLine("Insira ou passe o cartão:");
		cronometro(7);
		Console.WriteLine("Digite sua senha:");
		cronometro(10);
		Console.WriteLine("Compra aprovada com sucesso!");
	}

	public void dinheiro(double total_compra)
	{
		double valor = 0.0;

		Console.WriteLine("Total da sua compra: R${0}",total_compra);
		cronometro(3);
		Console.WriteLine("Qual é o valor que deseja pagar?");
		cronometro(3);
		while (valor < total_compra)
        {
			try
			{
				valor = double.Parse(Console.ReadLine());
			}
			catch (FormatException)
			{
				Console.WriteLine("Valor inválido");
			}

			if (total_compra - valor > 0)
            {
				Console.WriteLine("Seu troco é de: R$ {}", total_compra - valor);
				cronometro(3);
			}
			else
            {
				Console.WriteLine("Você não tem troco");
            }

		}
	}

	public void picpay()
	{
		Console.WriteLine("Nosso PicPay é: @Livraria_DG");
		cronometro(7);
		Console.WriteLine("Realize o pagamento no app!");
		cronometro(10);
		Console.WriteLine("Compra aprovada com sucesso!");
	}

	public void exibePagamento(double total_compra)
    {
		while (true) { 
			Console.WriteLine("Qual sua forma de pagamento ?");
			Console.WriteLine("1 - Cartão de crédito");
			Console.WriteLine("2 - Cartão de débito");
			Console.WriteLine("3 - Dinheiro");
			Console.WriteLine("4 - PicPay");
			try
			{
				int option = int.Parse(Console.ReadLine());
				if (option > 0 && option < 5)
                {
                    switch (option)
                    {
						case 1:
							cartao();
							break;
						case 2:
							cartao();
							break;
						case 3:
							dinheiro(total_compra);
							break;
						case 4:
							picpay();
							break;
					}

					this.carrinho_item.Clear();
					this.carrinho_quant.Clear();

					break;
				}
			}
			catch(FormatException)
            {
				Console.WriteLine("Formato inválido!");
            }
		}
	}
	public int getCount()
    {
		return this.carrinho_item.Count;
    }

	public int getQuant(int index)
    {
		return this.carrinho_quant[index];
    }

	public int getItem(int index)
    {
		return this.carrinho_item[index];
    }
}
