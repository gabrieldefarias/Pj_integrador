using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PJIntegrador.classes;

namespace PJIntegrador.Classes
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public List<Endereco> Enderecos { get; set; }
        public bool Ativo { get; set; }
        //=============================================construtor
        public Cliente() { }

        public Cliente(string nome, string cpf, string email, string telefone, List<Endereco> enderecos = null, bool ativo = true)
        {
            Nome = nome;
            Cpf = cpf;
            Email = email;
            Telefone = telefone;
            Enderecos = enderecos;
            Ativo = ativo;
        }

        public Cliente(int id, string nome, string cpf, string email, string telefone, List<Endereco> enderecos = null, bool ativo = true)
        {
            Id = id;
            Nome = nome;
            Cpf = cpf;
            Email = email;
            Telefone = telefone;
            Enderecos = enderecos;
            Ativo = ativo;
        }
        //=============================================================================metodo
        public void Inserir()
        {
            var cmd = Banco.Abrir(); // inserir usando concatenações
            if (cmd.Connection.State == System.Data.ConnectionState.Open)
            {
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "insert " +
                    "cliente(nome, cpf, email, telefone, ativo) " +
                    "values ('"+Nome+"','"+Cpf+"','"+Email+"','"+Telefone+"',default);";
                cmd.ExecuteNonQuery();
                cmd.CommandText = "select @@identity";
                Id = Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
    }
}
