using System;
using System.Collections.Generic;
using System.IO;
using Ponto_Digital.Models;

namespace Ponto_Digital.Repositorios{
    public class ClienteRepositorio
    {
        private const string PATH = "DataBases/Cliente.csv";
        public void RegistrarClienteNoCSV(ClienteModel cliente){
            if(File.Exists(PATH)){
                cliente.Id = File.ReadAllLines(PATH).Length + 1;
            }else{
                cliente.Id = 1;
            }
            StreamWriter sw = new StreamWriter(PATH, true);

            cliente.DataCadastro = DateTime.Now;
            cliente.Tipo = "comum";

            sw.WriteLine($"{cliente.Id};{cliente.Nome};{cliente.Email};{cliente.Senha};{cliente.DataCadastro};{cliente.Tipo}");
        
          sw.Close();
        } 

        public List<ClienteModel> ListarClientes(){
                List<ClienteModel> listaDeCliente = new List<ClienteModel>();
                string[] linhas = File.ReadAllLines(PATH);

                foreach (var item in linhas)
                {
                    if (item == null){
                        continue;
                    } 
                    string[] dados = item.Split(";");
                    ClienteModel cliente = new ClienteModel();
                    cliente.Id = int.Parse(dados[0]);
                    cliente.Nome = dados[1];
                    cliente.Email = dados[2];
                    cliente.Senha = dados[3];
                    cliente.DataCadastro =DateTime.Parse(dados[4]);
                    cliente.Tipo = dados[5];

                    listaDeCliente.Add(cliente);
                }
                    return listaDeCliente;
        }

        public ClienteModel BuscarPorEmailESenha(string email,string senha){
            
            List<ClienteModel> listaDeClientes = ListarClientes();
            foreach (var item in listaDeClientes)
            {
                if( item != null){
                    if(item.Email.Equals(email) && item.Senha.Equals(senha)){
                        return item;
                    }
                }
            }
            return null;

        }

    }
}
