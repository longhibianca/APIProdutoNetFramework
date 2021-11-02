using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIProdutoNetFramework.Models
{
    public class ProdutoRepositorio : InterfaceProdutoRepositorio
    {
        private List<Produto> produtos = new List<Produto>();
        private int proximoId = 1;

        //construtor para iniciar já uma listagem de produtos
        public ProdutoRepositorio()
        {
            Add(new Produto { Nome = "Guaraná Antartica", Categoria = "Refrigerantes", Preco = 4.59M });
            Add(new Produto { Nome = "Suco de Laranja Prats", Categoria = "Sucos", Preco = 5.75M });
            Add(new Produto { Nome = "Mostarda Hammer", Categoria = "Condimentos", Preco = 3.90M });
            Add(new Produto { Nome = "Molho de Tomate Cepera", Categoria = "Condimentos", Preco = 2.99M });
            Add(new Produto { Nome = "Suco de Uva Aurora", Categoria = "Sucos", Preco = 6.50M });
            Add(new Produto { Nome = "Pepsi-Cola", Categoria = "Refrigerantes", Preco = 4.25M });
        }

        public Produto Add(Produto item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            item.Id = proximoId++;
            produtos.Add(item);
            return item;
        }

        public Produto Get(int id)
        {
            //retorna o produto que tem o id igual ao parametro
            return produtos.Find(p => p.Id == id);
        }

        public IEnumerable<Produto> GetAll()
        {
            return produtos;
        }

        public void Remove(int id)
        {
            //remove o produto que tem o id igual ao parametro
            produtos.RemoveAll(p => p.Id == id);
        }

        public bool Update(Produto item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            //localiza dentro de produtos o que tem o indice igual ao item passado
            int indice = produtos.FindIndex(p => p.Id == item.Id);

            if (indice == -1)
            {
                return false;
            }
            //remove o produto do indice e adiciona um novo no mesmo indice
            produtos.RemoveAt(indice);
            produtos.Add(item);
            return true;
        }
    }
}