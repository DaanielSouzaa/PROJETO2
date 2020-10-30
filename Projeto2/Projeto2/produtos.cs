using System;
using System.Collections.Generic;

public class Produtos
{
    List<string> livro_titulo = new List<string>();
    List<double> livro_preco = new List<double>();
    List<int> livro_saldo = new List<int>();
    List<string> livro_autor = new List<string>();


    private void preencherTitulos() {

        this.livro_titulo.Add("Cronicas de Narnia");
        this.livro_titulo.Add("O Senhor dos Aneis ");
        this.livro_titulo.Add("A Guerra dos Tronos");
        this.livro_titulo.Add("O Maravilhoso Magico de Oz");
        this.livro_titulo.Add("Eragon");
        this.livro_titulo.Add("Caixa de Passaros");
        this.livro_titulo.Add("O Pequeno Principe");
        this.livro_titulo.Add("Harry Potter e a pedra filosofal");
        this.livro_titulo.Add("A Cabana");
        this.livro_titulo.Add("Sherlock Holmes");
        this.livro_titulo.Add("A Culpa e das Estrelas");
        this.livro_titulo.Add("O Morro dos Ventos Uivantes");
        this.livro_titulo.Add("Um Dia");
        this.livro_titulo.Add("A Mulher do Viajante no Tempo");
        this.livro_titulo.Add("Orgulho e Preconceito");
        this.livro_titulo.Add("A Profecia");
        this.livro_titulo.Add("O Bebe de Rosemary");
        this.livro_titulo.Add("A Coisa");
        this.livro_titulo.Add("O Cemiterio");
        this.livro_titulo.Add("A Casa Infernal");
        this.livro_titulo.Add("Alice no Pais das Maravilhas");
        this.livro_titulo.Add("Contos de Grimm");
        this.livro_titulo.Add("Viagem ao Centro da Terra");
        this.livro_titulo.Add("As Aventuras de Pinoquio");
        this.livro_titulo.Add("Onde Vivem os Monstros");

    }

    private void preencherAutores()
    {
        this.livro_autor.Add("Clive Staples Lewis");
        this.livro_autor.Add("J. R. R. Tolkien");
        this.livro_autor.Add("George R.R. Martin");
        this.livro_autor.Add("L. Frank Baum");
        this.livro_autor.Add("Christopher Paolini");
        this.livro_autor.Add("Josh Malerman");
        this.livro_autor.Add("Antoine Saint-Exupery");
        this.livro_autor.Add("J. K. Rowling");
        this.livro_autor.Add("William P. Young");
        this.livro_autor.Add("Arthur Conan Doyle");
        this.livro_autor.Add("John Green");
        this.livro_autor.Add("Emily Bronte");
        this.livro_autor.Add("David Nicholls");
        this.livro_autor.Add("Audrey Niffenegger");
        this.livro_autor.Add("Jane Austen");
        this.livro_autor.Add("David Seltzer");
        this.livro_autor.Add("Ira Levin");
        this.livro_autor.Add("Stephen King");
        this.livro_autor.Add("Stephen King");
        this.livro_autor.Add("Richard Matheson");
        this.livro_autor.Add("Lewis Carroll");
        this.livro_autor.Add("Jacob e Wilhelm Grimm");
        this.livro_autor.Add("Julio Verne");
        this.livro_autor.Add("Carlo Collodi");
        this.livro_autor.Add("Maurice Sendak");
    }

    public void preencherSaldo()
    {
        this.livro_saldo.Add(10);
        this.livro_saldo.Add(20);
        this.livro_saldo.Add(30);
        this.livro_saldo.Add(40);
        this.livro_saldo.Add(50);
        this.livro_saldo.Add(100);
        this.livro_saldo.Add(200);
        this.livro_saldo.Add(32131);
        this.livro_saldo.Add(123);
        this.livro_saldo.Add(1231);
        this.livro_saldo.Add(43);
        this.livro_saldo.Add(53);
        this.livro_saldo.Add(453);
        this.livro_saldo.Add(53);
        this.livro_saldo.Add(435);
        this.livro_saldo.Add(64);
        this.livro_saldo.Add(7);
        this.livro_saldo.Add(678);
        this.livro_saldo.Add(5);
        this.livro_saldo.Add(656);
        this.livro_saldo.Add(7);
        this.livro_saldo.Add(65467);
        this.livro_saldo.Add(6554);
        this.livro_saldo.Add(567);
        this.livro_saldo.Add(54456);
    }

    public void preencherPrecos()
    {
        this.livro_preco.Add(12.32);
        this.livro_preco.Add(32.5);
        this.livro_preco.Add(54.123);
        this.livro_preco.Add(435.75);
        this.livro_preco.Add(90.8);
        this.livro_preco.Add(78.6);
        this.livro_preco.Add(56.7);
        this.livro_preco.Add(45.2);
        this.livro_preco.Add(457.334);
        this.livro_preco.Add(342423.65);
        this.livro_preco.Add(34.1);
        this.livro_preco.Add(10.2);
        this.livro_preco.Add(34.4);
        this.livro_preco.Add(1.99);
        this.livro_preco.Add(12.24);
        this.livro_preco.Add(4324.33);
        this.livro_preco.Add(2.23);
        this.livro_preco.Add(33.12);
        this.livro_preco.Add(1234.45);
        this.livro_preco.Add(24565.7);
        this.livro_preco.Add(765.43);
        this.livro_preco.Add(34567.5);
        this.livro_preco.Add(89.76);
        this.livro_preco.Add(67.6);
        this.livro_preco.Add(87.6);
    }

    public int getCount()
    {
        return this.livro_autor.Count;
    }

    public bool validaQuant(int indice,int quantidade)
    {
        if (quantidade <= this.livro_saldo[indice])
        {
            return true;
        }

        return false;
    }

    public double getPreco(int index)
    {
        return this.livro_preco[index];
    }

    public void cadItem(string titulo,string autor,int saldo,double preco)
    {
        this.livro_titulo.Add(titulo);
        this.livro_autor.Add(autor);
        this.livro_saldo.Add(saldo);
        this.livro_preco.Add(preco);
    }

    public void setSaldo(int index, int saldo)
    {
        this.livro_saldo[index] = this.livro_saldo[index] - saldo;
    }

    public string retornaTitulo(int index)
    {
        return this.livro_titulo[index];
    }

    public bool verificaTitulo(string titulo)
    {
        if (this.livro_titulo.IndexOf(titulo) == -1)
        {
            return true;
        }
        return false;
    }
    public void listaProdutos()
    {
        for (int i = 0;i < livro_autor.Count; i++)
        {
            if (this.livro_saldo[i] > 0) 
            {
                Console.WriteLine(" _____________________________________________________________________________________________________________________________");
                Console.WriteLine("|                |                           |                        |                           |                           |");
                Console.WriteLine("|       ID       |            LIVRO          |           AUTOR        |           SALDO           |           PRECO           |");
                Console.WriteLine("|________________|___________________________|________________________|___________________________|___________________________|");
                Console.WriteLine("|       {0}       |   {1}   |   {2}       |             {3}           |          {4}           |", i, this.livro_titulo[i], this.livro_autor[i], this.livro_saldo[i], this.livro_preco[i]);
                Console.WriteLine("|________________|___________________________|________________________|___________________________|___________________________|");
            }
         }
    }

    public Produtos()
    {
        preencherTitulos();
        preencherPrecos();
        preencherAutores();
        preencherSaldo();
    }
}
